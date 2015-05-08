# tours

[![Build status](https://ci.appveyor.com/api/projects/status/udp0mms0gm7m2cjp?svg=true)](https://ci.appveyor.com/project/bjornhol/tours)

Serving steps for [intro.js](http://usablica.github.io/intro.js/) based tours.

## Create tours

![New tour UI](/docs/addtour.png?raw=true "UI for creating new tour")

## Get tours

/api/tours (lists all)
/api/tours?screen=xyz (lists all for screen)
/api/tours?screen=xyz&userid=123 (returns and mark as "read" for screen and user)


![WebAPI to get tours](/docs/apireturn.png?raw=true "Get tours WebAPI")