// GENERATED AUTOMATICALLY FROM 'Assets/_Game/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""d38104da-fe6a-48c6-bfad-287ea0d7afad"",
            ""actions"": [
                {
                    ""name"": ""MoveHorizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1493964e-584e-4d32-951b-429744b9bc2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveVertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""be21fd6e-7c7d-4edf-8bbc-b710573b8c12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Break"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ba1a3d45-05eb-4e6a-9579-86aab9b5c390"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Place"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e37c0afc-da3e-41ac-9619-d495a4fd2be7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bdab18aa-f175-4eac-8dba-d45606ecfb69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Screenshot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""174f9423-abc9-478b-bb10-1ed4bab2ae32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""363e56f1-5077-4ba7-93e9-ce5733ea9ab6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""23a2e36c-4fc1-4308-9f0c-2890d7d1ce7a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e0edd05a-0aee-47fa-b81a-d57ee72acd30"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Active"",
                    ""id"": ""f3716be4-3b9d-40a1-a608-398f4fe4502c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Break"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""58703e1d-95fa-4692-97d0-4d58008ef439"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a8b3bc8a-c8ef-44fd-ba02-08acab23ed5d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b5a489d2-cbcb-4cbe-a1c4-839a1472620b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b039d78-13ae-4199-ad77-affe332abc89"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""e503d104-017e-46a2-8751-a042f5067f07"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0df2e625-5d53-4056-8998-c652c16753cc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3ee5eebc-898a-48e7-b9a7-e4f4aa551756"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""291f4aa0-f91b-4bcd-8002-becc8c62b0f6"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screenshot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_MoveHorizontal = m_Main.FindAction("MoveHorizontal", throwIfNotFound: true);
        m_Main_MoveVertical = m_Main.FindAction("MoveVertical", throwIfNotFound: true);
        m_Main_Break = m_Main.FindAction("Break", throwIfNotFound: true);
        m_Main_Place = m_Main.FindAction("Place", throwIfNotFound: true);
        m_Main_Interact = m_Main.FindAction("Interact", throwIfNotFound: true);
        m_Main_Screenshot = m_Main.FindAction("Screenshot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_MoveHorizontal;
    private readonly InputAction m_Main_MoveVertical;
    private readonly InputAction m_Main_Break;
    private readonly InputAction m_Main_Place;
    private readonly InputAction m_Main_Interact;
    private readonly InputAction m_Main_Screenshot;
    public struct MainActions
    {
        private @PlayerActionControls m_Wrapper;
        public MainActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveHorizontal => m_Wrapper.m_Main_MoveHorizontal;
        public InputAction @MoveVertical => m_Wrapper.m_Main_MoveVertical;
        public InputAction @Break => m_Wrapper.m_Main_Break;
        public InputAction @Place => m_Wrapper.m_Main_Place;
        public InputAction @Interact => m_Wrapper.m_Main_Interact;
        public InputAction @Screenshot => m_Wrapper.m_Main_Screenshot;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @MoveHorizontal.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveHorizontal;
                @MoveVertical.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveVertical;
                @Break.started -= m_Wrapper.m_MainActionsCallbackInterface.OnBreak;
                @Break.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnBreak;
                @Break.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnBreak;
                @Place.started -= m_Wrapper.m_MainActionsCallbackInterface.OnPlace;
                @Place.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnPlace;
                @Place.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnPlace;
                @Interact.started -= m_Wrapper.m_MainActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnInteract;
                @Screenshot.started -= m_Wrapper.m_MainActionsCallbackInterface.OnScreenshot;
                @Screenshot.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnScreenshot;
                @Screenshot.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnScreenshot;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveHorizontal.started += instance.OnMoveHorizontal;
                @MoveHorizontal.performed += instance.OnMoveHorizontal;
                @MoveHorizontal.canceled += instance.OnMoveHorizontal;
                @MoveVertical.started += instance.OnMoveVertical;
                @MoveVertical.performed += instance.OnMoveVertical;
                @MoveVertical.canceled += instance.OnMoveVertical;
                @Break.started += instance.OnBreak;
                @Break.performed += instance.OnBreak;
                @Break.canceled += instance.OnBreak;
                @Place.started += instance.OnPlace;
                @Place.performed += instance.OnPlace;
                @Place.canceled += instance.OnPlace;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Screenshot.started += instance.OnScreenshot;
                @Screenshot.performed += instance.OnScreenshot;
                @Screenshot.canceled += instance.OnScreenshot;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnMoveHorizontal(InputAction.CallbackContext context);
        void OnMoveVertical(InputAction.CallbackContext context);
        void OnBreak(InputAction.CallbackContext context);
        void OnPlace(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnScreenshot(InputAction.CallbackContext context);
    }
}
