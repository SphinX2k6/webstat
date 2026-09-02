using System;
using System.Runtime.CompilerServices;

// Token: 0x020020F6 RID: 8438
[NullableContext(1)]
[Nullable(0)]
public class LoginMapConfig
{
	// Token: 0x06010204 RID: 66052 RVA: 0x0046EDF9 File Offset: 0x0046CFF9
	public LoginMapConfig(int mapId, string mapName)
	{
		this.MapId = mapId;
		this.MapName = mapName;
	}

	// Token: 0x04007BB6 RID: 31670
	public int MapId;

	// Token: 0x04007BB7 RID: 31671
	public string MapName = string.Empty;
}
