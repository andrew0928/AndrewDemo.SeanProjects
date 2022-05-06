using System;
using System.Collections;
using System.Collections.Generic;

namespace AndrewDemo.SeanProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /*
    
    條件 1: 給定初始商品清單 (包含庫存)
    條件 2: 給定想要訂購的清單 (可能會超過庫存)

    結果: 完成訂購，訂單結果與剩餘庫存均正確

    壓測 1: 平行處理 ( concurrent transactions: 100 )
            在結果必須完全正確的前提下，盡可能地提高 TPS (transaction per seconds)
    壓測 2: 最佳化運算成本
    壓測 3: 最佳化交易體驗

    參考指標定義:
        指標: TTFT (time to first transction)
        指標: TTLT (time to last transation)
        指標: ALT (average lead time)
        指標: COST = QueryCount x 1 + Checkout x 10 ( 包含 fail )
            (鼓勵訂購前先確認庫存，避免不必要的訂購動作)



    */

    // 查詢商品
    public class ProductService
    {
        public ProductEntity Get(string sku)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetProducts(params string[] filter_tags)
        {
            throw new NotImplementedException();
        }
    }

    public class CheckoutService
    {
        public OrderEntity Checkout((string sku, int qty)[] lineitems, string email, string creditcard)
        {
            // 訂購成功就 return order
            // 訂購失敗就 throw exception
            // 必須正確處理庫存
            throw new NotImplementedException();
        }
    }

    public class ProductEntity
    {
        public string SKUID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string[] Tags { get; set; }
    }

    public class OrderEntity
    {
        public string OrderID { get; set; }

        public (string sku, int qty)[] LineItems { get; set; }

        public string BuyerEmail { get; set; }

        public DateTime CheckoutDate { get; set; }

        public OrderStateEnum State { get; set; }

    }

    public enum OrderStateEnum
    {
        CREATED,
        PURCHASED,
        SHIPPING,
        DELIVERED,
        COMPLETE
    }
}
