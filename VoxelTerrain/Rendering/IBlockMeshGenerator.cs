/// <summary>
/// Interface for a mesh renderer for blocks for unity
/// </summary>
interface IBlockMeshGenerator {

  /// <summary>
  /// Generate a unity mesh from a set of blockData
  /// </summary>
  /// <param name="blockData"></param>
  /// <param name="isoSurfaceLevel"></param>
  /// <returns></returns>
  public IMesh generateMesh(IBlockStorage blockData);
}