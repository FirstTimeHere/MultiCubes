using UnityEngine;

public class LocalVariables : MonoBehaviour
{
    private float _precent = 100f;
    private int _divisor = 2;

    public float GetPrecent()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        _precent /= _divisor;
        
        return _precent;
    }
}
