using UnityEngine;

public class Shooting : MonoBehaviour
{

    //[SerializeField] private LayerMask whatIsGrappleable;
    //[SerializeField] private Transform gunTip, player;
    //[SerializeField] private GameObject webPrefab; // Префаб паутины

    //private LineRenderer lineRenderer;
    //private Vector3 grapplePoint;
    //private float maxDistance = 300f;
    //private SpringJoint joint;
    //private GameObject web; // Созданный объект паутины

    //void Awake()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        StartGrapple();
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        StopGrapple();
    //    }
    //}

    //void LateUpdate()
    //{
    //    DrawRope();
    //}

    //void StartGrapple()
    //{
    //    RaycastHit hit;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out hit, maxDistance, whatIsGrappleable))
    //    {
    //        grapplePoint = hit.point;
    //        joint = player.gameObject.AddComponent<SpringJoint>();
    //        joint.autoConfigureConnectedAnchor = false;
    //        joint.connectedAnchor = grapplePoint;

    //        float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

    //        joint.maxDistance = distanceFromPoint * 0f;
    //        joint.minDistance = distanceFromPoint * 0f;

    //        joint.spring = 50f;
    //        joint.damper = 7f;
    //        joint.massScale = 4.5f;
    //        lineRenderer.positionCount = 2;

    //        // Создание объекта паутины и его позиционирование
    //        web = Instantiate(webPrefab, grapplePoint, Quaternion.identity);
    //        web.transform.parent = gunTip;
    //    }
    //}

    //void DrawRope()
    //{
    //    if (!joint) return;

    //    lineRenderer.SetPosition(0, gunTip.position);
    //    lineRenderer.SetPosition(1, web.transform.position); // Используем позицию паутины вместо grapplePoint
    //}

    //void StopGrapple()
    //{
    //    lineRenderer.positionCount = 0;
    //    Destroy(joint);

    //    if (web != null)
    //    {
    //        Destroy(web);
    //        web = null;
    //    }
    //}


    [SerializeField] private LayerMask whatIsGrappleable;
    [SerializeField] private Transform gunTip, player;

    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    private float maxDistance = 300f;
    private SpringJoint joint;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0f;
            joint.minDistance = distanceFromPoint * 0f;

            joint.spring = 50f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
            lineRenderer.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;

        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }



    //public GameObject projectilePrefab;
    //public Transform shootPoint;
    //public float projectileSpeed = 10f;

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector3 mousePosition = Input.mousePosition;
    //        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            Vector3 targetPosition = hit.point;
    //            Vector3 direction = targetPosition - shootPoint.position;
    //            direction.Normalize();

    //            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
    //            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
    //            projectileRigidbody.velocity = direction * projectileSpeed;
    //        }
    //    }
    //}
}
