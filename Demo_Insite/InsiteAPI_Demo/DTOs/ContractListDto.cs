using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsiteAPI_Deno.DTOs
{
   public class ContractListDto
    {

       
        public int CustomerKey { get; set; }

        public int ContractId { get; set; }

        public int? ContractGroupId { get; set; }

        public int UtilityId { get; set; }

        public string ContractGroupDescription { get; set; }

        public int? ContractGroupDepth { get; set; }

        public string ContractGroupRootDescription { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public DateTime TradingStartDate { get; set; }

        public DateTime TradingEndDate { get; set; }

        public string SupplierName { get; set; }

        public string UtilityName { get; set; }

        public string UtilityAlias { get; set; }

        public decimal? MarkTotalCost { get; set; }

        public decimal? MarkCostPerUnit { get; set; }

        public decimal? MarketTotalCost { get; set; }

        public decimal? MarketCostPerUnit { get; set; }

        public bool CustomerWebVisible { get; set; }

        public bool ContractWebVisible { get; set; }

        public bool ContractMarkToMarketChartWebVisible { get; set; }

        public bool IsArchivedCustomer { get; set; }

        public bool IsArchivedContract { get; set; }

        public long TotalVolume { get; set; }

        public long TradedVolume { get; set; }

        public decimal TradedCost { get; set; }

        public decimal ExposedCost { get; set; }

        public double PercentTraded { get; set; }

        public double PercentExposed { get; set; }

        public DateTime MinMarkToMarketDate { get; set; }

        public DateTime MaxMarkToMarketDate { get; set; }

    }
}
