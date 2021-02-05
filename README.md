# C# Masterclass
I am hosting the code from this course to act as a reference and to share what I've accomplished. All code is written by my hand following the course, and most comments are my personal annotations to help explain what is going on.

In general, I structured my code around having a class per section, and if multiple classes were needed I stored the files together in a folder. The class-per-section format brok down sometimes, particularly with sections using WPF, in which case I would create a new project within the solution. 

### Running the Code
All of the code is meant to be run from Visual Studio. Each section's class is meant to be executed standalone, usually with a static `Run()` method or method named after the specific lesson. For console applications, I would hook up the lesson I want to run in the `Main()` function in `Program.cs` in the Hello World project. For running the WPF projects, each one can simply be executed independently.

### Notable Sections
Most of this course was covering the basic use of most C# constructs. There are a few notable parts of the course that were more involved projects that involved creative use of the concepts taught in the course. The first one is in [Section 7](Hello%20World/Section%207), where I was tasked with writing a complete TicTacToe game for the command line interface. This was one of the first projects that really stretched me, and I intentionally tried to code the game in a way that was different from what the instructor taught.

The second is the [WPF ZooManager](WPF%20ZooManager) project. This part of the course involved making a small but complete WPF application that would allow the user to edit data contained the a Microsoft SQL server. This was my first time making a complete graphical application from scratch and is my favorite project of the entire course (so far).

### Course Topics
The following is a list of the course's topics, and the ones I have completed are checked.
- [ ] test
