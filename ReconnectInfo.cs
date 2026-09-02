using System;
using System.Runtime.CompilerServices;

// Token: 0x020020F5 RID: 8437
[NullableContext(1)]
[Nullable(0)]
public class ReconnectInfo
{
	// Token: 0x06010203 RID: 66051 RVA: 0x0046EDC6 File Offset: 0x0046CFC6
	public ReconnectInfo(string token, string host, int port)
	{
		this.Token = token;
		this.Host = host;
		this.Port = port;
	}

	// Token: 0x04007BB3 RID: 31667
	public string Token = string.Empty;

	// Token: 0x04007BB4 RID: 31668
	public string Host = string.Empty;

	// Token: 0x04007BB5 RID: 31669
	public int Port;
}
