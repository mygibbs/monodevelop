// WebDeployResolver.cs
// 
// Author:
//   Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.IO;

using MonoDevelop.Deployment;

namespace MonoDevelop.AspNet.Deployment
{
	
	public class WebDeployResolver : IDirectoryResolver
	{
		
		public string GetDirectory (DeployContext context, string folderId)
		{
			string directory;
			
			switch (folderId) {
			case WebTargetDirectory.AspNetBin:
				directory = "bin";
				break;
			case WebTargetDirectory.SiteRoot:
				directory = string.Empty;
				break;
			default:
				return null;
			}
			
			// While this would seem to be what the deploy API expects, for a web deploy it could 
			// produces results the user wouldn't expect
			//if (context.Prefix != null)
			//	directory = Path.Combine (context.Prefix, directory);
			
			return directory;
		}
	}
	
	public static class WebTargetDirectory
	{
		public const string AspNetBin = "Web.AspNet.Bin";
		public const string SiteRoot  = "Web.SiteRoot";
	}
	
}
