 using System.Data;
 using app.data.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DatabaseConnection))]  
  public class DatabaseConnectionSpecs
  {
    public abstract class concern : Observes<IManageADatabase,
      DatabaseConnection>
    {
        
    }

    public class when_configuring_the_underlying_connection : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      Because b = () =>
        sut.configure_underlying_connection(x =>
        {
          x.ConnectionString = "blah";
        });


      It allows_configuration_through_a_config_delegate = () =>
        connection.ConnectionString.ShouldEqual("blah");

      static IDbConnection connection;
        
    }
   
    public class when_creating_a_command_to_run_a_query : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
        depends.on<IConfigureACommand>(x =>
        {
          x.CommandText = "blah";
        });

        command = fake.an<IDbCommand>();
        query = fake.an<IEncapsulateAQuery>();
        raw_query = fake.an<IRunRawQueries>();

        depends.on<ICreateRawQueriesFromCommands>(x =>
        {
          x.ShouldEqual(command);
          return raw_query;
        });

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      Because b = () =>
        result = sut.create_command_to_run(query);

      It runs_the_initial_command_configuration_against_the_command = () =>
        command.CommandText.ShouldEqual("blah");
        
      It tells_the_query_to_prepare_a_command = () =>
        query.received(x => x.prepare(command));

      It returns_a_new_raw_query = () =>
        result.ShouldEqual(raw_query);

      static IDbConnection connection;
      static IDbCommand command;
      static IEncapsulateAQuery query;
      static IRunRawQueries result;
      static IRunRawQueries raw_query;
    }
    public class when_open : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      Because b = () =>
        sut.open();


      It opens_its_underlying_connection = () =>
        connection.received(x => x.Open());

      static IDbConnection connection;
        
    }
  }
}
