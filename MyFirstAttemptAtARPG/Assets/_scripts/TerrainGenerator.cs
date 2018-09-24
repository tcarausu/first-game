using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public int depth = 20;
    public float scale = 20f;

    public float offSetX = 100f;
    public float offSetY = 100f;

    // Use this for initialization
    void Start()
    {
        offSetX = Random.Range(0f, 99999f);
        offSetY = Random.Range(0f, 99999f);
    }

     void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateData(terrain.terrainData);

      //  offSetX += Time.deltaTime * 5f;
    }
    TerrainData GenerateData(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;

    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeigh(x, y);
            }
        }

        return heights;
    }

    float CalculateHeigh(int x, int y)
    {
        float xCoord = (float)x / width * scale + offSetX;
        float yCoord = (float)y / height * scale + offSetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }


}
