using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002D9F RID: 11679
[NullableContext(1)]
[Nullable(0)]
public class BulletDataExecution
{
	// Token: 0x17001F3D RID: 7997
	// (get) Token: 0x0601791D RID: 96541 RVA: 0x0068E4D7 File Offset: 0x0068C6D7
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<LogicDataBase> GbDataList
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			this.InitGbGroup();
			return this.GbDataListInternal;
		}
	}

	// Token: 0x17001F3E RID: 7998
	// (get) Token: 0x0601791E RID: 96542 RVA: 0x0068E4E5 File Offset: 0x0068C6E5
	public bool HasRebound
	{
		get
		{
			return this.HasReboundInternal;
		}
	}

	// Token: 0x17001F3F RID: 7999
	// (get) Token: 0x0601791F RID: 96543 RVA: 0x0068E4ED File Offset: 0x0068C6ED
	public bool HasCollision
	{
		get
		{
			return this.HasCollisionInternal;
		}
	}

	// Token: 0x06017920 RID: 96544 RVA: 0x0068E4F8 File Offset: 0x0068C6F8
	public void InitGbGroup()
	{
		if (this.GbGroupInternalInit)
		{
			return;
		}
		this.GbGroupInternalInit = true;
		FName assetPathName = this.Data.GB组.GetAssetPathName();
		if (assetPathName != FName.NAME_None)
		{
			this.ActionGroup = Singleton<ResourceSystem>.Instance.Load<UKuroBpDataAssetGroup>(assetPathName.ToString(), "js_undefined");
			UKuroBpDataAssetGroup actionGroup = this.ActionGroup;
			TArray<UKuroBpDataAsset> tarray = (actionGroup != null) ? actionGroup.Data : null;
			int num = (tarray != null) ? tarray.Num() : 0;
			if (num > 0)
			{
				this.GbDataListInternal = new List<LogicDataBase>();
				this.SupportCamp = new List<ECamp>();
				this.ReboundBitMask = 0;
				for (int i = 0; i < num; i++)
				{
					LogicDataBase logicDataBase = tarray.Get(i) as LogicDataBase;
					this.GbDataListInternal.Add(logicDataBase);
					if (!this.HasReboundInternal && logicDataBase is LogicDataRebound)
					{
						this.HasReboundInternal = true;
					}
					if (!this.HasCollisionInternal && logicDataBase is LogicDataBulletCollision)
					{
						this.HasCollisionInternal = true;
					}
				}
			}
		}
	}

	// Token: 0x17001F40 RID: 8000
	// (get) Token: 0x06017921 RID: 96545 RVA: 0x0068E5F0 File Offset: 0x0068C7F0
	[Nullable(2)]
	public int[] TagIdOnVictimEnter
	{
		[NullableContext(2)]
		get
		{
			if (!this.TagIdOnVictimEnterInit)
			{
				this.TagIdOnVictimEnterInit = true;
				SReBulletDataExe data = this.Data;
				TArray<FGameplayTag> tarray = (data != null) ? data.受击对象进入添加Tag.GameplayTags : null;
				int num = (tarray != null) ? tarray.Num() : 0;
				if (num > 0)
				{
					this.TagIdOnVictimEnterInternal = new int[num];
					for (int i = 0; i < num; i++)
					{
						FGameplayTag tag = tarray.Get(i);
						this.TagIdOnVictimEnterInternal[i] = tag.TagId();
					}
				}
			}
			return this.TagIdOnVictimEnterInternal;
		}
	}

	// Token: 0x17001F41 RID: 8001
	// (get) Token: 0x06017922 RID: 96546 RVA: 0x0068E66C File Offset: 0x0068C86C
	public long[] GeIdApplyToVictim
	{
		get
		{
			if (this.GeIdApplyToVictimInternal == null)
			{
				TArray<long> 受击对象进入应用的GE的Id = this.Data.受击对象进入应用的GE的Id;
				this.GeIdApplyToVictimInternal = new long[受击对象进入应用的GE的Id.Count];
				受击对象进入应用的GE的Id.AsSpan<long>().CopyTo(this.GeIdApplyToVictimInternal);
			}
			return this.GeIdApplyToVictimInternal;
		}
	}

	// Token: 0x17001F42 RID: 8002
	// (get) Token: 0x06017923 RID: 96547 RVA: 0x0068E6BD File Offset: 0x0068C8BD
	public bool WaitEnterGeReply
	{
		get
		{
			if (this.WaitEnterGeReplyInternal == null)
			{
				this.WaitEnterGeReplyInternal = new bool?(this.Data.等待回包过程中不重复触发进入GE);
			}
			return this.WaitEnterGeReplyInternal.Value;
		}
	}

	// Token: 0x17001F43 RID: 8003
	// (get) Token: 0x06017924 RID: 96548 RVA: 0x0068E6ED File Offset: 0x0068C8ED
	public FGameplayTag SendGameplayEventTagToVictim
	{
		get
		{
			if (this.SendGameplayEventTagToVictimInternal == null)
			{
				this.SendGameplayEventTagToVictimInternal = new FGameplayTag?(this.Data.命中后对受击者发射GameplayEvent标签);
			}
			return this.SendGameplayEventTagToVictimInternal.Value;
		}
	}

	// Token: 0x17001F44 RID: 8004
	// (get) Token: 0x06017925 RID: 96549 RVA: 0x0068E720 File Offset: 0x0068C920
	public long[] SendGeIdToVictim
	{
		get
		{
			if (this.SendGeIdToVictimInternal == null)
			{
				TArray<long> 命中后对受击者应用GE的Id = this.Data.命中后对受击者应用GE的Id;
				this.SendGeIdToVictimInternal = new long[命中后对受击者应用GE的Id.Num()];
				命中后对受击者应用GE的Id.AsSpan<long>().CopyTo(this.SendGeIdToVictimInternal);
			}
			return this.SendGeIdToVictimInternal;
		}
	}

	// Token: 0x17001F45 RID: 8005
	// (get) Token: 0x06017926 RID: 96550 RVA: 0x0068E774 File Offset: 0x0068C974
	public long[] SendGeIdToRoleInGame
	{
		get
		{
			if (this.SendGeIdToRoleInGameInternal == null)
			{
				TArray<long> 命中后对在场上角色应用的GE的Id = this.Data.命中后对在场上角色应用的GE的Id;
				this.SendGeIdToRoleInGameInternal = new long[命中后对在场上角色应用的GE的Id.Num()];
				命中后对在场上角色应用的GE的Id.AsSpan<long>().CopyTo(this.SendGeIdToRoleInGameInternal);
			}
			return this.SendGeIdToRoleInGameInternal;
		}
	}

	// Token: 0x17001F46 RID: 8006
	// (get) Token: 0x06017927 RID: 96551 RVA: 0x0068E7C5 File Offset: 0x0068C9C5
	public FGameplayTag SendGameplayEventTagToAttacker
	{
		get
		{
			if (this.SendGameplayEventTagToAttackerInternal == null)
			{
				this.SendGameplayEventTagToAttackerInternal = new FGameplayTag?(this.Data.命中后对攻击者发射GameplayEvent标签);
			}
			return this.SendGameplayEventTagToAttackerInternal.Value;
		}
	}

	// Token: 0x17001F47 RID: 8007
	// (get) Token: 0x06017928 RID: 96552 RVA: 0x0068E7F8 File Offset: 0x0068C9F8
	public long[] SendGeIdToAttacker
	{
		get
		{
			if (this.SendGeIdToAttackerInternal == null)
			{
				TArray<long> 命中后对攻击者应用GE的Id = this.Data.命中后对攻击者应用GE的Id;
				this.SendGeIdToAttackerInternal = new long[命中后对攻击者应用GE的Id.Num()];
				命中后对攻击者应用GE的Id.AsSpan<long>().CopyTo(this.SendGeIdToAttackerInternal);
			}
			return this.SendGeIdToAttackerInternal;
		}
	}

	// Token: 0x17001F48 RID: 8008
	// (get) Token: 0x06017929 RID: 96553 RVA: 0x0068E849 File Offset: 0x0068CA49
	public FGameplayTag SendGameplayEventTagToAttackerOnEnd
	{
		get
		{
			if (this.SendGameplayEventTagToAttackerOnEndInternal == null)
			{
				this.SendGameplayEventTagToAttackerOnEndInternal = new FGameplayTag?(this.Data.结束时对攻击者发射GameplayEvent标签);
			}
			return this.SendGameplayEventTagToAttackerOnEndInternal.Value;
		}
	}

	// Token: 0x17001F49 RID: 8009
	// (get) Token: 0x0601792A RID: 96554 RVA: 0x0068E87C File Offset: 0x0068CA7C
	public long[] EnergyRecoverGeIds
	{
		get
		{
			if (this.EnergyRecoverGeIdsInternal == null)
			{
				TArray<long> 能量恢复类GE数组的Id = this.Data.能量恢复类GE数组的Id;
				this.EnergyRecoverGeIdsInternal = new long[能量恢复类GE数组的Id.Num()];
				能量恢复类GE数组的Id.AsSpan<long>().CopyTo(this.EnergyRecoverGeIdsInternal);
			}
			return this.EnergyRecoverGeIdsInternal;
		}
	}

	// Token: 0x17001F4A RID: 8010
	// (get) Token: 0x0601792B RID: 96555 RVA: 0x0068E8CD File Offset: 0x0068CACD
	public FGameplayTag SendGameplayEventTagToAttackerOnStart
	{
		get
		{
			if (this.SendGameplayEventTagToAttackerOnStartInternal == null)
			{
				this.SendGameplayEventTagToAttackerOnStartInternal = new FGameplayTag?(this.Data.生成时对攻击者发射GameplayEvent标签);
			}
			return this.SendGameplayEventTagToAttackerOnStartInternal.Value;
		}
	}

	// Token: 0x0601792C RID: 96556 RVA: 0x0068E8FD File Offset: 0x0068CAFD
	public BulletDataExecution(SReBulletDataExe data)
	{
		this.Data = data;
	}

	// Token: 0x0601792D RID: 96557 RVA: 0x0068E90C File Offset: 0x0068CB0C
	public bool Preload()
	{
		this.InitGbGroup();
		return true;
	}

	// Token: 0x0400B4E7 RID: 46311
	[Nullable(2)]
	private readonly SReBulletDataExe Data;

	// Token: 0x0400B4E8 RID: 46312
	private bool GbGroupInternalInit;

	// Token: 0x0400B4E9 RID: 46313
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<LogicDataBase> GbDataListInternal;

	// Token: 0x0400B4EA RID: 46314
	public bool MovementReplaced;

	// Token: 0x0400B4EB RID: 46315
	public int ReboundBitMask;

	// Token: 0x0400B4EC RID: 46316
	[Nullable(2)]
	public List<ECamp> SupportCamp;

	// Token: 0x0400B4ED RID: 46317
	private bool HasReboundInternal;

	// Token: 0x0400B4EE RID: 46318
	private bool HasCollisionInternal;

	// Token: 0x0400B4EF RID: 46319
	[Nullable(2)]
	private UKuroBpDataAssetGroup ActionGroup;

	// Token: 0x0400B4F0 RID: 46320
	private bool TagIdOnVictimEnterInit;

	// Token: 0x0400B4F1 RID: 46321
	[Nullable(2)]
	private int[] TagIdOnVictimEnterInternal;

	// Token: 0x0400B4F2 RID: 46322
	[Nullable(2)]
	private long[] GeIdApplyToVictimInternal;

	// Token: 0x0400B4F3 RID: 46323
	private bool? WaitEnterGeReplyInternal;

	// Token: 0x0400B4F4 RID: 46324
	private FGameplayTag? SendGameplayEventTagToVictimInternal;

	// Token: 0x0400B4F5 RID: 46325
	[Nullable(2)]
	private long[] SendGeIdToVictimInternal;

	// Token: 0x0400B4F6 RID: 46326
	[Nullable(2)]
	private long[] SendGeIdToRoleInGameInternal;

	// Token: 0x0400B4F7 RID: 46327
	private FGameplayTag? SendGameplayEventTagToAttackerInternal;

	// Token: 0x0400B4F8 RID: 46328
	[Nullable(2)]
	private long[] SendGeIdToAttackerInternal;

	// Token: 0x0400B4F9 RID: 46329
	private FGameplayTag? SendGameplayEventTagToAttackerOnEndInternal;

	// Token: 0x0400B4FA RID: 46330
	[Nullable(2)]
	private long[] EnergyRecoverGeIdsInternal;

	// Token: 0x0400B4FB RID: 46331
	private FGameplayTag? SendGameplayEventTagToAttackerOnStartInternal;
}
