// MainWindow.xaml.cs

using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Controls;
using System.Windows;

namespace lab_1_miniexplorer
{
    public partial class MainWindow : Window
    {
        private ManagementEventWatcher? driveWatcher;
        private List<(string fileName, DateTime openTime)> openedFiles = new List<(string fileName, DateTime openTime)>();

        public MainWindow()
        {
            InitializeComponent();
            LoadDrivesToComboBox(); // Инициализация списка дисков
            StartDriveWatcher(); // Запуск наблюдателя за подключением/отключением дисков
        }

        // Загрузка доступных дисков в ComboBox
        private void LoadDrivesToComboBox()
        {
            string? currentSelection = diskSelection.SelectedItem?.ToString(); // Запоминаем текущий выбранный диск

            diskSelection.Items.Clear(); // Очищаем список
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                diskSelection.Items.Add(drive.Name); // Добавляем каждый диск в список
            }

            // Восстанавливаем предыдущий выбор, если он все еще доступен
            if (currentSelection != null && diskSelection.Items.Contains(currentSelection))
            {
                diskSelection.SelectedItem = currentSelection;
            }
        }

        // Запуск наблюдателя за изменениями состояния дисков (подключение/отключение)
        private void StartDriveWatcher()
        {
            driveWatcher = new ManagementEventWatcher();
            driveWatcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            driveWatcher.EventArrived += new EventArrivedEventHandler(OnDriveChanged);
            driveWatcher.Start(); // Запуск наблюдателя
        }

        // Обработчик события изменения состояния диска (подключение/отключение)
        private void OnDriveChanged(object sender, EventArrivedEventArgs e)
        {
            Dispatcher.Invoke(() => LoadDrivesToComboBox()); // Обновляем список дисков в UI-потоке
        }

        // Обработчик изменения выбора диска
        private void diskSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (diskSelection.SelectedItem != null)
            {
                string? selectedDrive = diskSelection.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(selectedDrive)) // Добавляем проверку на null или пустую строку
                {
                    DriveInfo drive = new DriveInfo(selectedDrive);
                    diskInfo.Clear(); // Очищаем информацию о диске

                    if (drive.IsReady) // Проверяем, готов ли диск
                    {
                        // Вычисляем размер диска и свободное место в гигабайтах
                        double totalSizeGB = drive.TotalSize / (double)(1024 * 1024 * 1024);
                        double freeSpaceGB = drive.TotalFreeSpace / (double)(1024 * 1024 * 1024);

                        diskInfo.AppendText($"Объем диска:\n{totalSizeGB:F2} ГБ\n");
                        diskInfo.AppendText($"Свободное пространство:\n{freeSpaceGB:F2} ГБ\n");

                        dirList.Items.Clear(); // Очищаем список директорий
                        try
                        {
                            // Получаем список директорий на диске
                            string[] dirs = Directory.GetDirectories(selectedDrive);
                            foreach (string dir in dirs)
                            {
                                dirList.Items.Add(dir); // Добавляем директории в список
                            }
                        }
                        catch (Exception ex)
                        {
                            diskInfo.AppendText($"Ошибка при получении каталогов:\n{ex.Message}\n"); // Выводим сообщение об ошибке
                        }
                    }
                    else
                    {
                        diskInfo.AppendText("Диск не готов.\n");
                        dirList.Items.Clear(); // Очищаем список, если диск не готов
                    }
                }
            }
        }

        // Обработчик изменения выбора директории
        private void dirList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dirList.SelectedItem != null)
            {
                string? selectedDirectory = dirList.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(selectedDirectory))
                {
                    fileList.Items.Clear(); // Очищаем список файлов

                    try
                    {
                        // Получаем информацию о выбранной директории
                        DirectoryInfo directoryInfo = new DirectoryInfo(selectedDirectory);

                        dirInfo.Clear();
                        dirInfo.AppendText($"Полное название каталога:\n{directoryInfo.FullName}\n");
                        dirInfo.AppendText($"Время создания:\n{directoryInfo.CreationTime}\n");
                        dirInfo.AppendText($"Корневой каталог:\n{directoryInfo.Root}\n");

                        // Получаем список файлов в директории
                        string[] files = Directory.GetFiles(selectedDirectory);
                        foreach (string file in files)
                        {
                            fileList.Items.Add(file); // Добавляем файлы в список
                        }

                        // Если файлов нет, выводим сообщение
                        if (files.Length == 0)
                        {
                            fileList.Items.Add("Нет файлов в выбранной директории.");
                        }
                    }
                    catch (Exception ex)
                    {
                        fileList.Items.Add($"Ошибка при получении файлов:\n{ex.Message}");
                    }
                }
            }
        }

        // Обработчик изменения выбора файла
        private void fileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fileList.SelectedItem != null)
            {
                string? selectedFile = fileList.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(selectedFile) && File.Exists(selectedFile)) // Проверяем, существует ли файл
                {
                    try
                    {
                        // Открываем файл с помощью ассоциированной программы
                        Process.Start(new ProcessStartInfo(selectedFile) { UseShellExecute = true });

                        // Добавляем файл в список открытых файлов
                        openedFiles.Add((selectedFile, DateTime.Now));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}");
                    }

                    Dispatcher.Invoke(() =>
                    {
                        fileList.SelectedItem = null; // Сбрасываем выбор файла
                    });
                }
            }
        }
        // Обработка закрытия окна
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (driveWatcher != null)
            {
                driveWatcher.Stop(); // Останавливаем наблюдатель за дисками
                driveWatcher.Dispose(); // Освобождаем ресурсы
            }

            LogOpenedFiles(); // Логируем недавно открытые файлы
        }

        // Логирование недавно открытых файлов в файл
        private void LogOpenedFiles()
        {
            DateTime now = DateTime.Now;
            // Отбираем файлы, открытые за последние 10 секунд
            var recentFiles = openedFiles.Where(f => (now - f.openTime).TotalSeconds <= 10).ToList();

            string logFileName = "output.txt";
            int counter = 1;
            while (File.Exists(logFileName))
            {
                logFileName = $"output.{counter}.txt"; // Генерируем уникальное имя файла
                counter++;
            }

            // Записываем список файлов в лог
            using (StreamWriter writer = new StreamWriter(logFileName, true))
            {
                foreach (var file in recentFiles)
                {
                    writer.WriteLine($"{file.fileName} (открыт в {file.openTime})");
                }
            }
        }
    }
}