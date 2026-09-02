using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x02002E07 RID: 11783
[NullableContext(1)]
[Nullable(0)]
public class BulletInitParams
{
	// Token: 0x06017CCF RID: 97487 RVA: 0x006A2574 File Offset: 0x006A0774
	public BulletInitParams(Entity owner, string bulletRowName, FTransformDouble? initialTransform, FVectorDouble? initTargetLocation, int skillId = 0, int parentId = 0, int targetId = 0, int baseTransformId = 0, int baseVelocityId = 0, [Nullable(2)] global::Vector size = null, bool fromRemote = false, EBulletSyncType syncType = EBulletSyncType.Local, long? contextId = null, long? skillContextId = null, Aki.Protocol.EBulletCreateSource source = Aki.Protocol.EBulletCreateSource.NormalSource, FVector? locationOffset = null, FRotator? beginRotatorOffset = null, [Nullable(2)] ISkillBattleContext battleContext = null, global::EBulletCreateSource createSource = global::EBulletCreateSource.Others)
	{
		this.Owner = owner;
		this.BulletRowName = bulletRowName;
		this.InitialTransform = initialTransform;
		this.InitTargetLocation = initTargetLocation;
		this.SkillId = skillId;
		this.ParentId = parentId;
		this.TargetId = targetId;
		this.BaseTransformId = baseTransformId;
		this.BaseVelocityId = baseVelocityId;
		this.Size = size;
		this.FromRemote = fromRemote;
		this.SyncType = syncType;
		this.ContextId = contextId;
		this.SkillContextId = skillContextId;
		this.Source = source;
		this.LocationOffset = locationOffset;
		this.BeginRotatorOffset = beginRotatorOffset;
		this.BattleContext = battleContext;
		this.CreateSource = createSource;
	}

	// Token: 0x0400B872 RID: 47218
	public readonly Entity Owner;

	// Token: 0x0400B873 RID: 47219
	public readonly string BulletRowName;

	// Token: 0x0400B874 RID: 47220
	public readonly FTransformDouble? InitialTransform;

	// Token: 0x0400B875 RID: 47221
	public readonly FVectorDouble? InitTargetLocation;

	// Token: 0x0400B876 RID: 47222
	public readonly int SkillId;

	// Token: 0x0400B877 RID: 47223
	public readonly int ParentId;

	// Token: 0x0400B878 RID: 47224
	public readonly int TargetId;

	// Token: 0x0400B879 RID: 47225
	public readonly int BaseTransformId;

	// Token: 0x0400B87A RID: 47226
	public readonly int BaseVelocityId;

	// Token: 0x0400B87B RID: 47227
	[Nullable(2)]
	public readonly global::Vector Size;

	// Token: 0x0400B87C RID: 47228
	public readonly bool FromRemote;

	// Token: 0x0400B87D RID: 47229
	public readonly EBulletSyncType SyncType;

	// Token: 0x0400B87E RID: 47230
	public readonly long? ContextId;

	// Token: 0x0400B87F RID: 47231
	public readonly long? SkillContextId;

	// Token: 0x0400B880 RID: 47232
	public readonly Aki.Protocol.EBulletCreateSource Source;

	// Token: 0x0400B881 RID: 47233
	public readonly FVector? LocationOffset;

	// Token: 0x0400B882 RID: 47234
	public readonly FRotator? BeginRotatorOffset;

	// Token: 0x0400B883 RID: 47235
	[Nullable(2)]
	public readonly ISkillBattleContext BattleContext;

	// Token: 0x0400B884 RID: 47236
	public readonly global::EBulletCreateSource CreateSource;
}
