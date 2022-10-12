using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class xu ly player: Move, AddBrick, RemoveBrick
public class Player : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform;
    [SerializeField] GameObject playerModel;
    [SerializeField] float speed;
    private MovePlayer movePlayer;
    private BrickProcess brickProcess;
    private Vector3 dir;
    private Animator ani;
    public float score =0f;
    public bool isWin;
    public EDirection eDirection;
    public bool isPlay= false;
    
    //Get cac component
    private void Awake() 
    {
        movePlayer = GetComponent<MovePlayer>();
        brickProcess = GetComponent<BrickProcess>();
        ani = playerModel.GetComponent<Animator>();
    }

    private void Start() 
    {
        OnInit();
    }
    //Goi cac xu ly logic game
    private void Update() 
    {
        
        if(isPlay && !isWin) //Da an play va chua den dich
        {
            eDirection = MouseInput.Instance.GetEDirection(); //Get huong di chuyen tu mouse
            Vector3 target = movePlayer.GetTargetPosition(eDirection); //Tim diem dich can di chuyen den
            movePlayer.MoveToTargetPosition(target, speed); //Di chuyen den diem dich
        }
        if(isWin) //Neu den diem dich
        {   
            ani.Play(CONST.ANI_WIN); //Thay doi Anin
            LevelManager.Instance.OnFinish(); // Quan ly level show UI Finish
        }
    }

    //Ham khoi tao cac tham so cho Player khi bat dau 1 level
    public void OnInit()
    {
        isPlay= false; 
        isWin = false;
        eDirection= EDirection.None;
        ani.Play(CONST.ANI_IDLE, 0, 0.25f);
    }
}
