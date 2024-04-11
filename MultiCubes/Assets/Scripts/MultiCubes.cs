using UnityEngine;
//using Random = System.Random;

[RequireComponent(typeof(Rigidbody))]
public class MultiCubes : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;

    [Header("Параметры рандома (количество кубов)")]
    [SerializeField] private int _minNumbersOfCubes;
    [SerializeField] private int _maxNumbersOfCubes;

    [SerializeField] private float _maxScale;

    private Vector3 _scale;
    private Vector3 _startPosition = new Vector3(5, 5, 5);

    private int _divisor = 2;

    private Rigidbody _rigidbody;
    //private Random _random;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _scale = new Vector3(_maxScale, _maxScale, _maxScale);
        transform.localScale = _scale;
        _maxNumbersOfCubes++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CreateCube();
    }
    private int GetUserRandom(int maxRandomValue, int minRandomValue = 0)
    {
        return Random.Range(minRandomValue, maxRandomValue);
        //return _random.Next(minRandomValue, maxRandomValue);
    }

    private void CreateCube()
    {
        int cubesCount = GetUserRandom(_minNumbersOfCubes, _maxNumbersOfCubes);

        Vector3 newScale = _scale / _divisor;
        transform.localScale = newScale;

        Destroy(this.gameObject);

        for (int i = 0; i < cubesCount; i++)
        {
            Instantiate(_prefabCube, _startPosition, Quaternion.identity);
            _rigidbody.AddForce(_startPosition, ForceMode.Impulse);
        }
    }

}
