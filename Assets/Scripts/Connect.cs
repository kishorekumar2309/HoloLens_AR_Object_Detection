using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.VR.WSA.WebCam;
using UnityEngine.Windows;
//using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class Connect : MonoBehaviour {

    public Text Attribute1;
    public GameObject datareceive;
    public Text Attribute2;
    public Text Attribute3;
    public Text Attribute4;
    public Text nameString;
    //public Text errorField;
    IEnumerator coroutine;
    public string webURL = "http://10.50.0.73:8080/jdbc/webapi/messages";

   // Texture2D targetTexture = null;
    PhotoCapture photoCaptureObject = null;
    
	// Use this for initialization
	void Start () {
        datareceive.SetActive(false);
        //errorField.text = "Deploy Started";
        StartCoroutine("coroLoop");
        //Application.OpenURL("http://10.50.0.73:8080/object/webapi/messages");
	}
    IEnumerator coroLoop()
    {
        int waitTime = 3;
        //errorField.text = "reached first coroLoop";
        while(true)
        {
            //GetPictures();
            GetData();
            yield return new WaitForSeconds(waitTime);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetData()
    {
        //errorField.text = "reached getData";
        //LoadJSON();
        coroutine = Data();
        StartCoroutine(coroutine);

    }
    
    IEnumerator Data()
    {
        //errorField.text = "reached Data coroutine";
        WWW webConnect = new WWW("http://10.50.0.73:8888/");
        yield return webConnect;
        //errorField.text = "returned web value";
       /* if(true)
        {
            connection.text = "Connected";
        }*/
        var readJSON = webConnect.text;
        var JSONObject = JsonUtility.FromJson<JSONScripting>(readJSON);
        
        
        datareceive.SetActive(true);
       // errorField.text = "JSON done";
        nameString.text = JSONObject.name;
        Attribute1.text = JSONObject.attribute1;
        Attribute2.text = JSONObject.attribute2;
        Attribute3.text = JSONObject.attribute3;
        Attribute4.text = JSONObject.attribute4;

    }
}
