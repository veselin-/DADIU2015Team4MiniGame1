using UnityEngine;
using System.Collections;

public class TextureAnimation : MonoBehaviour {

    public Texture2D tex1, tex2;

    public float animationTime = 0;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

        animationTime += Time.deltaTime;

        if(animationTime < 3f)
        {
            noThunder();
        }
        else if(animationTime < 3.5f)
        {
            thunder();
        }
        else if(animationTime < 4f)
        {
            noThunder();
        }
        else if(animationTime < 5f)
        {
            thunder();
        }
        else if(animationTime >= 5f)
        {
            animationTime = 0f;
        }

	
	}

    void thunder()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", tex2);
    }

    void noThunder()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", tex1);
    }
}


