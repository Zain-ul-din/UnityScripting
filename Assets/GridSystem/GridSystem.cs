using Randoms.Utilities;
using UnityEngine;

namespace Randoms.GridSystem {
    /// <summary>
    /// Grid System
    /// </summary>
    public class GridSystem {
        private int height;
        private int width;
        private float cellSize;
        
        public GridSystem (int height, int width, float cellSize) {
            this.height = height;
            this.width = width;
            this.cellSize = cellSize;
            DrawGrid();
        }

        private void DrawGrid( ) {
            for (int x = 0; x <= width; x += 1) {
                for (int z = 0; z <= height; z += 1) {
                    // draw lines vertically
                    if ((z + 1) <= height) {
                        var startPosY = Util.VectorXZ(Vector3.zero, x, z) * cellSize;
                        var endPosY = (Util.VectorXZ(Vector3.zero, x, z + 1) * cellSize);
                        Debug.DrawLine(startPosY, endPosY, Color.white, 1000f);
                    }
                    
                    // draw lines horizontally
                    if ((x + 1) <= width) {
                        var startPosX = Util.VectorXZ(Vector3.zero, x, z) * cellSize;
                        var endPosX = (Util.VectorXZ(Vector3.zero, x + 1, z) * cellSize);
                        Debug.DrawLine(startPosX, endPosX, Color.white, 1000f);
                    }
                }
            }
        }
    }
}

