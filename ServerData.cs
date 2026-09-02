using System;
using System.Runtime.CompilerServices;

// Token: 0x020020F8 RID: 8440
[NullableContext(1)]
[Nullable(0)]
public class ServerData
{
	// Token: 0x06010206 RID: 66054 RVA: 0x0046EE6D File Offset: 0x0046D06D
	public ServerData(ServerConfig config = null)
	{
		if (config != null)
		{
			this.Config = config;
		}
	}

	// Token: 0x06010207 RID: 66055 RVA: 0x0046EE9A File Offset: 0x0046D09A
	public ServerData SetIp(string ip)
	{
		this.Config.Ip = ip;
		return this;
	}

	// Token: 0x04007BBC RID: 31676
	public ServerConfig Config = new ServerConfig("", "", "", 0);
}
