// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Architect/ArchitectController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ArchitectController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ArchitectController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ArchitectController"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""251cc0f9-afe0-4507-a6bf-fd47d7012317"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8c66c5f9-3600-432a-a1d4-1ba6f2d9beb3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a2951b98-e990-49d4-8b5e-e9db1582562b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e5d174c-9972-430c-af3f-87a64b6dccfd"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": ""Hold(duration=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de71d9a8-da10-4468-8878-9c0b887bc233"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c22fbb7e-d2da-4227-9589-f98286777d84"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(duration=8)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MousePosition = m_Mouse.FindAction("MousePosition", throwIfNotFound: true);
        m_Mouse_MouseSelect = m_Mouse.FindAction("MouseSelect", throwIfNotFound: true);
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

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_MousePosition;
    private readonly InputAction m_Mouse_MouseSelect;
    public struct MouseActions
    {
        private @ArchitectController m_Wrapper;
        public MouseActions(@ArchitectController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Mouse_MousePosition;
        public InputAction @MouseSelect => m_Wrapper.m_Mouse_MouseSelect;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePosition;
                @MouseSelect.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseSelect;
                @MouseSelect.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseSelect;
                @MouseSelect.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseSelect;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseSelect.started += instance.OnMouseSelect;
                @MouseSelect.performed += instance.OnMouseSelect;
                @MouseSelect.canceled += instance.OnMouseSelect;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IMouseActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseSelect(InputAction.CallbackContext context);
    }
}
