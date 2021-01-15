using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TileDatabase))]
public class WorldManager : MonoBehaviour
{
  public static WorldManager instance;

  public static event Action<Vector2Int, TileData.TileType> onBlockPlace = delegate { };
  public static event Action<Vector2Int, TileData.TileType> onBlockBreak = delegate { };

  private GameManager game;
  private WorldGenerator worldGenerator;
  private TileDatabase tileDatabase;

  [SerializeField] GameObject player;
  [SerializeField] WorldData world;
  [SerializeField] [Range(1, 5)] int radius = 3;

  [SerializeField] Tilemap baseTilemap;
  [SerializeField] Tilemap collisionTilemap;
  [SerializeField] Tilemap glowTilemap;

  private ConcurrentDictionary<Vector2Int, Chunk> chunks;
  private HashSet<Vector2Int> renderedChunks;
  private Vector3 lastBuildPos;

  [Header("Debugging")]
  [SerializeField] bool debugging;
  [SerializeField] bool showChunkCenter;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
      return;
    }

    DontDestroyOnLoad(gameObject);

    game = GameObject.FindObjectOfType<GameManager>();
    tileDatabase = GetComponent<TileDatabase>();
  }

  void Start()
  {
    game.GetEffectsManager().ChangeBloom(world.ambientColor);
    baseTilemap.ClearAllTiles();
    collisionTilemap.ClearAllTiles();
    glowTilemap.ClearAllTiles();

    StartCoroutine(BuildBackground());

    worldGenerator = new WorldGenerator(world, 420);
    chunks = new ConcurrentDictionary<Vector2Int, Chunk>();
    renderedChunks = new HashSet<Vector2Int>();

    lastBuildPos = player.transform.position;
    var firstBuildAt = WorldGenerator.WorldPosToChunkPos(lastBuildPos);
    BuildChunkAt(firstBuildAt.x, firstBuildAt.y);
    BuildNearPlayer();
  }

  void Update()
  {
    Vector3 movement = lastBuildPos - player.transform.position;
    if (movement.magnitude > WorldGenerator.CHUNK_SIZE)
    {
      lastBuildPos = player.transform.position;
      BuildNearPlayer();
    }
  }

  private void BuildNearPlayer()
  {
    StopCoroutine("RecursiveBuildWorld");
    var playerPosition = WorldGenerator.WorldPosToChunkPos(player.transform.position);
    StartCoroutine(RecursiveBuildWorld(playerPosition.x, playerPosition.y, radius));
  }

  public IEnumerator RecursiveBuildWorld(int x, int y, int radius)
  {
    radius--;
    if (radius < 0)
    {
      yield break;
    }

    StartCoroutine(BuildChunkAt(x, y));

    StartCoroutine(RecursiveBuildWorld(x + 1, y, radius));
    StartCoroutine(RecursiveBuildWorld(x - 1, y, radius));
    StartCoroutine(RecursiveBuildWorld(x, y + 1, radius));
    StartCoroutine(RecursiveBuildWorld(x, y - 1, radius));
    yield return null;
  }

  IEnumerator BuildChunkAt(int x, int y)
  {
    // TODO: add saving and loading
    Chunk chunk;
    if (!chunks.TryGetValue(new Vector2Int(x, y), out chunk))
    {
      chunk = worldGenerator.GenerateChunk(x, y);
      chunks.AddOrUpdate(new Vector2Int(x, y), chunk, (k, v) => v);
    }
    StartCoroutine(RenderChunk(x, y, chunk.tileData));
    yield break;
  }

  IEnumerator RenderChunk(int x, int y, TileData.TileType[,] tiles, bool rerender = false)
  {
    if (renderedChunks.Contains(new Vector2Int(x, y)) && !rerender)
    {
      yield break;
    }
    TileBase[] collisionArray = new TileBase[WorldGenerator.CHUNK_SIZE * WorldGenerator.CHUNK_SIZE];
    TileBase[] glowArray = new TileBase[WorldGenerator.CHUNK_SIZE * WorldGenerator.CHUNK_SIZE];

    var i = 0;
    for (int localX = 0; localX < WorldGenerator.CHUNK_SIZE; localX++)
    {
      for (int localY = 0; localY < WorldGenerator.CHUNK_SIZE; localY++)
      {

        TileData tileData = tileDatabase.GetTile(tiles[localX, localY]);
        Tile tile = TileData.CreateTile(tileData);
        if (TileData.TilemapLayer.COLLISION.Equals(tileData?.tilemap))
        {
          collisionArray[i] = tile;
        }
        else if (TileData.TilemapLayer.GLOW.Equals(tileData?.tilemap))
        {
          glowArray[i] = tile;
        }
        i++;
      }
    }

    int startX = x * WorldGenerator.CHUNK_SIZE;
    int endX = x * WorldGenerator.CHUNK_SIZE + WorldGenerator.CHUNK_SIZE - 1;
    int startY = y * WorldGenerator.CHUNK_SIZE;
    int endY = y * WorldGenerator.CHUNK_SIZE + WorldGenerator.CHUNK_SIZE - 1;

    var chunkBounds = new BoundsInt(startX, startY, 0, WorldGenerator.CHUNK_SIZE, WorldGenerator.CHUNK_SIZE, 1);
    collisionTilemap.SetTilesBlock(chunkBounds, collisionArray);
    glowTilemap.SetTilesBlock(chunkBounds, glowArray);
    renderedChunks.Add(new Vector2Int(x, y));
    yield break;
  }

  IEnumerator BuildBackground()
  {
    baseTilemap.SetTile(new Vector3Int(-world.size, -world.size, 0), TileData.CreateTile(tileDatabase.GetTile(world.baseTile)));
    baseTilemap.SetTile(new Vector3Int(-world.size, world.size, 0), TileData.CreateTile(tileDatabase.GetTile(world.baseTile)));
    baseTilemap.SetTile(new Vector3Int(world.size, -world.size, 0), TileData.CreateTile(tileDatabase.GetTile(world.baseTile)));
    baseTilemap.SetTile(new Vector3Int(world.size, world.size, 0), TileData.CreateTile(tileDatabase.GetTile(world.baseTile)));

    baseTilemap.FloodFill(Vector3Int.zero, TileData.CreateTile(tileDatabase.GetTile(world.baseTile)));
    yield break;
  }

  public bool HasTileAt(Vector3 pos)
  {
    return GetTileAt(pos) != null;
  }

  public TileData GetTileAt(Vector3 pos)
  {
    var chunkPoint = WorldGenerator.WorldPosToChunkPos(pos);
    var blockPointInChunk = WorldGenerator.WorldPosToPosInChunk(Vec3ToVec2Int(pos));

    if (showChunkCenter)
    {
      game.GetEffectsManager().SpawnParticle(
        Particle.Type.BLUE_ENERGY,
        (new Vector3(chunkPoint.x, chunkPoint.y, 0) * WorldGenerator.CHUNK_SIZE) +
        new Vector3(WorldGenerator.CHUNK_SIZE / 2, WorldGenerator.CHUNK_SIZE / 2)
        );
    }

    Chunk chunk;
    if (!chunks.TryGetValue(chunkPoint, out chunk))
    {
      return null;
    }
    return tileDatabase.GetTile(chunk.tileData[blockPointInChunk.y, blockPointInChunk.x]);
  }

  public void SetTileAt(Vector3 pos, TileData.TileType tileType)
  {
    var chunkPoint = WorldGenerator.WorldPosToChunkPos(pos);

    Chunk chunk;
    if (!chunks.TryGetValue(chunkPoint, out chunk))
    {
      return;
    }

    var blockPointInChunk = WorldGenerator.WorldPosToPosInChunk(Vec3ToVec2Int(pos));
    chunk.tileData[blockPointInChunk.y, blockPointInChunk.x] = tileType;

    StartCoroutine(RenderChunk(chunkPoint.x, chunkPoint.y, chunk.tileData, true));

    if (tileType.Equals(TileData.TileType.AIR))
      onBlockBreak(Vec3ToVec2Int(pos), tileType);
    else
      onBlockPlace(Vec3ToVec2Int(pos), tileType);
  }

  private Vector2Int Vec3ToVec2Int(Vector3 pos) => Vector2Int.FloorToInt(((Vector2)pos));
  private Vector3Int Vec3ToVec3Int(Vector3 pos) => Vector3Int.FloorToInt(pos);
  private Vector3Int Vec2IntToVec3Int(Vector2Int pos) => new Vector3Int(pos.x, pos.y, 0);
}
