// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""f5ee90bc-61f0-44e2-a068-83a84b07cd36"",
            ""actions"": [
                {
                    ""name"": ""Left Click"",
                    ""type"": ""Button"",
                    ""id"": ""be2afb62-4dbb-4d11-8626-f9430f440078"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Click"",
                    ""type"": ""Button"",
                    ""id"": ""6276b9a7-83b2-4f28-9445-d006318c0648"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Middle Click"",
                    ""type"": ""Button"",
                    ""id"": ""705aa92d-0aa2-482b-926c-de0295b0e65a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Middle Scroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cb6ec8ce-a946-4873-a30a-66a3db35f832"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""477b65d9-e5ea-456b-ae04-3ff9dc06f1cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""b917989d-5a58-46d3-9baf-f38b6adc633d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CamerMove"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a8c364f4-7615-4afd-b98a-c4f26d0be52d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shift"",
                    ""type"": ""Button"",
                    ""id"": ""f0865f69-d285-4a0b-93fe-726f3b05c5f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""427ffa5a-bcda-47aa-bf90-ad474e64869e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab45d1e2-572b-468d-9a09-8a66f0bb4e55"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f83e9516-39a2-4e70-bc66-51af584be0eb"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d1fbdff-f0ca-45a5-b34f-90dd3307547f"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c9dac51a-096a-4b6d-8f1b-89c8ae3bbcf6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle Scroll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c46886dc-d0a9-4af2-89e7-cc78a1327f4f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c147b96d-3f1b-4ac0-89d6-14c3e5c07c7b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2bbe5349-aa07-4528-91bf-8010cfeb6ec4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6ff599e-043d-44a8-9797-30f08309cd61"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f5affb2-fc82-49ff-8712-b52be454218d"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""efeb0cc3-5964-4835-b46f-a8b689cf74f8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""14c0d141-4f8d-46c5-adb8-8fe4749a6adc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3c90336c-e4ae-4d95-b0d5-7dd8d30f7340"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8e05c172-6c60-4577-90cc-822ff44a4e4f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_LeftClick = m_Default.FindAction("Left Click", throwIfNotFound: true);
        m_Default_RightClick = m_Default.FindAction("Right Click", throwIfNotFound: true);
        m_Default_MiddleClick = m_Default.FindAction("Middle Click", throwIfNotFound: true);
        m_Default_MiddleScroll = m_Default.FindAction("Middle Scroll", throwIfNotFound: true);
        m_Default_Esc = m_Default.FindAction("Esc", throwIfNotFound: true);
        m_Default_MousePosition = m_Default.FindAction("MousePosition", throwIfNotFound: true);
        m_Default_CamerMove = m_Default.FindAction("CamerMove", throwIfNotFound: true);
        m_Default_Shift = m_Default.FindAction("Shift", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_LeftClick;
    private readonly InputAction m_Default_RightClick;
    private readonly InputAction m_Default_MiddleClick;
    private readonly InputAction m_Default_MiddleScroll;
    private readonly InputAction m_Default_Esc;
    private readonly InputAction m_Default_MousePosition;
    private readonly InputAction m_Default_CamerMove;
    private readonly InputAction m_Default_Shift;
    public struct DefaultActions
    {
        private @InputControls m_Wrapper;
        public DefaultActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_Default_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_Default_RightClick;
        public InputAction @MiddleClick => m_Wrapper.m_Default_MiddleClick;
        public InputAction @MiddleScroll => m_Wrapper.m_Default_MiddleScroll;
        public InputAction @Esc => m_Wrapper.m_Default_Esc;
        public InputAction @MousePosition => m_Wrapper.m_Default_MousePosition;
        public InputAction @CamerMove => m_Wrapper.m_Default_CamerMove;
        public InputAction @Shift => m_Wrapper.m_Default_Shift;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightClick;
                @MiddleClick.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMiddleClick;
                @MiddleScroll.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMiddleScroll;
                @MiddleScroll.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMiddleScroll;
                @MiddleScroll.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMiddleScroll;
                @Esc.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEsc;
                @MousePosition.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @CamerMove.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCamerMove;
                @CamerMove.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCamerMove;
                @CamerMove.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCamerMove;
                @Shift.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShift;
                @Shift.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShift;
                @Shift.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShift;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @MiddleScroll.started += instance.OnMiddleScroll;
                @MiddleScroll.performed += instance.OnMiddleScroll;
                @MiddleScroll.canceled += instance.OnMiddleScroll;
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @CamerMove.started += instance.OnCamerMove;
                @CamerMove.performed += instance.OnCamerMove;
                @CamerMove.canceled += instance.OnCamerMove;
                @Shift.started += instance.OnShift;
                @Shift.performed += instance.OnShift;
                @Shift.canceled += instance.OnShift;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnMiddleScroll(InputAction.CallbackContext context);
        void OnEsc(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCamerMove(InputAction.CallbackContext context);
        void OnShift(InputAction.CallbackContext context);
    }
}
