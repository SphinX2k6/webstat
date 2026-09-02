using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;

// Token: 0x02000F3D RID: 3901
[NullableContext(1)]
[Nullable(0)]
public class KscRemoveContext
{
	// Token: 0x060061AE RID: 25006 RVA: 0x00186AF4 File Offset: 0x00184CF4
	public void InitFromRemoveContext(FKSC_RemoveContext context, Dictionary<int, KscEntityHandle> entities)
	{
		KscEntityHandle kscEntityHandle;
		this.CreatureDataId = (entities.TryGetValue(context.EntityId, out kscEntityHandle) ? kscEntityHandle.CreatureDataId : 0L);
		KscEntityHandle kscEntityHandle2;
		this.KillerId = (entities.TryGetValue(context.EntityIdKillBy, out kscEntityHandle2) ? kscEntityHandle2.CreatureDataId : 0L);
		this.KillerType = FNameUtil.GetDynamicFName(context.EntityTypeKillBy.ToString());
		this.IsPreview = context.IsPreview;
		Vector location = this.Location;
		FVectorDouble location2 = context.Location;
		location.DeepCopy(location2);
		this.ReasonName = FNameUtil.GetDynamicFName(context.ReasonName.ToString()).Value;
		this.ClearCell = false;
		this.EffectRange = 0;
		this.FireNum = 0;
		this.Params = null;
	}

	// Token: 0x060061AF RID: 25007 RVA: 0x00186BC4 File Offset: 0x00184DC4
	public void InitFromLandFireContext(FKSC_LandFireContext context, Dictionary<int, KscEntityHandle> entities)
	{
		KscEntityHandle kscEntityHandle;
		this.CreatureDataId = (entities.TryGetValue(context.SpawnerEntityId, out kscEntityHandle) ? kscEntityHandle.CreatureDataId : 0L);
		this.KillerId = this.CreatureDataId;
		this.KillerType = null;
		this.IsPreview = false;
		this.Location.Set(0.0, 0.0, 0.0);
		this.ReasonName = KscData.landFireRemoveReason;
		this.ClearCell = context.ClearCell;
		this.EffectRange = context.EffectRange;
		this.FireNum = context.FireNum;
		this.Params = context.Params;
	}

	// Token: 0x04002ECA RID: 11978
	public long CreatureDataId;

	// Token: 0x04002ECB RID: 11979
	public long KillerId;

	// Token: 0x04002ECC RID: 11980
	public FName? KillerType;

	// Token: 0x04002ECD RID: 11981
	public bool IsPreview;

	// Token: 0x04002ECE RID: 11982
	public Vector Location = Vector.Create();

	// Token: 0x04002ECF RID: 11983
	public FName ReasonName;

	// Token: 0x04002ED0 RID: 11984
	public bool ClearCell;

	// Token: 0x04002ED1 RID: 11985
	public int EffectRange;

	// Token: 0x04002ED2 RID: 11986
	public int FireNum;

	// Token: 0x04002ED3 RID: 11987
	[Nullable(2)]
	public TMap<EKSC_AttrType, int> Params;
}
