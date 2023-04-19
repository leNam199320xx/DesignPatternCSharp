using static DesignPattern.Pattern.Structural.AdapterDesignPattern;
using static DesignPattern.Pattern.Creational.BuilderDesignPattern;
using static DesignPattern.Pattern.Creational.FactoryDesignPattern;
using static DesignPattern.Pattern.Creational.SingletonDesignPattern;
using static DesignPattern.Pattern.Structural.FacedeDesignPattern;
using static DesignPattern.Pattern.Structural.DecoratorDesignPattern;
using DesignPattern.Pattern.Creational;
using static DesignPattern.Pattern.Structural.BridgeDesignPattern;
using static DesignPattern.Pattern.Structural.CompositeDesignPattern;
using static DesignPattern.Pattern.Structural.ProxyDesignPattern;
using DesignPattern.Pattern.Behavioral;
using static DesignPattern.Pattern.Behavioral.ObserverDesignPattern;
using static DesignPattern.Pattern.Behavioral.CommandDesignPattern;
using static DesignPattern.Pattern.Behavioral.VisitorDesignPattern;
using static DesignPattern.Pattern.Behavioral.StrategyDesignPattern;
using static DesignPattern.Pattern.Behavioral.InterpreterDesignPattern;
using static DesignPattern.Pattern.Behavioral.MementoDesignPattern;
using static DesignPattern.Pattern.Structural.FlyweightDesignPattern;

class Program
{
    static void Main(string[] args)
    {
        #region factory
        Console.WriteLine("===START FACTORY DESIGN PATTERN===");
        ICreditCard cardDetails = FactoryDesignPattern.GetCreditCard("Platinum");
        ICreditCard cardMoneyBackDetails = FactoryDesignPattern.GetCreditCard("MoneyBack");

        if (cardDetails != null)
        {
            Console.WriteLine("CardType : " + cardDetails.GetCardType());
            Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
            Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());


            Console.WriteLine("money back CardType : " + cardMoneyBackDetails.GetCardType());
            Console.WriteLine("money back CreditLimit : " + cardMoneyBackDetails.GetCreditLimit());
            Console.WriteLine("money back AnnualCharge :" + cardMoneyBackDetails.GetAnnualCharge());
        }
        else
        {
            Console.Write("Invalid Card Type");
        }

        Console.WriteLine("===FINISH FACTORY DESIGN PATTERN===");

        #endregion

        #region builder
        Console.WriteLine("===START BUILDER DESIGN PATTERN===");
        Report report;
        ReportDirector reportDirector = new ReportDirector();

        PDFReport pdfReport = new PDFReport();
        report = reportDirector.MakeReport(pdfReport);
        report.DisplayReport();

        ExcelReport excelReport = new ExcelReport();
        report = reportDirector.MakeReport(excelReport);
        report.DisplayReport();

        Console.WriteLine("===FINISH BUILDER DESIGN PATTERN===");
        #endregion

        #region prototype
        Console.WriteLine("===START PROTOTYPE DESIGN PATTERN===");

        //Nếu chúng ta sử dụng Prototype Design Pattern thì khi thay đổi emp2, emp1 vẫn giữ nguyên giá trị ban đầu.
        DesignPattern.Pattern.Creational.PrototypeDesignPattern.Employee emp1 = new DesignPattern.Pattern.Creational.PrototypeDesignPattern.Employee();
        emp1.Name = "Anurag";
        emp1.Department = "IT";

        DesignPattern.Pattern.Creational.PrototypeDesignPattern.Employee emp2 = emp1.GetClone();
        emp2.Name = "Pranaya";

        Console.WriteLine("Emplpyee 1: ");
        Console.WriteLine("Name: " + emp1.Name + ", Department: " + emp1.Department);
        Console.WriteLine("Emplpyee 2: ");
        Console.WriteLine("Name: " + emp2.Name + ", Department: " + emp2.Department);

        Console.WriteLine("===FINISH PROTOTYPE DESIGN PATTERN===");

        #endregion

        #region singleton

        Console.WriteLine("===START SINGLETON DESIGN PATTERN===");
        Singleton fromTeachaer = Singleton.GetInstance;
        fromTeachaer.PrintDetails("From Teacher");
        Singleton fromStudent = Singleton.GetInstance;
        fromStudent.PrintDetails("From Student");
        Console.WriteLine("===FINISH SINGLETON DESIGN PATTERN===");
        #endregion

        #region adapter
        Console.WriteLine("===START ADAPTER DESIGN PATTERN===");

        string[,] employeesArray = new string[5, 4]
           {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
           };

        ITarget target = new EmployeeAdapter();
        Console.WriteLine("He thong nhan su chuyen chuoi employee sang adapter\n");
        target.ProcessCompanySalary(employeesArray);


        Console.WriteLine("===FINISH ADAPTER DESIGN PATTERN===");
        #endregion

        #region facade
        Console.WriteLine("===START FACADE DESIGN PATTERN===");

        Order order = new Order();
        order.PlaceOrder();
        Console.WriteLine("===FINISH FACADE DESIGN PATTERN===");
        #endregion

        #region decorator
        Console.WriteLine("===START DECORATOR DESIGN PATTERN===");
        ICar bmwCar1 = new BMWCar();
        bmwCar1.ManufactureCar();
        Console.WriteLine(bmwCar1 + "\n");
        DieselCarDecorator carWithDieselEngine = new DieselCarDecorator(bmwCar1);
        carWithDieselEngine.ManufactureCar();
        Console.WriteLine();
        ICar bmwCar2 = new BMWCar();
        PetrolCarDecorator carWithPetrolEngine = new PetrolCarDecorator(bmwCar2);
        carWithPetrolEngine.ManufactureCar();
        Console.WriteLine("===FINISH DECORATOR DESIGN PATTERN===");
        #endregion

        #region bridge
        Console.WriteLine("===START BRIDGE DESIGN PATTERN===");
        Client client = new Client();

        Abstraction abstraction;
        // Client phải có thể hoạt động với bất kỳ tổ hợp hiện thực - trừu tượng
        // nào được định cấu hình trước.
        abstraction = new Abstraction(new ImplementationA());
        client.ClientCode(abstraction);

        Console.WriteLine();

        abstraction = new RefinedAbstraction(new ImplementationB());
        client.ClientCode(abstraction);
        Console.WriteLine("===FINISH BRIDGE DESIGN PATTERN===");
        #endregion

        #region composite
        Console.WriteLine("===START COMPOSITE DESIGN PATTERN===");
        IComponent hardDisk = new Leaf("Hard Disk", 2000);
        IComponent ram = new Leaf("RAM", 3000);
        IComponent cpu = new Leaf("CPU", 2000);
        IComponent mouse = new Leaf("Mouse", 2000);
        IComponent keyboard = new Leaf("Keyboard", 2000);
        //tạo đối tượng composite
        Composite motherBoard = new Composite("Peripherals");
        Composite cabinet = new Composite("Cabinet");
        Composite peripherals = new Composite("Peripherals");
        Composite computer = new Composite("Computer");
        //tạo cấu trúc cây
        motherBoard.AddComponent(cpu);
        motherBoard.AddComponent(ram);

        cabinet.AddComponent(motherBoard);
        cabinet.AddComponent(hardDisk);

        peripherals.AddComponent(mouse);
        peripherals.AddComponent(keyboard);

        computer.AddComponent(cabinet);
        computer.AddComponent(peripherals);

        computer.DisplayPrice();
        Console.WriteLine();

        keyboard.DisplayPrice();
        Console.WriteLine();

        cabinet.DisplayPrice();
        Console.WriteLine("===FINISH COMPOSITE DESIGN PATTERN===");
        #endregion

        #region proxy
        Console.WriteLine("===START PROXY DESIGN PATTERN===");
        Console.WriteLine("Client passing employee with Role Developer to folderproxy");
        DesignPattern.Pattern.Structural.ProxyDesignPattern.Employee emp11 = new DesignPattern.Pattern.Structural.ProxyDesignPattern.Employee("Anurag", "Anurag123", "Developer");
        SharedFolderProxy folderProxy1 = new SharedFolderProxy(emp11);
        folderProxy1.PerformRWOperations();
        Console.WriteLine();
        Console.WriteLine("Client passing employee with Role Manager to folderproxy");
        DesignPattern.Pattern.Structural.ProxyDesignPattern.Employee emp22 = new DesignPattern.Pattern.Structural.ProxyDesignPattern.Employee("Pranaya", "Pranaya123", "Manager");
        SharedFolderProxy folderProxy2 = new SharedFolderProxy(emp22);
        folderProxy2.PerformRWOperations();
        Console.WriteLine("===FINISH PROXY DESIGN PATTERN===");
        #endregion

        #region iterator
        IteratorDesignPattern.ConcreteCollection collection = new IteratorDesignPattern.ConcreteCollection();
        collection.AddEmployee(new IteratorDesignPattern.Elempoyee("Anurag", 100));
        collection.AddEmployee(new IteratorDesignPattern.Elempoyee("Pranaya", 101));
        collection.AddEmployee(new IteratorDesignPattern.Elempoyee("Santosh", 102));
        collection.AddEmployee(new IteratorDesignPattern.Elempoyee("Priyanka", 103));
        collection.AddEmployee(new IteratorDesignPattern.Elempoyee("Abinash", 104));
        collection.AddEmployee(new IteratorDesignPattern.Elempoyee("Preety", 105));
        // Create iterator
        IteratorDesignPattern.Iterator iterator = collection.CreateIterator();
        //looping iterator      
        Console.WriteLine("Iterating over collection:");

        for (var emp = iterator.First(); !iterator.IsCompleted; emp = iterator.Next())
        {
            Console.WriteLine($"ID : {emp.ID} & Name : {emp.Name}");
        }
        #endregion

        #region observer
        //Create a Product with Out Of Stock Status
        Subject RedMI = new Subject("Red MI Mobile", 10000, "Out Of Stock");
        //User Anurag will be created and user1 object will be registered to the subject
        Observer user1 = new Observer("Anurag", RedMI);
        //User Pranaya will be created and user1 object will be registered to the subject
        Observer user2 = new Observer("Pranaya", RedMI);
        //User Priyanka will be created and user3 object will be registered to the subject
        Observer user3 = new Observer("Priyanka", RedMI);

        Console.WriteLine("Red MI Mobile current state : " + RedMI.getAvailability());
        // Now product is available
        RedMI.setAvailability("Available");
        #endregion

        #region command
        Document document = new Document();
        ICommand openCommand = new OpenCommand(document);
        ICommand saveCommand = new SaveCommand(document);
        ICommand closeCommand = new CloseCommand(document);
        MenuOptions menu = new MenuOptions(openCommand, saveCommand, closeCommand);
        menu.clickOpen();
        menu.clickSave();
        menu.clickClose();
        #endregion

        #region visitor
        School school = new School();
        var visitor1 = new Doctor("James");
        school.PerformOperation(visitor1);
        Console.WriteLine();
        var visitor2 = new Salesman("John");
        school.PerformOperation(visitor2);

        #endregion

        #region strategy
        CompressionContext ctx = new CompressionContext(new ZipCompression());
        ctx.CreateArchive("Freetuts");
        ctx.SetStrategy(new RarCompression());
        ctx.CreateArchive("Freetuts");
        #endregion

        #region interpreter
        List<AbstractExpression> objExpressions = new List<AbstractExpression>();
        Context context = new Context(DateTime.Now);
        Console.WriteLine("Please select the Expression  : MM DD YYYY or YYYY MM DD or DD MM YYYY ");
        context.expression = "MM DD YYYY";
        string[] strArray = context.expression.Split(' ');
        foreach (var item in strArray)
        {
            if (item == "DD")
            {
                objExpressions.Add(new DayExpression());
            }
            else if (item == "MM")
            {
                objExpressions.Add(new MonthExpression());
            }
            else if (item == "YYYY")
            {
                objExpressions.Add(new YearExpression());
            }
        }
        objExpressions.Add(new SeparatorExpression());
        foreach (var obj in objExpressions)
        {
            obj.Evaluate(context);
        }
        Console.WriteLine(context.expression);
        #endregion

        #region memento
        Originator originator = new Originator();
        originator.ledTV = new LEDTV("42 inch", "60000Rs", false);

        Caretaker caretaker = new Caretaker();
        caretaker.AddMemento(originator.CreateMemento());
        originator.ledTV = new LEDTV("46 inch", "80000Rs", true);
        caretaker.AddMemento(originator.CreateMemento());
        originator.ledTV = new LEDTV("50 inch", "100000Rs", true);

        Console.WriteLine("\nOrignator current state : " + originator.GetDetails());
        Console.WriteLine("\nOriginator restoring to 42 inch LED TV");
        originator.ledTV = caretaker.GetMemento(0).ledTV;
        Console.WriteLine("\nOrignator current state : " + originator.GetDetails());
        #endregion

        #region abstract factory
        AbstractFactoryDesignPattern.LoaiNacFactory loaiNac = new AbstractFactoryDesignPattern.LoaiNacFactory();
        AbstractFactoryDesignPattern.Client NacClient = new AbstractFactoryDesignPattern.Client(loaiNac);
        AbstractFactoryDesignPattern.LoaiGioFactory loaiGio = new AbstractFactoryDesignPattern.LoaiGioFactory();
        AbstractFactoryDesignPattern.Client GioClient = new AbstractFactoryDesignPattern.Client(loaiGio);

        Console.WriteLine("********* HU TIEU **********");
        Console.WriteLine(NacClient.GetHuTieuDetails());
        Console.WriteLine(GioClient.GetHuTieuDetails());

        Console.WriteLine("******* MY **********");
        Console.WriteLine(NacClient.GetMyDetails());
        Console.WriteLine(GioClient.GetMyDetails());
        #endregion

        #region state
        var xxx = new StateDesignPattern.Context(new StateDesignPattern.ConcreteStateA());
        xxx.Request1();
        xxx.Request2();
        #endregion

        #region flyweight
        var factory = new FlyweightFactory(
               new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
               new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
               new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
               new Car { Company = "BMW", Model = "M5", Color = "red" },
               new Car { Company = "BMW", Model = "X6", Color = "white" }
           );
        factory.listFlyweights();

        FlyweightFactory.addCarToPoliceDatabase(factory, new Car
        {
            Number = "CL234IR",
            Owner = "James Doe",
            Company = "BMW",
            Model = "M5",
            Color = "red"
        });

        FlyweightFactory.addCarToPoliceDatabase(factory, new Car
        {
            Number = "CL234IR",
            Owner = "James Doe",
            Company = "BMW",
            Model = "X1",
            Color = "red"
        });

        factory.listFlyweights();
        #endregion
        Console.ReadLine();
    }
}