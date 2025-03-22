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
                    ""name"": ""Shoot1"",
                    ""type"": ""Button"",
                    ""id"": ""168e150c-701b-4df4-b01b-8b7957185730"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gun1"",
                    ""type"": ""Button"",
                    ""id"": ""2cf1cbe3-e446-4705-a2b9-58413a287189"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gun2"",
                    ""type"": ""Button"",
                    ""id"": ""1f20eddf-57ae-4896-a71b-ceb170d23670"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gun3"",
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
                    ""action"": ""Shoot1"",
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
                    ""action"": ""Gun1"",
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
                    ""action"": ""Gun2"",
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
                    ""action"": ""Gun3"",
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
        m_GamePlay_Shoot1 = m_GamePlay.FindAction("Shoot1", throwIfNotFound: true);
        m_GamePlay_Gun1 = m_GamePlay.FindAction("Gun1", throwIfNotFound: true);
        m_GamePlay_Gun2 = m_GamePlay.FindAction("Gun2", throwIfNotFound: true);
        m_GamePlay_Gun3 = m_GamePlay.FindAction("Gun3", throwIfNotFound: true);
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
    private readonly InputAction m_GamePlay_Shoot1;
    private readonly InputAction m_GamePlay_Gun1;
    private readonly InputAction m_GamePlay_Gun2;
    private readonly InputAction m_GamePlay_Gun3;
    public struct GamePlayActions
    {
        private @Inputs m_Wrapper;
        public GamePlayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot1 => m_Wrapper.m_GamePlay_Shoot1;
        public InputAction @Gun1 => m_Wrapper.m_GamePlay_Gun1;
        public InputAction @Gun2 => m_Wrapper.m_GamePlay_Gun2;
        public InputAction @Gun3 => m_Wrapper.m_GamePlay_Gun3;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Shoot1.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShoot1;
                @Shoot1.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShoot1;
                @Shoot1.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShoot1;
                @Gun1.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun1;
                @Gun1.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun1;
                @Gun1.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun1;
                @Gun2.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun2;
                @Gun2.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun2;
                @Gun2.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun2;
                @Gun3.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun3;
                @Gun3.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun3;
                @Gun3.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGun3;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot1.started += instance.OnShoot1;
                @Shoot1.performed += instance.OnShoot1;
                @Shoot1.canceled += instance.OnShoot1;
                @Gun1.started += instance.OnGun1;
                @Gun1.performed += instance.OnGun1;
                @Gun1.canceled += instance.OnGun1;
                @Gun2.started += instance.OnGun2;
                @Gun2.performed += instance.OnGun2;
                @Gun2.canceled += instance.OnGun2;
                @Gun3.started += instance.OnGun3;
                @Gun3.performed += instance.OnGun3;
                @Gun3.canceled += instance.OnGun3;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnShoot1(InputAction.CallbackContext context);
        void OnGun1(InputAction.CallbackContext context);
        void OnGun2(InputAction.CallbackContext context);
        void OnGun3(InputAction.CallbackContext context);
    }
}
