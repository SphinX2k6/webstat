using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F84 RID: 3972
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueActivityEntityModel : SurvivorsRogueEntityModel, ISurvivorsRogueActivityEntityInfo, ISurvivorsRogueCombatInfo, ISurvivorsRogueConfigInfo
{
	// Token: 0x170007D8 RID: 2008
	// (get) Token: 0x060064E3 RID: 25827 RVA: 0x00193645 File Offset: 0x00191845
	// (set) Token: 0x060064E4 RID: 25828 RVA: 0x0019364D File Offset: 0x0019184D
	public int ConfigId { get; set; }

	// Token: 0x170007D9 RID: 2009
	// (get) Token: 0x060064E5 RID: 25829 RVA: 0x00193656 File Offset: 0x00191856
	// (set) Token: 0x060064E6 RID: 25830 RVA: 0x0019365E File Offset: 0x0019185E
	public ESurvivorsRogueMonsterDeathType DeathType { get; set; }

	// Token: 0x170007DA RID: 2010
	// (get) Token: 0x060064E7 RID: 25831 RVA: 0x00193667 File Offset: 0x00191867
	// (set) Token: 0x060064E8 RID: 25832 RVA: 0x0019366F File Offset: 0x0019186F
	public int BuffRadius { get; set; }

	// Token: 0x170007DB RID: 2011
	// (get) Token: 0x060064E9 RID: 25833 RVA: 0x00193678 File Offset: 0x00191878
	// (set) Token: 0x060064EA RID: 25834 RVA: 0x00193680 File Offset: 0x00191880
	public int[] BuffIds { get; set; }

	// Token: 0x170007DC RID: 2012
	// (get) Token: 0x060064EB RID: 25835 RVA: 0x00193689 File Offset: 0x00191889
	// (set) Token: 0x060064EC RID: 25836 RVA: 0x00193691 File Offset: 0x00191891
	public int[] SpawnIds { get; set; }

	// Token: 0x170007DD RID: 2013
	// (get) Token: 0x060064ED RID: 25837 RVA: 0x0019369A File Offset: 0x0019189A
	// (set) Token: 0x060064EE RID: 25838 RVA: 0x001936A2 File Offset: 0x001918A2
	public int PolluteRadius { get; set; }

	// Token: 0x060064EF RID: 25839 RVA: 0x001936AB File Offset: 0x001918AB
	static SurvivorsRogueActivityEntityModel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SurvivorsRogueActivityEntityModel.CreateStaticDefaultValue), new Action(SurvivorsRogueActivityEntityModel.ResetStaticDefaultValue));
	}

	// Token: 0x060064F0 RID: 25840 RVA: 0x001936CA File Offset: 0x001918CA
	public new static void CreateStaticDefaultValue()
	{
		SurvivorsRogueActivityEntityModel.ActivityEntityPool = new Pool<SurvivorsRogueActivityEntityModel>(100, () => new SurvivorsRogueActivityEntityModel(), null);
	}

	// Token: 0x060064F1 RID: 25841 RVA: 0x001936F8 File Offset: 0x001918F8
	public new static void ResetStaticDefaultValue()
	{
		SurvivorsRogueActivityEntityModel.ActivityEntityPool = null;
	}

	// Token: 0x060064F2 RID: 25842 RVA: 0x00193700 File Offset: 0x00191900
	[NullableContext(1)]
	public static SurvivorsRogueActivityEntityModel InitFromConfigId(int configId)
	{
		SurvivorsRogueActivityEntityModel survivorsRogueActivityEntityModel = SurvivorsRogueActivityEntityModel.ActivityEntityPool.Get();
		if (survivorsRogueActivityEntityModel == null)
		{
			survivorsRogueActivityEntityModel = SurvivorsRogueActivityEntityModel.ActivityEntityPool.Create();
		}
		if (survivorsRogueActivityEntityModel != null)
		{
			survivorsRogueActivityEntityModel.ConfigId = configId;
		}
		return survivorsRogueActivityEntityModel;
	}

	// Token: 0x060064F3 RID: 25843 RVA: 0x00193734 File Offset: 0x00191934
	[NullableContext(1)]
	[return: Nullable(2)]
	public new static ISurvivorsRogueCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
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
		SurvivorsRogueActivityEntityModel survivorsRogueActivityEntityModel = SurvivorsRogueActivityEntityModel.ActivityEntityPool.Get();
		if (survivorsRogueActivityEntityModel == null)
		{
			survivorsRogueActivityEntityModel = SurvivorsRogueActivityEntityModel.ActivityEntityPool.Create();
		}
		if (survivorsRogueActivityEntityModel != null)
		{
			survivorsRogueActivityEntityModel.InitFromProto(entityData, componentDataMap);
		}
		return survivorsRogueActivityEntityModel;
	}

	// Token: 0x060064F4 RID: 25844 RVA: 0x001937A1 File Offset: 0x001919A1
	public new static void Clear()
	{
		SurvivorsRogueActivityEntityModel.ActivityEntityPool.Clear();
	}

	// Token: 0x060064F5 RID: 25845 RVA: 0x001937B0 File Offset: 0x001919B0
	[NullableContext(1)]
	protected override void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		base.InitFromProto(entityData, componentDataMap);
		ActivityComponentPb activityComponentPb = componentDataMap["ActivityComponentPb"].ActivityComponentPb;
		this.ConfigId = activityComponentPb.ConfigId;
		if (activityComponentPb.SurvivorsMonsterPbData != null)
		{
			base.EntityType = ESurvivorsRogueEntityType.Monster;
			this.DeathType = ESurvivorsRogueMonsterDeathType.Normal;
			this.BuffRadius = 0;
			this.BuffIds = null;
			this.SpawnIds = null;
			this.PolluteRadius = 0;
			return;
		}
		if (activityComponentPb.SurvivorsPlayerCharacterPbData != null)
		{
			base.EntityType = ESurvivorsRogueEntityType.PlayerCharacter;
			return;
		}
		if (activityComponentPb.SurvivorsWeaponPbData != null)
		{
			base.EntityType = ESurvivorsRogueEntityType.Weapon;
			return;
		}
		if (activityComponentPb.SurvivorsGoldenCoinPbData != null)
		{
			base.EntityType = ESurvivorsRogueEntityType.GoldenCoin;
		}
	}

	// Token: 0x060064F6 RID: 25846 RVA: 0x00193844 File Offset: 0x00191A44
	[NullableContext(1)]
	public override void Update(ISurvivorsRogueCombatInfo other)
	{
		base.Update(other);
		ISurvivorsRogueActivityEntityInfo survivorsRogueActivityEntityInfo = (ISurvivorsRogueActivityEntityInfo)other;
		this.ConfigId = survivorsRogueActivityEntityInfo.ConfigId;
		this.DeathType = survivorsRogueActivityEntityInfo.DeathType;
		this.BuffRadius = survivorsRogueActivityEntityInfo.BuffRadius;
		this.BuffIds = survivorsRogueActivityEntityInfo.BuffIds;
		this.SpawnIds = survivorsRogueActivityEntityInfo.SpawnIds;
		this.PolluteRadius = survivorsRogueActivityEntityInfo.PolluteRadius;
	}

	// Token: 0x060064F7 RID: 25847 RVA: 0x001938A7 File Offset: 0x00191AA7
	public new virtual void Reset()
	{
		base.Reset();
		this.ConfigId = 0;
		this.DeathType = ESurvivorsRogueMonsterDeathType.Normal;
		this.BuffRadius = 0;
		this.BuffIds = null;
		this.SpawnIds = null;
		this.PolluteRadius = 0;
	}

	// Token: 0x060064F8 RID: 25848 RVA: 0x001938D9 File Offset: 0x00191AD9
	public new virtual void Release()
	{
		this.Reset();
		SurvivorsRogueActivityEntityModel.ActivityEntityPool.Put(this);
	}

	// Token: 0x060064F9 RID: 25849 RVA: 0x001938F0 File Offset: 0x00191AF0
	[NullableContext(1)]
	public new ISurvivorsRogueCombatInfo Clone()
	{
		SurvivorsRogueActivityEntityModel survivorsRogueActivityEntityModel = SurvivorsRogueActivityEntityModel.ActivityEntityPool.Get();
		if (survivorsRogueActivityEntityModel == null)
		{
			survivorsRogueActivityEntityModel = SurvivorsRogueActivityEntityModel.ActivityEntityPool.Create();
		}
		if (survivorsRogueActivityEntityModel != null)
		{
			survivorsRogueActivityEntityModel.Update(this);
		}
		return survivorsRogueActivityEntityModel;
	}

	// Token: 0x0400301D RID: 12317
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<SurvivorsRogueActivityEntityModel> ActivityEntityPool;
}
