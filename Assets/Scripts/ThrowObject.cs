using UnityEngine;
using UnityEngine.Events;

public class ThrowObject : MonoBehaviour
{
    public UnityEvent OnThrow;
    public UnityEvent OnEmpty;

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _throwForce = 30f;

    private Camera _mainCamera;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _ballPrefab != null)
        {
            Debug.Log("Выстрел");
            Throw(_throwForce);
        }
    }

    public void Throw(float force = 10f)
    {
        if (GameManager.BallCount <= 0)
        {
            OnEmpty.Invoke();
            return;
        }

        // Переводим координаты мыши в мировые координаты
        Ray mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePosition = mouseRay.GetPoint(1f);

        // Рассчитываем направление для броска
        Vector3 throwDirection = (mousePosition - transform.position).normalized;
        // Создаем копию объекта, который бросимё       
        GameObject newBall = Instantiate(_ballPrefab);
        newBall.transform.position = transform.position;

        // Проверяем наличие физики на объекте
        if (newBall.GetComponent<Rigidbody>() != null)
        {
            // Бросаем шар
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            rb.AddForce(throwDirection * force, ForceMode.VelocityChange);
        }

        GameManager.BallCount--;
        OnThrow.Invoke();
    }

    public void ThrowAway(int number = 10, float force = 10f)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject newBall = Instantiate(_ballPrefab);
            newBall.transform.position = transform.position;

            if (newBall.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = newBall.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.forward * force, ForceMode.VelocityChange);
            }
        }

    }
}
