/// <summary>
/// Interface for storing blocks
/// </summary>
public interface IBlockStorage {

  /// <summary>
  /// The itteratable bounds of this collection of blocks, x, y, and z
  /// </summary>
  Coordinate bounds {
    get;
  }

  /// <summary>
  /// Get the block data as an int bitmask at the given x,y,z
  /// </summary>
  /// <param name="location">the x,y,z of the block/point data to get</param>
  /// <returns>The block type</returns>
  Block.Type getBlock(Coordinate location);

  /// <summary>
  /// Update the point at the given location with a new blcok type id, and potentially a new density value
  /// This also updates the bit mask for all the blocks around the point being updated.
  /// </summary>
  /// <param name="location">The xyz of the point to update</param>
  /// <param name="blockType">the type of block to set to</param>
  void setBlock(Coordinate location, Block.Type newBlockType);
}
