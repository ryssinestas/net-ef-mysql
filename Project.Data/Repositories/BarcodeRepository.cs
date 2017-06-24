using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Data.Repositories
{
    public class BarcodeRepository : BaseContext<Barcode>, IUnitOfWork<Barcode>
    {
    }
}
