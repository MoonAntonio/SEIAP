using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextureDivider : MonoBehaviour
{

    public Texture2D source;


   public float width;
   public float height;

    public Sprite[] slices;

    // Use this for initialization
    void Start()
    {

        GameObject spritesRoot = GameObject.Find("SpritesRoot");
        slices = new Sprite[9];
        width = source.width / 3;
        height = source.height / 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Sprite newSprite = Sprite.Create(source, new Rect(j*width, source.height -( i*height), width, -height), new Vector2(0.5f, 0.5f));
                slices[j + (i*3)] = newSprite;

                GameObject n = new GameObject();
                n.name = "Slice" + (j + (i * 3));

                SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                sr.sprite = newSprite;
                n.transform.position = new Vector3(j  , -i  , 0);
                n.transform.parent = spritesRoot.transform;
            }
        }

        assignSlices();
    }

    void assignSlices()
    {
        for (int i = 0; i < 9; i++)
        {
        GameObject go = GameObject.Find("Tile" + i);
        go.transform.RotateAround(transform.position,Vector3.forward,180); 
            if (go)
            {
                Image sr = go.GetComponent<Image>();
                if (sr)
                {
                    sr.sprite = slices[i];
                }
            }

        }
        
    }
}
