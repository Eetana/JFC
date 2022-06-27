using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

/*
 *  CRISP BILLBOARD AID
 */
namespace TeklaBillboardAid
{
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            MyModel = new Model();
            modelParameters = new ModelParameters();
        }

        private readonly Model MyModel;
        public ModelParameters modelParameters;

        private void BuildButton_Click(object sender, EventArgs e) {

            // Disable build button until validated again
            button1.Enabled = false;

            // Check that the program is connected to tekla
            if (!MyModel.GetConnectionStatus())
            {
                MessageBox.Show("Tekla not running");
                return;
            }

            // initial offset
            double xOffset = 0;

            // Create a list of x coordinates for the planes / spacings between the columns from engineering drawings
            List<double> xCoordinates = modelParameters.XCoordinates;

            // Offset of each cabinet in the z-axis (Size)
            List<double> zCoordinates = modelParameters.ZCoordinates;

            // Create a variable for the mesh thickness 
            double meshThickness = modelParameters.MeshThickness;

            // B3 Dimensions
            double[] B3Dimensions = BeamDimensions(modelParameters.B3Profile);
            double B3BeamWidth = B3Dimensions[1];

            // Dimensions for B1 
            double[] B1Dimensions = BeamDimensions(modelParameters.B1Profile);
            double B1BeamWidth = B1Dimensions[0];
            double B1BeamDepth = B1Dimensions[1];

            // Dimensions for B2 
            double[] B2Dimensions = BeamDimensions(modelParameters.B2Profile);
            double B2BeamWidth = B2Dimensions[1];

            // Dimensions for BR1 
            double[] BR1Dimensions = BeamDimensions(modelParameters.BR1Profile);
            double BR1BeamDepth = BR1Dimensions[0];
            double BR1BeamWidth = BR1Dimensions[1];

            // B5 Dimensions
            double[] B5Dimensions = BeamDimensions(modelParameters.B5Profile);
            double B5BeamDepth = B5Dimensions[0];
            double B5BeamWidth = B5Dimensions[1];

            // Dimensions for C1
            double[] C1Dimensions = BeamDimensions(modelParameters.C1Profile);
            double C1BeamDepth = C1Dimensions[0];
            double C1BeamWidth = C1Dimensions[1];

            // Dimensions for EA
            double[] EADimensions = BeamDimensions(modelParameters.EAProfile);
            double EAbeamDepth = EADimensions[0];
            double EAbeamWidth = EADimensions[1];

            // Dimensions for waler
            double[] WalerDimensions = BeamDimensions(modelParameters.WalerProfile);
            double WalerBeamDepth = WalerDimensions[0];
            double WalerBeamWidth = WalerDimensions[1];

            // Dimensions for z-bracket
            double[] zBracketDimensions = BeamDimensions(modelParameters.BracketProfile);
            double zBracketThickness = zBracketDimensions[0];
            double zBracketWidth = zBracketDimensions[1];

            // Difference between depth of B1 and B5
            double differenceb1b5Depth = B1BeamDepth - B5BeamDepth;

            // Initialise the height coordinates or altitude location based on the engineering drawing 
            // We add the mesh thickness and subtract the difference in depth between b1 and b5 from the user since the dimensions ar given from the top of the mesh int he engineering drawing 
            List<double> railingCoordinates = modelParameters.RailingCoordinates;


            // These values are taken from the engineering drawing
            double screenLength = 0;
            foreach (double x in xCoordinates)
            {
                screenLength += x;
            }

            double billboardDepth = modelParameters.WalkwayWidth + (2 * modelParameters.WalkwayClearance) + (2 * B1BeamWidth); // TODO: Verify it's width
            BillBoardDepth.Text = billboardDepth.ToString();

            List<Frame> planes = new List<Frame>(); // Storing each plane (of each x offset)

            // Setting screenHeight variable to 0 and then looping through the z coordinates and summing them toghether to get the screen height height 
            double screenHeight = 0;
            foreach (double coordinate in zCoordinates)
            {
                screenHeight += coordinate;
            }

            // Adding the screen height to double the b1 beam depth with the top and bottom height offset to get the overall height of the billboard.
            double billboardHeight = screenHeight + modelParameters.HeightOffsetTop + modelParameters.HeightOffsetBottom + B1BeamDepth * 2; 

            // Display information on GUI
            modelParameters.BillboardHeight = billboardHeight;
            modelParameters.BillboardLength = screenLength + C1BeamWidth;
            BillBoardHeight.Text = modelParameters.BillboardHeight.ToString();
            BillBoardLength.Text = modelParameters.BillboardLength.ToString();

            // Loop through the indexes of the xCoordinates list to set identifying values for the planeType variable 
            // I.e. loops through integers from 0 to number of inputs in xCoordinates list 
            for (int indexX = 0; indexX < xCoordinates.Count; indexX++)
            {
                // Initial plane
                int planeType;

                // if first plane, it is type (0)
                if (indexX == 0)
                {
                    planeType = 0;
                }
                // If last plane ( count -1 for index = 10), index start from 0
                else if (indexX == xCoordinates.Count - 1)
                {
                    planeType = 2;
                }
                // All other planes are in between
                else
                {
                    planeType = 1;
                }

                // Total offset for the current plane
                xOffset += xCoordinates[indexX];

                // The four points of a plane
                TSG.Point point1 = new TSG.Point(xOffset, 0, 0);
                TSG.Point point2 = new TSG.Point(xOffset, billboardDepth, 0);
                TSG.Point point3 = new TSG.Point(xOffset, billboardDepth, billboardHeight);
                TSG.Point point4 = new TSG.Point(xOffset, 0, billboardHeight);

                // Create a plane and store this plane
                Frame plane = new Frame(point1, point2, point3, point4, planeType, modelParameters);
                planes.Add(plane);
            }

            // B1 beams across, 2 bottom, 2 top
            // Created array of Y and Z coordinates such that the distance between parallel B1 beams is correct as per the engineering drawing/user input
            // Array of coordinates also ensure B1 beams are created at desired location at model origin
            double[] b1Ycoordinates = { 0 + 0.5 * B1BeamWidth, billboardDepth - 0.5 * B1BeamWidth };
            double[] b1Zcoordinates = { 0, billboardHeight - B1BeamDepth };

            // Create the enums and the offsets for the b1 beams
            int[] b1Enums = new int[] { 2, 0, 0 };
            double[] b1Offsets = new double[] { 0.0, 0.0, 0.0 };

            foreach (double y in b1Ycoordinates)
            {
                foreach (double z in b1Zcoordinates)
                {
                    CreateBeam(
                        new TSG.Point(0, y, z),
                        new TSG.Point(screenLength + C1BeamWidth, y, z),
                        modelParameters.B1Material,
                        modelParameters.B1Profile,
                        "11",
                        b1Enums,
                        b1Offsets
                    );
                }
            }

            // THIS CODE IS FOR THE HORIZTONAL RAILINGS //
            // Offset for the welds that shortens members (spacing between connecting members)
            double weldOffset = modelParameters.WeldOffset;

            // Initialise the spacing variables for the horisztonal railings 
            double xRailingSpacingCurrent = 0;
            double zRailingSpacing = meshThickness - differenceb1b5Depth;

            // Create coordinates that can be used to offset the horizontal railings (also include the welding offset)
            double railingOffsetX = C1BeamWidth;
            double railingOffsetY = B3BeamWidth;
            double railingOffsetZ = 0; // This variable has been kept in case the spacing inputs need to be changed to be from outer edge to edge 

            // Create the enums and offsets for the railings
            int[] railingEnums = new int[] { 2, 0, 2 };
            double[] railingOffsets = new double[] { 0.0, 0.0, 90 };

            // Create a list for the z-coordinates of the railings so that they can be used in the insertion of the side railings (coordinates from bottom to top)
            List<double> zCoordinatesForSideBracings = new List<double> { 0 };

            // Create the horizontal railings //
            // Loop through the integers 0 to the length of the xCoordinates array less 1 
            for (int indexXcoordinates = 0; indexXcoordinates < (xCoordinates.Count - 1); indexXcoordinates++)
            {
                // Calculate the current x coordinate and the next x coordinate using the spacings 
                xRailingSpacingCurrent += xCoordinates[indexXcoordinates];
                double xRailingSpacingNext = xRailingSpacingCurrent + xCoordinates[indexXcoordinates + 1];

                // Loop through the railing coordinates 
                for (int i = 0; StructureManualRadio.Checked == true ? i < railingCoordinates.Count : i < 2; i++)
                {
                    // Calculate the spacing
                    zRailingSpacing += railingCoordinates[i];


                    // Only add to the zCoordinates list one time
                    if (indexXcoordinates == 0)
                    {
                        // Add the next railings z-coordinate into the z-coordinate list for the railings
                        zCoordinatesForSideBracings.Add(zRailingSpacing);
                    }

                    // Insert the beams
                    CreateBeam(
                        new TSG.Point(xRailingSpacingCurrent + railingOffsetX + weldOffset, billboardDepth - railingOffsetY, zRailingSpacing + railingOffsetZ),
                        new TSG.Point(xRailingSpacingNext - weldOffset, billboardDepth - railingOffsetY, zRailingSpacing + railingOffsetZ),
                        modelParameters.B3Material,
                        modelParameters.B3Profile,
                        "5",
                        railingEnums,
                        railingOffsets
                    );

                    // Check if it's the first x coordinate i.e. 0
                    if (indexXcoordinates == 0)
                    {
                        // Insert the side beams
                        CreateBeam(
                            new TSG.Point(xCoordinates[indexXcoordinates] + B3BeamWidth, 0 + C1BeamDepth + weldOffset, zRailingSpacing + railingOffsetZ),
                            new TSG.Point(xCoordinates[indexXcoordinates] + B3BeamWidth, billboardDepth - C1BeamDepth - weldOffset, zRailingSpacing + railingOffsetZ),
                            modelParameters.B3Material,
                            modelParameters.B3Profile,
                            "5",
                            railingEnums,
                            railingOffsets
                        );
                    }

                    // If it's at the final coordinate
                    else if (indexXcoordinates == (xCoordinates.Count - 2))
                    {
                        //Insert the side beams
                        CreateBeam(
                           new TSG.Point(xRailingSpacingNext + B3BeamWidth + (C1BeamWidth - B3BeamWidth), 0 + C1BeamDepth + weldOffset, zRailingSpacing + railingOffsetZ),
                           new TSG.Point(xRailingSpacingNext + B3BeamWidth + (C1BeamWidth - B3BeamWidth), billboardDepth - C1BeamDepth - weldOffset, zRailingSpacing + railingOffsetZ),
                           modelParameters.B3Material,
                           modelParameters.B3Profile,
                           "5",
                           railingEnums,
                           railingOffsets
                       );
                    }
                }

                // If automatic beam spacing, run this
                if (StructureAutoRadio.Checked == true)
                {
                    // Get remaining spacing
                    double totalHorizontalBeamSpacing = (billboardHeight - B1BeamDepth - 0.5 * B1BeamDepth) - zRailingSpacing;

                    // Calculate number of beams needed
                    int numberOfHorizontalBeams = (int)Math.Floor(totalHorizontalBeamSpacing / 1200);

                    // Get the middle distance of each spacing for each beam
                    double horizontalBeamSpacing = totalHorizontalBeamSpacing / (numberOfHorizontalBeams + 1);
                    for (int i = 0; i < numberOfHorizontalBeams; i++)
                    {
                        // Calculate the spacing
                        zRailingSpacing += horizontalBeamSpacing;

                        // Only add to the zCoordinates list one time
                        if (indexXcoordinates == 0)
                        {
                            // Add the next railings z-coordinate into the z-coordinate list for the railings
                            zCoordinatesForSideBracings.Add(zRailingSpacing);
                        }

                        CreateBeam(
                            new TSG.Point(xRailingSpacingCurrent + railingOffsetX + weldOffset, billboardDepth - railingOffsetY, zRailingSpacing + railingOffsetZ),
                            new TSG.Point(xRailingSpacingNext - weldOffset, billboardDepth - railingOffsetY, zRailingSpacing + railingOffsetZ),
                            modelParameters.B3Material,
                            modelParameters.B3Profile,
                            "5",
                            railingEnums,
                            railingOffsets
                        );

                        // Check if it's the first x coordinate i.e. 0
                        if (indexXcoordinates == 0)
                        {
                            // Insert the side beams
                            CreateBeam(
                                new TSG.Point(xCoordinates[indexXcoordinates] + B3BeamWidth, 0 + C1BeamDepth + weldOffset, zRailingSpacing + railingOffsetZ),
                                new TSG.Point(xCoordinates[indexXcoordinates] + B3BeamWidth, billboardDepth - C1BeamDepth - weldOffset, zRailingSpacing + railingOffsetZ),
                                modelParameters.B3Material,
                                modelParameters.B3Profile,
                                "5",
                                railingEnums,
                                railingOffsets
                            );
                        }

                        // If it's at the final coordinate
                        else if (indexXcoordinates == (xCoordinates.Count - 2))
                        {
                            //Insert the side beams
                            CreateBeam(
                                new TSG.Point(xRailingSpacingNext + B3BeamWidth + (C1BeamWidth - B3BeamWidth), 0 + C1BeamDepth + weldOffset, zRailingSpacing + railingOffsetZ),
                                new TSG.Point(xRailingSpacingNext + B3BeamWidth + (C1BeamWidth - B3BeamWidth), billboardDepth - C1BeamDepth - weldOffset, zRailingSpacing + railingOffsetZ),
                                modelParameters.B3Material,
                                modelParameters.B3Profile,
                                "5",
                                railingEnums,
                                railingOffsets
                            );
                        }
                    }
                }

                // Set the z spacing equal to 0 each time in the loop 
                zRailingSpacing = meshThickness - differenceb1b5Depth;
            }

            // THIS CODE IS FOR THE WALERS //

            // Spacings for the top and bottom walers
            // From the bottom of the billboard to the top of the bottom waler
            double bottomWalerSpacing = modelParameters.LowerWalerSpacing;

            // From the top of the billboard to the top of the uppermost waler
            double topWalerSpacing = modelParameters.UpperWalerSpacing;

            // Create a list for the middle waler spacings
            // Spacing is from the top edge of the lower waler to the top edge of the waler above
            List<double> walermiddleSpacings = modelParameters.WalersCoordinates;

            // Set the enums for the walers
            int[] walerEnums = new int[] { 2, 2, 0 };
            double[] walerOffsets = new double[] { 0.0, 0.0, 90 };


            // Create the bottom waler
            Beam bottomWaler = CreateBeam(
                new TSG.Point(0, billboardDepth, bottomWalerSpacing - B1BeamDepth),
                new TSG.Point(screenLength + C1BeamWidth, billboardDepth, bottomWalerSpacing - B1BeamDepth),
                modelParameters.WalerMaterial,
                modelParameters.WalerProfile,
                "3",
                walerEnums,
                walerOffsets
            );

            // Create the Top waler
            Beam topWaler = CreateBeam(
                new TSG.Point(0, billboardDepth, billboardHeight - B1BeamDepth - topWalerSpacing),
                new TSG.Point(screenLength + C1BeamWidth, billboardDepth, billboardHeight - B1BeamDepth - topWalerSpacing),
                modelParameters.WalerMaterial,
                modelParameters.WalerProfile,
                "3",
                walerEnums,
                walerOffsets
            );

            // Create a list of waler beams so they can be bolted to the z-brackets 
            List<Beam> walerBeams = new List<Beam> { bottomWaler };

            // Initialise a z coordinate fot the middle walers
            double walerZcoordinate = bottomWalerSpacing - B1BeamDepth;

            // Create a list for the z-coordinates of the walers so that they can be used in the insertion of the z-brackets (coordinates from bottom to top)
            List<double> zCoordinatesForZBrackets = new List<double> { walerZcoordinate };

            // Check if the user input is selected as manual 
            if (!modelParameters.WalerAuto)
            {
                // Loop through the waler spacings 
                for (int walerSpacingIndex = 0; walerSpacingIndex <= walermiddleSpacings.Count - 1; walerSpacingIndex++)
                {
                    // Build the walers
                    Beam waler = CreateBeam(
                        new TSG.Point(0, billboardDepth, walerZcoordinate + walermiddleSpacings[walerSpacingIndex]),
                        new TSG.Point(screenLength + C1BeamWidth, billboardDepth, walerZcoordinate + walermiddleSpacings[walerSpacingIndex]),
                        modelParameters.WalerMaterial,
                        modelParameters.WalerProfile,
                        "3",
                        walerEnums,
                        walerOffsets
                    );

                    // Update the z coordinate
                    walerZcoordinate += walermiddleSpacings[walerSpacingIndex];

                    // Add the next waler z-coordinate into the z-coordinate list for the z brackets
                    zCoordinatesForZBrackets.Add(walerZcoordinate);

                    // Add the next waler beam to the waler beam list for bolting purposes
                    walerBeams.Add(waler);
                }
            }

            // If the user input is selected as automatic
            else
            {
                // Calculating the distance between the top and bottom waler
                double topBottomWalerSpacing = billboardHeight - bottomWalerSpacing - topWalerSpacing;

                // The number of middle walers to be added
                int numberOfWalers = modelParameters.WalersNumber;

                // Calculate the spacing between the walers
                double walerBeamSpacing = topBottomWalerSpacing / (numberOfWalers + 1);

                // Loop through the number of walers
                for (int i = 0; i < numberOfWalers; i++)
                {
                    // Build the walers
                    Beam waler = CreateBeam(
                        new TSG.Point(0, billboardDepth, walerZcoordinate + walerBeamSpacing),
                        new TSG.Point(screenLength + C1BeamWidth, billboardDepth, walerZcoordinate + walerBeamSpacing),
                        modelParameters.WalerMaterial,
                        modelParameters.WalerProfile,
                        "3",
                        walerEnums,
                        walerOffsets
                     );

                    // Update the z coordinate
                    walerZcoordinate += walerBeamSpacing;

                    // Add the next waler z-coordinate into the z-coordinate list for the z brackets
                    zCoordinatesForZBrackets.Add(walerZcoordinate);

                    // Add the next waler beam to the waler beam list for bolting purposes
                    walerBeams.Add(waler);
                }
            }
            // Add the final/top waler z-coordinate into the z-coordinate list for the z brackets
            zCoordinatesForZBrackets.Add(billboardHeight - B1BeamDepth - topWalerSpacing);

            // Add the final waler beam to the waler beam list for bolting purposes
            walerBeams.Add(topWaler);

            // THIS CODE IS FOR THE DIAGONALS //
            // Initialise the spacing variables for the diagonal 
            double xDiagonalSpacingCurrent = 0;
            double xDiagonalSpacingNext;

            // Create enums and offsets for diagonals 
            int[] diagonalEnums = new int[] { 2, 1, 2 };
            double[] diagonalOffsets = new double[] { 0.0, 0.0, 90 };

            // Create dimensional variables that can be used to calculate the welding offset
            double br1CornerWeldOffset = modelParameters.CornerOffset;

            // Initialise dimensional variables that can be used to calculate the welding offset
            double p;
            double q;
            double theta;
            double K;

            /*
            *                 p
            *     ----------------------
            *     |        (theta)   / |
            *     |              /     |     
            *     |          /         |   q  
            *   | |      /             |    
            *  K| |  /                 |     
            *   | ----------------------
            *
            */

            // Create a list of z coordinates to loop through in the diagonals creation loop
            List<double> zCoordinateDiagonals = new List<double> { 0 - (B1BeamDepth - BR1BeamDepth) - BR1BeamDepth, billboardHeight - B1BeamDepth - BR1BeamDepth };

            double topDiagonalOffset = modelParameters.DiagonalTopOffset;
            double bottomDiagonalOffset = modelParameters.DiagonalBottomOffset;

            // Loop through the integers 0 to the length of the xCoordinates array less 1 
            for (int indexXcoordinatesNew = 0; indexXcoordinatesNew < (xCoordinates.Count - 1); indexXcoordinatesNew++)
            {
                // Calculate the current x coordinate and the next x coordinate using the spacings 
                xDiagonalSpacingCurrent += xCoordinates[indexXcoordinatesNew];
                xDiagonalSpacingNext = xDiagonalSpacingCurrent + xCoordinates[indexXcoordinatesNew + 1];

                // Insert the BR1 beams on the top
                // Check to see if it is the first diagonal, since the first cabinet has smaller dimensions 
                if (indexXcoordinatesNew == 0)
                {
                    // Create dimensional variables that can be used to calculate the welding offset
                    p = xCoordinates[indexXcoordinatesNew + 1] - B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5);
                    q = billboardDepth - 2 * B1BeamWidth;

                    // Calculate the angle of the diagonal in radians 
                    theta = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - q), 2) + Math.Pow(p, 2)))) - Math.Atan((-1 * p) / (2 * br1CornerWeldOffset - q));

                    // Calculate the unknown dimension for offsetting the second point of the beam in the y axis
                    K = q - br1CornerWeldOffset - p * Math.Tan(theta);

                    // Create variables to offset the diagonal beam at the second point when calling the create beam function using the equation of the digonal line and theta
                    double xOffsetPoint2Top1 = BR1BeamWidth;
                    double yOffsetPoint2Top1 = xOffsetPoint2Top1 * Math.Tan(theta);

                    // Create the diagonal beam at the top, for the first cabinet
                    Beam br1Top = CreateBeam(new TSG.Point(xDiagonalSpacingCurrent + B2BeamWidth, B1BeamWidth + br1CornerWeldOffset, zCoordinateDiagonals[1] - topDiagonalOffset),
                                                new TSG.Point(xDiagonalSpacingNext + xOffsetPoint2Top1 - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5), billboardDepth - B1BeamWidth - K + yOffsetPoint2Top1, zCoordinateDiagonals[1] - topDiagonalOffset),
                                                modelParameters.BR1Material,
                                                modelParameters.BR1Profile,
                                                "7",
                                                diagonalEnums,
                                                diagonalOffsets);

                    // Generate a plane which will cut the diagonal top beam on the right side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(B2BeamWidth + xDiagonalSpacingCurrent + weldOffset, B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                        Father = br1Top
                    };
                    CutPlaneTop1.Insert();

                    // Generate a plane which will cut the diagonal top beam on the left side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xDiagonalSpacingNext - 0.5 * (B2BeamWidth - C1BeamWidth) - weldOffset, billboardDepth - B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                        Father = br1Top
                    };
                    CutPlaneTop2.Insert();

                }
                // Check to see if it is the final diagonal on the final cabinets, similar to the first one. 
                else if (indexXcoordinatesNew == xCoordinates.Count - 2)
                {
                    // Create dimensional variables that can be used to calculate the welding offset
                    p = xCoordinates[indexXcoordinatesNew + 1] - B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5);
                    q = billboardDepth - 2 * B1BeamWidth;

                    // Calculate the angle of the diagonal in radians 
                    theta = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - q), 2) + Math.Pow(p, 2)))) - Math.Atan((-1 * p) / (2 * br1CornerWeldOffset - q));

                    // Calculate the unknown dimension for offsetting the second point of the beam in the y axis
                    K = q - br1CornerWeldOffset - p * Math.Tan(theta);

                    // Create variables to offset the diagonal beam at the second point when calling the create beam function using the equation of the digonal line and theta
                    double xOffsetPoint2Top3 = BR1BeamWidth;
                    double yOffsetPoint2Top3 = xOffsetPoint2Top3 * Math.Tan(theta);

                    Beam br1Top = CreateBeam(
                        new TSG.Point(xDiagonalSpacingCurrent + B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5), B1BeamWidth + br1CornerWeldOffset, zCoordinateDiagonals[1] - topDiagonalOffset),
                        new TSG.Point(xDiagonalSpacingNext + xOffsetPoint2Top3 - (B2BeamWidth - C1BeamWidth), billboardDepth - B1BeamWidth - K + yOffsetPoint2Top3, zCoordinateDiagonals[1] - topDiagonalOffset),
                        modelParameters.BR1Material,
                        modelParameters.BR1Profile,
                        "7",
                        diagonalEnums,
                        diagonalOffsets
                    );

                    CutPlane CutPlaneTop1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(B2BeamWidth + xDiagonalSpacingCurrent - 0.5 * (B2BeamWidth - C1BeamWidth) + weldOffset, B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                        Father = br1Top
                    };
                    CutPlaneTop1.Insert();

                    CutPlane CutPlaneTop2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xDiagonalSpacingNext - (B2BeamWidth - C1BeamWidth) - weldOffset, billboardDepth - B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                        Father = br1Top
                    };
                    CutPlaneTop2.Insert();
                }
                // Check to see if the beams been constructed are the middle diagonals of the billboard
                else
                {
                    // Create dimensional variables that can be used to calculate the welding offset
                    p = xCoordinates[indexXcoordinatesNew + 1] - B2BeamWidth;
                    q = billboardDepth - 2 * B1BeamWidth;

                    // Calculate the angle of the diagonal in radians 
                    theta = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - q), 2) + Math.Pow(p, 2)))) - Math.Atan((-1 * p) / (2 * br1CornerWeldOffset - q));

                    // Calculate the unknown dimension for offsetting the second point of the beam in the y axis
                    K = q - br1CornerWeldOffset - p * Math.Tan(theta);

                    // Create variables to offset the diagonal beam at the second point when calling the create beam function using the equation of the digonal line and theta
                    double xOffsetPoint2Top2 = BR1BeamWidth;
                    double yOffsetPoint2Bottom2 = xOffsetPoint2Top2 * Math.Tan(theta);

                    // Create the top diagonals for the middle cabinets
                    Beam br1Top = CreateBeam(
                        new TSG.Point(xDiagonalSpacingCurrent + B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5), B1BeamWidth + br1CornerWeldOffset, zCoordinateDiagonals[1] - topDiagonalOffset),
                        new TSG.Point(xDiagonalSpacingNext + xOffsetPoint2Top2 - 0.5 * (B2BeamWidth - C1BeamWidth), billboardDepth - B1BeamWidth - K + yOffsetPoint2Bottom2, zCoordinateDiagonals[1] - topDiagonalOffset),
                        modelParameters.BR1Material,
                        modelParameters.BR1Profile,
                        "7",
                        diagonalEnums,
                        diagonalOffsets
                    );

                    CutPlane CutPlaneTop1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(B2BeamWidth + xDiagonalSpacingCurrent - 0.5 * (B2BeamWidth - C1BeamWidth) + weldOffset, B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                        Father = br1Top
                    };
                    CutPlaneTop1.Insert();

                    CutPlane CutPlaneTop2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xDiagonalSpacingNext - 0.5 * (B2BeamWidth - C1BeamWidth) - weldOffset, billboardDepth - B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                        Father = br1Top
                    };
                    CutPlaneTop2.Insert();
                }

                // Insert the BR1 beams on the bottom
                // Check to see if it is the first diagonal, since the first cabinet has smaller dimensions 
                if (indexXcoordinatesNew == 0)
                {
                    // Create dimensional variables that can be used to calculate the welding offset
                    p = xCoordinates[indexXcoordinatesNew + 1] - B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5);
                    q = billboardDepth - 2 * B1BeamWidth;

                    // Calculate the angle of the diagonal in radians 
                    theta = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - q), 2) + Math.Pow(p, 2)))) - Math.Atan((-1 * p) / (2 * br1CornerWeldOffset - q));

                    // Calculate the unknown dimension for offsetting the second point of the beam in the y axis
                    K = q - br1CornerWeldOffset - p * Math.Tan(theta);

                    // Create variables to offset the diagonal beam at the second point when calling the create beam function using the equation of the digonal line and theta
                    double xOffsetPoint2Bottom1 = BR1BeamWidth;
                    double yOffsetPoint2Bottom1 = xOffsetPoint2Bottom1 * Math.Tan(theta);

                    // Create the diagonal beam at the bottom, for the first cabinet
                    Beam br1Bottom = CreateBeam(new TSG.Point(xDiagonalSpacingCurrent + B5BeamWidth, B1BeamWidth + br1CornerWeldOffset, zCoordinateDiagonals[0] + bottomDiagonalOffset),
                                                new TSG.Point(xDiagonalSpacingNext + xOffsetPoint2Bottom1 - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5), billboardDepth - B1BeamWidth - K + yOffsetPoint2Bottom1, zCoordinateDiagonals[0] + bottomDiagonalOffset),
                                                modelParameters.BR1Material,
                                                modelParameters.BR1Profile,
                                                "7",
                                                diagonalEnums,
                                                diagonalOffsets);

                    // Generate a plane which will cut the diagonal bottom beam on the right side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B5 beam.
                    CutPlane CutPlaneBottom1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(B5BeamWidth + xDiagonalSpacingCurrent + weldOffset, B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                        Father = br1Bottom
                    };
                    CutPlaneBottom1.Insert();

                    // Generate a plane which will cut the diagonal bottom beam on the left side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B5 beam.
                    CutPlane CutPlaneBottom2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xDiagonalSpacingNext - 0.5 * (B5BeamWidth - C1BeamWidth) - weldOffset, billboardDepth - B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                        Father = br1Bottom
                    };
                    CutPlaneBottom2.Insert();

                }
                // Check to see if it is the final diagonal on the final cabinets, similar to the first one. 
                else if (indexXcoordinatesNew == xCoordinates.Count - 2)
                {

                    // Create dimensional variables that can be used to calculate the welding offset
                    p = xCoordinates[indexXcoordinatesNew + 1] - B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5);
                    q = billboardDepth - 2 * B1BeamWidth;

                    // Calculate the angle of the diagonal in radians 
                    theta = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - q), 2) + Math.Pow(p, 2)))) - Math.Atan((-1 * p) / (2 * br1CornerWeldOffset - q));

                    // Calculate the unknown dimension for offsetting the second point of the beam in the y axis
                    K = q - br1CornerWeldOffset - p * Math.Tan(theta);

                    // Create variables to offset the diagonal beam at the second point when calling the create beam function using the equation of the digonal line and theta
                    double xOffsetPoint2Bottom3 = BR1BeamWidth;
                    double yOffsetPoint2Bottom3 = xOffsetPoint2Bottom3 * Math.Tan(theta);

                    // Create the diagonal beam at the bottom, for the last cabinet
                    Beam br1Bottom = CreateBeam(
                        new TSG.Point(xDiagonalSpacingCurrent + B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5), B1BeamWidth + br1CornerWeldOffset, zCoordinateDiagonals[0] + bottomDiagonalOffset),
                        new TSG.Point(xDiagonalSpacingNext + xOffsetPoint2Bottom3 - (B5BeamWidth - C1BeamWidth), billboardDepth - B1BeamWidth - K + yOffsetPoint2Bottom3, zCoordinateDiagonals[0] + bottomDiagonalOffset),
                        modelParameters.BR1Material,
                        modelParameters.BR1Profile,
                        "7",
                        diagonalEnums,
                        diagonalOffsets
                    );

                    CutPlane CutPlaneBottom1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(B5BeamWidth + xDiagonalSpacingCurrent - 0.5 * (B5BeamWidth - C1BeamWidth) + weldOffset, B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                        Father = br1Bottom
                    };
                    CutPlaneBottom1.Insert();

                    CutPlane CutPlaneBottom2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xDiagonalSpacingNext - (B5BeamWidth - C1BeamWidth) - weldOffset, billboardDepth - B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                        Father = br1Bottom
                    };
                    CutPlaneBottom2.Insert();

                    // Check to see if the beams been constructed are the middle diagonals of the billboard
                }
                else
                {
                    // Create dimensional variables that can be used to calculate the welding offset
                    p = xCoordinates[indexXcoordinatesNew + 1] - B5BeamWidth;
                    q = billboardDepth - 2 * B1BeamWidth;

                    // Calculate the angle of the diagonal in radians 
                    theta = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - q), 2) + Math.Pow(p, 2)))) - Math.Atan((-1 * p) / (2 * br1CornerWeldOffset - q));

                    // Calculate the unknown dimension for offsetting the second point of the beam in the y axis
                    K = q - br1CornerWeldOffset - p * Math.Tan(theta);

                    // Create variables to offset the diagonal beam at the second point when calling the create beam function using the equation of the digonal line and theta
                    double xOffsetPoint2Bottom2 = BR1BeamWidth;
                    double yOffsetPoint2Bottom2 = xOffsetPoint2Bottom2 * Math.Tan(theta);

                    // Create the bottom diagonal for the middle cabinets
                    Beam br1Bottom = CreateBeam(
                        new TSG.Point(xDiagonalSpacingCurrent + B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5), B1BeamWidth + br1CornerWeldOffset, zCoordinateDiagonals[0] + bottomDiagonalOffset),
                        new TSG.Point(xDiagonalSpacingNext + xOffsetPoint2Bottom2 - 0.5 * (B5BeamWidth - C1BeamWidth), billboardDepth - B1BeamWidth - K + yOffsetPoint2Bottom2, zCoordinateDiagonals[0] + bottomDiagonalOffset),
                        modelParameters.BR1Material,
                        modelParameters.BR1Profile,
                        "7",
                        diagonalEnums,
                        diagonalOffsets
                    );

                    CutPlane CutPlaneBottom1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(B5BeamWidth + xDiagonalSpacingCurrent - 0.5 * (B5BeamWidth - C1BeamWidth) + weldOffset, B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                        Father = br1Bottom
                    };
                    CutPlaneBottom1.Insert();

                    CutPlane CutPlaneBottom2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xDiagonalSpacingNext - 0.5 * (B5BeamWidth - C1BeamWidth) - weldOffset, billboardDepth - B1BeamWidth, 0 - (B1BeamDepth - BR1BeamDepth)),
                            AxisY = new TSG.Vector(0, billboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                        Father = br1Bottom
                    };
                    CutPlaneBottom2.Insert();
                }
            }


            // THIS CODE IS FOR THE EA SUPPORTS //
            // EA support clearance 
            double EAsupportClearance = modelParameters.EASupportClearance;

            // Initialise offsetting variables 
            double firstXOffsetEA;
            double secondXOffsetEA;
            double pforEA;
            double qforEA;
            double thetaForEA;

            // Create offsets for the EA supports
            // Create coordinates that can be used to offset the horizontal railings (also include the welding offset)
            double EAOffsetX;
            double EAOffsetY = B1BeamWidth;
            double EAOffsetZ =  differenceb1b5Depth;

            // Set a variable for the spacing of the EA supports
            double xEASpacingCurrent = 0;
            double xEASpacingNext;

            // Create a list for the y coordinates of the EA supports
            List<double> EAyCoordinates = new List<double> { 0 + EAOffsetY, billboardDepth - EAOffsetY };

            // Initialise x coordinate points for the EA supports so they can be checked in the code
            double EAxCoordinate1 = 0;
            double EAxCoordinate2 = 0;

            // Loop through the x coordinates
            for (int indexXcoordinates = 0; indexXcoordinates < (xCoordinates.Count - 1); indexXcoordinates++)
            {
                // Calculate the current x coordinate and the next x coordinate using the spacings 
                xEASpacingCurrent += xCoordinates[indexXcoordinates];
                xEASpacingNext = xEASpacingCurrent + xCoordinates[indexXcoordinates + 1];

                // Loop through the y coordinates array
                for (int indexYcoordinates = 0; indexYcoordinates <= (EAyCoordinates.Count - 1); indexYcoordinates++)
                {
                    // Check to see if we are building the first EA support
                    if (indexXcoordinates == 0)
                    {
                        // Create dimensional variables that can be used to calculate the welding offset
                        pforEA = xCoordinates[indexXcoordinates + 1] - B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5);
                        qforEA = billboardDepth - 2 * B1BeamWidth;

                        // Calculate the angle of the diagonal in radians 
                        thetaForEA = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - qforEA), 2) + Math.Pow(pforEA, 2)))) - Math.Atan((-1 * pforEA) / (2 * br1CornerWeldOffset - qforEA));

                        // Calculate the offset for the EA support edges that are closest to the BR1 diagonals 
                        firstXOffsetEA = EAsupportClearance / Math.Sin(thetaForEA);
                        secondXOffsetEA = (EAbeamWidth - br1CornerWeldOffset) / Math.Tan(thetaForEA);
                        EAOffsetX = firstXOffsetEA + secondXOffsetEA;


                        // Check if we are at the side closest to the screen
                        if (indexYcoordinates == 0)
                        {
                            // Create enums and offsets for EA supports at the screen side of the billboard
                            int[] EAEnums = new int[] { 2, 1, 3 };
                            double[] EAOffsets = new double[] { 0.0, 0.0, 0.0 };

                            // Establish the x coordinates
                            EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth + EAOffsetX;
                            EAxCoordinate2 = xEASpacingNext - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) - EAsupportClearance;

                           // Check to see if the length of the EA support will be greater than the gap between the B5 Bbeams
                            if ((EAxCoordinate2 - EAxCoordinate1) >= (xCoordinates[indexXcoordinates + 1] - B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5)))
                            {
                                // Adjust the first x coordinate
                                EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth + EAsupportClearance;
                            }

                            // Insert the EA supports
                            CreateBeam(
                                new TSG.Point(EAxCoordinate1, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                new TSG.Point(EAxCoordinate2, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "8",
                                EAEnums,
                                EAOffsets
                            );
                        }

                        // If we are at the side furthest away from the screen
                        else
                        {
                            // Create enums and offsets for EA supports at the side of the billboard furthest away from the screen
                            int[] EAEnums = new int[] { 2, 2, 2 };
                            double[] EAOffsets = new double[] { 0.0, 0.0, 0.0 };

                            // Establish the x coordinates
                            EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth + EAsupportClearance;
                            EAxCoordinate2 = xEASpacingNext - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) - EAOffsetX;

                            // Check to see if the length of the EA support will be greater than the gap between the B5 Bbeams
                            if ((EAxCoordinate2 - EAxCoordinate1) >= (xCoordinates[indexXcoordinates + 1] - B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5)))
                            {
                                // Adjust the second x coordinate
                                EAxCoordinate2 = xEASpacingNext - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) - EAsupportClearance;

                            }

                            // Insert the EA supports
                            CreateBeam(
                                new TSG.Point(EAxCoordinate1, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                new TSG.Point(EAxCoordinate2, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "8",
                                EAEnums,
                                EAOffsets
                            );
                        }
                    }

                    // Check to see if we are building the final EA support
                    else if (indexXcoordinates == xCoordinates.Count - 2)
                    {
                        // Create dimensional variables that can be used to calculate the welding offset
                        pforEA = xCoordinates[indexXcoordinates + 1] - B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5);
                        qforEA = billboardDepth - 2 * B1BeamWidth;

                        // Calculate the angle of the diagonal in radians 
                        thetaForEA = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - qforEA), 2) + Math.Pow(pforEA, 2)))) - Math.Atan((-1 * pforEA) / (2 * br1CornerWeldOffset - qforEA));

                        // Calculate the offset for the EA support edges that are closest to the BR1 diagonals 
                        firstXOffsetEA = EAsupportClearance / Math.Sin(thetaForEA);
                        secondXOffsetEA = (EAbeamWidth - br1CornerWeldOffset) / Math.Tan(thetaForEA);
                        EAOffsetX = firstXOffsetEA + secondXOffsetEA;

                        // Check if we are at the side closest to the screen
                        if (indexYcoordinates == 0)
                        {
                            // Create enums and offsets for EA supports at the screen side of the billboard
                            int[] EAEnums = new int[] { 2, 1, 3 };
                            double[] EAOffsets = new double[] { 0.0, 0.0, 0.0 };

                            // Establish the x coordinates
                            EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) + EAOffsetX;
                            EAxCoordinate2 = xEASpacingNext - (B5BeamWidth - C1BeamWidth) - EAsupportClearance;

                            // Check to see if the length of the EA support will be greater than the gap between the B5 Bbeams
                            if ((EAxCoordinate2 - EAxCoordinate1) >= (xCoordinates[indexXcoordinates + 1] - B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5)))
                            {
                                // Adjust the first x coordinate
                                EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) + EAsupportClearance;
                            }

                            // Insert the EA supports
                            CreateBeam(
                                new TSG.Point(EAxCoordinate1, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                new TSG.Point(EAxCoordinate2, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "8",
                                EAEnums,
                                EAOffsets
                            );
                        }

                        // If we are at the side furthest away from the screen
                        else
                        {
                            // Create enums and offsets for EA supports at the side of the billboard furthest away from the screen
                            int[] EAEnums = new int[] { 2, 2, 2 };
                            double[] EAOffsets = new double[] { 0.0, 0.0, 0.0 };

                            // Establish the x coordinates
                            EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth - (B5BeamWidth* 0.5 - C1BeamWidth* 0.5) + EAsupportClearance;
                            EAxCoordinate2 = xEASpacingNext - (B5BeamWidth - C1BeamWidth) - EAOffsetX;

                            // Check to see if the length of the EA support will be greater than the gap between the B5 Bbeams
                            if ((EAxCoordinate2 - EAxCoordinate1) >= (xCoordinates[indexXcoordinates + 1] - B2BeamWidth - (B2BeamWidth * 0.5 - C1BeamWidth * 0.5)))
                            {
                                // Adjust the second x coordinate
                                EAxCoordinate2 = xEASpacingNext - (B5BeamWidth - C1BeamWidth) - EAsupportClearance;

                            }

                            // Insert the EA supports
                            CreateBeam(
                                new TSG.Point(EAxCoordinate1, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                new TSG.Point(EAxCoordinate2, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "8",
                                EAEnums,
                                EAOffsets
                            );
                        }
                    }

                    // We are building the middle EA supports
                    else
                    {
                        // Create dimensional variables that can be used to calculate the welding offset
                        pforEA = xCoordinates[indexXcoordinates + 1] - B5BeamWidth;
                        qforEA = billboardDepth - 2 * B1BeamWidth;

                        // Calculate the angle of the diagonal in radians 
                        thetaForEA = Math.Acos(BR1BeamWidth / (Math.Sqrt(Math.Pow((2 * br1CornerWeldOffset - qforEA), 2) + Math.Pow(pforEA, 2)))) - Math.Atan((-1 * pforEA) / (2 * br1CornerWeldOffset - qforEA));

                        // Calculate the offset for the EA support edges that are closest to the BR1 diagonals 
                        firstXOffsetEA = EAsupportClearance / Math.Sin(thetaForEA);
                        secondXOffsetEA = (EAbeamWidth - br1CornerWeldOffset) / Math.Tan(thetaForEA);
                        EAOffsetX = firstXOffsetEA + secondXOffsetEA;

                        // Check if we are at the side closest to the screen
                        if (indexYcoordinates == 0)
                        {
                            // Create enums and offsets for EA supports at the screen side of the billboard
                            int[] EAEnums = new int[] { 2, 1, 3 };
                            double[] EAOffsets = new double[] { 0.0, 0.0, 0.0 };

                            // Establish the x coordinates
                            EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) + EAOffsetX;
                            EAxCoordinate2 = xEASpacingNext - 0.5 * (B5BeamWidth - C1BeamWidth) - EAsupportClearance;

                            // Check to see if the length of the EA support will be greater than the gap between the B5 Bbeams
                            if ((EAxCoordinate2 - EAxCoordinate1) >= (xCoordinates[indexXcoordinates + 1] - B2BeamWidth))
                            {
                                // Adjust the first second coordinate
                                EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) + EAsupportClearance;
                            }

                            // Insert the EA supports
                            CreateBeam(
                                new TSG.Point(EAxCoordinate1, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                new TSG.Point(EAxCoordinate2, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "8",
                                EAEnums,
                                EAOffsets
                            );
                        }

                        // If we are at the side furthest away from the screen
                        else
                        {
                            // Create enums and offsets for EA supports at the side of the billboard furthest away from the screen
                            int[] EAEnums = new int[] { 2, 2, 2 };
                            double[] EAOffsets = new double[] { 0.0, 0.0, 0.0 };

                            // Establish the x coordinates
                            EAxCoordinate1 = xEASpacingCurrent + B5BeamWidth - (B5BeamWidth * 0.5 - C1BeamWidth * 0.5) + EAsupportClearance;
                            EAxCoordinate2 = xEASpacingNext - 0.5 * (B5BeamWidth - C1BeamWidth) - EAOffsetX;

                            // Check to see if the length of the EA support will be greater than the gap between the B5 Bbeams
                            if ((EAxCoordinate2 - EAxCoordinate1) >= (xCoordinates[indexXcoordinates + 1] - B2BeamWidth))
                            {
                                // Adjust the second x coordinate
                                EAxCoordinate2 = xEASpacingNext - 0.5 * (B5BeamWidth - C1BeamWidth) - EAsupportClearance;
                            }

                            // Insert the EA supports
                            CreateBeam(
                                new TSG.Point(EAxCoordinate1, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                new TSG.Point(EAxCoordinate2, EAyCoordinates[indexYcoordinates], 0 - EAOffsetZ),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "8",
                                EAEnums,
                                EAOffsets
                            );
                        }
                    }
                }
            }

            // Cabinet starting offset, half the profile dimension of the starting beam
            double cabinetXOffset = (BeamDimensions(modelParameters.C1Profile)[1]) / 2;
            CreateCabinet(xCoordinates, zCoordinates, cabinetXOffset, modelParameters.HeightOffsetBottom);

            // THIS CODE IS FOR THE WALKWAY MESH //
            // Get the mesh thickness as a string
            string walkwayMeshThicknessString = Convert.ToString(modelParameters.MeshThickness);

            // Obtain the width of the walkway 
            double walkwayMeshWidth = modelParameters.WalkwayWidth;

            // Convert the walkway width to a string
            string walkwayMeshWidthString = Convert.ToString(walkwayMeshWidth);

            // Concatenate the strings e.g. PLT14*615
            string walkwayProfile = "PLT" + walkwayMeshThicknessString + "*" + walkwayMeshWidthString;

            // Create enums and offsets for the walkway mesh
            int[] meshEnums = new int[] { 1, 1, 0 };
            double[] meshOffsets = new double[] { 0.0, 0.0, 0.0 };

            // Create the plate 
            CreateBeam(
                new TSG.Point(0, B1BeamWidth + modelParameters.WalkwayClearance, 0 - differenceb1b5Depth),
                new TSG.Point(screenLength + C1BeamWidth, B1BeamWidth + modelParameters.WalkwayClearance, 0 - differenceb1b5Depth),
                modelParameters.MeshMaterial,
                walkwayProfile,
                "1",
                meshEnums,
                meshOffsets
                );


          
                // Insert code for side bracings here //



                // THIS CODE IS FOR THE Z BRACKETS // 
                //              P1
                //              |
                //    Plate 1   |
                //              |
                //           P2 |___________P3
                //                 Plate2   |
                //                          |
                //                          | Plate 3
                //                          |
                //                       P4 \
                //                           \
                //                            \
                //                             \  Plate 4
                //                              P5



                // Initialise the x-direction and z-direction spacing for the z-brackets
                double xZBracketSpacing = 0;
            double zZBracketSpacing = 0;

            // Initialise the variables
            // The angle for the extended part of the bracket on the edges of the billboard 
            double angleInDegrees = 45;

            // Converting the angle to radians 
            double angleInRadians = angleInDegrees * (Math.PI / 180);

            // Outer edges bracket plate 4 length 
            double plate4Length = 150; //TODO Maybe user input

            // Finding the y and z components of the length of Plate 4.
            double plate4Y = plate4Length * Math.Cos(angleInRadians);
            double plate4Z = plate4Length * Math.Sin(angleInRadians);

            // Initialise dimensions for all four plates of z bracket
            // double zBracketYOffset = 0.5 zBracketThickness;
            //double  zBracketZOffset =

            // For plate 1:
            double topEdgeToUpperBolt = 30; //TODO Maybe user input
            double spacingBetweenBolts = 100; //TODO user input
            double lowerBoltToTopWaler = 50; // TODO user input

            //Internal Bracket offsets (a and b in the clients documents)   
            double offsetToWalerFaceSides = modelParameters.EndBracketSpacing;  
            double offsetToWalerFaceInner = modelParameters.BracketASpacing;  
            double offsetToWalerBottom = modelParameters.BracketBSpacing; 

            // Loop through the x-coordinates
            for (int indexXcoordinates = 0; indexXcoordinates <= (xCoordinates.Count - 1); indexXcoordinates++)
            {
                // Update the x-spacing (the first value in the xCoordinates list is 0)
                xZBracketSpacing += xCoordinates[indexXcoordinates];

                // Loop through the z-coordinates of the walers (i.e. the z spacings of the brackets)
                for (int indexZcoordinates = 0; indexZcoordinates <= (zCoordinatesForZBrackets.Count - 1); indexZcoordinates++)
                {
                    // Update the z-spacing 
                    zZBracketSpacing = zCoordinatesForZBrackets[indexZcoordinates];

                    // Check if we are in the first x-coordinate (because these have modified z brackets and different alignment)
                    if (indexXcoordinates == 0)
                    {
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth , zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth , zZBracketSpacing), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth + WalerBeamWidth + offsetToWalerFaceSides, zZBracketSpacing), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth + WalerBeamWidth + offsetToWalerFaceSides , zZBracketSpacing - WalerBeamDepth), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth + WalerBeamWidth + offsetToWalerFaceSides + plate4Y, zZBracketSpacing - WalerBeamDepth - plate4Z), null),

                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreateZBracket(contourPoints, bracketEnums, bracketOffsets);

                        // INSERT THE BOLTS
                        // Create a new bolt array
                        BoltArray Bolt = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = planes[indexXcoordinates].Back,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth, zZBracketSpacing), // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth, zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler), // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter, 
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Bolt.Position.Depth = Position.DepthEnum.MIDDLE;
                        Bolt.Position.DepthOffset = (zBracketWidth - C1BeamWidth) + 0.5 * C1BeamWidth;
                        Bolt.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Bolt.Position.Rotation = Position.RotationEnum.BELOW;
                        Bolt.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Bolt.Bolt = true;
                        Bolt.Washer1 = false;
                        Bolt.Washer2 = false;
                        Bolt.Washer3 = true;
                        Bolt.Nut1 = true;
                        Bolt.Nut2 = false;

                        Bolt.Hole1 = false;
                        Bolt.Hole2 = false;
                        Bolt.Hole3 = false;
                        Bolt.Hole4 = false;
                        Bolt.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Bolt.AddBoltDistY(0);

                        // Add the distance between two holes 
                        Bolt.AddBoltDistX(spacingBetweenBolts);

                        // Specify the offset to the first bolt 
                        Bolt.StartPointOffset.Dx = lowerBoltToTopWaler;

                        // Insert bolts
                        if (!Bolt.Insert())
                        {
                            MessageBox.Show("Insertion of Bolt failed.");
                        }

                        // INSERT THE BOLT HOLE ON WALER
                        // Create a new bolt array
                        BoltArray Hole = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = zBracket,
                           
                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth + WalerBeamWidth, zZBracketSpacing), // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing + zBracketWidth, billboardDepth, zZBracketSpacing), // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter, 
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard, 
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Hole.Position.Depth = Position.DepthEnum.MIDDLE;
                        Hole.Position.DepthOffset = 0;
                        Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Hole.Position.PlaneOffset = -1*((zBracketWidth - C1BeamWidth) + 0.5 * C1BeamWidth);
                        Hole.Position.Rotation = Position.RotationEnum.FRONT;
                        Hole.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Hole.Bolt = false;
                        Hole.Washer1 = false;
                        Hole.Washer2 = false;
                        Hole.Washer3 = false;
                        Hole.Nut1 = false;
                        Hole.Nut2 = false;

                        Hole.Hole1 = false;
                        Hole.Hole2 = false;
                        Hole.Hole3 = false;
                        Hole.Hole4 = false;
                        Hole.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Hole.AddBoltDistY(0);

                        // Add the distance between two holes (set to 0 because we want one)
                        Hole.AddBoltDistX(0);

                        // Specify the offset to the first bolt 
                        Hole.StartPointOffset.Dx = 0.5 * WalerBeamWidth;


                        // Insert bolts
                        if (!Hole.Insert())
                        {
                            MessageBox.Show("Insertion of Bolt failed.");
                        }
                    }
                    // Check if we are at the finalx-coordinate (because these have modified z brackets and different alignment)
                    else if (indexXcoordinates == (xCoordinates.Count - 1))
                    {
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth, zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts +lowerBoltToTopWaler), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth, zZBracketSpacing), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth + WalerBeamWidth + offsetToWalerFaceSides, zZBracketSpacing), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth + WalerBeamWidth + offsetToWalerFaceSides, zZBracketSpacing - WalerBeamDepth), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth + WalerBeamWidth + offsetToWalerFaceSides + plate4Y , zZBracketSpacing - WalerBeamDepth - plate4Z), null),

                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreateZBracket(contourPoints, bracketEnums, bracketOffsets);

                        // INSERT THE BOLTS
                        // Create a new bolt array
                        BoltArray Bolt = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = planes[indexXcoordinates].Back,


                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth, zZBracketSpacing), // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth, zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler), // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter, 
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard, 
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Bolt.Position.Depth = Position.DepthEnum.MIDDLE;
                        Bolt.Position.DepthOffset = 0.5 * C1BeamWidth;
                        Bolt.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Bolt.Position.Rotation = Position.RotationEnum.BELOW;
                        Bolt.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Bolt.Bolt = true;
                        Bolt.Washer1 = false;
                        Bolt.Washer2 = false;
                        Bolt.Washer3 = true;
                        Bolt.Nut1 = true;
                        Bolt.Nut2 = false;

                        Bolt.Hole1 = false;
                        Bolt.Hole2 = false;
                        Bolt.Hole3 = false;
                        Bolt.Hole4 = false;
                        Bolt.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Bolt.AddBoltDistY(0);

                        // Add the distance between two holes 
                        Bolt.AddBoltDistX(spacingBetweenBolts);

                        // Specify the offset to the first bolt 
                        Bolt.StartPointOffset.Dx = lowerBoltToTopWaler;


                        // Insert bolts
                        if (!Bolt.Insert())
                        {
                            MessageBox.Show("Insertion of Bolt failed.");
                        }

                        // INSERT THE BOLT HOLE ON WALER
                        // Create a new bolt array
                        BoltArray Hole = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = zBracket,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth + WalerBeamWidth, zZBracketSpacing), // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing + C1BeamWidth, billboardDepth, zZBracketSpacing), // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter, 
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard, 
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Hole.Position.Depth = Position.DepthEnum.MIDDLE;
                        Hole.Position.DepthOffset = 0;
                        Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Hole.Position.PlaneOffset =   -0.5 * C1BeamWidth;
                        Hole.Position.Rotation = Position.RotationEnum.FRONT;
                        Hole.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Hole.Bolt = false;
                        Hole.Washer1 = false;
                        Hole.Washer2 = false;
                        Hole.Washer3 = false;
                        Hole.Nut1 = false;
                        Hole.Nut2 = false;

                        Hole.Hole1 = false;
                        Hole.Hole2 = false;
                        Hole.Hole3 = false;
                        Hole.Hole4 = false;
                        Hole.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Hole.AddBoltDistY(0);

                        // Add the distance between two holes (set to 0 because we want one)
                        Hole.AddBoltDistX(0);

                        // Specify the offset to the first bolt 
                        Hole.StartPointOffset.Dx = 0.5 * WalerBeamWidth;


                        // Insert bolts
                        if (!Hole.Insert())
                        {
                            MessageBox.Show("Insertion of Bolt failed.");
                        }
                    }
                    // If we are in the middle of the billboard
                    else
                    {
                        // Build the regular z-brackets
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth, zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts +lowerBoltToTopWaler), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth, zZBracketSpacing), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth + WalerBeamWidth + offsetToWalerFaceInner, zZBracketSpacing), null),
                             new ContourPoint(new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth + WalerBeamWidth + offsetToWalerFaceInner, zZBracketSpacing - WalerBeamDepth + offsetToWalerBottom), null),
                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreateZBracket(contourPoints, bracketEnums, bracketOffsets);

                        // INSERT THE BOLTS
                        // Create a new bolt array
                        BoltArray Bolt = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket, 
                            PartToBoltTo = planes[indexXcoordinates].Back,


                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth , zZBracketSpacing), // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth , zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler), // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter, 
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard, 
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Bolt.Position.Depth = Position.DepthEnum.MIDDLE;
                        Bolt.Position.DepthOffset = 0.5 * zBracketWidth;
                        Bolt.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Bolt.Position.Rotation = Position.RotationEnum.BELOW;
                        Bolt.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Bolt.Bolt = true;
                        Bolt.Washer1 = false;
                        Bolt.Washer2 = false;
                        Bolt.Washer3 = true;
                        Bolt.Nut1 = true;
                        Bolt.Nut2 = false;

                        Bolt.Hole1 = false;
                        Bolt.Hole2 = false;
                        Bolt.Hole3 = false;
                        Bolt.Hole4 = false;
                        Bolt.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Bolt.AddBoltDistY(0);

                        // Add the distance between two holes 
                        Bolt.AddBoltDistX(spacingBetweenBolts);

                        // Specify the offset to the first bolt 
                        Bolt.StartPointOffset.Dx = lowerBoltToTopWaler; 


                        // Insert bolts
                        if (!Bolt.Insert())
                        {
                            MessageBox.Show("Insertion of Bolt failed.");
                        }

                        // INSERT THE BOLT HOLE ON WALER
                        // Create a new bolt array
                        BoltArray Hole = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = zBracket,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth + WalerBeamWidth, zZBracketSpacing), // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing + 0.5 * (zBracketWidth + C1BeamWidth), billboardDepth, zZBracketSpacing), // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter, 
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard, 
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Hole.Position.Depth = Position.DepthEnum.MIDDLE;
                        Hole.Position.DepthOffset = 0;
                        Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Hole.Position.PlaneOffset = -0.5 * zBracketWidth;
                        Hole.Position.Rotation = Position.RotationEnum.FRONT;
                        Hole.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Hole.Bolt = false;
                        Hole.Washer1 = false;
                        Hole.Washer2 = false;
                        Hole.Washer3 = false;
                        Hole.Nut1 = false;
                        Hole.Nut2 = false;

                        Hole.Hole1 = false;
                        Hole.Hole2 = false;
                        Hole.Hole3 = false;
                        Hole.Hole4 = false;
                        Hole.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Hole.AddBoltDistY(0);

                        // Add the distance between two holes (set to 0 because we want one)
                        Hole.AddBoltDistX(0);

                        // Specify the offset to the first bolt 
                        Hole.StartPointOffset.Dx = 0.5 * WalerBeamWidth;


                        // Insert bolts
                        if (!Hole.Insert())
                        {
                            MessageBox.Show("Insertion of Bolt failed.");
                        }
                    }
                }
            }

            MyModel.CommitChanges();
        }

        // Method to create a Z-Bracket using the list of points
        private PolyBeam CreateZBracket(List<ContourPoint> points, int[] bracketEnums, double[] bracketOffsets)
        {
            PolyBeam polyBeam = new PolyBeam();

            foreach (ContourPoint point in points)
            {
                polyBeam.AddContourPoint(point);
            }

            polyBeam.Profile.ProfileString = modelParameters.BracketProfile;
            polyBeam.Material.MaterialString = modelParameters.BracketMaterial;

            polyBeam.Position.Depth = (Position.DepthEnum)bracketEnums[0];
            polyBeam.Position.DepthOffset = bracketOffsets[0];

            polyBeam.Position.Plane = (Position.PlaneEnum)bracketEnums[1];
            polyBeam.Position.PlaneOffset = bracketOffsets[1];

            polyBeam.Position.Rotation = (Position.RotationEnum)bracketEnums[2];
            polyBeam.Position.RotationOffset = bracketOffsets[2];

            polyBeam.Class = "6";

            if (!polyBeam.Insert())
            {
                MessageBox.Show("Failed to insert beam");
            };

            return polyBeam;
        }

        // method to create a beam
        // enums and offset element position
        // 1st element [0] = Depth
        // 2nd element [1] = Plane
        // 3rd element [2] = Rotation
        private static Beam CreateBeam(TSG.Point startPos, TSG.Point endPos, string material, string profile, string beamClass, int[] enums, double[] offsets)
        {

            // Beam properties
            Beam beam = new Beam(startPos, endPos);
            beam.Profile.ProfileString = profile;
            beam.Material.MaterialString = material;

            // Depth position - First element in the array : 0 - Middle, 1 - Front, 2 - Back
            beam.Position.Depth = (Position.DepthEnum)enums[0];
            beam.Position.DepthOffset = offsets[0];

            // Plane position - Second element in the array : 0 - Middle, 1 - Left, 2 - Right
            beam.Position.Plane = (Position.PlaneEnum)enums[1];
            beam.Position.PlaneOffset = offsets[1];

            // Rotation position - Third element in the array : 0 - Front, 1 - Top, 2 - Back, 3 - Below
            beam.Position.Rotation = (Position.RotationEnum)enums[2];
            beam.Position.RotationOffset = offsets[2];

            beam.Class = beamClass;

            if (!beam.Insert())
            {
                Console.WriteLine("Insertion of beam failed.");
            }

            return beam;
        }

        // Create LED Cabinet
        private void CreateCabinet(List<double> xCoordinates, List<double> zCoordinates, double cabinetXOffset, double cabinetYOffset)
        {


            // x offset for the left edge
            double xOffsetPlateLeft = 0.0 + cabinetXOffset;
            // x offset for the right edge
            double xOffsetPlateRight = 0.0 + cabinetXOffset;
            // z offset for the lower edge
            double zOffsetPlateLower = 0 + cabinetYOffset;
            // z offset for the upper edge
            double zOffsetPlateUpper = 0 + cabinetYOffset;

            // Loop for each row
            for (int indexZ = 0; indexZ < zCoordinates.Count - 1; indexZ++)
            {
                // Lower and Upper edge offset
                zOffsetPlateLower += zCoordinates[indexZ];
                zOffsetPlateUpper += zCoordinates[indexZ + 1];

                // Loop for each column
                for (int indexX = 0; indexX < xCoordinates.Count - 1; indexX++)
                {
                    // Left and Right edge offset
                    xOffsetPlateLeft += xCoordinates[indexX];
                    xOffsetPlateRight += xCoordinates[indexX + 1];

                    // Define the four corners
                    // Important: Sequence matters! The points adds to be a path to enclose the box
                    TSG.Point point1p = new TSG.Point(xOffsetPlateLeft, 0.0, zOffsetPlateLower);
                    TSG.Point point2p = new TSG.Point(xOffsetPlateRight, 0.0, zOffsetPlateLower);
                    TSG.Point point3p = new TSG.Point(xOffsetPlateRight, 0.0, zOffsetPlateUpper);
                    TSG.Point point4p = new TSG.Point(xOffsetPlateLeft, 0.0, zOffsetPlateUpper);

                    // Create a plate
                    Plate plate = new Plate(point1p, point2p, point3p, point4p, modelParameters);
                    
                    // Call the method CreateBoltHoles, to make bolt array on created plate
                    CreateBoltHoles(plate);
                }

                // Reset starting x position
                xOffsetPlateLeft = 0.0 + cabinetXOffset;
                xOffsetPlateRight = 0.0 + cabinetXOffset;
            }
        }

        // Method to create bolt holes on a plate
        // The imput is plate class, dx = the distance between horizontal edge of plate to the centre of hole
        // dy = the distance between vertical edge of plate to the centre of the hole
        private void CreateBoltHoles(Plate plate)
        {
            // Create a new bolt array
            BoltArray B = new BoltArray
            {
                // Define part (plate) for array
                PartToBeBolted = plate.ContourPlate,
                PartToBoltTo = plate.ContourPlate, 
                // Set the midpoints 
                // Start from middle bottom to middle top
                // Right edge - half of the length (right edge - left edge)/2
                FirstPosition = plate.Point2 - new TSG.Point((plate.Point2.X - plate.Point1.X) / 2, 0.0, 0.0),
                SecondPosition = plate.Point3 - new TSG.Point((plate.Point3.X - plate.Point4.X) / 2, 0.0, 0.0),

                // Bolt properties
                BoltSize = modelParameters.BoltSize,
                Tolerance = 3.00,
                BoltStandard = "UNDEFINED_STUD",
                BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                CutLength = 105,
                Length = 120,
                ExtraLength = 15,
                ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_NO
            };

            // Bolt offsets
            B.Position.Depth          = Position.DepthEnum.MIDDLE;
            B.Position.DepthOffset    = 0;
            B.Position.Plane          = Position.PlaneEnum.MIDDLE;
            B.Position.Rotation       = Position.RotationEnum.BELOW;
            B.Position.RotationOffset = 0;

            // the following properties determine the shape of bolts
            // In this case, we set everything to false
            B.Bolt    = true;
            B.Washer1 = false;
            B.Washer2 = false;
            B.Washer3 = false;
            B.Nut1    = false;
            B.Nut2    = false;

            B.Hole1   = false;
            B.Hole2   = false;
            B.Hole3   = false;
            B.Hole4   = false;
            B.Hole5   = false;

            // Add the distance between two holes on the same horizontal line
            // Length of plate is difference between two edge
            // Distance is length - 2 * hole distance from edge
            B.AddBoltDistY(plate.Point2.X - plate.Point1.X - (2 * modelParameters.BoltOffsetDx));

            // Add the distance between two holes on the same vertical line
            B.AddBoltDistX(plate.Point4.Z - plate.Point1.Z - (2 * modelParameters.BoltOffsetDy));
            
            // Bolt array x-y axis is in line with first -> second position
            B.StartPointOffset.Dx = modelParameters.BoltOffsetDy;

            // Insert bolts
            if (!B.Insert()) {
                MessageBox.Show("Insertion of Bolt failed.");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // Method to convert beam profile dimensions string into a double
        private double[] BeamDimensions(string dimensionString)
        {
            string[] FinalDimensions;
            if (dimensionString.Contains("EA"))
            {
                // Remove first three characters in string and split string into an array from * points 
                FinalDimensions = dimensionString.Substring(2).Split('*');

                // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
                double beamDepth = Convert.ToDouble(FinalDimensions[0]);
                double beamWidth = Convert.ToDouble(FinalDimensions[1]);
                double beamThicccness = Convert.ToDouble(FinalDimensions[2]);
                return new double[] { beamDepth, beamWidth, beamThicccness };
            }
            else if (dimensionString.Contains("PLT"))
            {
                // Remove first three characters in string and split string into an array from * points 
                FinalDimensions = dimensionString.Substring(3).Split('*');

                // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
                double beamThickness = Convert.ToDouble(FinalDimensions[0]);
                double beamWidth = Convert.ToDouble(FinalDimensions[1]);
                return new double[] { beamThickness, beamWidth };
            }
            else
            {
                // Remove first three characters in string and split string into an array from * points 
                FinalDimensions = dimensionString.Substring(3).Split('*');

                // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
                double beamDepth = Convert.ToDouble(FinalDimensions[0]);
                double beamWidth = Convert.ToDouble(FinalDimensions[1]);
                double beamThicccness = Convert.ToDouble(FinalDimensions[2]);
                return new double[] { beamDepth, beamWidth, beamThicccness };
            }
        }

        // Get the height of the model (cabinet)
        private double GetHeight()
        {
            double height = 0;
            foreach (var item in modelParameters.ZCoordinates)
            {
                height += item;
            }
            return height;
        }

        // Get the length of the model (cabinet)
        private double GetLength()
        {
            double height = 0;
            foreach (var item in modelParameters.XCoordinates)
            {
                height += item;
            }
            return height;
        }

        private void CabinetValueAddButton_Click(object sender, EventArgs e)
        {
            // Disable build button
            button1.Enabled = false;
            try
            {
                // Convert input to double
                double addValue = Convert.ToDouble(cabinetAddValue.Text);

                // If the input is 0, throw error
                if (addValue <= 0)
                {
                    throw new Exception();
                }

                // Check if it's adding row or column
                if (RowAddRadioButton.Checked)
                {
                    // Add value to UI list and variable
                    rowList.Items.Add(addValue);
                    modelParameters.ZCoordinates.Add(addValue);

                    // Display count and sum
                    rowSumLabel.Text = (modelParameters.ZCoordinates.Count - 1).ToString();
                    CabinetHeightSumLabel.Text = GetHeight().ToString();
                } else
                {
                    columnList.Items.Add(addValue);
                    modelParameters.XCoordinates.Add(addValue);
                    columnSumLabel.Text = (modelParameters.XCoordinates.Count - 1).ToString();
                    CabinetLengthSumLabel.Text = GetLength().ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void RowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RowEditRadioButton.Checked)
            {
                // if no selection, display nothing, otherwise display selected item
                CabinetEditValue.Text = rowList.SelectedIndex == -1 ? "" : rowList.SelectedItem.ToString();
            }
        }

        private void ColumnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColumnEditRadioButton.Checked)
            {
                CabinetEditValue.Text = columnList.SelectedIndex == -1 ? "" : columnList.SelectedItem.ToString();
            }
        }

        private void EditRowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CabinetEditValue.Text = rowList.SelectedIndex == -1 ? "" : CabinetEditValue.Text = rowList.SelectedItem.ToString();
        }

        private void EditColumnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CabinetEditValue.Text = columnList.SelectedIndex == -1 ? "" : CabinetEditValue.Text = columnList.SelectedItem.ToString();
        }

        private void CabinetEditButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                double editValue = Convert.ToDouble(CabinetEditValue.Text);

                if (editValue <= 0)
                {
                    throw new Exception();
                }

                if (RowEditRadioButton.Checked)
                {
                    // If an item is selected in UI list
                    if (rowList.SelectedIndex != -1)
                    {
                        // Get the index of selected item
                        int rowIndex = rowList.SelectedIndex;

                        // Replace item at index with new value
                        rowList.Items[rowIndex] = editValue;

                        // Update variable list, +1 to shift index away from required 0 value in list
                        modelParameters.ZCoordinates[rowIndex + 1] = editValue;

                        // Display total
                        CabinetHeightSumLabel.Text = GetHeight().ToString();
                    }
                }
                else
                {
                    if (columnList.SelectedIndex != -1)
                    {
                        int columnIndex = columnList.SelectedIndex;
                        columnList.Items[columnIndex] = editValue;
                        modelParameters.XCoordinates[columnIndex + 1] = editValue;
                        CabinetLengthSumLabel.Text = GetLength().ToString();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void CabinetRemoveButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (RowEditRadioButton.Checked)
            {
                if (rowList.SelectedIndex != -1)
                {
                    int rowIndex = rowList.SelectedIndex;

                    // Remove item at index in UI
                    rowList.Items.RemoveAt(rowIndex);

                    // Remove value from variable list, +1 to shift index away from required 0 value in list
                    modelParameters.ZCoordinates.RemoveAt(rowIndex + 1);

                    // Display total, -1 to account for required value already counted
                    rowSumLabel.Text = (modelParameters.ZCoordinates.Count - 1).ToString();
                    CabinetHeightSumLabel.Text = GetHeight().ToString();
                }
            }
            else
            {
                if (columnList.SelectedIndex != -1)
                {
                    int columnIndex = columnList.SelectedIndex;
                    columnList.Items.RemoveAt(columnIndex);
                    modelParameters.XCoordinates.RemoveAt(columnIndex + 1);
                    columnSumLabel.Text = (modelParameters.XCoordinates.Count - 1).ToString();
                    CabinetLengthSumLabel.Text = GetLength().ToString();
                }
            }
            button1.Enabled = false;
        }

        private void CabinetResetButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            // Clear UI list
            rowList.Items.Clear();
            columnList.Items.Clear();

            // Remove all items except first value 0
            modelParameters.XCoordinates.RemoveRange(1, modelParameters.XCoordinates.Count - 1);
            modelParameters.ZCoordinates.RemoveRange(1, modelParameters.ZCoordinates.Count - 1);

            // Reset label
            rowSumLabel.Text = (modelParameters.XCoordinates.Count - 1).ToString();
            columnSumLabel.Text = (modelParameters.ZCoordinates.Count - 1).ToString();
            CabinetEditValue.Text = "";
            CabinetLengthSumLabel.Text = "0";
            CabinetHeightSumLabel.Text = "0";
        }

        private void LEDMaterial_TextChanged(object sender, EventArgs e)
        {
            modelParameters.LEDMaterial = LEDMaterial.Text;
        }

        private void LEDProfile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.LEDProfile = LEDProfile.Text;
        }

        private void C1Material_TextChanged(object sender, EventArgs e)
        {
            modelParameters.C1Material = C1Material.Text;
        }

        private void C1Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.C1Profile = C1Profile.Text;
        }

        private void B1Material_TextChanged(object sender, EventArgs e)
        {
            modelParameters.B1Material = B1Material.Text;
        }

        private void B1Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.B1Profile = B1Profile.Text;
        }

        private void B2Material_TextChanged(object sender, EventArgs e)
        {
            modelParameters.B2Material = B2Material.Text;
        }

        private void B2Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.B2Profile = B2Profile.Text;
        }

        private void B5Material_TextChanged(object sender, EventArgs e)
        {
            modelParameters.B5Material = B5Material.Text;
        }

        private void B5Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.B5Profile = B5Profile.Text;
        }
        
        private void HoleHorizontalOffset_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(HoleHorizontalOffset.Text))
                {
                    modelParameters.BoltOffsetDx = Convert.ToDouble(HoleHorizontalOffset.Text);
                }
                else
                {
                    modelParameters.BoltOffsetDx = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.BoltOffsetDx = -1;
            }
        }

        private void HoleVerticalOffset_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(HoleVerticalOffset.Text))
                {
                    modelParameters.BoltOffsetDy = Convert.ToDouble(HoleVerticalOffset.Text);
                }
                else
                {
                    modelParameters.BoltOffsetDy = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.BoltOffsetDy = -1;
            }
        }

        private void HeightOffsetTop_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(HeightOffsetTop.Text))
                {
                    modelParameters.HeightOffsetTop = Convert.ToDouble(HeightOffsetTop.Text);
                }
                else
                {
                    modelParameters.HeightOffsetTop = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.HeightOffsetTop = -1;
            }
        }

        private void HeightOffsetBottom_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(HeightOffsetBottom.Text))
                {
                    modelParameters.HeightOffsetBottom = Convert.ToDouble(HeightOffsetBottom.Text);
                }
                else
                {
                    modelParameters.HeightOffsetBottom = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.HeightOffsetBottom = -1;
            }
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            // Check if all inputs are valid, enable build button if it is
            if (modelParameters.ValidateInputs())
            {
                button1.Enabled = true;
            }
        }

        private void B3Material_TextChanged(object sender, EventArgs e)
        {
            modelParameters.B3Material=B3Material.Text;
        }

        private void B3Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.B3Profile = B3Profile.Text;
        }

        private void BR1Material_TextChanged(object sender, EventArgs e)
        {
            modelParameters.BR1Material=BR1Material.Text;
        }

        private void BR1Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.BR1Profile = BR1Profile.Text;
        }

        private void RailingSpace1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(RailingSpace1.Text))
                {
                    modelParameters.RailingSpace1 = Convert.ToDouble(RailingSpace1.Text);
                    modelParameters.RailingCoordinates[0] = modelParameters.RailingSpace1;
                }
                else
                {
                    modelParameters.RailingSpace1 = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.RailingSpace1 = -1;
            }
        }

        private void RailingSpace2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(RailingSpace2.Text))
                {
                    modelParameters.RailingSpace2 = Convert.ToDouble(RailingSpace2.Text);
                    modelParameters.RailingCoordinates[1] = modelParameters.RailingSpace2;
                }
                else
                {
                    modelParameters.RailingSpace2 = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.RailingSpace2 = -1;
            }
        }

        private void MeshThickness_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(MeshThickness.Text))
                {
                    modelParameters.MeshThickness = Convert.ToDouble(MeshThickness.Text);
                }
                else
                {
                    modelParameters.MeshThickness = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.MeshThickness = -1;
            }
        }

        private void Welding_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(Welding.Text))
                {
                    modelParameters.WeldOffset = Convert.ToDouble(Welding.Text);
                }
                else
                {
                    modelParameters.WeldOffset = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.WeldOffset = -1;
            }
        }

        private void StructureManualRadio_CheckedChanged(object sender, EventArgs e)
        {
            // Enable value editing if manual input
            if (StructureManualRadio.Checked == true)
            {
                HorizontalBeamsAddValue.Enabled = true;
                HorizontalBeamsAddButton.Enabled = true;
                HorizontalBeamsEditValue.Enabled = true;
                HorizontalBeamsEditButton.Enabled = true;
                HorizontalBeamsRemoveButton.Enabled = true;
                HorizontalBeamsResetButton.Enabled = true;
                modelParameters.AutoSpacing = false;
            }
            else
            {
                HorizontalBeamsAddValue.Enabled = false;
                HorizontalBeamsAddButton.Enabled = false;
                HorizontalBeamsEditValue.Enabled = false;
                HorizontalBeamsEditButton.Enabled = false;
                HorizontalBeamsRemoveButton.Enabled = false;
                HorizontalBeamsResetButton.Enabled = false;
                modelParameters.AutoSpacing = true;
            }
        }

        private void HorizontalBeamsAddButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                double addValue = Convert.ToDouble(HorizontalBeamsAddValue.Text);

                if (addValue <= 0)
                {
                    throw new Exception();
                }

                HorizontalBeamsList.Items.Add(addValue);
                modelParameters.RailingCoordinates.Add(addValue);
                BeamsSumLabel.Text = (modelParameters.RailingCoordinates.Count - 2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void HorizontalBeamsEditButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                double editValue = Convert.ToDouble(HorizontalBeamsEditValue.Text);

                if (editValue <= 0)
                {
                    throw new Exception();
                }

                if (HorizontalBeamsList.SelectedIndex != -1)
                {
                    int rowIndex = HorizontalBeamsList.SelectedIndex;
                    HorizontalBeamsList.Items[rowIndex] = editValue;
                    modelParameters.RailingCoordinates[rowIndex + 2] = editValue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void HorizontalBeamsRemoveButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (HorizontalBeamsList.SelectedIndex != -1)
            {
                int editIndex = HorizontalBeamsList.SelectedIndex;
                HorizontalBeamsList.Items.RemoveAt(editIndex);
                modelParameters.RailingCoordinates.RemoveAt(editIndex + 2);
                BeamsSumLabel.Text = (modelParameters.RailingCoordinates.Count - 2).ToString();
                HorizontalBeamsEditValue.Text = "";
            }
        }

        private void HorizontalBeamsResetButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            HorizontalBeamsList.Items.Clear();
            modelParameters.RailingCoordinates.RemoveRange(2, modelParameters.RailingCoordinates.Count - 2);
            BeamsSumLabel.Text = (modelParameters.RailingCoordinates.Count - 2).ToString();
            HorizontalBeamsEditValue.Text = "";
        }

        private void HorizontalBeamsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HorizontalBeamsEditValue.Text = HorizontalBeamsList.SelectedIndex == -1 ? "" : HorizontalBeamsList.SelectedItem.ToString();
        }

        private void CornerOffset_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(CornerOffset.Text))
                {
                    modelParameters.CornerOffset = Convert.ToDouble(CornerOffset.Text);
                }
                else
                {
                    modelParameters.CornerOffset = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.CornerOffset = -1;
            }
        }

        private void DiagonalTopOffset_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(DiagonalTopOffset.Text))
                {
                    modelParameters.DiagonalTopOffset = Convert.ToDouble(DiagonalTopOffset.Text);
                }
                else
                {
                    modelParameters.DiagonalTopOffset = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.DiagonalTopOffset = -1;
            }
        }

        private void BoltDiameter_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(BoltDiameter.Text))
                {
                    modelParameters.BoltSize = Convert.ToDouble(BoltDiameter.Text);
                }
                else
                {
                    modelParameters.BoltSize = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.BoltSize = -1;
            }
        }

        private void DiagonalBottomOffset_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(DiagonalBottomOffset.Text))
                {
                    modelParameters.DiagonalBottomOffset = Convert.ToDouble(DiagonalBottomOffset.Text);
                }
                else
                {
                    modelParameters.DiagonalBottomOffset = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.DiagonalBottomOffset = -1;
            }
        }

        private void WalerAutoRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (WalerAutoRadio.Checked)
            {
                modelParameters.WalerAuto = true;
                WalerNumberLabel.Visible = true;
                WalerAddButton.Enabled = false;
                WalerEditValue.Enabled = false;
                WalerEditButton.Enabled = false;
                WalerRemoveButton.Enabled = false;
                WalerResetButton.Enabled = false;
                WalersSumLabel.Text = modelParameters.WalersNumber.ToString();
                WalerAddValue.Text = modelParameters.WalersNumber.ToString();
            } else
            {
                modelParameters.WalerAuto = false;
                WalerNumberLabel.Visible = false;
                WalerAddButton.Enabled = true;
                WalerEditValue.Enabled = true;
                WalerEditButton.Enabled = true;
                WalerRemoveButton.Enabled = true;
                WalerResetButton.Enabled = true;
                WalersSumLabel.Text = modelParameters.WalersCoordinates.Count.ToString();
                WalerAddValue.Text = "";
            }
        }

        private void WalerAddButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                double addValue = Convert.ToDouble(WalerAddValue.Text);

                if (addValue <= 0)
                {
                    throw new Exception();
                }

                WalersList.Items.Add(addValue);
                modelParameters.WalersCoordinates.Add(addValue);
                WalersSumLabel.Text = modelParameters.WalersCoordinates.Count.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void WalerEditButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                double editValue = Convert.ToDouble(WalerEditValue.Text);

                if (editValue <= 0)
                {
                    throw new Exception();
                }

                if (WalersList.SelectedIndex != -1)
                {
                    int rowIndex = WalersList.SelectedIndex;
                    WalersList.Items[rowIndex] = editValue;
                    modelParameters.WalersCoordinates[rowIndex] = editValue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void WalerRemoveButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (WalersList.SelectedIndex != -1)
            {
                int editIndex = WalersList.SelectedIndex;
                WalersList.Items.RemoveAt(editIndex);
                modelParameters.WalersCoordinates.RemoveAt(editIndex);
                WalersSumLabel.Text = (modelParameters.WalersCoordinates.Count).ToString();
                WalerEditValue.Text = "";
            }
        }

        private void WalerResetButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            WalersList.Items.Clear();
            modelParameters.WalersCoordinates.Clear();
            WalersSumLabel.Text = (modelParameters.WalersCoordinates.Count).ToString();
            WalerEditValue.Text = "";
        }

        private void WalersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WalerEditValue.Text = WalersList.SelectedIndex == -1 ? "" : WalersList.SelectedItem.ToString();
        }

        private void WalerMaterial_TextChanged(object sender, EventArgs e)
        {
            modelParameters.WalerMaterial = WalerMaterial.Text;
        }

        private void WalerProfile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.WalerProfile = WalerProfile.Text;
        }

        private void WalerAddValue_TextChanged(object sender, EventArgs e)
        {
            if (WalerAutoRadio.Checked)
            {
                try
                {
                    if (WalerAddValue.Text == "")
                    {
                        modelParameters.WalersNumber = 0;
                        WalersSumLabel.Text = "0";
                        return;
                    }
                    modelParameters.WalersNumber = Convert.ToInt32(WalerAddValue.Text);
                    WalersSumLabel.Text = modelParameters.WalersNumber.ToString();
                }
                catch (Exception)
                {
                    WalerAddValue.Text = "0";
                    modelParameters.WalersNumber = 0;
                    WalersSumLabel.Text = "0";
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        private void UpperWalerSpacing_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(UpperWalerSpacing.Text))
                {
                    modelParameters.UpperWalerSpacing = Convert.ToDouble(UpperWalerSpacing.Text);
                }
                else
                {
                    modelParameters.UpperWalerSpacing = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.UpperWalerSpacing = -1;
            }
        }

        private void LowerWalerSpacing_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(LowerWalerSpacing.Text))
                {
                    modelParameters.LowerWalerSpacing = Convert.ToDouble(LowerWalerSpacing.Text);
                }
                else
                {
                    modelParameters.LowerWalerSpacing = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.LowerWalerSpacing = -1;
            }
        }

        private void SeatingPlateOffset_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(SeatingPlateOffset.Text))
                {
                    modelParameters.SeatingPlateOffset = Convert.ToDouble(SeatingPlateOffset.Text);
                }
                else
                {
                    modelParameters.SeatingPlateOffset = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.SeatingPlateOffset = -1;
            }
        }

        private void ExtrusionLength_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(ExtrusionLength.Text))
                {
                    modelParameters.SeatingPlateExtrusionLength = Convert.ToDouble(ExtrusionLength.Text);
                }
                else
                {
                    modelParameters.SeatingPlateExtrusionLength = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.SeatingPlateExtrusionLength = -1;
            }
        }

        private void SeatingPlateMaterial_TextChanged(object sender, EventArgs e)
        {
            modelParameters.SeatingPlateMaterial = SeatingPlateMaterial.Text;
        }

        private void SeatingPlateProfile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.SeatingPlateProfile = SeatingPlateProfile.Text;
        }

        private void SeatingPlateOnButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SeatingPlateOnButton.Checked == true)
            {
                modelParameters.BuildSeatingPlate = true;
                SeatingPlateOffset.Enabled = true;
                ExtrusionLength.Enabled = true;
                validateDouble(SeatingPlateOffset);
                validateDouble(ExtrusionLength);
            }
            else
            {
                modelParameters.BuildSeatingPlate = false;
                SeatingPlateOffset.Enabled = false;
                ExtrusionLength.Enabled = false;
                errorProvider.SetError(SeatingPlateOffset, null);
                errorProvider.SetError(ExtrusionLength, null);
            }
        }

        private void EAMaterial_TextChanged(object sender, EventArgs e)
        {
            modelParameters.EAMaterial = EAMaterial.Text;
        }

        private void WalkwayMaterial_TextChanged(object sender, EventArgs e)
        {
            modelParameters.MeshMaterial = WalkwayMaterial.Text;
        }

        private void EAProfile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.EAProfile= EAProfile.Text;
        }

        private void EAClearance_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(EAClearance.Text))
                {
                    modelParameters.EASupportClearance = Convert.ToDouble(EAClearance.Text);
                }
                else
                {
                    modelParameters.EASupportClearance = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.EASupportClearance = -1;
            }
        }

        private void ZBracketMaterial_TextChanged(object sender, EventArgs e)
        {
            modelParameters.BracketMaterial = ZBracketMaterial.Text;

        }

        private void ZBracketProfile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            modelParameters.BracketProfile = ZBracketProfile.Text;
        }

        private void ZbracketSpacingA_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(ZbracketSpacingA.Text))
                {
                    modelParameters.BracketASpacing = Convert.ToDouble(ZbracketSpacingA.Text);
                }
                else
                {
                    modelParameters.BracketASpacing = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.BracketASpacing = -1;
            }
        }
        
        private void ZbracketSpacingB_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(ZbracketSpacingB.Text))
                {
                    modelParameters.BracketBSpacing = Convert.ToDouble(ZbracketSpacingB.Text);
                }
                else
                {
                    modelParameters.BracketBSpacing = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.BracketBSpacing = -1;
            }
        }
        
        private void WalkwayClearance_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(WalkwayClearance.Text))
                {
                    modelParameters.WalkwayClearance = Convert.ToDouble(WalkwayClearance.Text);
                }
                else
                {
                    modelParameters.WalkwayClearance = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.WalkwayClearance = -1;
            }
        }
        
        private void WalkwayWidth_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(WalkwayWidth.Text))
                {
                    modelParameters.WalkwayWidth = Convert.ToDouble(WalkwayWidth.Text);
                }
                else
                {
                    modelParameters.WalkwayWidth = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.WalkwayWidth = -1;
            }
        }
        
        private void ZbracketEndSpacing_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(ZbracketEndSpacing.Text))
                {
                    modelParameters.EndBracketSpacing = Convert.ToDouble(ZbracketEndSpacing.Text);
                }
                else
                {
                    modelParameters.EndBracketSpacing = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.EndBracketSpacing = -1;
            }
        }
        
        private void BracketBoltStandard_TextChanged(object sender, EventArgs e)
        {
            modelParameters.BracketBoltStandard = BracketBoltStandard.Text;
        }
        
        private void BracketBoltDiameter_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                if (RegexValidateDouble(BracketBoltDiameter.Text))
                {
                    modelParameters.BracketBoltDiameter = Convert.ToDouble(BracketBoltDiameter.Text);
                }
                else
                {
                    modelParameters.BracketBoltDiameter = -1;
                }
            }
            catch (Exception)
            {
                modelParameters.BracketBoltDiameter = -1;
            }
        }
        
        private bool RegexValidateDouble(string text)
        {
            return Regex.IsMatch(text, @"^\d+(?:\.\d+)?$");
        }
    }

    class Frame
    {
        /* Figure 1. Representation of a single plane of the frame box (side view).
           ________
        3 |        | 4
          |        |
          |        |  front 
          |        |
          |        |
          |________|
        2            1
            bottom
    
        */
        public TSG.Point Point1 { get; set; }
        public TSG.Point Point2 { get; set; }
        public TSG.Point Point3 { get; set; }
        public TSG.Point Point4 { get; set; }
        public int PlaneType { get; set; }
        public Beam Front { get; set; }
        public Beam Back { get; set; }
        public Beam Top { get; set; }
        public Beam Bottom { get; set; }
        public ContourPlate Seatplate { get; set; }
        public ModelParameters ModelParameters { get; set; }

        public Frame
            (
                TSG.Point point1,
                TSG.Point point2,
                TSG.Point point3,
                TSG.Point point4,
                int planeType,
                ModelParameters modelParameters
            )
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
            this.Point4 = point4;
            this.PlaneType = planeType;
            this.ModelParameters = modelParameters;

            BuildFrame();
        }

        // MILESTONE 2 - BUILD FRAME
        private void BuildFrame()
        {

            // Create points for the weld offsets
            TSG.Point weldingOffsetPointY = new TSG.Point(0, ModelParameters.WeldOffset, 0);
            TSG.Point weldingOffsetPointZ = new TSG.Point(0, 0, ModelParameters.WeldOffset);

            // Initialise B1 dimension profile
            double[] b1Dimensions = BeamDimensions(ModelParameters.B1Profile);

            // FRONT VERTICAL BEAMS (Points 1-4)
            // Initialise FRONT dimension profile
            double[] frontDimensions = BeamDimensions(ModelParameters.C1Profile);

            /*
            *  OFFSET POINT GENERATION
            *  Different points were generated in the x,y,z direction to offset the original origins of the beams in tekla.
            *  The result was that the beam's edges matched.
            */

            // Move the model's orgin in the postive x direction origin by half front beam width.
            TSG.Point frontOffsetX = new TSG.Point(0.5 * frontDimensions[1], 0, 0);

            // Move the model's orgin in the postive y direction by half the front beam depth.
            TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontDimensions[0], 0);

            // Reduce the length of the front beam in the z direction by twice the B1 depth 
            TSG.Point frontOffsetZ = new TSG.Point(0, 0, 2 * b1Dimensions[1]);

            /* 
             * POSITION PARAMETERS
             * First Element in Array -> Depth
             * Second Element in Array -> Plane
             * Third Element in Array -> Rotation
             */
            int[] frontEnums = new int[] { 0, 0, 3 };
            double[] frontOffsets = new double[] { 0.0, 0.0, 90.0 };

            TSG.Point ColumnPoint = Point1 + frontOffsetX + frontOffsetY + weldingOffsetPointZ;

            // CREATE Front Beam
            Front = CreateBeam(ColumnPoint, Point4 + frontOffsetX + frontOffsetY - frontOffsetZ - weldingOffsetPointZ, ModelParameters.C1Material, ModelParameters.C1Profile,"2", frontEnums, frontOffsets);

            // BACK VERTICAL BEAMS (Points 3-2)

            // Initialise BACK beam dimensions
            double[] backDimensions = BeamDimensions(ModelParameters.C1Profile);

            // OFFSET POINT GENERATION
            // Move the model's orgin in the postive x direction origin by half back beam width.
            TSG.Point backOffsetX = new TSG.Point(0.5 * backDimensions[1], 0, 0);

            // Move the model's orgin in the postive y direction by half the back beam depth
            TSG.Point backOffsetY = new TSG.Point(0, 0.5 * backDimensions[0], 0);

            // Reduce the length of the back beam in the z direction by twice the B1 depth 
            TSG.Point backOffsetZ = new TSG.Point(0, 0, 2 * b1Dimensions[1]);


            // POSITION PARAMETERS
            int[] backEnums = new int[] { 0, 0, 0 };
            double[] backOffsets = new double[] { 0.0, 0.0, 0.0 };

            // CREATE back beam
            Back = CreateBeam(Point2 + backOffsetX - backOffsetY + weldingOffsetPointZ, Point3 + backOffsetX - backOffsetY - backOffsetZ - weldingOffsetPointZ, ModelParameters.C1Material, ModelParameters.C1Profile, "2",backEnums, backOffsets);

            // BOTTOM HORIZONTAL BEAM (Points 2-1)
            // Initialise BOTTOM dimension profile
            double[] bottomDimensions = BeamDimensions(ModelParameters.B5Profile);

            // Bottom beam Position parameters
            int[] bottomEnums = new int[] { 0, 1, 2 };
            double[] bottomOffsets = new double[] { 0.0, 0.0, 90 };

            // TOP HORIZONTAL BEAMS (Points 3-4)
            // Top beam Position parameters
            int[] topEnums = new int[] { 0, 2, 2 };
            double[] topOffsets = new double[] { 0.0, 0.0, 90 };

            // Get the dimensions for the B5 beams
            double[] topDimensions = BeamDimensions(ModelParameters.B2Profile);

            // Check to see what plane it is 
            // If it is the first plane 
            // Plane == 0 -> First Plane
            // Plane == 1 -> In between
            // Everything else -> Last Plane
            if (PlaneType == 0)
            {
                // First plane 
                // Shift the bottom beam in the first plane by half the width of the bottom beam.
                TSG.Point bottomOffsetX = new TSG.Point(bottomDimensions[1] * 0.5, 0, 0);

                // Reduce the length of the bottom beam by the width of B1 beam such that it alligns 
                TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Shift the bottom beam in the negtive z direction by the width of the B1 beam.
                TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);
                Bottom = CreateBeam(Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + weldingOffsetPointY, Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - weldingOffsetPointY, ModelParameters.B5Material, ModelParameters.B5Profile,"4", bottomEnums, bottomOffsets);

                if (ModelParameters.BuildSeatingPlate)
                {
                    CreateSeatingPlate(ColumnPoint + new TSG.Point(frontDimensions[1] / 2 + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0), frontDimensions, ModelParameters, true);
                }

                // Shift the bottom beam in the first plane by half the width of the bottom beam.
                TSG.Point topOffsetX = new TSG.Point(topDimensions[1] * 0.5, 0, 0);

                // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Bring down the top beams by B1 depth so it aligns with the frame 
                TSG.Point topOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // CREATE the TOP beam
                Top = CreateBeam(Point4 + topOffsetY - topOffsetZ + weldingOffsetPointY + topOffsetX, Point3 - topOffsetY - topOffsetZ - weldingOffsetPointY + topOffsetX, ModelParameters.B2Material, ModelParameters.B2Profile,"4", topEnums, topOffsets);


            }
            else if (PlaneType == 1)
            {
                // Middle Planes
                // Align the bottom beams with the far edge of the structure -> 
                TSG.Point bottomOffsetX = new TSG.Point(bottomDimensions[1] * 0.5 - (bottomDimensions[1] - frontDimensions[1]) * 0.5, 0, 0);

                // Reduce the length of the bottom beam by the width of B1 beam such that it alligns 
                TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Shift the bottom beam in the negtive z direction by the width of the B1 beam.
                TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);
                Bottom = CreateBeam(Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + weldingOffsetPointY, Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - weldingOffsetPointY, ModelParameters.B5Material, ModelParameters.B5Profile, "4", bottomEnums, bottomOffsets);

                if (ModelParameters.BuildSeatingPlate)
                {
                    CreateSeatingPlate(ColumnPoint, frontDimensions, ModelParameters, false);
                }

                // Shift the bottom beam in the first plane by half the width of the bottom beam.
                TSG.Point topOffsetX = new TSG.Point(topDimensions[1] * 0.5 - (topDimensions[1] - frontDimensions[1]) * 0.5, 0, 0);

                // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Bring down the top beams by B1 depth so it aligns with the frame 
                TSG.Point topOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // CREATE the TOP beam
                Top = CreateBeam(Point4 + topOffsetY - topOffsetZ + weldingOffsetPointY + topOffsetX, Point3 - topOffsetY - topOffsetZ - weldingOffsetPointY + topOffsetX, ModelParameters.B2Material, ModelParameters.B2Profile, "4", topEnums, topOffsets);

            }
            else
            {
                // Last Plane
                // Align the bottom beam with the center of B1 -> align it to the left edge of B1 by shifting it by half the bottom beam width in the postive x direction
                // -> shift it in the negtive x direction by half the difference between the width of the bottom beam and the front beam.
                TSG.Point bottomOffsetX = new TSG.Point(bottomDimensions[1] * 0.5 - (bottomDimensions[1] - frontDimensions[1]), 0, 0);  // (width of b5 - width of c1

                // Reduce the length of the bottom beam by the width of B1 beam such that it alligns 
                TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Shift the bottom beam in the negtive z direction by the width of the B1 beam.
                TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);
                Bottom = CreateBeam(Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + weldingOffsetPointY, Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - weldingOffsetPointY, ModelParameters.B5Material, ModelParameters.B5Profile, "4", bottomEnums, bottomOffsets);

                if (ModelParameters.BuildSeatingPlate)
                {
                    CreateSeatingPlate(ColumnPoint - new TSG.Point((frontDimensions[1] / 2) + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0), frontDimensions, ModelParameters, true);                    
                }

                // Shift the bottom beam in the first plane by half the width of the bottom beam.
                TSG.Point topOffsetX = new TSG.Point(topDimensions[1] * 0.5 - (topDimensions[1] - frontDimensions[1]), 0, 0);

                // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Bring down the top beams by B1 depth so it aligns with the frame 
                TSG.Point topOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // CREATE the TOP beam
                Top = CreateBeam(Point4 + topOffsetY - topOffsetZ + weldingOffsetPointY + topOffsetX, Point3 - topOffsetY - topOffsetZ - weldingOffsetPointY + topOffsetX, ModelParameters.B2Material, ModelParameters.B2Profile, "4", topEnums, topOffsets);

            }
        }
        //method to create a seating plate
        private static ContourPlate CreateSeatingPlate(TSG.Point C1BeamOrigin, double[] frontDimensions, ModelParameters modelParameters, bool EndPlate)
        {

            // Depth and Width of the reference column
            double ColDepth = frontDimensions[0];
            double ColWidth = frontDimensions[1];

            // Create a new Contour Plate
            ContourPlate CP = new ContourPlate();
            CP.Profile.ProfileString = modelParameters.SeatingPlateProfile;
            CP.Material.MaterialString = modelParameters.SeatingPlateMaterial;
            CP.Class = "5";

            // Get the thickness of the seating plate
            double PlateDepth = Convert.ToDouble(modelParameters.SeatingPlateProfile.Substring(2));
            double ZPosition = C1BeamOrigin.Z + (PlateDepth / 2) - modelParameters.WeldOffset;

            double a = modelParameters.SeatingPlateExtrusionLength;

            // If the plate is at the end
            if (EndPlate)
            {
                // Define plate points
                ContourPoint point1a = new ContourPoint(new TSG.Point(C1BeamOrigin.X - (65.0 / 2), C1BeamOrigin.Y + (ColDepth / 2), ZPosition), null);
                ContourPoint point2b = new ContourPoint(new TSG.Point(point1a.X, point1a.Y - ColDepth - a + 20, ZPosition), null);
                ContourPoint point3c = new ContourPoint(new TSG.Point(point2b.X + 20, point2b.Y - 20, ZPosition), null);
                ContourPoint point4d = new ContourPoint(new TSG.Point(point3c.X + 25, point3c.Y, ZPosition), null);
                ContourPoint point5e = new ContourPoint(new TSG.Point(point4d.X + 20, point4d.Y + 20, ZPosition), null);
                ContourPoint point6f = new ContourPoint(new TSG.Point(point5e.X, point1a.Y, ZPosition), null);

                // Add points to plate
                CP.AddContourPoint(point1a);
                CP.AddContourPoint(point2b);
                CP.AddContourPoint(point3c);
                CP.AddContourPoint(point4d);
                CP.AddContourPoint(point5e);
                CP.AddContourPoint(point6f);
            }
            else
            {
                // Define plate points
                ContourPoint point1a = new ContourPoint(new TSG.Point(C1BeamOrigin.X - (ColWidth * 0.5) - modelParameters.SeatingPlateOffset, C1BeamOrigin.Y - (ColDepth * 0.5) - modelParameters.SeatingPlateOffset, ZPosition), null);
                ContourPoint point2b = new ContourPoint(new TSG.Point(point1a.X, C1BeamOrigin.Y + (ColDepth * 0.5), ZPosition), null);
                ContourPoint point3c = new ContourPoint(new TSG.Point(point1a.X - 25, point2b.Y, ZPosition), null);
                ContourPoint point4d = new ContourPoint(new TSG.Point(point3c.X, point3c.Y - ColDepth - (a - 20), ZPosition), null);
                ContourPoint point5e = new ContourPoint(new TSG.Point(point4d.X + 20, C1BeamOrigin.Y - (ColDepth * 0.5) - a, ZPosition), null);

                ContourPoint point10j = new ContourPoint(new TSG.Point(C1BeamOrigin.X + (ColWidth * 0.5) + modelParameters.SeatingPlateOffset, point1a.Y, ZPosition), null);
                ContourPoint point9i = new ContourPoint(new TSG.Point(point10j.X, point2b.Y, ZPosition), null);
                ContourPoint point8h = new ContourPoint(new TSG.Point(point9i.X + 25, point3c.Y, ZPosition), null);
                ContourPoint point7g = new ContourPoint(new TSG.Point(point8h.X, point4d.Y, ZPosition), null);
                ContourPoint point6f = new ContourPoint(new TSG.Point(point7g.X - 20, point5e.Y, ZPosition), null);

                // Add points to plate
                CP.AddContourPoint(point1a);
                CP.AddContourPoint(point2b);
                CP.AddContourPoint(point3c);
                CP.AddContourPoint(point4d);
                CP.AddContourPoint(point5e);
                CP.AddContourPoint(point6f);
                CP.AddContourPoint(point7g);
                CP.AddContourPoint(point8h);
                CP.AddContourPoint(point9i);
                CP.AddContourPoint(point10j);
            }

            // Insert plate
            if (!CP.Insert())
            {
                MessageBox.Show("Insertion of Seating Plate failed.");
            }

            return CP;
        }

        // method to create a beam
        // enums and offset element position
        // 1st element [0] = Depth
        // 2nd element [1] = Plane
        // 3rd element [2] = Rotation
        private static Beam CreateBeam(TSG.Point startPos, TSG.Point endPos, string material, string profile, string beamClass, int[] enums, double[] offsets)
        {

            // Beam properties
            Beam beam = new Beam(startPos, endPos);
            beam.Profile.ProfileString = profile;
            beam.Material.MaterialString = material;

            // Depth position - First element in the array : 0 - Middle, 1 - Front, 2 - Back
            beam.Position.Depth = (Position.DepthEnum)enums[0];
            beam.Position.DepthOffset = offsets[0];

            // Plane position - Second element in the array : 0 - Middle, 1 - Left, 2 - Right
            beam.Position.Plane = (Position.PlaneEnum)enums[1];
            beam.Position.PlaneOffset = offsets[1];

            // Rotation position - Third element in the array : 0 - Front, 1 - Top, 2 - Back, 3 - Below
            beam.Position.Rotation = (Position.RotationEnum)enums[2];
            beam.Position.RotationOffset = offsets[2];

            beam.Class = beamClass;

            if (!beam.Insert())
            {
                Console.WriteLine("Insertion of beam failed.");
            }

            return beam;
        }

        // method to turn beam profile dimensions string into an array of doubles for dimensions
        private static double[] BeamDimensions(string dimensionString)
        {
            // Remove first three characters in string and split string into an array from * points 
            string[] FinalDimensions = dimensionString.Substring(3).Split('*');

            // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
            double beamDepth = Convert.ToDouble(FinalDimensions[0]);
            double beamWidth = Convert.ToDouble(FinalDimensions[1]);
            double beamThicccness = Convert.ToDouble(FinalDimensions[2]);
            return new double[] { beamDepth, beamWidth, beamThicccness };
        }
    }

    class Plate
    {
        /*
           ________
        4 |        | 3
          |        |
          |        |
          |        |
          |        |
          |________|
        1            2
    
        */

        public TSG.Point Point1 { get; set; }
        public TSG.Point Point2 { get; set; }
        public TSG.Point Point3 { get; set; }
        public TSG.Point Point4 { get; set; }
        public ModelParameters ModelParameters { get; set; }
        public ContourPlate ContourPlate { get; set; }

        public Plate(TSG.Point point1, TSG.Point point2, TSG.Point point3, TSG.Point point4, ModelParameters modelParameters) {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
            this.Point4 = point4;
            this.ModelParameters = modelParameters;

            BuildPlate();
        }

        // build the cabinet
        private void BuildPlate() {
            ContourPlate = CreatePlate(Point1, Point2, Point3, Point4, ModelParameters);
        }

        // method to create a plate
        private static ContourPlate CreatePlate(TSG.Point point1, TSG.Point point2, TSG.Point point3, TSG.Point point4, ModelParameters modelParameters) {

            var contour = new Contour();
            contour.AddContourPoint(new ContourPoint(point1, null));
            contour.AddContourPoint(new ContourPoint(point2, null));
            contour.AddContourPoint(new ContourPoint(point3, null));
            contour.AddContourPoint(new ContourPoint(point4, null));

            ContourPlate plate = new ContourPlate
            {
                Name = "SCREEN",
                Material = {
                    MaterialString = modelParameters.LEDMaterial
                },
                Profile = { 
                    ProfileString = modelParameters.LEDProfile
                },
                Class = "0",
                Position = { 
                    Depth = Position.DepthEnum.FRONT, 
                    DepthOffset = 0.0,
                },
                Contour = contour
            };
            if (!plate.Insert()) {
                MessageBox.Show("Insertion of plate failed.");
            }

            return plate;
        }
    }

    public class ModelParameters
    {
        public List<double> XCoordinates { get; set; }
        public List<double> ZCoordinates { get; set; }

        // Walers
        public double UpperWalerSpacing { get; set; }
        public double LowerWalerSpacing { get; set; }
        public List<double> WalersCoordinates { get; set; }
        public int WalersNumber { get; set; }
        public bool WalerAuto { get; set; }

        // Railings & Horizontal Back Beams
        public double RailingSpace1 { get; set; }
        public double RailingSpace2 { get; set; }
        public List<double> RailingCoordinates { get; set; }
        public bool AutoSpacing { get; set; }

        // Material 
        public string LEDMaterial { get; set; }
        public string C1Material { get; set; }
        public string B1Material { get; set; }
        public string B2Material { get; set; }
        public string B3Material { get; set; }
        public string B5Material { get; set; }
        public string BR1Material { get; set; }
        public string SeatingPlateMaterial { get; set; }
        public string WalerMaterial { get; set; }
        public string EAMaterial { get; set; }
        public string BracketMaterial { get; set; }
        public string MeshMaterial { get; set; }

        // Profile
        public string LEDProfile { get; set; }
        public string C1Profile { get; set; }
        public string B1Profile { get; set; }
        public string B2Profile { get; set; }
        public string B3Profile { get; set; }
        public string B5Profile { get; set; }
        public string BR1Profile { get; set; }
        public string SeatingPlateProfile { get; set; }
        public string WalerProfile { get; set; }
        public string EAProfile { get; set; }
        public string BracketProfile { get; set; }

        // Cabinets
        public double BoltSize { get; set; }
        public double BoltOffsetDy { get; set; } //dy is the horizontal offset
        public double BoltOffsetDx { get; set; } //dx - vertical offset

        // The gap between the screen and top and bottom beam
        public double HeightOffsetTop { get; set; }
        public double HeightOffsetBottom { get; set; }

        // Walkways
        public double MeshThickness { get; set; }
        public double WalkwayWidth { get; set; }
        public double WalkwayClearance { get; set; }
        public double EASupportClearance { get; set; }

        // Diagonals

        public double DiagonalTopOffset { get; set; }
        public double DiagonalBottomOffset { get; set; }
        public double CornerOffset { get; set; }

        // Seating Plates
        public double SeatingPlateOffset { get; set; }
        public double SeatingPlateExtrusionLength { get; set; }
        public bool BuildSeatingPlate { get; set; }

        // Z Brackets
        public double BracketASpacing { get; set; }
        public double BracketBSpacing { get; set; }
        public double EndBracketSpacing { get; set; }
        public string BracketBoltStandard { get; set; }
        public double BracketBoltDiameter { get; set; }

        // Others
        public double WeldOffset { get; set; }
        public double BillboardHeight { get; set; }
        public double BillboardLength { get; set; }

        public ModelParameters()
        {
            // Initial coordinate 0
            XCoordinates = new List<double>() { 0 };
            ZCoordinates = new List<double>() { 0 };

            // Walers
            UpperWalerSpacing = 350;
            LowerWalerSpacing = 350;
            WalersCoordinates = new List<double>();
            WalersNumber = 0;
            WalerAuto = true;

            // Railings & Horizontal Back Beams
            RailingSpace1 = 560;
            RailingSpace2 = 550;
            RailingCoordinates = new List<double> { RailingSpace1, RailingSpace2 };
            AutoSpacing = true;

            // Material
            LEDMaterial = "digital";
            C1Material = "C350L0";
            B1Material = "C350L0";
            B2Material = "C350L0";
            B3Material = "C350L0";
            B5Material = "C350L0";
            BR1Material = "C350L0";
            SeatingPlateMaterial = "250";
            WalerMaterial = "C350L0";
            EAMaterial = "C350L0";
            BracketMaterial = "250";
            MeshMaterial = "FM14";

            // Profile
            LEDProfile = "PLT170";
            C1Profile = "RHS75*50*4.0";
            B1Profile = "SHS75*75*4.0";
            B2Profile = "RHS75*50*4.0";
            B3Profile = "SHS50*50*3.0";
            B5Profile = "SHS65*65*4.0";
            BR1Profile = "SHS50*50*3.0";
            SeatingPlateProfile = "FL8";
            WalerProfile = "SHS75*75*4.0";
            EAProfile = "EA50*50*5";
            BracketProfile = "PLT12*75";

            // Cabinets
            BoltSize = 10;
            BoltOffsetDx = 60;
            BoltOffsetDy = 65;
            HeightOffsetTop = 8;
            HeightOffsetBottom = 8;

            // Walkways
            MeshThickness = 14;
            WalkwayWidth = 600;
            WalkwayClearance = 15; 
            EASupportClearance = 50;

            // Diagonals
            DiagonalTopOffset = 0;
            DiagonalBottomOffset = 0;
            CornerOffset = 10;

            // Seating plates
            SeatingPlateOffset = 10;
            SeatingPlateExtrusionLength = 75;
            BuildSeatingPlate = true;

            // Z Brackets
            BracketASpacing = 10;
            BracketBSpacing = 20;
            EndBracketSpacing = 10;
            BracketBoltStandard = "8.8S";
            BracketBoltDiameter = 12.0;

            // Others
            WeldOffset = 1;
            BillboardHeight = 0;
            BillboardLength = 0;
        }

        // Validate input values
        public bool ValidateInputs()
        {
            if (XCoordinates.Count == 1 || ZCoordinates.Count == 1)
            {
                MessageBox.Show("There needs to be at least 1 LED Cabinet");
                return false;
            }
            if (BoltOffsetDx < 0 || BoltOffsetDy < 0)
            {
                MessageBox.Show("Bolt offsets must be greater than 0");
                return false;
            }
            if (BoltSize == -1)
            {
                MessageBox.Show("Invalid Bolt Size");
                return false;
            }
            if (RailingSpace1 <= 0 || RailingSpace2 <= 0)
            {
                MessageBox.Show("Upper/Lower railing spacing must be greater than 0");
                return false;
            }
            if (DiagonalTopOffset < 0 || DiagonalBottomOffset < 0 || CornerOffset < 0)
            {
                MessageBox.Show("Diagonals offset cannot be smaller than 0");
                return false;
            }
            if (HeightOffsetTop == -1 || HeightOffsetBottom == -1)
            {
                MessageBox.Show("Invalid Screen Gap");
                return false;
            }
            if (MeshThickness == -1)
            {
                MessageBox.Show("Invalid Walkway Thickness");
                return false;
            }
            if (WeldOffset == -1)
            {
                MessageBox.Show("Invalid Welding offset");
                return false;
            }
            if (WeldOffset == -1)
            {
                MessageBox.Show("Invalid Welding offset");
                return false;
            }
            if (SeatingPlateOffset == -1 && BuildSeatingPlate)
            {
                MessageBox.Show("Invalid Seating Plate offset");
                return false;
            }
            if (SeatingPlateExtrusionLength == -1 && BuildSeatingPlate)
            {
                MessageBox.Show("Invalid Seating Plate extrusion length");
                return false;
            }
            if (EASupportClearance < 0)
            {
                MessageBox.Show("Walkway EA bracket cannot be smaller than 0");
                return false;
            }
            if (WalkwayClearance == -1)
            {
                MessageBox.Show("Invalid walkway offset");
                return false;
            }
            if (WalkwayWidth == -1)
            {
                MessageBox.Show("Invalid walkway width");
                return false;
            }

            // Get total height
            double totalHeight = 0;
            foreach (var item in ZCoordinates)
            {
                totalHeight += item;
            }

            double totalRailingHeight = 0;
            foreach (var item in RailingCoordinates)
            {
                totalRailingHeight += item;
            }

            double totalWalerHeight = 0;
            foreach (var item in WalersCoordinates)
            {
                totalWalerHeight += item;
            }

            if (UpperWalerSpacing <= 0 || LowerWalerSpacing <= 0)
            {
                MessageBox.Show("Upper/Lower waler spacings myst be greater than 0");
                return false;
            }
            if (!WalerAuto && UpperWalerSpacing + totalWalerHeight + LowerWalerSpacing > totalHeight)
            {
                MessageBox.Show("Waler must be within the billboard height");
                return false;
            }

            if (AutoSpacing)
            {
                // Check if height can include the two railings
                if ((RailingSpace1 + RailingSpace2) > totalHeight)
                {
                    MessageBox.Show("Not enough height to accomodate railings");
                    return false;
                }
            }
            else
            {
                // Check if height can include the two railings
                if (totalRailingHeight > totalHeight)
                {
                    MessageBox.Show("Not enough height to accomodate railings");
                    return false;
                }
            }
            if (BracketASpacing == -1 || BracketBSpacing == -1)
            {
                MessageBox.Show("Invalid middle bracket spacing");
                return false;
            }
            if (EndBracketSpacing == -1)
            {
                MessageBox.Show("Invalid middle bracket spacing");
                return false;
            }
            if (BracketBoltDiameter == -1)
            {
                MessageBox.Show("Invalid bracket bolt diameter");
                return false;
            }
            // Profile validation
            if (!RegexValidate(C1Profile))
            {
                MessageBox.Show("Invalid C1 profile");
                return false;
            }
            if (!RegexValidate(B1Profile))
            {
                MessageBox.Show("Invalid B1 profile");
                return false;
            }
            if (!RegexValidate(B2Profile))
            {
                MessageBox.Show("Invalid B2 profile");
                return false;
            }
            if (!RegexValidate(B3Profile))
            {
                MessageBox.Show("Invalid B3 profile");
                return false;
            }
            if (!RegexValidate(B5Profile))
            {
                MessageBox.Show("Invalid B5 profile");
                return false;
            }
            if (!RegexValidate(BR1Profile))
            {
                MessageBox.Show("Invalid BR1 profile");
                return false;
            }
            if (!RegexValidate(WalerProfile))
            {
                MessageBox.Show("Invalid Waler profile");
                return false;
            }
            if (!Regex.IsMatch(LEDProfile, @"^PLT\d+(?:\.\d+)?$"))
            {
                MessageBox.Show("Invalid LED profile");
                return false;
            }
            if (!Regex.IsMatch(SeatingPlateProfile, @"^(FL)\d+(?:\.\d+)?$"))
            {
                MessageBox.Show("Invalid Plate profile");
                return false;
            }
            if (!Regex.IsMatch(EAProfile, @"^EA\d{2,3}\*\d{2,3}\*\d{1,2}$"))
            {
                MessageBox.Show("Invalid EA profile");
                return false;
            }
            else
            {
                // Remove first three characters in string and split string into an array from * points 
                string[] dimensions = EAProfile.Substring(2).Split('*');

                // Convert the first. second and third string to a double that represents the depth and width of the beam 
                double beamDepth = Convert.ToDouble(dimensions[0]);
                double beamWidth = Convert.ToDouble(dimensions[1]);

                if (beamDepth != beamWidth)
                {
                    MessageBox.Show("Equal Angled beam must have the same depth and width");
                    return false;
                }
            }
            if (!Regex.IsMatch(BracketProfile, @"^PLT\d{1,}(?:\.\d{1,})?(\*)?(?(1)\d{1,}(?:\.\d{1,})?$|$)"))
            {
                MessageBox.Show("Invalid Plate profile");
                return false;
            }

            return true;
        }

        private bool RegexValidate(string text)
        {
            return Regex.IsMatch(text, @"^[SR]{1}HS\d{2,3}\*\d{2,3}\*\d{1,2}\.\d{1}$");
        }
    }
}
