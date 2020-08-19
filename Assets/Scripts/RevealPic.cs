using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealPic : MonoBehaviour
{
    public Transform cardPiece;
    public Material cardMaterial;
    public float startLocationX;
    public float startLocationY;

    // Start is called before the first frame update
    void Start()
    {
        startLocationX = cardPiece.position.x;
        startLocationY = cardPiece.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float percentageOfCardX = -(cardPiece.position.x + 1.5F) / 4;
        float percentageOfCardY = (cardPiece.position.y + 1.5F) / 3;
        cardMaterial.SetTextureOffset("_MainTex", new Vector2(percentageOfCardX, percentageOfCardY));
        
    }
}
