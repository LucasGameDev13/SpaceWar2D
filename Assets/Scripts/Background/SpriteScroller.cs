using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    private Renderer meshRender;
    private Material currentMaterial;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float incrementOffset;
    [SerializeField] private float posX;
    private float offset;

    [SerializeField] private string sortingLayer;
    [SerializeField] private int orderInLayer;

    // Start is called before the first frame update
    void Start()
    {
        //Accessing the components of the meshRender : Sorting in Layer / Order in Layer / Material
        meshRender = GetComponent<Renderer>();
        meshRender.sortingLayerName = sortingLayer;
        meshRender.sortingOrder = orderInLayer;
        currentMaterial = meshRender.material;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }


    //Method to be used as the parallax effect
    private void OnMove()
    {
        
        offset += incrementOffset;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(posX * offset, offset * moveSpeed));
    }
}
