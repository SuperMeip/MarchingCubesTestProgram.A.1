/// <summary>
/// Used for interfacing with blocks
/// </summary>
namespace Evix.Voxel.Blocks {

  /// <summary>
  /// Used for block constants
  /// </summary>
  public static class Block {

    /// <summary>
    /// A class for storing the values of each type of block
    /// </summary>
    public abstract class Type : IBlockType {

      /// <summary>
      /// The ID of the block
      /// </summary>
      public byte Id {
        get;
        protected set;
      }

      /// <summary>
      /// If this block type is solid block or not
      /// </summary>
      public bool IsSolid {
        get;
        protected set;
      } = true;

      /// <summary>
      /// How hard/solid this block is. 0 is air.
      /// </summary>
      public byte Density {
        get;
        protected set;
      } = 64;

      /// <summary>
      /// Make a new type
      /// </summary>
      /// <param name="id"></param>
      internal Type(byte id) {
        Id = id;
      }
    }

    /// <summary>
    /// A class for manipulating block types
    /// </summary>
    public static class Types {

      /// <summary>
      /// Air, an empty block
      /// </summary>
      public static Type Air = new Air();

      /// <summary>
      /// Stone, a solid rock block
      /// </summary>
      public static Type Stone = new Stone();

      /// <summary>
      /// Stone, a solid rock block
      /// </summary>
      public static Type Placeholder = new Placeholder();

      /// <summary>
      /// All block types by id
      /// </summary>
      public static Type[] All = {
        Air,
        Placeholder,
        Stone
      };

      public static Type Get(byte id) {
        return All[id];
      }
    }
  }
}