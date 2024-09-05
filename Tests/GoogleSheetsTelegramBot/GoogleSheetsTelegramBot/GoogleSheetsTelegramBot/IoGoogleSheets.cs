using System.Globalization;
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
    private const string SheetName = "Журнал ЗАЯВОК"; // "Лист32";
    private readonly SheetsService? _service;
    
    public IoGoogleSheets()
    {
        GoogleCredential credential;

        // Загрузка учетных данных сервисного аккаунта
        using (FileStream stream = new("paymaxsheets.json", FileMode.Open, FileAccess.Read)) // "credentials.json"
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(_scopes);
        }

        // Создание службы Google Sheets API
        _service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
    }

    public void Test()
    {
        IList<IList<object>> rows = GetRowsWithSpecificValue("D", "AAA");
        
        foreach (var row in rows)
        {
              Console.WriteLine(row[6]);
        }
       
        Console.WriteLine($"Rows count: {rows.Count}");

        // GetLastFilledRow
        int n = GetLastFilledRow("E");
        Console.WriteLine($"Last filled row: {n}");

        _ = Update("E", 30320, "AAA777");
        // _ = Update("E", 30321, 412);
        // _ = Update("E", 30322, 25.3);
        
        // SetBackgroundColor
        _ = SetBackgroundColor("E", 30320, "#8e7cc3");
    }

    public string? Update(string column, int row, object value)
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
    
    public IList<IList<object>> GetRowsWithSpecificValue(string column, string value)
    {
        string range = $"{SheetName}!{column}:{column}";
        
        GetRequest? request = _service?.Spreadsheets.Values.Get(SpreadsheetId, range);
        ValueRange? response = request?.Execute();
        
        IList<IList<object>>? values = response?.Values;

        if (values == null || values.Count == 0)
        {
            return new List<IList<object>>();
        }

        IList<IList<object>> matchingRows = new List<IList<object>>();

        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].Count <= 0 || values[i][0].ToString() != value)
            {
                continue;
            }
            string rowRange = $"{SheetName}!A{i + 1}:Z{i + 1}"; // Предполагаем, что данные находятся в диапазоне A:Z
            
            GetRequest? rowRequest = _service?.Spreadsheets.Values.Get(SpreadsheetId, rowRange);
            ValueRange? rowResponse = rowRequest?.Execute();
            
            if (rowResponse?.Values is { Count: > 0 })
            {
                matchingRows.Add(rowResponse.Values[0]);
            }
        }

        return matchingRows;
    }
    
    public IList<object> GetRowNumber(int row)
    {
        string range = $"{SheetName}!A{row}:Z{row}";
        GetRequest? request = _service?.Spreadsheets.Values.Get(SpreadsheetId, range);
        ValueRange? response = request?.Execute();
        return response?.Values?.FirstOrDefault() ?? new List<object>();
    }

    public string? SetBackgroundColor(string column, int row, string hexColorCode)
    {
        // Преобразуем hex-код цвета в RGB
        var color = System.Drawing.ColorTranslator.FromHtml(hexColorCode);

        // Преобразуем строку столбца в индекс (A -> 0, B -> 1, и т.д.)
        int columnIndex = column.ToUpper()[0] - 'A';

        var requests = new List<Request>
        {
            new Request
            {
                RepeatCell = new RepeatCellRequest
                {
                    Range = new GridRange
                    {
                        SheetId = GetSheetId(SheetName),
                        StartRowIndex = row - 1, // Google Sheets is 0-indexed
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
        };

        var batchUpdateRequest = new BatchUpdateSpreadsheetRequest { Requests = requests };
        var response = _service?.Spreadsheets.BatchUpdate(batchUpdateRequest, SpreadsheetId).Execute();

        return response != null ? "Background color set successfully" : "Failed to set background color";
    }

    private int GetSheetId(string sheetName)
    {
        Spreadsheet? spreadsheet = _service?.Spreadsheets.Get(SpreadsheetId).Execute();
        Sheet? sheet = spreadsheet?.Sheets?.FirstOrDefault(s => s.Properties.Title == sheetName);
        return sheet?.Properties.SheetId ?? 0;
    }

}