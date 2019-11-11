using System.Numerics;
using System.Collections.Generic;

namespace Evix.Voxel.Generation.Mesh {

  /// <summary>
  /// A mesh made of tri and verticie data
  /// </summary>
  public interface IMesh {
    List<int> triangles {
      get;
    }

    List<Vector3> vertices {
      get;
    }
  }
}