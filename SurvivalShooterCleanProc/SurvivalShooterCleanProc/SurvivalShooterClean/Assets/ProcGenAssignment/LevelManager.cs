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

    public int twoChoices = 0;

    public int threeChoices = 0;

    // Use this for initialization
    void Start () {
        entrance = Random.Range(1, 4);
        if (entrance == 1)
        {
            AddRoom(testRow = 0, testColumn = 0, testType = Random.Range(0, 2));
        }
        if (entrance == 2)
        {
            AddRoom(testRow = 0, testColumn = 1, testType = Random.Range(0, 2));
        }
        if (entrance == 3)
        {
            AddRoom(testRow = 0, testColumn = 2, testType = Random.Range(0, 2));
        }
        if (entrance == 4)
        {
            AddRoom(testRow = 0, testColumn = 3, testType = Random.Range(0, 2));
        }
    }
	
	// Update is called once per frame
	void Update () {
        //testRow < 4 && testColumn < 4
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddRoom(testRow, testColumn, testType);
        }
        while (entrance < 4)
        {
            //AddRoom(testRow, testColumn, testType);
            if (entrance == 1)
            {
                twoChoices = Random.Range(1, 2);
                if (twoChoices == 1)
                {
                    AddRoom(testRow = 0, testColumn = 1, testType);
                }
                if (twoChoices == 2)
                {
                    AddRoom(testRow = 1, testColumn = 0, testType);
                }
                entrance = 5;
            }
            else if (entrance == 2)
            {
                threeChoices = Random.Range(1, 3);
                if (threeChoices == 1)
                {
                    AddRoom(testRow = 0, testColumn = 0, testType);
                }
                if (threeChoices == 2)
                {
                    AddRoom(testRow = 1, testColumn = 1, testType);
                }
                if (threeChoices == 3)
                {
                    AddRoom(testRow = 0, testColumn = 2, testType);
                }
                entrance = 5;
            }
            else if (entrance == 3)
            {
                threeChoices = Random.Range(1, 3);
                if (threeChoices == 1)
                {
                    AddRoom(testRow = 0, testColumn = 1, testType);
                }
                if (threeChoices == 2)
                {
                    AddRoom(testRow = 1, testColumn = 2, testType);
                }
                if (threeChoices == 3)
                {
                    AddRoom(testRow = 0, testColumn = 3, testType);
                }
                entrance = 5;
            }
            /*if (entrance == 3)
            {
                twoChoices = Random.Range(1, 2);
                if (twoChoices == 1)
                {
                    testColumn = 2;
                }
                if (twoChoices == 2)
                {
                    testRow = 1;
                }
                entrance = 5;
            }
            if (testColumn == 0)
            {
                testType = Random.Range(0, 2);
            }
            //testRow++;
            testColumn++;
            if (testColumn == 4)
            {
                testRow++;
                testColumn = 0;
            }*/
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
}
