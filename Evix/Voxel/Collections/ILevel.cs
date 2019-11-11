using Evix.Voxel.Collections.BlockData;

namespace Evix.Voxel.Collections {
  /// <summary>
  /// An interface for a level, used to load the block data for a level around a player/focus point
  /// </summary>
  public interface ILevel<BlockStorageType> where BlockStorageType : IBlockStorage {

    /// <summary>
    /// The overall bounds of the level, max x y and z
    /// </summary>
    Coordinate chunkBounds {
      get;
    }

    /// <summary>
    /// Get the chunk at the given location (if it's loaded)
    /// </summary>
    /// <param name="chunkLocation">the location of the chunk to get</param>
    /// <param name="withNeighbors">if we want to populate the chunks neighbors on get</param>
    /// <returns>the chunk data or null if there's none loaded</returns>
    IBlockChunk getChunk(Coordinate chunkLocation, bool withNeighbors = false);

    /// <summary>
    /// initialize this level with the center of loaded chunks fouced on the given location
    /// </summary>
    /// <param name="centerChunkLocation">the center point/focus of the loaded chunks, usually a player location</param>
    void initializeAround(Coordinate centerChunkLocation);

    /// <summary>
    /// Move the focus/central loaded point of the level
    /// </summary>
    /// <param name="direction">the direction to move the focus (moves it one chunk in this direction)</param>
    void adjustFocus(Directions.Direction direction);
  }
}