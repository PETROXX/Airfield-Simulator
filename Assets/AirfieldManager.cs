using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirfieldManager : MonoBehaviour
{
    [SerializeField] private int _ringsAmount;
    [SerializeField] private GameObject _ringPrefab;


    private Route[] _routes;

    private void Start()
    {
        _routes = FindObjectsOfType<Route>();

        for (int i = 0; i < _ringsAmount; i++)
        {
            Instantiate(_ringPrefab, GetRandomPosOnCurve(), Quaternion.identity);
        }
    }

    private Vector2 GetRandomPosOnCurve()
    {
        float t = Random.Range(0f, 1f);
        int routeNumber = Random.Range(0, _routes.Length);

        Vector2[] controlPoints = new Vector2[4];

        for (int i = 0; i < controlPoints.Length; i++)
        {
            controlPoints[i] = _routes[routeNumber].ControlPoints[i].position;
        }

        Vector2 pos = Mathf.Pow(1 - t, 3) * controlPoints[0] +
    3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1] +
    3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2] +
    Mathf.Pow(t, 3) * controlPoints[3];

        return pos;
    }
}
