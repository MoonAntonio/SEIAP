using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_PuzzleManager : MonoBehaviour {

	public Puzblemanager AIController;

    private Text[] textHolders;
   

    private TextureDivider ImageUtility;

	// Use this for initialization
	void Start () {

		AIController = GameObject.FindObjectOfType<Puzblemanager>();
        textHolders = gameObject.GetComponentsInChildren<Text>();
      
        ImageUtility = FindObjectOfType<TextureDivider>();

    }

    // Update is called once per frame
    void Update()
    {

        if (AIController)
        {
            loadState();
        }

    }

    private void loadState()
    {
        for (int i = 0; i <9; i++)
        {
			if (AIController.curretstate.state[i] != 0)
            {
                 //if (textHolders.Length > 0) textHolders[i].text = AIController.currentState.state[i].ToString();
                //  imageHolders[i].sprite = ImageUtility.slices[i];
                Image holder = transform.FindChild("Tile" + i).GetComponent<Image>();
				Sprite source = GameObject.Find("Slice" + AIController.curretstate.state[i]).GetComponent<SpriteRenderer>().sprite;
                holder.sprite = source;
            }
            else
            {
                transform.FindChild("Tile" + i).GetComponent<Image>().sprite = null;
                //if (textHolders.Length > 0) textHolders[i].text = "";
                // imageHolders[i].sprite = null;
            }
           
        }
    }
}
