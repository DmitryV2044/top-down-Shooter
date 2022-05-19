
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask whatIsSolid;

    public int damage;

    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
    }
    private void OnDisable()
    {
        this.StopCoroutine("LifeRoutine");
    }
    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(this.lifetime);
        this.Deactivate();
    }
    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    private void OnShot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, this.distance, this.whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Deactivate();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
