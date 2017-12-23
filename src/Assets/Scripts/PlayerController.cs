using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Queues
{
        
        public class PlayerController : MonoBehaviour
        {
                public static Queue x=HurdleRenderer.randomindexQueue;
                public Text CountText;
                //public float speed;
                public static GameObject G;
                public static int score = 0;
                public static int CollisionFlag = 0;
                public static Vector3 currentPosition;

                //public static Text endText;

                public int index = 1;

                public GameObject[] Blocks;
                private float speed = 400;
                private Rigidbody rb;
                private CapsuleCollider c;
                private AudioSource ad;
                void Start()
                {
                        ad = GetComponent<AudioSource>();
                        ad.Play();
                        CollisionFlag = 0;
                        currentPosition = new Vector3(0.4f, 1.2f, -220);
                        CountText.text = "";
                        Quaternion rotation = Quaternion.Euler(0, 0, 0);

                        /*positions[0] = new Vector3(-10, 1, -200);
                        positions[1] = new Vector3(0.4f, 1, -200);
                        positions[2] = new Vector3(10, 1, -200);*/

                        int randomindex = (int)Random.Range(0, 3);
                        //Vector3 random_index_generator = (Vector3)HurdleRenderer.randomindexQueue.Dequeue();
                        GameObject currentBlock = Blocks[randomindex];

                        G = (GameObject)Instantiate(currentBlock, currentPosition, rotation);
                        rb = G.GetComponent<Rigidbody>();
                        c = G.AddComponent<CapsuleCollider>();
                        c.isTrigger = true;
                        c.radius = (float)3;
                        c.height = 3;
                }
                void Update()
                {
                        
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                                index--;
                                if (index < 0)
                                {
                                        index = 0;
                                }
                                else {
                                        //rb.transform.position = Vector3.MoveTowards(rb.transform.position, positions[index], Time.deltaTime * speed);
                                        Vector3 new_position = new Vector3(rb.transform.position[0] - 10, rb.transform.position[1], rb.transform.position[2]);
                                        rb.transform.position = new_position;
                                        currentPosition = new_position;
                                }
                        }
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                                index++;
                                if (index >= 3)
                                {
                                        index = 2;
                                }
                                else
                                {
                                        Vector3 new_position = new Vector3(rb.transform.position[0] + 10, rb.transform.position[1], rb.transform.position[2]);
                                        rb.transform.position = new_position;
                                        currentPosition = new_position;
                                }
                        }
                        if (CollisionFlag == 1)
                        {
                                int mNo = 0;
                                int[] arr = new int[3]; 
                                if (x.Count != 0)
                                {
                                        Vector3 z = (Vector3)x.Dequeue();
                                         
                                        arr[0] = (int)z.x;
                                        arr[1] = (int) z.y;
                                        arr[2] = (int)z.z;
                                        print("player : "+arr[0].ToString()+ arr[1].ToString()+ arr[2].ToString());
                                         mNo= (int)Random.Range(0, 3);

                                }
                                //int randomindex = (int)Random.Range(0, Blocks.Length);

                                GameObject currentBlock = Blocks[arr[mNo]];
                                CountText.text = "Count: " + score.ToString();

                                //GameObject currentBlock = Blocks[randomindex];
                                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                                G = (GameObject)Instantiate(currentBlock, currentPosition, rotation);
                                print("instantiated player :" +arr[mNo].ToString());
                                rb = G.GetComponent<Rigidbody>();
                              
                                CollisionFlag = 0;
                        }
                }

        }
}