using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{

	public InputField input;
	private InputField.SubmitEvent subEvent;
	public Text output;
	public string newText;
	// Use this for initialization
	void Start ()
	{
		input = gameObject.GetComponent<InputField> ();
		subEvent = new InputField.SubmitEvent ();
		subEvent.AddListener (SubmitEvent);
		input.onEndEdit = subEvent;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			input.ActivateInputField ();
		}
	}

	void SubmitEvent (string arg0)
	{

		string currentString = output.text;
		newText = currentString + "\n" + arg0;
		output.text = newText;
			
		input.text = "";
		input.DeactivateInputField ();


	}
}
