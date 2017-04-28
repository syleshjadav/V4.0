using MyShopWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShopWeb.Models
{
    public class StickerModel
    {
        public int StickerTypeId { get; set; }
        public string StickerTypeCD { get; set; }
        public string StickerTypeDesc { get; set; }

        public byte? OrderQty { get; set; }

        public decimal? Cost { get; set; }
    }

    public class SafetyStickers
    {
        public StickerModel AI { get; set; }
        public StickerModel AO { get; set; }
        public StickerModel SI { get; set; }
    }

    public class EmissionStickers
    {
        public StickerModel IM { get; set; }
    }

    public class SpecialInsertsStickers
    {
        public StickerModel ExcemptInserts { get; set; }
        public StickerModel WaiverInserts { get; set; }
        public StickerModel DOTInserts { get; set; }
    }

    public class StickerMaster
    {
        public SafetyStickers MySafetyStickers { get; set; }
        public EmissionStickers MyEmissionStickerss { get; set; }
        public SpecialInsertsStickers MySpecialInsertsStickers { get; set; }
        public List<uspSelDealerStickerTypeResult> DealerStickerTypes { get; set; }

    }
}