/******************************************************************************
* The MIT License
* Copyright (c) 2003 Novell Inc.  www.novell.com
* 
* Permission is hereby granted, free of charge, to any person obtaining  a copy
* of this software and associated documentation files (the Software), to deal
* in the Software without restriction, including  without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
* copies of the Software, and to  permit persons to whom the Software is 
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in 
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED AS IS, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*******************************************************************************/
//
// Samples.Extensions.SplitPartition.cs
//
// Author:
//   Sunil Kumar (Sunilk@novell.com)
//
// (C) 2003 Novell, Inc (http://www.novell.com)
//

using System;
using Novell.Directory.Ldap;
using Novell.Directory.Ldap.Extensions;

namespace Samples.Extensions
{

class SplitPartition
{
	static void Main(string[] args)
	{

		if ( args.Length != 5)
		{
			Console.WriteLine("Usage:   mono SplitPartition <host name> <ldap port>  <login dn>" + " <password> <partition root dn>  ");
			Console.WriteLine("Example: mono SplitPartition Acme.com 389"  + " \"cn=admin,o=Acme\"" + " secret \"ou=Sales,o=Acme\"");
			return;
        }

        string ldapHost = args[0];
		int ldapPort = System.Convert.ToInt32(args[1]);
        String loginDN  = args[2];
        String password = args[3];
        String partitionRoot   = args[4];

		try
		{
			LdapConnection conn= new LdapConnection();
			Console.WriteLine("Connecting to:" + ldapHost);
			conn.Connect(ldapHost,ldapPort);
			conn.Bind(loginDN,password);
		    LdapExtendedOperation request = new SplitPartitionRequest(	partitionRoot,
																		ReplicationConstants.Ldap_ENSURE_SERVERS_UP);
          	LdapExtendedResponse response = conn.ExtendedOperation(request);
			if ( response.ResultCode == LdapException.SUCCESS )
			{
				Console.WriteLine("SplitPartition Request succeeded\n");
			}
			conn.Disconnect();
		}
		catch(LdapException e)
		{
			Console.WriteLine("Error:" + e.LdapErrorMessage);
			return;
		}
		catch(Exception e)
		{
			Console.WriteLine("Error:" + e.Message);
			return;
		}
	}
}
}

