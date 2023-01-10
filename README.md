# BNDBankTerminal
Structure:

The program is divided into 3 main parts. 

1. The Core (hosts the models)
2. The API backend (contains an MDF DB with foreign keys/contraints to ensure the burden of data-consistency isnt on the backend)
3. The WPF program (Talks to the API)

The backend and the WPF reference the Core as a DLL, all made in .NET Core 6
The API also has Swagger so feel free to use/test the endpoints in case the WPF has limitations
