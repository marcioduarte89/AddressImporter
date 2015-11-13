namespace AddressImporter.Common.Helpers
{
    public class Math
    {
        /// <summary>
        /// Calculates the Distance Between Two Coordinates
        /// </summary>
        /// <param name="eastingA1"></param>
        /// <param name="eastingA2"></param>
        /// <param name="northingB1"></param>
        /// <param name="northingB2"></param>
        /// <returns></returns>
        public static double CalculatePythagoreanTheorem(double eastingA1, double eastingA2, double northingB1, double northingB2)
        {
            return System.Math.Round((System.Math.Sqrt(System.Math.Pow(eastingA1 - eastingA2, 2) + System.Math.Pow(northingB1 - northingB2, 2)) / 1000),2);
        }
    }
}
