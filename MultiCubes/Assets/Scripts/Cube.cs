using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private ClickHandler _click;

    [Header("Параметры рандома (количество кубов)")]
    [SerializeField] private int _minNumbersOfCubes;
    [SerializeField] private int _maxNumbersOfCubes;

    [SerializeField][Range(1, 100)] private float _precentChanged;
    [SerializeField][Range(1, 100)] private float _maxScale;

    private Vector3 _scale;

    private int _divisor = 2;
    private int _precentRandom = 100;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _meshRenderer.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        _scale = new Vector3(_maxScale, _maxScale, _maxScale);
        transform.localScale = _scale;
    }

    private void OnEnable()
    {
        _click.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _click.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        float randomPrecentValue = GetUserRandom(_precentRandom);

        if (randomPrecentValue <= _precentChanged)
        {
            CreateCubes();
        }

        Destroy(gameObject);
    }

    private int GetUserRandom(int maxRandomValue, int minRandomValue = 0)
    {
        return UnityEngine.Random.Range(minRandomValue, maxRandomValue);
    }

    private void CreateCubes()
    {
        int cubesCount = GetUserRandom(_minNumbersOfCubes, _maxNumbersOfCubes);

        _maxScale /= _divisor;
        Vector3 scaleChildren = Vector3.one * _maxScale;
        _precentChanged /= _divisor;

        for (int i = 0; i < cubesCount; i++)
        {
            GameObject gameObject = Instantiate(this.gameObject);
            gameObject.transform.localScale = scaleChildren;
        }
    }

}
