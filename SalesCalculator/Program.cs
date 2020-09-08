using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SalesCalculator
{
    class Program
    {
        // ************************************************************
        // main
        // ************************************************************
        static void Main(string[] args)
        {
            // SalesCounterインスタンス生成・ファイルから読み込み・リスト生成
            SalesCounter sales = new SalesCounter(ReadSales("sales.csv"));

            // 売り上げ金額取得
            Dictionary<string, int> amountPerStore = sales.GetPerStoreSales();

            // 画面出力
            foreach(KeyValuePair<string, int> obj in amountPerStore)
            {
                Console.WriteLine("{0}{1}", obj.Key, obj.Value);
            }
            Console.ReadKey();
        }

        // ************************************************************
        // 売り上げデータを読み込み、Saleオブジェクトのリストを返す
        // ************************************************************
        static List<Sale> ReadSales(string filePath)
        {
            // リスト生成
            List<Sale> sales = new List<Sale>();

            // ファイル全読み込み
            string[] lines = File.ReadAllLines(filePath);

            // 解析
            foreach(string line in lines)
            {
                // 項目に分ける
                string[] iteams = line.Split(',');

                // リスト生成・初期化
                Sale sale = new Sale {
                    ShopName        = iteams[0],
                    ProductCategory = iteams[1],
                    Amount          = int.Parse(iteams[2])
                };

                // リストに追加
                sales.Add(sale);
            }

            return sales;
        }
    }
}
