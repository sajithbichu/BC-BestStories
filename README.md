# BC-BestStories
 Bamboo-Card - Developer Coding Test

 ## Assumptions
 1. The IDs for the stories can be found only in the API call to https://hacker-news.firebaseio.com/v0/beststories.json
 2. Details of the best stories can be accessed only one at a time, passing the ID to the API call example: https://hacker-news.firebaseio.com/v0/item/21233041.json
    Example : if there are 5 IDs, then the News Hacker API has to be called 5 times to retrieve the story details.
 4. There is no API call provided or available to download all the best story details in one go.
 5. N will be the number of stories to be listed by the API, which will be specified by the caller as the parameter. If no value is entered, API will get and list all the details available for all the IDs in https://hacker-news.firebaseio.com/v0/beststories.json

## API coding logic
1. API accepts noOfStories as an optional parameter, which specifies the number of details to be listed in the API response. If no parameter is specified, all the details will be listed for the IDs in https://hacker-news.firebaseio.com/v0/beststories.json
2. As Best stories can be downloaded only by passing the ID to the Hacker New API one at a time, the API call happens in a loop.
3. The story details are accumulated in an array and order descending based on their scores and listed as a result.

## Enhancements
1. Memory caching has been implemented to minimize the API call to the News Hacker API, thus minimizing the unwanted overloading of the API. Also helps in the efficient handling of a large number of requests.
2. Auto Mapper is used to map the API response from the New Hacker API, to the result format.
