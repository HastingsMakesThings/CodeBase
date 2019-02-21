using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Framework.Interfaces.Managers;
using Microsoft.Xna.Framework;

namespace Game1.Framework.Managers
{
    class SATCollision : ISATCollision
    {
        //The purpose of this class is to identifiy when a collision has occured 

        public SATCollision()
        {
            //Constructor Code
        }
        //The purpose of this method is to identify when a collision has occured. The Method takes in an array of vectors whch are the vertexes for each shape, Th emethod themn passes through each array and 
        public Vector2 TestCollisionSignle(Vector2[] shapeA, Vector2[] shapeB)
        {
            //Deffines a variable for the miinimum translation vector
            Vector2 minTransVec;

            //Deffines a variable for the direction of the MTV
            Vector2 mtvNormal = new Vector2();

            //Deffines a float for the magnitude of the MTV
            float mtvMag =0;

            //Inisiate a for loop to cycle through each vertex in the list
            for(int i = 0; i < shapeA.Length; i++)
            {
                int ii = i + 1;

                //identifies if i is at max, if so then ii is set to 0
                if(ii == shapeA.Length)
                {
                    ii = 0;
                }

                //This calls the seperationAxisCalculator method to generate a seperation vector

                Vector2 mSepAxis = SeperationAxisCalculator(shapeA[i], shapeA[ii]);

                //This calls the shape projection method to identify the greatest shape projection of shape A onto the seperation axis
                float[] aProj = ShapeProjection(shapeA, mSepAxis);

                //this calls the shape projection method to identify the greatest shape projection of shape B onto the sepearation axis
                float[] bProj = ShapeProjection(shapeB, mSepAxis);

                //this calculates the midpoint of each shape as a value.
                float aMean = (aProj.Sum()*0.5f);

                float bMean = (bProj.Sum() * 0.5f);

                float directionMultiplier;
                //this detects which side are the shapes on relative to eachother on the seperation axis
                if(aMean >= bMean)
                {
                    directionMultiplier = 1;
                }
                else
                {
                    directionMultiplier = -1;
                }
                //This method finds the overlap between the two objects if it is negative the shapes are not colliding 
                float mOverlap = FindOverlap(aProj, bProj);

                //if there is no collision the loop is broken and a zero vector2 is returned
                if (mOverlap <= 0)
                {
                    return Vector2.Zero;
                }

                //this checks if the loop has been run before, if not the values for mtvMag and Normal are set
                if(i == 0)
                {
                    mtvNormal = mSepAxis;

                    mtvMag = mOverlap * directionMultiplier;
                }
                // if not, if the overlap is less than the mtvMag then the sep axis and magnitude of the mtv are set
                else if(Math.Abs(mtvMag) > mOverlap)
                {
                    mtvNormal = mSepAxis;

                    mtvMag = mOverlap* directionMultiplier;
                }   
            }

            
            minTransVec = Vector2.Multiply(mtvNormal, mtvMag);

            
            return minTransVec;
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
            sepAxCalc.Y = (nY* -1); //This is multiplied by -1 to swap its sign as this is required to create a vector normal

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

        //The purpose of this method is to cycle through the vertexes of a shape and determine if they are the minimum or maximum values of the shape's projection onto the seperation axis. A vector for the shape projection is the returned to the caller
        private float[] ShapeProjection(Vector2[] pVerticies, Vector2 pSepAxis)
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

            //create a new vector array to hold the minimum and maximum values for the shape projection
            float[] vectValues = new float[2];

            //Sets the first value of the vectValues array to the Minimum value
            vectValues[0] = dotMin;

            //Sets the second value of the vectValues array to the Maximum value
            vectValues[1] = dotMax;

            //this retursn the minimum and maximum vertexes that give the greatest shape projection onto the seperation axis 
            return vectValues;

        }

        //The function of this method is to find the overlap of two vectors onto a seperation axis and return a float value of that overlap
        private float FindOverlap(float[] vertsA, float[] vertsB)
        {
            // Creates a float value to return to caller
            float overlapVal = 0;

            //Creates a collection of vectors to hold the dot values of both shapes
            float aMinVert = vertsA[0];
            float aMaxVert = vertsA[1];

            float bMinVert = vertsB[0];
            float bMaxVert = vertsB[1];

            float maxValue;
            float minValue;
            //finds the larger of the two max values
            if (aMaxVert > bMaxVert)
            {
                 maxValue = aMaxVert;
            }
            else
            {
                 maxValue = bMaxVert;
            }

            //finds the smallest of the two min values
            if(aMinVert < bMinVert)
            {
                 minValue = aMinVert;
            }
            else
            {
                 minValue = bMinVert;
            }

            //The overlap is equal to the length of  ((aMax - aMin) + (bMax - bMin) - (distance between The minimum value and maximum value))
             overlapVal = (((aMaxVert - aMinVert) + (bMaxVert - bMinVert)) - (maxValue - minValue));

            
            return overlapVal;
        }

    }
}
