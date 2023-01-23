using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface IReportReadService
    {
        public List<object> GigaFunction(Guid lessonId);
    }
}
