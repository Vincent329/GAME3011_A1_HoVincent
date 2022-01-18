using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningGrid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridAreaArray;
    public MiningGrid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridAreaArray = new int[width, height];

        for (int i = 0; i < gridAreaArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridAreaArray.GetLength(1); j++)
            {
            
            }
        }
    }
}
