# user_stories.md

User stories derived from the [backend Wiki](https://github.com/code4romania/teacher-workout-backend/wiki).

- [user_stories.md](#user_storiesmd)
  - [Tags for platform targeting](#tags-for-platform-targeting)
    - [User story template](#user-story-template)
  - [User types](#user-types)
    - [Visitor](#visitor)
    - [Logged-in User](#logged-in-user)
    - [Administrator](#administrator)
  - [Teacher Workout Mobile flow](#teacher-workout-mobile-flow)
      - [Account creation](#account-creation)
      - [Lesson Flow](#lesson-flow)
      - [User Profile Flow](#user-profile-flow)
      - [General Purpose Flow](#general-purpose-flow)
  - [Accessiblity](#accessiblity)

## Tags for platform targeting

- [A] - All application platforms user story
- [W] - Web application platform user story
- [M] - Mobile application platforms user story
- [?] - Unclear

### User story template

[Wikipedia link on user stories](https://en.wikipedia.org/wiki/User_story)

`As a <role> I can <capability>, so that <receive benefit>`

`In order to <receive benefit> as a <role>, I can <goal/desire>`

`As <who> <when> <where>, I <want> because <why>`

## [User types](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-user-types)

### [Visitor](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-user-types#visitor-anyone-who-is-not-logged-in-neither-in-the-mobile-app-nor-the-web-client)

Anyone who is not logged in, neither in the mobile app, nor the web client.

- [W] As any kind of user, I can take lessons published on the public-facing web app.
- [M] As a visitor, I need to login/create an account to proceed using the [authentification screen](https://drive.google.com/file/d/12NcJA1TtyGyaB3h-8toVoYUJGhJa-k6M/view?usp=sharing).
- [A] As a visitor, I can create an account using:
  - my e-mail address and a password - an e-mail is sent to the address in order to confirm the account
  - Google OAuth 2.0 flow
  - Facebook OAuth
  - Apple ID

### [Logged-in User](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-user-types#logged-in-user)

- [A] As a logged-in user:
  - I can take the lessons published on the public-facing web or the mobile app.
  - I can receive experience points after completing in-app lessons.
  - I can set preferences for which subjects they are interested in.
  - I can receive suggestions of new lessons to take in the mobile app.
  - I can receive notifications (and can mute their notifications).

### [Administrator](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-user-types#administrator)

- [W] As an Administrator user: 
  - I can log into the administration dashboard in the web app.
  - I can add / edit / delete other admins.
  - I can add / edit / delete content creators.
  - I can add / edit / delete lesson themes / domains.
  - I can add / edit / delete lessons.
  - I can see reports about how many users have finished a certain lesson, how many lessons have been attempted from a domain etc.

## [Teacher Workout Mobile flow](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-Mobile-flow)

#### [Account creation](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-Mobile-flow#account-creation)

- [M] As a logged-in user:
  - I need to fully finish an Onboarding process through several screens to be allowed to access the other parts of the app.
  - I am taken to a [First time user - home screen](https://drive.google.com/file/d/1PGH4w2ilLl8RpuEG6wmdWkcOONiKOEiW/view) following the Onbarding process.
  - I will only see the First time user - home screen once, subsequent logins will take me to my Home screen.

#### [Lesson Flow](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-Mobile-flow#lesson-flow)

[Figma doc](https://www.figma.com/file/uLiqrlxmOB5xCppIzmiUXV/Teacher-Workout?node-id=0%3A1)

- [A] As any kind of user:
  - I can press `Începe lecția` to go to the next screen.
  - I can press `Salvează lecția` to go o the previous screen, pressing this button adds the lesson to the `Lecții în curs` to my `Home Screen`.
  - I can press a buttons to go forward (near the bottom) or a go back (at the top) to navigate through quizz screens.
  - I get feedback for the corectness of the answers via highlighting of the correct answer and aditionally of the wrong answer if applicable, getting the answers wrong does not influence how may points I get at the end.
  - I get some Experience Points at the end of the lesson, hitting the `Continuă` button takes me back to the lessons listing screen where the lesson is now marked as complete.

#### [User Profile Flow](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-Mobile-flow#user-profile-flow)

[This is the Figma flow for the user profile](https://drive.google.com/file/d/1AHyMTegyK7OUv2vTTqm4MV-OTCqvSfp-/view?usp=sharing).

Open the [Figma doc](https://www.figma.com/file/uLiqrlxmOB5xCppIzmiUXV/Teacher-Workout?node-id=0%3A1) in order to follow along.

- [A] As any kind of user:
  - I can enter my profile by clicking the general purpose `Profil` button in the footer of the app.
  - I can see my avatar along with the total number of Experience Points I have achieved at the top of the profile.
  - I can access the `Rezultate` section of my profile which lists all the lesson categories, along with the progress I have achieved in each, the progress is marked as `lessons completed / total number of lessons in the category`.
  - I can access the `Setări` section of my profile which allows me to:
    - change my avatar
    - change my password
    - change the notification settings
    - log out
    - delete my account

#### [General Purpose Flow](https://github.com/code4romania/teacher-workout-backend/wiki/Teacher-Workout-Mobile-flow#user-profile-flow)

- [A] As any kind of user I can use the 3 general purpose buttons in the footer of every screen:
  - the `Descoperă` button takes me to the [First time user - home screen](https://drive.google.com/file/d/1PGH4w2ilLl8RpuEG6wmdWkcOONiKOEiW/view?usp=sharing)
  - the `Acasă` button takes me to the [Home screen](https://drive.google.com/file/d/1iYjJb4Co_SP2ytNTEwfdYRMvHgDA-Sij/view?usp=sharing)
  - the `Profil` button takes me to the [](https://drive.google.com/file/d/1TLjeEvnWmA6HCFjixDJ5BbV6WJ4mkp77/view?usp=sharing)

## Accessiblity 

TODO: Derive/modify user stories based on the [EU Web accessibility policy](https://europa.eu/european-union/abouteuropa/accessibility_en).
