# Address Book

Address Book is a simple yet practical contact keeper for your everyday organization. Address Book enables easy contact storing, retrieving and general management.

## Getting Started

### Requirements
* Visual Studio 2019
* .NET Framework 4.7.2
* C# 6.0+
* MS SQL Server 2017 Express

### Installation

To get started, simply clone or download the application and Build the Solution.

To create the required database simply execute the update-database command on Package Manager Console once the solution builds successfully.

```bash
update-database
```
**The solution will target your local SQL Express server by default.**

Should you want to change the connection string you can modify it on the Web.Config file.

## Usage

Since your contact list would be empty, you can start by adding a new contact by clicking on the **Add New** as prompted.

**First Name, Last Name** and a **valid Email address** are required fields.

Upon adding your new contact you will be directed back to the same Contact List where you can **Edit**, **Delete** or modify the **Phonebook** of your contact.

## Features
* Search by Name - Get contacts whose names or surnames contain your desired word.
* Paging - Contacts are grouped in pages of 10 contacts to reduce clutter.
* Address and Phonebook - Associate your contacts with a physical address and **ALL** their phones. _(Phones need to be 10-digit long!)_

## Built With
* [Entity Framework](https://docs.microsoft.com/en-us/ef/#pivot=entityfmwk&panel=entityfmwk1) - As the object-relational mapping (ORM) framework
* [PagedList.MVC](https://github.com/troygoode/PagedList) - For conctact list paging
* [Bootstrap](https://getbootstrap.com/) - General styling


## License
[MIT](https://choosealicense.com/licenses/mit/)
