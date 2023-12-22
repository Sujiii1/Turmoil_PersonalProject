using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Texture2D groTexture;
    Texture2D newTexture;
    SpriteRenderer spriteRen;

    float worldWidth, worldHeight;
    int pixelWidth, pixelHeight;

    [SerializeField] private bool isWork;
    [SerializeField] private bool isCol;


    private void Start()
    {
        //newTexture = new Texture2D(100, 20);
        newTexture = Instantiate(groTexture);
        spriteRen = GetComponent<SpriteRenderer>();

        #region[Sprite make Pixel]
       /* for (int i = 0; i < newTexture.width; i++)
        {
            for (int j = 0; j < newTexture.height; j++)
            {
                newTexture.SetPixel(i, j, Color.white);
            }
        }*/
        #endregion

        #region[Sprite make Pixel Color[] ] 
      /*  newTexture = new Texture2D(groTexture.width, groTexture.height);
        Color[] colors = groTexture.GetPixels();    //GetPixels()?
        newTexture.SetPixels(colors);               //SetPixels()?*/
        #endregion

        newTexture.Apply();
        makeSprite();

        worldWidth = spriteRen.bounds.size.x;
        worldHeight = spriteRen.bounds.size.y;
        pixelWidth = spriteRen.sprite.texture.width;
        pixelHeight = spriteRen.sprite.texture.height;

        //Debug.Log("World:" + worldWidth + "," + worldHeight + "Pixel:" + pixelWidth + "," + pixelHeight);

        gameObject.AddComponent<PolygonCollider2D>();
    }


    #region[Drill Destroy]
    
    bool isStartco = false;
    public IEnumerator makeHole_co(BoxCollider2D col)
    {
        isStartco = true;
        //drill.isWork = false;
        Vector2Int colliderCenter = wolrdToPixel(col.bounds.center);
        int radius = Mathf.RoundToInt(col.bounds.size.x / 2 * pixelWidth / worldWidth);
        // Iterate over the pixels inside the collider's shape
        /*        for (int x = colliderCenter.x - radius; x <= colliderCenter.x + radius; x++)
                {
                    for (int y = colliderCenter.y - radius; y <= colliderCenter.y + radius; y++)
                    {
                        // Check if the pixel is within the circular area
                        if (Vector2.Distance(new Vector2(x, y), colliderCenter) <= radius)
                        {
                            // Set the pixel color to Color.clear
                            newTexture.SetPixel(x, y, Color.clear);
                        }
                    }
                }*/

        for (int x = colliderCenter.x - radius; x <= colliderCenter.x; x++)
        {
            for (int y = colliderCenter.y; y > -x + colliderCenter.x + colliderCenter.y - radius; y--)
            {
                newTexture.SetPixel(x, y, Color.clear);
            }
        }

        for (int x = colliderCenter.x; x <= colliderCenter.x + radius; x++)
        {
            for (int y = colliderCenter.y; y > colliderCenter.y + x - colliderCenter.x - radius; y--)
            {
                newTexture.SetPixel(x, y, Color.clear);
            }
        }

        newTexture.Apply();
        makeSprite();
        Destroy(gameObject.GetComponent<PolygonCollider2D>());


        yield return null;

        while (true)
        {
            if(!gameObject.TryGetComponent(out PolygonCollider2D p))
            {
                gameObject.AddComponent<PolygonCollider2D>();
                break;
            }
            yield return null;
        }
        isStartco = false;
    }

    #endregion


    #region[Texture Remove]

    public void makeDot(Vector3 pos)
    {
        Vector2Int pixelPosition = wolrdToPixel(pos);
        
        newTexture.SetPixel(pixelPosition.x, pixelPosition.y, Color.clear);
        newTexture.SetPixel(pixelPosition.x+1, pixelPosition.y, Color.clear);
        newTexture.SetPixel(pixelPosition.x-1, pixelPosition.y, Color.clear);
        newTexture.SetPixel(pixelPosition.x, pixelPosition.y+1, Color.clear);
        newTexture.SetPixel(pixelPosition.x, pixelPosition.y-1, Color.clear);

        newTexture.Apply();
        makeSprite();
    }

    void makeSprite()
    {
        //Sprite.Create 를 써서 텍스처를 0,0부터 텍스처의 넚이와 높이만큼 사각형 Sprite. Pivot: 0.5,0.5
        spriteRen.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.one * 0.5f);
    }

    private Vector2Int wolrdToPixel(Vector3 pos)
    {
        Vector2Int pixelPosition = Vector2Int.zero;

        var dx = pos.x - transform.position.x;
        var dy = pos.y - transform.position.y;

        pixelPosition.x = Mathf.RoundToInt(0.5f * pixelWidth + dx * (pixelWidth / worldWidth));
        pixelPosition.y = Mathf.RoundToInt(0.5f * pixelHeight + dy * (pixelHeight / worldHeight));

        return pixelPosition;
    }

    #endregion
}
