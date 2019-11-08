using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// A mesh of tris and verts
/// </summary>
public class Mesh : IMesh {

  /// <summary>
  ///  the triangles
  /// </summary>
  public List<int> triangles {
    get;
    set;
  }

  /// <summary>
  /// the vertices
  /// </summary>
  public List<Vector3> vertices {
    get;
    set;
  }

  /// <summary>
  /// Make a mesh
  /// </summary>
  /// <param name="triangles"></param>
  /// <param name="vertices"></param>
  public Mesh(List<int> triangles, List<Vector3> vertices) {
    this.triangles = triangles;
    this.vertices = vertices;
  }
}