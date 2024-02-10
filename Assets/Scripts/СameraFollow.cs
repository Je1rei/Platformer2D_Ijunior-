using UnityEngine;

public class СameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _movingSpeed;

    private void Awake()
    {
        transform.position = ChangePosition();
    }

    private void Update()
    {
        Vector3 target = ChangePosition();

        Vector3 pos = Vector3.Lerp(transform.position, target, _movingSpeed * Time.deltaTime);

        transform.position = pos;
    }

    private Vector3 ChangePosition()
    {
        float offsetCamera = 10;

        return new Vector3(_player.position.x, _player.position.y, _player.position.z - offsetCamera);
    }
}
