using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Randoms.Fun 
{
    using Editor = UnityEditor.Editor;
    
    [CustomEditor (typeof (UnityEngine.Object),true)]
    [CanEditMultipleObjects]
    public class TicTacToe : Editor
    {
        private bool canPlayTicTacToe = false;
        private static readonly char defaultCharSet = '^';
        private PlayerTurnType playerTurnType;
        private Matrix matrix;
        private bool   hasWinner;
        private readonly Dictionary <PlayerTurnType, char> playerBox = new Dictionary<PlayerTurnType, char> ();

        private static readonly List <((int,int),(int,int),(int,int))> lines = new List<((int,int),(int,int),(int,int))>
        {
            ((0,0), (0,1), (0,2)),
            ((1,0), (1,1), (1,2)),
            ((2,0), (2,1), (2,2)),
            ((0,0), (1,0), (2,0)),
            ((0,1), (1,1), (2,1)),
            ((0,2), (1,2), (2,2)),
            ((0,0), (1,1), (2,2)),
            ((0,2), (1,1), (2,0))
        };
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        void OnEnable()
        {
            (playerBox [PlayerTurnType.PlayerX],playerBox [PlayerTurnType.PlayerY]) = ('X', '0');
            matrix = new Matrix (defaultCharSet);
            playerTurnType = PlayerTurnType.PlayerX;
            canPlayTicTacToe = true;
            hasWinner = false;
        }

        /// <summary>
        /// Overrides Editor Default function to draw custom GUI
        /// </summary>
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector ();
            Util
            .Decorator
            (
                Splash,
                ShowUI,
                RenderGame
            );
        }

        /// <summary>
        /// Splash Screen
        /// </summary>
        private void Splash ()
        {
            if 
            (
                GUILayout.Button ($"{(!canPlayTicTacToe ? "Play" : "Close")} TIC-TAC-TOE", EditorStyles.miniButtonMid)
            )
            {
                canPlayTicTacToe = !canPlayTicTacToe;  
            }
        }


        /// <summary>
        /// Renderers Game UI
        /// </summary>
        private void ShowUI ()
        {
            if (!canPlayTicTacToe) return;

            GUILayout.Space (10);
            if (!hasWinner)
            {
                GUILayout.Label ($"{playerTurnType.ToString ()} Turn", EditorStyles.boldLabel);
            }
            else 
            {
                GUILayout.Label ($"{playerTurnType.ToString ()} Won", EditorStyles.boldLabel);
            }
        }

        /// <summary>
        /// Renderers Tic-Tac-Toe Matrix
        /// </summary>
        private void RenderGame ()
        {
            if (!canPlayTicTacToe || hasWinner) return;
            GUILayout.Space (10);

            int rowSize = matrix.matrix.GetLength (0);
            int colSize = matrix.matrix.GetLength (1);

            for (int x = 0 ; x < rowSize; x += 1)
            {
                GUILayout.BeginHorizontal ();
                {
                    for (int y = 0 ; y < colSize; y += 1)
                    {
                        GUILayout.Space (10);
                        if 
                        (
                            GUILayout.Button (matrix.matrix [x,y] + "", EditorStyles.miniButtonMid)
                        )
                        {
                            if (
                                matrix.GetCell(x,y) != playerBox [PlayerTurnType.PlayerX] 
                                &&
                                matrix.GetCell(x,y) != playerBox [PlayerTurnType.PlayerY]  
                            )
                            {
                                matrix.SetCell (x,y, playerBox [playerTurnType]);
                                GetWinner ();
                                if (!hasWinner)
                                {
                                    playerTurnType = playerTurnType == PlayerTurnType.PlayerX ?  PlayerTurnType.PlayerY : PlayerTurnType.PlayerX;
                                }
                            }
                        }
                    }
                }
                GUILayout.EndHorizontal();
            }
        }

        /// <summary>
        /// Calculates Game Winner
        /// </summary>
        private void GetWinner ()
        {
           int rowSize = matrix.matrix.GetLength (0);
           int colSize = matrix.matrix.GetLength (1);

            foreach (var line in lines)
            {
                var (a,b,c) = line;

                var (aX,aY) = a;
                var (bX,bY) = b;
                var (cX,cY) = c;
                
                if (
                    matrix.matrix [aX, aY] != defaultCharSet
                    &&
                    matrix.matrix [aX, aY] == matrix.matrix [bX, bY]
                    &&
                    matrix.matrix [aX, aY] == matrix.matrix [cX, cY]
                )
                {
                    hasWinner = true;
                    return;
                }
            }

            if (!matrix.AnyOf (defaultCharSet, (defaultChar, matrixChar) => {
                return defaultChar == matrixChar;
            }))
            {
                GUILayout.Label ("Match Has been Tied :-(", EditorStyles.helpBox);
            }
        }
    }

    public class Matrix
    {
        public Matrix (char defaultChar = '^')
        {
            for (int i = 0 ; i < matrix.GetLength (0); i += 1)
            {
                for (int j = 0 ; j < matrix.GetLength (1); j += 1)
                {
                   matrix [i,j] =  defaultChar;
                }
            }
        }

        /// <summary>
        /// Sets Cell Value
        /// </summary>
        public void SetCell (int x, int y, char newChar)
        {
            matrix [x,y] = newChar;
        }

        /// <summary>
        /// Sets Cell
        /// </summary>
        public char GetCell (int x, int y) => matrix [x,y];
        
        /// <summary>
        /// Returns true if given char founds in matrix 
        /// </summary>
        public bool AnyOf (char charToCompare, System.Func <char, char, bool> filter)
        {
            for (int i = 0 ; i < matrix.GetLength (0); i += 1)
            {
                for (int j = 0 ; j < matrix.GetLength (1); j += 1)
                {
                    if (filter (charToCompare, matrix [i,j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public readonly char[,] matrix  = new char [3,3];
    }

    /// Util
    public static class Util 
    {
        public static void Decorator (params System.Action[] actions )
        {
            foreach (var action in actions)
            {
                action.Invoke ();
            }
        }
    }

    public enum PlayerTurnType
    {
        PlayerX,
        PlayerY
    }

}


