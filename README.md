# Saber-ReplaceTemplate
A vendor plugin for [Saber](https://github.com/Datasilk/Saber) that allows webmasters to replace the template website that is included with Saber with the currently published website.

This was meant to be an internal tool used by Saber developers to update the official template website that is loaded when the user first runs a new copy of Saber in Visual Studio.

### Prerequisites
* Visual Studio 2017
* Clone [Saber](https://github.com/Datasilk/Saber) repository

### Installation
* Clone this repository inside your Saber project within `/App/Vendor/` and name the folder **ReplaceTemplate**
	> NOTE: use `git clone` instead of `git submodule add` since the contents of the Vendor folder is ignored by git
* Run `gulp default` to copy any required files from the vendor folder into the public `wwwroot` folder