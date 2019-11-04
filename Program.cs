using System;

namespace BlockGenTest {
  class Program {
    static void Main(string[] args) {
      Level<MarchingPointDictionary> level = 
        new ColumnLoadedLevel<MarchingPointDictionary>(
          (100, 25, 100),
          new WaveSource()
      );

      level.initializeAround((50, 0, 50));
    }
  }
}
