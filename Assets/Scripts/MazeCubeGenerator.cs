using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCubeGeneratorCell
{
    public int X;
    public int Y;
    public int Z;

    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool floor = true;

    public bool isVisited = false;
}

public class MazeCubeGenerator
{
    public int Size { get; set; } = 10;

    public MazeCubeGenerator(int size)
    {
        Size = size;
    }
    //генерация лабиринта
    public MazeCubeGeneratorCell[,,] GenerateMaze()
    {
        MazeCubeGeneratorCell[,,] mazeCube = new MazeCubeGeneratorCell[Size, Size, Size]; // кубический лабиринат в виде трехмерного массива

        for (int x = 0; x < mazeCube.GetLength(0); x++)
        {
            for (int y = 0; y < mazeCube.GetLength(1); y++)
            {
                for (int z = 0; z < mazeCube.GetLength(2); z++)
                {
                    mazeCube[x, y, z] = new MazeCubeGeneratorCell { X = x, Y = y, Z = z };
                }
            }
        }

        RemoveWallsWithTracker(mazeCube);
        return mazeCube;
    }
    //алгоритм идет по лабиринту и убирает случайную стену (Bottom, Left)
    void RemoveWallsWithTracker(MazeCubeGeneratorCell[,,] maze)
    {
        Stack<MazeCubeGeneratorCell> stack = new Stack<MazeCubeGeneratorCell>();

        MazeCubeGeneratorCell current = maze[1, 1, 0];

        current.isVisited = true;

        do
        {
            List<MazeCubeGeneratorCell> UnvisitedNeighbors = new List<MazeCubeGeneratorCell>();
            int x = current.X;
            int y = current.Y;
            int z = current.Z;

            //далее возможные переходы в другие ячейки в лабиринте соответственно для каждой грани куба 
            if (z == 0) 
            {
                if (x > 1 && !maze[x - 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y, z]);
                if (x < Size - 3 && !maze[x + 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, z]);
                if (y > 1 && !maze[x, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y - 1, z]);
                if (y < Size - 3 && !maze[x, y + 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y + 1, z]);
            
                if ((x == 1) && !maze[0, y , x].isVisited) UnvisitedNeighbors.Add(maze[0, y, x]);
                if ((y == 1) && !maze[x, 0, y].isVisited) UnvisitedNeighbors.Add(maze[x, 0, y]);
                if ((x == Size - 3) && !maze[x + 1, y, 1].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, 1]);
                if ((y == Size - 3) && !maze[x, y + 1, 1].isVisited) UnvisitedNeighbors.Add(maze[x, y + 1, 1]);
            }

            if (z == Size - 2)
            {
                if (x > 1 && !maze[x - 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y, z]);
                if (x < Size - 3 && !maze[x + 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, z]);
                if (y > 1 && !maze[x, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y - 1, z]);
                if (y < Size - 3 && !maze[x, y + 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y + 1, z]);

                if ((x == 1) && !maze[0, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[0, y, z - 1]);
                if ((y == 1) && !maze[x, 0, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x, 0, z - 1]);
                if ((x == Size - 3) && !maze[x + 1, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, z - 1]);
                if ((y == Size - 3) && !maze[x, y + 1, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x, y + 1, z - 1]);
            }

            if (y == 0)
            {
                if (x > 1 && !maze[x - 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y, z]);
                if (x < Size - 3 && !maze[x + 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, z]);
                if (z > 1 && !maze[x, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z - 1]);
                if (z < Size - 3 && !maze[x, y, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z + 1]);

                if ((x == 1) && !maze[0, 1, z].isVisited) UnvisitedNeighbors.Add(maze[0, 1, z]);
                if ((z == 1) && !maze[x, 1, 0].isVisited) UnvisitedNeighbors.Add(maze[x, 1, 0]);
                if ((x == Size - 3) && !maze[x + 1, 1, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, 1, z]);
                if ((z == Size - 3) && !maze[x, 1, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x, 1, z + 1]);
            }

            if (y == Size - 2)
            {
                if (x > 1 && !maze[x - 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y, z]);
                if (x < Size - 3 && !maze[x + 1, y, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, z]);
                if (z > 1 && !maze[x, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z - 1]);
                if (z < Size - 3 && !maze[x, y, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z + 1]);

                if ((x == 1) && !maze[x - 1, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y - 1, z]);
                if ((z == 1) && !maze[x, y - 1, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x, y - 1, z - 1]);
                if ((x == Size - 3) && !maze[x + 1, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y - 1, z]);
                if ((z == Size - 3) && !maze[x, y - 1, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x, y - 1, z + 1]);
            }

            if (x == 0)
            {
                if (y > 1 && !maze[x, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y - 1, z]);
                if (y < Size - 3 && !maze[x, y + 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y + 1, z]);
                if (z > 1 && !maze[x, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z - 1]);
                if (z < Size - 3 && !maze[x, y, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z + 1]);

                if ((y == 1) && !maze[x + 1, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y - 1, z]);
                if ((z == 1) && !maze[x + 1, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, z - 1]);
                if ((y == Size - 3) && !maze[x + 1, y + 1, z].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y + 1, z]);
                if ((z == Size - 3) && !maze[x + 1, y, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y, z + 1]);
            }

            if (x == Size - 2)
            {
                if (y > 1 && !maze[x, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y - 1, z]);
                if (y < Size - 3 && !maze[x, y + 1, z].isVisited) UnvisitedNeighbors.Add(maze[x, y + 1, z]);
                if (z > 1 && !maze[x, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z - 1]);
                if (z < Size - 3 && !maze[x, y, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x, y, z + 1]);

                if ((y == 1) && !maze[x - 1, y - 1, z].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y - 1, z]);
                if ((z == 1) && !maze[x - 1, y, z - 1].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y, z - 1]);
                if ((y == Size - 3) && !maze[x - 1, y + 1, z].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y + 1, z]);
                if ((z == Size - 3) && !maze[x - 1, y, z + 1].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y, z + 1]);
            }




            if (UnvisitedNeighbors.Count > 0)
            {
                MazeCubeGeneratorCell chosen = UnvisitedNeighbors[Random.Range(0, UnvisitedNeighbors.Count)];
                RemoveWall(current, chosen);
                //Debug.Log(chosen.X + " " + chosen.Y + " " + chosen.Z + " " + "вперед");
                chosen.isVisited = true;
                current = chosen;
                stack.Push(chosen);
            }
            else
            {
                current = stack.Pop();
                //Debug.Log(current.X + " " + current.Y + " " + current.Z + " " + "назад");
            }
        }
        while (stack.Count > 0);
    }
    //функция убирающая стену в лабиринте
    private void RemoveWall(MazeCubeGeneratorCell current, MazeCubeGeneratorCell chosen)
    {
        if (current.Z == 0 || current.Z == Size - 2)
        {
            if (chosen.Z == 1 || chosen.Z == Size - 3)
            {
                if (chosen.Y == current.Y)
                {
                    if (current.X == 1)
                        current.WallLeft = false;
                    else
                        chosen.WallLeft = false;
                }
                else 
                {
                    if (current.Y == 1)
                        current.WallBottom = false;
                    else
                        chosen.WallBottom = false;
                }
            }
            else
            {
                if (current.X == chosen.X)
                {
                    if (current.Y > chosen.Y)
                        current.WallBottom = false;

                    else
                        chosen.WallBottom = false;
                }
                else
                {
                    if (current.X > chosen.X)
                    {
                        if (current.Z == 0)
                            current.WallLeft = false;
                        else
                            chosen.WallLeft = false;
                    }
                    else
                    {
                        if (current.Z == 0)
                            chosen.WallLeft = false;
                        else
                            current.WallLeft = false;
                    }
                }
            }
        }

        if (current.Y == 0 || current.Y == Size - 2)
        {
            if (chosen.Y == 1)
            {
                if (chosen.Z == current.Z)
                {
                    if (current.X == 1)
                    {
                        current.WallLeft = false;
                        chosen.WallBottom = false;
                    }
                    else
                        chosen.WallBottom = false;
                }
                else
                {
                    if (current.Z == 1)
                        chosen.WallBottom = false;
                    else
                    {
                        chosen.WallBottom = false;
                        current.WallBottom = false;
                    }
                }
            }
            else if (chosen.Y == Size - 3)
            {
                if (chosen.Z == current.Z)
                {
                    if (current.X == 1)
                        current.WallLeft = false;
                }
                else
                {
                    if (current.Z == 1)
                        current.WallBottom = false;
                }
            }
            else
            {
                if (current.X == chosen.X)
                {
                    if (current.Z > chosen.Z)
                    {
                        if (current.Y == 0)
                            chosen.WallBottom = false;
                        else
                            current.WallBottom = false;
                    }
                    else
                    {
                        if (current.Y == 0)
                            current.WallBottom = false;
                        else
                            chosen.WallBottom = false;
                    }
                }
                else
                {
                    if (current.X > chosen.X)
                        current.WallLeft = false;
                    else
                        chosen.WallLeft = false;
                }
            }
        }

        if (current.X == 0 || current.X == Size - 2)
        {
            if (chosen.X == 1)
            {
                if (chosen.Y == current.Y)
                {
                    if (current.Z == 1)
                        chosen.WallLeft = false;
                    else
                        current.WallLeft = false;
                }
                else
                {
                    if (current.Y == 1)
                    {
                        chosen.WallLeft = false;
                        current.WallBottom = false;
                    }
                    else
                        chosen.WallLeft = false;
                }
            }
            else if (chosen.X == Size - 3)
            {
                if (chosen.Y == current.Y)
                {
                    if (current.Z == 1)
                        current.WallLeft = false;
                    else
                        chosen.WallLeft = false;
                }
                else
                {
                    if (current.Y == 1)
                        current.WallBottom = false;
                }
            }
            else
            {
                if (current.Z == chosen.Z)
                {
                    if (current.Y > chosen.Y)
                        current.WallBottom = false;
                    else
                        chosen.WallBottom = false;
                }
                else
                {
                    if (current.Z > chosen.Z)
                    {
                        if (current.X == 0)
                            chosen.WallLeft = false;
                        else
                            current.WallLeft = false;
                    }
                    else
                    {
                        if (current.X == 0)
                            current.WallLeft = false;
                        else
                            chosen.WallLeft = false;
                    }
                }
            }
        }
    }
    
}
