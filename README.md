# NamedPipesSharp
A simple Named Pipes Implementation in c#

Usage Instructions:
1. Launch one instance of **NamedPipesServer.exe**
2. This will print two **'net.pipe'** urls
3. Launch two instances of **NamedPipesClient.exe**
4. Paste first 'net.pipe' url in first Client instance and second url in second client instance
5. Press **Enter** in both client instances to make a function calls over NetNamedPipe.
6. First client instance will use a newly created instance of **DynamicDataProceesor** to perform its action.
7. Second client instance will use pre created instance of **InstanciatedDataProceesor** on the server to perform its actions.
8. You can see the data transfer time per operation on client.

**Observations:**
First function call takes longer time than later calls.