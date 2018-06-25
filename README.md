﻿# Tuple

[![Build status](https://img.shields.io/appveyor/ci/UMCO/umbraco-tuple.svg)](https://ci.appveyor.com/project/UMCO/umbraco-tuple)
[![NuGet release](https://img.shields.io/nuget/v/Our.Umbraco.Tuple.svg)](https://www.nuget.org/packages/Our.Umbraco.Tuple)

Tuple is a property editor for Umbraco 7.6+

## Getting Started

### Installation

> *Note:* Tuple has been developed against **Umbraco v7.6.0** and will support that version and above.

Tuple can be installed from either NuGet package repositories, or build manually from the source-code:


#### NuGet package repository

To [install from NuGet](https://www.nuget.org/packages/Our.Umbraco.Tuple), you can run the following command from within Visual Studio:

	PM> Install-Package Our.Umbraco.Tuple

We also have a [MyGet package repository](https://www.myget.org/gallery/umbraco-packages) - for bleeding-edge / development releases.

#### Manual build

If you prefer, you can compile Tuple yourself, you'll need:

* Visual Studio 2017 (or above)

To clone it locally click the "Clone in Windows" button above or run the following git commands.

	git clone https://github.com/umco/umbraco-tuple.git umbraco-tuple
	cd umbraco-tuple
	.\build.cmd

---

## Known Issues

* _[TBC]_

---

## Contributing to this project

Anyone and everyone is welcome to contribute. Please take a moment to review the [guidelines for contributing](CONTRIBUTING.md).

* [Bug reports](CONTRIBUTING.md#bugs)
* [Feature requests](CONTRIBUTING.md#features)
* [Pull requests](CONTRIBUTING.md#pull-requests)

### TODO

What's left to do?

- [ ] Deploy ValueConnector
  - [ ] Pre Value Editor
    - [ ] Add DataType dependency
  - [ ] Value Editor
    - [ ] Processing the item's DataTypes


---

## Contact

Have a question?

* [Raise an issue](https://github.com/umco/umbraco-tuple/issues) on GitHub

## Dev Team

* [Lee Kelleher](https://github.com/leekelleher)
* [Matt Brailsford](https://github.com/mattbrailsford)

## License

Copyright &copy; 2017 UMCO, Our Umbraco and [other contributors](https://github.com/umco/umbraco-tuple/graphs/contributors)

Licensed under the [MIT License](LICENSE.md)
