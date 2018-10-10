using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    private bool loadScene = false;
    private bool logoAffiche = false;

    [SerializeField]private int scene;
    [SerializeField]private Text loadingText;
    [SerializeField]private Image text1;
    [SerializeField] private Image text2;
    [SerializeField] private Image logo;
    private float loadTime = 5.0f;
    private Color couleur;


    // Updates once per frame
    void Update()
    {
        InvokeRepeating("AfficherLogo", 0.01f, 0.01f);
        StartCoroutine(EnleverLogo());
        if (logoAffiche == true)
        {
            // If the player has pressed the space bar and a new scene is not loading yet...
            if (Input.GetKeyUp(KeyCode.Space) && loadScene == false)
            {

                // ...set the loadScene boolean to true to prevent loading a new scene more than once...
                loadScene = true;

                // ...change the instruction text to read "Loading..."
                loadingText.text = "Loading...";

                // ...and start a coroutine that will load the desired scene.
                StartCoroutine(LoadNewScene());
            }
            // If the new scene has started loading...
            if (loadScene == true)
            {

                // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
                loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

                text1.fillAmount -= 1.0f / loadTime * Time.deltaTime;
                text2.fillAmount += 1.0f / loadTime * Time.deltaTime;
            }
        }
    }

    void AfficherLogo()
    {
        couleur = logo.color;
        print(couleur);
        if (couleur.a < 1)
        {
            couleur.a += 0.001f;
            logo.color = couleur;
        }

        if (couleur.a >= 1)
        {
            CancelInvoke("AfficherLogo");
        }
    }

    IEnumerator EnleverLogo()
    {
        yield return new WaitForSeconds(3);
        logoAffiche = true;

        logo.enabled = false;
        loadingText.gameObject.SetActive(true);
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
    }

    IEnumerator ChangerText()
    {

        yield return null;
    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene()
    {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(6);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = Application.LoadLevelAsync(scene);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }

}
