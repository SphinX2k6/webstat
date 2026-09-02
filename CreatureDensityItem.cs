using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200348C RID: 13452
[NullableContext(1)]
[Nullable(0)]
public class CreatureDensityItem
{
	// Token: 0x0601C61B RID: 116251 RVA: 0x008817C5 File Offset: 0x0087F9C5
	public CreatureDensityItem(long creatureDataId, int densityLevel, EntityPb entityData)
	{
		this.CreatureDataId = creatureDataId;
		this.DensityLevel = densityLevel;
		this.EntityData = entityData;
	}

	// Token: 0x0400E451 RID: 58449
	[Nullable(2)]
	public EntityHandle EntityHandle;

	// Token: 0x0400E452 RID: 58450
	public readonly long CreatureDataId;

	// Token: 0x0400E453 RID: 58451
	public int DensityLevel;

	// Token: 0x0400E454 RID: 58452
	public readonly EntityPb EntityData;
}
