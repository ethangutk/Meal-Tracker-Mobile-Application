# 🍽 Meal Tracker Mobile Application
## 🎓 About The Class
#### CSE382 - Mobile Application Development
This course is offered rarely at Miami University, so I immediately signed up for it when I found out they were delivering it in the Summer of 2021. The class dove straight into topics as it was a pretty intense course being only six weeks long. We had five projects, a final project, ‘exam-like weekly quizzes, and assignments accompanying our lecture videos. The class was delightful due to its organization. 


<br><br>
## 🌮 About The Program
I created this program as my final project for this class. I was between a couple of ideas since we got the freedom to choose, but I decided to use a meal tracker. I picked this idea for the sole reason of wanting to experiment with APIs. I thought the concept of a meal tracker gave me a lot of opportunities to find different APIs about food online. I ended up paying to use two other APIs from the same website, called [spoonacular](https://spoonacular.com/food-api). I used one to [search up menu items](https://spoonacular.com/food-api/docs#Search-Menu-Items), and based on the results of the other API, I would get the nutrition facts using [another API](https://spoonacular.com/food-api/docs#Get-Menu-Item-Information). The program taught me a lot about this side of computer science. Along with the APIs, there were also some other features within the application. Additional project requirements included web services, user preferences, MVVM architecture, local databases, multipage, listviews, and images. The program was 22% of my final grade. I got a 94% on it, with some points deducted due to the midpoint demonstration.
<br><br>
## 🥞 Note
If you download this and run this program in Visual Studio, you might have to do a couple of things to run for an android simulation and UWP. First, you have to download the workload that uses Xamarin for cross-platform mobile application development. You can do this by going to <br>

<p align="center">
  <b>Tools > Get Tools and Features > Download Mobile Development with .NET</b><br><br>
  <img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Setup_1.png?raw=true">
</p>
<br>

This should allow you to run it within UWP and potentially an android simulation. If you are still having problems with running the android simulation, check out 
[this article](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/hardware-acceleration?tabs=vswin&pivots=windows) and it will most likely fix the problem. However, if it doesn’t fix it, you can honestly email me, and I can help you out and most likely update this document with more solutions.

<br><br><br>
## 🍕 The *Tasty* Features
### 🥗 Application Programing Interfaces (APIs)

**APIs Used:**
- [Search Up Menu Item](https://spoonacular.com/food-api/docs#Search-Menu-Items)
- [Get Specific Item Information](https://spoonacular.com/food-api/docs#Get-Menu-Item-Information)

The best part about this program, without a doubt. I found this elegant API to use online revolving all-around food. The two in particular that I used were dependent on one another within my program. What I mean by this is that you couldn’t query the second API without the results from the first API. It made testing a little bit more tedious and challenging, but it worked out great in the end. The first API takes a series of food/meal keywords and lists results closest to the keywords. So if I searched up “Taco Bell,” it would bring back the top ten menu items from Taco Bell. 

<br>

<p align="center">
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/API_1.png?raw=true" width=275px>
</p>

<br>

Since this API only gave us the menu item, image, name, and restaurant, I had to take the food ID and query a second API and query that using the food from the first. A little meta and complicated at the start but very elegant when you draw it out on paper! The second API would bring back all of the nutrition facts that the GUI will show. After this, we now have all of the information needed to add to our local database/the user’s food diary.

<br>

<p align="center">
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/API_2.png?raw=true"  width=275px>
</p>

<br>

After this, we now have all of the information needed to add the entry to our local database/the user’s food diary. As you can see, the user can choose what meal they want to add it to and the date. That would get transferred to the Diary page and updated as needed.

**Spoonacular API Dashboard:**

<p align="center">
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/API_3.png?raw=true">
</p>

<br><br>
### 🍔 Favorite Food User Preferences
User preferences are a simple way to store values locally on a user’s device. It’s not for significant data for the application, just more minor stuff. For the sake of my project, I have the calorie goal for the user set as a preference. If the application is deleted off of the device, redownloading it would reset the preference.

<br>

<p align="center">
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Preferences_1.png?raw=true">
</p>

<br>

<br><br>
### 🌭 Model-View View-Model (MVVM) Architecture

<p align="center">
View  ↔  Controller  ↔  Model
</p>

A complex concept to learn within mobile applications. You have three different components within this concept that talk to each other. First, our application uses a slider on the summary page to update the calories on the screen. Instead of making an on update function, which we could have quickly done, the slider is tied directly to everything that needs to be updated on-screen. Third, it makes the phone use less power since it is more efficient and more streamlined.

<br><br>
### 🥪 Databases
For this application, I used Visual Studio’s NuGet package search feature to find the SQLite-net-PCL package. This package simulates any ordinary database that you would see in an application. However, unlike preferences, this is where we can store more significant amounts of data within our application. We used this application to keep the food entities in a giant schema that the application referenced when loading the Diary page. The package saved all of the data locally to the device. The table below is a great visual of what the schema looks like within the application.


| id | Date | Meal | Name | Calories | Fat | Protein | Carbs
| :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: 
| PRIMARY KEY int | DateTime | string | string | double | double | double | double 

 
<br><br>
### 🍟 Multipage Application
Pretty self-explanatory, the idea that your application has navigation between multiple pages. My application is tabbed. You can navigate between various pages by using the buttons located at the top or bottom of your screen. The example below demonstrates only two tabs, Diary and Track.

<br>

<p align="center">
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Tabbed_1.png?raw=true">
</p>

<br>

Another navigation feature used is stacked navigation. Furthermore, when you search for a meal, a page will push on top of the stack. You cannot return to the original tabbed navigation until the user pops all the pages within the stack navigation.

<br><br>
### 🌯 List Views
List views appear throughout the program. List views show the diary contents, including all of the macronutrients and the food name. The list view for the search results creates a set of buttons. The user can click on them and get the additional macros for the food. 

<br>

<p align="center">
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/ListView_1.png?raw=true" width=275px> 
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/ListView_2.png?raw=true" width=275px>
</p>

<br><br>


<br><br><br><br>

- - - -

<br>

<p align="center">
  ...🥁now let's put all of the slices🍰 together...drumroll please🥁...
</p>

<br>

- - - -


<br><br><br><br>

## 🎂 The *Delicious* Final Product

<p align="center">
  <img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Final_1.png?raw=true" width=275px>
  <img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Final_2.png?raw=true" width=275px>
  <img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Final_3.png?raw=true" width=275px>
</p>
<br>
<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Final_4.png?raw=true">

<br>

<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Final_5.png?raw=true">

<br>

<img src="https://github.com/ethangutknecht/Meal-Tracker-Mobile-Application/blob/main/Images/Final_6.png?raw=true">



<br><br><br>

- - - -

<p align="center">
  Copyright © Ethan Gutknecht 2021
</p>
