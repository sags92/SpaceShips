using System.Collections;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject SpawnA;
    [SerializeField] private GameObject SpawnB;
    public float shootingForce;
    private GameObject newBullet;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            newBullet = Instantiate(bullet, SpawnA.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(SpawnA.transform.up.normalized * shootingForce);
            StartCoroutine(DestroyBullet(newBullet));
            newBullet = Instantiate(bullet, SpawnB.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(SpawnB.transform.up.normalized * shootingForce);
            StartCoroutine(DestroyBullet(newBullet));
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3);
        Destroy(bullet);
    }
}