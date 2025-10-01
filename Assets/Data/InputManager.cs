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
    void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    void Update()
    {
        this.GetMouseDown();
        GetHoriontal();
        GetVertical();
    }

    void FixedUpdate()
    {
        this.GetMousePos();

    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetHoriontal()
    {
        this.onHorizontal = Input.GetAxis("Horizontal");
    }
    protected virtual void GetVertical()
    {
        this.onVertical = Input.GetAxis("Vertical");
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
