**How to use**

1.  Download or clone this repo
2.  Open folder in terminal and type : "_dotnet run"_
3.  Find any REST Client. Make sure the request type is POST. Type the username and password in body with JSON format. Here is the hint:

> {
> "Username":"admin",
> "Password":"P@ssw0rd"
> }

Server will return you jwt token.

4.  Copy this token and open another rest call and set its type to GET.
5.  Add a header. **Key**: Authorization **Value**: Bearer {your token}
6.  When hit the enter, server will be return promotion code! :D

\*\*

## NOTE:

\*\*
I prepared this example thanks to Burak Selim Şenyurt's article and I understood the basics of jwt and user authentication.
[https://buraksenyurt.com/post/jwt-json-web-token-kullanimi](https://buraksenyurt.com/post/jwt-json-web-token-kullanimi)
