using Block;
using System;

[Serializable]
public abstract class BlockStorage : IBlockStorage {

  /// <summary>
  /// The itteratable bounds of this collection of blocks, x, y, and z
  /// </summary>
  public Coordinate bounds {
    get;
    protected set;
  }

  /// <summary>
  /// Generic base constructor
  /// </summary>
  /// <param name="bounds"></param>
  public BlockStorage(Coordinate bounds) {
    setBounds(bounds);
  }

  /// <summary>
  /// Base constructor all same bounds
  /// </summary>
  /// <param name="bound">x,y,and z's shared max bound</param>
  public BlockStorage(int bound) : this(new Coordinate(bound)) { }

  /// <summary>
  /// Get the block data as an int bitmask at the given x,y,z
  /// </summary>
  /// <param name="location">the x,y,z of the block/point data to get</param>
  /// <returns>the block type</returns>
  public abstract Block.Type getBlock(Coordinate location);

  /// <summary>
  /// Overwrite the entire block at the given location
  /// </summary>
  /// <param name="location">the x,y,z of the block to set</param>
  /// <param name="newBlockType">the new type to set for the given block</param>
  public abstract void setBlock(Coordinate location, byte newBlockType);

  /// <summary>
  /// Overwrite the entire block at the given location
  /// </summary>
  /// <param name="location">the x,y,z of the block to set</param>
  /// <param name="newBlockType">the new type to set for the given block</param>
  public void setBlock(Coordinate location, Block.Type newBlockType) {
    setBlock(location, newBlockType.Id);
  }

  /// <summary>
  /// set the bounds based on a provided x y and z
  /// </summary>
  /// <param name="newBounds"></param>
  protected virtual void setBounds(Coordinate newBounds) {
    bounds = newBounds;
  }
}
