using Evix.Voxel.Blocks;
using System;
using System.Collections.Generic;

namespace Evix.Voxel.Collections.BlockData {

  /// <summary>
  /// A collection of block data stored by point location in a dictionary
  /// </summary>
  public class MarchingPointDictionary : BlockStorage {

    /// <summary>
    /// if there are no blocks in this storage object
    /// </summary>
    public override bool isEmpty
      => points == null || points.Count == 0;

    /// <summary>
    /// The collection of points, a byte representing the material the point is made of
    /// </summary>
    IDictionary<Coordinate, byte> points;

    /// <summary>
    /// Create a new marching point block dictionary of the given size
    /// </summary>
    /// <param name="bounds"></param>
    public MarchingPointDictionary(Coordinate bounds) : base(bounds) {
      points = new Dictionary<Coordinate, byte>(bounds.x * bounds.y * bounds.z);
    } //int version:
    public MarchingPointDictionary(int bound) : this(new Coordinate(bound)) { }

    /// <summary>
    /// Get the block at the location from the dictionary
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public override Block.Type getBlock(Coordinate location) {
      points.TryGetValue(location, out byte value);
      return Block.Types.Get(value);
    }

    /// <summary>
    /// Overwrite the entire point at the given location
    /// </summary>
    /// <param name="location">the x,y,z of the block to set</param>
    /// <param name="newBlockValue">The block data to set as a bitmask:
    ///   byte 1: the block type id
    ///   byte 2: the block vertex mask
    ///   byte 3 & 4: the block's scalar density float, compresed to a short
    /// </param>
    public override void setBlock(Coordinate location, byte newBlockValue) {
      if (location.isWithin(bounds)) {
        points[location] = newBlockValue;
      } else {
        throw new IndexOutOfRangeException();
      }
    }
  }
}