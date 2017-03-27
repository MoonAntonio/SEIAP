using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Puzblemanager))]
public class BFSClase : MonoBehaviour 
{
	public Puzzblestate state;
	public Puzblemanager pm;

	private void Start()
	{
		pm = GetComponent<Puzblemanager>();
	}

	public bool busquedaPuzzle()
	{
		// Inicializamos el estado
		state = pm.curretstate;

		// Creamos una lista y agregamos el estado
		List<Puzzblestate> frontera = new List<Puzzblestate>();
		frontera.Add(state);

		// Recorremos un while
		while(frontera.Count > 0)
		{
			Puzzblestate nodo = frontera[0];
			frontera.RemoveAt(0);

			if(PuzzleUtility.checkState(nodo)) return true;

			List<Puzzblestate> hijos = nodo.getchils();

			foreach(Puzzblestate hijo in hijos)
			{
				frontera.Add(hijo);
			}
		}
		return false;
	}
}
