# AdvancedCSharpTopic

166. Delegates Introduction
Các đại biểu trong C# là một cách an toàn về kiểu để đóng gói tham chiếu đến một phương thức. Chúng tương tự như con trỏ hàm trong C++ nhưng an toàn và bảo mật về kiểu. Các đại biểu được sử dụng để triển khai các sự kiện và các phương thức gọi lại. Tất cả các đại biểu đều được bắt nguồn ngầm từ lớp `System.Delegate`.

Dưới đây là những điểm chính về đại biểu:

1. **Tuyên bố**:
    - Một delegate được khai báo với một chữ ký thể hiện kiểu trả về và các tham số của các phương thức mà nó có thể tham chiếu.
    public delegate void MyDelegate(string message);
2. **Khởi tạo**:
    - Một cá thể đại biểu được tạo bằng một phương thức khớp với chữ ký của nó.

MyDelegate del = new MyDelegate(MyMethod);
// or simply
MyDelegate del = MyMethod;

3. **Lời mời**:
    - Khi một đại biểu được gán một phương thức, nó có thể được gọi giống như bất kỳ phương thức nào.
del("Hello, World!");
4. **Đại biểu phát đa hướng**:
    - Các đại biểu trong C# là multicast, nghĩa là chúng có thể chứa các tham chiếu đến nhiều phương thức. Khi đại biểu được gọi, nó sẽ gọi các phương thức một cách tuần tự theo thứ tự chúng được thêm vào.

del += AnotherMethod;
del("Hello again!"); // Calls both MyMethod and AnotherMethod

5. **Phương thức ẩn danh và biểu thức Lambda**:
    - Các đại biểu có thể được sử dụng với các phương thức ẩn danh hoặc biểu thức lambda, cho phép các phương thức nội tuyến được truyền dưới dạng tham số.
MyDelegate del = delegate (string msg) { Console.WriteLine(msg); };
// or using a lambda expression
MyDelegate del = (msg) => Console.WriteLine(msg);
6. **Trường hợp sử dụng**:
    - Các đại biểu được sử dụng để xác định các phương thức gọi lại (ví dụ: để chỉ định điều gì sẽ xảy ra khi một sự kiện xảy ra).
    - Chúng là cơ sở cho `Sự kiện` trong C#.
    - Delegate được sử dụng trong biểu thức LINQ.
    - Chúng cũng được sử dụng trong các tình huống trong đó một phương thức cần được truyền dưới dạng tham số.

7. **Các đại biểu chức năng, hành động và vị ngữ**:
    - .NET cung cấp sẵn các kiểu ủy nhiệm chung chung `Func<>`, `Action<>`, và `Predicate<>` cho các tình huống phổ biến.
    - `Action<>` được sử dụng cho các phương thức không trả về giá trị.
    - `Func<>` được sử dụng cho các phương thức trả về một giá trị.
    - `Vị ngữ<>` được sử dụng cho các phương thức trả về giá trị boolean (`bool`).

Đây là một ví dụ đơn giản thể hiện việc sử dụng đại biểu:

public delegate void DisplayMessage(string message);

class Program
{
    static void Main()
    {
        DisplayMessage messageTarget = WriteMessage;
        messageTarget("Hello, World!");

        messageTarget = ShowMessage;
        messageTarget("Hello again!");
    }

    static void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }

    static void ShowMessage(string message)
    {
        Console.WriteLine($"Displayed: {message}");
    }
}

Trong ví dụ này, `DisplayMessage` là một đại biểu và `WriteMessage` và `ShowMessage` là các phương thức khớp với chữ ký của nó. Đại biểu `messageTarget` có thể trỏ đến một trong hai phương thức này.
169. Anonymous Methods
Các phương thức ẩn danh trong C# cung cấp một cách để xác định các nội dung phương thức nội tuyến, không tên có thể được sử dụng ở bất kỳ nơi nào cần có loại đại biểu. Tính năng này được giới thiệu trong C# 2.0 và đặc biệt hữu ích cho các phương thức đơn giản chỉ được sử dụng một lần, thường làm đối số cho các phương thức khác, chẳng hạn như trình xử lý sự kiện hoặc lệnh gọi lại. Tuy nhiên, với sự ra đời của biểu thức lambda trong C# 3.0, việc sử dụng các phương thức ẩn danh đã trở nên ít phổ biến hơn vì biểu thức lambda cung cấp cú pháp ngắn gọn hơn cho cùng một mục đích.

Dưới đây là tổng quan về các phương pháp ẩn danh:

1. **Cú pháp**:
    - Một phương thức ẩn danh được tạo bằng từ khóa `delegate`, theo sau là danh sách tham số (nếu có) và nội dung phương thức.
    - Nếu đại biểu không lấy tham số nào thì có thể bỏ qua danh sách tham số.
    - Kiểu trả về của một phương thức ẩn danh được suy ra từ phương thức được gán cho nó.

2. **Cách sử dụng**:
    - Phương thức ẩn danh thường được sử dụng với delegate hoặc sự kiện.
    - Chúng hữu ích khi phần thân phương thức quá ngắn để có thể đặt tên riêng cho một phương thức hoặc khi phương thức đó sẽ không được sử dụng lại ở nơi khác.

3. **Lấy các biến bên ngoài**:
    - Các phương thức ẩn danh có thể nắm bắt các biến từ phạm vi bên ngoài (các biến nằm trong phạm vi mà phương thức ẩn danh được xác định). Điều này được gọi là sự đóng cửa trong lập trình chức năng.

Đây là một ví dụ về việc sử dụng phương thức ẩn danh trong C#:

using System;

public delegate void MyDelegate(string message);

class Program
{
    static void Main()
    {
        MyDelegate del = delegate (string msg) {
            Console.WriteLine($"Anonymous method called with message: {msg}");
        };

        del("Hello, World!");
    }
}

Trong ví dụ này, một phương thức ẩn danh được gán cho đại biểu `del` thuộc loại `MyDelegate`. Phương thức này lấy một tham số chuỗi `msg` và ghi nó vào bảng điều khiển.

So sánh với biểu thức Lambda:
- Biểu thức Lambda cung cấp một cách ngắn gọn và dễ đọc hơn để viết các phương thức nội tuyến. Biểu thức lambda tương đương cho phương thức ẩn danh ở trên sẽ là:
MyDelegate del = (msg) => Console.WriteLine($"Lambda called with message: {msg}");
- Do cú pháp ngắn gọn nên biểu thức lambda thường được ưu tiên hơn so với các phương thức ẩn danh để triển khai đại biểu nội tuyến.

Bất chấp sự phổ biến của biểu thức lambda, việc hiểu các phương thức ẩn danh vẫn hữu ích, đặc biệt là khi đọc hoặc duy trì các cơ sở mã C# cũ hơn, nơi chúng có thể được sử dụng rộng rãi.
170. Lambda Expressions
Biểu thức Lambda trong C# là một cách ngắn gọn để biểu diễn các phương thức ẩn danh. Chúng đặc biệt hữu ích khi viết các đoạn mã ngắn có thể được chuyển dưới dạng đối số hoặc được sử dụng trong biểu thức truy vấn. Được giới thiệu trong C# 3.0, biểu thức lambda là một phần cơ bản của LINQ (Truy vấn tích hợp ngôn ngữ) và được sử dụng rộng rãi để xử lý sự kiện, xác định logic sắp xếp tùy chỉnh, v.v.

Đây là những điều bạn cần biết về biểu thức lambda:

1. **Cú pháp**:
    - Biểu thức lambda được viết bằng toán tử lambda `=>`, được đọc là "đi tới" hoặc "trở thành".
    - Phía bên trái toán tử lambda chỉ định các tham số đầu vào (nếu có) và phía bên phải chứa khối biểu thức hoặc câu lệnh.

2. **Các loại biểu thức Lambda**:
    - **Biểu thức Lambdas**: Chúng bao gồm một biểu thức duy nhất trả về một giá trị. Kiểu trả về được trình biên dịch suy ra.
(x, y) => x + y
    - **Câu lệnh Lambdas**: Những câu lệnh này có thể chứa nhiều câu lệnh được đặt trong `{}` và có thể được sử dụng để thực hiện các thao tác phức tạp hơn.
      (x, y) => { return x + y; }
3. **Cách sử dụng**:
    - Biểu thức Lambda thường được sử dụng với delegate hoặc cây biểu thức.
    - Chúng là một phần quan trọng của các truy vấn LINQ và được sử dụng rộng rãi trong các phương thức lấy `Func<T, TResult>`, `Action<T>`, hoặc các kiểu ủy nhiệm tương tự.

4. **Lấy các biến bên ngoài**:
    - Lambdas có thể nắm bắt các biến từ phạm vi bên ngoài (đóng). Điều này rất hữu ích khi viết các hàm cục bộ có thể truy cập các biến cục bộ.

5. **Ví dụ**:
    - Sắp xếp danh sách bằng biểu thức lambda làm bộ so sánh tùy chỉnh:


List<int> numbers = new List<int> { 3, 1, 4, 1, 5, 9 };
numbers.Sort((a, b) => a.CompareTo(b));
    - Sử dụng biểu thức lambda với delegate `Func`:
Func<int, int, int> add = (x, y) => x + y;
int result = add(5, 10); // result is 15    - Sử dụng biểu thức lambda trong truy vấn LINQ:
var evenNumbers = numbers.Where(n => n % 2 == 0);
6. **Không có cú pháp tham số**:
    - Nếu biểu thức lambda không có tham số, bạn chỉ cần viết `() =>`.
   
7. **Suy luận kiểu**:
    - Trình biên dịch thường suy ra kiểu đầu vào của biểu thức lambda. Ví dụ: trong `numbers. Where(n => n % 2 == 0)`, loại `n` được suy ra từ loại phần tử trong `numbers`.

Biểu thức Lambda là một tính năng mạnh mẽ giúp mã dễ đọc và ngắn gọn hơn, đặc biệt khi làm việc với các bộ sưu tập, xử lý sự kiện và bất kỳ tình huống nào yêu cầu đại biểu ngắn gọn. Chúng là một trong những tính năng chính tạo nên phong cách lập trình chức năng trong C#.
172. Events and Multicast Delegates
Trong C#, các sự kiện và đại biểu phát đa hướng là các thành phần chính để thiết kế và triển khai mô hình đăng ký xuất bản, trong đó một đối tượng (nhà xuất bản) thông báo cho các đối tượng khác (người đăng ký) về sự xuất hiện của một số sự kiện. Mô hình này được sử dụng rộng rãi trong các ứng dụng GUI, như Windows Forms hoặc WPF, để xử lý các tương tác của người dùng, nhưng nó cũng hữu ích trong nhiều ngữ cảnh khác.

### Sự kiện:

1. **Định nghĩa**:
    - Sự kiện trong C# là cách để một lớp cung cấp thông báo cho các client của lớp đó khi có điều gì đó thú vị xảy ra với một đối tượng.

2. **Tuyên bố**:
    - Các sự kiện thường được khai báo trong một lớp bằng từ khóa `event`, theo sau là loại đại biểu xác định chữ ký của các phương thức xử lý sự kiện có thể đăng ký sự kiện.

3. **Đăng ký**:
    - Các đối tượng khác đăng ký sự kiện bằng cách gắn phương thức xử lý sự kiện vào sự kiện, phương thức này phải khớp với chữ ký của đại biểu.

4. **Tăng sự kiện**:
    - Lớp nhà xuất bản đưa ra sự kiện vào thời điểm thích hợp và tất cả các trình xử lý sự kiện đã đăng ký đều được gọi.

### Đại biểu Multicast:

1. **Định nghĩa**:
    - Một đại biểu multicast, trong C#, là một đại biểu chứa các tham chiếu đến nhiều hơn một hàm. Điều này cho phép đại biểu gọi nhiều phương thức khi nó được gọi.

2. **Cách sử dụng trong Sự kiện**:
    - Các sự kiện trong C# sử dụng các đại biểu multicast để duy trì danh sách các trình xử lý sự kiện đính kèm. Khi sự kiện được đưa ra, đại biểu multicast sẽ gọi từng trình xử lý sự kiện.

### Ví dụ:

Dưới đây là ví dụ minh họa cách khai báo một sự kiện bằng cách sử dụng đại biểu phát đa hướng, đăng ký sự kiện và nâng cao sự kiện đó.

Đầu tiên, xác định một đại biểu:

public delegate void Notify();  // Delegate

Sau đó, xác định một lớp với một sự kiện:

public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; // Event

    public void StartProcess()
    {
        Console.WriteLine("Process Started!");
        // Some code here..
        OnProcessCompleted();
    }

    protected virtual void OnProcessCompleted()
    {
        // If ProcessCompleted is not null then call delegate
        ProcessCompleted?.Invoke();
    }
}
Cuối cùng, đăng ký sự kiện và kích hoạt nó:

class Program
{
    static void Main(string[] args)
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // Subscribe to the event
        bl.StartProcess();
    }

    // Event handler
    public static void bl_ProcessCompleted()
    {
        Console.WriteLine("Process Completed!");
    }
}

Trong ví dụ này, `ProcessBusinessLogic` có một sự kiện `ProcessCompleted`, sự kiện này được phát sinh sau khi `StartProcess` hoàn thành. Phương thức `Main` của lớp `Program` đăng ký sự kiện này bằng phương thức `bl_ProcessCompleted`, phương thức này được gọi khi sự kiện được đưa ra.

### Những điểm chính:

- **Trình xử lý sự kiện**: Trình xử lý sự kiện trong C# là các phương thức có chữ ký cụ thể, được xác định bởi loại đại biểu được sử dụng cho sự kiện.
- **Đóng gói**: Bằng cách sử dụng các sự kiện, C# cho phép nhà xuất bản bảo vệ phiên bản đại biểu của họ, đảm bảo rằng người đăng ký chỉ có thể thêm hoặc xóa trình xử lý cho sự kiện.
- **An toàn luồng**: Khi đưa ra các sự kiện, đặc biệt là trong môi trường đa luồng, bạn nên cân nhắc đến độ an toàn của luồng. Mẫu chung `ProcessCompleted?.Invoke()` là một cách an toàn theo luồng để kiểm tra giá trị rỗng và gọi đại biểu.
- **Sử dụng trong Ứng dụng giao diện người dùng**: Trong các khung giao diện người dùng như WinForms hoặc WPF, các sự kiện được sử dụng rộng rãi để phản hồi các hành động của người dùng như nhấp chuột, nhấn phím, v.v.

Các sự kiện và đại biểu multicast là nền tảng cho việc triển khai mẫu thiết kế người quan sát trong C#. Chúng cung cấp một cách rõ ràng và mạnh mẽ để xử lý các tình huống trong đó một hành động được thực hiện bởi một đối tượng cần được truyền đạt tới một hoặc nhiều đối tượng khác.

