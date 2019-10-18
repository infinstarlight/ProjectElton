// GENERATED AUTOMATICALLY FROM 'Assets/Dynamic/Game/GameInputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GameInputControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public GameInputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputControls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""4bc61230-eb0c-4413-8d72-0106f7a518e3"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""5d90ba52-c2ff-4baf-88d4-73c530aac37a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Value"",
                    ""id"": ""73212634-9bf3-41b0-b818-707fd9db978e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Value"",
                    ""id"": ""bbc09ef9-618c-49ec-9552-44d0f182c03c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookUp"",
                    ""type"": ""Value"",
                    ""id"": ""c345672a-5bc1-435d-841b-6d236c350c0f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookRight"",
                    ""type"": ""Value"",
                    ""id"": ""eadcb8a7-5bdc-4f37-9f66-4b99a9ca772e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e60d367-2c42-435a-88dc-3b2a550e192e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33fc8b73-9ba7-47e0-ba4c-9bc18ed527f3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyboardAxis"",
                    ""id"": ""94588340-bf5b-4547-ad10-92c01670317e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b09c0fc5-a66e-4033-b349-8e08e0ccc708"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9f6f3e2f-e50e-454a-ace3-77594893ed82"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamepadAxis"",
                    ""id"": ""aab04a77-c5dd-4208-a2b1-d85246a3877c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e861d0c8-bf91-42ae-b674-3d20b643cbe7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cc097df0-1492-4143-b414-f2e330b0826b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""96529613-4d73-4758-a3fa-319e1201a66b"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a8f7cbe-8b68-4969-beb1-4cde2cede081"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyboardAxis"",
                    ""id"": ""6a08b5d3-f503-4557-9c85-4e9e70883dfe"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""46d905a6-114c-4edd-8001-ebd3fb2e76aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8ed0c928-b460-4f25-9b49-b5b5d906db32"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamepadAxis"",
                    ""id"": ""20668967-990e-4ff5-a8fa-2236a77914dd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""550a9b11-d410-4523-a8a7-e5d155a1a5c5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dc8bd8e9-b398-4c8f-886c-9a4f8ad57800"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3901ed71-5f6f-4e48-95f7-72e57405e580"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""deb77a61-381f-4382-910b-105bdd3d6255"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ui"",
            ""id"": ""62a9018a-9185-4223-9b22-69c857fe1921"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""c223f0ff-795e-4c43-acdc-607a91b1b14e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0038955c-5838-4359-be9c-bb95df84051e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_Fire = m_gameplay.FindAction("Fire", throwIfNotFound: true);
        m_gameplay_MoveUp = m_gameplay.FindAction("MoveUp", throwIfNotFound: true);
        m_gameplay_MoveRight = m_gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_gameplay_LookUp = m_gameplay.FindAction("LookUp", throwIfNotFound: true);
        m_gameplay_LookRight = m_gameplay.FindAction("LookRight", throwIfNotFound: true);
        // ui
        m_ui = asset.FindActionMap("ui", throwIfNotFound: true);
        m_ui_Newaction = m_ui.FindAction("New action", throwIfNotFound: true);
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

    // gameplay
    private readonly InputActionMap m_gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_gameplay_Fire;
    private readonly InputAction m_gameplay_MoveUp;
    private readonly InputAction m_gameplay_MoveRight;
    private readonly InputAction m_gameplay_LookUp;
    private readonly InputAction m_gameplay_LookRight;
    public struct GameplayActions
    {
        private GameInputControls m_Wrapper;
        public GameplayActions(GameInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_gameplay_Fire;
        public InputAction @MoveUp => m_Wrapper.m_gameplay_MoveUp;
        public InputAction @MoveRight => m_Wrapper.m_gameplay_MoveRight;
        public InputAction @LookUp => m_Wrapper.m_gameplay_LookUp;
        public InputAction @LookRight => m_Wrapper.m_gameplay_LookRight;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                MoveUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                MoveUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                MoveUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                LookUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookUp;
                LookUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookUp;
                LookUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookUp;
                LookRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookRight;
                LookRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookRight;
                LookRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookRight;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Fire.started += instance.OnFire;
                Fire.performed += instance.OnFire;
                Fire.canceled += instance.OnFire;
                MoveUp.started += instance.OnMoveUp;
                MoveUp.performed += instance.OnMoveUp;
                MoveUp.canceled += instance.OnMoveUp;
                MoveRight.started += instance.OnMoveRight;
                MoveRight.performed += instance.OnMoveRight;
                MoveRight.canceled += instance.OnMoveRight;
                LookUp.started += instance.OnLookUp;
                LookUp.performed += instance.OnLookUp;
                LookUp.canceled += instance.OnLookUp;
                LookRight.started += instance.OnLookRight;
                LookRight.performed += instance.OnLookRight;
                LookRight.canceled += instance.OnLookRight;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);

    // ui
    private readonly InputActionMap m_ui;
    private IUiActions m_UiActionsCallbackInterface;
    private readonly InputAction m_ui_Newaction;
    public struct UiActions
    {
        private GameInputControls m_Wrapper;
        public UiActions(GameInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_ui_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_ui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
        public void SetCallbacks(IUiActions instance)
        {
            if (m_Wrapper.m_UiActionsCallbackInterface != null)
            {
                Newaction.started -= m_Wrapper.m_UiActionsCallbackInterface.OnNewaction;
                Newaction.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnNewaction;
                Newaction.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UiActionsCallbackInterface = instance;
            if (instance != null)
            {
                Newaction.started += instance.OnNewaction;
                Newaction.performed += instance.OnNewaction;
                Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UiActions @ui => new UiActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnLookUp(InputAction.CallbackContext context);
        void OnLookRight(InputAction.CallbackContext context);
    }
    public interface IUiActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
