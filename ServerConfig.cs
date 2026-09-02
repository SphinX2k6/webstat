using System;
using System.Runtime.CompilerServices;

// Token: 0x020020F7 RID: 8439
[NullableContext(1)]
[Nullable(0)]
public class ServerConfig
{
	// Token: 0x06010205 RID: 66053 RVA: 0x0046EE1C File Offset: 0x0046D01C
	public ServerConfig(string ip = "", string port = "", string name = "", int order = 0)
	{
		this.Ip = ip;
		this.Port = port;
		this.Name = name;
		this.Order = order;
	}

	// Token: 0x04007BB8 RID: 31672
	public string Ip = string.Empty;

	// Token: 0x04007BB9 RID: 31673
	public string Port = string.Empty;

	// Token: 0x04007BBA RID: 31674
	public string Name = string.Empty;

	// Token: 0x04007BBB RID: 31675
	public int Order;
}
