using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JavaGrammarChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The missing Form1_Load event handler
        private void Form1_Load(object sender, EventArgs e)
        {
            // This method runs when the form is loaded
        }

        // Button click handler to validate the input
        private void validateButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;

            // Call the validation function
            if (IsValidJavaConstruct(input))
            {
                resultLabel.Text = "Valid Java construct!";
                resultLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                resultLabel.Text = "Invalid Java construct.";
                resultLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Method to validate Java-like constructs using regular expressions
        private bool IsValidJavaConstruct(string input)
        {
            // Define basic patterns for Java constructs

            // Pattern for variable declarations like 'int x = 5;'
            string variableDeclarationPattern = @"^\s*(int|float|double|String)\s+\w+\s*=\s*.+;\s*$";

            // Pattern for method declarations like 'public void methodName() { }'
            string methodDeclarationPattern = @"^\s*public\s+void\s+\w+\s*\(\)\s*\{\s*\}\s*$";

            // Pattern for if-else statements like 'if (x > 0) { } else { }'
            string ifElsePattern = @"^\s*if\s*\(.+\)\s*\{\s*\}\s*(else\s*\{\s*\})?\s*$";

            // Check if input matches any of the patterns
            return Regex.IsMatch(input, variableDeclarationPattern) ||
                   Regex.IsMatch(input, methodDeclarationPattern) ||
                   Regex.IsMatch(input, ifElsePattern);
        }
    }
}
