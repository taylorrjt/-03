using System;
using System.Collections.Generic;
using System.Text;

namespace AGCLibrary
{
    public class SpacerCard
    {
        #region Horizontal Variables and spacer length
        public int HorizontalGearCaseDeviation { get; set; }
        public int HorizontalCarrierDeviation { get; set; }
        public int Bearing { get; set; }
        public float HMDGear { get; set; }
        public float HorizontalSpacerLength { get; private set; } //Will be initialized with the class if needed variables are set.
        #endregion

        #region Vertical Variables and spacer length
        public int VerticalGearCaseDeviation { get; set; }
        public int VerticalCarrierDeviation { get; set; }
        public int GearMount { get; set; }
        public float VMDGear { get; set; }
        public float VerticalSpacerLength { get; private set; }
        #endregion

        #region Misc Variables
        public string DriveNumber { get; set; }
        public DriveCard Drive { get; set; }
        public Operator Operator { get; set; }
        public DateTime Date { get; set; }
        #endregion

        #region Card Back Variables
        //These are set to nullable because they might or might not be set and they will never be used for calculation
        public float? Backlash { get; set; }
        public float? HorizontalSetting { get; set; }
        public float? IntermediateSetting { get; set; }
        public float? OutputSetting { get; set; }
        public string HelicalGearNumber { get; set; }
        public string HelicalPinionNumber { get; set; }
        #endregion

        static private float[,] DriveConstants = new float[5, 10] { {6.455f, 1.4567f, -.0001f, .0005f, 0, 0, 4.582f, 1.4567f, -.0004f, 0},
                                                                 {8.125f, 1.625f, 0, -.0001f, .0001f, 0, 5.25f, 1.8125f, 0, 0},
                                                                 {10, 2.125f, .0003f, -.0001f, 0, 0, 6, 1.8125f, 0, 0},
                                                                 {11.063f, 1.9375f, 0, 0, 0, 0, 7.4375f, 1.9375f, 0, 0},
                                                                 {11.813f, 1.9375f, 0, 0, 0, 0, 7.4375f, 1.9375f, 0, 0} };

        public SpacerCard()
        {
            int model;
            switch (Drive.Model)
            {
                case "F85":
                    model = 0;
                    break;

                case "F110":
                    model = 1;
                    break;

                case "F135":
                    model = 2;
                    break;

                case "F155":
                    model = 3;
                    break;

                case "F175":
                    model = 4;
                    break;

                default:
                    model = -1;
                    break;
            }

            HorizontalSpacerLength = float.Parse(GetHorizontalSpacerLength(model));
            VerticalSpacerLength = float.Parse(GetVerticalSpacerLength(model));
        }

        private string GetHorizontalSpacerLength(int model)
        {
            if (model != -1)
            {
                float horizontalSpacerLength = (1000 * (DriveConstants[model, 0] + (HorizontalGearCaseDeviation / 1000) - (HorizontalCarrierDeviation / 1000) - DriveConstants[model, 1] - (Bearing / 1000) - HMDGear - (DriveConstants[model, 4]) - (DriveConstants[0, 2]) + (DriveConstants[model, 3]))) / 1000;

                string horizontalSpacerLengthString = horizontalSpacerLength.ToString("0.000");

                return horizontalSpacerLengthString;
            }
            else
            {
                return "0.000";
            }
        }

        private string GetVerticalSpacerLength(int model)
        {
            if (model != -1)
            {
                float verticalSpacerLength = (1000 * ((DriveConstants[model, 6]) + (VerticalGearCaseDeviation / 1000) - (DriveConstants[model, 7]) - (VerticalCarrierDeviation / 1000) - (VMDGear + GearMount) + (DriveConstants[model, 8]))) / 1000;

                string verticalSpacerLengthString = verticalSpacerLength.ToString("0.000");

                return verticalSpacerLengthString;
            }
            else
            {
                return "0.000";
            }
        }
    }
}
