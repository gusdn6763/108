using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class ObjectSlicer : MonoBehaviour
{
    private CapsuleCollider cap;
    public float slicedObjectInitialVelocity = 100;
    public Material slicedMaterial;
    public Transform startSlicingPoint;
    public Transform endSlicingPoint;
    public LayerMask sliceableLayer;
    public VelocityEstimator velocityEstimator;
    public AudioSource audioss;

    // Start is called before the first frame update
    private void Awake()
    {
        cap = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        RaycastHit hit2;
        Vector3 slicingDirection = endSlicingPoint.position - startSlicingPoint.position;

        bool hasHitSlime = Physics.Raycast(startSlicingPoint.position, slicingDirection, out hit, slicingDirection.magnitude, 1 << 3);
        if (hasHitSlime)
        {
            Slice(hit.transform.gameObject, hit.point, velocityEstimator.GetVelocityEstimate());
        }
        bool hasHit = Physics.Raycast(startSlicingPoint.position, slicingDirection, out hit2, slicingDirection.magnitude, 1 << 6);
        if (hasHit)
        {
            SlicePeople(hit2.transform.gameObject, hit2.point, velocityEstimator.GetVelocityEstimate());      
        }
    }

    void Slice(GameObject target, Vector3 planePosition, Vector3 slicerVelocity)
    {
        Debug.Log("WE SLICE THE OBJECT");
        Vector3 slicingDirection = endSlicingPoint.position - startSlicingPoint.position;
        Vector3 planeNormal = Vector3.Cross(slicerVelocity, slicingDirection);

        SlicedHull hull = target.Slice(planePosition, planeNormal, slicedMaterial);
        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, slicedMaterial);
            GameObject lowerHull = hull.CreateLowerHull(target, slicedMaterial);

            CreateSlicedComponent(upperHull);
            CreateSlicedComponent(lowerHull);

            Destroy(target);
        }


    }

    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private Transform[] spawnPoint2;
    [SerializeField] private SlimeController slime;
    [SerializeField] private SlimeController slime2;
    // Start is called before the first frame update
    private bool check = false;

    void SlicePeople(GameObject target, Vector3 planePosition, Vector3 slicerVelocity)
    {
        audioss.Play();
        Debug.Log("WE SLICE THE OBJECT");
        Vector3 slicingDirection = endSlicingPoint.position - startSlicingPoint.position;
        Vector3 planeNormal = Vector3.Cross(slicerVelocity, slicingDirection);

        SlicedHull hull = target.Slice(planePosition, planeNormal, slicedMaterial);
        if(hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, slicedMaterial);
            GameObject lowerHull = hull.CreateLowerHull(target, slicedMaterial);

            CreateSlicedComponent(upperHull);
            CreateSlicedComponent(lowerHull);

            Destroy(target);
        }
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(slime, spawnPoint[i].position, spawnPoint[i].rotation).GetComponent<SlimeController>();
        }
        for (int i = 0; i < spawnPoint2.Length; i++)
        {
            Instantiate(slime2, spawnPoint2[i].position, spawnPoint2[i].rotation).GetComponent<SlimeController>();
        }
        Player.instance.moveImpossible = false;

    }

    void CreateSlicedComponent(GameObject slicedHull)
    {
        Rigidbody rb = slicedHull.AddComponent<Rigidbody>();
        MeshCollider collider = slicedHull.AddComponent<MeshCollider>();
        collider.convex = true;

        rb.AddExplosionForce(slicedObjectInitialVelocity, slicedHull.transform.position, 1);
    }
    [SerializeField] private LightSaber save;
    private void OnTriggerEnter(Collider other)
    {
        if (!save.isOn)
        {
            if (other.CompareTag("ErrorSlime"))
            {
                other.GetComponent<SlimeController>().Show();
            }
            
        }
    }
}
