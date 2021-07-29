// GENERATED AUTOMATICALLY FROM 'Assets/Dist/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""default"",
            ""id"": ""07cdbdbb-ef5c-4408-b39f-291c67ce15e5"",
            ""actions"": [
                {
                    ""name"": ""Flick"",
                    ""type"": ""Value"",
                    ""id"": ""c6f2a55c-5f7e-430f-b5df-a5363e968793"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Button"",
                    ""id"": ""89a3e822-8346-40eb-964c-bdebbc2c1c60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""42abc20a-db6d-4f02-8107-130dcb1c6fb7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d0adabe-e420-4984-a212-a5536bbe6733"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // default
        m_default = asset.FindActionMap("default", throwIfNotFound: true);
        m_default_Flick = m_default.FindAction("Flick", throwIfNotFound: true);
        m_default_Aiming = m_default.FindAction("Aiming", throwIfNotFound: true);
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

    // default
    private readonly InputActionMap m_default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_default_Flick;
    private readonly InputAction m_default_Aiming;
    public struct DefaultActions
    {
        private @Player m_Wrapper;
        public DefaultActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Flick => m_Wrapper.m_default_Flick;
        public InputAction @Aiming => m_Wrapper.m_default_Aiming;
        public InputActionMap Get() { return m_Wrapper.m_default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Flick.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFlick;
                @Flick.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFlick;
                @Flick.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFlick;
                @Aiming.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAiming;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Flick.started += instance.OnFlick;
                @Flick.performed += instance.OnFlick;
                @Flick.canceled += instance.OnFlick;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
            }
        }
    }
    public DefaultActions @default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnFlick(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
    }
}
