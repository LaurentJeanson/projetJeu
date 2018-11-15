//////////////////////////////////////////
////Philippe Thibeault////////////////////
//Modification de script trouvé sur gamedevelopertips.com/unity-how-fade-between-scenes//
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Valeurs booléennes pour vérifier si la scène charge et si le logo est affiché
    private bool loadScene = false;
    private bool logoAffiche = false;

    [SerializeField]private int scene; //Scène à charger
    [SerializeField]private Text loadingText; //Texte de chargement à afficher
    [SerializeField]private Image text1; //Titre normal
    [SerializeField] private Image text2; //Titre changé
    [SerializeField] private Image logo; //Logo à afficher
    private float loadTime = 5.0f; //Temps de chargement
    private Color couleur; //Couleur pour le texte de chargement

    public RawImage fadeOutUIImage; //
    public float fadeSpeed = 0.8f; //Vitesse du fondu
    public enum fadeDirection //Directions pour le fondu
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }


    // Updates once per frame
    void Update()
    {
        //On affiche le logo et on commence une coroutine pour l'enlever
        InvokeRepeating("AfficherLogo", 0.01f, 0.01f);
        StartCoroutine(EnleverLogo());
        //Si le logo est affiché
        if (logoAffiche == true)
        {
            // Si une scène ne charge pas encore
            if (loadScene == false)
            {

                // On fait charger une scène
                loadScene = true;

                // On affiche un texte de chargement
                loadingText.text = "Loading...";

                // Une coroutine commence le fondu vers la prochaine scène
                StartCoroutine(FadeAndLoadScene(fadeDirection.Out, scene));
            }
            // Si une scène charge déjà
            if (loadScene == true)
            {

                // On fait changer la couleur du texte en pulsations
                loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

                //On remplace graduellement un titre par l'autre
                text1.fillAmount -= 1.0f / loadTime * Time.deltaTime;
                text2.fillAmount += 1.0f / loadTime * Time.deltaTime;
            }
        }
    }

    //Faire afficher le logo avec un effet de fondu
    void AfficherLogo()
    {
        //On stock la couleur du logo
        couleur = logo.color;
        //S'il a de la transparence
        if (couleur.a < 1)
        {
            //On le fait apparaitre plus et on stock à nouveau sa couleur
            couleur.a += 0.001f;
            logo.color = couleur;
        }
        //S'il n'est pas transparent
        if (couleur.a >= 1)
        {
            //On arrête la fonction
            CancelInvoke("AfficherLogo");
        }
    }

    //Enlever le logo de l,affichage
    IEnumerator EnleverLogo()
    {
        yield return new WaitForSeconds(3);
        logoAffiche = true;

        logo.enabled = false;
        loadingText.gameObject.SetActive(true);
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
    }

    //Faire un fondu et ensuite charger la prochaine scène
    public IEnumerator FadeAndLoadScene(fadeDirection fadeDirection, int scene)
    {
        yield return new WaitForSeconds(5f);
        yield return Fade(fadeDirection);
        SceneManager.LoadScene(scene);
    }

    //
    private IEnumerator Fade(fadeDirection fadeDirection)
    {
        //On défini la transparence actuelle et la transparence vers laquelle nous nous dirigeons
        float alpha = (fadeDirection == fadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == fadeDirection.Out) ? 0 : 1;
        //Si c'est un fondu de sortie
        if (fadeDirection == fadeDirection.Out)
        {
            //Pendant que la transparence n'est pas à celle désirée
            while (alpha >= fadeEndValue)
            {
                //Changer la transparence
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        //Sinon, si c'est un fondu d'entrée
        else
        {
            fadeOutUIImage.enabled = true;
            //Pendant que la transparence n'est pas à celle désirée
            while (alpha <= fadeEndValue)
            {
                //Changer la transparence
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }

    //Changer la transparence de l'image affichée
    private void SetColorImage(ref float alpha, fadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        text2.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        loadingText.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == fadeDirection.Out) ? -1 : 1);
    }
}
