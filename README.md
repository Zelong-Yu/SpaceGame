Star Trek Trade War: A Consoled based text game
===============================================
### [Zelong Yu](https://github.com/himoyu),  [Pingdwende Philippe Kabore](https://github.com/kaborephil) 

[Star Trek Trade War Github folder](https://github.com/himoyu/SpaceGame/tree/master/SpaceGameLibrary/StarTrekTradeWar)

![Alt text](Supporting_Document/SampleUse.gif?raw=true "StarTrekTradeWar")


Introduction
------------
_Star Trek Trade War_ is a texted based game as a result of a week-long peer programming project. 

[Basic warp equation](https://www.calormen.com/star_trek/warpcalc/) was used in calculating travel speed with warp factor w in c.

Planets used in game are selected from [List_of_potentially_habitable_exoplanets](https://en.wikipedia.org/wiki/List_of_potentially_habitable_exoplanets)

Fuel consumption per light year is proportional to order of two of warp factor.

Installation
------------
1. Clone/Download the git folder to a local directory. 
2. Source code is in `SpaceGame/SpaceGameLibrary/StarTrekTradeWar/` folder. Compile and run `StarTrekTradeWar.exe`. 
2.1 May need to restore NuGet packages before compiling, since Colorful.Console and Newtonsoft.Json is used.
3. A sample save file is `hero.json` in `Supporting_Document` folder. Put it in the same folder of `StarTrekTradeWar.exe` and choose Load Game. 

Game Play
------------
0. Player starts with Age 20, money $1000, fuel 100 on Earth.
1. Travel between planets with certain warp factor. Faster player goes, more fuel it consumes, but less time needed. There is 1/3 chance to get raid and lost 10-50% of money when travelling.
2. Buy / sell. Certain items will have a planet-specific specific mark up factor. Use the price difference to earn money.
3. Refuel when fuel gets low. Fuel price is $10 per Unit of [Dilithium](https://en.wikipedia.org/wiki/Dilithium_(Star_Trek)). Attempt to travel 
with low fuel will result in death by strangled in space.
4. Bad end: Age > 70 years old, money < 0, or fuel <0.
5. Good end: Earn $10,000.


Characters copy right belongs to Paramount Pictures (R)
