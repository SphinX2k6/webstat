using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045C3 RID: 17859
	[NullableContext(1)]
	[Nullable(0)]
	public class AuthCodeData
	{
		// Token: 0x0602ECA6 RID: 191654 RVA: 0x00B1408E File Offset: 0x00B1228E
		public AuthCodeData(string authCode, int issuerId)
		{
			this.AuthCode = authCode;
			this.IssuerId = issuerId;
		}

		// Token: 0x0401A9DE RID: 109022
		public readonly string AuthCode;

		// Token: 0x0401A9DF RID: 109023
		public readonly int IssuerId;
	}
}
