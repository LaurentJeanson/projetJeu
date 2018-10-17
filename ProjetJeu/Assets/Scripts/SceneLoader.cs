using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public RawImage fadeOutUIImage;
    public float fadeSpeed = 0.8f;
    public enum fadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }


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
                StartCoroutine(FadeAndLoadScene(fadeDirection.Out, scene));
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

    public IEnumerator FadeAndLoadScene(fadeDirection fadeDirection, int scene)
    {
        yield return new WaitForSeconds(5f);
        yield return Fade(fadeDirection);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator Fade(fadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == fadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == fadeDirection.Out) ? 0 : 1;
        if (fadeDirection == fadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }

    private void SetColorImage(ref float alpha, fadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == fadeDirection.Out) ? -1 : 1);
    }
}
