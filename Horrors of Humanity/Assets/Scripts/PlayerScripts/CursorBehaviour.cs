using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CursorBehaviour : MonoBehaviour
{
    public static CursorBehaviour instance { get; set; }

    public Texture2D defaultCursor; // default cursor
    public Texture2D clickedCursor; // texture for when cursor has been clicked
    public Texture2D overClickableCursor; // texture for when cursor is over sth clickable
    public Texture2D defaultPencilCursor; // used in menus & drawing
    public Texture2D hoverPencilCursor;
    public Texture2D downArrowCursor;
    public Texture2D upArrowCursor;
    public Texture2D rightArrowCursor;
    public Texture2D leftArrowCursor;
    public Texture2D cloudCursor;
    public Texture2D checkCursor;

    PlayerInput cursorControls;
    public bool isHovering = false;
    Camera mainCam;
    public bool isPencilTime;

    public List<Texture2D> handIdle;
    public List<Texture2D> clicked;

    [SerializeField] protected int lastClickedFrame;
    protected int frame;
    public float frameRate;
    protected float idleTime;

    bool startTimer;

    private void Awake()
    {
        cursorControls = new PlayerInput();
        ChangeCursor(defaultCursor);
        isHovering = false;
        Cursor.lockState = CursorLockMode.Confined; // confining cursor to game screen
        mainCam = Camera.main; // referencing main cam

        Cursor.visible = true;
        startTimer = false;

        //we first declare the singleton
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }
    public void Start()
    {
        cursorControls.Gameplay.Click.started += _ => StartedClick(); // when we've started clicking, call StartedClick()
        cursorControls.Gameplay.Click.performed += _ => EndedClick(); // when we're done clicking, call EndedClick()
    }

    void StartedClick()
    {
        

        if(isPencilTime)
        {
            ChangeCursor(hoverPencilCursor);
        }
        else
        {
            ChangeCursor(clickedCursor);
            startTimer = true;
        }
        // start timer
        /*do
        {
            animationTimer++;
            ChangeCursor(clicked[animationTimer]);
            Debug.Log($"Looping through clicked animation");
        }
        while (animationTimer < 7);*/

        /*while(animationTimer > 9)
        {
            animationTimer++;
            ChangeCursor(clicked[animationTimer]);
            Debug.Log($"Looping through clicked animation");
        }*/
    }

    private void Update()
    {
        if(startTimer)
        { 
            if (clicked[frame] != clicked[lastClickedFrame]) //if last frame hasnt been reached yet, cycle through the animation
            {
                float playTime = Time.time - idleTime; //time since started moving
                int totalFrames = (int)(playTime * frameRate); //total frames since started moving
                frame = totalFrames % clicked.Count; //current frame

                Debug.Log($"Counting for frames {clicked[frame]}");
                ChangeCursor(clicked[frame]);
            }
            else // if last frame has been reached
            {
                EndedClick();
                startTimer = false;
            }
        }
    }
    
    void EndedClick()
    {
        if (isHovering)
        {
            if(isPencilTime)
            {
                ChangeCursor(hoverPencilCursor);
            }
            else
            {
                ChangeCursor(overClickableCursor);
            }
        }
        else
        {
            if (isPencilTime)
            {
                ChangeCursor(defaultPencilCursor);
                DetectObject();
            }
            else
            {
                ChangeCursor(defaultCursor);
                DetectObject();
            }
        }
    }   

    void DetectObject()
    {
        Ray ray = mainCam.ScreenPointToRay(cursorControls.Gameplay.MousePosition.ReadValue<Vector2>()); // creating ray from camera to a position
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if(hit2D.collider != null) // if raycast hits something, do...
        {
            IClicked click = hit2D.collider.GetComponent<IClicked>(); // getting IClicked class of hit gameobject
            if(click != null) // calling OnClick()
            {
                click.OnClick();
                Debug.Log($"click.OnClick() from cursor behaviour");
            }
            Debug.Log($"Raycast hit {hit2D.collider.tag}");
        }
    }

    public void MouseEnterHover()
    {
        if (isPencilTime)
        {
            ChangeCursor(hoverPencilCursor);
            isHovering = true;
        }
        else
        {
            ChangeCursor(overClickableCursor);
            isHovering = true;
        }
    }
    public void MouseExitHover()
    {
        if (isPencilTime)
        {
            ChangeCursor(defaultPencilCursor);
            isHovering = false;
        }
        else
        {
            ChangeCursor(defaultCursor);
            isHovering = false;
        }
    }
    public void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto); // Vector2.zero is "hotspot" or place on cursor where clicking is checked, CursorMode.Auto chooses to run cursor through hardware or software
    }

    public void ChangeToUpArrow()
    {
        ChangeCursor(upArrowCursor);
    }
    public void ChangeToDownArrow()
    {
        ChangeCursor(downArrowCursor);
    }
    public void ChangeToRightArrow()
    {
        ChangeCursor(rightArrowCursor);
    }
    public void ChangeToLeftArrow()
    {
        ChangeCursor(leftArrowCursor);
    }
    public void ChangeToCheckCursor()
    {
        ChangeCursor(checkCursor);
    }
    public void ChangeToCloudCursor()
    {
        ChangeCursor(cloudCursor);
    }
    private void OnEnable()
    {
        cursorControls.Enable();
    }

    private void OnDisable()
    {
        cursorControls.Disable();
    }
}
