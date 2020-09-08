# Chattprogram

## Structure
### Contacts
Name|Type|Description
------------ | ------------- | -------------
Log|Log|Used to store the chatlogs
ConnectionType|int|Used to keep track of what type of connection it is, 0: Web Connection,  1: Private Connection, 2: Host Connection
Name|string|Used to keep track of contacts for the user
Connected|bool|Used to keep track if contact has an established connection
Server|string|Used to keep track of which server to keep contact with, Only used when ConnectionType == 0
Username|string|Personal Username for webserver, as of now unused
IP|IPAdress|IP to connect to. Only used when ConnectionType == 1,
Port|int|Port to connect to.
stream|NetworkStream|stream to read/write to. Note lack of capitalization, please fix
Listener|Thread|Thread used to listen to stream
EncryptProvider|RSACryptoServiceProvider|RSACSP used to encrypt messages. Reciving Contacts DecryptProvider
DecryptProvider|RSACryptoServiceProvider|RSACSP used to decrypt messages. Reciving Contacts EncryptProvider
### Log
Name|Type|Description
------------ | ------------- | -------------
Text|Object[]|Object array used to contain text and images, could be renamed as variable was named before image functionality
ReadText|Object[]|Array used to check if anything new has arrived

## Schedule
### Initiating Contact
* Host has listening TCPListener
* Client connects to Host's TCPListener
* Both sides prepare DecryptProviders
* Host writes Host's DecryptProvider's public key. Client Reads and prepares their EncryptProvider
* Client writes Client's DecryptProvider's public key. Host Reads and prepares their EncryptProvider
* Host writes own AES key. Client Recieves and sets as own AES, note AES is symetrical i.e no public/private key
* Encrypted communication can now begin
### Sending Images
* Sender sends [0,1,2,3,4] in binary, which is the constant used to warn that an image is comming. Can be changed, just need's to be unwritable in utf-8
* Sender sends image size
* Sender sends image encrypted with AES instead of RSA
* Communications return to normal
