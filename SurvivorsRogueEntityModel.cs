using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F83 RID: 3971
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueEntityModel : SurvivorsRogueEntityBaseModel, ISurvivorsRogueCombatInfo, IStaticVariableResetter
{
	// Token: 0x170007CA RID: 1994
	// (get) Token: 0x060064BB RID: 25787 RVA: 0x00193150 File Offset: 0x00191350
	// (set) Token: 0x060064BC RID: 25788 RVA: 0x00193158 File Offset: 0x00191358
	public ESurvivorsRogueEntityType EntityType { get; set; }

	// Token: 0x170007CB RID: 1995
	// (get) Token: 0x060064BD RID: 25789 RVA: 0x00193161 File Offset: 0x00191361
	// (set) Token: 0x060064BE RID: 25790 RVA: 0x00193169 File Offset: 0x00191369
	public int Uid { get; set; }

	// Token: 0x170007CC RID: 1996
	// (get) Token: 0x060064BF RID: 25791 RVA: 0x00193172 File Offset: 0x00191372
	// (set) Token: 0x060064C0 RID: 25792 RVA: 0x0019317A File Offset: 0x0019137A
	public int OwnerId { get; set; }

	// Token: 0x170007CD RID: 1997
	// (get) Token: 0x060064C1 RID: 25793 RVA: 0x00193183 File Offset: 0x00191383
	// (set) Token: 0x060064C2 RID: 25794 RVA: 0x0019318B File Offset: 0x0019138B
	public int TemplateId { get; set; }

	// Token: 0x170007CE RID: 1998
	// (get) Token: 0x060064C3 RID: 25795 RVA: 0x00193194 File Offset: 0x00191394
	// (set) Token: 0x060064C4 RID: 25796 RVA: 0x0019319C File Offset: 0x0019139C
	public int CombatId { get; set; }

	// Token: 0x170007CF RID: 1999
	// (get) Token: 0x060064C5 RID: 25797 RVA: 0x001931A5 File Offset: 0x001913A5
	// (set) Token: 0x060064C6 RID: 25798 RVA: 0x001931AD File Offset: 0x001913AD
	public int SubTypeId { get; set; }

	// Token: 0x170007D0 RID: 2000
	// (get) Token: 0x060064C7 RID: 25799 RVA: 0x001931B6 File Offset: 0x001913B6
	// (set) Token: 0x060064C8 RID: 25800 RVA: 0x001931BE File Offset: 0x001913BE
	public string PrefabPath { get; set; }

	// Token: 0x170007D1 RID: 2001
	// (get) Token: 0x060064C9 RID: 25801 RVA: 0x001931C7 File Offset: 0x001913C7
	// (set) Token: 0x060064CA RID: 25802 RVA: 0x001931CF File Offset: 0x001913CF
	public string AssetPath { get; set; }

	// Token: 0x170007D2 RID: 2002
	// (get) Token: 0x060064CB RID: 25803 RVA: 0x001931D8 File Offset: 0x001913D8
	// (set) Token: 0x060064CC RID: 25804 RVA: 0x001931E0 File Offset: 0x001913E0
	public int PropertyId { get; set; }

	// Token: 0x170007D3 RID: 2003
	// (get) Token: 0x060064CD RID: 25805 RVA: 0x001931E9 File Offset: 0x001913E9
	// (set) Token: 0x060064CE RID: 25806 RVA: 0x001931F1 File Offset: 0x001913F1
	public int? SplineId { get; set; }

	// Token: 0x170007D4 RID: 2004
	// (get) Token: 0x060064CF RID: 25807 RVA: 0x001931FA File Offset: 0x001913FA
	// (set) Token: 0x060064D0 RID: 25808 RVA: 0x00193202 File Offset: 0x00191402
	public Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x170007D5 RID: 2005
	// (get) Token: 0x060064D1 RID: 25809 RVA: 0x0019320B File Offset: 0x0019140B
	// (set) Token: 0x060064D2 RID: 25810 RVA: 0x00193213 File Offset: 0x00191413
	public Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x170007D6 RID: 2006
	// (get) Token: 0x060064D3 RID: 25811 RVA: 0x0019321C File Offset: 0x0019141C
	// (set) Token: 0x060064D4 RID: 25812 RVA: 0x00193224 File Offset: 0x00191424
	[Nullable(1)]
	public global::Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170007D7 RID: 2007
	// (get) Token: 0x060064D5 RID: 25813 RVA: 0x0019322D File Offset: 0x0019142D
	// (set) Token: 0x060064D6 RID: 25814 RVA: 0x00193235 File Offset: 0x00191435
	[Nullable(1)]
	public global::Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x060064D7 RID: 25815 RVA: 0x00193240 File Offset: 0x00191440
	public SurvivorsRogueEntityModel()
	{
		this.Position = global::Vector.Create(0.0, 0.0, 0.0);
		this.Rotation = global::Rotator.Create(0f, 0f, 0f);
	}

	// Token: 0x060064D8 RID: 25816 RVA: 0x00193293 File Offset: 0x00191493
	static SurvivorsRogueEntityModel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SurvivorsRogueEntityModel.CreateStaticDefaultValue), new Action(SurvivorsRogueEntityModel.ResetStaticDefaultValue));
	}

	// Token: 0x060064D9 RID: 25817 RVA: 0x001932B2 File Offset: 0x001914B2
	public static void CreateStaticDefaultValue()
	{
		SurvivorsRogueEntityModel.EntityPool = new Pool<SurvivorsRogueEntityModel>(100, () => new SurvivorsRogueEntityModel(), null);
	}

	// Token: 0x060064DA RID: 25818 RVA: 0x001932E0 File Offset: 0x001914E0
	public static void ResetStaticDefaultValue()
	{
		SurvivorsRogueEntityModel.EntityPool = null;
	}

	// Token: 0x060064DB RID: 25819 RVA: 0x001932E8 File Offset: 0x001914E8
	[NullableContext(1)]
	[return: Nullable(2)]
	public new static ISurvivorsRogueCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		if (!componentDataMap.ContainsKey("SimpleCombatComponentPb"))
		{
			return null;
		}
		SurvivorsRogueEntityModel survivorsRogueEntityModel = SurvivorsRogueEntityModel.EntityPool.Get();
		if (survivorsRogueEntityModel == null)
		{
			survivorsRogueEntityModel = SurvivorsRogueEntityModel.EntityPool.Create();
		}
		if (survivorsRogueEntityModel != null)
		{
			survivorsRogueEntityModel.InitFromProto(entityData, componentDataMap);
		}
		return survivorsRogueEntityModel;
	}

	// Token: 0x060064DC RID: 25820 RVA: 0x00193329 File Offset: 0x00191529
	public new static void Clear()
	{
		SurvivorsRogueEntityModel.EntityPool.Clear();
	}

	// Token: 0x060064DD RID: 25821 RVA: 0x00193338 File Offset: 0x00191538
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
			this.Position.Set((double)pos.X, (double)pos.Y, (double)pos.Z);
		}
		Aki.Protocol.Rotator rot = entityData.Rot;
		if (rot != null)
		{
			this.Rotation.Set(rot.Pitch, rot.Yaw, rot.Roll);
		}
	}

	// Token: 0x060064DE RID: 25822 RVA: 0x00193468 File Offset: 0x00191668
	[NullableContext(1)]
	public virtual void Update(ISurvivorsRogueCombatInfo other)
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

	// Token: 0x060064DF RID: 25823 RVA: 0x00193551 File Offset: 0x00191751
	public bool IsValid()
	{
		return this.Uid > 0;
	}

	// Token: 0x060064E0 RID: 25824 RVA: 0x0019355C File Offset: 0x0019175C
	public void Reset()
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

	// Token: 0x060064E1 RID: 25825 RVA: 0x001935FE File Offset: 0x001917FE
	public void Release()
	{
		this.Reset();
		SurvivorsRogueEntityModel.EntityPool.Put(this);
	}

	// Token: 0x060064E2 RID: 25826 RVA: 0x00193614 File Offset: 0x00191814
	[NullableContext(1)]
	public ISurvivorsRogueCombatInfo Clone()
	{
		SurvivorsRogueEntityModel survivorsRogueEntityModel = SurvivorsRogueEntityModel.EntityPool.Get();
		if (survivorsRogueEntityModel == null)
		{
			survivorsRogueEntityModel = SurvivorsRogueEntityModel.EntityPool.Create();
		}
		if (survivorsRogueEntityModel != null)
		{
			survivorsRogueEntityModel.Update(this);
		}
		return survivorsRogueEntityModel;
	}

	// Token: 0x04003016 RID: 12310
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<SurvivorsRogueEntityModel> EntityPool;
}
