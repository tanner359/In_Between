// GENERATED AUTOMATICALLY FROM 'Assets/JumboShell/Inventory System/Inputs/Inventory_Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inventory_Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inventory_Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inventory_Inputs"",
    ""maps"": [
        {
            ""name"": ""Inventory"",
            ""id"": ""75def19c-01d8-4b76-a079-021a63deea13"",
            ""actions"": [
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""7ea8b2c5-1494-4e51-accf-764db0ff42fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""93b882d6-6f30-4507-9cb5-0531f00eb22c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""5d26fa06-fec8-4aef-b1ee-057a2ad3cea0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Split"",
                    ""type"": ""Button"",
                    ""id"": ""8661a0b1-f457-4179-8fa1-61e554b69883"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""86d944c3-4c25-4b51-ae79-3570ad22968f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""70738bab-d348-4cf2-8cea-72d2d6f8d665"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Shift+LeftClick"",
                    ""id"": ""616a7251-9dfa-49b4-ae98-dcabb279aaed"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Split"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5c74ceee-dacc-4581-afd7-be39554a33f0"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Split"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""cd03d24b-2b5d-4f81-863f-4a9f8a6415c7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Split"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""316f332b-5163-4c41-85a0-0e8c16f712eb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f09c04e5-f533-4e1d-b501-0709dd070a68"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ded96605-ed39-4d09-b19c-4b24417405e0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""e65087a5-062e-4020-90c5-5a0c91ba279b"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""79ebaabe-cdfc-4676-8e4b-5933513263fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c7be7ffb-27c3-4151-bdfe-53b8526e2ed9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
        }
    ]
}");
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_RightClick = m_Inventory.FindAction("RightClick", throwIfNotFound: true);
        m_Inventory_LeftClick = m_Inventory.FindAction("LeftClick", throwIfNotFound: true);
        m_Inventory_MousePosition = m_Inventory.FindAction("MousePosition", throwIfNotFound: true);
        m_Inventory_Split = m_Inventory.FindAction("Split", throwIfNotFound: true);
        m_Inventory_Drop = m_Inventory.FindAction("Drop", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
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

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_RightClick;
    private readonly InputAction m_Inventory_LeftClick;
    private readonly InputAction m_Inventory_MousePosition;
    private readonly InputAction m_Inventory_Split;
    private readonly InputAction m_Inventory_Drop;
    public struct InventoryActions
    {
        private @Inventory_Inputs m_Wrapper;
        public InventoryActions(@Inventory_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightClick => m_Wrapper.m_Inventory_RightClick;
        public InputAction @LeftClick => m_Wrapper.m_Inventory_LeftClick;
        public InputAction @MousePosition => m_Wrapper.m_Inventory_MousePosition;
        public InputAction @Split => m_Wrapper.m_Inventory_Split;
        public InputAction @Drop => m_Wrapper.m_Inventory_Drop;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @RightClick.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnRightClick;
                @LeftClick.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnLeftClick;
                @MousePosition.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnMousePosition;
                @Split.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSplit;
                @Split.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSplit;
                @Split.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSplit;
                @Drop.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnDrop;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Split.started += instance.OnSplit;
                @Split.performed += instance.OnSplit;
                @Split.canceled += instance.OnSplit;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_Interact;
    public struct InteractionActions
    {
        private @Inventory_Inputs m_Wrapper;
        public InteractionActions(@Inventory_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IInventoryActions
    {
        void OnRightClick(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnSplit(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
}
