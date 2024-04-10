using CSVObjList;
using System;

List <Person> personList;
Person tempPerson; //Temps here good be improved

personList = new List<Person>();

// Get the data from path.
string sampleCSV = @"C:\Users\User\source\repos\Week10ExamplesC#\CSVObjList\some-data.csv";

string[,] values = LoadCSV(sampleCSV);
int num_rows = values.GetUpperBound(0) + 1;

//Read the data and add to List 
for (int r = 1; r < num_rows; r++)
{
    //name age mail company
    tempPerson = new Person(int.Parse(values[r, 0]), values[r, 1], values[r, 2], int.Parse(values[r, 3]), int.Parse(values[r, 4]));
    personList.Add(tempPerson);//Temp object could just be a new object instance call in .Add
}

//read data from list
foreach (var personRead in personList)
{
    if (personRead.BirthYear >= 2000)// && personRead.Gender == "Female" )
    {
        Console.WriteLine("Born After the 90s: " + personRead.ID + "\t" + personRead.Name + "\t" + personRead.Gender + "\t" + personRead.BirthYear + "\t" + personRead.Age + "\t");
        //Save function here to save all people born in the 2000's
        //LETS THINK PROJECT -> Calculate with tax or no tax threshold, Employee OR Managers 
    }
    else if(personRead.BirthYear < 2000)// && personRead.Gender == "Male")
    {
        Console.WriteLine("Born before 2000's: " + personRead.ID + "\t" + personRead.Name + "\t" + personRead.Gender + "\t" + personRead.BirthYear + "\t" + personRead.Age + "\t");
    }
}

Console.WriteLine($"THE FIRST PERSON IN THE LIST IS {personList[0].Name}");
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