using System.Net;
using System.Net.Sockets;
using System.Text;

var port = 5000;

var client = new TcpClient();

client.Connect(IPAddress.Loopback, port);
Console.WriteLine("Client connected // IP :: "+IPAddress.Loopback+"  // Port :: "+port);

var stream = client.GetStream();

var message = "hello";
Console.WriteLine("Data to send : "+message);
var data  = Encoding.UTF8.GetBytes(message);
Console.WriteLine("Data after encoded : "+data);


stream.Write(data);//writes on the stream :: Client to server

var buffer  = new byte[1024];
stream.Read(buffer, 0, buffer.Length);//Reads on the stream :: Server to client
Console.WriteLine("Sever Data resived : "+buffer);
var msg  = Encoding.UTF8.GetString(buffer);
Console.WriteLine("Sever Data after decoding : "+msg);