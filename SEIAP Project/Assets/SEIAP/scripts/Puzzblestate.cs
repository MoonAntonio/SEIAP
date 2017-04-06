using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Puzzblestate
{
    public int[] state; //array q va a represmntar los estados
    public int x;// saber en q posicion esta el jugador vamos el espacdio en blanco
    public int y;
    public string action;// texto que se mostrara en la solucion
    public int depth;// cada vez q creemos un nodo representara el nivel de profundida

    public Puzzblestate parent;
	
   public Puzzblestate()//metodo constructor crea desde 0 el primer estado
    {
        state = new int[9];
        for(int i = 0; i < 9; i++)
        {
            state[i] = i;
        }
        getcoords();
    }
    //en un array  para saber su posicion se divi  se divide la posicion entre 3 , y el resto y el coecifiente te hayan el nuemro
    //recive un aaray de intg  , y asi  q crea un hijo con esos nuevos valores

    public Puzzblestate(int[] initialstate)
    {
        state = initialstate;
        getcoords();
    }



    public List<Puzzblestate> getchils()
    {
        List<Puzzblestate> childs = new List<Puzzblestate>();
        Puzzblestate child = moveup();
        if (child != null) childs.Add(child);
        child = movedown();
        if (child != null) childs.Add(child);
        child = moveleft();
        if (child != null) childs.Add(child);
        child = moveright();
        if (child != null) childs.Add(child);

        return childs;
    }

    public Puzzblestate moveup()
    {
        Puzzblestate childNode;
        if (y - 1 < 0)
        {
            return null;
        }
        else
        {
            // crea un nodo , con una accion aplicada crea un array vacio , clonando  un nuevo tablero y cambia las posiciones
            int[] updatenode = state.Clone() as int[];
            updatenode[y * 3 + x] = state[(y - 1) * 3 + x];
            updatenode[(y - 1) * 3 + x] = 0;
            childNode = new Puzzblestate(updatenode);
            childNode.action = "Up";
            childNode.parent = this;
            childNode.depth=depth+1;
            return childNode;
        }
    }

    public Puzzblestate movedown()
    {
        Puzzblestate childNode;
        if (y +1 > 2)
        {
            return null;
        }
        else
        {
            // crea un nodo , con una accion aplicada crea un array vacio , clonando  un nuevo tablero y cambia las posiciones
            int[] updatenode = state.Clone() as int[];
            updatenode[y * 3 + x] = state[(y + 1) * 3 + x];
            updatenode[(y + 1) * 3 + x] = 0;
            childNode = new Puzzblestate(updatenode);
            childNode.action = "Down";
            childNode.parent = this;
            childNode.depth = depth + 1;
            return childNode;
        }

    }

    public Puzzblestate moveleft()
    {
        Puzzblestate childNode;
        if (x-1< 0)
        {
            return null;
        }
        else
        {
            // crea un nodo , con una accion aplicada crea un array vacio , clonando  un nuevo tablero y cambia las posiciones
            int[] updatenode = state.Clone() as int[];
            updatenode[y * 3 + x] = state[y  * 3 + x-1];
            updatenode[y  * 3 + x-1] = 0;
            childNode = new Puzzblestate(updatenode);
            childNode.action = "Left";
            childNode.parent = this;
            childNode.depth = depth + 1;
            return childNode;
        }

    }

    public Puzzblestate moveright()
    {
        Puzzblestate childNode;
        if (x +1  > 2)
        {
            return null;
        }
        else
        {
            // crea un nodo , con una accion aplicada crea un array vacio , clonando  un nuevo tablero y cambia las posiciones
            int[] updatenode = state.Clone() as int[];
            updatenode[y * 3 + x] = state[y * 3 + x + 1];
            updatenode[y * 3 + x + 1] = 0;
            childNode = new Puzzblestate(updatenode);
            childNode.action = "Right";
            childNode.parent = this;
            childNode.depth = depth + 1;
            return childNode;
        }

    }




    private void getcoords()
    {
        int index=-1;
        for(int i = 0; i < 9; i++)
        {
            if (state[i] == 0)
            {
                x = i % 3;
                y = i/3;
                return;
            }
        }
        x = -1;
        y = -1;
        //si devuelve el -1 es porq no encuentra el 0 , vamos q es imposible solo es un codigo de error , ya que busca la posicion del 0
    }

}
