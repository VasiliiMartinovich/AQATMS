namespace Calculator.Hooks;

public abstract class BaseTest 
 {
     protected Core.Calculator Calculator { get; private set; }
     
     public BaseTest()
     {
         Calculator = new Core.Calculator();
     }

     [OneTimeSetUp]
     public void OneTimeSetup()
     {
         Console.WriteLine("Executed once before this suit");
     }

     [SetUp]
     public void BeforeEachTest()
     {
         Console.WriteLine("SETUP: executed before each test");
     }

     [TearDown]
     public void AfterEachTest()
     {
         Console.WriteLine("TEARDOWN: executed after each test");
     }

     [OneTimeTearDown]
     public void OneTimeTearDown()
     {
         Console.WriteLine("Executed after this suit");
     }
 }