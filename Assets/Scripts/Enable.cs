using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Transform[] points;
    private bool oneCheck = false;
    public float speed = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (oneCheck == false)
            {
                oneCheck = true;
                Player.instance.moveImpossible = true;
                StartCoroutine(PlayerMove());
            }
            mesh.enabled = true;
        }
    }

    public IEnumerator PlayerMove()
    {
        int i = 0;
        while (Player.instance.moveImpossible && points.Length != i)
        {
            Player.instance.transform.position = Vector3.MoveTowards(Player.instance.transform.position, points[i].position, speed * Time.deltaTime);
            if (Vector3.Distance(Player.instance.transform.position, points[i].position) <= 1f)
            {
                i++;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
