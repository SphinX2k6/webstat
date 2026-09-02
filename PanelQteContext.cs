using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.CreatureTools;
using AkiClient.Game.Aki.Data.Fight.UI;
using UnrealEngine;

// Token: 0x02002352 RID: 9042
[NullableContext(2)]
[Nullable(0)]
public class PanelQteContext
{
	// Token: 0x06011485 RID: 70789 RVA: 0x004C0B70 File Offset: 0x004BED70
	public Entity GetSourceEntity()
	{
		if (this.IsInitSourceEntity)
		{
			EntityHandle sourceEntityHandle = this.SourceEntityHandle;
			if (sourceEntityHandle == null || !sourceEntityHandle.Valid)
			{
				this.SourceEntityHandle = null;
				return null;
			}
			return this.SourceEntityHandle.Entity;
		}
		else
		{
			this.IsInitSourceEntity = true;
			if (this.SourceActor == null)
			{
				return null;
			}
			if (!(this.SourceActor is IBPI_CreatureInterface_C))
			{
				return null;
			}
			IBPI_CreatureInterface_C ibpi_CreatureInterface_C = this.SourceActor as IBPI_CreatureInterface_C;
			int? num = (ibpi_CreatureInterface_C != null) ? new int?(ibpi_CreatureInterface_C.GetEntityId()) : null;
			if (num == null)
			{
				return null;
			}
			this.SourceEntityHandle = ModelBase<CharacterModel>.Instance.GetHandle(num.Value);
			EntityHandle sourceEntityHandle2 = this.SourceEntityHandle;
			if (sourceEntityHandle2 == null)
			{
				return null;
			}
			return sourceEntityHandle2.Entity;
		}
	}

	// Token: 0x040087AF RID: 34735
	public EPanelQteSource? Source;

	// Token: 0x040087B0 RID: 34736
	public int QteId;

	// Token: 0x040087B1 RID: 34737
	public int QteHandleId;

	// Token: 0x040087B2 RID: 34738
	public USkeletalMeshComponent SourceMeshComp;

	// Token: 0x040087B3 RID: 34739
	public long? SourceBuffId;

	// Token: 0x040087B4 RID: 34740
	public int SourceBuffHandleId;

	// Token: 0x040087B5 RID: 34741
	public AActor SourceActor;

	// Token: 0x040087B6 RID: 34742
	public bool IsInitSourceEntity;

	// Token: 0x040087B7 RID: 34743
	public EntityHandle SourceEntityHandle;

	// Token: 0x040087B8 RID: 34744
	public SPanelQte Config;

	// Token: 0x040087B9 RID: 34745
	public long? PreMessageId;

	// Token: 0x040087BA RID: 34746
	public bool Success;

	// Token: 0x040087BB RID: 34747
	public int BuffIndex = -1;
}
