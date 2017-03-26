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


	void Start () {
        initialstate = new Puzzblestate(initialvalues);
        initialstate.action = "Root";
        initialstate.depth = 0;

		curretstate = initialstate;
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
		switch (a) 
		{
			case "Up":
				curretstate = curretstate.moveup ();
				break;

			case "Down":
				curretstate = curretstate.movedown ();
				break;

			case "Left":
				curretstate = curretstate.moveleft ();
				break;

			case "Right":
				curretstate = curretstate.moveright ();
				break;

			case "Undo":
				Undo ();
				break;
		}

	}
}
