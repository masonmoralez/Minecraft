using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [SerializeField] GameObject trunkPrefab;
    [SerializeField] GameObject leafPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int growPos = new Vector3Int(3, 1, -3);
        GameObject tree = new GameObject("Tree");
        tree.transform.position = growPos;

        int height = Random.Range(5, 15);
        Vector3Int[] branchDirections = { Vector3Int.forward, Vector3Int.right, Vector3Int.back, Vector3Int.left };

        for (int i = 0; i < height; i++)
        {
            Instantiate(trunkPrefab, growPos, Quaternion.identity, tree.transform);
            growPos += Vector3Int.up;

            if ((Random.Range(0f, 1f) > .6f))
            {
                Vector3Int branchPos = growPos;
                Debug.Log("Branching!");

                Vector3Int branchDir = branchDirections[Random.Range(0, 4)];
                int branchLength = Random.Range(1, 5);

                while (branchLength > 0)
                {
                    branchPos += branchDir;
                    Instantiate(trunkPrefab, branchPos, Quaternion.identity, tree.transform);
                    branchLength--;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
