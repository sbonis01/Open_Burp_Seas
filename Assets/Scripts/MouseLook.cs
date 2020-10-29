using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private int smooth_Steps = 10;

    [SerializeField]
    private float smooth_Weight = .4f;

    [SerializeField]
    private float roll_Angle = 10f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private bool can_Unlock = true;

    [SerializeField]
    private float sensitivity = 5f;

    [SerializeField]
    private Vector2 default_look_limits = new Vector2(-70f, 80f);

    private Vector2 look_angles;

    private Vector2 current_mouse_look;
    private Vector2 smooth_move;

    private float current_Roll_Angle;

    private int last_Look_Frame;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LockAndUnlockCursor();

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            lookAround();
        }
    }

    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    void lookAround()
    {
        current_mouse_look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_angles.x += current_mouse_look.x * sensitivity * (invert ? 1f : -1f);
        look_angles.y += current_mouse_look.y * sensitivity;

        look_angles.x = Mathf.Clamp(look_angles.x, default_look_limits.x, default_look_limits.y);

        current_Roll_Angle =
            Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * roll_Angle, Time.deltaTime * roll_Speed);

        lookRoot.localRotation = Quaternion.Euler(look_angles.x, 0f, current_Roll_Angle);
        playerRoot.localRotation = Quaternion.Euler(0f, look_angles.y, 0f);
    }

    public class MouseAxis
    {
        public const string MOUSE_X = "Mouse X";
        public const string MOUSE_Y = "Mouse Y";

    }
}
