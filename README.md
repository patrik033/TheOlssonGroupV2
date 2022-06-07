# TheOlssonGroup
The purpose of this project was to make an easy implementation of a movie shop.

## Description
TheOlssonGroup is a simple but still fully functional movie shop built with a wasm hosted approach(frontend in blazor and backend with an api).
Our website was a school project that we wanted to do a bit different because it was both fun and we wanted to test some things.
The site itself is fully functional with a local storage(all your orders will be saved in your browsers cache), checkout functionality and payment system built with stripe and email capabilities.

## Getting Started
Everything is included in the project to get going, please bear in mind that the project database is in the cloud se dont make any database updates with entity framework. If you want to test it please make a local database instead. 

#### Local Database
If you want to do it with this approach in mind, please change CreateDbContext(under Tthe server project and int the contextfactory class) to your localdb name.
Also make sure to change the serviceextensions(under the server project) and the ConfigureSqlContextOlsson metod with the correct localdb name.


### Azure Database
As default the application is hosted at a azure appservice and database and every user is created with admin permission.
</br>Here's the address for the app: &nbsp;&nbsp; [The Olsson Group](https://theolssongroup.azurewebsites.net/)

## How to use stripe checkout

The website is setup with stripe as the payment provied, but no money will be charged since the payment system is only in test.

### How to checkout

* For payment success:  4242 4242 4242 4242
* For cards with unnificent founds: 4000 0000 0000 9995
* For declined payment: 4000 0000 0000 0002

 
 For date use a valid future date such as 12/34
 And csv code 3 digits such as 123 &nbsp; (4 digits for american express cards)
<br/><br/>For more information how to use stripe, please use:  &nbsp; [Stripe testing documentation](https://stripe.com/docs/testing?numbers-or-method-or-token=card-numbers#use-test-cards)
 
 ## Email Service
 
 We have provided email capabilities in this project so if you want to be sure to be able to receive an email, please provide a valid one if you want to be able to receive a confirmation email.
 
 
