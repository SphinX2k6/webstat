using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F63 RID: 3939
[NullableContext(2)]
[Nullable(0)]
public class PinballBattleEntityModel : PinballBattleEntityBaseModel, IPinballBattleCombatInfo, IStaticVariableResetter
{
	// Token: 0x17000776 RID: 1910
	// (get) Token: 0x06006360 RID: 25440 RVA: 0x0018EEA2 File Offset: 0x0018D0A2
	// (set) Token: 0x06006361 RID: 25441 RVA: 0x0018EEAA File Offset: 0x0018D0AA
	public EPinballBattleEntityType EntityType { get; set; }

	// Token: 0x17000777 RID: 1911
	// (get) Token: 0x06006362 RID: 25442 RVA: 0x0018EEB3 File Offset: 0x0018D0B3
	// (set) Token: 0x06006363 RID: 25443 RVA: 0x0018EEBB File Offset: 0x0018D0BB
	public int Uid { get; set; }

	// Token: 0x17000778 RID: 1912
	// (get) Token: 0x06006364 RID: 25444 RVA: 0x0018EEC4 File Offset: 0x0018D0C4
	// (set) Token: 0x06006365 RID: 25445 RVA: 0x0018EECC File Offset: 0x0018D0CC
	public int OwnerId { get; set; }

	// Token: 0x17000779 RID: 1913
	// (get) Token: 0x06006366 RID: 25446 RVA: 0x0018EED5 File Offset: 0x0018D0D5
	// (set) Token: 0x06006367 RID: 25447 RVA: 0x0018EEDD File Offset: 0x0018D0DD
	public int TemplateId { get; set; }

	// Token: 0x1700077A RID: 1914
	// (get) Token: 0x06006368 RID: 25448 RVA: 0x0018EEE6 File Offset: 0x0018D0E6
	// (set) Token: 0x06006369 RID: 25449 RVA: 0x0018EEEE File Offset: 0x0018D0EE
	public int CombatId { get; set; }

	// Token: 0x1700077B RID: 1915
	// (get) Token: 0x0600636A RID: 25450 RVA: 0x0018EEF7 File Offset: 0x0018D0F7
	// (set) Token: 0x0600636B RID: 25451 RVA: 0x0018EEFF File Offset: 0x0018D0FF
	public int SubTypeId { get; set; }

	// Token: 0x1700077C RID: 1916
	// (get) Token: 0x0600636C RID: 25452 RVA: 0x0018EF08 File Offset: 0x0018D108
	// (set) Token: 0x0600636D RID: 25453 RVA: 0x0018EF10 File Offset: 0x0018D110
	public string PrefabPath { get; set; }

	// Token: 0x1700077D RID: 1917
	// (get) Token: 0x0600636E RID: 25454 RVA: 0x0018EF19 File Offset: 0x0018D119
	// (set) Token: 0x0600636F RID: 25455 RVA: 0x0018EF21 File Offset: 0x0018D121
	public string AssetPath { get; set; }

	// Token: 0x1700077E RID: 1918
	// (get) Token: 0x06006370 RID: 25456 RVA: 0x0018EF2A File Offset: 0x0018D12A
	// (set) Token: 0x06006371 RID: 25457 RVA: 0x0018EF32 File Offset: 0x0018D132
	public int PropertyId { get; set; }

	// Token: 0x1700077F RID: 1919
	// (get) Token: 0x06006372 RID: 25458 RVA: 0x0018EF3B File Offset: 0x0018D13B
	// (set) Token: 0x06006373 RID: 25459 RVA: 0x0018EF43 File Offset: 0x0018D143
	public int? SplineId { get; set; }

	// Token: 0x17000780 RID: 1920
	// (get) Token: 0x06006374 RID: 25460 RVA: 0x0018EF4C File Offset: 0x0018D14C
	// (set) Token: 0x06006375 RID: 25461 RVA: 0x0018EF54 File Offset: 0x0018D154
	public Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x17000781 RID: 1921
	// (get) Token: 0x06006376 RID: 25462 RVA: 0x0018EF5D File Offset: 0x0018D15D
	// (set) Token: 0x06006377 RID: 25463 RVA: 0x0018EF65 File Offset: 0x0018D165
	public Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x17000782 RID: 1922
	// (get) Token: 0x06006378 RID: 25464 RVA: 0x0018EF6E File Offset: 0x0018D16E
	// (set) Token: 0x06006379 RID: 25465 RVA: 0x0018EF76 File Offset: 0x0018D176
	[Nullable(1)]
	public global::Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000783 RID: 1923
	// (get) Token: 0x0600637A RID: 25466 RVA: 0x0018EF7F File Offset: 0x0018D17F
	// (set) Token: 0x0600637B RID: 25467 RVA: 0x0018EF87 File Offset: 0x0018D187
	[Nullable(1)]
	public global::Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x0600637C RID: 25468 RVA: 0x0018EF90 File Offset: 0x0018D190
	public PinballBattleEntityModel()
	{
		this.Position = global::Vector.Create(0.0, 0.0, 0.0);
		this.Rotation = global::Rotator.Create(0f, 0f, 0f);
	}

	// Token: 0x0600637D RID: 25469 RVA: 0x0018EFE3 File Offset: 0x0018D1E3
	static PinballBattleEntityModel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PinballBattleEntityModel.CreateStaticDefaultValue), new Action(PinballBattleEntityModel.ResetStaticDefaultValue));
	}

	// Token: 0x0600637E RID: 25470 RVA: 0x0018F002 File Offset: 0x0018D202
	public static void CreateStaticDefaultValue()
	{
		PinballBattleEntityModel.EntityPool = new Pool<PinballBattleEntityModel>(100, () => new PinballBattleEntityModel(), null);
	}

	// Token: 0x0600637F RID: 25471 RVA: 0x0018F030 File Offset: 0x0018D230
	public static void ResetStaticDefaultValue()
	{
		PinballBattleEntityModel.EntityPool = null;
	}

	// Token: 0x06006380 RID: 25472 RVA: 0x0018F038 File Offset: 0x0018D238
	[NullableContext(1)]
	[return: Nullable(2)]
	public new static IPinballBattleCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		if (!componentDataMap.ContainsKey("SimpleCombatComponentPb"))
		{
			return null;
		}
		PinballBattleEntityModel pinballBattleEntityModel = PinballBattleEntityModel.EntityPool.Get();
		if (pinballBattleEntityModel == null)
		{
			pinballBattleEntityModel = PinballBattleEntityModel.EntityPool.Create();
		}
		if (pinballBattleEntityModel != null)
		{
			pinballBattleEntityModel.InitFromProto(entityData, componentDataMap);
		}
		return pinballBattleEntityModel;
	}

	// Token: 0x06006381 RID: 25473 RVA: 0x0018F079 File Offset: 0x0018D279
	public new static void Clear()
	{
		PinballBattleEntityModel.EntityPool.Clear();
	}

	// Token: 0x06006382 RID: 25474 RVA: 0x0018F088 File Offset: 0x0018D288
	[NullableContext(1)]
	protected virtual void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		SimpleCombatComponentPb simpleCombatComponentPb = componentDataMap["SimpleCombatComponentPb"].SimpleCombatComponentPb;
		this.Uid = (int)Singleton<MathUtils>.Instance.LongToNumber(entityData.Id);
		this.OwnerId = (int)Singleton<MathUtils>.Instance.LongToNumber(entityData.OwnerIncId);
		this.TemplateId = entityData.ConfigId;
		this.CombatId = 0;
		this.SubTypeId = simpleCombatComponentPb.SubTypeId;
		this.PrefabPath = null;
		this.AssetPath = null;
		this.PropertyId = 0;
		this.SplineId = ((simpleCombatComponentPb.SplineConfigId != 0) ? new int?(simpleCombatComponentPb.SplineConfigId) : null);
		this.BuffIdLayers = ((simpleCombatComponentPb.BuffLayers != null) ? new Dictionary<int, int>(simpleCombatComponentPb.BuffLayers) : null);
		this.AttributeMap = ((simpleCombatComponentPb.AttributeMap != null) ? new Dictionary<int, int>(simpleCombatComponentPb.AttributeMap) : null);
		Aki.Protocol.Vector pos = entityData.Pos;
		if (pos != null)
		{
			this.Position.Set((double)(-(double)pos.X), (double)pos.Y, (double)pos.Z);
		}
		Aki.Protocol.Rotator rot = entityData.Rot;
		if (rot != null)
		{
			this.Rotation.Set(rot.Pitch, rot.Yaw, rot.Roll);
		}
	}

	// Token: 0x06006383 RID: 25475 RVA: 0x0018F1B8 File Offset: 0x0018D3B8
	[NullableContext(1)]
	public virtual void Update(IPinballBattleCombatInfo other)
	{
		this.Uid = other.Uid;
		this.OwnerId = other.OwnerId;
		this.TemplateId = other.TemplateId;
		this.CombatId = other.CombatId;
		this.SubTypeId = other.SubTypeId;
		this.PrefabPath = other.PrefabPath;
		this.AssetPath = other.AssetPath;
		this.PropertyId = other.PropertyId;
		this.SplineId = other.SplineId;
		this.BuffIdLayers = other.BuffIdLayers;
		this.AttributeMap = other.AttributeMap;
		this.Position.Set(other.Position.X, other.Position.Y, other.Position.Z);
		this.Rotation.Set(other.Rotation.Pitch, other.Rotation.Yaw, other.Rotation.Roll);
	}

	// Token: 0x06006384 RID: 25476 RVA: 0x0018F2A1 File Offset: 0x0018D4A1
	public bool IsValid()
	{
		return this.Uid > 0;
	}

	// Token: 0x06006385 RID: 25477 RVA: 0x0018F2AC File Offset: 0x0018D4AC
	public virtual void Reset()
	{
		this.Uid = 0;
		this.OwnerId = 0;
		this.TemplateId = 0;
		this.CombatId = 0;
		this.SubTypeId = 0;
		this.PrefabPath = null;
		this.AssetPath = null;
		this.PropertyId = 0;
		this.SplineId = null;
		this.BuffIdLayers = null;
		this.AttributeMap = null;
		this.Position.Set(0.0, 0.0, 0.0);
		this.Rotation.Set(0f, 0f, 0f);
	}

	// Token: 0x06006386 RID: 25478 RVA: 0x0018F34E File Offset: 0x0018D54E
	public virtual void Release()
	{
		this.Reset();
		PinballBattleEntityModel.EntityPool.Put(this);
	}

	// Token: 0x06006387 RID: 25479 RVA: 0x0018F364 File Offset: 0x0018D564
	[NullableContext(1)]
	public virtual IPinballBattleCombatInfo Clone()
	{
		PinballBattleEntityModel pinballBattleEntityModel = PinballBattleEntityModel.EntityPool.Get();
		if (pinballBattleEntityModel == null)
		{
			pinballBattleEntityModel = PinballBattleEntityModel.EntityPool.Create();
		}
		if (pinballBattleEntityModel != null)
		{
			pinballBattleEntityModel.Update(this);
		}
		return pinballBattleEntityModel;
	}

	// Token: 0x04002F9E RID: 12190
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<PinballBattleEntityModel> EntityPool;
}
