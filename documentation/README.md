## Installation Steps

1.	To get correct installation of Air Pollution module on your instance of Sitecore you should have installed **Sitecore Experience Platform 9.0 rev. 171219 (9.0 Update-1)**.
2.	On github repository in **sc.package** directory is [package](../sc.package/AirPollution-LasVegans-Hackathon-2018-1.0.0.zip) which has to be installed on Sitecore instance. In case of any conflicts, please choose **Overwrite** option and continue.
3.	After successfully installation of package, please publish installed items or whole site.
4.	In **AirPolutionCustomConfig.config** some settings responsible for external API are placed. Most important is **BreezoMetterApiKey**. To hackaton purposes we’ve used trial version which will expire in a month. If verification process will be made after **3.04.2018**, please sign up and generate new token here https://developers.breezometer.com/login.
5.	**!!Please configure your Sitecore instance to use HTTPS and use it during exploring website.!!** It is required by localization services.
6.	Setup for Sitecore instance is done. Now there is a need to add some things to **xConnect** instance. Please make sure that your xConnect instance is turned on and works well.
7.	Go to **sc.pakage** directory on repository and copy [XConnectSmogModel, 0.1.json](../sc.package/XConnectSmogModel,%200.1.json) file to following directories:
	-	xConnect-web-root/App_Data/Models
	- xConnect-web-root/App_data/jobs/continuous/IndexWorker/App_data/Models
8. Enjoy the module!
