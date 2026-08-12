### nineshaft-light-intel

A lightweight, asynchronous OSINT profile tracker written in C# (.NET 10). The tool automates target nickname enumeration across various platforms while strictly adhering to secure coding practices and operational security (OPSEC). 

### Key Features & Security Design

* **Secure By Design**: Implements strict input validation via compiled regular expressions (InputValidator.cs) to eliminate common input vulnerabilities such as Path Traversal and SSRF vectors.
* **Socket Exhaustion Prevention**: Utilizes a single, long-lived HttpClient instance configured with a managed SocketsHttpHandler pool. This ensures active connection reuse and protects system resources during heavy operations.
* **Anti-Detection Measures**: Features dynamic HTTP header generation using a browser user-agent rotation mechanism to bypass primitive rate-limiting and automated client blocks.
* **Asynchronous Resilience**: Built with full async/await patterns and bounded per-request CancellationToken timeouts (4 seconds) to guarantee the engine never hangs on slow or unresponsive endpoints.

### Project Structure

* Program.cs - Application entry point, CLI orchestrator, and flow controller.
* Validation/InputValidator.cs - Security boundary component protecting execution flow from malicious input payloads.
* Engine/IntelClient.cs - Dedicated network core handling safe HTTP client lifetimes and traffic stealth parameters.
* Services/ProfileScanner.cs - Execution engine managing target list processing, asynchronous network tasks, error interception, and dynamic delays (1.0s - 2.5s jitter) between target requests.
