namespace Evix.Voxel.Blocks {

  /// <summary>
  /// An air block, empty
  /// </summary>
  internal class Air : Block.Type {

    internal Air() : base(0) {
      Density = 0;
      IsSolid = false;
    }
  }

  /// <summary>
  /// An empty block that's not air.
  /// Counts as solid but doesn't render
  /// </summary>
  internal class Placeholder : Block.Type {
    internal Placeholder() : base(1) { }
  }

  /// <summary>
  /// Stone, a solid rock block
  /// </summary>
  internal class Stone : Block.Type {

    internal Stone() : base(2) {
      Density = 128;
    }
  }
}
