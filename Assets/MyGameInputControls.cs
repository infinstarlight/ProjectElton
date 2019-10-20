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
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltFire"",
                    ""type"": ""Button"",
                    ""id"": ""d5e41e2d-8138-4471-9d29-47ca04ba56b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
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
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""c345672a-5bc1-435d-841b-6d236c350c0f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0f1f7568-2bcb-43d5-9e6c-b5a8b142d45c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""54b32bf7-d30d-4970-871c-ff207bb0fb60"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special Ability"",
                    ""type"": ""Button"",
                    ""id"": ""cbc696ba-0136-4afb-b1f6-a977f822c8a7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Style Switch Up"",
                    ""type"": ""Button"",
                    ""id"": ""d4091cdc-89be-4e58-8878-5d668b5962e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Style Switch Down"",
                    ""type"": ""Button"",
                    ""id"": ""32a0a6e6-4f45-4249-89a0-3053f9bcec39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""0f6b9c69-6b37-49f3-a1a7-6976b1b91c86"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Character Menu"",
                    ""type"": ""Button"",
                    ""id"": ""66a2b395-0075-4d46-9e91-77bcbb5151a2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Weapon One"",
                    ""type"": ""Button"",
                    ""id"": ""fcc8f5c7-1392-4de8-a306-6c207f20192a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Weapon Two"",
                    ""type"": ""Button"",
                    ""id"": ""bda868a3-2c20-43e5-91e9-7c9ea0faa2ae"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Weapon Three"",
                    ""type"": ""Button"",
                    ""id"": ""4e682c50-e098-43c4-984d-b36a32757fef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""cee16f88-85e2-497a-9502-3ee52b03dcea"",
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
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
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
                    ""groups"": ""Keyboard&Mouse"",
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
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a8f7cbe-8b68-4969-beb1-4cde2cede081"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Look"",
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
                    ""id"": ""008d6cd9-d6a1-4dc2-9181-7e7506787d30"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbdfd97a-cecb-4689-8005-358fab3ad79f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22a830ae-c588-4edd-841b-c0c522bfd260"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""042cb96a-77ab-418b-a5e2-45f95079da9c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d661a64-b10d-411a-8728-1d6a3e01b194"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Special Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6473262-a3fa-4de5-87ea-4ea40fdd5f8d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""292f61fe-7b4c-4697-920d-142d23e7f698"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c8c6da5-4832-4d55-a4be-52963a83a0e3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c896a5da-c3df-491e-baae-77787d088213"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Character Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61bbbfd8-50f7-4537-a311-c336b219f9da"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Character Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c31db32-4b87-4fb3-972c-043fbaeae45a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Style Switch Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""624e3c21-4a0f-4896-8454-3a53d916cd4c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Style Switch Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63cc83d1-6d46-4ab8-ae5d-b3b028843649"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Select Weapon One"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7f1363a-b8fb-4a2e-953a-668eea0b0311"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Select Weapon Two"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""612a6aa1-8dc6-4a28-b5a5-3ded654448ec"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AltFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b04cd459-8616-4aaf-9ce2-1952cf6acb77"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""AltFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce98fa7e-36dc-4a1b-a222-d691f0c7dd70"",
                    ""path"": ""<Keyboard>/rightAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55a342c9-cfca-4fb6-ada5-aa48193925f7"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88069a39-5f9c-415f-ab83-bbf84fec24dd"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Select Weapon Three"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fc91609-0274-44d1-ba1c-5440fab36811"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Style Switch Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c777fc48-ddb1-4759-b92c-0876a1198833"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Style Switch Down"",
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
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""c223f0ff-795e-4c43-acdc-607a91b1b14e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5dcc0afc-d3e9-46a7-a7c9-c9d90ba94100"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""94830c29-7b16-403e-ad2a-cd85c44a1183"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2f23be39-625b-46b6-a0ab-88f60901b6f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pointer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""03b0c819-94c8-4c2d-b71a-7588023ba1b6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""ca1fd091-d01e-48a5-b70a-d324d8fc35a9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""642b9341-a31f-4790-801a-96e39461134b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""bcffbb1a-86d1-4779-851e-333caf745b1f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0038955c-5838-4359-be9c-bb95df84051e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e25509ab-3f69-4228-9da2-584a94e91e41"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96dee7f1-6a7a-4a79-ac5f-268255841199"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad LS"",
                    ""id"": ""46205ff6-3366-4689-95c6-a9e3f1b65fd1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b04eed11-90b6-464a-948e-80fab4bc868c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""22f0e728-f657-44f4-9da1-ab8d84cb0aca"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""40dc17f2-32af-4011-ae05-3db5f61dafd7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dab0891c-fc31-4f00-b819-e1df8ec03974"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad D-pad"",
                    ""id"": ""e9eb2042-3c5a-4846-828f-da9efb8e0b95"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f082259b-e9eb-4cdb-ace9-214f7cf19f3e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""30a45973-c4d1-43e3-9209-93bbae6da303"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f5bac5e5-cc51-47f8-9b41-2c4f01b88ae0"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a9fc21c-9cb2-402b-bf1b-7a5fc71dad1b"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5d8ec488-ef68-48cf-b697-3bef7a09bab3"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97966b9b-279a-4763-8c3a-9eec56856f5c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46574dc7-39ff-4d78-9688-b2f29e74ae0f"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f958163d-92fa-4453-8563-8ded25e7b7e4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fd81cc7-6b8f-4810-9d7c-ed96d79b82bb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe34a3fa-5425-4d29-9956-a743449a3268"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8135aebb-1be4-40a0-adc7-76599cb1a506"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""649e2192-4c74-43e0-9651-17923ab82a01"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""327de879-f33d-4361-bf90-0c658f2f0024"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
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
        m_gameplay_AltFire = m_gameplay.FindAction("AltFire", throwIfNotFound: true);
        m_gameplay_MoveUp = m_gameplay.FindAction("MoveUp", throwIfNotFound: true);
        m_gameplay_MoveRight = m_gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_gameplay_Look = m_gameplay.FindAction("Look", throwIfNotFound: true);
        m_gameplay_Jump = m_gameplay.FindAction("Jump", throwIfNotFound: true);
        m_gameplay_Sprint = m_gameplay.FindAction("Sprint", throwIfNotFound: true);
        m_gameplay_SpecialAbility = m_gameplay.FindAction("Special Ability", throwIfNotFound: true);
        m_gameplay_StyleSwitchUp = m_gameplay.FindAction("Style Switch Up", throwIfNotFound: true);
        m_gameplay_StyleSwitchDown = m_gameplay.FindAction("Style Switch Down", throwIfNotFound: true);
        m_gameplay_Pause = m_gameplay.FindAction("Pause", throwIfNotFound: true);
        m_gameplay_CharacterMenu = m_gameplay.FindAction("Character Menu", throwIfNotFound: true);
        m_gameplay_SelectWeaponOne = m_gameplay.FindAction("Select Weapon One", throwIfNotFound: true);
        m_gameplay_SelectWeaponTwo = m_gameplay.FindAction("Select Weapon Two", throwIfNotFound: true);
        m_gameplay_SelectWeaponThree = m_gameplay.FindAction("Select Weapon Three", throwIfNotFound: true);
        m_gameplay_Zoom = m_gameplay.FindAction("Zoom", throwIfNotFound: true);
        // ui
        m_ui = asset.FindActionMap("ui", throwIfNotFound: true);
        m_ui_Confirm = m_ui.FindAction("Confirm", throwIfNotFound: true);
        m_ui_MiddleClick = m_ui.FindAction("MiddleClick", throwIfNotFound: true);
        m_ui_RightClick = m_ui.FindAction("RightClick", throwIfNotFound: true);
        m_ui_Click = m_ui.FindAction("Click", throwIfNotFound: true);
        m_ui_Pointer = m_ui.FindAction("Pointer", throwIfNotFound: true);
        m_ui_Navigate = m_ui.FindAction("Navigate", throwIfNotFound: true);
        m_ui_Scroll = m_ui.FindAction("Scroll", throwIfNotFound: true);
        m_ui_Return = m_ui.FindAction("Return", throwIfNotFound: true);
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
    private readonly InputAction m_gameplay_AltFire;
    private readonly InputAction m_gameplay_MoveUp;
    private readonly InputAction m_gameplay_MoveRight;
    private readonly InputAction m_gameplay_Look;
    private readonly InputAction m_gameplay_Jump;
    private readonly InputAction m_gameplay_Sprint;
    private readonly InputAction m_gameplay_SpecialAbility;
    private readonly InputAction m_gameplay_StyleSwitchUp;
    private readonly InputAction m_gameplay_StyleSwitchDown;
    private readonly InputAction m_gameplay_Pause;
    private readonly InputAction m_gameplay_CharacterMenu;
    private readonly InputAction m_gameplay_SelectWeaponOne;
    private readonly InputAction m_gameplay_SelectWeaponTwo;
    private readonly InputAction m_gameplay_SelectWeaponThree;
    private readonly InputAction m_gameplay_Zoom;
    public struct GameplayActions
    {
        private GameInputControls m_Wrapper;
        public GameplayActions(GameInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_gameplay_Fire;
        public InputAction @AltFire => m_Wrapper.m_gameplay_AltFire;
        public InputAction @MoveUp => m_Wrapper.m_gameplay_MoveUp;
        public InputAction @MoveRight => m_Wrapper.m_gameplay_MoveRight;
        public InputAction @Look => m_Wrapper.m_gameplay_Look;
        public InputAction @Jump => m_Wrapper.m_gameplay_Jump;
        public InputAction @Sprint => m_Wrapper.m_gameplay_Sprint;
        public InputAction @SpecialAbility => m_Wrapper.m_gameplay_SpecialAbility;
        public InputAction @StyleSwitchUp => m_Wrapper.m_gameplay_StyleSwitchUp;
        public InputAction @StyleSwitchDown => m_Wrapper.m_gameplay_StyleSwitchDown;
        public InputAction @Pause => m_Wrapper.m_gameplay_Pause;
        public InputAction @CharacterMenu => m_Wrapper.m_gameplay_CharacterMenu;
        public InputAction @SelectWeaponOne => m_Wrapper.m_gameplay_SelectWeaponOne;
        public InputAction @SelectWeaponTwo => m_Wrapper.m_gameplay_SelectWeaponTwo;
        public InputAction @SelectWeaponThree => m_Wrapper.m_gameplay_SelectWeaponThree;
        public InputAction @Zoom => m_Wrapper.m_gameplay_Zoom;
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
                AltFire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAltFire;
                AltFire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAltFire;
                AltFire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAltFire;
                MoveUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                MoveUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                MoveUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                SpecialAbility.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecialAbility;
                SpecialAbility.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecialAbility;
                SpecialAbility.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecialAbility;
                StyleSwitchUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStyleSwitchUp;
                StyleSwitchUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStyleSwitchUp;
                StyleSwitchUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStyleSwitchUp;
                StyleSwitchDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStyleSwitchDown;
                StyleSwitchDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStyleSwitchDown;
                StyleSwitchDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStyleSwitchDown;
                Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                CharacterMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCharacterMenu;
                CharacterMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCharacterMenu;
                CharacterMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCharacterMenu;
                SelectWeaponOne.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponOne;
                SelectWeaponOne.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponOne;
                SelectWeaponOne.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponOne;
                SelectWeaponTwo.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponTwo;
                SelectWeaponTwo.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponTwo;
                SelectWeaponTwo.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponTwo;
                SelectWeaponThree.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponThree;
                SelectWeaponThree.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponThree;
                SelectWeaponThree.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponThree;
                Zoom.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                Zoom.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                Zoom.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Fire.started += instance.OnFire;
                Fire.performed += instance.OnFire;
                Fire.canceled += instance.OnFire;
                AltFire.started += instance.OnAltFire;
                AltFire.performed += instance.OnAltFire;
                AltFire.canceled += instance.OnAltFire;
                MoveUp.started += instance.OnMoveUp;
                MoveUp.performed += instance.OnMoveUp;
                MoveUp.canceled += instance.OnMoveUp;
                MoveRight.started += instance.OnMoveRight;
                MoveRight.performed += instance.OnMoveRight;
                MoveRight.canceled += instance.OnMoveRight;
                Look.started += instance.OnLook;
                Look.performed += instance.OnLook;
                Look.canceled += instance.OnLook;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Sprint.started += instance.OnSprint;
                Sprint.performed += instance.OnSprint;
                Sprint.canceled += instance.OnSprint;
                SpecialAbility.started += instance.OnSpecialAbility;
                SpecialAbility.performed += instance.OnSpecialAbility;
                SpecialAbility.canceled += instance.OnSpecialAbility;
                StyleSwitchUp.started += instance.OnStyleSwitchUp;
                StyleSwitchUp.performed += instance.OnStyleSwitchUp;
                StyleSwitchUp.canceled += instance.OnStyleSwitchUp;
                StyleSwitchDown.started += instance.OnStyleSwitchDown;
                StyleSwitchDown.performed += instance.OnStyleSwitchDown;
                StyleSwitchDown.canceled += instance.OnStyleSwitchDown;
                Pause.started += instance.OnPause;
                Pause.performed += instance.OnPause;
                Pause.canceled += instance.OnPause;
                CharacterMenu.started += instance.OnCharacterMenu;
                CharacterMenu.performed += instance.OnCharacterMenu;
                CharacterMenu.canceled += instance.OnCharacterMenu;
                SelectWeaponOne.started += instance.OnSelectWeaponOne;
                SelectWeaponOne.performed += instance.OnSelectWeaponOne;
                SelectWeaponOne.canceled += instance.OnSelectWeaponOne;
                SelectWeaponTwo.started += instance.OnSelectWeaponTwo;
                SelectWeaponTwo.performed += instance.OnSelectWeaponTwo;
                SelectWeaponTwo.canceled += instance.OnSelectWeaponTwo;
                SelectWeaponThree.started += instance.OnSelectWeaponThree;
                SelectWeaponThree.performed += instance.OnSelectWeaponThree;
                SelectWeaponThree.canceled += instance.OnSelectWeaponThree;
                Zoom.started += instance.OnZoom;
                Zoom.performed += instance.OnZoom;
                Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);

    // ui
    private readonly InputActionMap m_ui;
    private IUiActions m_UiActionsCallbackInterface;
    private readonly InputAction m_ui_Confirm;
    private readonly InputAction m_ui_MiddleClick;
    private readonly InputAction m_ui_RightClick;
    private readonly InputAction m_ui_Click;
    private readonly InputAction m_ui_Pointer;
    private readonly InputAction m_ui_Navigate;
    private readonly InputAction m_ui_Scroll;
    private readonly InputAction m_ui_Return;
    public struct UiActions
    {
        private GameInputControls m_Wrapper;
        public UiActions(GameInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_ui_Confirm;
        public InputAction @MiddleClick => m_Wrapper.m_ui_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_ui_RightClick;
        public InputAction @Click => m_Wrapper.m_ui_Click;
        public InputAction @Pointer => m_Wrapper.m_ui_Pointer;
        public InputAction @Navigate => m_Wrapper.m_ui_Navigate;
        public InputAction @Scroll => m_Wrapper.m_ui_Scroll;
        public InputAction @Return => m_Wrapper.m_ui_Return;
        public InputActionMap Get() { return m_Wrapper.m_ui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
        public void SetCallbacks(IUiActions instance)
        {
            if (m_Wrapper.m_UiActionsCallbackInterface != null)
            {
                Confirm.started -= m_Wrapper.m_UiActionsCallbackInterface.OnConfirm;
                Confirm.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnConfirm;
                Confirm.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnConfirm;
                MiddleClick.started -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                MiddleClick.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                MiddleClick.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                RightClick.started -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                RightClick.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                RightClick.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                Click.started -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                Click.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                Click.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                Pointer.started -= m_Wrapper.m_UiActionsCallbackInterface.OnPointer;
                Pointer.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnPointer;
                Pointer.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnPointer;
                Navigate.started -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                Navigate.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                Navigate.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                Scroll.started -= m_Wrapper.m_UiActionsCallbackInterface.OnScroll;
                Scroll.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnScroll;
                Scroll.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnScroll;
                Return.started -= m_Wrapper.m_UiActionsCallbackInterface.OnReturn;
                Return.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnReturn;
                Return.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnReturn;
            }
            m_Wrapper.m_UiActionsCallbackInterface = instance;
            if (instance != null)
            {
                Confirm.started += instance.OnConfirm;
                Confirm.performed += instance.OnConfirm;
                Confirm.canceled += instance.OnConfirm;
                MiddleClick.started += instance.OnMiddleClick;
                MiddleClick.performed += instance.OnMiddleClick;
                MiddleClick.canceled += instance.OnMiddleClick;
                RightClick.started += instance.OnRightClick;
                RightClick.performed += instance.OnRightClick;
                RightClick.canceled += instance.OnRightClick;
                Click.started += instance.OnClick;
                Click.performed += instance.OnClick;
                Click.canceled += instance.OnClick;
                Pointer.started += instance.OnPointer;
                Pointer.performed += instance.OnPointer;
                Pointer.canceled += instance.OnPointer;
                Navigate.started += instance.OnNavigate;
                Navigate.performed += instance.OnNavigate;
                Navigate.canceled += instance.OnNavigate;
                Scroll.started += instance.OnScroll;
                Scroll.performed += instance.OnScroll;
                Scroll.canceled += instance.OnScroll;
                Return.started += instance.OnReturn;
                Return.performed += instance.OnReturn;
                Return.canceled += instance.OnReturn;
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
        void OnAltFire(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnSpecialAbility(InputAction.CallbackContext context);
        void OnStyleSwitchUp(InputAction.CallbackContext context);
        void OnStyleSwitchDown(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnCharacterMenu(InputAction.CallbackContext context);
        void OnSelectWeaponOne(InputAction.CallbackContext context);
        void OnSelectWeaponTwo(InputAction.CallbackContext context);
        void OnSelectWeaponThree(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface IUiActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPointer(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnReturn(InputAction.CallbackContext context);
    }
}
