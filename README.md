# ToDoApplication
Test task for rabota.ua


How to run:
```
docker build -t todoappv1 .
docker run -p 8008:80 -e ASPNETCORE_ENVIRONMENT='Development' todoappv1
```
or
```
docker-compose up --build
```
then enter in browser *host*:*port*/swagger
