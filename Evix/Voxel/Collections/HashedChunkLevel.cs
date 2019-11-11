using System.Collections.Generic;
using Evix.Voxel.Collections.BlockData;
using Evix.Voxel.Generation.BlockData;

namespace Evix.Voxel.Collections {

  /// <summary>
  /// A level that uses a dictionary to organize it's chunks
  /// </summary>
  /// <typeparam name="BlockStorageType"></typeparam>
  public abstract class HashedChunkLevel<BlockStorageType> : Level<BlockStorageType> where BlockStorageType : IBlockStorage {

    /// <summary>
    /// The active chunks, stored by coordinate location
    /// </summary>
    Dictionary<long, BlockStorageType> loadedChunks;

    /// <summary>
    /// Construct
    /// </summary>
    /// <param name="chunkBounds"></param>
    /// <param name="blockSource"></param>
    public HashedChunkLevel(
      Coordinate chunkBounds,
      IBlockSource blockSource
    ) : base(chunkBounds, blockSource) {
      loadedChunks = new Dictionary<long, BlockStorageType>(
        chunkBounds.x * chunkBounds.y * chunkBounds.z
      );
    }

    /// <summary>
    /// Get the chunk from the hash map
    /// </summary>
    /// <param name="chunkLocation"></param>
    /// <returns></returns>
    protected override IBlockStorage getChunkBlockData(Coordinate chunkLocation) {
      return chunkLocation.isWithin(chunkBounds)
        && chunkIsWithinkLoadedBounds(chunkLocation)
        && loadedChunks.ContainsKey(getChunkHash(chunkLocation))
          ? loadedChunks[getChunkHash(chunkLocation)]
          : default;
    }

    /// <summary>
    /// Set the given set of block data to the given chunk location
    /// </summary>
    /// <param name="chunkLocation"></param>
    /// <param name="blockData"></param>
    internal override void setChunkData(Coordinate chunkLocation, BlockStorageType blockData) {
      loadedChunks[getChunkHash(chunkLocation)] = blockData;
    }

    /// <summary>
    /// Remove the chunk at the given location
    /// </summary>
    /// <param name="chunkLocation"></param>
    internal override void removeChunk(Coordinate chunkLocation) {
      loadedChunks.Remove(getChunkHash(chunkLocation));
    }

    /// <summary>
    /// Get the hash key for the chunk's location
    /// todo: add property longHash to coordinate
    /// </summary>
    /// <returns></returns>
    long getChunkHash(Coordinate chunkLocation) {
      long hash = 0;
      hash |= ((short)chunkLocation.x);
      hash |= (((short)chunkLocation.y) << 16);
      hash |= (((short)chunkLocation.z) << 24);

      return hash;
    }
  }
}