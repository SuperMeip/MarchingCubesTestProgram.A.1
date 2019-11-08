using System;

namespace BlockGenTest {
  class Program {
    static void Main(string[] args) {
      Level<MarchingPointDictionary> level = 
        new ColumnLoadedLevel<MarchingPointDictionary>(
          (100, 25, 100),
          new WaveSource()
      );

      IBlockMeshGenerator meshGenerator = new MarchRenderer();

      level.initializeAround((50, 0, 50));
      Coordinate.Zero.until(level.chunkBounds, chunkLocation => {
        Console.WriteLine("Mesh Generating: " + chunkLocation.ToString());
        IBlockStorage chunkData = level.getChunk(chunkLocation);
        if (chunkData != null) {
          Console.WriteLine("Done Generating Mesh: " + chunkLocation.ToString());
          meshGenerator.generateMesh(chunkData);
        } else {
          Console.WriteLine("Generating Mesh Skipped: " + chunkLocation.ToString());
        }
      });
    }
  }
}
