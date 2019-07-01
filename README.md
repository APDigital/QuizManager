# QuizManager
this is my project repository for my final project piece. 
Project Overview and Objectives 

## Overview
You work for WebbiSkools Ltd, a software company that provides on-line educational solutions for education establishments and training providers. Your manager would like you to design, build, and test a database-driven website to manage quizzes, each consisting of a set of multiple-choice questions and their associated answers. The website’s capabilities will only be accessible to known users. Users with full permissions will be able to view and edit the questions and answers; users with lesser permissions will be able to view them but not edit them; users with minimal permissions will only be able to see the questions. 

### You will need to: 
1. Review all the key information and create a design for the quiz manager
2. Construct the quiz manager in accordance with the design
3. Test that the quiz manager meets its requirements
4. Document what you built. 

## Background Information & Business Requirements 
The following additional information has been provided to help you with the completion of the project. 
### Background information 
- WebbiSkools Ltd provides on-line educational solutions to commercial and government clients, such as universities and training departments of large industrial companies. 
- This database-driven website enables the creation and management of quizzes consisting of multiple-choice questions. 
- The website should be designed and built to production standards and should adhere as far as possible to industry best practices. 
- The website should be designed to be straightforward to re-brand, by encapsulating the definition of colour schemes, styles, company logos and so on. 
- Any suitable technology stack with which you are familiar may be used to construct the website. 
- For this version of the website the set of known users with their passwords and permissions will be pre-configured; the website does not need to provide capabilities for user registration, password reset, or change of permission.
- Related but separate websites will be used to allow students to take quizzes, and will manage their marks and grades. You are not required to consider these. 
- You may want to get a simplified viewing-only version of the website working first before moving onto the editing version. 

## Business requirements 
### Users and permissions 
- The set of users with their usernames, passwords and permissions should be pre- configured. This may be done by manually inputting data into the database, through a separate user-config file (e.g. an XML, JSON or CSV file), or any other mechanism of your choice. 
- Stored passwords should be hashed for security, using a suitable hash algorithm. 
- Permission levels should be one of {Edit, View, Restricted}, where Edit means the ability to add, delete and change questions and answers, View means the ability to view questions and answers, and Restricted means the ability to view questions only. 
- Only known users can login to the website. Once logged in, a user can only carry out the actions allowed by their permission level. 
- The website will need to maintain user session state while the user is logged in. 
- You may assume that the number of users with edit permissions is small, and the probability of more than one user attempting to edit a quiz simultaneously is negligible. 
- A user can logout, which will take them back to the login page. 
Quizzes 
- A quiz has a title and a numbered sequence of questions. 
- Each question is formulated as a text string, e.g. “What is the approximate population of London?” 
- Each question is associated with a set of between 3 and 5 answers. Each answer is a text string, shown in the user interface indexed by an uppercase character (‘A’, ‘B’, ‘C’ etc). For example, the answers to the above question might appear like this: 
  - A. “250 thousand” 
  - B. “1 million” 
  - C. “9 million” 
  - D. “78 million” 
### Viewing and Editing 
- A user with Restricted permission can select a quiz from all available quizzes. Having selected the quiz, all the questions in that quiz can be viewed on the screen. If the quiz is too large to fit, the user should be able to scroll up and down to see it. 
- A user with View permission can select and view a quiz as above. They can also select a question to see the associated answers. 
- A user with Edit permission can select a quiz and view questions and answers as above. They can also make and save all the following changes: 
  - Create new quizzes and delete existing ones 
  - Add and delete questions at any point in the numerical sequence of a quiz 
(which may cause the questions to be re-numbered)
  - Edit the text of any questions
  - Add and delete answers to any question (which may cause the answers to be 
re-indexed)
  - Edit the text of any answer. 
