using Evix.Voxel.Collections;
using Evix.Voxel.Collections.BlockData;
using Evix.Voxel.Generation.Mesh;
using System;

namespace BlockGenTest {
  class Program {
    static void Main(string[] args) {
      Level<MarchingPointDictionary> level = 
        new ColumnLoadedLevel<MarchingPointDictionary>(
          (100, 25, 100),
          new WaveSource()
      );

      IBlockMeshGenerator meshGenerator = new MarchGenerator();

      level.initializeAround((50, 0, 50));
      /*System.Threading.Thread.Sleep(7000);

      Coordinate.Zero.until(level.chunkBounds, chunkLocation => {
        Console.WriteLine("Mesh Generating: " + chunkLocation.ToString());
        IBlockStorage chunkData = level.getChunk(chunkLocation);
        if (!chunkData.isEmpty) {
          Console.WriteLine("Done Generating Mesh: " + chunkLocation.ToString());
          meshGenerator.generateMesh(chunkData);
        } else {
          Console.WriteLine("Generating Mesh Skipped: " + chunkLocation.ToString());
        }
      });*/
    }
  }
}
