## TaskRunway Application Testing

### Prerequisites

Before you start, ensure you have:

- Visual Studio with .NET support installed.

### Installation

1. **Clone the repository:**

```bash
git clone https://github.com/username/repository-name.git
cd repository-name
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
```
Or, Open Visual Studio, then open the NuGet Package Manager Console by navigating to Tools > NuGet Package Manager > Package Manager Console. Run the following command:
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
### Run the application:
Press F5 in Visual Studio to build and run the application.

### Testing:
Во рамките на проектот кој е изработен во Visual Studio, имплементиравме framework **MSTest** која е основан од Microsoft.

МSTest се користи за тестирање на .Net апликации и подржува **unit testing**. За да креирање тестови потребно е да се додаде нов проект во веќе постоечкиот и да се ибере **Unit Test Project template**. Во овој проект се наоѓаат класи анотирани како **[TestClass]** и методи анотирани како **[TestMethod]**. 

Во нашиот проект ја искористивме и анотацијата **[TestInitialize]** која се извршува *пред стартување на секој метод* и служи за да се припреми работната околина.

За *валидација* користевме **Assertions** при што валидиравме каков output ќе се добие од самата метода.

Најчесто користени **Assertions** во нашиот проект:

- Assert.IsNotNull
- Assert.IsInstanceOfType
- Assert.AreEqual
- Assert.IsFalse

Исто така ја користевме класата **Mock**, која припаѓа на *Moq framework* и овозможува да креираме *mock објекти* во *unit tests*. Мock објектите служат за симулација на однесувањето на реалните објекти при контролиран начин, со ова овозможуваме *кодот да биде тестиран независно од неговите dependencies*.

Тестовите може да се стартуваат со десен клик на тeст класата и ја бираме опцијата *Run Tests* при што дознаваме дали тестот се извршил успешно и кој е неговиот *coverage*. 
Доколку истиот неуспешно завршил може во *debug mode* да ја поправиме грешката

### Изработено од:
- Кристина Србиноска 211099
- Антониа Стајковска 211048


