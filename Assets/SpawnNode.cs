using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{
    float x = 0;
    public Slider sliderx;
    public Slider sliderz;

    public int baseX { set; get; } = 2;
    public int baseZ { set; get; } = 3;
    int count = 0;
    int capacity = 50;
    public Color[] colors = new Color[3];
    public GameObject myPrefab;
    public GameObject[] nodes = new GameObject[50]; 
    public void UpdateGame()
    {
        for (int i = count; i > 0; i--)
        {
            Destroy(nodes[i-1]);
            count--;
        }
        

        baseX = (int)sliderx.value;
        baseZ = (int)sliderz.value;
        if (baseX != 1 && baseZ != 1) {
            for (int i = 0; i < 50; i++)
            {
                Vector3 pos = new Vector3(halton(i + 1, baseX) * 100f - 50f, 2f, halton(i + 1, baseZ) * 100f - 50f);
                nodes[i] = Instantiate(myPrefab, pos, Quaternion.identity);
                int r = Random.Range(0, 2);
                nodes[i].GetComponent<MeshRenderer>().material.SetColor("_Color", colors[r]);
                count++;
            }
        }
    }
    public void Start()
    {
        baseX = (int)sliderx.value;
        baseZ = (int)sliderz.value;
        
        for (int i = 0; i < 50; i++)
        {
            Vector3 pos = new Vector3(halton(i + 1, baseX) * 100f - 50f, 2f, halton(i + 1, baseZ) * 100f - 50f);
            nodes[i] = Instantiate(myPrefab, pos, Quaternion.identity);
            int r = Random.Range(0, 2);
            nodes[i].GetComponent<MeshRenderer>().material.SetColor("_Color", colors[r]);
            count++;
        }
    }
    float halton(int index, int numbase)
    {
        float fraction = 1;
        float  result = 0;
        while (index > 0)
        {
            fraction /= numbase;
            result += fraction * (index % numbase);
            index = ~~(index / numbase); // floor division
        }
        return result;
    }
}
