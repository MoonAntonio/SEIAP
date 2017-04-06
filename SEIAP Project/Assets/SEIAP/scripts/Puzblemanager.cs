using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzblemanager : MonoBehaviour {

    public int[] initialvalues = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    //privado
    Puzzblestate initialstate;
    public int shuffleforce = 10;
    // Use this for initialization
    //este esera el publico 
    public Puzzblestate curretstate;

	public bool victoria = false;


	void Start () {
        initialstate = new Puzzblestate(initialvalues);
        initialstate.action = "Root";
        initialstate.depth = 0;
		
		curretstate = initialstate;

		if(victoria){Debug.Log("Victoria");} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Undo()
	{
		curretstate = curretstate.parent;
	}

	public void action(string a)
	{
		Puzzblestate temp = new Puzzblestate();
		switch (a) 
		{
			case "Up":
				temp = curretstate.moveup ();
				break;

			case "Down":
				temp = curretstate.movedown ();
				break;

			case "Left":
				temp = curretstate.moveleft ();
				break;

			case "Right":
				temp = curretstate.moveright ();
				break;

			case "Undo":
				Undo ();
				break;
		}

		if(temp != null) curretstate = temp;

		victoria = PuzzleUtility.checkState(curretstate);

		if(victoria){Debug.Log("Victoria");}
	}

	public void Aleatoriedad()
	{
		int temp = Random.Range(3,10);
		Debug.Log("Temp: " + temp);

		for(int n = 0; n < temp; n ++)
		{
			int a = Random.Range(0,3);
			Debug.Log("A: " + a);

			switch(a)
			{
				case 0:
						action("Up");
						Debug.Log("Accion: Up");
						break;

				case 1:
						action("Down");
						Debug.Log("Accion: Down");
						break;

				case 2:
						action("Left");
						Debug.Log("Accion: Left");
						break;

				case 3:
						action("Right");
						Debug.Log("Accion: Right");
						break;

				default:
						action("Up");
						Debug.Log("Accion: Up");
						break;
			}
		}
	}
}
