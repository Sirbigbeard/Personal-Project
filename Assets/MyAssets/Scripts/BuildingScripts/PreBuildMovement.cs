using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreBuildMovement : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    public GameObject buildingBuffer;
    public Camera mainCamera;
    public LayerMask groundLayerMask;
    public LayerMask buildingBufferLM;
    private Material mat1;
    private Material mat2;
    private Material mat3;
    private Material mat4;
    private Material mat5;
    private bool built = false;
    private Vector3 mouseZPosition;
    private Vector3 mouseXPosition;
    public bool mouseXPositionChecked;
    public bool mouseZPositionChecked;
    public GameObject rangeFinder;
    void Start()
    {
        mainCamera = Camera.main;
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        groundLayerMask = LayerMask.GetMask("Ground");
        buildingBufferLM = LayerMask.GetMask("Building");
        //opacity to 50%
        /*SetOpacity(mat1, .5f);
        if (mat2 != null)
        {
            SetOpacity(mat2, .5f);
            if (mat3 != null)
            {
                SetOpacity(mat3, .5f);
                if (mat4 != null)
                {
                    SetOpacity(mat4, .5f);
                    if (mat5 != null)
                    {
                        SetOpacity(mat5, .5f);
                    }
                }
            }
        }*/
    }
    void Update()
    {
        if(gameManagerScript.currentBuilding == gameObject)
        {
            //Debug.Log("should be moving");
            //mainCamera.screenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit buildingRaycastHit, float.MaxValue, buildingBufferLM))
            {
                /*if (gameManagerScript.currentBuildingScript.verticalPositiveCollision)
                {
                    if (!mouseZPositionChecked)
                    {
                        mouseZPosition = Input.mousePosition;
                        mouseZPositionChecked = true;
                    }
                    if(Input.mousePosition.z < mouseZPosition.z)
                    {
                        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit groundRaycastHit, float.MaxValue, groundLayerMask))
                        {
                            transform.position = groundRaycastHit.point;
                        }
                    }
                    else
                    {
                        transform.position = new Vector3(buildingRaycastHit.point.x, transform.position.y, transform.position.z);
                    }
                }
                if (gameManagerScript.currentBuildingScript.verticalNegativeCollision)
                {
                    if (!mouseZPositionChecked)
                    {
                        mouseZPosition = Input.mousePosition;
                        mouseZPositionChecked = true;
                    }
                    if (Input.mousePosition.z > mouseZPosition.z)
                    {
                        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit groundRaycastHit, float.MaxValue, groundLayerMask))
                        {
                            transform.position = groundRaycastHit.point;
                        }
                    }
                    else
                    {
                        transform.position = new Vector3(buildingRaycastHit.point.x, transform.position.y, transform.position.z);
                    }
                }
                if (gameManagerScript.currentBuildingScript.horizontalPositiveCollision)
                {
                    if (!mouseXPositionChecked)
                    {
                        mouseXPosition = Input.mousePosition;
                        mouseXPositionChecked = true;
                    }
                    if (Input.mousePosition.x < mouseXPosition.x)
                    {
                        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit groundRaycastHit, float.MaxValue, groundLayerMask))
                        {
                            transform.position = groundRaycastHit.point;
                        }
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, buildingRaycastHit.point.z);
                    }
                }
                if (gameManagerScript.currentBuildingScript.horizontalNegativeCollision)
                {
                    if (!mouseXPositionChecked)
                    {
                        mouseXPosition = Input.mousePosition;
                        mouseXPositionChecked = true;
                    }
                    if (Input.mousePosition.x > mouseXPosition.x)
                    {
                        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit groundRaycastHit, float.MaxValue, groundLayerMask))
                        {
                            transform.position = groundRaycastHit.point;
                        }
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, buildingRaycastHit.point.z);
                    }
                }
                else if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit groundRaycastHit, float.MaxValue, groundLayerMask))
                {
                    transform.position = groundRaycastHit.point;
                }*/
            }
            else if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit groundRaycastHit, float.MaxValue, groundLayerMask))
            {
                transform.position = groundRaycastHit.point;
            }
            if (!built && Input.GetMouseButtonDown(0))
            {
                //opacity to 100%
                built = true;
                gameManagerScript.currentBuildingScript.startPosition = gameManagerScript.currentBuildingScript.transform.position;
                gameManagerScript.GainGold(-gameManagerScript.currentBuildingCost);
                gameManagerScript.alliesRemaining++;
                if(rangeFinder != null)
                {
                    rangeFinder.GetComponent<MeshRenderer>().enabled = false;
                }
                buildingBuffer.SetActive(true);
                gameManagerScript.creationCamera.enabled = false;
                gameManagerScript.constructing = false;
                gameManagerScript.currentBuilding = null;
            }
            if (!built && Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
                gameManagerScript.creationCamera.enabled = false;
                gameManagerScript.constructing = false;
                gameManagerScript.currentBuilding = null;
            }
        }
    }
    void SetOpacity(Material mat, float opacity)
    {
        mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, opacity));
    }
}
