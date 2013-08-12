# Novell.Directory.LDAP

This is a GitHub mirror of the `Novell.Directory.LDAP` library which is primarily hosted by Novell directly (original [here](http://www.novell.com/developer/ndk/ldap_libraries_for_c_sharp.html)).

This mirror hosts the sources for v2.1.11 for convenience, since it is otherwise necessary to use FTP to obtain the source code.

`Mono.Security.dll` is also included, taken unmodified from the v2.10 Windows binary release of Mono. The sources for this binary are available [here](https://github.com/mono/mono/tree/mono-2-10).

It is necessary to include the `Mono.Security.dll` assembly when running on .NET on Windows.

It is thought that this mirror is acceptable under the MIT license (intact in the LICENSE file) under which both `Novell.Directory.LDAP` and `Mono.Security.dll` are released.

## Building (Windows/.NET)

From a Developer Command Prompt:

```
> build.bat
```

### Building (Linux/Mono)

From a shell with mono available on `PATH`:

```
$ build.sh
```