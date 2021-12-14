using ArinWhois.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleTestApp
{


class Program
{


static async Task Main (string[] args)
{
	var arinClient = new ArinClient () ;

// Check single IP
	var ipResponse = await arinClient.QueryIpAsync (IPAddress.Parse ("45.134.225.25")) ;
	if (ipResponse == null)
		goto exit_app ;

	string strNetName   = string.Format ("NetName:   {0}", ipResponse.Network.Name) ;
	Console.WriteLine (strNetName) ;
	string strNetHandle = string.Format ("NetHandle: {0}", ipResponse.Network.Handle) ;
	Console.WriteLine (strNetHandle) ;
	string strNetType   = string.Format ("NetType:   {0} ({1})", ipResponse.Network.NetBlocks.NetBlock.Type, ipResponse.Network.NetBlocks.NetBlock.Description) ;
	Console.WriteLine (strNetType) ;
	string strNetRange  = string.Format ("NetRange:  {0} - {1}", ipResponse.Network.StartAddress, ipResponse.Network.EndAddress) ;
	Console.WriteLine (strNetRange) ;
	string strCIDR	     = string.Format ("CIDR:      {0}", ipResponse.Network.NetBlocks.NetBlock.Cidr) ;
	Console.WriteLine (strCIDR) ;

	string strOrgName   = string.Format ("OrgName:   {0}", ipResponse.Network.OrgRef.Name) ;
	Console.WriteLine (strOrgName) ;
	string strOrgId     = string.Format ("OrgId:     {0}", ipResponse.Network.OrgRef.Handle) ;
	Console.WriteLine (strOrgId) ;

// Find out more about organization
	var orgResponse = await arinClient.QueryResourceAsync (ipResponse.Network.OrgRef.Handle, ArinClient.ResourceType.Organization) ;
	if (orgResponse != null)
	{
		Console.WriteLine (orgResponse.Organization.Name) ;
		Console.WriteLine (orgResponse.Organization.City) ;
	}

exit_app:

	return ;
}


}
}
