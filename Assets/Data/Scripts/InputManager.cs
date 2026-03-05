using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    [SerializeField] protected float onVertical;
    public float OnVertical { get => onVertical; }

    [SerializeField] protected float onHorizontal;
    public float OnHorizontal { get => onHorizontal; }

    [SerializeField] protected bool onSpaceDown;
    public bool OnSpaceDown { get => onSpaceDown; }
    private Camera mainCamera;
    void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    void Start()
    {
        // L?y Camera main m?t l?n duy nh?t lúc b?t ??u
        mainCamera = Camera.main;
    }
    void Update()
    {
        this.GetMouseDown();
        GetHorizontal();
        GetVertical();
        GetSpaceDown();
        this.GetMousePos();

    }


    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetHorizontal()
    {
        this.onHorizontal = Input.GetAxis("Horizontal");
    }
    protected virtual void GetVertical()
    {
        this.onVertical = Input.GetAxis("Vertical");
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    protected virtual void GetSpaceDown()
    {
        this.onSpaceDown = Input.GetKeyDown(KeyCode.Space);
    }
}
