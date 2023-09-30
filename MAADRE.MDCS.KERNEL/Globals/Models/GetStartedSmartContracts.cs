using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;
using Nethereum.Hex.HexTypes;

namespace MAADRE.MDCSI.KERNEL.Globals.Models
{
    public class GetStartedSmartContracts
    {
        public class StandardTokenDeployment : ContractDeploymentMessage
        {
            public static string BYTECODE =
                "0x60806040523480156200001157600080fd5b506040518060400160405280600e81526020017f5661726f436f696e20546f6b656e0000000000000000000000000000000000008152506004908162000058919062000389565b506040518060400160405280600381526020017f5652430000000000000000000000000000000000000000000000000000000000815250600590816200009f919062000389565b5069152d02c7e14af6800000600381905550620000c16200010760201b60201c565b600660006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555062000470565b600033905090565b600081519050919050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052604160045260246000fd5b7f4e487b7100000000000000000000000000000000000000000000000000000000600052602260045260246000fd5b600060028204905060018216806200019157607f821691505b602082108103620001a757620001a662000149565b5b50919050565b60008190508160005260206000209050919050565b60006020601f8301049050919050565b600082821b905092915050565b600060088302620002117fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff82620001d2565b6200021d8683620001d2565b95508019841693508086168417925050509392505050565b6000819050919050565b6000819050919050565b60006200026a620002646200025e8462000235565b6200023f565b62000235565b9050919050565b6000819050919050565b620002868362000249565b6200029e620002958262000271565b848454620001df565b825550505050565b600090565b620002b5620002a6565b620002c28184846200027b565b505050565b5b81811015620002ea57620002de600082620002ab565b600181019050620002c8565b5050565b601f82111562000339576200030381620001ad565b6200030e84620001c2565b810160208510156200031e578190505b620003366200032d85620001c2565b830182620002c7565b50505b505050565b600082821c905092915050565b60006200035e600019846008026200033e565b1980831691505092915050565b60006200037983836200034b565b9150826002028217905092915050565b62000394826200010f565b67ffffffffffffffff811115620003b057620003af6200011a565b5b620003bc825462000178565b620003c9828285620002ee565b600060209050601f831160018114620004015760008415620003ec578287015190505b620003f885826200036b565b86555062000468565b601f1984166200041186620001ad565b60005b828110156200043b5784890151825560018201915060208501945060208101905062000414565b868310156200045b578489015162000457601f8916826200034b565b8355505b6001600288020188555050505b505050505050565b61124280620004806000396000f3fe608060405234801561001057600080fd5b50600436106100ea5760003560e01c806370a082311161008c578063a457c2d711610066578063a457c2d714610275578063a9059cbb146102a5578063d5abeb01146102d5578063dd62ed3e146102f3576100ea565b806370a0823114610209578063893d20e81461023957806395d89b4114610257576100ea565b806323b872dd116100c857806323b872dd1461015b578063313ce5671461018b57806339509351146101a9578063557cded5146101d9576100ea565b806306fdde03146100ef578063095ea7b31461010d57806318160ddd1461013d575b600080fd5b6100f7610323565b6040516101049190610dfd565b60405180910390f35b61012760048036038101906101229190610eb8565b6103b5565b6040516101349190610f13565b60405180910390f35b6101456103d8565b6040516101529190610f3d565b60405180910390f35b61017560048036038101906101709190610f58565b6103e2565b6040516101829190610f13565b60405180910390f35b610193610411565b6040516101a09190610fc7565b60405180910390f35b6101c360048036038101906101be9190610eb8565b61041a565b6040516101d09190610f13565b60405180910390f35b6101f360048036038101906101ee9190610fe2565b610451565b6040516102009190610f13565b60405180910390f35b610223600480360381019061021e919061100f565b610518565b6040516102309190610f3d565b60405180910390f35b610241610560565b60405161024e919061104b565b60405180910390f35b61025f61058a565b60405161026c9190610dfd565b60405180910390f35b61028f600480360381019061028a9190610eb8565b61061c565b60405161029c9190610f13565b60405180910390f35b6102bf60048036038101906102ba9190610eb8565b610699565b6040516102cc9190610f13565b60405180910390f35b6102dd6106bc565b6040516102ea9190610f3d565b60405180910390f35b61030d60048036038101906103089190611066565b6106c6565b60405161031a9190610f3d565b60405180910390f35b606060048054610332906110d5565b80601f016020809104026020016040519081016040528092919081815260200182805461035e906110d5565b80156103ab5780601f10610380576101008083540402835291602001916103ab565b820191906000526020600020905b81548152906001019060200180831161038e57829003601f168201915b5050505050905090565b6000806103c061074d565b90506103cd818585610755565b600191505092915050565b6000600254905090565b6000806103ed61074d565b90506103fa858285610767565b6104058585856107fb565b60019150509392505050565b60006012905090565b60008061042561074d565b905061044681858561043785896106c6565b6104419190611135565b610755565b600191505092915050565b6000600660009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16146104e3576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004016104da906111b5565b60405180910390fd5b61050f600660009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16836108ef565b60019050919050565b60008060008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020549050919050565b6000600660009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905090565b606060058054610599906110d5565b80601f01602080910402602001604051908101604052809291908181526020018280546105c5906110d5565b80156106125780601f106105e757610100808354040283529160200191610612565b820191906000526020600020905b8154815290600101906020018083116105f557829003601f168201915b5050505050905090565b60008061062761074d565b9050600061063582866106c6565b905083811015610680578481856040517fa60f030c000000000000000000000000000000000000000000000000000000008152600401610677939291906111d5565b60405180910390fd5b61068d8286868403610755565b60019250505092915050565b6000806106a461074d565b90506106b18185856107fb565b600191505092915050565b6000600354905090565b6000600160008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054905092915050565b600033905090565b6107628383836001610971565b505050565b600061077384846106c6565b90507fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff81146107f557818110156107e5578281836040517ffb8f41b20000000000000000000000000000000000000000000000000000000081526004016107dc939291906111d5565b60405180910390fd5b6107f484848484036000610971565b5b50505050565b600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff160361086d5760006040517f96c6fd1e000000000000000000000000000000000000000000000000000000008152600401610864919061104b565b60405180910390fd5b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff16036108df5760006040517fec442f050000000000000000000000000000000000000000000000000000000081526004016108d6919061104b565b60405180910390fd5b6108ea838383610b48565b505050565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff16036109615760006040517fec442f05000000000000000000000000000000000000000000000000000000008152600401610958919061104b565b60405180910390fd5b61096d60008383610b48565b5050565b600073ffffffffffffffffffffffffffffffffffffffff168473ffffffffffffffffffffffffffffffffffffffff16036109e35760006040517fe602df050000000000000000000000000000000000000000000000000000000081526004016109da919061104b565b60405180910390fd5b600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff1603610a555760006040517f94280d62000000000000000000000000000000000000000000000000000000008152600401610a4c919061104b565b60405180910390fd5b81600160008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055508015610b42578273ffffffffffffffffffffffffffffffffffffffff168473ffffffffffffffffffffffffffffffffffffffff167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92584604051610b399190610f3d565b60405180910390a35b50505050565b600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff1603610b9a578060026000828254610b8e9190611135565b92505081905550610c6d565b60008060008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054905081811015610c26578381836040517fe450d38c000000000000000000000000000000000000000000000000000000008152600401610c1d939291906111d5565b60405180910390fd5b8181036000808673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002081905550505b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1603610cb65780600260008282540392505081905550610d03565b806000808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600082825401925050819055505b8173ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef83604051610d609190610f3d565b60405180910390a3505050565b600081519050919050565b600082825260208201905092915050565b60005b83811015610da7578082015181840152602081019050610d8c565b60008484015250505050565b6000601f19601f8301169050919050565b6000610dcf82610d6d565b610dd98185610d78565b9350610de9818560208601610d89565b610df281610db3565b840191505092915050565b60006020820190508181036000830152610e178184610dc4565b905092915050565b600080fd5b600073ffffffffffffffffffffffffffffffffffffffff82169050919050565b6000610e4f82610e24565b9050919050565b610e5f81610e44565b8114610e6a57600080fd5b50565b600081359050610e7c81610e56565b92915050565b6000819050919050565b610e9581610e82565b8114610ea057600080fd5b50565b600081359050610eb281610e8c565b92915050565b60008060408385031215610ecf57610ece610e1f565b5b6000610edd85828601610e6d565b9250506020610eee85828601610ea3565b9150509250929050565b60008115159050919050565b610f0d81610ef8565b82525050565b6000602082019050610f286000830184610f04565b92915050565b610f3781610e82565b82525050565b6000602082019050610f526000830184610f2e565b92915050565b600080600060608486031215610f7157610f70610e1f565b5b6000610f7f86828701610e6d565b9350506020610f9086828701610e6d565b9250506040610fa186828701610ea3565b9150509250925092565b600060ff82169050919050565b610fc181610fab565b82525050565b6000602082019050610fdc6000830184610fb8565b92915050565b600060208284031215610ff857610ff7610e1f565b5b600061100684828501610ea3565b91505092915050565b60006020828403121561102557611024610e1f565b5b600061103384828501610e6d565b91505092915050565b61104581610e44565b82525050565b6000602082019050611060600083018461103c565b92915050565b6000806040838503121561107d5761107c610e1f565b5b600061108b85828601610e6d565b925050602061109c85828601610e6d565b9150509250929050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052602260045260246000fd5b600060028204905060018216806110ed57607f821691505b602082108103611100576110ff6110a6565b5b50919050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052601160045260246000fd5b600061114082610e82565b915061114b83610e82565b925082820190508082111561116357611162611106565b5b92915050565b7f455250433a20596f7520646f6e27742068617665207065726d697373696f6e73600082015250565b600061119f602083610d78565b91506111aa82611169565b602082019050919050565b600060208201905081810360008301526111ce81611192565b9050919050565b60006060820190506111ea600083018661103c565b6111f76020830185610f2e565b6112046040830184610f2e565b94935050505056fea264697066735822122016a3d09770bce40d6de38fe85da847ff7665ab585c3a583c8ef514e39db9661964736f6c63430008130033";

            public static string ABI =
                "[{\"inputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"constructor\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"currentAllowance\",\"type\": \"uint256\"},{\"internalType\": \"uint256\",\"name\": \"requestedDecrease\",\"type\": \"uint256\"}],\"name\": \"ERC20FailedDecreaseAllowance\",\"type\": \"error\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"allowance\",\"type\": \"uint256\"},{\"internalType\": \"uint256\",\"name\": \"needed\",\"type\": \"uint256\"}],\"name\": \"ERC20InsufficientAllowance\",\"type\": \"error\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"sender\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"balance\",\"type\": \"uint256\"},{\"internalType\": \"uint256\",\"name\": \"needed\",\"type\": \"uint256\"}],\"name\": \"ERC20InsufficientBalance\",\"type\": \"error\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"approver\",\"type\": \"address\"}],\"name\": \"ERC20InvalidApprover\",\"type\": \"error\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"receiver\",\"type\": \"address\"}],\"name\": \"ERC20InvalidReceiver\",\"type\": \"error\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"sender\",\"type\": \"address\"}],\"name\": \"ERC20InvalidSender\",\"type\": \"error\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"}],\"name\": \"ERC20InvalidSpender\",\"type\": \"error\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": true,\"internalType\": \"address\",\"name\": \"owner\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"},{\"indexed\": false,\"internalType\": \"uint256\",\"name\": \"value\",\"type\": \"uint256\"}],\"name\": \"Approval\",\"type\": \"event\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": true,\"internalType\": \"address\",\"name\": \"from\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"indexed\": false,\"internalType\": \"uint256\",\"name\": \"value\",\"type\": \"uint256\"}],\"name\": \"Transfer\",\"type\": \"event\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"owner\",\"type\": \"address\"},{\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"}],\"name\": \"allowance\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"value\",\"type\": \"uint256\"}],\"name\": \"approve\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"account\",\"type\": \"address\"}],\"name\": \"balanceOf\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"decimals\",\"outputs\": [{\"internalType\": \"uint8\",\"name\": \"\",\"type\": \"uint8\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"requestedDecrease\",\"type\": \"uint256\"}],\"name\": \"decreaseAllowance\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"getOwner\",\"outputs\": [{\"internalType\": \"address\",\"name\": \"\",\"type\": \"address\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"spender\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"addedValue\",\"type\": \"uint256\"}],\"name\": \"increaseAllowance\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"maxSupply\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"name\",\"outputs\": [{\"internalType\": \"string\",\"name\": \"\",\"type\": \"string\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"value\",\"type\": \"uint256\"}],\"name\": \"setMint\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"symbol\",\"outputs\": [{\"internalType\": \"string\",\"name\": \"\",\"type\": \"string\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"totalSupply\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"value\",\"type\": \"uint256\"}],\"name\": \"transfer\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"from\",\"type\": \"address\"},{\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"value\",\"type\": \"uint256\"}],\"name\": \"transferFrom\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"}]";
            //@"[{""constant"":false,""inputs"":[{""name"":""_spender"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[],""name"":""totalSupply"",""outputs"":[{""name"":""supply"",""type"":""uint256""}],""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_from"",""type"":""address""},{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""name"":""balance"",""type"":""uint256""}],""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""},{""name"":""_spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{""name"":""remaining"",""type"":""uint256""}],""type"":""function""},{""inputs"":[{""name"":""_initialAmount"",""type"":""uint256""}],""type"":""constructor""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_from"",""type"":""address""},{""indexed"":true,""name"":""_to"",""type"":""address""},{""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_owner"",""type"":""address""},{""indexed"":true,""name"":""_spender"",""type"":""address""},{""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Approval"",""type"":""event""}]";
            public StandardTokenDeployment() : base(BYTECODE)
            {
            }

            [Parameter("uint256", "totalSupply")]
            public BigInteger TotalSupply { get; set; }
        }

        [Function("balanceOf", "uint256")]
        public class BalanceOfFunction : FunctionMessage
        {
            [Parameter("address", "account", 1)]
            public string Account { get; set; }
        }

        [FunctionOutput]
        public class BalanceOfOutputDTO : IFunctionOutputDTO
        {
            [Parameter("uint256", "balance", 1)]
            public BigInteger Balance { get; set; }
        }


        // If we were going to return multiple values we could have something like:

        [FunctionOutput]
        public class BalanceOfOutputMultipleDTO : IFunctionOutputDTO
        {
            [Parameter("uint256", "balance1", 1)]
            public BigInteger Balance1 { get; set; }

            [Parameter("uint256", "balance2", 2)]
            public BigInteger Balance2 { get; set; }

            [Parameter("uint256", "balance3", 3)]
            public BigInteger Balance3 { get; set; }
        }
        [Function("setMint", "bool")]
        public class SetMintFunction : FunctionMessage
        {

            [Parameter("uint256", "value", 1)]
            public BigInteger Value { get; set; }
        }

        [Function("allowance", "uint256")]
        public class SetAllowanceFunction : FunctionMessage
        {
            [Parameter("address", "owner", 1)]
            public string Owner { get; set; }

            [Parameter("address", "spender", 2)]
            public string Spender { get; set; }
        }

        [Function("approve", "bool")]
        public class SetApproveFunction : FunctionMessage
        {
            [Parameter("address", "spender", 1)]
            public string Spender { get; set; }

            [Parameter("uint256", "value", 2)]
            public BigInteger Value { get; set; }
        }

        [Function("transfer", "bool")]
        public class TransferFunction : FunctionMessage
        {
            [Parameter("address", "to", 1)]
            public string To { get; set; }

            [Parameter("uint256", "value", 2)]
            public BigInteger TokenAmount { get; set; }
        }

        [Event("Transfer")]
        public class TransferEventDTO : IEventDTO
        {
            [Parameter("address", "_from", 1, true)]
            public string From { get; set; }

            [Parameter("address", "_to", 2, true)]
            public string To { get; set; }

            [Parameter("uint256", "_value", 3, false)]
            public BigInteger Value { get; set; }
        }

        [Function("transferFrom", "bool")]
        public class TransferFromFunction : FunctionMessage
        {
            [Parameter("address", "from", 1)]
            public string From { get; set; }
            [Parameter("address", "to", 1)]
            public string To { get; set; }

            [Parameter("uint256", "value", 2)]
            public BigInteger Value { get; set; }
        }

        /********************/
        [Function("setNFTSaleContractAddress")]
        public class SetNFTSaleContractAddressFunction : FunctionMessage
        {
            [Parameter("address", "_nftSaleAddress", 1)]
            public string NFTSaleAddress { get; set; }
        }

        [Function("listNFTForSale")]
        public class ListNFTForSaleFunction : FunctionMessage
        {
            [Parameter("uint256", "tokenId", 1)]
            public BigInteger TokenId { get; set; }
        }

        [Function("buyNFT")]
        public class BuyNFTFunction : FunctionMessage
        {
            [Parameter("uint256", "tokenId", 1)]
            public BigInteger TokenId { get; set; }
        }
        //**** END CONTRACT DEFINITIONS ***** ///
        public static async Task SetNFTSaleContractAddress(string contractAddress, string nftSaleAddress)
        {
            try
            {
                var url = "http://127.0.0.1:8545";
                var privateKey = "TU_CLAVE_PRIVADA";
                var chainId = 31337;
                var account = new Account(privateKey, chainId);
                var web3 = new Web3(account, url);

                // Crea una instancia del objeto SetNFTSaleContractAddressFunction y establece los parámetros
                var setNFTSaleContractFunction = new SetNFTSaleContractAddressFunction()
                {
                    NFTSaleAddress = nftSaleAddress
                };

                // Crea una instancia del objeto TransactionHandler y establece el gas y la gasPrice
                var transactionHandler = web3.Eth.GetContractTransactionHandler<SetNFTSaleContractAddressFunction>();
                var gas = new HexBigInteger(200000); // Establece el gas que consideres adecuado
                var gasPrice = new HexBigInteger(new BigInteger(1000000000)); // Establece el gasPrice que consideres adecuado

                // Realiza el envío de la transacción para llamar a la función setNFTSaleContractAddress
                var transactionReceipt = await transactionHandler
                    .SendRequestAndWaitForReceiptAsync(contractAddress, setNFTSaleContractFunction);

                // Verifica si la transacción se ejecutó exitosamente
                if (transactionReceipt.Status.Value == 1)
                {
                    Console.WriteLine("setNFTSaleContractAddress ejecutada exitosamente.");
                }
                else
                {
                    Console.WriteLine("setNFTSaleContractAddress fallida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }
        /****************************************************************************************************/
        public static async Task<bool> SetTransferFromFunction(string contractAddress, string from, string to, BigInteger tokenAmount)
        {
            try
            {
                var url = "http://127.0.0.1:8545";
                var privateKey = "0x59c6995e998f97a5a0044966f0945389dc9e86dae88c7a8412f4603b6b78690d";
                //var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
                //"0x59c6995e998f97a5a0044966f0945389dc9e86dae88c7a8412f4603b6b78690d";
                var chainId = 31337;
                var account = new Account(privateKey, chainId);
                var web3 = new Web3(account, url);
                // Crea una instancia del objeto AllowanceFunction y establece los parámetros
                var transferFunction = new TransferFromFunction()
                {
                    From = from,
                    To = to,
                    Value = tokenAmount
                };

                var approveHandler = web3.Eth.GetContractQueryHandler<TransferFromFunction>();
                var approveValue = await approveHandler.QueryAsync<bool>(contractAddress, transferFunction);

                Console.WriteLine("El valor de la allowance es: " + approveValue);
                return approveValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }
        public static async Task<bool> SetTransferFunction(string contractAddress, string to, BigInteger tokenAmount)
        {
            try
            {
                var url = "http://127.0.0.1:8545";
                var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
                var chainId = 31337;
                var account = new Account(privateKey, chainId);
                var web3 = new Web3(account, url);
                // Crea una instancia del objeto AllowanceFunction y establece los parámetros
                var transferFunction = new TransferFunction()
                {
                    To = to,
                    TokenAmount = tokenAmount
                };

                var approveHandler = web3.Eth.GetContractQueryHandler<TransferFunction>();
                var approveValue = await approveHandler.QueryAsync<bool>(contractAddress, transferFunction);

                Console.WriteLine("El valor de la allowance es: " + approveValue);
                return approveValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }
        public static async Task ApproveFunction(string contractAddress, string spender)
        {
            try
            {
                var url = "http://127.0.0.1:8545";
                var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
                var chainId = 31337;
                var account = new Account(privateKey, chainId);
                var web3 = new Web3(account, url);
                // Crea una instancia del objeto AllowanceFunction y establece los parámetros
                var approveFunction = new SetApproveFunction()
                {
                    Spender = spender,
                    Value = BigInteger.Parse("5000000000000000000")
                };

                //// Ejecuta la consulta "allowance" en el contrato
                /*var allowanceValue = await web3.Eth.GetContractTransactionHandler<SetApproveFunction>()
                    .SendRequestAndWaitForReceiptAsync(contractAddress, approveFunction);*/

                var approveHandler = web3.Eth.GetContractQueryHandler<SetApproveFunction>();
                var approveValue = await approveHandler.QueryAsync<bool>(contractAddress, approveFunction);

                Console.WriteLine("El valor de la allowance es: " + approveValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static async Task<BigInteger> AllowanceFunction(string contractAddress, string spender)
        {
            try
            {
                var url = "http://127.0.0.1:8545";
                var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
                var chainId = 31337;
                var account = new Account(privateKey, chainId);
                var web3 = new Web3(account, url);
                // Crea una instancia del objeto AllowanceFunction y establece los parámetros
                var allowanceFunction = new SetAllowanceFunction()
                {
                    Owner = account.Address,
                    Spender = spender
                };

                /*var allowanceValue = await web3.Eth.GetContractTransactionHandler<SetAllowanceFunction>()
                    .SendRequestAndWaitForReceiptAsync(contractAddress, allowanceFunction);*/

                var allowanceHandler = web3.Eth.GetContractQueryHandler<SetAllowanceFunction>();
                var allowanceValue = await allowanceHandler.QueryAsync<BigInteger>(contractAddress, allowanceFunction);

                Console.WriteLine("El valor de la allowance es: " + allowanceValue.ToString());
                return allowanceValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static async Task SetMintMain(string contractAddress)
        {
            try
            {
                //// ### Instantiating Web3 and the Account
                //// To create an instance of web3 we first provide the url of our testchain and the private key of our account. 
                //// Here we are using http://testchain.nethereum.com:8545 which is our simple single node Nethereum testchain.
                //// When providing an Account instantiated with a  private key, all our transactions will be signed by Nethereum.

                var url = "http://127.0.0.1:8545";
                var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
                var chainId = 31337;
                var account = new Account(privateKey, chainId);
                var web3 = new Web3(account, url);

                var totalSupply = BigInteger.Parse("1000000000000000000");
                //var senderAddress = account.Address;


                // Dirección y cantidad de tokens a mintear               

                // Crea una instancia del objeto MintFunction y establece los parámetros
                var mintFunction = new SetMintFunction()
                {
                    Value = totalSupply
                };

                // Envía la transacción para mintear los tokens
                var transactionReceipt = await web3.Eth.GetContractTransactionHandler<SetMintFunction>()
                    .SendRequestAndWaitForReceiptAsync(contractAddress, mintFunction);

                // La transacción se ha completado, y los tokens han sido minteados
                Console.WriteLine("Tokens minteados correctamente. Transaction Hash: " + transactionReceipt.TransactionHash);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static async Task SetMint(string contractAddress)
        {
            try
            {
                var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
                var chainId = 31337; //Nethereum test chain, chainId
                                     //var chainId = 444444444500; //Nethereum test chain, chainId
                var account = new Account(privateKey, chainId);
                var mintFunctionMessage = new SetMintFunction()
                {
                    Value = new HexBigInteger("10000000000000000000")//BigInteger.Parse("10000000000000000000")
                };
                var web3 = new Web3(account, "http://127.0.0.1:8545");

                var balanceHandler = web3.Eth.GetContractQueryHandler<SetMintFunction>();
                var balance = await balanceHandler.QueryAsync<BigInteger>(contractAddress, mintFunctionMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async Task<string> GetBalanceOf(string contractAddress, string balanceAddres)
        {
            var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
            var chainId = 31337; //Nethereum test chain, chainId            
            var account = new Account(privateKey, chainId);
            var ownerAddres = account.Address;
            var balanceOfFunctionMessage = new BalanceOfFunction()
            {
                Account = balanceAddres //contractAddress  account.Address,
            };
            var web3 = new Web3(account, "http://127.0.0.1:8545");
            var balanceHandler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();

            var balance = await balanceHandler.QueryAsync<BigInteger>(contractAddress, balanceOfFunctionMessage);

            Console.WriteLine("Balance of deployment owner address: " + balance.ToString());
            return balance.ToString();
        }
        public static async Task<string> DeployContract()
        {
            var url = "http://127.0.0.1:8545";
            var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
            var chainId = 31337;
            var account = new Account(privateKey, chainId);
            var web3 = new Web3(account, url);
            // web3.TransactionManager.UseLegacyAsDefault = true;

            var contractByteCode = GetStartedSmartContracts.StandardTokenDeployment.BYTECODE;
            var abi = GetStartedSmartContracts.StandardTokenDeployment.ABI;
            var senderAddress = account.Address;

            var estimatedGas = await web3.Eth.DeployContract.EstimateGasAsync(abi, contractByteCode, senderAddress);
            var receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(contractByteCode, senderAddress, estimatedGas);
            Console.WriteLine("Contract deployed at address: " + receipt.ContractAddress);
            return receipt.ContractAddress;
        }
        ///*** THE MAIN PROGRAM ***
        public static async Task Main()
        {

        }
    }
}