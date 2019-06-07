using System;
using AdvertModel;
using Amazon.DynamoDBv2.DataModel;

namespace Infrastructure.Repositories
{
    [DynamoDBTable("Advert")]
    public class AdvertDbModel
    {
        [DynamoDBHashKey]
        public string Id { get; set; } 

        [DynamoDBProperty]
        public string Title { get; set; } 
        
        [DynamoDBProperty]
        public string Description { get; set; }

        [DynamoDBProperty]
        public double Price { get; set; }

        [DynamoDBProperty]
        public DateTime CreationDateTime { get; set; }

        [DynamoDBProperty]
        public AdvertStatus Status { get; set; }
    }
}