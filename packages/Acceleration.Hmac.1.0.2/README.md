# Acceleration.Hmac

Generate and validate [Hash-based message authentication codes][HMAC]
for data transfer objects (DTO).

Useful for securely sending DTOs with things like database ids from a
server to a client, and ensure some parts haven't been edited.

Uses [System.Security.Cryptography.HMACSHA256][HMACSHA256] to perform
the actual hashing.

Example:

* ASP.NET renders a form with three fields:
  * user-editable name
  * hidden id
  * hidden hmac hash
* User opens up their browser dev tools, changes the hidden id to
  something else, and submits the form, which sends back all fields
* ASP.NET recalculates the hash based on the incoming id, compares it
  to the incoming hash, and rejects the update because the hashes
  don't match

This is *not* a complete security solution; it's simply a way
to detect if a set of values has been modified.

[HMAC]: http://en.wikipedia.org/wiki/Hash-based_message_authentication_code
[HMACSHA256]: http://msdn.microsoft.com/en-us/library/system.security.cryptography.hmacsha256%28v=vs.110%29.aspx

## Example

```csharp

		using Acceleration.Hmac
		public class MyDto : IHmac {
			[Hmac]
			public int Id {get;set;}
			[Hmac]
			public DateTime Created {get;set;}
			public string Hash {get;set;}
			public string Name {get;set;}
		}

		// some imaginary web framework
		public class MyController{
		  public Result GetDto(){
			var dto = new MyDto{Id=1, Created=DateTime.Now};
			dto.ComputeHash();
			return Ok(dto);
		  }
        
		  // get it back from the client	
	      public Result PostDto(MyDto dto){
		    if(!dto.ValidateHash()) return Error("bad hash");
			// run whatever processing
		  }
		}	
```

## API Reference

* `IHmac` - interface DTOs must implement
* `Hmac` - abstract class implementing `IHmac`
* `HmacAttribute` tags a property for inclusion in the hash
* `string IHmac.ComputeHash(secret)` - extension method to compute the
  hash. If no secret is given, uses the full type name. Uses reflection
  and a naive cache to figure out what properties to include in the
  hash.
* `bool IHmac.ValidateHash(secret)` - extension method to recompute the
  hash and compare with the one already calculated
* `string Hasher.ComputeHash(secret, datum)` - static method that does
  the actual hash calculations
* `HashMismatchException` - basic exception for throwing hash errors