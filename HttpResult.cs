using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Net;

// Token: 0x020020EE RID: 8430
[NullableContext(1)]
[Nullable(0)]
public class HttpResult
{
	// Token: 0x04007B74 RID: 31604
	public int code;

	// Token: 0x04007B75 RID: 31605
	public string token = string.Empty;

	// Token: 0x04007B76 RID: 31606
	public List<NetHostInfo> udpHosts = new List<NetHostInfo>();

	// Token: 0x04007B77 RID: 31607
	public List<NetHostInfo> tcpHosts = new List<NetHostInfo>();

	// Token: 0x04007B78 RID: 31608
	public int tcpRatio;

	// Token: 0x04007B79 RID: 31609
	[Nullable(2)]
	public GatewayLatencyConfigVo gatewayLatencyConfig;

	// Token: 0x04007B7A RID: 31610
	public int userData;

	// Token: 0x04007B7B RID: 31611
	public string errMessage = string.Empty;

	// Token: 0x04007B7C RID: 31612
	public int sex;

	// Token: 0x04007B7D RID: 31613
	public long banTimeStamp;

	// Token: 0x04007B7E RID: 31614
	public int banReason;

	// Token: 0x04007B7F RID: 31615
	public int clientWaitingMode;

	// Token: 0x04007B80 RID: 31616
	public int clientWaitingTime;

	// Token: 0x04007B81 RID: 31617
	public int clientAutoInInterval;
}
