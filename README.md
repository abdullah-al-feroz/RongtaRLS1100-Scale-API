# RongtaRLS1100-Scale-API
This project provides a .NET 8.0 Web API solution for connecting to and retrieving sales data from the Rongta RLS-1100 Weighing Scale. The API communicates with the weighing scale over a local network, reads transaction data (sales records), and saves it into a SQL database using Entity Framework Core.

🚀 Features
📡 Connect to Rongta RLS-1100 via TCP/IP
📦 Retrieve sales data directly from the weighing scale
💾 Automatically save records to the database using Entity Framework Core
🧩 Clean service architecture (Controller → Service → Repository → DbContext)
⚙️ Asynchronous operations for non-blocking I/O
🔐 Error handling and logging for connection and parsing failures
