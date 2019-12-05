// GENERATED AUTOMATICALLY FROM 'Assets/Dynamic/Game/GameInputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @GameInputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputControls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""4bc61230-eb0c-4413-8d72-0106f7a518e3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2cc50c3c-ac3d-45dd-bcb2-09c29960ec23"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""5d90ba52-c2ff-4baf-88d4-73c530aac37a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""d5e41e2d-8138-4471-9d29-47ca04ba56b2"",
                    ""expectedControlType"": """",
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
                    ""interactions"": ""Press(pressPoint=0.2)""
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
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""cbc696ba-0136-4afb-b1f6-a977f822c8a7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""Special Ability"",
                    ""type"": ""Button"",
                    ""id"": ""d428be45-dda6-46de-916c-653e0ec79173"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""0f6b9c69-6b37-49f3-a1a7-6976b1b91c86"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
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
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""edc3be7b-3e76-42f7-9a14-b39466534665"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.2)""
                },
                {
                    ""name"": ""Select Previous Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""e0b7565a-a6d8-4d06-8ef2-94ee41c4964c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Next Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""870eed36-5663-45cb-9b8a-e9ee37bf9546"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Activate Subweapon"",
                    ""type"": ""Button"",
                    ""id"": ""0ffa29de-4740-49a3-8fbe-da12efb8f7b3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e60d367-2c42-435a-88dc-3b2a550e192e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
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
                    ""name"": """",
                    ""id"": ""4f2283ac-df6a-473d-b4fb-e765c5e8bed7"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""id"": ""63780eb8-d584-4dd7-a673-b72e56f9e91f"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;Keyboard&Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6473262-a3fa-4de5-87ea-4ea40fdd5f8d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
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
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
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
                    ""action"": ""Aim"",
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
                    ""id"": ""dd125532-f729-46a3-81c1-f894ca84667c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0664079f-dac9-4a2e-81ad-413c15c663ee"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29f7f62b-c41e-4ff5-8496-82841b052b23"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select Previous Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8906f580-3a05-496d-9fd7-d6bb7bdbc188"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select Next Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bef9cf2-c063-4bdb-b7fe-b6d8b8ba0910"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Activate Subweapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6c28442-4a1e-4530-b768-519bdcdae2a1"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Activate Subweapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5607a696-a39d-48c8-b24a-637dac827911"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Special Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a5fd6ed-ec90-41f0-b0d9-9cd03325ce6f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyboardVector"",
                    ""id"": ""9b3913db-09d2-46ba-9f91-ef0b844bd39d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fc201a2e-572c-4bbf-a346-aae2eb015911"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5d25fbef-027b-4299-b805-70c33decd108"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dfc4f2f0-58fe-45ff-9f9d-2d08ed63b382"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""355f12e3-cf14-465f-8796-0a691a6f5c00"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cf496eff-6355-444a-a4f5-b5f22aa0a2e4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
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
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""c0eacb70-7a31-419d-a43a-0ce4e6d19225"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""1603aa25-3e21-44dc-b1ea-d2904ae971d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""7355a72f-6324-4f12-b4ba-a288ccd6a483"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""be1a0100-21e1-4c89-9434-6e1204bf6ed6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f2daedc7-d156-4e1b-8e73-417aab27e693"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""640bf156-3015-4d8d-b1e3-d00031b39982"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""72788406-9429-4a56-81da-a80ca2a4c566"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cd812a68-2aa7-4cc3-9a3e-a243260084c6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Stick"",
                    ""id"": ""4e647706-f987-4838-84d9-d915245ef847"",
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
                    ""id"": ""777d2331-fbe5-4d10-9663-2d7f4dd03a10"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7628b536-8eec-4b6e-921c-ec8824ccdcde"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f132d35d-75f6-4c79-bd84-5a4774bb9c42"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c91754de-80d6-4ad5-8d64-e277a3a9f498"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0092c1e7-2e55-4270-a1a6-156aca8cf76e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""c78d98ae-91cc-4fe6-8a4b-188b4dc817a0"",
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
                    ""id"": ""f0031beb-8659-4c79-8d76-614d4cf4cdde"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ea887e02-61e0-44d4-8692-9fde4cdf75b4"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""610bf4dc-02de-43eb-a9da-13b67dbb386c"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""58cca605-a58d-4c04-86b6-25af11ba5241"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""633c79c8-4041-4d46-b78c-b269a84ac49c"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28140145-2994-4f22-a6c2-bfedf7bb302c"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f446f2d-5fcc-4310-8980-310f6ebf784f"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28963f7c-32fb-46da-bf50-319a3b5ea72f"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b20d509-71ba-4617-8fec-bed908ed3dfc"",
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
                    ""id"": ""5f2547c2-209e-4849-b1b4-16cd5d4ec4d3"",
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
                    ""id"": ""67652380-ec26-4d56-8e6a-0f9b89cd0c4f"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c380f350-fbe1-499b-b3a9-b1dcbb39d75f"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3251c17c-32bf-44c9-8aa5-ab12fd7c91e6"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8dd0520-268e-4303-aef3-a52e80ccdf00"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
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
        },
        {
            ""name"": ""Touchscreen"",
            ""bindingGroup"": ""Touchscreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_Move = m_gameplay.FindAction("Move", throwIfNotFound: true);
        m_gameplay_Fire = m_gameplay.FindAction("Fire", throwIfNotFound: true);
        m_gameplay_Aim = m_gameplay.FindAction("Aim", throwIfNotFound: true);
        m_gameplay_Look = m_gameplay.FindAction("Look", throwIfNotFound: true);
        m_gameplay_Jump = m_gameplay.FindAction("Jump", throwIfNotFound: true);
        m_gameplay_Sprint = m_gameplay.FindAction("Sprint", throwIfNotFound: true);
        m_gameplay_Dash = m_gameplay.FindAction("Dash", throwIfNotFound: true);
        m_gameplay_SpecialAbility = m_gameplay.FindAction("Special Ability", throwIfNotFound: true);
        m_gameplay_Pause = m_gameplay.FindAction("Pause", throwIfNotFound: true);
        m_gameplay_CharacterMenu = m_gameplay.FindAction("Character Menu", throwIfNotFound: true);
        m_gameplay_SelectWeaponOne = m_gameplay.FindAction("Select Weapon One", throwIfNotFound: true);
        m_gameplay_SelectWeaponTwo = m_gameplay.FindAction("Select Weapon Two", throwIfNotFound: true);
        m_gameplay_SelectWeaponThree = m_gameplay.FindAction("Select Weapon Three", throwIfNotFound: true);
        m_gameplay_Zoom = m_gameplay.FindAction("Zoom", throwIfNotFound: true);
        m_gameplay_Interact = m_gameplay.FindAction("Interact", throwIfNotFound: true);
        m_gameplay_SelectPreviousWeapon = m_gameplay.FindAction("Select Previous Weapon", throwIfNotFound: true);
        m_gameplay_SelectNextWeapon = m_gameplay.FindAction("Select Next Weapon", throwIfNotFound: true);
        m_gameplay_ActivateSubweapon = m_gameplay.FindAction("Activate Subweapon", throwIfNotFound: true);
        // ui
        m_ui = asset.FindActionMap("ui", throwIfNotFound: true);
        m_ui_Navigate = m_ui.FindAction("Navigate", throwIfNotFound: true);
        m_ui_Submit = m_ui.FindAction("Submit", throwIfNotFound: true);
        m_ui_Cancel = m_ui.FindAction("Cancel", throwIfNotFound: true);
        m_ui_Point = m_ui.FindAction("Point", throwIfNotFound: true);
        m_ui_Click = m_ui.FindAction("Click", throwIfNotFound: true);
        m_ui_ScrollWheel = m_ui.FindAction("ScrollWheel", throwIfNotFound: true);
        m_ui_MiddleClick = m_ui.FindAction("MiddleClick", throwIfNotFound: true);
        m_ui_RightClick = m_ui.FindAction("RightClick", throwIfNotFound: true);
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
    private readonly InputAction m_gameplay_Move;
    private readonly InputAction m_gameplay_Fire;
    private readonly InputAction m_gameplay_Aim;
    private readonly InputAction m_gameplay_Look;
    private readonly InputAction m_gameplay_Jump;
    private readonly InputAction m_gameplay_Sprint;
    private readonly InputAction m_gameplay_Dash;
    private readonly InputAction m_gameplay_SpecialAbility;
    private readonly InputAction m_gameplay_Pause;
    private readonly InputAction m_gameplay_CharacterMenu;
    private readonly InputAction m_gameplay_SelectWeaponOne;
    private readonly InputAction m_gameplay_SelectWeaponTwo;
    private readonly InputAction m_gameplay_SelectWeaponThree;
    private readonly InputAction m_gameplay_Zoom;
    private readonly InputAction m_gameplay_Interact;
    private readonly InputAction m_gameplay_SelectPreviousWeapon;
    private readonly InputAction m_gameplay_SelectNextWeapon;
    private readonly InputAction m_gameplay_ActivateSubweapon;
    public struct GameplayActions
    {
        private @GameInputControls m_Wrapper;
        public GameplayActions(@GameInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_gameplay_Move;
        public InputAction @Fire => m_Wrapper.m_gameplay_Fire;
        public InputAction @Aim => m_Wrapper.m_gameplay_Aim;
        public InputAction @Look => m_Wrapper.m_gameplay_Look;
        public InputAction @Jump => m_Wrapper.m_gameplay_Jump;
        public InputAction @Sprint => m_Wrapper.m_gameplay_Sprint;
        public InputAction @Dash => m_Wrapper.m_gameplay_Dash;
        public InputAction @SpecialAbility => m_Wrapper.m_gameplay_SpecialAbility;
        public InputAction @Pause => m_Wrapper.m_gameplay_Pause;
        public InputAction @CharacterMenu => m_Wrapper.m_gameplay_CharacterMenu;
        public InputAction @SelectWeaponOne => m_Wrapper.m_gameplay_SelectWeaponOne;
        public InputAction @SelectWeaponTwo => m_Wrapper.m_gameplay_SelectWeaponTwo;
        public InputAction @SelectWeaponThree => m_Wrapper.m_gameplay_SelectWeaponThree;
        public InputAction @Zoom => m_Wrapper.m_gameplay_Zoom;
        public InputAction @Interact => m_Wrapper.m_gameplay_Interact;
        public InputAction @SelectPreviousWeapon => m_Wrapper.m_gameplay_SelectPreviousWeapon;
        public InputAction @SelectNextWeapon => m_Wrapper.m_gameplay_SelectNextWeapon;
        public InputAction @ActivateSubweapon => m_Wrapper.m_gameplay_ActivateSubweapon;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Aim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @SpecialAbility.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecialAbility;
                @SpecialAbility.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecialAbility;
                @SpecialAbility.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecialAbility;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @CharacterMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCharacterMenu;
                @CharacterMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCharacterMenu;
                @CharacterMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCharacterMenu;
                @SelectWeaponOne.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponOne;
                @SelectWeaponOne.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponOne;
                @SelectWeaponOne.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponOne;
                @SelectWeaponTwo.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponTwo;
                @SelectWeaponTwo.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponTwo;
                @SelectWeaponTwo.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponTwo;
                @SelectWeaponThree.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponThree;
                @SelectWeaponThree.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponThree;
                @SelectWeaponThree.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectWeaponThree;
                @Zoom.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @SelectPreviousWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPreviousWeapon;
                @SelectNextWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectNextWeapon;
                @SelectNextWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectNextWeapon;
                @SelectNextWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectNextWeapon;
                @ActivateSubweapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnActivateSubweapon;
                @ActivateSubweapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnActivateSubweapon;
                @ActivateSubweapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnActivateSubweapon;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @SpecialAbility.started += instance.OnSpecialAbility;
                @SpecialAbility.performed += instance.OnSpecialAbility;
                @SpecialAbility.canceled += instance.OnSpecialAbility;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @CharacterMenu.started += instance.OnCharacterMenu;
                @CharacterMenu.performed += instance.OnCharacterMenu;
                @CharacterMenu.canceled += instance.OnCharacterMenu;
                @SelectWeaponOne.started += instance.OnSelectWeaponOne;
                @SelectWeaponOne.performed += instance.OnSelectWeaponOne;
                @SelectWeaponOne.canceled += instance.OnSelectWeaponOne;
                @SelectWeaponTwo.started += instance.OnSelectWeaponTwo;
                @SelectWeaponTwo.performed += instance.OnSelectWeaponTwo;
                @SelectWeaponTwo.canceled += instance.OnSelectWeaponTwo;
                @SelectWeaponThree.started += instance.OnSelectWeaponThree;
                @SelectWeaponThree.performed += instance.OnSelectWeaponThree;
                @SelectWeaponThree.canceled += instance.OnSelectWeaponThree;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SelectPreviousWeapon.started += instance.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.performed += instance.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.canceled += instance.OnSelectPreviousWeapon;
                @SelectNextWeapon.started += instance.OnSelectNextWeapon;
                @SelectNextWeapon.performed += instance.OnSelectNextWeapon;
                @SelectNextWeapon.canceled += instance.OnSelectNextWeapon;
                @ActivateSubweapon.started += instance.OnActivateSubweapon;
                @ActivateSubweapon.performed += instance.OnActivateSubweapon;
                @ActivateSubweapon.canceled += instance.OnActivateSubweapon;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);

    // ui
    private readonly InputActionMap m_ui;
    private IUiActions m_UiActionsCallbackInterface;
    private readonly InputAction m_ui_Navigate;
    private readonly InputAction m_ui_Submit;
    private readonly InputAction m_ui_Cancel;
    private readonly InputAction m_ui_Point;
    private readonly InputAction m_ui_Click;
    private readonly InputAction m_ui_ScrollWheel;
    private readonly InputAction m_ui_MiddleClick;
    private readonly InputAction m_ui_RightClick;
    public struct UiActions
    {
        private @GameInputControls m_Wrapper;
        public UiActions(@GameInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_ui_Navigate;
        public InputAction @Submit => m_Wrapper.m_ui_Submit;
        public InputAction @Cancel => m_Wrapper.m_ui_Cancel;
        public InputAction @Point => m_Wrapper.m_ui_Point;
        public InputAction @Click => m_Wrapper.m_ui_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_ui_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_ui_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_ui_RightClick;
        public InputActionMap Get() { return m_Wrapper.m_ui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
        public void SetCallbacks(IUiActions instance)
        {
            if (m_Wrapper.m_UiActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UiActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UiActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UiActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_UiActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
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
    private int m_TouchscreenSchemeIndex = -1;
    public InputControlScheme TouchscreenScheme
    {
        get
        {
            if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
            return asset.controlSchemes[m_TouchscreenSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnSpecialAbility(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnCharacterMenu(InputAction.CallbackContext context);
        void OnSelectWeaponOne(InputAction.CallbackContext context);
        void OnSelectWeaponTwo(InputAction.CallbackContext context);
        void OnSelectWeaponThree(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSelectPreviousWeapon(InputAction.CallbackContext context);
        void OnSelectNextWeapon(InputAction.CallbackContext context);
        void OnActivateSubweapon(InputAction.CallbackContext context);
    }
    public interface IUiActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
}
