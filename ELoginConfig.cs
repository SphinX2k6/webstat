using System;

// Token: 0x020020EC RID: 8428
public enum ELoginConfig
{
	// Token: 0x04007B6B RID: 31595
	KcpConnectTimeoutMsPerTry = 3000,
	// Token: 0x04007B6C RID: 31596
	KcpConnectRetryCount = 1,
	// Token: 0x04007B6D RID: 31597
	ConnectGateWayRetryCount = 3,
	// Token: 0x04007B6E RID: 31598
	GetGameServerTokenTimeout = 13000,
	// Token: 0x04007B6F RID: 31599
	GetGlobalSdkTokenTimeout = 13000,
	// Token: 0x04007B70 RID: 31600
	ProtoKeyRequestTimeoutMs = 3000,
	// Token: 0x04007B71 RID: 31601
	CreateCharacterRequestTimeoutMs = 13000,
	// Token: 0x04007B72 RID: 31602
	EnterGameRequestTimeoutMs = 13000,
	// Token: 0x04007B73 RID: 31603
	LoginRequestTimeoutMs = 13000
}
