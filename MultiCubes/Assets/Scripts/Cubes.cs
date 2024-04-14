using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cubes : MonoBehaviour
{
    [SerializeField] private ClickHandler _click;

    [SerializeField] private GameObject _prefabCube;

    [Header("Параметры рандома (количество кубов)")]
    [SerializeField] private int _minNumbersOfCubes;
    [SerializeField] private int _maxNumbersOfCubes;

    [SerializeField][Range(1, 100)] private float _maxScale;

    private Vector3 _scale;

    private GameObject _gameObject;
    private LocalVariables _precentChance;

    private int _divisor = 2;
    private int _precentRandom = 100;
    private float _precentChanged;

    private Rigidbody _rigidbody;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag(nameof(LocalVariables));

        _rigidbody = GetComponent<Rigidbody>();
        _precentChance = _gameObject.GetComponent<LocalVariables>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _meshRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        _scale = new Vector3(_maxScale, _maxScale, _maxScale);
        transform.localScale = _scale;
    }

    private void OnEnable()
    {
        _click.Click += Clicked;
    }

    private void OnDisable()
    {
        _click.Click -= Clicked;
    }

    private void Clicked()
    {
        float randomPrecentValue = GetUserRandom(_precentRandom);
        _precentChanged = _precentChance.GetPrecent();

        if (randomPrecentValue <= _precentChanged)
        {
            CreateCube();
        }

        Destroy(gameObject);
    }

    private int GetUserRandom(int maxRandomValue, int minRandomValue = 0)
    {
        return Random.Range(minRandomValue, maxRandomValue);
    }

    private void CreateCube()
    {
        int cubesCount = GetUserRandom(_minNumbersOfCubes, _maxNumbersOfCubes);

        _maxScale /= _divisor;
        _scale = new Vector3(_maxScale, _maxScale, _maxScale);

        for (int i = 0; i < cubesCount; i++)
        {
            _prefabCube.transform.localScale = _scale;

            Instantiate(_prefabCube, transform.position, Quaternion.identity);
        }
    }

}
