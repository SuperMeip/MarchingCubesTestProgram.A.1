/// <summary>
/// A wavy, hilly block source
/// </summary>
public class WaveSource : BlockSource {

  protected override float getNoiseValueAt(Coordinate location) {
    return location.y - noise.GetPerlin(location.x / 0.1f, location.z / 0.1f).GenMap(-1, 1, 0, 1) * 10 - 10;
  }
}

public static class WaveSourceUtiliy {

  /// <summary>
  /// Map values for terrain generation
  /// </summary>
  /// <param name="value"></param>
  /// <param name="x1"></param>
  /// <param name="y1"></param>
  /// <param name="x2"></param>
  /// <param name="y2"></param>
  /// <returns></returns>
  public static float GenMap(this float value, float x1, float y1, float x2, float y2) {
    return (value - x1) / (y1 - x1) * (y2 - x2) + x2;
  }
}