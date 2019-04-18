Create an UserPool on Cognito AWS Amazon

Setup appsetting.json by using the UserPool configure on AWS Cognito.

```json
    "UserPoolClientId": "[App client id]", // You get on AWS -> UserPool -> App clients
    "UserPoolClientSecret": "[App client secret]", // You get on AWS -> UserPool -> App clients
    "UserPoolId": "[Pool Id]"  // You get on AWS -> UserPool -> General Settings
```

Create a new layer by using DDD and move the model for the properly layer.