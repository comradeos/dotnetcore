using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;
using Color = Google.Apis.Sheets.v4.Data.Color;

namespace GoogleSheetsTelegramBot;

public class IoGoogleSheets
{
    // Для работы с Google Sheets API вам нужно использовать учетные данные сервисного аккаунта. 
    //     Вот шаги для создания и использования учетных данных сервисного аккаунта:
    //
    // Создайте учетные данные сервисного аккаунта
    //     Перейдите в Google Cloud Console.
    //     Выберите ваш проект или создайте новый.
    //     Перейдите в раздел "API & Services" > "Credentials".
    //     Нажмите "Create credentials" и выберите "Service account".
    //     Заполните необходимые поля и нажмите "Create".
    //     На следующем шаге выберите роль "Editor" или "Owner" и нажмите "Continue".
    //     Нажмите "Done".
    //     В разделе "Service accounts" найдите созданный аккаунт и нажмите на кнопку "Manage keys".
    //     Нажмите "Add key" > "Create new key" и выберите формат JSON.
    //     Скачайте файл JSON и сохраните его в вашем проекте (например, service_account.json).
    //     Шаг 2: Обновите ваш код для использования учетных данных сервисного аккаунта
    //
    //     Предоставьте доступ сервисному аккаунту к таблице Google Sheets:
    //
    // Откройте таблицу Google Sheets в браузере.
    //     Нажмите на кнопку "Поделиться" (Share) в правом верхнем углу.
    //     Введите email сервисного аккаунта (например, gsapi2@graphical-balm-433408-i1.iam.gserviceaccount.com) в поле "Добавить людей и группы" (Add people and groups).
    //     Выберите роль "Редактор" (Editor) и нажмите "Отправить" (Send).
    //     Убедитесь, что ваш код корректен:
  
    private readonly string[] _scopes = [SheetsService.Scope.Spreadsheets];
    private const string ApplicationName = "Google Sheets API .NET Quickstart";
    
    // Copy of Журнал дзвінків на 2024 рік 
    private const string SpreadsheetId = "1E53bygPrEP_57mx_zVEFnGUr26Aou9_NCOHV7X9MBfA";
    private const string SheetName = "Журнал ЗАЯВОК 2"; // "Лист32";
    private readonly SheetsService? _service;
    
    public IoGoogleSheets()
    {
        GoogleCredential credential;

        // Загрузка учетных данных сервисного аккаунта
        using (FileStream stream = new("paymaxsheets.json", FileMode.Open, FileAccess.Read)) // "credentials.json"
        {
        credential = GoogleCredential.FromStream(stream).CreateScoped(_scopes);
        }
        // credential = GoogleCredential.FromJson(json).CreateScoped(_scopes);

        // Создание службы Google Sheets API
        _service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
    }

    public void Test()
    {
        // Dictionary<int, IList<object>> rows = GetRowsByColumnValue("D", "F25");
        // foreach ((int num, IList<object> row) in rows)
        // {
        //     Console.WriteLine($"Row {num}: {row[6]}");
        // }
        // Console.WriteLine($"Rows count: {rows.Values.Count}");

        // GetLastFilledRow
        // int n = GetLastFilledRow("E");
        // Console.WriteLine($"Last filled row: {n}");

        // _ = UpdateCell("E", 30320, "oOoOoOo");
        // _ = UpdateCell("E", 30321, 412);
        // _ = UpdateCell("E", 30322, 25.3);
        
        // CellBackgroundColor
        // _ = CellBackgroundColor("E", 30320, "#ff00ff");

        /*
        int counter = 0;
        int lastRowNum = 0;
        while (true)
        {
            ++counter;
            Thread.Sleep(5000);
            
            int lastRowNumUpd = GetLastNumberDayTimeFilledRow();
            
            if (lastRowNum != lastRowNumUpd)
            {
                lastRowNum = lastRowNumUpd;
                Console.WriteLine($"Last row has been updated: {lastRowNum}");
            }
            
            if (counter >= 120) break;
        }
        */
        
        Dictionary<int, object> newFilter = new()
        {
            { 0, "59" },         // A
            { 1, "02.09.2024" }, // B
            { 2, "10:07:42" },   // C
            { 10, "Екіпаж 8ф" },  // K
        };
        
        Dictionary<int, IList<object>> rows = GetRowsByFilter(newFilter);
        Console.WriteLine(rows.Count);
        foreach (KeyValuePair<int, IList<object>> row in rows)
        {
            Console.WriteLine($"Row {row.Key}: {row.Value[0]} {row.Value[1]} {row.Value[2]} {row.Value[10]}");
        }
        
        int r = new Random().Next(10, 99);
        UpdateCell("E", 30325, $"тест {r}");
        CellBackgroundColor("E", 30325, $"#{r}{r}{r}");
        
        string? color = GetCellBackgroundColor("E", 30326);
        Console.WriteLine($"Color: {color} ({string.IsNullOrEmpty(color)})");
    }

    public string? UpdateCell(string column, int row, object value)
    {
        string? error = null;
        
        string range = $"{SheetName}!{column}{row}";
        
        ValueRange valueRange = new()
        {
            Values = new List<IList<object>> { new List<object> { value } }
        };

        UpdateRequest? updateRequest = _service?.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);

        if (updateRequest == null)
        {
            return error;
        }
        
        updateRequest.ValueInputOption = UpdateRequest.ValueInputOptionEnum.RAW;
        
        try
        {
            updateRequest.Execute();
            
            Console.WriteLine($"Updated cell {column}{row} with '{value}'");
        }
        catch (Exception _)
        {
            error = "Unable to update cell";
        }

        return error;
    }
    
    public int GetLastFilledRow(string column)
    {
        string range = $"{SheetName}!{column}:{column}";
        
        GetRequest? request = _service?.Spreadsheets.Values.Get(SpreadsheetId, range);
        
        ValueRange? response = request?.Execute();
        
        IList<IList<object>>? values = response?.Values;

        if (values == null || values.Count == 0)
        {
            return 0;
        }

        for (int i = values.Count - 1; i >= 0; i--)
        {
            if (values[i].Count > 0 && !string.IsNullOrEmpty(values[i][0].ToString()))
            {
                return i + 1;
            }
        }

        return 0;
    }
    
    public Dictionary<int, IList<object>> GetRowsByColumnValue(string column, string value)
    {
        string range = $"{SheetName}!{column}:{column}";
        
        GetRequest? request = _service?.Spreadsheets.Values.Get(SpreadsheetId, range);
        ValueRange? response = request?.Execute();
        
        IList<IList<object>>? values = response?.Values;

        if (values == null || values.Count == 0)
        {
            return new Dictionary<int, IList<object>>();
        }
        
        Dictionary<int, IList<object>> result = new(); 

        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].Count <= 0 || values[i][0].ToString() != value)
            {
                continue;
            }
            
            string rowRange = $"{SheetName}!A{i + 1}:Z{i + 1}";
            
            GetRequest? rowRequest = _service?.Spreadsheets.Values.Get(SpreadsheetId, rowRange);
            ValueRange? rowResponse = rowRequest?.Execute();
            
            if (rowResponse?.Values is { Count: > 0 })
            {
                result.Add(i + 1, rowResponse.Values[0]);
            }
        }

        return result;
    }
    
    public IList<object> GetRowNumber(int row)
    {
        string range = $"{SheetName}!A{row}:Z{row}";
        GetRequest? request = _service?.Spreadsheets.Values.Get(SpreadsheetId, range);
        ValueRange? response = request?.Execute();
        return response?.Values?.FirstOrDefault() ?? new List<object>();
    }

    public string? CellBackgroundColor(string column, int row, string hexColorCode)
    {
        string? error = null;
        
        System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(hexColorCode);

        int columnIndex = column.ToUpper()[0] - 'A';

        List<Request> requests =
        [
            new()
            {
                RepeatCell = new RepeatCellRequest
                {
                    Range = new GridRange
                    {
                        SheetId = GetSheetId(SheetName),
                        StartRowIndex = row - 1,
                        EndRowIndex = row,
                        StartColumnIndex = columnIndex,
                        EndColumnIndex = columnIndex + 1
                    },
                    Cell = new CellData
                    {
                        UserEnteredFormat = new CellFormat
                        {
                            BackgroundColor = new Color
                            {
                                Red = color.R / 255f,
                                Green = color.G / 255f,
                                Blue = color.B / 255f
                            }
                        }
                    },
                    Fields = "userEnteredFormat.backgroundColor"
                }
            }
        ];

        BatchUpdateSpreadsheetRequest batchUpdateRequest = new() { Requests = requests };

        try
        {
            BatchUpdateSpreadsheetResponse? _ = _service?.Spreadsheets
                .BatchUpdate(batchUpdateRequest, SpreadsheetId).Execute();
            
            Console.WriteLine($"Set background color {hexColorCode} for cell {column}{row}");
        }
        catch (Exception _)
        {
            error = "Unable to set background color";
        }

        return error;
    }

    private int GetSheetId(string sheetName)
    {
        Spreadsheet? spreadsheet = _service?
            .Spreadsheets.Get(SpreadsheetId).Execute();
        
        Sheet? sheet = spreadsheet?
            .Sheets?.FirstOrDefault(s => s.Properties.Title == sheetName);
        
        return sheet?.Properties.SheetId ?? 0;
    }
    
    public int GetLastNumberDayTimeFilledRow()
    {
        GetRequest? request = _service?.Spreadsheets.Values.Get(SpreadsheetId, $"{SheetName}!A:Z");
        ValueRange? response;
        
        try
        {
            response = request?.Execute();
        }
        catch (Exception _)
        {
            return 0;
        }
        
        IList<IList<object>>? values = response?.Values;

        if (values == null || values.Count == 0)
        {
            return 0;
        }

        for (int i = values.Count - 1; i >= 0; i--)
        {
            if (values[i].Count <= 0
                || string.IsNullOrEmpty(values[i][0].ToString())
                || string.IsNullOrEmpty(values[i][1].ToString())
                || string.IsNullOrEmpty(values[i][2].ToString()))
            {
                continue;
            }
            return i + 1;
        }
        return 0;
    }

    private readonly Dictionary<int, object> _filter = new()
    {
        { 0, "59" },         // A
        { 1, "02.09.2024" }, // B
        { 2, "10:07:42" },   // C
        { 10, "Екіпаж 8" },  // K
    };
    
    public Dictionary<int, IList<object>> GetRowsByFilter(Dictionary<int, object> filter)
    {
        GetRequest? request = _service?.Spreadsheets.Values.Get(SpreadsheetId, $"{SheetName}!A:Z");
        ValueRange? response = request?.Execute();
        
        IList<IList<object>>? values = response?.Values;

        if (values == null || values.Count == 0)
        {
            return new Dictionary<int, IList<object>>();
        }
        
        Dictionary<int, IList<object>> result = new(); 

        for (int i = 0; i < values.Count; i++)
        {
            bool isMatch = true;
            
            foreach ((int key, object value) in filter)
            {
                if (values[i].Count > key && values[i][key].ToString() == value.ToString())
                {
                    continue;
                }
                
                isMatch = false;
                break;
            }
            
            if (!isMatch)
            {
                continue;
            }
            
            string rowRange = $"{SheetName}!A{i + 1}:Z{i + 1}";
            
            GetRequest? rowRequest = _service?.Spreadsheets.Values.Get(SpreadsheetId, rowRange);
            ValueRange? rowResponse = rowRequest?.Execute();
            
            if (rowResponse?.Values is { Count: > 0 })
            {
                result.Add(i + 1, rowResponse.Values[0]);
            }
        }

        return result;
    }
    
    
    public string? GetCellBackgroundColor(string column, int row)
    {
        SpreadsheetsResource.GetRequest? request = _service?.Spreadsheets.Get(SpreadsheetId);

        if (request == null)
        {
            return null;
        }
            
        request.Ranges = new List<string> { $"{SheetName}!{column}{row}:{column}{row}" };
        request.IncludeGridData = true;
        
        try
        {
            Spreadsheet response = request.Execute();
            CellData cellData = response.Sheets[0].Data[0].RowData[0].Values[0];

            if (cellData.UserEnteredFormat?.BackgroundColor == null) return null;
            
            Color? color = cellData.UserEnteredFormat.BackgroundColor;
            
            int red = (int)(color.Red * 255 ?? 0);
            int green = (int)(color.Green * 255 ?? 0);
            int blue = (int)(color.Blue * 255 ?? 0);

            return $"#{red:X2}{green:X2}{blue:X2}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting cell background color: {ex.Message}");
            return null;
        }
    }
}