using CSVObjList;

List <Person> list;
Person person;

list = new List<Person>();

// Get the data from path.
string sampleCSV = @"C:\Users\User\source\repos\Week10ExamplesC#\CSVObjList\some-data.csv";

string[,] values = LoadCSV(sampleCSV);
int num_rows = values.GetUpperBound(0) + 1;

//Read the data and add to List 
for (int r = 1; r < num_rows; r++)
{
    //name age mail company
    person = new Person(int.Parse(values[r, 0]), values[r, 1], values[r, 2], int.Parse(values[r, 3]), int.Parse(values[r, 4]));
    list.Add(person);
}

//read data from list
foreach (var item in list)
{
    if (item.Birthday == 2000)
    {
        Console.WriteLine("FOUND: " + item.ID + "\t" + item.Name + "\t" + item.Gender + "\t" + item.Birthday + "\t" + item.Age + "\t");
        //Save function here to save all people born in the 2000's
        //LETS THINK PROJECT -> Calculate with tax or no tax threshold, Employee OR Managers 
    }
}
Console.ReadLine();



static string[,] LoadCSV(string filename)
{
    // Get the file's text.
    string whole_file = System.IO.File.ReadAllText(filename);

    // Split into lines.
    whole_file = whole_file.Replace('\n', '\r');
    string[] lines = whole_file.Split(new char[] { '\r' },
        StringSplitOptions.RemoveEmptyEntries);

    // See how many rows and columns there are.
    int num_rows = lines.Length;
    int num_cols = lines[0].Split(',').Length;

    // Allocate the data array.
    string[,] values = new string[num_rows, num_cols];

    // Load the array.
    for (int r = 0; r < num_rows; r++)
    {
        string[] line_r = lines[r].Split(',');
        for (int c = 0; c < num_cols; c++)
        {
            values[r, c] = line_r[c];
        }
    }

    // Return the values.
    return values;
}