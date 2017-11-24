# indexmyphotos
assigns tags, dates and location data to photos.

## Getting started

Just Drag and Drop your image file into the program. It will create a local copy in the program files folder and manage any files completely self-sufficient within a database.

![Screenshot](https://github.com/henkwh/indexmyphotos/blob/master/PhotoManager/PhotoManager/Resources/demo1.png?raw=true)

## Motivation

My search for any offline-service that is capable of managing my photos and showing their location on a map was badly disappointing.
And because I've got tons of Fotos from family, travels, sport, etc. by now, a program to manage my fotos was very needful.

## Synopsis

The Visual Studio Project "Index my Photos" offers a functionality to assign tags, dates, descriptions and location data to Image files (.png, .jpg files at the moment).<br/>
The program runs in a Windows Form and uses the GMap API and SQLite.<br/>
The GUI consists of several tabs.<br/>
The main tab shows a scrollable List of the fotos. The search bar can be used to filter fotos by tag (including, excluding arguments), date and location.
The GMap tab uses a GMap to mark (selected) Fotos on a worldmap (flagged with a tiny preview of the foto).
The tab to edit tags has textfields to set the location (as Coordinates lat/lng), the date (day, month, year), tags and a description. You can also select the location from the map.
A new file can be load to the program by dragging them onto the Form. Two local copies are created. The first 1:1-copy in the "full" folder is done because the program manages itself. Theres also a smaller, comprimated preview of the foto in the "preview" folder. The filename is changed to a Globally Unique Identifier.
By adding a new foto to the program, an entry in the local database "Database.mdf" is created. Every entry's ID is a Globally Unique Identifier.<br/>
Database: Table Foto: GUID (filename), filetype, loclat, loclng, date, description

## Demo

![Screenshot](https://github.com/henkwh/indexmyphotos/blob/master/PhotoManager/PhotoManager/Resources/demo2.png?raw=true)
![Screenshot](https://github.com/henkwh/indexmyphotos/blob/master/PhotoManager/PhotoManager/Resources/demo3.png?raw=true)

## Prerequisites

Software required:
- Microsoft Windows envionment
- MS Visual Studio
- <del>MS SQL Server</del> (embedded SQLite database in use)

Create Database "Database.mdf" in Project Folder

## Installation Issues

SQl Server not found (Outdated, embedded SQLite in use):<br/>
Change version number in Database connection string or create an instance of LocalDB to match the version number:
```
SqlLocalDB create "v13.0" -s
```

## Authors

Henk Haala (https://github.com/henkwh)

## License

This project is licensed under the MIT License - see the LICENSE.md file for details
