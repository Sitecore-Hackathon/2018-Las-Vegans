# Sitecore Hackathon 2018

## LasVegans Team - Poland
### Tomasz Juranek
### Robert Debowski
### Wojciech Urban

## Category: XConnect

# Welcome dear user! (Purpose) 

LasVegans team would like to present to you sophisticated solution to get you healthier. We are here to help you and take care of you. First of all we have to ask ourselves a main question:

What is one of the most widespread factor around the world, which is invisible, calm but in other hand extremely danger?

Answer is simple: SMOG !

Smog is a heavy air pollution which looks like mix of fog and smoke, but unfortunately it's not nature work.

To protect you against this risks we provided special module application to Sitecore which will take care about checking air in your location and will notify you in needed situation.

----------

# How user should use our module?

Don't worry dear user that module is hard to use. What steps are needed to you make it are:

1. Register in Sitecore using our form prepared especially for this unusual Hackathon 2018 occasion.
![enter image description here](https://github.com/Sitecore-Hackathon/2018-Las-Vegans/blob/ab04d8d33b4ebb2488e1541f85e18b6725cdb2df/documentation/images/register.jpg?raw=true)
2. Since that moment you GeoLocation data will be get and module will check quality of you air using many dedicated sensor in your area.
![enter image description here](https://raw.githubusercontent.com/Sitecore-Hackathon/2018-Las-Vegans/ab04d8d33b4ebb2488e1541f85e18b6725cdb2df/documentation/images/db.jpg)
4.  When situation will be dangerous for you health, you will received an email on the email address that you have registered into system. Rensposible for sending email is EXM module.
![enter image description here](https://raw.githubusercontent.com/Sitecore-Hackathon/2018-Las-Vegans/ab04d8d33b4ebb2488e1541f85e18b6725cdb2df/documentation/images/exm.jpg)

![enter image description here](https://raw.githubusercontent.com/Sitecore-Hackathon/2018-Las-Vegans/ab04d8d33b4ebb2488e1541f85e18b6725cdb2df/documentation/images/email.jpg)

Summary: Only step 1 has to be done by you, nothing else ! :)

# Technical Point Of View

## Installation

To setup module you will need:
- Sitecore 9 rev. 171219 (Update-1)
- working xConnect service
- module package from repository
- json file prepared for Sitecore & xConnect to extend model

## Solutions
Our application gather user email from address using form and localization from his browser. Later those data are used by Marketing Automation to trigger external API "BreezoMeter". That API basing on given user localization check current air condition and return results to Sitecore. Then our model gets those data and put it by xConnect Custom Facet to xDB. Additionally, if value of air condition is dangerous low, Marketing Automation will send an email through EXM to warn user before this situation.

![enter image description here](https://github.com/Sitecore-Hackathon/2018-Las-Vegans/blob/master/documentation/images/marketing_automation.png?raw=true)
![enter image description here](https://github.com/Sitecore-Hackathon/2018-Las-Vegans/blob/master/documentation/images/rule.jpg?raw=true)
## Extensions
Our Module consists more than standard behavior presented in solution workflow above. There is also option to use custom action code, which has been already written and it's done!

### Marketing Automation Action
If you would like to make more fancy stuff, just use our prepared action.
![enter image description here](https://github.com/Sitecore-Hackathon/2018-Las-Vegans/blob/master/documentation/images/marketing_action.png?raw=true)

Only what you need is to create UI part for that :)

### Task scheduler
If you need something working out of the box, just use scheduler and enjoy possibility to refresh data systematically.
![enter image description here](https://github.com/Sitecore-Hackathon/2018-Las-Vegans/blob/master/documentation/images/tasks.jpg?raw=true)

# Summary

We are really glad to present you our Sitecore Hackathon 2018 work. We see much of possibilities to extend our work, especially in Marketing Automation way. You will share our main goal of this work we believe, and enjoy of this at least the same as we do :) !
