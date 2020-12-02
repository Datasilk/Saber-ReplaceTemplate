# Saber-ReplaceTemplate
A vendor plugin for [Saber](https://saber.datasilk.io) that allows users to replace the template website that is included with Saber with the currently published website. This is useful if you plan on distributing a copy of Saber with a custom template website preinstalled.

### Prerequisites
* [Saber](https://saber.datasilk.io) ([latest release](https://github.com/Datasilk/Saber/releases))

### Installation
#### For Visual Studio Users
* Clone this repository inside your Saber project within `/App/Vendors/` and name the folder **ReplaceTemplate**
	> NOTE: use `git clone` instead of `git submodule add` since the contents of the Vendor folder is ignored by git
* Run `gulp default` from the root of your Saber project folder

#### For DevOps Users
While using the latest release of Saber, do the following:
* Download latest release of [Saber.Vendors.ReplaceTemplate](https://github.com/Datasilk/Saber-ReplaceTemplate/releases)
* Extract all files & folders from either the `win-x64` or `linux-x64` zip folder to Saber's `/Vendors/` folder

### Publish
* run command `./publish.bat`
* publish `bin/Publish/ReplaceTemplate.7z` as latest release

