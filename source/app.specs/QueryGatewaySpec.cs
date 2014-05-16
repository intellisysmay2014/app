using System.Collections.Generic;
using System.Linq;
using app.data.core;
using app.web.application.store_browsing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(QueryGateway))]
  public class QueryGatewaySpec
  {
    public abstract class concern : Observes<IQueryForData, QueryGateway>
    {
    }

    public class when_querying_for_data : concern
    {
      Establish c = () =>
      {
        connection_factory = depends.on<ICreateConnections>();

        query = fake.an<IEncapsulateAQuery>();
        connection = fake.an<IManageADatabase>();
        command = fake.an<IRunRawQueries>();
        one_item = new SomeDataObject();
        list_of_items = new List<SomeDataObject> {one_item};

        connection_factory.setup(x => x.create()).Return(connection);
        connection.setup(x => x.create_command_to_run(query)).Return(command);
        command.setup(x => x.execute_for<SomeDataObject>()).Return(list_of_items);
      };

      Because b = () =>
        results = sut.query_using<SomeDataObject>(query);

      It uses_the_connection_to_create_a_command_to_run_the_query = () =>
        connection.received(x => x.create_command_to_run(query));

      It opens_the_connection = () =>
        connection.received(x => x.open());

      It disposes_its_connection = () =>
        connection.received(x => x.Dispose());

      It disposes_the_command = () =>
        command.received(x => x.Dispose());

      It returns_the_mapped_data = () =>
      {
        var result = results.First();
      };

      static ICreateConnections connection_factory;
      static IEncapsulateAQuery query;
      static IManageADatabase connection;
      static IRunRawQueries command;
      static IEnumerable<SomeDataObject> results;
      static SomeDataObject one_item;
      static IEnumerable<SomeDataObject> list_of_items;
    }

    public class SomeDataObject
    {
    }
  }
}