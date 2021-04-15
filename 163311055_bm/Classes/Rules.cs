using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _163311055_bm.Classes
{
    public class Rules
    {
        #region Properties

        #region Giriş Değerleri tanımlaması Enum değerleri tanımlanıyor.
        public EnumValues.Hassaslık Hassaslık { get; set; }
        public EnumValues.Miktar Miktar { get; set; }
        public EnumValues.Kirlilik Kirlilik { get; set; }
        #endregion
        #region Çıkış Değerleri tanımlaması Enum değerleri tanımlanıyor.
        public EnumValues.RotationalSpeed RotationalSpeed { get; set; }
        public EnumValues.Detergent Detergent { get; set; }
        public EnumValues.Time Time { get; set; }
        #endregion

        #region Hassaslık, Kirlilik, Miktar değerleri tutuluyor.
        public double value1 { get; set; }
        public double value2 { get; set; }
        public double value3 { get; set; }
        #endregion

        /// <summary>
        /// WashingMachineOperations nesne türetimi yapılmıştır.
        /// </summary>
        WashingMachineOperations operations = new WashingMachineOperations();

        #endregion

        #region Constructor

        /// <summary>
        /// The Rules Constructor in parameter
        /// </summary>
        /// <param name="Hassaslık"></param>
        /// <param name="Miktar"></param>
        /// <param name="Kirlilik"></param>
        public Rules(EnumValues.Hassaslık Hassaslık, EnumValues.Miktar Miktar, EnumValues.Kirlilik Kirlilik)
        {
            this.Hassaslık = Hassaslık;
            this.Miktar = Miktar;
            this.Kirlilik = Kirlilik;
            TotalRules();
        }

        /// <summary>
        /// The Rules Constructor in parameter
        /// </summary>
        /// <param name="Hassaslık"></param>
        /// <param name="Miktar"></param>
        /// <param name="Kirlilik"></param>
        public Rules(string Hassaslık, string Miktar, string Kirlilik)
        {
            EnumValues.Hassaslık hassaslık = 0;
            EnumValues.Miktar miktar = 0;
            EnumValues.Kirlilik kirlilik = 0;

            #region Gelen Değer Hasssaslık ise
            switch (Hassaslık)
            {
                case ConstantsValues.Saglam:
                    hassaslık = EnumValues.Hassaslık.sağlam;
                    break;
                case ConstantsValues.Orta:
                    hassaslık = EnumValues.Hassaslık.orta;
                    break;
                case ConstantsValues.Hassas:
                    hassaslık = EnumValues.Hassaslık.hassas;
                    break;
            }
            #endregion

            #region Gelen Değer Miktar ise
            switch (Miktar)
            {
                case ConstantsValues.Kucuk:
                    miktar = EnumValues.Miktar.kucuk;
                    break;
                case ConstantsValues.Orta:
                    miktar = EnumValues.Miktar.orta;
                    break;
                case ConstantsValues.Buyuk:
                    miktar = EnumValues.Miktar.buyuk;
                    break;
            }
            #endregion

            #region Gelen Değer Kirlilik ise
            switch (Kirlilik)
            {
                case ConstantsValues.Kucuk:
                    kirlilik = EnumValues.Kirlilik.kucuk;
                    break;
                case ConstantsValues.Orta:
                    kirlilik = EnumValues.Kirlilik.orta;
                    break;
                case ConstantsValues.Buyuk:
                    kirlilik = EnumValues.Kirlilik.buyuk;
                    break;
            }
            #endregion

            this.Hassaslık = hassaslık;
            this.Miktar = miktar;
            this.Kirlilik = kirlilik;
            TotalRules();
        }

        /// <summary>
        /// The Rules Constructor
        /// </summary>
        public Rules()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// X ekseninde minimum kesişimi getirir.
        /// </summary>
        public double GetMinIntersectionX
        {
            get { return GetIntersectionX.Where(a => a != -1).Min(); }
        }

        /// <summary>
        /// Kesişimer getiriliyor
        /// </summary>
        public double[] GetIntersectionX
        {
            get
            {
                List<double> list = new List<double>();
                list.Add(operations.IntersectionCalculated(value1, EnumValues.Intersection.HASSASLIK, (int)Hassaslık).Single());
                list.Add(operations.IntersectionCalculated(value1, EnumValues.Intersection.MIKTAR, (int)Miktar).Single());
                list.Add(operations.IntersectionCalculated(value1, EnumValues.Intersection.KIRLILIK, (int)Kirlilik).Single());
                return list.ToArray();
            }
        }

        /// <summary>
        /// Genişlikler getiriliyor
        /// </summary>
        /// <param name="centerOfGravity"></param>
        /// <returns></returns>
        public double BringWeight(EnumValues.CenterOfGravity centerOfGravity)
        {
            double rotationalWeight = 0, timeWeight = 0, detergentWeight = 0;
            #region Dönüş Hızı ise
            switch (RotationalSpeed)
            {
                case EnumValues.RotationalSpeed.Hassas:
                    rotationalWeight = -1.15; break;
                case EnumValues.RotationalSpeed.NormalHassas:
                    rotationalWeight = 2.75; break;
                case EnumValues.RotationalSpeed.Orta:
                    rotationalWeight = 5; break;
                case EnumValues.RotationalSpeed.NormalGuclu:
                    rotationalWeight = 7.25; break;
                case EnumValues.RotationalSpeed.Guclu:
                    rotationalWeight = 11.15; break;
            }
            #endregion

            #region Deterjan ise
            switch (Detergent)
            {
                case EnumValues.Detergent.CokAz:
                    detergentWeight = 10; break;
                case EnumValues.Detergent.Az:
                    detergentWeight = 85; break;
                case EnumValues.Detergent.Orta:
                    detergentWeight = 150; break;
                case EnumValues.Detergent.Fazla:
                    detergentWeight = 215; break;
                case EnumValues.Detergent.CokFazla:
                    detergentWeight = 290; break;
            }
            #endregion

            #region Süre ise
            switch (Time)
            {
                case EnumValues.Time.Kisa:
                    timeWeight = 23.79; break;
                case EnumValues.Time.NormalKisa:
                    timeWeight = 39.9; break;
                case EnumValues.Time.Orta:
                    timeWeight = 57.5; break;
                case EnumValues.Time.NormalUzun:
                    timeWeight = 75.1; break;
                case EnumValues.Time.Uzun:
                    timeWeight = 102.15; break;
            }
            #endregion

            #region Ağırlık Merkezinde gelen değerlerin sonucu döndürülüyor..
            switch (centerOfGravity)
            {
                case EnumValues.CenterOfGravity.DonusHizi: return rotationalWeight;
                case EnumValues.CenterOfGravity.Deterjan: return detergentWeight;
                case EnumValues.CenterOfGravity.Sure: return timeWeight;
            }
            #endregion

            return 0;
        }

        /// <summary>
        /// X koordinat değerleri atanıyor
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        public void XCoordinatValues(Double x1, Double x2, Double x3)
        {
            this.value1 = x1;
            this.value2 = x2;
            this.value3 = x3;
        }

        /// <summary>
        /// Text olarak string değerler döndürülüyor
        /// </summary>
        /// <param name="inputValues"></param>
        /// <returns></returns>
        public string ToString(EnumValues.InputValues inputValues)
        {
            switch (inputValues)
            {

                #region Enumdan gelen ifade Hassaslık ise
                case EnumValues.InputValues.Hassaslık:
                    switch (Hassaslık)
                    {
                        case EnumValues.Hassaslık.sağlam: return ConstantsValues.Saglam;
                        case EnumValues.Hassaslık.orta: return ConstantsValues.Orta;
                        case EnumValues.Hassaslık.hassas: return ConstantsValues.Hassas;
                    }
                    break;
                #endregion
                #region Enumdan gelen ifade Miktar ise
                case EnumValues.InputValues.Miktar:
                    switch (Miktar)
                    {
                        case EnumValues.Miktar.kucuk: return ConstantsValues.Kucuk;
                        case EnumValues.Miktar.orta: return ConstantsValues.Orta;
                        case EnumValues.Miktar.buyuk: return ConstantsValues.Buyuk;
                    }
                    break;
                #endregion
                #region Enumdan gelen ifade Kirlilik ise
                case EnumValues.InputValues.Kirlilik:
                    switch (Kirlilik)
                    {
                        case EnumValues.Kirlilik.kucuk: return ConstantsValues.Kucuk;
                        case EnumValues.Kirlilik.orta: return ConstantsValues.Orta;
                        case EnumValues.Kirlilik.buyuk: return ConstantsValues.Buyuk;
                    }
                    break;
                    #endregion
            }
            return base.ToString();
        }

        /// <summary>
        /// Toplam kurallar listelenmektedir.
        /// </summary>
        public void TotalRules()
        {
            if (Hassaslık == EnumValues.Hassaslık.hassas &&
               Miktar == EnumValues.Miktar.kucuk &&
               Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Hassas;
                Detergent = EnumValues.Detergent.CokAz;
                Time = EnumValues.Time.Kisa;
            }
            if (Hassaslık == EnumValues.Hassaslık.hassas &&
              Miktar == EnumValues.Miktar.kucuk &&
              Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalHassas;
                Detergent = EnumValues.Detergent.Az;
                Time = EnumValues.Time.Kisa;
            }
            if (Hassaslık == EnumValues.Hassaslık.hassas &&
              Miktar == EnumValues.Miktar.kucuk &&
              Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Orta;
                Detergent = EnumValues.Detergent.Orta;
                Time = EnumValues.Time.NormalKisa;
            }

            if (Hassaslık == EnumValues.Hassaslık.hassas &&
              Miktar == EnumValues.Miktar.orta &&
              Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Hassas;
                Detergent = EnumValues.Detergent.Orta;
                Time = EnumValues.Time.Kisa;
            }
            if (Hassaslık == EnumValues.Hassaslık.hassas &&
              Miktar == EnumValues.Miktar.orta &&
              Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalHassas;
                Detergent = EnumValues.Detergent.Orta;
                Time = EnumValues.Time.NormalKisa;
            }
            if (Hassaslık == EnumValues.Hassaslık.hassas &&
              Miktar == EnumValues.Miktar.orta &&
              Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Orta;
                Detergent = EnumValues.Detergent.Fazla;
                Time = EnumValues.Time.Orta;
            }

            if (Hassaslık == EnumValues.Hassaslık.hassas &&
              Miktar == EnumValues.Miktar.buyuk &&
              Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalHassas;
                Detergent = EnumValues.Detergent.Orta;
                Time = EnumValues.Time.NormalKisa;
            }
            if (Hassaslık == EnumValues.Hassaslık.hassas &&
             Miktar == EnumValues.Miktar.buyuk &&
             Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalHassas;
                Detergent = EnumValues.Detergent.Fazla;
                Time = EnumValues.Time.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.hassas &&
             Miktar == EnumValues.Miktar.buyuk &&
             Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Orta;
                Detergent = EnumValues.Detergent.Fazla;
                Time = EnumValues.Time.NormalUzun;
            }

            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.kucuk &&
                Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalHassas;
                Time = EnumValues.Time.NormalKisa;
                Detergent = EnumValues.Detergent.Az;
            }
            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.kucuk &&
                Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Orta;
                Time = EnumValues.Time.Kisa;
                Detergent = EnumValues.Detergent.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.kucuk &&
                Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalGuclu;
                Time = EnumValues.Time.Orta;
                Detergent = EnumValues.Detergent.Fazla;
            }

            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.orta &&
                Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalHassas;
                Time = EnumValues.Time.NormalKisa;
                Detergent = EnumValues.Detergent.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.orta &&
                Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Orta;
                Time = EnumValues.Time.Orta;
                Detergent = EnumValues.Detergent.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.orta &&
                Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Hassas;
                Time = EnumValues.Time.Uzun;
                Detergent = EnumValues.Detergent.Fazla;
            }

            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.buyuk &&
                Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Hassas;
                Time = EnumValues.Time.Orta;
                Detergent = EnumValues.Detergent.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.buyuk &&
                Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Hassas;
                Time = EnumValues.Time.NormalUzun;
                Detergent = EnumValues.Detergent.Fazla;
            }
            if (Hassaslık == EnumValues.Hassaslık.orta &&
                Miktar == EnumValues.Miktar.buyuk &&
                Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Hassas;
                Time = EnumValues.Time.Uzun;
                Detergent = EnumValues.Detergent.CokFazla;
            }

            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.kucuk &&
                Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Orta;
                Time = EnumValues.Time.Orta;
                Detergent = EnumValues.Detergent.Az;
            }
            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.kucuk &&
                Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalGuclu;
                Time = EnumValues.Time.Orta;
                Detergent = EnumValues.Detergent.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.kucuk &&
                Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Guclu;
                Time = EnumValues.Time.NormalUzun;
                Detergent = EnumValues.Detergent.Fazla;
            }

            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.orta &&
                Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Orta;
                Time = EnumValues.Time.Orta;
                Detergent = EnumValues.Detergent.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.orta &&
                Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalGuclu;
                Time = EnumValues.Time.NormalUzun;
                Detergent = EnumValues.Detergent.Orta;
            }
            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.orta &&
                Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Guclu;
                Time = EnumValues.Time.Orta;
                Detergent = EnumValues.Detergent.CokFazla;
            }

            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.buyuk &&
                Kirlilik == EnumValues.Kirlilik.kucuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalGuclu;
                Time = EnumValues.Time.NormalUzun;
                Detergent = EnumValues.Detergent.Fazla;
            }
            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.buyuk &&
                Kirlilik == EnumValues.Kirlilik.orta)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.NormalGuclu;
                Time = EnumValues.Time.Uzun;
                Detergent = EnumValues.Detergent.Fazla;
            }
            if (Hassaslık == EnumValues.Hassaslık.sağlam &&
                Miktar == EnumValues.Miktar.buyuk &&
                Kirlilik == EnumValues.Kirlilik.buyuk)
            {
                RotationalSpeed = EnumValues.RotationalSpeed.Guclu;
                Time = EnumValues.Time.Uzun;
                Detergent = EnumValues.Detergent.CokFazla;
            }
        }

        #endregion
    }
}
