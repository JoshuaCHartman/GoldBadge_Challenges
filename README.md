# GoldBadge_Challenges
Gold Badge Challenges: 1, 2, 3


<!-- PROJECT LOGO -->
<br />
<p align="center">

  <h3 align="center">Gold Badge Challenges</h3>

  <p align="center">
    Joshua Hartman // SD71B // 1150 Academy
    <br />
   
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#Personal-Takeaways-and-Plans-for-Future-Learning-and-Practice">Takeaways and Development</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
    <li><a href="#license">License</a></li>
    
  </ol>
</details>


<!-- ABOUT THE PROJECT -->
## About The Project


Included in this repository are the first three Gold Badge Challenges. In addition to the top level priority of completing the required tasks and gaining a deeper understanding of C# and .NET fundamentals, I chose to focus on handling of null exceptions (i.e., making an application resistant to the user "breaking" the application through their input). I believe all three challenges successfully demonstrate this input handling.

### Built With

* C# and .NET framework


<!-- GETTING STARTED -->
## Getting Started

Each challenge is composed of three directories using the same naming convention: ChallengeX_Library, ChallengeX_Tests, and ChallengeX_Console. All directory contents follow the same naming convention as their parent directory. The overall **SOLUTION FILE** is GoldBadgeChallenges_Hartman.sln.

### Installation

 Clone the repository
   ```sh
   git clone https://https://github.com/JoshuaCHartman/GoldBadge_Challenges
   ```

<!-- USAGE EXAMPLES -->
## Usage

* Challenge 1 focuses on a hypothetical cafeteria menu, and the needs of a manager to edit the menu and its constituent meals. Editing functions involved full CRUD functions in the repository, and a MenuItem class with properties that include, amongst others, a uniqe ID number ("Meal Number") and a list of strings for ingredients. I created functionality that would prevent a user from inputting a new meal using an existing meal's ID number. I also ensured that all input would conform to the desired input type by using a series of loops and checks before converting the input and assigning to the appropriate properties. In the takeaways section, I discuss how I now recognize the need to refactor these checks and other operations into reusable helper methods.

* Challenge 2 is centered on the use of a task management system based on a queue of tasks ("claims" in the project) to be completed. Required functionality included displaying the next task to be completed using the FIFO (first-in first-out) rules of a queue. "Peek" was to view the claim, and "Dequeue" was used to remove the claim from the queue. Additionally, the data needed to be displayed in a clear and consistent manner. To accomplish this, I built the application so all data (including the isolated next task to complete) ise displayed using a data table, and the console size is set upon running so data will be properly displayed. I reused many of the user input checks from Challenge 1, which reinforced the need to build these operations as methods. 

* Challenge 3 is an employee security/access control application using a dictionary. Badge objects are created with a unique ID number and a list of doors as properties. The badge objects are dictionary values, and integers identical to the ID numbers are used as the dictionary keys. This allows the manipulation of badge properties after finding them by use of the key. The most efficient solution I found to this problem (cited in my Acknowledgements below as the Dictionary Flowchart) was using [ unique key input ] to return a corresponding value. An example of that usage is included below.
    ```sh 
      var nameOfObject = nameOfDictionary[key] 
    ``` 
    This allowed the manipulation of the list of doors by simpling using the built-in list operations (example: myList.Add(), myList.Remove(), myList.Clear()). Again, it became clear that many input checking and, in this case, searching functions could be refactored into standalone methods.


<!-- Future Developments / Takeaways -->
## Personal Takeaways and Plans for Future Learning and Practice

* My personal greatest takeway is to focus on isolating sections of code into reusable methods. After reviewing the logic for handling user input, I realized that many of the tasks are repetitive. In the future, I will refactor the input check processes (for example, ensuring user input is an integer, not zero, or not duplicated) into separate helper methods. I will also do this with operations involving, amongst other things, DateTime. This will also assist with ease of unit testing. This should help with adherence to DRY principles and overall more capable and more readable code.

* Included in the code for the challenges are a handful of commented out lines that include alternate techniques to achieve the same or similar end results. These were left with notes for future exploration. For example, alternate ways of displaying output text with "String.Join" versus "\t" formatting, and a method of counting and finding items using LINQ. These are techniques I would like to employ in the future after investigating their function within the completed challenges.

* To that end, I considered the completed challenges to be a reference for future projects. I wanted to ensure the projects were as complete and as polished as I was able to make them.

* I will continue to compile my own collection of learning and reference materials. While Intellisense suggestions are extremely helpful, I found flow charts and exposition to be better suited to my learning style.



<!-- CONTACT -->
## Contact

Joshua Hartman - [JoshuaCHartman@gmail.com] 

Project Link: [https://github.com/JoshuaCHartman/GoldBadge_Challenges](https://github.com/JoshuaCHartman/GoldBadge_Challengese)


<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [Tutorials Teacher Dictionary Entry w/ Flowchart](https://www.tutorialsteacher.com/csharp/csharp-dictionary)
* [Geeks for Geeks Queue .Peek method article](https://www.geeksforgeeks.org/c-sharp-get-the-object-at-the-beginning-of-the-queue-peek-operation/)
* [MS documenation on Enumerable Classes (LINQ)](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-5.0)
* [The Developer Blog on TryGetValue Method](https://thedeveloperblog.com/trygetvalue)
* [w3resource on using short time for DateTime](https://www.w3resource.com/csharp-exercises/datetime/csharp-datetime-exercise-35.php)
* [Geeks For Geeks on Changing WindowWidth of console](https://www.geeksforgeeks.org/c-sharp-how-to-change-the-windowwidth-of-the-console/)
* [A Basic Introduction To C# Unit Test For Beginners](https://www.c-sharpcorner.com/article/a-basic-introduction-of-unit-test-for-beginners/)




<!-- LICENSE -->
## License

README .md format distributed under the MIT License. See `LICENSE` for more information.
