using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {

    public List<Vector2> positions;
    List<GameObject> blocks;
    GameObject block;
    GameManager gameManager;

	// Use this for initialization
	void Start () {

        positions = new List<Vector2>();
        blocks = new List<GameObject>();

        gameManager = GameObject.FindObjectOfType<GameManager>();
        block = Resources.Load("prefab/block") as GameObject;

        for (int i = -2; i <= 2; i++)
        {
            positions.Add(new Vector2(i, 4));
        }

        StartCoroutine(GenerateBlocks());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GenerateBlocks()
    {
        while (gameManager.isRunning)
        {
            for (int i = 0; i < Random.Range(1,4); i++)
            {
                blocks.Add(Instantiate(block, positions[Random.Range(0, 4)], Quaternion.identity));
            }
            
            yield return new WaitForSeconds(0.5f);
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    block.transform.position = new Vector2(block.transform.position.x, block.transform.position.y - 0.25f);
                }
            }
            //for (int i = 0; i < blocks.Count; i++)
            //{

            //}

        }

        yield return null;

        yield break;
    }

}
