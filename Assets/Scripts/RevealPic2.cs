using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealPic2 : MonoBehaviour
{
    public Transform cardPiece;
    public Material cardMaterial;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        cardPiece = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (cardPiece.localScale.x <= 4)
        {
            float percentage = cardPiece.localScale.x / 4;
            float newX = cardPiece.localScale.x + speed + Time.deltaTime;
            float newZ = newX;
            cardPiece.localScale = new Vector3(newX, cardPiece.localScale.y, newZ);

            cardMaterial.SetTextureScale("_MainTex", new Vector2(percentage, percentage));
            cardMaterial.SetTextureOffset("_MainTex", new Vector2(0.5F * (1 - percentage), 0.5F * (1 - percentage)));
        }
    }
}
