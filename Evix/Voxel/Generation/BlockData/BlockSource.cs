﻿using Evix.Voxel.Blocks;
using Evix.Voxel.Collections.BlockData;

namespace Evix.Voxel.Generation.BlockData {

  /// <summary>
  /// Base class for a block source
  /// </summary>
  public abstract class BlockSource : IBlockSource {

    /// <summary>
    /// 
    /// </summary>
    public static int BlocksGenerated = 0;

    /// <summary>
    /// The generation seed
    /// </summary>
    public int seed {
      get;
      protected set;
    }

    /// <summary>
    /// The noise generator used for this block source
    /// </summary>
    protected Noise.FastNoise noise { get; }

    /// <summary>
    /// The density threshold of the isosurface, clamped to 0->1
    /// </summary>
    public float isoSurfaceLevel {
      get;
      protected set;
    }

    /// <summary>
    /// Create a new block source
    /// </summary>
    public BlockSource(int seed = 1234) {
      this.seed = seed;
      noise = new Noise.FastNoise(seed);
      setUpNoise();
    }

    /// <summary>
    /// Must be implimented, get the noise density float (0 -> 1) for a given point
    /// </summary>
    /// <param name="location">the x y z to get the iso density for</param>
    /// <returns></returns>
    protected abstract float getNoiseValueAt(Coordinate location);

    /// <summary>
    /// Function for setting up noise before generation
    /// </summary>
    protected virtual void setUpNoise() { }

    /// <summary>
    /// Generate all the blocks in the given collection with this source
    /// </summary>
    /// <param name="blockData"></param>
    public void generateAll(IBlockStorage blockData) {
      generateAllAt(Coordinate.Zero, blockData);
    }

    /// <summary>
    /// Generate the given set of blockdata at the given location offset
    /// </summary>
    /// <param name="location">The xyz to use as an offset for generating these blocks</param>
    /// <param name="blockData">The block data to populate</param>
    public void generateAllAt(Coordinate location, IBlockStorage blockData) {
      isoSurfaceLevel = getIsoSurfaceLevel();
      Coordinate.Zero.until(blockData.bounds, (coordinate) => {
        BlocksGenerated++;
        Coordinate globalLocation = coordinate + (location * blockData.bounds);
        float isoSurfaceDensityValue = getNoiseValueAt(globalLocation);
        Block.Type newBlockType = getBlockTypeFor(isoSurfaceDensityValue);
        if (newBlockType != Block.Types.Air) {
          blockData.setBlock(coordinate, newBlockType);
        }
      });
    }

    /// <summary>
    /// Get the block type for the density
    /// </summary>
    /// <param name="isoSurfaceDensityValue"></param>
    /// <returns></returns>
    protected virtual Block.Type getBlockTypeFor(float isoSurfaceDensityValue) {
      return isoSurfaceDensityValue < isoSurfaceLevel
        ? Block.Types.Air
        : Block.Types.Stone;
    }

    /// <summary>
    /// Must be implimented, get the value to use as the iso surface level
    /// </summary>
    /// <returns></returns>
    protected virtual float getIsoSurfaceLevel() {
      return 0.5f;
    }
  }
}