using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F71 RID: 3953
[NullableContext(2)]
[Nullable(0)]
public class PotatoActivityEntityModel : PotatoEntityModel, IPotatoActivityEntityInfo, IPotatoCombatInfo, IPotatoConfigInfo
{
	// Token: 0x170007AC RID: 1964
	// (get) Token: 0x0600640E RID: 25614 RVA: 0x00190155 File Offset: 0x0018E355
	// (set) Token: 0x0600640F RID: 25615 RVA: 0x0019015D File Offset: 0x0018E35D
	public int ConfigId { get; set; }

	// Token: 0x170007AD RID: 1965
	// (get) Token: 0x06006410 RID: 25616 RVA: 0x00190166 File Offset: 0x0018E366
	// (set) Token: 0x06006411 RID: 25617 RVA: 0x0019016E File Offset: 0x0018E36E
	public EPotatoMonsterDeathType DeathType { get; set; }

	// Token: 0x170007AE RID: 1966
	// (get) Token: 0x06006412 RID: 25618 RVA: 0x00190177 File Offset: 0x0018E377
	// (set) Token: 0x06006413 RID: 25619 RVA: 0x0019017F File Offset: 0x0018E37F
	public int BuffRadius { get; set; }

	// Token: 0x170007AF RID: 1967
	// (get) Token: 0x06006414 RID: 25620 RVA: 0x00190188 File Offset: 0x0018E388
	// (set) Token: 0x06006415 RID: 25621 RVA: 0x00190190 File Offset: 0x0018E390
	public int[] BuffIds { get; set; }

	// Token: 0x170007B0 RID: 1968
	// (get) Token: 0x06006416 RID: 25622 RVA: 0x00190199 File Offset: 0x0018E399
	// (set) Token: 0x06006417 RID: 25623 RVA: 0x001901A1 File Offset: 0x0018E3A1
	public int[] SpawnIds { get; set; }

	// Token: 0x170007B1 RID: 1969
	// (get) Token: 0x06006418 RID: 25624 RVA: 0x001901AA File Offset: 0x0018E3AA
	// (set) Token: 0x06006419 RID: 25625 RVA: 0x001901B2 File Offset: 0x0018E3B2
	public int PolluteRadius { get; set; }

	// Token: 0x170007B2 RID: 1970
	// (get) Token: 0x0600641A RID: 25626 RVA: 0x001901BB File Offset: 0x0018E3BB
	// (set) Token: 0x0600641B RID: 25627 RVA: 0x001901C3 File Offset: 0x0018E3C3
	public int IncId { get; set; }

	// Token: 0x170007B3 RID: 1971
	// (get) Token: 0x0600641C RID: 25628 RVA: 0x001901CC File Offset: 0x0018E3CC
	// (set) Token: 0x0600641D RID: 25629 RVA: 0x001901D4 File Offset: 0x0018E3D4
	public int SpawnConfigId { get; set; }

	// Token: 0x170007B4 RID: 1972
	// (get) Token: 0x0600641E RID: 25630 RVA: 0x001901DD File Offset: 0x0018E3DD
	// (set) Token: 0x0600641F RID: 25631 RVA: 0x001901E5 File Offset: 0x0018E3E5
	public int SpawnConfigGroupIndex { get; set; }

	// Token: 0x06006420 RID: 25632 RVA: 0x001901EE File Offset: 0x0018E3EE
	static PotatoActivityEntityModel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PotatoActivityEntityModel.CreateStaticDefaultValue), new Action(PotatoActivityEntityModel.ResetStaticDefaultValue));
	}

	// Token: 0x06006421 RID: 25633 RVA: 0x0019020D File Offset: 0x0018E40D
	public new static void CreateStaticDefaultValue()
	{
		PotatoActivityEntityModel.ActivityEntityPool = new Pool<PotatoActivityEntityModel>(100, () => new PotatoActivityEntityModel(), null);
	}

	// Token: 0x06006422 RID: 25634 RVA: 0x0019023B File Offset: 0x0018E43B
	public new static void ResetStaticDefaultValue()
	{
		PotatoActivityEntityModel.ActivityEntityPool = null;
	}

	// Token: 0x06006423 RID: 25635 RVA: 0x00190244 File Offset: 0x0018E444
	[NullableContext(1)]
	public static PotatoActivityEntityModel InitFromConfigId(int configId)
	{
		PotatoActivityEntityModel potatoActivityEntityModel = PotatoActivityEntityModel.ActivityEntityPool.Get();
		if (potatoActivityEntityModel == null)
		{
			potatoActivityEntityModel = PotatoActivityEntityModel.ActivityEntityPool.Create();
		}
		if (potatoActivityEntityModel != null)
		{
			potatoActivityEntityModel.ConfigId = configId;
		}
		return potatoActivityEntityModel;
	}

	// Token: 0x06006424 RID: 25636 RVA: 0x00190278 File Offset: 0x0018E478
	[NullableContext(1)]
	[return: Nullable(2)]
	public new static IPotatoCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
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
		PotatoActivityEntityModel potatoActivityEntityModel = PotatoActivityEntityModel.ActivityEntityPool.Get();
		if (potatoActivityEntityModel == null)
		{
			potatoActivityEntityModel = PotatoActivityEntityModel.ActivityEntityPool.Create();
		}
		if (potatoActivityEntityModel != null)
		{
			potatoActivityEntityModel.InitFromProto(entityData, componentDataMap);
		}
		return potatoActivityEntityModel;
	}

	// Token: 0x06006425 RID: 25637 RVA: 0x001902E5 File Offset: 0x0018E4E5
	public new static void Clear()
	{
		PotatoActivityEntityModel.ActivityEntityPool.Clear();
	}

	// Token: 0x06006426 RID: 25638 RVA: 0x001902F4 File Offset: 0x0018E4F4
	[NullableContext(1)]
	protected override void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		base.InitFromProto(entityData, componentDataMap);
		ActivityComponentPb activityComponentPb = componentDataMap["ActivityComponentPb"].ActivityComponentPb;
		this.ConfigId = activityComponentPb.ConfigId;
		if (activityComponentPb.KurotatoMonsterEntityPbData != null)
		{
			base.EntityType = EPotatoEntityType.Monster;
			this.DeathType = EPotatoMonsterDeathType.Normal;
			this.BuffRadius = 0;
			this.BuffIds = null;
			this.SpawnIds = null;
			this.PolluteRadius = 0;
			this.SpawnConfigId = activityComponentPb.KurotatoMonsterEntityPbData.SpawnConfigId;
			this.SpawnConfigGroupIndex = activityComponentPb.KurotatoMonsterEntityPbData.SpawnConfigGroupIndex;
			return;
		}
		if (activityComponentPb.KurotatoCharacterEntityPbData != null)
		{
			base.EntityType = EPotatoEntityType.PlayerCharacter;
			return;
		}
		if (activityComponentPb.KurotatoWeaponEntityPbData != null)
		{
			base.EntityType = EPotatoEntityType.Weapon;
			this.IncId = activityComponentPb.KurotatoWeaponEntityPbData.IncId;
			return;
		}
		if (activityComponentPb.KurotatoDropEntityPbData != null)
		{
			base.EntityType = EPotatoEntityType.GoldenCoin;
			return;
		}
		if (activityComponentPb.KurotatoStructureEntityPbData != null)
		{
			base.EntityType = EPotatoEntityType.Structure;
		}
	}

	// Token: 0x06006427 RID: 25639 RVA: 0x001903CC File Offset: 0x0018E5CC
	[NullableContext(1)]
	public override void Update(IPotatoCombatInfo other)
	{
		base.Update(other);
		IPotatoActivityEntityInfo potatoActivityEntityInfo = (IPotatoActivityEntityInfo)other;
		this.ConfigId = potatoActivityEntityInfo.ConfigId;
		this.DeathType = potatoActivityEntityInfo.DeathType;
		this.BuffRadius = potatoActivityEntityInfo.BuffRadius;
		this.BuffIds = potatoActivityEntityInfo.BuffIds;
		this.SpawnIds = potatoActivityEntityInfo.SpawnIds;
		this.PolluteRadius = potatoActivityEntityInfo.PolluteRadius;
		this.SpawnConfigId = potatoActivityEntityInfo.SpawnConfigId;
		this.SpawnConfigGroupIndex = potatoActivityEntityInfo.SpawnConfigGroupIndex;
	}

	// Token: 0x06006428 RID: 25640 RVA: 0x00190447 File Offset: 0x0018E647
	public override void Reset()
	{
		base.Reset();
		this.ConfigId = 0;
		this.DeathType = EPotatoMonsterDeathType.Normal;
		this.BuffRadius = 0;
		this.BuffIds = null;
		this.SpawnIds = null;
		this.PolluteRadius = 0;
		this.SpawnConfigId = 0;
		this.SpawnConfigGroupIndex = 0;
	}

	// Token: 0x06006429 RID: 25641 RVA: 0x00190487 File Offset: 0x0018E687
	public override void Release()
	{
		this.Reset();
		PotatoActivityEntityModel.ActivityEntityPool.Put(this);
	}

	// Token: 0x0600642A RID: 25642 RVA: 0x0019049C File Offset: 0x0018E69C
	[NullableContext(1)]
	public override IPotatoCombatInfo Clone()
	{
		PotatoActivityEntityModel potatoActivityEntityModel = PotatoActivityEntityModel.ActivityEntityPool.Get();
		if (potatoActivityEntityModel == null)
		{
			potatoActivityEntityModel = PotatoActivityEntityModel.ActivityEntityPool.Create();
		}
		if (potatoActivityEntityModel != null)
		{
			potatoActivityEntityModel.Update(this);
		}
		return potatoActivityEntityModel;
	}

	// Token: 0x04002FD1 RID: 12241
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<PotatoActivityEntityModel> ActivityEntityPool;
}
