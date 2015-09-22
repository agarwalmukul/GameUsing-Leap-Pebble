using UnityEngine;
using System.Collections;
using Leap;

public class PlayerController : MonoBehaviour {

	Controller controller;

	public float speed;

	private Rigidbody rb;
	private Vector handcenter;
	public float handcenterx;
	public float handcenterz;
	public float handcentery;
	public bool jumpEvent;
	public float jumpHeight;
	public float gravity;
	private string str2;
	private int count = 0;

	void Start() {

		rb = GetComponent<Rigidbody> ();
		controller = new Controller ();
	}

	void Update(){

		//string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
		string[] lines = System.IO.File.ReadAllLines(@"../GameUsing-Leap-Pebble/BallGame-master/logFile.txt");

		if (lines.Length != null && lines.Length>0) {
			string last = lines [lines.Length - 1];

			int first = last.IndexOf (">") + 2;
			str2 = last.Substring (first, 1);

		}
		//if (str2 == "S") {
		
		//}


//		foreach (string line in lines)
//		{
			// Use a tab to indent each line of the file.
			//Console.WriteLine("\t" + line);
//		}

		Frame frame = controller.Frame ();
		HandList Hands = frame.Hands;
		Hand firstHand = Hands [0];
		handcenterx = firstHand.PalmVelocity.x;
		handcenterz = firstHand.PalmVelocity.z;
		if (str2 == "U" || Input.GetKeyDown("up")) {
			jumpEvent = true;
		} else {
			jumpEvent = false;
		}
		if (jumpEvent) {
			handcentery = jumpHeight;
		}
			handcentery -= gravity;
		
//	}
//	void FixedUpdate(){
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		if (handcenterx != null && handcenterz!=null) {

			float moveHorizontal = handcenterx;
			float moveVertical = -handcenterz;

			Vector3 movement = new Vector3 (moveHorizontal,handcentery, moveVertical);
			rb.AddForce (speed * movement);
		} //else {
			//rb.AddForce(speed * 0);
	//	}
	}
}