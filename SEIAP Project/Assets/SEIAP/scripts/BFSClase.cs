using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Puzblemanager))]
public class BFSClase : MonoBehaviour 
{
	public Puzzblestate state;
	public Puzblemanager pm;
	public List<string> solution;
	public int nodosTime = 100;

	// Performance Counter
	public int nodesVisited = 0;

	private void Start()
	{
		pm = GetComponent<Puzblemanager>();
	}

	public void SolucionaElPuzzle()
	{
		StartCoroutine(busquedaPuzzle());
	}

	public IEnumerator busquedaPuzzle()
	{
		int cuentaFrame = 0;

		// Inicializamos la lista
		solution = new List<string>();
		// Inicializamos el estado
		state = pm.curretstate;
		
		// Ajuste
		state.parent = null;
		state.action = "Root";

		// Creamos una lista y agregamos el estado
		List<Puzzblestate> frontera = new List<Puzzblestate>();
		frontera.Add(state);

		// Recorremos un while
		while(frontera.Count > 0)
		{
			Puzzblestate nodo = frontera[0];
			frontera.RemoveAt(0);

			nodesVisited++;

			if(PuzzleUtility.checkState(nodo))
			{
				solution.Clear();
				while(nodo.parent != null)
				{
					solution.Add(nodo.action);
					nodo = nodo.parent;
				}
				solution.Reverse();
				break;
			}

			List<Puzzblestate> hijos = nodo.getchils();

			foreach(Puzzblestate hijo in hijos)
			{
				frontera.Add(hijo);
			}
			
			if(cuentaFrame >= nodosTime)
			{
				cuentaFrame = 0;

				// Esperamos al final del frame
				yield return new WaitForEndOfFrame();
			}	
			cuentaFrame++;
		}
	}
}
