using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator
{
    public class SalesCounter
    {
        // 計算用リスト
        private List<Sale> _sales;

        //**************************************************************
        // コンストラクタ
        //**************************************************************
        public SalesCounter(List<Sale> sales)
        {
            _sales = sales;
        }

        //**************************************************************
        // 店舗別売上処理
        //**************************************************************
        public Dictionary<string, int> GetPerStoreSales()
        {
            // Dictionaryクラスのインスタンス生成
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach(Sale sale in _sales)
            {
                if(dict.ContainsKey(sale.ShopName))
                {
                    dict[sale.ShopName] += sale.Amount;
                }
                else
                {
                    dict[sale.ShopName] = sale.Amount;
                }
            }

            return dict;


        }
    }
}
