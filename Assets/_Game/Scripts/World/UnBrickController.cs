using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrickController : MonoBehaviour
{
    [SerializeField] GameObject UnBrick;
    private Renderer unBrickRenderer;
    private Color updateColor;
    private Transform unBrickTrans;

    private void Awake() {
        UnBrick.AddComponent<Renderer>();
        unBrickRenderer = UnBrick.GetComponent<Renderer>();
    }
    private void Start() {
         unBrickRenderer = UnBrick.GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.C))
        // {
        //     ChangeColor();
        // }
    }

    public void ChangeColor()
    {
        updateColor = Color.yellow;
        unBrickRenderer.material.SetColor("_Color", updateColor);

    }

    public void ChangPosition()
    {
        Vector3 pos= unBrickTrans.position;
        pos.y += 0.5f;
        unBrickTrans.position= pos;

    }
}
