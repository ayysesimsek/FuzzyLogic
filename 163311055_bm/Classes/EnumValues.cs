using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _163311055_bm.Classes
{
    public static class EnumValues
    {
        /// <summary>
        /// Giriş Değerleri Enum Tanımlaması
        /// </summary>
        public enum InputValues
        {
            Hassaslık,
            Miktar,
            Kirlilik
        }
        /// <summary>
        /// Ağırlık Merkezi Enum Tanımlamaları
        /// </summary>
        public enum CenterOfGravity
        {
            DonusHizi,
            Deterjan,
            Sure
        }
        /// <summary>
        /// Hasssaslık Enum Tanımlamaları
        /// </summary>
        public enum Hassaslık
        {
            sağlam,
            orta,
            hassas
        }
        /// <summary>
        /// Miktar Enum Tanımlamaları
        /// </summary>
        public enum Miktar
        {
            kucuk,
            orta,
            buyuk
        }
        /// <summary>
        /// Kirlilik Enum Tanımlamları
        /// </summary>
        public enum Kirlilik
        {
            kucuk,
            orta,
            buyuk
        }
        /// <summary>
        /// Dönüş Hızı Enum Tanımlamaları
        /// </summary>
        public enum RotationalSpeed
        {
            Hassas,
            NormalHassas,
            Orta,
            NormalGuclu,
            Guclu
        }
        /// <summary>
        /// Deterjan Enum Tanımlamları
        /// </summary>
        public enum Detergent
        {
            CokAz,
            Az,
            Orta,
            Fazla,
            CokFazla
        }
        /// <summary>
        /// Süre Enum Tanımlamaları
        /// </summary>
        public enum Time
        {
            Kisa,
            NormalKisa,
            Orta,
            NormalUzun,
            Uzun
        }
        /// <summary>
        /// Kesişim Ennum Tanımlamaları
        /// </summary>
        public enum Intersection
        {
            HASSASLIK,
            MIKTAR,
            KIRLILIK
        }

    }
}
