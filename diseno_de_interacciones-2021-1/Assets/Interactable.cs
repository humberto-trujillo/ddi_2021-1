using System.Collections;
using System.Collections.Generic;
using IBM.Watsson.Examples;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone = false;
    public bool gazedAt = false;

    public float gazeInteractTime = 2f;
    public float gazeTimer = 0;
    // public KeyCode interactionKey = KeyCode.P;
    public string interactionButton = "Interact";

    public string voiceCommand = "Brincar";

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        ExampleStreaming commandProcessor = GameObject.FindObjectOfType<ExampleStreaming>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
    }
    
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    public virtual void Update()
    {
        // if (isInsideZone && Input.GetKeyDown(interactionKey))
        if (isInsideZone && CrossPlatformInputManager.GetButtonDown(interactionButton))
        {
            Interact();
        }
        if (gazedAt)
        {
            if ((gazeTimer += Time.deltaTime) >= gazeInteractTime)
            {
                Interact();
                gazedAt = false;
                gazeTimer = 0f;
            }
        }
    }

    public void OnVoiceCommandRecognized(string command)
    {
        if (command.ToLower() == voiceCommand.ToLower() && gazedAt)
        {
            Interact();
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("Entró en el área");
        isInsideZone = true;
    }

    // /// <summary>
    // /// OnMouseDown is called when the user has pressed the mouse button while
    // /// over the GUIElement or Collider.
    // /// </summary>
    // void OnMouseDown()
    // {
    //     Interact();
    // }

    public void SetGazedAt(bool gazedAt)
    {
        this.gazedAt = gazedAt;
        if (!gazedAt)
        {
            gazeTimer = 0f;
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;
        gazeTimer = 0f;
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        gazeTimer = 0f;
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        Interact();
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("Salió en el área");
        isInsideZone = false;
    }

    public virtual void Interact()
    {

    }    
}
