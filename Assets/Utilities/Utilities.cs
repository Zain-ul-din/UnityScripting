using UnityEngine;

namespace  Randoms.Utilities {
  
  /// Basic Utilities to boost up Unity work flow  
  public static class Util {
    
    /* Vector simplifier */
    public static Vector3 Vector (float x, float y, float z) => new Vector3 (x, y, z);
    public static Vector3 VectorX (Transform transform, float x) => new Vector3 (x, transform.position.y, transform.position.z);
    public static Vector3 VectorY (Transform transform, float y) => new Vector3 (transform.position.x, y, transform.position.z);
    public static Vector3 VectorZ (Transform transform, float z) => new Vector3 (transform.position.x, transform.position.y, z);
    public static Vector3 VectorXY (Transform transform, float x, float y) => new Vector3 (x, y, transform.position.z);
    public static Vector3 VectorXZ (Transform transform, float x, float z) => new Vector3 (x, transform.position.y, z);
    public static Vector3 VectorYZ (Transform transform, float y, float z) => new Vector3 (transform.position.x, y, z);
        
    public static Vector3 VectorX (Vector3 vector, float x) => new Vector3 (x, vector.y, vector.z);
    public static Vector3 VectorY (Vector3 vector, float y) => new Vector3 (vector.x, y, vector.z);
    public static Vector3 VectorZ (Vector3 vector, float z) => new Vector3 (vector.x, vector.y, z);
    public static Vector3 VectorXY (Vector3 vector, float x, float y) => new Vector3 (x, y, vector.z);
    public static Vector3 VectorXZ (Vector3 vector, float x, float z) => new Vector3 (x, vector.y, z);
    public static Vector3 VectorYZ (Vector3 vector, float y, float z) => new Vector3 (vector.x, y, z);


  }
}



