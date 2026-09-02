using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F70 RID: 3952
[NullableContext(2)]
[Nullable(0)]
public class PotatoEntityModel : PotatoEntityBaseModel, IPotatoCombatInfo, IStaticVariableResetter
{
	// Token: 0x1700079E RID: 1950
	// (get) Token: 0x060063E6 RID: 25574 RVA: 0x0018FC62 File Offset: 0x0018DE62
	// (set) Token: 0x060063E7 RID: 25575 RVA: 0x0018FC6A File Offset: 0x0018DE6A
	public EPotatoEntityType EntityType { get; set; }

	// Token: 0x1700079F RID: 1951
	// (get) Token: 0x060063E8 RID: 25576 RVA: 0x0018FC73 File Offset: 0x0018DE73
	// (set) Token: 0x060063E9 RID: 25577 RVA: 0x0018FC7B File Offset: 0x0018DE7B
	public int Uid { get; set; }

	// Token: 0x170007A0 RID: 1952
	// (get) Token: 0x060063EA RID: 25578 RVA: 0x0018FC84 File Offset: 0x0018DE84
	// (set) Token: 0x060063EB RID: 25579 RVA: 0x0018FC8C File Offset: 0x0018DE8C
	public int OwnerId { get; set; }

	// Token: 0x170007A1 RID: 1953
	// (get) Token: 0x060063EC RID: 25580 RVA: 0x0018FC95 File Offset: 0x0018DE95
	// (set) Token: 0x060063ED RID: 25581 RVA: 0x0018FC9D File Offset: 0x0018DE9D
	public int TemplateId { get; set; }

	// Token: 0x170007A2 RID: 1954
	// (get) Token: 0x060063EE RID: 25582 RVA: 0x0018FCA6 File Offset: 0x0018DEA6
	// (set) Token: 0x060063EF RID: 25583 RVA: 0x0018FCAE File Offset: 0x0018DEAE
	public int CombatId { get; set; }

	// Token: 0x170007A3 RID: 1955
	// (get) Token: 0x060063F0 RID: 25584 RVA: 0x0018FCB7 File Offset: 0x0018DEB7
	// (set) Token: 0x060063F1 RID: 25585 RVA: 0x0018FCBF File Offset: 0x0018DEBF
	public int SubTypeId { get; set; }

	// Token: 0x170007A4 RID: 1956
	// (get) Token: 0x060063F2 RID: 25586 RVA: 0x0018FCC8 File Offset: 0x0018DEC8
	// (set) Token: 0x060063F3 RID: 25587 RVA: 0x0018FCD0 File Offset: 0x0018DED0
	public string PrefabPath { get; set; }

	// Token: 0x170007A5 RID: 1957
	// (get) Token: 0x060063F4 RID: 25588 RVA: 0x0018FCD9 File Offset: 0x0018DED9
	// (set) Token: 0x060063F5 RID: 25589 RVA: 0x0018FCE1 File Offset: 0x0018DEE1
	public string AssetPath { get; set; }

	// Token: 0x170007A6 RID: 1958
	// (get) Token: 0x060063F6 RID: 25590 RVA: 0x0018FCEA File Offset: 0x0018DEEA
	// (set) Token: 0x060063F7 RID: 25591 RVA: 0x0018FCF2 File Offset: 0x0018DEF2
	public int PropertyId { get; set; }

	// Token: 0x170007A7 RID: 1959
	// (get) Token: 0x060063F8 RID: 25592 RVA: 0x0018FCFB File Offset: 0x0018DEFB
	// (set) Token: 0x060063F9 RID: 25593 RVA: 0x0018FD03 File Offset: 0x0018DF03
	public int? SplineId { get; set; }

	// Token: 0x170007A8 RID: 1960
	// (get) Token: 0x060063FA RID: 25594 RVA: 0x0018FD0C File Offset: 0x0018DF0C
	// (set) Token: 0x060063FB RID: 25595 RVA: 0x0018FD14 File Offset: 0x0018DF14
	public Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x170007A9 RID: 1961
	// (get) Token: 0x060063FC RID: 25596 RVA: 0x0018FD1D File Offset: 0x0018DF1D
	// (set) Token: 0x060063FD RID: 25597 RVA: 0x0018FD25 File Offset: 0x0018DF25
	public Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x170007AA RID: 1962
	// (get) Token: 0x060063FE RID: 25598 RVA: 0x0018FD2E File Offset: 0x0018DF2E
	// (set) Token: 0x060063FF RID: 25599 RVA: 0x0018FD36 File Offset: 0x0018DF36
	[Nullable(1)]
	public global::Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170007AB RID: 1963
	// (get) Token: 0x06006400 RID: 25600 RVA: 0x0018FD3F File Offset: 0x0018DF3F
	// (set) Token: 0x06006401 RID: 25601 RVA: 0x0018FD47 File Offset: 0x0018DF47
	[Nullable(1)]
	public global::Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x06006402 RID: 25602 RVA: 0x0018FD50 File Offset: 0x0018DF50
	public PotatoEntityModel()
	{
		this.Position = global::Vector.Create(0.0, 0.0, 0.0);
		this.Rotation = global::Rotator.Create(0f, 0f, 0f);
	}

	// Token: 0x06006403 RID: 25603 RVA: 0x0018FDA3 File Offset: 0x0018DFA3
	static PotatoEntityModel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PotatoEntityModel.CreateStaticDefaultValue), new Action(PotatoEntityModel.ResetStaticDefaultValue));
	}

	// Token: 0x06006404 RID: 25604 RVA: 0x0018FDC2 File Offset: 0x0018DFC2
	public static void CreateStaticDefaultValue()
	{
		PotatoEntityModel.EntityPool = new Pool<PotatoEntityModel>(100, () => new PotatoEntityModel(), null);
	}

	// Token: 0x06006405 RID: 25605 RVA: 0x0018FDF0 File Offset: 0x0018DFF0
	public static void ResetStaticDefaultValue()
	{
		PotatoEntityModel.EntityPool = null;
	}

	// Token: 0x06006406 RID: 25606 RVA: 0x0018FDF8 File Offset: 0x0018DFF8
	[NullableContext(1)]
	[return: Nullable(2)]
	public new static IPotatoCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		if (!componentDataMap.ContainsKey("SimpleCombatComponentPb"))
		{
			return null;
		}
		PotatoEntityModel potatoEntityModel = PotatoEntityModel.EntityPool.Get();
		if (potatoEntityModel == null)
		{
			potatoEntityModel = PotatoEntityModel.EntityPool.Create();
		}
		if (potatoEntityModel != null)
		{
			potatoEntityModel.InitFromProto(entityData, componentDataMap);
		}
		return potatoEntityModel;
	}

	// Token: 0x06006407 RID: 25607 RVA: 0x0018FE39 File Offset: 0x0018E039
	public new static void Clear()
	{
		PotatoEntityModel.EntityPool.Clear();
	}

	// Token: 0x06006408 RID: 25608 RVA: 0x0018FE48 File Offset: 0x0018E048
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

	// Token: 0x06006409 RID: 25609 RVA: 0x0018FF78 File Offset: 0x0018E178
	[NullableContext(1)]
	public virtual void Update(IPotatoCombatInfo other)
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

	// Token: 0x0600640A RID: 25610 RVA: 0x00190061 File Offset: 0x0018E261
	public bool IsValid()
	{
		return this.Uid > 0;
	}

	// Token: 0x0600640B RID: 25611 RVA: 0x0019006C File Offset: 0x0018E26C
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

	// Token: 0x0600640C RID: 25612 RVA: 0x0019010E File Offset: 0x0018E30E
	public virtual void Release()
	{
		this.Reset();
		PotatoEntityModel.EntityPool.Put(this);
	}

	// Token: 0x0600640D RID: 25613 RVA: 0x00190124 File Offset: 0x0018E324
	[NullableContext(1)]
	public virtual IPotatoCombatInfo Clone()
	{
		PotatoEntityModel potatoEntityModel = PotatoEntityModel.EntityPool.Get();
		if (potatoEntityModel == null)
		{
			potatoEntityModel = PotatoEntityModel.EntityPool.Create();
		}
		if (potatoEntityModel != null)
		{
			potatoEntityModel.Update(this);
		}
		return potatoEntityModel;
	}

	// Token: 0x04002FC7 RID: 12231
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<PotatoEntityModel> EntityPool;
}
