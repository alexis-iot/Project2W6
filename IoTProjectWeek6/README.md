# Web Service for IoT

## Getting Started

This project contains a Web Service running on an AWS EC2 Linux Instance able to receive data from an IoT deployment. The supported content type to be received is JSON, and supports 2 actions depending on the following HTTP verbs:

1. **POST**: Stores the information submitted by the user. Internally, it stores the received information, along with the client's IP Address and request timestamp. The data structure that this method receives is the following:

```json
{
  "username": "Alexis",
  "password": "123"
}
```
2. **GET**: Retrieves the latest 10 registers stored in database, as an array of items containing the registered information, along with the client's IP Address and request timestamp. For example:  

```json
[
  {
    "id":2,
    "username":"xyz",
    "password":"xyz",
    "ipAddress":"172.31.11.138",
    "requestDate":"2018-09-25T02:41:32",
  },
  {
    "id":1,
    "username":"Alexis",
    "password":"123",
    "ipAddress":"172.31.11.138",
    "requestDate":"2018-09-25T02:35:52",
  }
]
```
### How to use it

##### POST
curl -H "Content-Type: application/json" -X POST -d '{"username":"xyz","password":"xyz"}' http://ec2-52-67-91-154.sa-east-1.compute.amazonaws.com:8080/api/login

or,

curl -H "Content-Type: application/json" -X POST -d '{"username":"xyz","password":"xyz"}' http://52.67.91.154:8080/api/login


##### GET
curl http://ec2-52-67-91-154.sa-east-1.compute.amazonaws.com:8080/api/login

or,

curl http://52.67.91.154:8080/api/login



### Technical Details

This service with created by using the following technical design:

1. Platform: Amazon Linux 2 AMI
2. .NET Core 2.1 (C# 7.0)
3. MySQL 5.7
4. Running on port 8080

<!--

ASPNETCORE_URLS="http://*:8080" dotnet IoTProjectWeek6.dll

sudo systemctl stop mysqld.service
/var/log/mysqld.log
ssh -i "alulema.pem" ec2-user@ec2-18-231-188-210.sa-east-1.compute.amazonaws.com

root | Sist3m45XDB<
web | Qw3rty<AzB




---------------------------
UBUNTU
---------------------
sudo nano /etc/mysql/debian.cnf 


curl -H "Content-Type: application/json" -X POST -d '{"username":"xyz","password":"xyz"}' http://ec2-18-228-116-83.sa-east-1.compute.amazonaws.com:8080/api/login
curl http://ec2-18-228-116-83.sa-east-1.compute.amazonaws.com:8080/api/login
/login

-->