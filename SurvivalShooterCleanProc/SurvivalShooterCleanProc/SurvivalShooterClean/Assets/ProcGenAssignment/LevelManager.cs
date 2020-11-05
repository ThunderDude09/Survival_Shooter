using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    // can't see 2D array in inspector
    public Transform[] roomSpawnersRow0;
    public Transform[] roomSpawnersRow1;
    public Transform[] roomSpawnersRow2;
    public Transform[] roomSpawnersRow3;

    public GameObject[] rooms;

    public int testRow = 0;
    public int testColumn = 0;
    public int testType = 0;

    public int entrance = 0;

    public int leftRight;

    public int upDown;

    public int horizontalOrVertical;

    public int path = 0;

    /*public int twoChoices = 0;

    public int threeChoices = 0;

    public int twoChoices2 = 0;

    public int threeChoices2 = 0;*/

    // Use this for initialization
    void Start () {
        entrance = Random.Range(1, 4);
        if (entrance == 1)
        {
            AddRoom(testRow = 0, testColumn = 0, testType);
        }
        if (entrance == 2)
        {
            AddRoom(testRow = 0, testColumn = 1, testType);
        }
        if (entrance == 3)
        {
            AddRoom(testRow = 0, testColumn = 2, testType);
        }
        if (entrance == 4)
        {
            AddRoom(testRow = 0, testColumn = 3, testType);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //testRow < 4 && testColumn < 4
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddRoom(testRow, testColumn, testType);
        }
        while (path < 5)
        {
            
            MakePath();
            path += 1;
        }
	}

    public void AddRoom(int row, int column, int roomType)
    {
        Vector3 spawnPos = Vector3.zero;
        // figure out position to spawn at
        switch(row)
        {
            case 0:
                spawnPos = roomSpawnersRow0[column].position;
                break;
            case 1:
                spawnPos = roomSpawnersRow1[column].position;
                break;
            case 2:
                spawnPos = roomSpawnersRow2[column].position;
                break;
            case 3:
                spawnPos = roomSpawnersRow3[column].position;
                break;
        }

        // actually spawn it
        Instantiate(rooms[roomType], spawnPos, transform.rotation);
    }

    public void MakePath()
    {
        Debug.Log("roomMade");
        horizontalOrVertical = Random.Range(1, 5);
        if (horizontalOrVertical == 1 && testColumn == 0)
        {
            AddRoom(testRow += 1, testColumn, testType);
        }
        else if (horizontalOrVertical == 1)
        {
            AddRoom(testRow, testColumn -= 1, testType);
        }
        else if (horizontalOrVertical == 2 && testColumn == 0)
        {
            AddRoom(testRow, testColumn += 1, testType);
        }
        else if (horizontalOrVertical == 2)
        {
            AddRoom(testRow, testColumn -= 1, testType);
        }
        else if (horizontalOrVertical == 3 && testColumn == 0)
        {
            AddRoom(testRow += 1, testColumn, testType);
        }
        else if (horizontalOrVertical == 3)
        {
            AddRoom(testRow, testColumn += 1, testType);
        }
        else if (horizontalOrVertical == 4 && testColumn == 0)
        {
            AddRoom(testRow, testColumn -= 1, testType);
        }
        else if (horizontalOrVertical == 4)
        {
            AddRoom(testRow, testColumn -= 1, testType);
        }
        else if (horizontalOrVertical == 5)
        {
            AddRoom(testRow += 1, testColumn, testType);
        }
    }
}


