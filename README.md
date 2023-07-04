# Part2

## Overview

Part3 is a Windows Presentation Foundation (WPF) Console App built on the .NET framework 4.8.
The Recipe Application is a user-friendly tool that allows a user to create and manage recipes.
With this application, you can easily enter the details of your recipe, including the ingredients and steps involved. 
The Recipe Application application was developed as a project for the PROGRAMMING 2A course POE Submission and serves 
as a tool to facilitate the learning of cooking techniques. 

## Installation
The application is a Console App operating on .NET framework 4.8 and this can 
run on Visual Studio 2019, Visual Studio 2022 and the Microsoft .NET Framework 4.8.

To install the application, follow these steps:

1. Download the ZIP file from the project repository.
2. Unzip the file to a directory of your choice.
3. Open the "Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.sln" file with VisualStudio.
4. Build the solution by pressing F6 or selecting "Build Solution" from the "Build" menu.
5. Run the application by pressing F5 or selecting "Start Debugging" from the "Debug" menu.

## Usage

To use the application, follow these steps:

1. Launch the application by following the installation instructions above.
2. Click "Create Recipe" from the user menu to create a recipe.
3. Enter the name of recipe you would like to capture for a recipe.
4. Enter the ingredients name, quantity and unit of measure, one at a time.
5. Enter the steps for the recipe, one at a time.
6. After entering all the recipe steps, the application will return to the user menu.
7. The useru can choose to perform other actions or exit the application.
8. user menu provides other options, such as viewing recipes, editing recipes, and deleting recipes.

## Updates 
The Recipe app has undergone several updates to enhance its functionality and user experience. Here are the key updates that have been made:

1. Unlimited Recipe Storage: The app now allows users to save an unlimited number of recipes. Users can create and store as many recipes as they desire, providing them with more flexibility in managing their recipe collection.
2. Flexible Ingredient Management: Users can now add an unlimited number of ingredients to each recipe. There are no limitations on the number of ingredients that can be included, giving users the freedom to capture all the necessary details for their recipes.
3. Ingredient Food Groupings and Calorie Count: The application now supports storing food groupings and calorie counts for each ingredient. Users can categorize ingredients into different food groups, making it easier to identify and manage recipes based on specific dietary preferences or restrictions. Additionally, the app alerts the user if a recipe exceeds 300 calories, helping them make informed choices about their meal plans.
4. Recipe Modification: Users now have the ability to make modifications to all stored recipes. They can update the recipe name, ingredients, quantities, food groupings, calorie counts, or any other details as needed. This feature allows users to refine their recipes over time and adapt them to their evolving preferences.
5. View All Option: The app includes a "Display All" option that displays all stored recipes in alphabetical order. This makes it convenient for users to browse through their recipe collection and quickly locate specific recipes based on their names.
These updates significantly enhance the versatility and usability of the Recipe app, providing users with more control over their recipe management and enabling them to create, store, and modify recipes according to their individual preferences and dietary requirements.
6. The application has been updated with a sleek and intuitive Graphical User Interface (GUI) developed using Windows Presentation Foundation (WPF)
7.  the application allows you to effortlessly filter the list of recipes by the name of an ingredient, specific food group and by a set a maximum number of calories to help you find recipes that fit the users dietary preferences.

## Review From Feedback
Feedback: After the user chose no on clear option , handle the exception. Code must not crush
Modification: To correct an issue that causes the program to crash after clearing a recipe, I have made the following improvements to the code. When the user chooses "No" on the clear prompt, an exception is appropriately handled to prevent the crash. The code now includes a menu within the method, enabling the user to select between returning to the main menu, generating a new recipe, or closing the application. The prompt is enclosed within a do-while loop to validate that the user's input falls within the menu range. A switch statement is used to call the appropriate method based on the user's selection. These modifications provide a smoother user experience and ensure the application runs smoothly.

## References
Manga, K. (2019) C#: How to change the cursorleft of the console, GeeksforGeeks. GeeksforGeeks. Available at: https://www.geeksforgeeks.org/c-sharp-how-to-change-the-cursorleft-of-the-console/ (Accessed: April 28, 2023). 
Mohanty, A. (no date) How to convert WORDS TO NUMBERS IN C#, C# Corner. C# Corner. Available at: https://www.c-sharpcorner.com/blogs/convert-words-to-numbers-in-c-sharp (Accessed: April 28, 2023). 
Tirabassi, J. (2022) Why double.tryparse("0.0000", out doublevalue) returns false ?, CopyProgramming. CopyProgramming. Available at: https://copyprogramming.com/howto/why-double-tryparse-0-0000-out-doublevalue-returns-false (Accessed: April 28, 2023). 
Troelsen, A. and Japikse, P. (2021) Pro C# 9 with . NET 5: Foundational principles and practices in programming. Berkeley, CA: Apress L. 
Wagner, B. (no date) .Net documentation, Microsoft Learn. Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/?view=netframework-4.8 (Accessed: April 28, 2023). 
OpenAI. (2021) ChatGPT (GPT-3.5). [Computer program]. Available at: https://openai.com (Accessed: April 28, 2023).
Microsoft , E.T. (2023) List.sort method (system.collections.generic), List.Sort Method (System.Collections.Generic) | Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-7.0 (Accessed: 06 June 2023). 
Microsoft , L. (2023) Keyvaluepair struct (system.collections.Generic), KeyValuePair Struct (System.Collections.Generic) | Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=net-7.0 (Accessed: 06 June 2023). 

## License
The MIT License (MIT)

Copyright (c) 2023 Hannah Michaelson

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE
