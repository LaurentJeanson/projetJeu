//////////////////////////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticule : MonoBehaviour {

    //Particule de touche d'une balle
    public GameObject particuleHit;

    //Evénements de collision d'une particule
    public List<ParticleCollisionEvent> collisionEvents;

    //Stocker une position
    private Vector3 pos;

    // Use this for initialization
    void Start () {
        //Créer une nouvelle liste de collisions
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    //S'il y a une collision d'une particule
    private void OnParticleCollision(GameObject other)
    {
        //Stocker la collision
        int numCollisionEvents = gameObject.GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);

        int i = 0;

        while (i < numCollisionEvents)
        {
            //Stocker le lieu de la collision
            pos = collisionEvents[i].intersection;
            i++;
        }

        //Instantier une particule de contact à l'endroit de la collision et l'activer
        var clone = Instantiate(particuleHit);
        clone.transform.position = pos;
        clone.SetActive(true);

        //Détruire la particule de contact et celle de la balle
        StartCoroutine(DetruireParticule(clone));
        Destroy(gameObject);

        //Si l'objet touché était un ennemi, le détruire aussi
        if (other.gameObject.tag == "ennemi")
        {
            other.gameObject.GetComponent<Ennemis>().Touche();
        }
    }

    //Détruire la particule de collision après 1 seconde
    IEnumerator DetruireParticule(GameObject particule)
    {
        yield return new WaitForSeconds(1);
        Destroy(particule);
    }
}
