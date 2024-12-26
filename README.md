## Общая информация

Данный репозиторий содержит несколько лабораторных работ, объединённых в одном Visual Studio Solution (`development-of-software-modules.sln`). Каждая лабораторная работа размещена в отдельной папке:

1. **lab-1-miniexplorer**  
2. **lab-2-classes**  
3. **lab-3-example** (папка `lab-3-example`, проект `lab-3-example-mvp`)  
4. **lab-3-example-mvvm**  
5. **lab-3-individual-mvp**  
6. **lab-3-individual-mvvm**

Все они связаны с изучением различных шаблонов проектирования (MVP, MVVM), шифрованием (Виженер), работой с дробями, матрицами и мини-обозревателем файлов.

## Структура репозитория

```
vemneyy-development-of-software-modules-yureva/
├── lab-1-miniexplorer/
│   ├── MainWindow.xaml.cs
│   ├── App.xaml
│   ├── MainWindow.xaml
│   ├── AssemblyInfo.cs
│   └── lab-1-miniexplorer.csproj

├── lab-2-classes/
│   ├── MainWindow.xaml.cs
│   ├── VigenereCipher.cs
│   ├── Password.cs
│   ├── SquareMatrix.cs
│   ├── Fraction.cs
│   ├── App.xaml
│   ├── MainWindow.xaml
│   ├── AssemblyInfo.cs
│   └── lab-2-classes.csproj

├── lab-3-example/
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Form1.resx
│   ├── Program.cs
│   └── lab-3-example-mvp.csproj

├── lab-3-example-mvvm/
│   ├── MainWindow.xaml.cs
│   ├── MainWindow.xaml
│   ├── AssemblyInfo.cs
│   ├── App.xaml
│   └── lab-3-example-mvvm.csproj

├── lab-3-individual-mvp/
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── IView.cs
│   ├── Presenter.cs
│   ├── Fraction.cs
│   ├── Program.cs
│   └── lab-3-individual-mvp.csproj

├── lab-3-individual-mvvm/
│   ├── MainWindow.xaml.cs
│   ├── MainWindow.xaml
│   ├── Fraction.cs
│   ├── AssemblyInfo.cs
│   ├── App.xaml
│   ├── App.xaml.cs
│   └── lab-3-individual-mvvm.csproj

└── development-of-software-modules.sln
```

Краткое описание каждого проекта:

- **lab-1-miniexplorer**  
  Мини-обозреватель файловой системы. Показывает список дисков, каталогов и файлов, а также позволяет открывать файлы. При закрытии ведёт логирование недавно открытых файлов.

- **lab-2-classes**  
  Демонстрация операций над матрицами (сложение, вычитание, умножение, проверка верхне- и нижнетреугольной) и дробями, а также содержит реализацию шифра Виженера и проверку «сильных» паролей.

- **lab-3-example** (MVP)  
  Пример простой реализации паттерна MVP (Model–View–Presenter) на Windows Forms: приложение для вычисления площади прямоугольника.

- **lab-3-example-mvvm**  
  Пример реализации MVVM (Model–View–ViewModel) на WPF: аналогичное вычисление площади, но через привязку свойств в XAML.

- **lab-3-individual-mvp**  
  Индивидуальный проект на MVP с дробями (сложение, вычитание, умножение, деление), где вся логика вынесена в Presenter, а View не содержит бизнес-логики.

- **lab-3-individual-mvvm**  
  Аналогичный индивидуальный пример с дробями, но уже на MVVM: ViewModel обрабатывает команды, а View лишь привязывается к свойствам.

## Системные требования

- **.NET 8.0** или **.NET 9.0** (в зависимости от указанного в `.csproj`)  
- Visual Studio 2022 (или более новый релиз) с поддержкой .NET desktop development

## Инструкция по сборке и запуску

1. **Склонировать репозиторий**:
   ```bash
   git clone https://github.com/username/vemneyy-development-of-software-modules-yureva.git
   ```

2. **Открыть решение**:
   - Запустить Visual Studio.
   - Открыть файл `development-of-software-modules.sln`.

3. **Выбрать проект для запуска**:
   - В **Solution Explorer** кликнуть правой кнопкой на нужном проекте (например, `lab-1-miniexplorer` или `lab-2-classes`).
   - Выбрать **Set as Startup Project**.

4. **Запустить приложение**:
   - Нажать **F5** или **Debug -> Start Debugging**.  
   - Для сборки без запуска выбрать **Build -> Build Solution**.

## Краткое описание функционала

### lab-1-miniexplorer
- Отслеживает подключение/отключение дисков.
- Отображает информацию о размере диска, свободном месте.
- Выводит список каталогов и файлов.
- При клике на файл — открывает его внешней программой.
- При закрытии логирует все файлы, которые были открыты за последние несколько секунд.

### lab-2-classes
- **Matrix**:
  - Создание квадратной матрицы любого размера (до 10×10).
  - Сложение, вычитание, умножение матриц и умножение на скаляр.
  - Проверка на верхне- и нижнетреугольную матрицу.
- **Fraction**:
  - Сложение, вычитание, умножение, деление дробей с автоматическим упрощением.
- **VigenereCipher**:
  - Шифрование и дешифрование текста на русском алфавите.
- **StrongPassword**:
  - Анализ «сильности» пароля (наличие разных типов символов, длина, отсутствие личных данных и т.п.).

### lab-3-example (MVP)
- Windows Forms-приложение для вычисления площади прямоугольника.
- Model хранит значения, Presenter связывает View (Form) и Model, обеспечивая логику вычислений.

### lab-3-example-mvvm
- WPF-приложение: демонстрирует работу паттерна MVVM.
- Ввод длины и ширины → автоматический расчёт площади с помощью привязки свойств.

### lab-3-individual-mvp
- Windows Forms-приложение, демонстрирующее MVP для операций с дробями (A + B, A - B и т.д.).
- View содержит только элементы управления и их события.
- Presenter реализует логику с использованием модели дробей.

### lab-3-individual-mvvm
- WPF-приложение, демонстрирующее MVVM для операций с дробями.
- ViewModel содержит команды (AddCommand, SubtractCommand и т.д.) и свойства NumeratorA/B, DenominatorA/B, Result.
- View (XAML) привязана к ViewModel (двустороннее или одностороннее Binding).

## Заключение

Данный репозиторий был создан для выполнения лабораторных работ с .NET-проектами в колледже ГУАП: от базового WPF-приложения для просмотра файлов до различных паттернов проектирования (MVP, MVVM), а также операции с матрицами, дробями и реализацию шифра Виженера.

При возникновении вопросов или проблем с запуском обращайтесь к документации .NET и Visual Studio.


---  

> **Примечание**  
> Все проекты можно собирать и запускать независимо друг от друга, выбрав соответствующий **Startup Project** в среде Visual Studio.  

---  
