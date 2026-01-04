using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PuffEffect : MonoBehaviour, IPoolable
{
    [SerializeField] private float lifeTime = 0.4f;
    [SerializeField] private float startScale = 0.3f;
    [SerializeField] private float endScale = 1.2f;

    private SpriteRenderer sr;
    private float timer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnSpawn()
    {
        timer = 0f;
        transform.localScale = Vector3.one * startScale;
        sr.color = Color.white;
    }

    public void OnDespawn() { }

    private void Update()
    {
        timer += Time.deltaTime;
        float t = timer / lifeTime;

        // Scale puff
        transform.localScale = Vector3.Lerp(
            Vector3.one * startScale,
            Vector3.one * endScale,
            t
        );

        // Fade out
        sr.color = new Color(1, 1, 1, 1 - t);

        if (timer >= lifeTime)
        {
            // PuffFactory.Release(this);
        }
    }
}
