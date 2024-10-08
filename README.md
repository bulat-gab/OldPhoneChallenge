![main branch](https://github.com/bulat-gab/OldPhoneChallenge/actions/workflows/dotnet.yml/badge.svg?branch=main)

# Old Phone Challenge

A command-line application that emulates the functionality of an old mobile phone keypad. It allows users to input sequences of numbers using the traditional multi-tap input method and provides features for converting those sequences into corresponding characters.

## Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) or higher

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/bulat-gab/OldPhoneChallenge.git
   cd OldPhoneChallenge
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

## Repository Structure

- **OldPhoneChallenge.Core**: A class library project that encapsulates the logic for the Old Phone KeyPad functionality.
- **OldPhoneChallenge.DemoApp**: A demo application that showcases simple usage of the Old Phone KeyPad.
- **OldPhoneChallenge.ConsoleApp**: A console application designed to parse command-line arguments and invoke methods from the OldPhoneChallenge.Core to perform conversions.
- **OldPhoneChallenge.Tests**: A project dedicated to unit testing.

## Usage

**Using `dotnet`**

```bash
dotnet run --project ./OldPhoneChallenge.ConsoleApp -- "222 2 22#"
```

**Using `run.bat`**

```bash
.\run.bat "222 2 22#"
```

**Using `run.sh`**

```bash
./run.sh "222 2 22#"
```

# Licence

See the [LICENSE](./LICENCE) file for details.
