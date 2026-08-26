using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract(Namespace = "https://bankwest.com.au")]
    public interface IToastMessageService
    {
        [OperationContract]
        bool Submit(ToastMessage Message);
    }
}
