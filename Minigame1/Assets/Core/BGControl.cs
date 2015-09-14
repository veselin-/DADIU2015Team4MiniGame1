using UnityEngine;
using System.Collections;

public class BGControl : MonoBehaviour {

    public GameObject Elephant;

    public static float Speed;

	private float _destination = 0f, edgeValue = 2.9f;
    private bool _movementEnbaled = true;
    public Camera UiCamera;

    // Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (_destination >= Elephant.transform.position.x && _movementEnbaled)
        {
            Elephant.transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        if (_destination < Elephant.transform.position.x && _movementEnbaled)
        {
            Elephant.transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
    }

    void OnMouseDown() {
    Ray ray = UiCamera.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit = new RaycastHit();
    if (Physics.Raycast(ray, out hit, 100))
    {
        _destination = hit.point.x;
            //IM SORRY - I CHEATED A LITLE BIT ---- FOR AW SCREEN ITS 3.74158 / -3.752747
            if (edgeValue < _destination)
            {
                _destination = edgeValue;
            }
            if (-edgeValue > _destination)
            {
                _destination = -edgeValue;
            }
        }     
    }

    public void DisableMovement()
    {
        _movementEnbaled = false;
    }

    public void EnableMovement()
    {
        _movementEnbaled = true;
    }

}
