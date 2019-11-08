using System;

class Bloctree : BlockStorage {

  /// <summary>
  /// The blocks contained in an octree
  /// </summary>
  Octree<byte> blocks;

  /// <summary>
  /// Make a new block octree of the given size
  /// </summary>
  /// <param name="diameter"></param>
  public Bloctree(byte diameter) : base(diameter) {
    blocks = new Octree<byte>(
      (Octree<byte>.DepthsByDiameter)bounds.x,
      Block.Types.Air.Id
    );
  }

  /// <summary>
  /// Get a block from the octree
  /// </summary>
  /// <param name="location"></param>
  /// <returns></returns>
  public override Block.Type getBlock(Coordinate location) {
    return Block.Types.Get(blocks.getValueAt(location));
  }

  /// <summary>
  /// set a block in the octree
  /// </summary>
  /// <param name="location"></param>
  /// <param name="newBlockType"></param>
  public override void setBlock(Coordinate location, byte newBlockType) {
    blocks.setValueAt(location, newBlockType, 1);
  }

  /// <summary>
  /// set the correct bounds, we need to stick to a valid diameter
  ///    valid diameters are squares of 2
  /// </summary>
  /// <param name="newBounds"></param>
  protected override void setBounds(Coordinate newBounds) {
    System.Array depths = Enum.GetValues(typeof(Octree<>.DepthsByDiameter));
    int diameterToUse = 0;
    foreach (Octree<int>.DepthsByDiameter depth in depths) {
      int validDiameter = Octree<int>.GetSizeOfNodeFromDepth(depth);
      if (validDiameter >= newBounds.x) {
        diameterToUse = validDiameter;
        break;
      }
    }
    bounds = new Coordinate(diameterToUse);
  }
}