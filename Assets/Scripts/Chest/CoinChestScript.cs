using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChestScript : MonoBehaviour
{
    public PlayerControl player;
    public float lerp = 10f;
    public SphereCollider colliderSphere;
    private bool chaseActive = false;

    public void Start()
    {
        if(colliderSphere != null)
        colliderSphere.enabled = (false);
    }

    public void PlayerChase(PlayerControl p)
    {
        player = p;
        colliderSphere.enabled = (true);
        chaseActive = true;
    }


    [NaughtyAttributes.Button]
    public void DropAddForce()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 força = new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f)); 
        rb.AddForce(força, ForceMode.Impulse);

    }


    private void Update()
    {
        if (chaseActive)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, lerp * Time.deltaTime);
        }
    }
}
