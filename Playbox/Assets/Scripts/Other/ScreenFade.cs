/*
*   Julien Lynge's fade code
*   10/27/14
*
*   Good example of how to do a screen fade.
*
*/

using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour 
{
    //The amount between 0 and 1 that we're currently faded
    private float amount;
    //The texture we're overlaying on the screen to do the fade
    private Texture2D texture;

    //Our singleton instance
    private static ScreenFade instance = null;
    private static ScreenFade Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject("Screen Fade", typeof(ScreenFade)).GetComponent<ScreenFade>();
            return instance;
        }
    }

    //When the singleton is created, do some setup
    void Start()
    {
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
        DontDestroyOnLoad(gameObject);
    }

    //The static method we can call to set up the instance and perform the fade
    public static void Fade(int toLevel)
    {
        Instance.StartCoroutine(Instance.performFade(toLevel));
    }

    //The coroutine that performs the fade
    private IEnumerator performFade(int level)
    {
        float time = Time.time;
        
        //fade to black
        while ((amount = Time.time - time) < 1f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.25f);
        Application.LoadLevel(level);

        time = Time.time;
        //fade from black
        while ((amount = 1f - (Time.time - time)) > 0f)
        {
            yield return null;
        }
        Destroy(Instance.gameObject);
    }

    //The Unity event that we tap into to show the fade texture
    void OnGUI()
    {
        GUI.color = new Color(0f, 0f, 0f, amount);
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), texture);
    }
}