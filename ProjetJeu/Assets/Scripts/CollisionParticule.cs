using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticule : MonoBehaviour {

    public GameObject particuleHit;
    public List<ParticleCollisionEvent> collisionEvents;

    private Vector3 pos;

    // Use this for initialization
    void Start () {
        collisionEvents = new List<ParticleCollisionEvent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = gameObject.GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);

        int i = 0;

        while (i < numCollisionEvents)
        {
            pos = collisionEvents[i].intersection;
            i++;
        }

        var clone = Instantiate(particuleHit);
        clone.transform.position = pos;
        clone.SetActive(true);
        StartCoroutine(DetruireParticule(clone));
        Destroy(gameObject);
        if (other.gameObject.tag == "ennemi")
        {
            other.gameObject.GetComponent<Ennemis>().Touche();
        }
    }

    IEnumerator DetruireParticule(GameObject particule)
    {
        yield return new WaitForSeconds(1);
        Destroy(particule);
    }
}
