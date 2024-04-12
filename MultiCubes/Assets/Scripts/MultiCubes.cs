using System.Collections.Generic;
using UnityEngine;
//using Random = System.Random;

[RequireComponent(typeof(Rigidbody))]
public class MultiCubes : MonoBehaviour
{
    [SerializeField] private InteractionWithObject _clickObject;

    [SerializeField] private GameObject _prefabCube;

    [Header("Параметры рандома (количество кубов)")]
    [SerializeField] private int _minNumbersOfCubes;
    [SerializeField] private int _maxNumbersOfCubes;

    [SerializeField] private float _maxScale;

    private Vector3 _scale;

    private int _divisor = 2;
    private int _precent = 100;

    private List<Color> _colors = new List<Color> 
    {
        Color.red,
        Color.white,
        Color.blue,
        Color.green,
        Color.gray
    };

    private Rigidbody _rigidbody;
    private MeshRenderer _meshRenderer;
    //private Random _random;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _scale = new Vector3(_maxScale, _maxScale, _maxScale);
        transform.localScale = _scale;
        _maxNumbersOfCubes++;
    }

    private void OnEnable()
    {
        _clickObject.ClickedObject += Clicked;
    }

    private void OnDisable()
    {
        _clickObject.ClickedObject -= Clicked;
    }

    private void Clicked()
    {
        int precent = 100;
        int randomPrecentValue = GetUserRandom(precent);

        if (randomPrecentValue >= _precent || precent == _precent)
        {
            CreateCube();
            _precent /= _divisor;
        }

        Destroy(this.gameObject);
    }

    private int GetUserRandom(int maxRandomValue, int minRandomValue = 0)
    {
        return Random.Range(minRandomValue, maxRandomValue);
        //return _random.Next(minRandomValue, maxRandomValue);
    }

    private Color TryGetRandomColor()
    {
        int randomColor = GetUserRandom(_colors.Count);

        return _colors[randomColor];
    }

    private void CreateCube()
    {
        int cubesCount = GetUserRandom(_minNumbersOfCubes, _maxNumbersOfCubes);

        Vector3 newScale = _scale / _divisor;
        transform.localScale = newScale;

        for (int i = 0; i < cubesCount; i++)
        {
            _prefabCube.transform.localScale = newScale;
            Instantiate(_prefabCube, this.gameObject.transform.position, Quaternion.identity);
            _meshRenderer.material.color = TryGetRandomColor();

            _rigidbody.AddForce(this.gameObject.transform.position, ForceMode.Acceleration);
        }
    }

}
