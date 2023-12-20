using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Texture2D imgTex;
    Texture2D newTexture;
    SpriteRenderer spriteRenderer;

    // 월드 좌표에서 픽셀 좌표로 변환하기 위해 스프라이트의 넓이와 높이, 
    // 픽셀 가로세로 갯수(픽셀의 넓이와 높이)
    float worldWidth, worldHeight;
    int pixelWidth, pixelHeight;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //  newTexture = new Texture2D(1920,423);
        newTexture = Instantiate(imgTex);

/*        for (int i = 0; i < newTexture.width; i++)
        {
            for (int j = 0; j < newTexture.height; j++)
            {
                newTexture.SetPixel(i, j, Color.white);
            }
        }

        newTexture = new Texture2D(imgTex.width, imgTex.height);
        Color[] colors = imgTex.GetPixels();
        newTexture.SetPixels(colors);   //SetPixels(colors)?*/

        newTexture.Apply(); // Apply()?
       
        MakeSprite();

        worldWidth = spriteRenderer.bounds.size.x;
        worldHeight = spriteRenderer.bounds.size.y;
        pixelWidth = spriteRenderer.sprite.texture.width;
        pixelHeight = spriteRenderer.sprite.texture.height;

        Debug.Log("World:" + worldWidth + "," + worldHeight + "Pixel:" + pixelWidth + "," + pixelHeight );

        //Sprite 를 만든 후에 Polygon 2D Collider 추가
        gameObject.AddComponent<PolygonCollider2D>();
    }

    public void MakeHole(CircleCollider2D cirCol)
    {
        Vector2Int colliderCenter = worldToPixel(cirCol.bounds.center);     //bounds?
        int radius = Mathf.RoundToInt(cirCol.bounds.size.x / 2 * pixelWidth / worldWidth);

        int px, nx, py, ny, distance;
        for(int i=0; i<radius; i++)
        {
            distance = Mathf.RoundToInt(Mathf.Sqrt(radius * radius - 1 * i));

            for(int j=0; j<distance; j++)
            {
                px = colliderCenter.x + i;
                nx = colliderCenter.x - i;
                py = colliderCenter.y + j;
                ny = colliderCenter.y - j;

                newTexture.SetPixel(px, py, Color.white);
                newTexture.SetPixel(nx, py, Color.white);
                newTexture.SetPixel(px, ny, Color.white);
                newTexture.SetPixel(nx, ny, Color.white);
            }
        }
        newTexture.Apply();
        MakeSprite();

        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<CircleCollider2D>()) return;
        MakeHole(collision.GetComponent<CircleCollider2D>());
    }

    public void MakeDot(Vector3 pos)
    {
        Vector2Int pixelpoistion = worldToPixel(pos);

        newTexture.SetPixel(pixelpoistion.x, pixelpoistion.y, Color.clear);
        newTexture.SetPixel(pixelpoistion.x +1, pixelpoistion.y, Color.clear);
        newTexture.SetPixel(pixelpoistion.x -1, pixelpoistion.y, Color.clear);
        newTexture.SetPixel(pixelpoistion.x, pixelpoistion.y+1, Color.clear);
        newTexture.SetPixel(pixelpoistion.x, pixelpoistion.y-1, Color.clear);

        newTexture.Apply();
        MakeSprite();
        
    }

    
    void MakeSprite()
    {
        spriteRenderer.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.one * 0.5f);
    }

    public Vector2Int worldToPixel(Vector3 pos)
    {
        Vector2Int pixelPosition = Vector2Int.zero;

        var dx = pos.x - transform.position.x;
        var dy = pos.y - transform.position.y;

        pixelPosition.x = Mathf.RoundToInt(0.5f * pixelWidth + dx * (pixelWidth / worldWidth));
        pixelPosition.y = Mathf.RoundToInt(0.5f * pixelWidth + dy * (pixelHeight / worldHeight));

        return pixelPosition;
    }
   
}
