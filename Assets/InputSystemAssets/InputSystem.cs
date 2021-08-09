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
            ""name"": ""GameplayControlls"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameplayControlls
        m_GameplayControlls = asset.FindActionMap("GameplayControlls", throwIfNotFound: true);
        m_GameplayControlls_HorizontalMovement = m_GameplayControlls.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_GameplayControlls_Interact = m_GameplayControlls.FindAction("Interact", throwIfNotFound: true);
        m_GameplayControlls_ChangeAimState = m_GameplayControlls.FindAction("ChangeAimState", throwIfNotFound: true);
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

    // GameplayControlls
    private readonly InputActionMap m_GameplayControlls;
    private IGameplayControllsActions m_GameplayControllsActionsCallbackInterface;
    private readonly InputAction m_GameplayControlls_HorizontalMovement;
    private readonly InputAction m_GameplayControlls_Interact;
    private readonly InputAction m_GameplayControlls_ChangeAimState;
    public struct GameplayControllsActions
    {
        private @InputSystem m_Wrapper;
        public GameplayControllsActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_GameplayControlls_HorizontalMovement;
        public InputAction @Interact => m_Wrapper.m_GameplayControlls_Interact;
        public InputAction @ChangeAimState => m_Wrapper.m_GameplayControlls_ChangeAimState;
        public InputActionMap Get() { return m_Wrapper.m_GameplayControlls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayControllsActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayControllsActions instance)
        {
            if (m_Wrapper.m_GameplayControllsActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnHorizontalMovement;
                @Interact.started -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnInteract;
                @ChangeAimState.started -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnChangeAimState;
                @ChangeAimState.performed -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnChangeAimState;
                @ChangeAimState.canceled -= m_Wrapper.m_GameplayControllsActionsCallbackInterface.OnChangeAimState;
            }
            m_Wrapper.m_GameplayControllsActionsCallbackInterface = instance;
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
            }
        }
    }
    public GameplayControllsActions @GameplayControlls => new GameplayControllsActions(this);
    public interface IGameplayControllsActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnChangeAimState(InputAction.CallbackContext context);
    }
}
