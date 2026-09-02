using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200106D RID: 4205
[NullableContext(1)]
[Nullable(0)]
public class FurnitureLevelContext
{
	// Token: 0x06006D62 RID: 28002 RVA: 0x001C7932 File Offset: 0x001C5B32
	public FurnitureLevelContext(Transform transform, string prefabPath)
	{
		this.Transform = transform;
		this.PrefabPath = prefabPath;
	}

	// Token: 0x040033E6 RID: 13286
	[Nullable(2)]
	public ULevelStreamingDynamic LevelStreamingDynamic;

	// Token: 0x040033E7 RID: 13287
	public readonly Transform Transform;

	// Token: 0x040033E8 RID: 13288
	public readonly string PrefabPath;
}
