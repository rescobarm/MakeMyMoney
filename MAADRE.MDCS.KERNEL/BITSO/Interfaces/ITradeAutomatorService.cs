using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MAADRE.MDCSI.KERNEL.BITSO.Service.CryptoKernel;

namespace MAADRE.MDCSI.KERNEL.BITSO.Interfaces
{
	public interface ITradeAutomatorService
	{
		ObservableCollection<TradesEnProceso> Trades { get; }
	}
}
