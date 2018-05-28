# Avoid food poisoning

## Task

Write code that provides a summary breakdown of the food establishments near our Leeds offices.

```
AS AN
    Engineer
WHEN I
    Visit the Leeds Office
I WANT
    To go for lunch with minimal chance of getting food poisoning
SO THAT
    I enjoy the weekend
```

I'd like to see:

* The top 5 restaurants for cleanliness.
* The bottom 5 restaurants.
* A historgram of scores, e.g.:
  * One star: 40 (20%)
  * Two stars: 60 (30%)
  * Three stars: 20 (10%)
  * Four stars: 20 (10%)
  * Five stars: 60 (30%)

Use any programming language you like. Web application or console application is fine.

I've converted the data from XML to JSON for you with `convertxmltojson.go` in the zip file. You're welcome to use either the XML or JSON. I've left the XML zipped up.

Sample data:

```json
{
  "data": {
    "establishments": [
      {
        "name": "(Asda) Leeds Bridge Service Station",
        "address1": "Meadow Lane",
        "address2": "Holbeck",
        "address3": "Leeds",
        "postcode": "LS11 5BJ",
        "rating": "5"
      },
      {
        "name": "147 Sports Bar",
        "address1": "7 Chapeltown",
        "address2": "Pudsey",
        "address3": "Leeds",
        "postcode": "LS28 7RZ",
        "rating": "4"
      },
      {
        "name": "168 Chinese And Thai Takeaway",
        "address1": "15 Burton Avenue",
        "address2": "Beeston",
        "address3": "Leeds",
        "postcode": "LS11 5ET",
        "rating": "1"
      }
    ]
  }
}
```
