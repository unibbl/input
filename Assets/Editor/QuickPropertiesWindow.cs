using UnityEngine;
using UnityEditor;

public class QuickPropertiesWindow : EditorWindow {

	string text = "Nothing Opened...";
	Vector2 scroll;
	//string myString = "Hello World";
	
	// Add menu named "My Window" to the Window menu
	[MenuItem ("Window/Quick Properties")]
	static void Init () {
		// Get existing open window or if none, make a new one:
		QuickPropertiesWindow window = (QuickPropertiesWindow)EditorWindow.GetWindow (typeof (QuickPropertiesWindow));
		window.Show();
	}

	void OnGUI() {

		scroll = EditorGUILayout.BeginScrollView(scroll);		
		text = EditorGUILayout.TextArea(text, GUILayout.Height(position.height - 30));		
		EditorGUILayout.EndScrollView();
		Debug.Log ("edit changed");
	}

	//void OnGUI () {

	
	//	myString = EditorGUILayout.TextField ("Text Field", myString);

		//object[] obj = GameObject.FindObjectsOfType(typeof (GameObject));
		//foreach (object o in obj)
		//{
		//	GameObject g = (GameObject) o;
		//	GUILayout.Label (g.name, EditorStyles.boldLabel);
		//}
		/*
		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField ("Text Field", myString);
		
		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
		*/

	//}
}