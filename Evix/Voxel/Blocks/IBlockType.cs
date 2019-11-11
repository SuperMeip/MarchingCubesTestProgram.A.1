namespace Evix.Voxel.Blocks {

  /// <summary>
  /// USed for manipulating blocktypes
  /// </summary>
  interface IBlockType {
    /// <summary>
    /// The ID of the block
    /// </summary>
    byte Id {
      get;
    }

    /// <summary>
    /// If this block type is solid block or not
    /// </summary>
    bool IsSolid {
      get;
    }

    /// <summary>
    /// How hard/solid this block is. 0 is air.
    /// </summary>
    byte Density {
      get;
    }
  }
}