using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Websocket_Server
{
    // Task I:  Modify this websocket behavior so that it remembers all messages.
    //          Whenever there is a new client connected, send all stored messages to the client
    //          so the client knows the history of the conversation.
    // Task II: Add timestamp (just the hour and minute) to the messages
    //          (see http://stackoverflow.com/questions/21219797/how-to-get-correct-timestamp-in-c-sharp
    //           for an example on how to get a timestamp).
    class Chat : WebSocketBehavior
    {
        Dummy_API dummy = new Dummy_API();
        protected override void OnOpen()
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            // Retrieve message from client
            string msg = e.Data;

            JObject rss = JObject.Parse(msg);
            string message = "";
            foreach(var pair in rss )
            {
                message = (string)pair.Value;
            }
            // login, logout, statusChange, roomStatusChange, createChat, addChatMember, leaveChat, chatMessage, contactAdded, contactRemoved 
            string response = "";
            switch (message)
            {
                case "login":
                    response = dummy.login(msg);
                    break;
                case "contactAdded":
                    response = dummy.contactAdded(msg);
                    break;
            }
            // Broadcast message to all clients
            Sessions.Broadcast(response);

        }
    }
}
