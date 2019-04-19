Setup appsetting.json by using the UserPool configure on AWS Cognito.

```json
    "UserPoolClientId": "7rc60n4ddgk74dchhov2vbm2ad", // You get on AWS -> UserPool -> App clients
    "UserPoolClientSecret": "aoh9a6a6ur153iohicvgn10fio4mf1b4ella9bhg98v9gka3ivk", // You get on AWS -> UserPool -> App clients
    "UserPoolId": "us-east-2_BpFrZVZIu"  // You get on AWS -> UserPool -> General Settings
```

Create a new layer by using DDD and move the model for the properly layer.