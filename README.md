# WcfOverRabbitMq

A very basic example of using RabbitMQ as a transport for WCF.

## RabbitMQ settings

In order to use this example you need a running RabbitMQ node.
All RabbitMQ settings (such as IP, port, etc) are hardcoded.

Default values are:

* `IP : localhost`
* `PORT : 5672`
* `user : guest`
* `password : guest`

## Important note

Latest version of RabbitMQ binding to WCF is 3.6.9. It requires at least match version of RabbitMQ client.
But newer versions of RabbitMQ client are incompatible with this binding, so **DO NOT UPGRADE** until the binding itself would be released.
