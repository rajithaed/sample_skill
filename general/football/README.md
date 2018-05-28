# Football, I've heard of it

## Task

Make an API for the data at https://raw.githubusercontent.com/jalapic/engsoccerdata/master/data-raw/england.csv

It needs to be able to:

* List team names.
* Be able to list results for a pair of teams, e.g. Manchester United vs Leeds.

Sample data:

```csv
"","Date","Season","home","visitor","FT","hgoal","vgoal","division","tier","totgoal","goaldif","result"
"1",1888-12-15,1888,"Accrington F.C.","Aston Villa","1-1",1,1,"1",1,2,0,"D"
"2",1889-01-19,1888,"Accrington F.C.","Blackburn Rovers","0-2",0,2,"1",1,2,-2,"A"
"3",1889-03-23,1888,"Accrington F.C.","Bolton Wanderers","2-3",2,3,"1",1,5,-1,"A"
"4",1888-12-01,1888,"Accrington F.C.","Burnley","5-1",5,1,"1",1,6,4,"H"
"5",1888-10-13,1888,"Accrington F.C.","Derby County","6-2",6,2,"1",1,8,4,"H"
"6",1888-12-29,1888,"Accrington F.C.","Everton","3-1",3,1,"1",1,4,2,"H"
"7",1889-01-26,1888,"Accrington F.C.","Notts County","1-2",1,2,"1",1,3,-1,"A"
"8",1888-10-20,1888,"Accrington F.C.","Preston North End","0-0",0,0,"1",1,0,0,"D"
"9",1889-04-20,1888,"Accrington F.C.","Stoke City","2-0",2,0,"1",1,2,2,"H"
```

## Validation

* Easy to understand API.
* API returns correct results.
* Bonus points for also being able to specify a year range, e.g. 2000-2017 for the matches.
