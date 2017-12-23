using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour {

       
        
        private GameObject G;
        private Rigidbody rb;
        private CapsuleCollider c;
        private AudioSource ad;

        void OnTriggerEnter(Collider other)
        {
                if(other.gameObject.CompareTag("Untagged"))
                { }
                        else if (other.gameObject.CompareTag(Queues.PlayerController.G.tag))
                        {
                                print("curr tag" + Queues.PlayerController.G.tag);
                                Queues.PlayerController.score += 1;
                                print("score : "+Queues.PlayerController.score.ToString());
                                Queues.PlayerController.CollisionFlag = 1;
                                Vector3 position = transform.position;
                                Queues.PlayerController.currentPosition = position;
                                Destroy(other.gameObject);
                                Destroy(gameObject);


                        }
                else
                {
                        
                        SceneManager.LoadScene("game_over_scene");
                }
                        
                        
                
        }
}
