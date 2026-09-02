using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E7C RID: 3708
[NullableContext(1)]
[Nullable(0)]
public class PreCreateEffectData
{
	// Token: 0x06005A5A RID: 23130 RVA: 0x00162646 File Offset: 0x00160846
	public PreCreateEffectData(int entityId, string path)
	{
		this.EntityId = entityId;
		this.Path = path;
	}

	// Token: 0x040029E0 RID: 10720
	public int EntityId;

	// Token: 0x040029E1 RID: 10721
	public string Path;
}
