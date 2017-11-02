# indexmyphotos
assigns tags, dates and location data to photos.

## Motivation

My search for any offline-service that is capable of managing my photos and showing their location on a map was badly disappointing.
And because I have got a lot of Fotos from family, travels, sport, etc by now, a program to manage my fotos was very needful.

## Synopsis

The Visual Studio Project "Index my Photos" offers a functionality to assign tags, dates, descriptions and location data to Image files (.png, .jpg files at the moment).
The program runs in a Windows Form and uses the GMap API and SQLite.
The GUI consists of several tabs.
The main tab shows a scrollable List of the fotos. The search bar can be used to filter fotos by tag (including, excluding arguments), date and location.
The GMap tab uses a GMap to mark (selected) Fotos on a worldmap (flagged with a tiny preview of the foto).
The tab to edit tags has textfields to set the location (as Coordinates lat/lng), the date (day, month, year), tags and a description. You can also select the location from the map.
A new file can be load to the program by dragging them onto the Form. Two local copies are created. The first 1:1-copy in the "full" folder is done because the program manages itself. Theres also a smaller, comprimated preview of the foto in the "preview" folder. The filename is changed to a Globally Unique Identifier.
By adding a new foto to the program, an entry in the local database "Database.mdf" is created. Every entry's ID is a Globally Unique Identifier.
Database: GUID (filename), filetype, location, date, tags, description

## Prerequisites

Software required:
- Microsoft Windows envionment
- MS Visual Studio
- MS SQL Server

## Installation Issues

-SQl Server not found:
Change version number in Database connection string or create an instance of LocalDB to match the version number:
SqlLocalDB create "v13.0" -s
## API Reference

Depending on the size of the project, if it is small and simple enough the reference docs can be added to the README. For medium size to larger projects it is important to at least provide a link to where the API reference docs live.

## Authors

Henk Haala (https://github.com/henkwh)

## License

This project is licensed under the MIT License - see the LICENSE.md file for details
