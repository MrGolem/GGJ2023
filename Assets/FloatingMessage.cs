using UnityEngine;
using TMPro;
public class FloatingMessage : MonoBehaviour
{
    private Rigidbody2D _rigidbdy;
    private TMP_Text _damageValue;

    public float InitialYVelocity = 7f;
    public float InitialXVelocityRange = 3f;
    public float LifeTime = 1f;

    public float timer;

    private void Awake()
    {
        _rigidbdy = GetComponent<Rigidbody2D>();
        _damageValue = GetComponentInChildren<TMP_Text>();

    }

    private void Start()
    {
        _rigidbdy.velocity = new Vector2(Random.Range(-InitialXVelocityRange, InitialXVelocityRange), InitialYVelocity);
        Destroy(gameObject, LifeTime);

    }
    private void Update()
    {
        //timer -= Time.deltaTime;
        //if (timer <= 0)
        //{
        //    //gameObject.SetActive(false);
        //}
    }

    public void SetMessage(string msg)
    {
        _damageValue.SetText(msg);
    }
}
