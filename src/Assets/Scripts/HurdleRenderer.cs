using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
        public class HurdleRenderer : MonoBehaviour
        {

                public static Queue randomindexQueue = new Queue();
                
                public float speed;
                public float spawnWait;
                public float startWait;
                private Rigidbody rb1;
                private Rigidbody rb2;
                private Rigidbody rb3;
                //public float waveWait;
                public GameObject[] Blocks;
                void Start()
                {
                        StartCoroutine(SpawnWaves());
                        
                }

                IEnumerator SpawnWaves()
                {
                        yield return new WaitForSeconds(startWait);
                        int i = 0;
                        int random_index1, random_index2, random_index3;
                        while (true)
                        {
                                double[] position_x = { -10, -10, -10, -10, -10, -10, -10, -10, -10 };
                                double[] position_y = { 1.2, 1.2, 1.75, 1.82, 2.02, 1.79, 1.5, 1.2, 1.65 };
                                double[] scale_x = { 1.8, 1.6, 1.2, 1.2, 1, 1.4, 1, 1.8, 1.8 };
                                double[] scale_y = { 1.8, 1.6, 1, 1.2, 0.8, 1.4, 1, 2, 1.8 };

                                if (i != 0)
                                {
                                        random_index1 = (int)Random.Range(0, Blocks.Length);
                                        random_index2 = (int)Random.Range(0, Blocks.Length);
                                        random_index3 = (int)Random.Range(0, Blocks.Length);
                                        print("hurdle : "+ random_index1.ToString()+ random_index2.ToString() + random_index3.ToString());
                                        Vector3 random_index_entry = new Vector3(random_index1, random_index2, random_index3);
                                        randomindexQueue.Enqueue(random_index_entry);
                                }
                                else
                                {
                                        random_index1 = 0;
                                        random_index2 = 1;
                                        random_index3 = 2;
                                }
                                
                              
                                Vector3 position1 = new Vector3((float)position_x[random_index1], (float)position_y[random_index1], 0);
                                Vector3 scale1 = new Vector3((float)scale_x[random_index1], (float)scale_y[random_index1], 1);
                                GameObject block1 = (GameObject)Blocks[random_index1];
                                GameObject newblock1 = (GameObject)Instantiate(block1, position1, transform.rotation);
                                newblock1.transform.localScale = scale1;


                                Vector3 position2 = new Vector3((float)position_x[random_index2] + 10, (float)position_y[random_index2], 0);
                                Vector3 scale2 = new Vector3((float)scale_x[random_index2], (float)scale_y[random_index2], 1);
                                GameObject block2 = (GameObject)Blocks[random_index2];
                                GameObject newblock2 = (GameObject)Instantiate(block2, position2, transform.rotation);
                                newblock2.transform.localScale = scale2;

                                Vector3 position3 = new Vector3((float)position_x[random_index3] + 20, (float)position_y[random_index3], 0);
                                Vector3 scale3 = new Vector3((float)scale_x[random_index3], (float)scale_y[random_index3], 1);
                                GameObject block3 = (GameObject)Blocks[random_index3];
                                GameObject newblock3 = (GameObject)Instantiate(block3, position3, transform.rotation);
                                newblock3.transform.localScale = scale3;
                                rb1 = newblock1.GetComponent<Rigidbody>();
                                rb2 = newblock2.GetComponent<Rigidbody>();
                                rb3 = newblock3.GetComponent<Rigidbody>();
                                rb1.velocity = transform.forward * speed;
                                rb2.velocity = transform.forward * speed;
                                rb3.velocity = transform.forward * speed;
                                i += 1;
                                if (PlayerController.score % 5 == 4)
                                        speed = speed - (float)7;
                                yield return new WaitForSeconds(spawnWait);
                        }
                }
        }
}

