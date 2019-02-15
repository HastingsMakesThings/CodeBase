using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Managers
{
    class SATCollision
    {
        //The purpose of this class is to identifiy when a collision has occured 

        public SATCollision()
        {
            //Constructor Code
        }

        //The function of this vector method is to calculate a normalized vector to be used as the seperation axis 
        private Vector2 SeperationAxisCalculator(Vector2 pVertexA, Vector2 pVertexB)
        {
            //Creates a new vector that will act as the seperation axis
            Vector2 sepAxCalc = new Vector2();

            //Calls the edge calculation method to return a vector
            sepAxCalc = EdgeCalculator(pVertexA, pVertexB);

            //Converts the dege into a normal by fliping the values for X and Y to create a vector perpandicular to the origional vector
            float nX = sepAxCalc.Y;
            float nY = sepAxCalc.X;

            sepAxCalc.X = nX;
            sepAxCalc.Y = nY;

            //Normalizes this edge normal and returns it to caller.
            Vector2 sepAxis = Vector2.Normalize(sepAxCalc);

            return sepAxis;
        }

        //Edge Calculator is used to calculate the edge of a shape using the positions of two vertexes.
        private Vector2 EdgeCalculator(Vector2 pVertexA, Vector2 pVertexB)
        {
            //Creates a new edge vector that will be returned 
            Vector2 edgeValue = new Vector2();

            //Sets the vector to become the line between these two vector points
            edgeValue.X = (pVertexA.X - pVertexB.X);
            edgeValue.Y = (pVertexA.Y - pVertexB.Y);

            return edgeValue;
        }

        //The purpose of this method is to cycle through the vertexes of a shape and determine if they are the minimum or maximum values of the shape's projection onto the seperation axis. 
        //A vector for the shape projection is the returned to the caller
        private Vector2 ShapeProjection(Vector2[] pVerticies, Vector2 pSepAxis)
        {
            //Declare own variable to store the seperation axis
            Vector2 mSepAxis = pSepAxis;

            //Declare values for the minimum and maximum vector points
            Vector2 vertMin = new Vector2();
            Vector2 vertMax = new Vector2();

            //Declare float values to check if the max and min values of the vertex 
            float dotMin = 0;
            float dotMax = 0;

            //Sets up for loop to cycle through the vertexes of the shape
            for(int i = 0; i < pVerticies.Length; i++)
            {
                //calls the dot method to find the dot product of the vertex and the seperaton axis
                float tempVertDot = Vector2.Dot(pVerticies[i], mSepAxis);

                //this checks if the  tempVertDot is less than dotMin or has not been changed yet and then sets the min dot and vert to the values of pVerticies[i]
                if (i == 0|| dotMin >= tempVertDot)
                {
                    dotMin = tempVertDot;
                    vertMin = pVerticies[i];
                }

                //this checks if the  tempVertDot is greater than dotMax or has not been changed yet and then sets the Max dot and vert to the values of pVerticies[i]
                if (i == 0 || dotMax <= tempVertDot)
                {
                    dotMax = tempVertDot;
                    vertMax = pVerticies[i];
                }
            }

            //create a new vector to hold the shape's projection vector
            Vector2 projectionVect = EdgeCalculator(vertMax, vertMin);

            return projectionVect;
        }

         
    }
}
