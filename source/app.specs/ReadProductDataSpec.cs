 using System.Collections.Generic;
 using System.Data;
 using app.web.application.store_browsing;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ReadProductData))]  
    public class ReadProductDataSpec
    {
        public abstract class concern : Observes<IQueryForData, ReadProductData>
        {
        
        }


        public class when_reading_product_data_from_data_source : concern
        {
            private Establish e = () =>
            {
                connection = depends.on<IDbConnection>();
                
                test_result = new List<ProductLineItem>
                {
                    new ProductLineItem
                    {
                        name = "product"
                    }
                };
            };

            private Because b = () => 
                result = sut.find_all_data_where<ProductLineItem>(x => x.name=="product");
        

            private It should_fetch_all_the_product_related_data_where_name_its_product = () =>
            {
                result.ShouldBeTheSameAs(test_result);
            };

            private static ReadProductData data_reader;
            private static IEnumerable<ProductLineItem> result;
            private static IDbConnection connection;
            private static IEnumerable<ProductLineItem> test_result;
        }
    }
}
