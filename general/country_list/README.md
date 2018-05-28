# RESTify some data

## Task

Make an API that provides access to the data contained in https://github.com/umpirsky/country-list/blob/master/data/en/country.json

```
AS A
    Developer
WHEN I
    make a HTTP GET request to the /country/{code} endpoint, passing in an ISO country code such as "en" as the {code} value
I WANT
    To receive the name of the country
SO THAT
    I can populate a drop-down list with the values
```

## Validation

* Invalid country codes result in a 404 status being returned.
