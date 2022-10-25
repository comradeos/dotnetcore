namespace HelloDotNetConsole.L14Classes; 

class RobotBase {
    private string _type;
    private string _model;
    
    /**
     * Конструктор.
     */
    public RobotBase(string model, string type) {
        this._model = model;
        this._type = type;
    }
    
    /**
     * Сеттер для _type
     */
    public void SetType(string newType) {
        this._type = newType;
    }
    
    /**
     * Вывод на экран _type
     */
    public void PrintType() {
        Console.WriteLine(this._type);
    }

    /**
     * Сеттер для _model
     */
    public void SetModel(string newModel) {
        this._model = newModel;
    }

    /**
     * Вывод на экран _model
     */
    public void PrintModel() {
        Console.WriteLine(this._model);
    }
}