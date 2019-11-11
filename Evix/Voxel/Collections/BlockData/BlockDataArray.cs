using Evix.Voxel.Blocks;
using System;

namespace Evix.Voxel.Collections.BlockData {

  /// <summary>
  /// Jagged array dynamic block storage
  /// </summary>
  public class BlockDataArray : BlockStorage {

    /// <summary>
    /// block data
    /// </summary>
    byte[][][] blocks;

    /// <summary>
    /// if this is empty
    /// </summary>
    public override bool isEmpty
      => blocks == null;

    /// <summary>
    /// make a new blockdata array
    /// </summary>
    /// <param name="bounds"></param>
    public BlockDataArray(Coordinate bounds) : base(bounds) {
      blocks = null;
    }

    /// <summary>
    /// make a new blockdata array
    /// </summary>
    /// <param name="bounds"></param>
    public BlockDataArray(int bound) : base(bound) {
      blocks = null;
    }

    /// <summary>
    /// get a block
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public override Block.Type getBlock(Coordinate location) {
      if (location.isWithin(bounds)) {
        return Block.Types.Get(get(location));
      }
      throw new IndexOutOfRangeException();
    }

    /// <summary>
    /// set a block
    /// </summary>
    /// <param name="location"></param>
    /// <param name="newBlockType"></param>
    public override void setBlock(Coordinate location, byte newBlockType) {
      if (location.isWithin(bounds)) {
        set(location, newBlockType);
      } else {
        throw new IndexOutOfRangeException();
      }
    }

    /// <summary>
    /// Set the value at the given point
    /// </summary>
    /// <param name="location"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    void set(Coordinate location, byte value) {
      if (blocks == null) {
        initilizeJaggedArray(location.x);
      }
      // If this is beyond our current X, resize the x array
      if (blocks.Length < location.x) {
        Array.Resize(ref blocks, location.x);
      }
      // if there's no Y array at the X location, add one
      if (blocks[location.x] == null) {
        blocks[location.x] = new byte[location.y][];
      }
      // if the Y array is too small, resize it
      if (blocks[location.x].Length < location.y) {
        Array.Resize(ref blocks[location.x], location.y);
      }
      // if there's no Z array at our location, add one
      if (blocks[location.x][location.y] == null) {
        blocks[location.x][location.y] = new byte[location.z];
      }
      // if the Z array is too small, resize it
      if (blocks[location.x][location.y].Length < location.z) {
        Array.Resize(ref blocks[location.x][location.y], location.z);
      }

      blocks[location.x][location.y][location.z] = value;
    }

    /// <summary>
    /// Get the block data at a location
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    byte get(Coordinate location) {
      return (byte)(blocks != null
        ? location.x < blocks.Length
          ? location.y < blocks[location.x].Length
            ? location.z < blocks[location.x][location.y].Length
              ? blocks[location.x][location.y][location.z]
              : 0
            : 0
          : 0
        : 0
      );
    }

    /// <summary>
    /// Create the first row of the jagged array
    /// </summary>
    /// <param name="x"></param>
    void initilizeJaggedArray(int x = -1) {
      blocks = new byte[x == -1 ? bounds.x : x][][];
    }
  }
}