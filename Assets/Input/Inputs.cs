// GENERATED AUTOMATICALLY FROM 'Assets/Input/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""5e2fc7ce-9e4f-4d61-91b5-f7f936b63b82"",
            ""actions"": [
                {
                    ""name"": ""Action1"",
                    ""type"": ""Button"",
                    ""id"": ""168e150c-701b-4df4-b01b-8b7957185730"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slot1"",
                    ""type"": ""Button"",
                    ""id"": ""2cf1cbe3-e446-4705-a2b9-58413a287189"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slot2"",
                    ""type"": ""Button"",
                    ""id"": ""1f20eddf-57ae-4896-a71b-ceb170d23670"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slot3"",
                    ""type"": ""Button"",
                    ""id"": ""0c8a0fbc-39c4-43a3-8419-32b984812760"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abcd3a36-2ced-45de-a589-5de70a0adf3d"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b594264-c174-4a7a-b88c-2ca0a2bb6d07"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef205418-0135-473a-823b-52782cd589f9"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c1e1f46-34c2-4c2a-a41c-f7f9aaf2cb2b"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Action1 = m_GamePlay.FindAction("Action1", throwIfNotFound: true);
        m_GamePlay_Slot1 = m_GamePlay.FindAction("Slot1", throwIfNotFound: true);
        m_GamePlay_Slot2 = m_GamePlay.FindAction("Slot2", throwIfNotFound: true);
        m_GamePlay_Slot3 = m_GamePlay.FindAction("Slot3", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Action1;
    private readonly InputAction m_GamePlay_Slot1;
    private readonly InputAction m_GamePlay_Slot2;
    private readonly InputAction m_GamePlay_Slot3;
    public struct GamePlayActions
    {
        private @Inputs m_Wrapper;
        public GamePlayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action1 => m_Wrapper.m_GamePlay_Action1;
        public InputAction @Slot1 => m_Wrapper.m_GamePlay_Slot1;
        public InputAction @Slot2 => m_Wrapper.m_GamePlay_Slot2;
        public InputAction @Slot3 => m_Wrapper.m_GamePlay_Slot3;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Action1.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAction1;
                @Action1.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAction1;
                @Action1.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAction1;
                @Slot1.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot1;
                @Slot1.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot1;
                @Slot1.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot1;
                @Slot2.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot2;
                @Slot2.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot2;
                @Slot2.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot2;
                @Slot3.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot3;
                @Slot3.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot3;
                @Slot3.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSlot3;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Action1.started += instance.OnAction1;
                @Action1.performed += instance.OnAction1;
                @Action1.canceled += instance.OnAction1;
                @Slot1.started += instance.OnSlot1;
                @Slot1.performed += instance.OnSlot1;
                @Slot1.canceled += instance.OnSlot1;
                @Slot2.started += instance.OnSlot2;
                @Slot2.performed += instance.OnSlot2;
                @Slot2.canceled += instance.OnSlot2;
                @Slot3.started += instance.OnSlot3;
                @Slot3.performed += instance.OnSlot3;
                @Slot3.canceled += instance.OnSlot3;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnAction1(InputAction.CallbackContext context);
        void OnSlot1(InputAction.CallbackContext context);
        void OnSlot2(InputAction.CallbackContext context);
        void OnSlot3(InputAction.CallbackContext context);
    }
}
