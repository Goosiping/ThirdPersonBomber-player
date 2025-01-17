using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject prefab;
    public GameObject bullet;
    LineRenderer lineRenderer;
    public float numPoints = 50.0f;
    public float timeBetweenPoints = 0.1f;
    public float F = 5.0f;
    public LayerMask CollidableLayers;
    Camera mainCamera;
    [SerializeField] Transform landingPos;
    public Animator a;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        mainCamera = Camera.main;
        
        //a = GameObject.Find("./MaleCharacterPolyart").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.state == GameState.Playing)
        {
            Vector2 screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = Camera.main.ScreenPointToRay(screenCentre);
            Vector3 startingPosition = this.transform.position;
            float cam_pitch = mainCamera.transform.rotation.eulerAngles.x;
            float pitch = -40;
            pitch += cam_pitch;
            transform.rotation = mainCamera.transform.rotation;
            transform.Rotate(pitch, 0, 0);

            Vector3 startingVelocity = transform.forward * F;
        
            List<Vector3> points = new List<Vector3>();
            for (float t = 0; t < numPoints; t += timeBetweenPoints){
                Vector3 newPoint = startingPosition + t * startingVelocity;
                newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t; 
                points.Add(newPoint);
                if(Physics.OverlapSphere(newPoint, 0.1f, CollidableLayers).Length > 0){
                    lineRenderer.positionCount = points.Count;
                    landingPos.position = newPoint;
                    break;
                }
            }
            lineRenderer.SetPositions(points.ToArray());

            if(Input.GetMouseButtonDown(0)){
                a.SetBool( "attack", true );
                prefab = Instantiate(bullet, transform.position, Quaternion.identity);
                prefab.GetComponent<Rigidbody>().velocity = startingVelocity;
            }

            else{
                a.SetBool( "attack", false );
            }
        }
        
    }
}
