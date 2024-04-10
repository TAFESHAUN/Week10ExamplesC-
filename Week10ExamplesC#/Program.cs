// Specify the file path of the CSV file you want to read
string sampleCSV = @"C:\Users\User\source\repos\Week10ExamplesC#\Week10ExamplesC#\some-data.csv";

// Load the CSV file into a two-dimensional array
string[,] values = LoadCSV(sampleCSV);

// Determine the number of rows and columns in the CSV data
int num_rows = values.GetUpperBound(0) + 1;
int num_cols = values.GetUpperBound(1) + 1;

// Display the column headings
for (int c = 0; c < num_cols; c++)
    Console.Write(values[0, c].PadRight(15)); // Adjust the width as needed

// Read and display the data excluding the first row (headers)
for (int r = 1; r < num_rows; r++)
{
    Console.WriteLine();
    for (int c = 0; c < num_cols; c++)
    {
        Console.Write($"{values[r, c].PadRight(15)}"); // Adjust the width as needed
    }
}

// Wait for user input before closing the console window
Console.ReadLine();


// Method to load data from a CSV file into a two-dimensional array
static string[,] LoadCSV(string filename)
{
    // Read the entire content of the CSV file into a string
    string whole_file = System.IO.File.ReadAllText(filename);

    // Replace newline characters with carriage return characters for consistency
    whole_file = whole_file.Replace('\n', '\r');

    // Split the file content into an array of lines
    string[] lines = whole_file.Split(new char[] { '\r' },
        StringSplitOptions.RemoveEmptyEntries);

    // Determine the number of rows and columns in the CSV data
    int num_rows = lines.Length;
    int num_cols = lines[0].Split(',').Length;

    // Allocate memory for the two-dimensional array to store the CSV data
    string[,] values = new string[num_rows, num_cols];

    // Parse each line of the CSV file and store its values in the array
    for (int r = 0; r < num_rows; r++)
    {
        string[] line_r = lines[r].Split(',');
        for (int c = 0; c < num_cols; c++)
        {
            // Store each value in the appropriate cell of the array
            values[r, c] = line_r[c];
        }
    }

    // Return the two-dimensional array containing the CSV data
    return values;
}