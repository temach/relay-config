
Server Side:

To set up the server:
- Since it runs on port 9000 (for now at least) you must run it with admin privilegies. Else you get System.Net.HttpListenerException (or something like that) 
- You must disable firewall, or preferably set a firewall Inbound Rule to allow connections on port 9000.
- The windows inside the virtual box must be connected to the network with the Bridged Adapter (this is done in virtual box "Settings" for the machine), else other machines will not be able to see it. By default virtual box sets up the NAT adapter.
- The relay config program must be already started on the server before the first client connects.
- If installing windows 7, you need to install Service Pack 1 and then .Net framework 4.5 to run the server.

For developer:
- AutoItX libraries (AutoItX3.Assembly, AutoItX3Lib, AutoItX3Lib\_x64) currently can not be installed through NuGet. They are just hand added as references and copied into bin/Debug and bin/Release directories.
- When writing the server code for RelayController the naming conventions are very important, read up on OWIN.

Client side:
- Test the connection to server with "telnet ip-addr port". Connection refused = nothing is running, accepted = something is running, timeout or failed = probably the firewall.
- Client code is not important.

Note that project ControlGUI is just a small part of the timerelay-daemon, it is split into a separate project for easier testing and periodically code is merged into timerelay-daemon project.
