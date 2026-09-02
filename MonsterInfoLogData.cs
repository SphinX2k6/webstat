using System;
using System.Runtime.CompilerServices;

// Token: 0x02002117 RID: 8471
public class MonsterInfoLogData
{
	// Token: 0x0601034D RID: 66381 RVA: 0x00474D2C File Offset: 0x00472F2C
	[NullableContext(1)]
	public MonsterInfoLogData(MonsterInfoLogData data = null)
	{
		if (data != null)
		{
			this.pbdata_id = data.pbdata_id;
			this.config_type = data.config_type;
		}
	}

	// Token: 0x04007C83 RID: 31875
	public int pbdata_id;

	// Token: 0x04007C84 RID: 31876
	public int config_type;
}
