using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ToastBehavior : IEndpointBehavior, IDispatchMessageInspector
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            try
            {
                MessageBuffer Buffer = request.CreateBufferedCopy(int.MaxValue);
                Message NewRequest = Buffer.CreateMessage();

                request = NewRequest;

                //object CompleteMessage = Buffer.CreateMessage().GetBody<ToastMessage>();

                //string Subject = ((ToastMessage)CompleteMessage).Subject;
                //string ApplicationName = ((ToastMessage)CompleteMessage).ApplicationName;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().FullName, e.Message);
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            Console.WriteLine(reply.ToString());
        }
    }
}
