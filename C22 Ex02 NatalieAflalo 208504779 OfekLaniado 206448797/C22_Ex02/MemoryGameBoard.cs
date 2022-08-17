﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C22_Ex02
{
    public class MemoryGameBoard
    {
        private int m_NumOfColumns;
        private int m_NumOfRows;
        private char[,] m_MatrixGameBoard;
        private bool[,] m_FlippedBlocksMatrix;
        private int[] m_RandomLettersCounter;

        public MemoryGameBoard(int i_InputRows, int i_InputColumns)
        {
            m_NumOfRows = i_InputRows;
            m_NumOfColumns = i_InputColumns;
            m_MatrixGameBoard = new char[m_NumOfRows,m_NumOfColumns];
            m_FlippedBlocksMatrix = new bool[m_NumOfRows, m_NumOfColumns]
            m_RandomLettersCounter = new int[m_NumOfColumns * m_NumOfRows / 2];
            createRandomMatrix();
        }

        private void createRandomMatrix()
        {
            int counterOfCorrectValuesInMatrix = 0;
            Random rndCharForMatrix = new Random();
            char randomChar;

            for (int currentRow = 0; currentRow < m_NumOfRows; currentRow++)
            { 
                for (int currentColumn = 0; currentColumn < m_NumOfColumns; currentColumn++)
                {
                    while (m_MatrixGameBoard[currentRow, currentColumn] == '\0')
                    {
                        randomChar = (char)rndCharForMatrix.Next(65, 65 + (m_NumOfColumns * m_NumOfRows / 2));

                        if (m_RandomLettersCounter[((int)randomChar) - 65] < 2)
                        {
                            m_RandomLettersCounter[((int)randomChar) - 65]++;
                            m_MatrixGameBoard[currentRow, currentColumn] = randomChar;
                            counterOfCorrectValuesInMatrix++;
                        }
                    }
                }
            }

            //print test
            for (int i = 0; i < m_NumOfRows; i++)
            {
                for (int j = 0; j < m_NumOfColumns; j++)
                {
                    Console.Write(string.Format("{0} ", m_MatrixGameBoard[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}