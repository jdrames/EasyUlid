# EasyUlid
This library is used to simplify the creation of strongly typed IDs 
using [ULIDs](https://github.com/Cysharp/Ulid) as the backing type.

## Usage
Simply decorate a partial record class with the `[EasyUlid]` attribute
and it will generate the remaining code.

Example:
```csharp
[EasyUlid]
public partial record GalleryId {}
```

### Methods
The following methods will be generated for the new Ulid-backed type.

```csharp
// Parses the provided string into the EasyUlid type
// Throws error when a non-valid value is passed
public static T Parse(string ulidString);

// Trys to parse the provided string into the EasyUlid type
public static bool TryParse(string ulidString, out T EasyUlidType);

// Generates a new ID matching for the EasyUlid type
public static T New();
```

### Implicit Operators
```csharp
public static implicit operator string(T easyUlidValue);
public static implicit operator T(string ulidId);
```
