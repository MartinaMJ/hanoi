using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class gameController : MonoBehaviour
{
    public int size=3;
    public GameObject diskTemplate;

    private List<GameObject> rod1 = new List<GameObject>();
    private List<GameObject> rod2 = new List<GameObject>();
    private List<GameObject> rod3 = new List<GameObject>();
    private List<List<GameObject>> rodArray = new List<List<GameObject>>();

    private GameObject currentDisk;

    private void Start()
    {
        Setup();
    }

    // Start is called before the first frame update
    public void Setup()
    {
        rodArray.Add(rod1);
        rodArray.Add(rod2);
        rodArray.Add(rod3);
        for (int i = 0; i < size; i++)
        {
            GameObject g= Instantiate(diskTemplate, new Vector3(0, i, 5),Quaternion.identity);
            g.transform.localScale = new Vector3(3+(size -i)*0.8f,1,3+(size -i)*0.8f);
            rod1.Add(g);
            g.GetComponent<MeshRenderer>().material.color
                = new Color(Random.Range(0.0f,1.0f),
                Random.Range(0.0f,1.0f),
                Random.Range(0.0f,1.0f)
                );
        }

    }

    public void Clear()
    {
        if (currentDisk)
        {
            Destroy(currentDisk);
            currentDisk = null;
        }
        foreach (List<GameObject> list in rodArray)
        {
            foreach (GameObject g in list)
            {
                Destroy(g);
            }
            list.Clear();
        }
    }

    // Update is called once per frame
    void Select(int rodNumber)
    {
        List<GameObject> r = rodArray[rodNumber];
        //pop last element
        GameObject g = r.Last();
        r.RemoveAt(r.Count -1);
        
        Vector3 oldPosition = g.transform.position;
        oldPosition.y = 10;
        g.transform.position = oldPosition;
        currentDisk = g;
    }



    void Move(int rodNumber)
    {
        if (currentDisk != null)
        {
            List<GameObject> r = rodArray[rodNumber];
            r.Add(currentDisk);
            Vector3 oldPosition = currentDisk.transform.position;
            oldPosition.y = r.Count()-1;
            oldPosition.x = 10*rodNumber;
            currentDisk.transform.position = oldPosition;
            currentDisk = null;
            
        }
        
    }

    public void HandleClick(int rodNumber)
    {
        if (currentDisk == null && rodArray[rodNumber].Count>0)
        {
            Select(rodNumber);
        }
        else
        {
            Move(rodNumber);
        }
    }


//https://en.wikipedia.org/wiki/Tower_of_Hanoi
    public IEnumerator Solve(int n,
        int src,
        int target,
        int auxiliary)
    {
        
        if (n > 0)
        {
            //Move n - 1 disks from source to auxiliary, so they are out of the way
            yield return Solve(n - 1, src, auxiliary, target);
            
            //Move the nth disk from source to target
            yield return new WaitForSeconds(1);
            Select(src);
            yield return new WaitForSeconds(1);
            Move(target);
            
            
            //Move the n - 1 disks that we left on auxiliary onto target
            yield return Solve(n-1,auxiliary,target,src);
        }
    }
    
    
    public void Autosolve()
    {
        Clear();
        Setup();
        StartCoroutine(Solve(size,0,2,1));
    }
    
    
}
