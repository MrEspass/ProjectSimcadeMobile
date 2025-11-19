// GENERATED AUTOMATICALLY FROM 'Assets/Script/InputSystem/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""CarController"",
            ""id"": ""9be0f12f-7601-4340-af73-91c0367d4389"",
            ""actions"": [
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""8fcf4017-043f-435c-b86f-52d30620e27b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Value"",
                    ""id"": ""445f81e9-91b8-4157-9846-5f256eaaeb3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandBrake"",
                    ""type"": ""Button"",
                    ""id"": ""411f7437-577b-42d6-a4ad-5d8aa5987dc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Clutch"",
                    ""type"": ""Value"",
                    ""id"": ""26f9035e-4de7-4567-b61b-2b412bcee30a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShiftUp"",
                    ""type"": ""Button"",
                    ""id"": ""c4dd38cf-7c17-4bdb-ba7b-3b67086211ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShiftDown"",
                    ""type"": ""Button"",
                    ""id"": ""2535e611-5d44-4b6b-8428-af86614c698f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steer"",
                    ""type"": ""Value"",
                    ""id"": ""78206e07-269f-47b8-8f76-b2da4a3e4c64"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Camera"",
                    ""type"": ""Button"",
                    ""id"": ""72cc051d-99fa-49d5-9fe5-088d45464c6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera Rotate X"",
                    ""type"": ""Value"",
                    ""id"": ""230ac5d1-b99b-4cb2-ad31-c7ff30079ad1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera Rotate Y"",
                    ""type"": ""Value"",
                    ""id"": ""eb68bfe7-e422-4e48-8cbf-336dfa67760d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Sign"",
                    ""type"": ""Button"",
                    ""id"": ""eee1f302-8b46-4c92-951f-d655e51a3d6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Sign"",
                    ""type"": ""Button"",
                    ""id"": ""3e841e6b-5155-4f22-a603-077c48f5e6f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hazard Sign"",
                    ""type"": ""Button"",
                    ""id"": ""0f3c593b-1a0f-4585-bb9d-e9bcf7abb65c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Front Light"",
                    ""type"": ""Button"",
                    ""id"": ""67dbe2b7-dd1a-456b-ae08-fef1e7d0dc95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""85776ee2-0e16-46ec-8729-f2c9a31a8fa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a5eacee6-f961-452d-93f7-44cf2a4b123e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63f45a70-6538-463b-849a-02a060d5043e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0546ea3-be47-4400-a209-ddd689404d77"",
                    ""path"": ""<AndroidGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5600627-d5ed-4736-97e1-934bcd8abf7f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""697e7952-1e4b-418f-a01c-d15173c733e5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""466020cb-0dae-42d8-8caa-8fa9f79d45f0"",
                    ""path"": ""<AndroidGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f582f6f-c608-4f79-b571-03309e6721ad"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Clutch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36eea48c-af0a-4edc-8253-bdcc31cdb929"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShiftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6a2c9ae-a221-4dcb-94d4-e502e462d7a7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShiftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ea069cb-83da-4ccb-8494-f0808838db90"",
                    ""path"": ""<AndroidGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""ShiftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""725619d2-6c6c-4fb3-8393-ff456d35310d"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShiftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7ac932f-1690-48bf-b65c-1fb105ce812a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShiftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d5eae65-2c1d-4969-bcff-5d283244cac2"",
                    ""path"": ""<AndroidGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""ShiftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""feca8ec1-3cab-4c59-a8d5-77cfedfe55d6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ca1f1b48-8d45-4746-a9e0-a05ebd7be38a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0a60eb6c-8aac-46ac-9662-61ce6f28cf13"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8f4429be-73d1-416c-967a-3d919040cd1c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""745e4892-995b-408f-9fd7-5e88a7bd203c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d5de257b-ee1d-4dae-889d-8e8b8ef041f7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e01f5e8d-73da-4335-b386-6e363fb0e156"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a318dc98-ddb6-40c2-ac26-6b2a53ee73ac"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""37fb133a-87da-4305-8a50-0cd039e80f84"",
                    ""path"": ""<AndroidGamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""AndroidGamepad"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16ce151a-2895-472d-9719-4574c8b87fcb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dae1b597-5817-4965-be18-8baf847d7a7f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e66f4c3b-ef47-4aec-87a8-a8b3e509df86"",
                    ""path"": ""<AndroidGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d369d614-3506-4e9d-8b4a-158eeecc9c9e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Change Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14459db3-b823-48d6-9c0c-71fe576e86ff"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Change Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb1a53be-2590-4204-98ba-87f5de2ce41a"",
                    ""path"": ""<AndroidGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Change Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b11545da-094e-4e3e-8f53-21d07ec2ed2b"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Camera Rotate X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""15921fca-6297-4d87-b4d3-f6281c253aa8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera Rotate X"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""085e89e7-5577-4e96-9ff4-44ceff646f80"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Rotate X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5e563d00-c523-41a8-91ea-942495ae2479"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Rotate X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1011a8d2-19d6-4cd1-823c-3da7cc2ebe28"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera Rotate X"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ff8d4687-c37e-4d06-949b-020fba1a6788"",
                    ""path"": ""<AndroidGamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Camera Rotate X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9c48f393-9800-4a67-aa7d-968a59b8e60d"",
                    ""path"": ""<AndroidGamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Camera Rotate X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b2ee2fb1-76c9-4290-8373-5ae729f8a456"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Camera Rotate Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f8601411-0b4e-4abd-b1c9-77b31e8577d1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera Rotate Y"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5c240d18-dba1-4d85-bdbe-4dfce0ffd91a"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Rotate Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""91d9dca5-f5da-4b25-8dd4-ec912487acaf"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Rotate Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""84ede71e-ceed-4e58-94d8-881fbd258b64"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera Rotate Y"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ab13191d-9af1-4847-994b-496cfde41152"",
                    ""path"": ""<AndroidGamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Camera Rotate Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6b23283e-0412-44cb-b792-98ad7c863ec2"",
                    ""path"": ""<AndroidGamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Camera Rotate Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a86baf19-5bdc-4a90-81ac-4e76dbb40d2b"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left Sign"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bb7a5c6-918a-4438-adf0-93be6c10497a"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right Sign"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14edb066-86fd-4a1e-996b-08141727efde"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Hazard Sign"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0ed2809-ccac-4f3d-8b90-c89018b0e30d"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Front Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f858adf-81ea-406a-8743-8f6bebaf060c"",
                    ""path"": ""<AndroidGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;AndroidGamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""69407897-6007-4b46-a955-f28f81408d30"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""4801b2c2-d184-4910-947f-45d3ba91c3ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""1758724f-8dba-4cda-892d-73f3e653319a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""a19eeadf-2dae-4427-b426-5600d8d9307f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6f576451-b5b1-4fb4-8661-6c932ec917bb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5e7af128-4ad2-47d6-80bb-f2481040eaec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1fef2325-5dc1-44c9-bd8f-42da4b6b7ec4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""86024bc8-38ff-42d9-8507-90cf2eb31b31"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""99c2c152-f96e-489f-8ff4-77d690453e33"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5af5f6e1-0a46-4c36-ac70-67e186a0cede"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""34ec2c83-4dfa-420f-8f91-9520bd4f8784"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""91d58d07-3eac-42df-97d3-15ceb7c59eb2"",
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
                    ""id"": ""9f8a42d4-e8d9-4ed0-b6e2-b5c3d4a4e7e0"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8f30a723-4ebc-4092-b52d-102fa8956a2e"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f69a6489-18f6-4524-8c7f-0d8903c713f8"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""48a18b0b-e2fa-435e-aafb-9ba413f12cdf"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b01b526c-cb58-4ab9-9531-de43901e0bc7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""339ae671-3f68-41d6-9e78-793752b6d487"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""112673fa-1405-4353-a72a-00f59a5b06fa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c3addee6-9638-468d-9c98-8cda3cbdff16"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e8484b31-c906-490a-9291-593346d7ae54"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""3db02238-1f1e-4fb8-b6ca-b24cb65bc581"",
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
                    ""id"": ""f31eef64-b0de-4933-9bfc-c6d13f0c99cc"",
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
                    ""id"": ""5a891ceb-8c39-4fb7-8f12-f56c5c0240f9"",
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
                    ""id"": ""f5038599-9386-4423-914f-43125dee8264"",
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
                    ""id"": ""87832c14-eca5-4eb8-98e4-90edac256b5f"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ce130e53-3056-412f-833c-caabdbbc629c"",
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
                    ""id"": ""60dc6c89-b85f-4719-9eda-e5b98ea7ab59"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c1225a1f-7e2f-432d-8de8-3ee408c937de"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c7ab5dbc-c556-405e-9266-516f78be7d49"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a08c684a-1bba-4938-98be-aa59d8a093d0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""983fbcad-447b-4a85-809f-48fd9ae0fd08"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""83077566-743c-441f-bf07-83d945a80357"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""75a6278b-5f9a-47c8-a012-320dc1fbf432"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8fa6b5f4-2e04-4a92-afa0-8be6dc617cd6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4d5ccc73-d5fe-441b-aa3d-0d2f83818ac3"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fe18bba-4944-4dfc-ab5d-03f5778909c4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fab30cd-e65e-433f-810d-95fb08765233"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a9b852d-8349-4d93-b0db-7cc0bbafbc33"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""644aff4d-cd6e-403c-a380-8ed540243d7e"",
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
                    ""id"": ""110b89a2-1179-4967-8aca-755e2d6b5f56"",
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
                    ""id"": ""590673de-53fc-4877-b558-67f88aaca4c9"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37727c7d-3f82-416b-985c-17fa216c54fd"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9544b0b3-e6b2-4704-b72b-0edf7ea2de66"",
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
                    ""id"": ""b43d1d64-3cfa-4f81-abcf-b99d2ac6fc03"",
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
                    ""id"": ""e521ae6a-6866-4bc0-a76e-2b7646dd6edd"",
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
                    ""id"": ""9bb8213b-978b-4b83-aaf6-c633978c8fa1"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7c12bc7-7cb5-457d-bfb2-355ddee27a30"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""93183ced-2146-41a4-a3a9-c24e35d13227"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""27a83582-cbcf-4ecb-84fc-716aea272f9d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f9f78983-847b-45f3-992a-419792d054f7"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""87eb48c4-78ac-487f-a47a-6202dec8571b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ce24e6a2-4b0d-4063-bd72-f1924d880e0e"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6b67a3e7-73f0-43d8-bce3-3fae27765af5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""14429608-12e5-4a00-832b-b65a7476ce4b"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f9aff7a-ed38-4b49-a787-39f0841a300d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6224c848-f6c4-4534-8925-d9e7c959d5dc"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""be4515f8-ae4d-4da8-a8f3-1d7205b382fd"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""26520080-bdae-47c6-a41d-b0efbe8cdc2d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""57c7dd0e-a7ac-4ff9-88c7-42cc7fa00510"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e515010c-e06c-4225-9a63-61fbc4bf8068"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e59f233b-b5e4-4a99-8694-fce3509b200e"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2a4bdfbb-1e26-4c1f-a171-98094050afe7"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""a956bb59-0f5f-4f5c-a328-581e02b3b344"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cb17f1b6-2a29-49c9-95be-456db820e903"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c1722451-c097-4dc3-b5d2-0fda2403bf9d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4371762d-788f-4330-ab1c-efb79790643d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""44cc3fc6-d893-4337-be05-ca3b883b0f06"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""357be8c5-8e04-4d21-920f-22d10efbab09"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""525f22d8-f7cd-40e6-8be5-3eb607dd37ad"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5e6f332-435f-4f3e-b9c0-a06aacc0a746"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3b8082f0-4c26-4929-8ce3-f72fb50a957c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc6e149f-9665-4e68-9543-20536b433ea1"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30ed5a21-1a27-44eb-a4ad-1f8a544d0f6a"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8da8ae75-84ba-4576-9e3b-9e217aae6c11"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b119ddf-fb02-4ca9-8718-5602e2ecfacf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01f2c801-5ec7-41eb-b156-851b50fea22e"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01f7bff3-47e6-4349-ba9c-34ea5808b430"",
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
                    ""id"": ""b3aa379e-67e7-489d-8b26-90ab6ca61e56"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fee74e9-8179-4ed7-872f-42e219d2b834"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d688169b-271b-4f9d-8e60-6fe391e9b456"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f644e333-87d7-4297-9fb2-c188ea7ecabb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c263168-3453-4f2e-b13d-547a5f9539ae"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52be9fc8-98a8-4bdc-a3d5-d8864b7b52bd"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fb9ff7d-038e-42c0-bd36-c660bbfee304"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""AndroidGamepad"",
            ""bindingGroup"": ""AndroidGamepad"",
            ""devices"": []
        }
    ]
}");
        // CarController
        m_CarController = asset.FindActionMap("CarController", throwIfNotFound: true);
        m_CarController_Throttle = m_CarController.FindAction("Throttle", throwIfNotFound: true);
        m_CarController_Brake = m_CarController.FindAction("Brake", throwIfNotFound: true);
        m_CarController_HandBrake = m_CarController.FindAction("HandBrake", throwIfNotFound: true);
        m_CarController_Clutch = m_CarController.FindAction("Clutch", throwIfNotFound: true);
        m_CarController_ShiftUp = m_CarController.FindAction("ShiftUp", throwIfNotFound: true);
        m_CarController_ShiftDown = m_CarController.FindAction("ShiftDown", throwIfNotFound: true);
        m_CarController_Steer = m_CarController.FindAction("Steer", throwIfNotFound: true);
        m_CarController_ChangeCamera = m_CarController.FindAction("Change Camera", throwIfNotFound: true);
        m_CarController_CameraRotateX = m_CarController.FindAction("Camera Rotate X", throwIfNotFound: true);
        m_CarController_CameraRotateY = m_CarController.FindAction("Camera Rotate Y", throwIfNotFound: true);
        m_CarController_LeftSign = m_CarController.FindAction("Left Sign", throwIfNotFound: true);
        m_CarController_RightSign = m_CarController.FindAction("Right Sign", throwIfNotFound: true);
        m_CarController_HazardSign = m_CarController.FindAction("Hazard Sign", throwIfNotFound: true);
        m_CarController_FrontLight = m_CarController.FindAction("Front Light", throwIfNotFound: true);
        m_CarController_Pause = m_CarController.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
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

    // CarController
    private readonly InputActionMap m_CarController;
    private ICarControllerActions m_CarControllerActionsCallbackInterface;
    private readonly InputAction m_CarController_Throttle;
    private readonly InputAction m_CarController_Brake;
    private readonly InputAction m_CarController_HandBrake;
    private readonly InputAction m_CarController_Clutch;
    private readonly InputAction m_CarController_ShiftUp;
    private readonly InputAction m_CarController_ShiftDown;
    private readonly InputAction m_CarController_Steer;
    private readonly InputAction m_CarController_ChangeCamera;
    private readonly InputAction m_CarController_CameraRotateX;
    private readonly InputAction m_CarController_CameraRotateY;
    private readonly InputAction m_CarController_LeftSign;
    private readonly InputAction m_CarController_RightSign;
    private readonly InputAction m_CarController_HazardSign;
    private readonly InputAction m_CarController_FrontLight;
    private readonly InputAction m_CarController_Pause;
    public struct CarControllerActions
    {
        private @InputSystem m_Wrapper;
        public CarControllerActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throttle => m_Wrapper.m_CarController_Throttle;
        public InputAction @Brake => m_Wrapper.m_CarController_Brake;
        public InputAction @HandBrake => m_Wrapper.m_CarController_HandBrake;
        public InputAction @Clutch => m_Wrapper.m_CarController_Clutch;
        public InputAction @ShiftUp => m_Wrapper.m_CarController_ShiftUp;
        public InputAction @ShiftDown => m_Wrapper.m_CarController_ShiftDown;
        public InputAction @Steer => m_Wrapper.m_CarController_Steer;
        public InputAction @ChangeCamera => m_Wrapper.m_CarController_ChangeCamera;
        public InputAction @CameraRotateX => m_Wrapper.m_CarController_CameraRotateX;
        public InputAction @CameraRotateY => m_Wrapper.m_CarController_CameraRotateY;
        public InputAction @LeftSign => m_Wrapper.m_CarController_LeftSign;
        public InputAction @RightSign => m_Wrapper.m_CarController_RightSign;
        public InputAction @HazardSign => m_Wrapper.m_CarController_HazardSign;
        public InputAction @FrontLight => m_Wrapper.m_CarController_FrontLight;
        public InputAction @Pause => m_Wrapper.m_CarController_Pause;
        public InputActionMap Get() { return m_Wrapper.m_CarController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarControllerActions set) { return set.Get(); }
        public void SetCallbacks(ICarControllerActions instance)
        {
            if (m_Wrapper.m_CarControllerActionsCallbackInterface != null)
            {
                @Throttle.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnThrottle;
                @Brake.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnBrake;
                @HandBrake.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnHandBrake;
                @HandBrake.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnHandBrake;
                @HandBrake.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnHandBrake;
                @Clutch.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnClutch;
                @Clutch.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnClutch;
                @Clutch.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnClutch;
                @ShiftUp.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnShiftUp;
                @ShiftUp.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnShiftUp;
                @ShiftUp.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnShiftUp;
                @ShiftDown.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnShiftDown;
                @ShiftDown.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnShiftDown;
                @ShiftDown.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnShiftDown;
                @Steer.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnSteer;
                @ChangeCamera.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnChangeCamera;
                @CameraRotateX.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnCameraRotateX;
                @CameraRotateX.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnCameraRotateX;
                @CameraRotateX.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnCameraRotateX;
                @CameraRotateY.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnCameraRotateY;
                @CameraRotateY.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnCameraRotateY;
                @CameraRotateY.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnCameraRotateY;
                @LeftSign.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnLeftSign;
                @LeftSign.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnLeftSign;
                @LeftSign.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnLeftSign;
                @RightSign.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnRightSign;
                @RightSign.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnRightSign;
                @RightSign.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnRightSign;
                @HazardSign.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnHazardSign;
                @HazardSign.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnHazardSign;
                @HazardSign.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnHazardSign;
                @FrontLight.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnFrontLight;
                @FrontLight.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnFrontLight;
                @FrontLight.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnFrontLight;
                @Pause.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_CarControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @HandBrake.started += instance.OnHandBrake;
                @HandBrake.performed += instance.OnHandBrake;
                @HandBrake.canceled += instance.OnHandBrake;
                @Clutch.started += instance.OnClutch;
                @Clutch.performed += instance.OnClutch;
                @Clutch.canceled += instance.OnClutch;
                @ShiftUp.started += instance.OnShiftUp;
                @ShiftUp.performed += instance.OnShiftUp;
                @ShiftUp.canceled += instance.OnShiftUp;
                @ShiftDown.started += instance.OnShiftDown;
                @ShiftDown.performed += instance.OnShiftDown;
                @ShiftDown.canceled += instance.OnShiftDown;
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
                @ChangeCamera.started += instance.OnChangeCamera;
                @ChangeCamera.performed += instance.OnChangeCamera;
                @ChangeCamera.canceled += instance.OnChangeCamera;
                @CameraRotateX.started += instance.OnCameraRotateX;
                @CameraRotateX.performed += instance.OnCameraRotateX;
                @CameraRotateX.canceled += instance.OnCameraRotateX;
                @CameraRotateY.started += instance.OnCameraRotateY;
                @CameraRotateY.performed += instance.OnCameraRotateY;
                @CameraRotateY.canceled += instance.OnCameraRotateY;
                @LeftSign.started += instance.OnLeftSign;
                @LeftSign.performed += instance.OnLeftSign;
                @LeftSign.canceled += instance.OnLeftSign;
                @RightSign.started += instance.OnRightSign;
                @RightSign.performed += instance.OnRightSign;
                @RightSign.canceled += instance.OnRightSign;
                @HazardSign.started += instance.OnHazardSign;
                @HazardSign.performed += instance.OnHazardSign;
                @HazardSign.canceled += instance.OnHazardSign;
                @FrontLight.started += instance.OnFrontLight;
                @FrontLight.performed += instance.OnFrontLight;
                @FrontLight.canceled += instance.OnFrontLight;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public CarControllerActions @CarController => new CarControllerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    public struct UIActions
    {
        private @InputSystem m_Wrapper;
        public UIActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
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
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_AndroidGamepadSchemeIndex = -1;
    public InputControlScheme AndroidGamepadScheme
    {
        get
        {
            if (m_AndroidGamepadSchemeIndex == -1) m_AndroidGamepadSchemeIndex = asset.FindControlSchemeIndex("AndroidGamepad");
            return asset.controlSchemes[m_AndroidGamepadSchemeIndex];
        }
    }
    public interface ICarControllerActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnHandBrake(InputAction.CallbackContext context);
        void OnClutch(InputAction.CallbackContext context);
        void OnShiftUp(InputAction.CallbackContext context);
        void OnShiftDown(InputAction.CallbackContext context);
        void OnSteer(InputAction.CallbackContext context);
        void OnChangeCamera(InputAction.CallbackContext context);
        void OnCameraRotateX(InputAction.CallbackContext context);
        void OnCameraRotateY(InputAction.CallbackContext context);
        void OnLeftSign(InputAction.CallbackContext context);
        void OnRightSign(InputAction.CallbackContext context);
        void OnHazardSign(InputAction.CallbackContext context);
        void OnFrontLight(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
    }
}
