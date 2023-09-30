using MAADRE.MDCSI.KERNEL.Globals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Controllers
{
    public class SmartContractCntrllr
    {
        public string ContractAddress = "0x5fbdb2315678afecb367f032d93f642f64180aa3";
        public string Owner = "0xf39Fd6e51aad88F6F4ce6aB8827279cffFb92266";
        public string spender = "0x70997970C51812dc3A010C7d01b50e0d17dc79C8";
        public SmartContractCntrllr()
        {

        }

        public async void DeploySC()
        {
            ContractAddress = await GetStartedSmartContracts.DeployContract();
        }

        public async Task<string> GetBalanceOf(string balanceAddres)
        {
            var b = await GetStartedSmartContracts.GetBalanceOf(ContractAddress, balanceAddres);
            return b;
        }

        public async void SetMint()
        {
            await GetStartedSmartContracts.SetMintMain(ContractAddress);
        }

        public async Task<string> SetAllowance()
        {
            var bi = await GetStartedSmartContracts.AllowanceFunction(ContractAddress, spender);
            return bi.ToString();
        }

        public async void SetApprove()
        {
            var spender = "0x70997970C51812dc3A010C7d01b50e0d17dc79C8";
            await GetStartedSmartContracts.ApproveFunction(ContractAddress, spender);
        }

        public async Task<bool> SetTransferFunction()
        {
            var to = "0x3C44CdDdB6a900fa2b585dd299e03d12FA4293BC";
            var resp = await GetStartedSmartContracts.SetTransferFunction(ContractAddress, to, BigInteger.Parse("1000000000000000000"));
            return resp;
        }
        public async Task<bool> SetTransferFromFunction()
        {
            var from = Owner;//spender;
            var to = "0x3C44CdDdB6a900fa2b585dd299e03d12FA4293BC";
            var resp = await GetStartedSmartContracts.SetTransferFromFunction(ContractAddress, from, to, BigInteger.Parse("1000000000000000000"));
            return resp;
        }
    }
}
