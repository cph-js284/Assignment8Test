# Assignment8Test
This is the 8th assignment for PBA Test soft2019spring

# What is it
This is a C#-MVC project running in a docker container. The webhost connects to another container runnning mongo for persistance.

-----------------------------------------------------------------------
# Setup
1) Clone the repo
2) Build the docker file by executing
```
sudo docker build -t marioapp .
```
3) Start up a container running MongoDb by executing
```
sudo docker run -d --rm -p 27017:27017 --name dbms mongo
```
4) start up the marioapp container and link it to the dbms container by executing
```
sudo docker run -d --rm -p 8080:80 --link dbms:mongo marioapp
```
This takes care of the setup, now you can open a browser and hit http://localhost:8080 and you will see the webinterface for Marios pizza

5) Setup the Selenium tests by following the instructions here [Setup Selenium tests](https://github.com/cph-js284/Assignment8TestSeleniumTests/blob/master/README.md)
