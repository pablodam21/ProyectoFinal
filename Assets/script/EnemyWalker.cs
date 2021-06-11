using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startPoint;
    public GameObject endPonit;
	
    public float enemySpeed;
    private bool isRight;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!isRight){
            transform.position = startPoint.transform.position;
        }else{
            transform.position = endPonit.transform.position;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRight){
            transform.position = Vector3.MoveTowards(transform.position, endPonit.transform.position, enemySpeed * Time.deltaTime);
            if(transform.position == endPonit.transform.position){
                isRight = true;
                GetComponent<SpriteRenderer>().flipX=true;
            }
        }
		
        if(isRight){
            transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed * Time.deltaTime);
            if(transform.position == startPoint.transform.position){
                isRight = false;
                GetComponent<SpriteRenderer>().flipX=false;
            }
        }
		

    }
}
