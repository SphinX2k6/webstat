using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B1B RID: 6939
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoManager : Singleton<DangoManager>
{
	// Token: 0x0600C7EB RID: 51179 RVA: 0x0034E808 File Offset: 0x0034CA08
	public DangoData GetDangoData(int id)
	{
		DangoData dangoData;
		if (!this.DangoDataMap.TryGetValue(id, out dangoData))
		{
			dangoData = DangoData.Create(id);
			this.DangoDataMap[id] = dangoData;
		}
		return dangoData;
	}

	// Token: 0x04005FDB RID: 24539
	private readonly Dictionary<int, DangoData> DangoDataMap = new Dictionary<int, DangoData>();
}
