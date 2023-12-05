using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed = 30f;
    [SerializeField] private GameObject missle;

    /*
    [NonSerialized] public Vector3 position;
    */

    public Vector3 Position { get; set; }

    private void Update()
    {
        
        // Обеспечивает плавное передвижение
        var step = speed * Time.deltaTime;
        // Передвижение снаряда от одной точки к другой со скоростью step
        transform.position = Vector3.MoveTowards(transform.position, Position, step);
        // Уничтожение снаряда по достижении цели
        if (transform.position == Position) Destroy(gameObject);
    }
    
    /*// Запуск одного снаряда в сторону врага
    public void FireToEnemy(Vector3 enemyPosition)
    { // Место создания объекта, помещение в obj
        GameObject obj = Instantiate(missle, transform.GetChild(0).position, Quaternion.identity);
        // Снаряд летит в врага (надо прямо)
        obj.GetComponent<MissileController>().Position = enemyPosition;
    }*/
    
    // Запуск одного снаряда
    public void Fire()
    { // Место создания объекта, помещение в obj
        GameObject obj = Instantiate(missle, transform.GetChild(0).position, Quaternion.identity);
        
    }

}