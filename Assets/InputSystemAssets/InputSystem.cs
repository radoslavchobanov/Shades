// GENERATED AUTOMATICALLY FROM 'Assets/InputSystemAssets/InputSystem.inputactions'

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
            ""name"": ""PlayerControls"",
            ""id"": ""68bcd418-ce34-4933-820b-9c90cb5e8d58"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""9733a792-3020-4047-bdf0-075715144fe6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9f36c936-b23c-4ab0-898e-214f3180c86c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeAimState"",
                    ""type"": ""Button"",
                    ""id"": ""66832699-de31-4775-96c6-f3ac84f18bc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""da7ac18b-abc2-4acd-a9cd-c0fc32efaf58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""acf02674-c29e-42b5-b792-1ed04cf1a271"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""253e3e2f-63ba-407b-a3f2-fae297d0b758"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d2307142-047f-4857-a427-e91e164faccb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a8f031b6-e7e5-4aa3-ad4c-738628957f79"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dff57042-c009-4836-948f-44975d35f7a5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""112cd334-fd47-42f7-910f-c63d233d39a8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab2f1724-5cb1-45ae-9e2d-7d8e9ae52f66"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeAimState"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2fcebf1-7f01-41f3-ab3c-e4b6367cfd8a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameInput"",
            ""id"": ""6d1e9250-75ad-427f-b912-13a10fcc9332"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3b0c9687-9e8b-4b05-bddc-a73e95491f89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26cd4f45-eaa4-4f98-955b-da477e271d29"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_HorizontalMovement = m_PlayerControls.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_PlayerControls_Interact = m_PlayerControls.FindAction("Interact", throwIfNotFound: true);
        m_PlayerControls_ChangeAimState = m_PlayerControls.FindAction("ChangeAimState", throwIfNotFound: true);
        m_PlayerControls_Dash = m_PlayerControls.FindAction("Dash", throwIfNotFound: true);
        // GameInput
        m_GameInput = asset.FindActionMap("GameInput", throwIfNotFound: true);
        m_GameInput_Pause = m_GameInput.FindAction("Pause", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_HorizontalMovement;
    private readonly InputAction m_PlayerControls_Interact;
    private readonly InputAction m_PlayerControls_ChangeAimState;
    private readonly InputAction m_PlayerControls_Dash;
    public struct PlayerControlsActions
    {
        private @InputSystem m_Wrapper;
        public PlayerControlsActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_PlayerControls_HorizontalMovement;
        public InputAction @Interact => m_Wrapper.m_PlayerControls_Interact;
        public InputAction @ChangeAimState => m_Wrapper.m_PlayerControls_ChangeAimState;
        public InputAction @Dash => m_Wrapper.m_PlayerControls_Dash;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHorizontalMovement;
                @Interact.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @ChangeAimState.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnChangeAimState;
                @ChangeAimState.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnChangeAimState;
                @ChangeAimState.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnChangeAimState;
                @Dash.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @ChangeAimState.started += instance.OnChangeAimState;
                @ChangeAimState.performed += instance.OnChangeAimState;
                @ChangeAimState.canceled += instance.OnChangeAimState;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // GameInput
    private readonly InputActionMap m_GameInput;
    private IGameInputActions m_GameInputActionsCallbackInterface;
    private readonly InputAction m_GameInput_Pause;
    public struct GameInputActions
    {
        private @InputSystem m_Wrapper;
        public GameInputActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameInput_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameInputActions set) { return set.Get(); }
        public void SetCallbacks(IGameInputActions instance)
        {
            if (m_Wrapper.m_GameInputActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameInputActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameInputActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameInputActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameInputActions @GameInput => new GameInputActions(this);
    public interface IPlayerControlsActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnChangeAimState(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IGameInputActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
