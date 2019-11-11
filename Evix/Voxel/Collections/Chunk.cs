using Evix.Voxel.Collections.BlockData;
using Evix.Voxel.Blocks;

namespace Evix.Voxel.Collections {

  /// <summary>
  /// A type of block storage that allows neighbors to link together
  /// </summary>
  public class Chunk : IBlockChunk {

    /// <summary>
    /// The blocks in this chunk
    /// </summary>
    public IBlockStorage blocks {
      get;
      private set;
    }

    /// <summary>
    /// The bounds of the chunks blocks
    /// </summary>
    public Coordinate bounds
      => blocks.bounds;

    /// <summary>
    /// if this chunk is empty
    /// </summary>
    public bool isEmpty
      => blocks == null || blocks.isEmpty;

    /// <summary>
    /// The neighbors of this chunk, indexed by the direction they're in
    /// </summary>
    IBlockChunk[] neighbors;

    /// <summary>
    /// Make a chunk out of block data
    /// </summary>
    /// <param name="blocks">the block data of this chunk</param>
    /// <param name="neighbors">the other chunks to link to</param>
    public Chunk(IBlockStorage blocks, IBlockChunk[] neighbors = null) {
      this.blocks = blocks;
      this.neighbors = neighbors;
    }

    /// <summary>
    /// get the block, making sure we're in the right chunk first
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public Block.Type getBlock(Coordinate location) {
      if (location.x >= bounds.x) {
        return getNeighbor(Directions.East).getBlock(location - bounds);
      }
      if (location.x < 0) {
        return getNeighbor(Directions.West).getBlock(location + bounds);
      }
      if (location.y >= bounds.y) {
        return getNeighbor(Directions.Above).getBlock(location - bounds);
      }
      if (location.y < 0) {
        return getNeighbor(Directions.Below).getBlock(location + bounds);
      }
      if (location.z >= bounds.z) {
        return getNeighbor(Directions.North).getBlock(location - bounds);
      }
      if (location.z < 0) {
        return getNeighbor(Directions.South).getBlock(location + bounds);
      }

      return blocks.getBlock(location);
    }

    /// <summary>
    /// set the block, making sure we're in the right chunk first
    /// </summary>
    /// <param name="location"></param>
    /// <param name="newBlockType"></param>
    public void setBlock(Coordinate location, Block.Type newBlockType) {
      if (location.x >= bounds.x) {
        getNeighbor(Directions.East).setBlock(location - bounds, newBlockType);
      }
      if (location.x < 0) {
        getNeighbor(Directions.West).setBlock(location + bounds, newBlockType);
      }
      if (location.y >= bounds.y) {
        getNeighbor(Directions.Above).setBlock(location - bounds, newBlockType);
      }
      if (location.y < 0) {
        getNeighbor(Directions.Below).setBlock(location + bounds, newBlockType);
      }
      if (location.z >= bounds.z) {
        getNeighbor(Directions.North).setBlock(location - bounds, newBlockType);
      }
      if (location.z < 0) {
        getNeighbor(Directions.South).setBlock(location + bounds, newBlockType);
      }

      blocks.setBlock(location, newBlockType);
    }

    /// <summary>
    /// set the neighbor at the direction
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="neighbor"></param>
    public void setNeighbor(Directions.Direction direction, IBlockChunk neighbor = null) {
      neighbors[direction.Value] = neighbor;
    }

    /// <summary>
    /// Get the neigboring chunk
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private IBlockChunk getNeighbor(Directions.Direction direction) {
      return neighbors[direction.Value];
    }
  }
}