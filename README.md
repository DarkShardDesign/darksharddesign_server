# darksharddesign_server
The backend server for DarkShard Design front end site

# basic scripts
```yarn build```
will build for production to the dist folder, do this before trying to create the docker image

```yarn dev```
this will build and run locally for development

```yarn start```
this will build for product and host locally on node

```yarn docker:make```
this will build the docker image as above

```yarn docker:run```
this will run the docker container from the image

```yarn docker:clean```
this will stop and delete the container and image

```yarn docker:refresh```
this will first clean and then build the image and run the container


# dockerize
run 
```docker build -t dsd-server```
this will create an image named dsd-server,
make sure to run the build first using ```yarn build``` or the required files will not be available

then run
```docker run -p 9090:9090 dsd-server```
to run the container on port 9090

use the ```-d``` tag if you want to run detached (recommended)