using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{
    private InputAction OpenMenu;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private Slider MouseSensibilitySlider;

    void Start()
    {
        OpenMenu = InputSystem.actions.FindAction("UI/Menu");
        OpenMenu.started += OpenMenuAction;//Delegate Susbscribing to started event of the OpenMenu action
        MouseSensibilitySlider.onValueChanged.AddListener(delegate { OnValueChanged(MouseSensibilitySlider.value); });//Subscribe to an event
    }

    private void OpenMenuAction(InputAction.CallbackContext Context)
    {
        Debug.Log("Menu opened P");
        if(MenuUI.activeSelf)
        {
            MenuUI.SetActive(false);
            InputSystem.actions.FindActionMap("Player").Enable();//Enable
            Cursor.lockState = CursorLockMode.Locked;//lock the cursor
            Cursor.visible = false;
            return;
        }
        else
        {
            MenuUI.SetActive(true);
            InputSystem.actions.FindActionMap("Player").Disable();//Disable the Player action map when the menu is open preventing PlayerMovement
            Cursor.lockState = CursorLockMode.None;//Unlock the cursor
            Cursor.visible = true;
            return;
        }
    }

    private void OnValueChanged(float Value)
    {
        Debug.Log("Value Changed to: " + Value);
    }

    private void OnDisable()
    {
        OpenMenu.started -= OpenMenuAction;//Unsubscribe from the started event when the object is disabled to prevent memory leaks
        MouseSensibilitySlider.onValueChanged.RemoveAllListeners();//Unsubscribe from the slider event to prevent memory leaks
    }
}
