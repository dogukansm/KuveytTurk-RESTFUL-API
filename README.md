<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url] 
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/dogukansm/KuveytTurk-RESTFUL-API">
    <img src="https://i.hizliresim.com/9710hkz.png" alt="KuveytTurk-RESTFUL-API" height="150">
  </a>

  <h3 align="center">Kuveyt Türk C#.NET CORE RESTFUL API</h3>

  <p align="center">
    In this project, development was made on C#.NET CORE with the <br />
    banking APIs given to all developers by Kuveyt Türk Bank.
    <br />
    <a href="https://developer.kuveytturk.com.tr/documentation/introduction/getting-started"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://developer.kuveytturk.com.tr/">Kuveyt Türk Developer</a>
    ·
    <a href="https://developer.kuveytturk.com.tr/swagger">Swagger Documentation</a> 
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![KuveytTurk-RESTFUL-API Screen Shot][product-screenshot]](https://example.com)

The documentation submitted for developers by Kuveyt Türk bank has been prepared quite clearly. However, the lack of a ready-made project may cause you to be alone with question marks.

For this reason, this API project (suitable for Microservice architecture) has been prepared in such a way that you can integrate Kuveyt Türk and even other banks.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

Nuget packages were used during the production. Packages used: <b>`Newtonsoft.Json`, `BouncyCastle.NetCore`, `RestSharp`, `Autofac`, `Microsoft.EntityFrameworkCore`</b>. The languages used during development are listed below:

* [![Next][CSHARP]][CSHARP-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

Before you begin, you must make the adjustments during the installation phase. If these steps are not fully followed, you will not get a properly working API connection.

### Installation

You need to change the lines below from the <b>`EnvHelper`</b> file in the <b>`Helper`</b> folder in the <b>`KuveytTurk.ENTITIES`</b> layer.

1. Change the "---UYGULAMANIZIN ADINI YAZIN---" with your Application Name.
   ```csharp
   public static string ApplicationName = "---UYGULAMANIZIN ADINI YAZIN---";
   ```
2. Change the "---UYGULAMANIZIN CLIENT ID(CANLI) KEYİNİ YAZIN---" with your Production Client Id.
   ```csharp
   public static string clientIdProd = "---UYGULAMANIZIN CLIENT ID(CANLI) KEYİNİ YAZIN---";
   ```
3. Change the "---UYGULAMANIZIN CLIENT SECRET(CANLI) KEYİNİ YAZIN---" with your Production Client Secret.
   ```csharp
   public static string clientSecretProd = "---UYGULAMANIZIN CLIENT SECRET(CANLI) KEYİNİ YAZIN---";
   ```
4. Change the "---UYGULAMANIZIN CLIENT ID(TEST) KEYİNİ YAZIN---" with your Test Client Id.
   ```csharp
   public static string clientIdTest = "---UYGULAMANIZIN CLIENT ID(TEST) KEYİNİ YAZIN---";
   ```
5. Change the "---UYGULAMANIZIN CLIENT SECRET(TEST) KEYİNİ YAZIN---" with your Test Client Secret.
   ```csharp
   public static string clientSecretTest = "---UYGULAMANIZIN CLIENT SECRET(TEST) KEYİNİ YAZIN---";
   ```
6. Change the "---UYGULAMANIZIN PUBLIC KEYİNİ YAZIN---" with your Application Public Key.
   ```csharp
   public static string publicKey = @"---UYGULAMANIZIN PUBLIC KEYİNİ YAZIN---";
   ```
7. Change the "---UYGULAMANIZIN PRIVATE KEYİNİ YAZIN---" with your Application Private Key.
   ```csharp
   public static string privateKey = @"---UYGULAMANIZIN PRIVATE KEYİNİ YAZIN---";
   ```
8. Change the "---CONNECTION STRING BİLGİLERİNİZİ YAZIN---" with your Connection String.
   ```csharp
   public static string ConnectionString = @"---CONNECTION STRING BİLGİLERİNİZİ YAZIN---";
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Some methods require `accessToken` and `signature`. These are nullable data. Therefore, in the methods where these are requested, you will get successful results if you only remove these two (fill in the other fields if any) and send them. 

<p align="right">(<a href="#readme-top">back to top</a>)</p>

 
 
 


<!-- CONTACT -->
## Contact

Doğukan Şimşek - [@linkedin](https://linkedin.com/in/dogukansm) - dogukansm@icloud.com 

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/dogukansm/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/dogukansm/KuveytTurk-RESTFUL-API/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/dogukansm/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/dogukansm/KuveytTurk-RESTFUL-API/network/members
[stars-shield]: https://img.shields.io/github/stars/dogukansm/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/dogukansm/KuveytTurk-RESTFUL-API/stargazers
[issues-shield]: https://img.shields.io/github/issues/dogukansm/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/dogukansm/KuveytTurk-RESTFUL-API/issues
[license-shield]: https://img.shields.io/github/license/dogukansm/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/dogukansm/KuveytTurk-RESTFUL-API/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/dogukansm
[product-screenshot]: https://i.hizliresim.com/7hyq25y.png
[CSHARP]: https://img.shields.io/badge/C%23-563D7C?style=for-the-badge&logo=csharp&logoColor=white
[CSHARP-url]: #
