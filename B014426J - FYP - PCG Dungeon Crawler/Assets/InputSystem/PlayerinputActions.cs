// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerinputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerinputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerinputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerinputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e7156fe4-1475-4d13-9368-b29918a210ca"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a70a3067-07bb-48f8-84ae-77e56fd6ebd6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""ce4aef40-75b5-48b5-bb5e-c91acfa89e99"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P. Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""5e4eca82-08af-4389-a3aa-48f8babd7c74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""S. Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""e7e237cb-0bc6-459a-9242-5b807bd828de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""d3b76210-2415-47e3-9178-b0d7bf0cdf92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon Slot 1"",
                    ""type"": ""Button"",
                    ""id"": ""2f0b96e2-d290-4e4c-8f38-2c9257ff3787"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon Slot 2"",
                    ""type"": ""Button"",
                    ""id"": ""35d84d80-ccfa-4dde-87fe-e127be54721e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon Slot 3"",
                    ""type"": ""Button"",
                    ""id"": ""5aaee3c8-7c00-4fb7-a390-428712bd22ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""83de9210-23e2-43df-bdcd-0aedd9178d8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""e31375d5-8042-4e32-a51d-c7570ddc6cd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""db86acc9-8211-4471-973b-b14de5e05815"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""d12c0d3b-240c-4690-8e3c-7b0820cf7af2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""26faa623-9dfc-4202-b23c-a03ebcb6b678"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bcd39a86-813c-439a-a20c-fcea97116fa7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""39bad06f-077a-4fa1-99c8-cf5555908d1e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""da51aefb-fb19-417f-b192-d2fc6169a339"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1e9530df-6c9a-4b47-aea2-641fdcd79851"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f4e47781-5c90-46c4-9d64-fbc9f492d054"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""456c1d06-019f-4efe-9ae5-8c97c5da25ee"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P. Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85c0d902-77de-4d53-ad1c-a862b3aa66de"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S. Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acb0b6a2-0eba-466a-abce-5233e658ee20"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""512287f5-d715-45d1-8c43-2fb8343c18aa"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""302fe3bc-0dfd-435d-8d0a-ce1f5af1e462"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon Slot 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56fbbba7-f0ba-4c42-bf64-875087d543c3"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon Slot 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e4bd285-1113-41f0-830b-cb0af97686d6"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon Slot 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00712e25-1f39-4eec-b04d-0a101eda6c5e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea876fc3-5665-4dcf-96c2-54dec3768d2a"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1378b1da-4271-40c0-b513-09a3208f809c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0aedfed-32e6-451c-a720-0681fdafb26b"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Aiming = m_Player.FindAction("Aiming", throwIfNotFound: true);
        m_Player_PShooting = m_Player.FindAction("P. Shooting", throwIfNotFound: true);
        m_Player_SShooting = m_Player.FindAction("S. Shooting", throwIfNotFound: true);
        m_Player_Melee = m_Player.FindAction("Melee", throwIfNotFound: true);
        m_Player_WeaponSlot1 = m_Player.FindAction("Weapon Slot 1", throwIfNotFound: true);
        m_Player_WeaponSlot2 = m_Player.FindAction("Weapon Slot 2", throwIfNotFound: true);
        m_Player_WeaponSlot3 = m_Player.FindAction("Weapon Slot 3", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Drop = m_Player.FindAction("Drop", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Aiming;
    private readonly InputAction m_Player_PShooting;
    private readonly InputAction m_Player_SShooting;
    private readonly InputAction m_Player_Melee;
    private readonly InputAction m_Player_WeaponSlot1;
    private readonly InputAction m_Player_WeaponSlot2;
    private readonly InputAction m_Player_WeaponSlot3;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Drop;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @PlayerinputActions m_Wrapper;
        public PlayerActions(@PlayerinputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Aiming => m_Wrapper.m_Player_Aiming;
        public InputAction @PShooting => m_Wrapper.m_Player_PShooting;
        public InputAction @SShooting => m_Wrapper.m_Player_SShooting;
        public InputAction @Melee => m_Wrapper.m_Player_Melee;
        public InputAction @WeaponSlot1 => m_Wrapper.m_Player_WeaponSlot1;
        public InputAction @WeaponSlot2 => m_Wrapper.m_Player_WeaponSlot2;
        public InputAction @WeaponSlot3 => m_Wrapper.m_Player_WeaponSlot3;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Drop => m_Wrapper.m_Player_Drop;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Aiming.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @PShooting.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPShooting;
                @PShooting.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPShooting;
                @PShooting.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPShooting;
                @SShooting.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSShooting;
                @SShooting.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSShooting;
                @SShooting.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSShooting;
                @Melee.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @WeaponSlot1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot1;
                @WeaponSlot1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot1;
                @WeaponSlot1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot1;
                @WeaponSlot2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot2;
                @WeaponSlot2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot2;
                @WeaponSlot2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot2;
                @WeaponSlot3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot3;
                @WeaponSlot3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot3;
                @WeaponSlot3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponSlot3;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Drop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @PShooting.started += instance.OnPShooting;
                @PShooting.performed += instance.OnPShooting;
                @PShooting.canceled += instance.OnPShooting;
                @SShooting.started += instance.OnSShooting;
                @SShooting.performed += instance.OnSShooting;
                @SShooting.canceled += instance.OnSShooting;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @WeaponSlot1.started += instance.OnWeaponSlot1;
                @WeaponSlot1.performed += instance.OnWeaponSlot1;
                @WeaponSlot1.canceled += instance.OnWeaponSlot1;
                @WeaponSlot2.started += instance.OnWeaponSlot2;
                @WeaponSlot2.performed += instance.OnWeaponSlot2;
                @WeaponSlot2.canceled += instance.OnWeaponSlot2;
                @WeaponSlot3.started += instance.OnWeaponSlot3;
                @WeaponSlot3.performed += instance.OnWeaponSlot3;
                @WeaponSlot3.canceled += instance.OnWeaponSlot3;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnPShooting(InputAction.CallbackContext context);
        void OnSShooting(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnWeaponSlot1(InputAction.CallbackContext context);
        void OnWeaponSlot2(InputAction.CallbackContext context);
        void OnWeaponSlot3(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
