# BNDBankTerminal
Structure:

The program is divided into 3 main parts. 

1. The Core (hosts the models)
2. The API backend (contains an MDF DB with foreign keys/contraints to ensure the burden of data-consistency isnt on the backend)
3. The WPF program (Talks to the API)

The backend and the WPF reference the Core as a DLL, all made in .NET Core 6
The API also has Swagger so feel free to use/test the endpoints in case the WPF has limitations.

PS: Ctrl + F5 starts both API and the WPF without debug, so needn't change startup prog (solution configured to have multiple).
Debug starts the same way (click start). The MDF can be connected to, both via Server Exporer and SSMS.
