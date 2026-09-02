using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F64 RID: 3940
[NullableContext(1)]
[Nullable(0)]
public class PinballBattleActivityEntityModel : PinballBattleEntityModel, IPinballBattleActivityEntityInfo, IPinballBattleCombatInfo, IPinballBattleConfigInfo
{
	// Token: 0x17000784 RID: 1924
	// (get) Token: 0x06006388 RID: 25480 RVA: 0x0018F395 File Offset: 0x0018D595
	// (set) Token: 0x06006389 RID: 25481 RVA: 0x0018F39D File Offset: 0x0018D59D
	public int ConfigId { get; set; }

	// Token: 0x17000785 RID: 1925
	// (get) Token: 0x0600638A RID: 25482 RVA: 0x0018F3A6 File Offset: 0x0018D5A6
	// (set) Token: 0x0600638B RID: 25483 RVA: 0x0018F3AE File Offset: 0x0018D5AE
	public EPinballBattleMonsterDeathType DeathType { get; set; }

	// Token: 0x0600638C RID: 25484 RVA: 0x0018F3B7 File Offset: 0x0018D5B7
	static PinballBattleActivityEntityModel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PinballBattleActivityEntityModel.CreateStaticDefaultValue), new Action(PinballBattleActivityEntityModel.ResetStaticDefaultValue));
	}

	// Token: 0x0600638D RID: 25485 RVA: 0x0018F3D6 File Offset: 0x0018D5D6
	public new static void CreateStaticDefaultValue()
	{
		PinballBattleActivityEntityModel.ActivityEntityPool = new Pool<PinballBattleActivityEntityModel>(100, () => new PinballBattleActivityEntityModel(), null);
	}

	// Token: 0x0600638E RID: 25486 RVA: 0x0018F404 File Offset: 0x0018D604
	public new static void ResetStaticDefaultValue()
	{
		PinballBattleActivityEntityModel.ActivityEntityPool = null;
	}

	// Token: 0x0600638F RID: 25487 RVA: 0x0018F40C File Offset: 0x0018D60C
	public static PinballBattleActivityEntityModel InitFromConfigId(int configId)
	{
		PinballBattleActivityEntityModel pinballBattleActivityEntityModel = PinballBattleActivityEntityModel.ActivityEntityPool.Get();
		if (pinballBattleActivityEntityModel == null)
		{
			pinballBattleActivityEntityModel = PinballBattleActivityEntityModel.ActivityEntityPool.Create();
		}
		if (pinballBattleActivityEntityModel != null)
		{
			pinballBattleActivityEntityModel.ConfigId = configId;
		}
		return pinballBattleActivityEntityModel;
	}

	// Token: 0x06006390 RID: 25488 RVA: 0x0018F440 File Offset: 0x0018D640
	[return: Nullable(2)]
	public new static IPinballBattleCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		if (!componentDataMap.ContainsKey("SimpleCombatComponentPb") || !componentDataMap.ContainsKey("ActivityComponentPb"))
		{
			return null;
		}
		EntityComponentPb entityComponentPb;
		if (!componentDataMap.TryGetValue("ActivityComponentPb", out entityComponentPb) || ((entityComponentPb != null) ? entityComponentPb.ActivityComponentPb : null) == null)
		{
			return null;
		}
		PinballBattleActivityEntityModel pinballBattleActivityEntityModel = PinballBattleActivityEntityModel.ActivityEntityPool.Get();
		if (pinballBattleActivityEntityModel == null)
		{
			pinballBattleActivityEntityModel = PinballBattleActivityEntityModel.ActivityEntityPool.Create();
		}
		if (pinballBattleActivityEntityModel != null)
		{
			pinballBattleActivityEntityModel.InitFromProto(entityData, componentDataMap);
		}
		return pinballBattleActivityEntityModel;
	}

	// Token: 0x06006391 RID: 25489 RVA: 0x0018F4AD File Offset: 0x0018D6AD
	public new static void Clear()
	{
		PinballBattleActivityEntityModel.ActivityEntityPool.Clear();
	}

	// Token: 0x06006392 RID: 25490 RVA: 0x0018F4BC File Offset: 0x0018D6BC
	protected override void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		base.InitFromProto(entityData, componentDataMap);
		ActivityComponentPb activityComponentPb = componentDataMap["ActivityComponentPb"].ActivityComponentPb;
		this.ConfigId = activityComponentPb.ConfigId;
	}

	// Token: 0x06006393 RID: 25491 RVA: 0x0018F4F0 File Offset: 0x0018D6F0
	public override void Update(IPinballBattleCombatInfo other)
	{
		base.Update(other);
		IPinballBattleActivityEntityInfo pinballBattleActivityEntityInfo = (IPinballBattleActivityEntityInfo)other;
		this.ConfigId = pinballBattleActivityEntityInfo.ConfigId;
		this.DeathType = pinballBattleActivityEntityInfo.DeathType;
	}

	// Token: 0x06006394 RID: 25492 RVA: 0x0018F523 File Offset: 0x0018D723
	public override void Reset()
	{
		base.Reset();
		this.ConfigId = 0;
		this.DeathType = EPinballBattleMonsterDeathType.Normal;
	}

	// Token: 0x06006395 RID: 25493 RVA: 0x0018F539 File Offset: 0x0018D739
	public override void Release()
	{
		this.Reset();
		PinballBattleActivityEntityModel.ActivityEntityPool.Put(this);
	}

	// Token: 0x06006396 RID: 25494 RVA: 0x0018F550 File Offset: 0x0018D750
	public override IPinballBattleCombatInfo Clone()
	{
		PinballBattleActivityEntityModel pinballBattleActivityEntityModel = PinballBattleActivityEntityModel.ActivityEntityPool.Get();
		if (pinballBattleActivityEntityModel == null)
		{
			pinballBattleActivityEntityModel = PinballBattleActivityEntityModel.ActivityEntityPool.Create();
		}
		if (pinballBattleActivityEntityModel != null)
		{
			pinballBattleActivityEntityModel.Update(this);
		}
		return pinballBattleActivityEntityModel;
	}

	// Token: 0x04002FA1 RID: 12193
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<PinballBattleActivityEntityModel> ActivityEntityPool;
}
