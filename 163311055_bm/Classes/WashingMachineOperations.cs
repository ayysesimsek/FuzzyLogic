using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _163311055_bm.Classes
{
    public class WashingMachineOperations
    {
        #region Properties

        /// <summary>
        /// The sensitiv list
        /// </summary>
        private List<String> sensitivityList = new List<string>();
        /// <summary>
        /// The quantity list
        /// </summary>
        private List<String> quantityList = new List<string>();
        /// <summary>
        /// The dirty list
        /// </summary>
        private List<String> dirtyList = new List<string>();

        #endregion

        #region Methods

        /// <summary>
        /// Kesişimlerin tutulduğu liste tanımlanıyor
        /// </summary>
        public List<List<String>> IntersectionList
        {
            get
            {
                List<List<String>> list = new List<List<string>>();
                list.Add(sensitivityList);
                list.Add(quantityList);
                list.Add(dirtyList);
                return list;
            }
        }

        /// <summary>
        /// Hesaplama
        /// </summary>
        /// <param name="outputCenter"></param>
        /// <param name="row"></param>
        /// <param name="centerId"></param>
        /// <returns>List<PointF></returns>
        public List<PointF> Calculated(EnumValues.CenterOfGravity outputCenter, double row, int centerId)
        {
            return OutputAreaRotationalDetergentTime(row, centerId, outputCenter);
        }

        /// <summary>
        /// Çıkış alanı Dönme Hızı - Deterjan - Süre 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="centerId"></param>
        /// <param name="centerOfGravity"></param>
        /// <returns>List<PointF></returns>
        private List<PointF> OutputAreaRotationalDetergentTime(double row, int centerId, EnumValues.CenterOfGravity centerOfGravity)
        {
            List<PointF> points = new List<PointF>();
            switch (centerOfGravity)
            {
                case EnumValues.CenterOfGravity.DonusHizi:
                    points = DeterminingPoints(centerId, row, EnumValues.CenterOfGravity.DonusHizi);
                    break;
                case EnumValues.CenterOfGravity.Deterjan:
                    points = DeterminingPoints(centerId, row, EnumValues.CenterOfGravity.Deterjan);
                    break;
                case EnumValues.CenterOfGravity.Sure:
                    points = DeterminingPoints(centerId, row, EnumValues.CenterOfGravity.Sure);
                    break;
            }
            return points;
        }

        /// <summary>
        /// Çıkış değerlerinin hesaplaması yapılıyor. -Verilen PDF dokümanındaki değerler göre
        /// </summary>
        /// <param name="centerId"></param>
        /// <param name="row"></param>
        /// <param name="centerOfGravity"></param>
        /// <returns></returns>
        private List<PointF> DeterminingPoints(int centerId, double row, EnumValues.CenterOfGravity centerOfGravity)
        {
            List<PointF> points = new List<PointF>();
            double result;
            #region Ağırlık merkezi değeri = Dönüş hızı ise
            if (centerOfGravity == EnumValues.CenterOfGravity.DonusHizi)
            {
                #region Gelen ağırlık merkezi değeri = 0 ise
                if (centerId == 0)
                {
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction1[0], 0));
                    result = ConstantsValues.rotateMemberShipFunction1[0] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction1[0] - ConstantsValues.rotateMemberShipFunction1[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.rotateMemberShipFunction1[3] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction1[2] - ConstantsValues.rotateMemberShipFunction1[3])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction1[3], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 1 ise
                if (centerId == 1)
                {
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction2[0], 0));
                    result = ConstantsValues.rotateMemberShipFunction2[0] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction2[0] - ConstantsValues.rotateMemberShipFunction2[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.rotateMemberShipFunction1[2] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction2[1] - ConstantsValues.rotateMemberShipFunction2[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction2[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 2 ise
                if (centerId == 2)
                {
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction3[0], 0));
                    result = ConstantsValues.rotateMemberShipFunction3[0] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction3[0] - ConstantsValues.rotateMemberShipFunction3[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.rotateMemberShipFunction3[2] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction3[1] - ConstantsValues.rotateMemberShipFunction3[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction3[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 3 ise
                if (centerId == 3)
                {
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction4[0], 0));
                    result = ConstantsValues.rotateMemberShipFunction4[0] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction4[0] - ConstantsValues.rotateMemberShipFunction4[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.rotateMemberShipFunction4[2] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction4[1] - ConstantsValues.rotateMemberShipFunction4[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction4[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 4 ise
                if (centerId == 4)
                {
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction5[0], 0));
                    result = ConstantsValues.rotateMemberShipFunction5[0] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction5[0] - ConstantsValues.rotateMemberShipFunction5[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.rotateMemberShipFunction5[3] + (row * (Math.Abs(ConstantsValues.rotateMemberShipFunction5[2] - ConstantsValues.rotateMemberShipFunction5[3])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.rotateMemberShipFunction5[3], 0));
                }
                #endregion
            }
            #endregion
            #region Ağırlık merkezi değeri = Deterjan ise
            else if (centerOfGravity == EnumValues.CenterOfGravity.Deterjan)
            {
                #region Gelen ağırlık merkezi değeri = 0 ise
                if (centerId == 0)
                {
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction1[0], 0));
                    result = ConstantsValues.detergentMemberShipFunction1[0] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction1[0] - ConstantsValues.detergentMemberShipFunction1[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.detergentMemberShipFunction1[3] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction1[2] - ConstantsValues.detergentMemberShipFunction1[3])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction1[3], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 1 ise
                if (centerId == 1)
                {
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction2[0], 0));
                    result = ConstantsValues.detergentMemberShipFunction2[0] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction2[0] - ConstantsValues.detergentMemberShipFunction2[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.detergentMemberShipFunction2[2] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction2[1] - ConstantsValues.detergentMemberShipFunction2[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction2[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 2 ise
                if (centerId == 2)
                {
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction3[0], 0));
                    result = ConstantsValues.detergentMemberShipFunction3[0] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction3[0] - ConstantsValues.detergentMemberShipFunction3[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.detergentMemberShipFunction3[2] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction3[1] - ConstantsValues.detergentMemberShipFunction3[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction3[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 3 ise
                if (centerId == 3)
                {
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction4[0], 0));
                    result = ConstantsValues.detergentMemberShipFunction4[0] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction4[0] - ConstantsValues.detergentMemberShipFunction4[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.detergentMemberShipFunction4[2] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction4[1] - ConstantsValues.detergentMemberShipFunction4[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction4[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 4 ise
                if (centerId == 4)
                {
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction5[0], 0));
                    result = ConstantsValues.detergentMemberShipFunction5[0] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction5[0] - ConstantsValues.detergentMemberShipFunction5[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.detergentMemberShipFunction5[3] + (row * (Math.Abs(ConstantsValues.detergentMemberShipFunction5[2] - ConstantsValues.detergentMemberShipFunction5[3])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.detergentMemberShipFunction5[3], 0));
                }
                #endregion
            }
            #endregion
            #region Ağırlık merkezi değeri = Süre ise
            else
            {
                #region Gelen ağırlık merkezi değeri = 0 ise
                if (centerId == 0)
                {
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction1[0], 0));
                    result = ConstantsValues.timeMemberShipFunction1[0] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction1[0] - ConstantsValues.timeMemberShipFunction1[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.timeMemberShipFunction1[3] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction1[2] - ConstantsValues.timeMemberShipFunction1[3])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction1[3], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 1 ise
                if (centerId == 1)
                {
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction2[0], 0));
                    result = ConstantsValues.timeMemberShipFunction2[0] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction2[0] - ConstantsValues.timeMemberShipFunction2[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.timeMemberShipFunction2[2] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction2[1] - ConstantsValues.timeMemberShipFunction2[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction2[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 2 ise
                if (centerId == 2)
                {
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction3[0], 0));
                    result = ConstantsValues.timeMemberShipFunction3[0] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction3[0] - ConstantsValues.timeMemberShipFunction3[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.timeMemberShipFunction3[2] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction3[1] - ConstantsValues.timeMemberShipFunction3[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction3[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 3 ise
                if (centerId == 3)
                {
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction4[0], 0));
                    result = ConstantsValues.timeMemberShipFunction4[0] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction4[0] - ConstantsValues.timeMemberShipFunction4[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.timeMemberShipFunction4[2] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction4[1] - ConstantsValues.timeMemberShipFunction4[2])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction4[2], 0));
                }
                #endregion
                #region Gelen ağırlık merkezi değeri = 4 ise
                if (centerId == 4)
                {
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction5[0], 0));
                    result = ConstantsValues.timeMemberShipFunction5[0] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction5[0] - ConstantsValues.timeMemberShipFunction5[1])));
                    points.Add(new PointF((float)result, (float)row));
                    result = ConstantsValues.timeMemberShipFunction5[3] + (row * (Math.Abs(ConstantsValues.timeMemberShipFunction5[2] - ConstantsValues.timeMemberShipFunction5[3])));
                    points.Add(new PointF((float)result, (float)result));
                    points.Add(new PointF((float)ConstantsValues.timeMemberShipFunction5[3], 0));
                }
                #endregion
            }
            #endregion

            return points;
        }

        /// <summary>
        /// Kesisişim Hesaplaması
        /// </summary>
        /// <param name="rangeValue"></param>
        /// <param name="intersection"></param>
        /// <param name="figureIndex"></param>
        /// <returns></returns>
        public List<double> IntersectionCalculated(double rangeValue, EnumValues.Intersection intersection, int figureIndex = -1)
        {
            switch (intersection)
            {
                case EnumValues.Intersection.HASSASLIK:
                    return SensitiveAndQuantityIntersection(rangeValue, intersection, figureIndex);
                case EnumValues.Intersection.MIKTAR:
                    return SensitiveAndQuantityIntersection(rangeValue, intersection, figureIndex);
                case EnumValues.Intersection.KIRLILIK:
                    return DirtyIntersection(rangeValue, figureIndex);
            }
            return null;
        }

        /// <summary>
        /// Hassaslık - Miktar Kesişimi
        /// </summary>
        /// <param name="inputRange"></param>
        /// <param name="intersection"></param>
        /// <param name="figureIndex"></param>
        /// <returns></returns>
        public List<double> SensitiveAndQuantityIntersection(double inputRange, EnumValues.Intersection intersection, int figureIndex)
        {
            // [-4, -1.5, 2, 4] - [3, 5, 7] - [5.5, 8, 12.5, 14]
            var tempList = new List<string>();
            List<double> intersections = new List<double>();
            double range1, range2, range3;
            range1 = -1; range2 = -1; range3 = -1;

            #region x>=0 && x<=2 || x>=2 && x<=4
            if (inputRange >= 0 &&
                inputRange <= 2)
                range1 = 1;
            else if (inputRange >= 2 &&
                     inputRange <= 4)
                range1 = 1 - (inputRange - 2) * (1 / Math.Abs((2.0) - (4.0)));
            #endregion

            #region x>=3 && x<=5 || x>=5 && x<=7
            if (inputRange >= 3 &&
                inputRange <= 5)
                range2 = (inputRange - 3) * (1 / Math.Abs((3.0) - (5.0)));
            else if (inputRange >= 5 &&
                     inputRange <= 7)
                range2 = 1 - (inputRange - 5) * (1 / Math.Abs((5.0) - (7.0)));
            #endregion

            #region x>=5.5 && x<=8 || x>=8 && x<=12.5 || x>=12.5 && x<=14
            if (inputRange >= 5.5 &&
               inputRange <= 8)
                range3 = (inputRange - 5.5) * (1 / Math.Abs((5.5) - (8)));
            else if (inputRange >= 8 &&
                     inputRange <= 12.5)
                range3 = 1;
            else if (inputRange >= 12.5 && inputRange <= 14)
                range3 = 1 - ((inputRange - 12.5) * (1 / Math.Abs((12.5) - (14.0))));
            #endregion

            #region Aralık değeri 1 koşulu
            if (range1 > -1)
            {
                tempList.Add(intersection == EnumValues.Intersection.HASSASLIK ? ConstantsValues.Saglam : ConstantsValues.Kucuk);
                if (figureIndex == -1 || figureIndex == 0)
                    intersections.Add(range1);
            }
            #endregion
            #region Aralık değeri 2 koşulu
            if (range2 > -1)
            {
                tempList.Add(ConstantsValues.Orta);
                if (figureIndex == -1 || figureIndex == 1)
                    intersections.Add(range2);
            }
            #endregion
            #region Aralık değeri 3 koşulu
            if (range3 > -1)
            {
                tempList.Add(intersection == EnumValues.Intersection.HASSASLIK ? ConstantsValues.Hassas : ConstantsValues.Buyuk);
                if (figureIndex == -1 || figureIndex == 2)
                    intersections.Add(range3);
            }
            #endregion

            if (intersection == EnumValues.Intersection.HASSASLIK)
                sensitivityList = tempList;
            else
                quantityList = tempList;

            if (intersections.Count == 0) intersections.Add(-1);
            return intersections;

        }

        /// <summary>
        /// Kirlilik Kesişimi
        /// </summary>
        /// <param name="inputRange"></param>
        /// <param name="figureIndex"></param>
        /// <returns></returns>
        public List<double> DirtyIntersection(double inputRange, int figureIndex)
        {
            // [-4.5, -2.5, 2, 4.5] - [3, 5, 7] - [5.5, 8, 12.5, 15]
            dirtyList = new List<string>();
            List<double> intersections = new List<double>();
            double range1, range2, range3;
            range1 = -1; range2 = -1; range3 = -1;

            #region x>=0 && x<=2 || x>=2 && x<=4.5
            if (inputRange >= 0 &&
               inputRange <= 2)
                range1 = 1;
            else if (inputRange >= 2 &&
                     inputRange <= 4.5)
                range1 = 1 - (inputRange - 2) * (1 / Math.Abs((2.0) - (4.5)));
            #endregion

            #region x>=3 && x<=5 || x>=5 && x<=7
            if (inputRange >= 3 &&
               inputRange <= 5)
                range2 = (inputRange - 3) * (1 / Math.Abs((3.0) - (5.0)));
            else if (inputRange >= 5 &&
                     inputRange <= 7)
                range2 = 1 - (inputRange - 5) * (1 / Math.Abs((5.0) - (7.0)));
            #endregion

            #region x>=5.5 && x<=8 || x>=8 && x<=12.5 || x>=12.5 && x<=15
            if (inputRange >= 5.5 &&
                inputRange <= 8)
                range3 = (inputRange - 5.5) * (1 / Math.Abs((5.5) - (8)));
            else if (inputRange >= 8 &&
                     inputRange <= 12.5)
                range3 = 1;
            else if (inputRange >= 12.5 &&
                     inputRange <= 15)
                range3 = 1 - ((inputRange - 12.5) * (1 / Math.Abs((12.5) - (15.0))));
            #endregion

            #region Aralık değeri 1 koşulu
            if (range1 > -1)
            {
                dirtyList.Add(ConstantsValues.Kucuk);
                if (figureIndex == -1 || figureIndex == 0)
                    intersections.Add(range1);
            }
            #endregion
            #region Aralık değeri 2 koşulu
            if (range2 > -1)
            {
                dirtyList.Add(ConstantsValues.Orta);
                if (figureIndex == -1 || figureIndex == 1)
                    intersections.Add(range2);
            }
            #endregion
            #region Aralık değeri 3 koşulu
            if (range3 > -1)
            {
                dirtyList.Add(ConstantsValues.Buyuk);
                if (figureIndex == -1 || figureIndex == 2)
                    intersections.Add(range3);
            }
            #endregion

            if (intersections.Count == 0) intersections.Add(-1);
            return intersections;
        }

        #endregion
    }
}
