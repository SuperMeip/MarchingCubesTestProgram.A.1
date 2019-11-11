using Evix.Voxel.Collections.BlockData;

namespace Evix.Voxel.Collections {
  /// <summary>
  /// A block storage wrapper aware of it's neighbors
  /// </summary>
  public interface IBlockChunk : IBlockStorage {

    /// <summary>
    /// get the block data for this chunk
    /// </summary>
    IBlockStorage blocks {
      get;
    }

    /// <summary>
    /// set the neighboring chunk
    /// </summary>
    /// <param name="direction">the direction of the neighbor to link</param>
    /// <param name="neighbor">the neighbor object to link</param>
    void setNeighbor(Directions.Direction direction, IBlockChunk neighbor = null);
  }
}