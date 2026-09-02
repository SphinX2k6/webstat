using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02000F2B RID: 3883
[NullableContext(2)]
[Nullable(0)]
public class FinalBattleEntityModel : IFinalBattleActivityEntityInfo, IFinalBattleCombatInfo, IStaticVariableResetter
{
	// Token: 0x17000712 RID: 1810
	// (get) Token: 0x060060D2 RID: 24786 RVA: 0x00183A80 File Offset: 0x00181C80
	// (set) Token: 0x060060D3 RID: 24787 RVA: 0x00183A88 File Offset: 0x00181C88
	public EFinalBattleEntityType EntityType { get; set; } = EFinalBattleEntityType.Monster;

	// Token: 0x17000713 RID: 1811
	// (get) Token: 0x060060D4 RID: 24788 RVA: 0x00183A91 File Offset: 0x00181C91
	// (set) Token: 0x060060D5 RID: 24789 RVA: 0x00183A99 File Offset: 0x00181C99
	public int Uid { get; set; }

	// Token: 0x17000714 RID: 1812
	// (get) Token: 0x060060D6 RID: 24790 RVA: 0x00183AA2 File Offset: 0x00181CA2
	// (set) Token: 0x060060D7 RID: 24791 RVA: 0x00183AAA File Offset: 0x00181CAA
	public int OwnerId { get; set; }

	// Token: 0x17000715 RID: 1813
	// (get) Token: 0x060060D8 RID: 24792 RVA: 0x00183AB3 File Offset: 0x00181CB3
	// (set) Token: 0x060060D9 RID: 24793 RVA: 0x00183ABB File Offset: 0x00181CBB
	public int TemplateId { get; set; }

	// Token: 0x17000716 RID: 1814
	// (get) Token: 0x060060DA RID: 24794 RVA: 0x00183AC4 File Offset: 0x00181CC4
	// (set) Token: 0x060060DB RID: 24795 RVA: 0x00183ACC File Offset: 0x00181CCC
	public int CombatId { get; set; }

	// Token: 0x17000717 RID: 1815
	// (get) Token: 0x060060DC RID: 24796 RVA: 0x00183AD5 File Offset: 0x00181CD5
	// (set) Token: 0x060060DD RID: 24797 RVA: 0x00183ADD File Offset: 0x00181CDD
	public int SubTypeId { get; set; }

	// Token: 0x17000718 RID: 1816
	// (get) Token: 0x060060DE RID: 24798 RVA: 0x00183AE6 File Offset: 0x00181CE6
	// (set) Token: 0x060060DF RID: 24799 RVA: 0x00183AEE File Offset: 0x00181CEE
	public string PrefabPath { get; set; }

	// Token: 0x17000719 RID: 1817
	// (get) Token: 0x060060E0 RID: 24800 RVA: 0x00183AF7 File Offset: 0x00181CF7
	// (set) Token: 0x060060E1 RID: 24801 RVA: 0x00183AFF File Offset: 0x00181CFF
	public string AssetPath { get; set; }

	// Token: 0x1700071A RID: 1818
	// (get) Token: 0x060060E2 RID: 24802 RVA: 0x00183B08 File Offset: 0x00181D08
	// (set) Token: 0x060060E3 RID: 24803 RVA: 0x00183B10 File Offset: 0x00181D10
	public int PropertyId { get; set; }

	// Token: 0x1700071B RID: 1819
	// (get) Token: 0x060060E4 RID: 24804 RVA: 0x00183B19 File Offset: 0x00181D19
	// (set) Token: 0x060060E5 RID: 24805 RVA: 0x00183B21 File Offset: 0x00181D21
	public int? SplineId { get; set; }

	// Token: 0x1700071C RID: 1820
	// (get) Token: 0x060060E6 RID: 24806 RVA: 0x00183B2A File Offset: 0x00181D2A
	// (set) Token: 0x060060E7 RID: 24807 RVA: 0x00183B32 File Offset: 0x00181D32
	public Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x1700071D RID: 1821
	// (get) Token: 0x060060E8 RID: 24808 RVA: 0x00183B3B File Offset: 0x00181D3B
	// (set) Token: 0x060060E9 RID: 24809 RVA: 0x00183B43 File Offset: 0x00181D43
	public Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x1700071E RID: 1822
	// (get) Token: 0x060060EA RID: 24810 RVA: 0x00183B4C File Offset: 0x00181D4C
	// (set) Token: 0x060060EB RID: 24811 RVA: 0x00183B54 File Offset: 0x00181D54
	[Nullable(1)]
	public global::Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x1700071F RID: 1823
	// (get) Token: 0x060060EC RID: 24812 RVA: 0x00183B5D File Offset: 0x00181D5D
	// (set) Token: 0x060060ED RID: 24813 RVA: 0x00183B65 File Offset: 0x00181D65
	[Nullable(1)]
	public global::Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000720 RID: 1824
	// (get) Token: 0x060060EE RID: 24814 RVA: 0x00183B6E File Offset: 0x00181D6E
	// (set) Token: 0x060060EF RID: 24815 RVA: 0x00183B76 File Offset: 0x00181D76
	public int ConfigId { get; set; }

	// Token: 0x060060F0 RID: 24816 RVA: 0x00183B80 File Offset: 0x00181D80
	public FinalBattleEntityModel()
	{
		this.Position = global::Vector.Create(0.0, 0.0, 0.0);
		this.Rotation = global::Rotator.Create(0f, 0f, 0f);
	}

	// Token: 0x060060F1 RID: 24817 RVA: 0x00183BDA File Offset: 0x00181DDA
	static FinalBattleEntityModel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FinalBattleEntityModel.CreateStaticDefaultValue), new Action(FinalBattleEntityModel.ResetStaticDefaultValue));
	}

	// Token: 0x060060F2 RID: 24818 RVA: 0x00183BF9 File Offset: 0x00181DF9
	public static void CreateStaticDefaultValue()
	{
		FinalBattleEntityModel.EntityPool = new Pool<FinalBattleEntityModel>(100, () => new FinalBattleEntityModel(), null);
	}

	// Token: 0x060060F3 RID: 24819 RVA: 0x00183C27 File Offset: 0x00181E27
	public static void ResetStaticDefaultValue()
	{
		FinalBattleEntityModel.EntityPool = null;
	}

	// Token: 0x060060F4 RID: 24820 RVA: 0x00183C30 File Offset: 0x00181E30
	[NullableContext(1)]
	[return: Nullable(2)]
	public static IFinalBattleCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		if (!componentDataMap.ContainsKey("SimpleCombatComponentPb"))
		{
			return null;
		}
		FinalBattleEntityModel finalBattleEntityModel = FinalBattleEntityModel.EntityPool.Get();
		if (finalBattleEntityModel == null)
		{
			finalBattleEntityModel = FinalBattleEntityModel.EntityPool.Create();
		}
		finalBattleEntityModel.InitFromProto(entityData, componentDataMap);
		return finalBattleEntityModel;
	}

	// Token: 0x060060F5 RID: 24821 RVA: 0x00183C6E File Offset: 0x00181E6E
	public static void Clear()
	{
		FinalBattleEntityModel.EntityPool.Clear();
	}

	// Token: 0x060060F6 RID: 24822 RVA: 0x00183C7C File Offset: 0x00181E7C
	[NullableContext(1)]
	protected void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		SimpleCombatComponentPb simpleCombatComponentPb = componentDataMap["SimpleCombatComponentPb"].SimpleCombatComponentPb;
		EntityComponentPb entityComponentPb;
		GpuEntityComponentPb gpuEntityComponentPb = componentDataMap.TryGetValue("GpuEntityComponentPb", out entityComponentPb) ? entityComponentPb.GpuEntityComponentPb : null;
		this.EntityType = EFinalBattleEntityType.Monster;
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
		this.ConfigId = ((gpuEntityComponentPb != null) ? gpuEntityComponentPb.ConfigId : 0);
		if (((gpuEntityComponentPb != null) ? gpuEntityComponentPb.GpuMonsterEntityPbData : null) != null)
		{
			this.EntityType = EFinalBattleEntityType.Monster;
			GPUMonster? config = ConfigGPUMonsterById.GetConfig(this.ConfigId, true);
			this.PropertyId = ((config != null) ? config.GetValueOrDefault().Prop : 0);
		}
		else if (((gpuEntityComponentPb != null) ? gpuEntityComponentPb.GpuRolePbEntityData : null) != null)
		{
			this.EntityType = EFinalBattleEntityType.Role;
			GPURole? config2 = ConfigGPURoleById.GetConfig(this.ConfigId, true);
			this.PropertyId = ((config2 != null) ? config2.GetValueOrDefault().Prop : 0);
		}
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

	// Token: 0x060060F7 RID: 24823 RVA: 0x00183E70 File Offset: 0x00182070
	[NullableContext(1)]
	public void Update(IFinalBattleCombatInfo other)
	{
		this.EntityType = other.EntityType;
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
		this.ConfigId = ((IFinalBattleActivityEntityInfo)other).ConfigId;
	}

	// Token: 0x060060F8 RID: 24824 RVA: 0x00183F76 File Offset: 0x00182176
	public bool IsValid()
	{
		return this.Uid > 0;
	}

	// Token: 0x060060F9 RID: 24825 RVA: 0x00183F84 File Offset: 0x00182184
	public void Reset()
	{
		this.EntityType = EFinalBattleEntityType.Monster;
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
		this.ConfigId = 0;
	}

	// Token: 0x060060FA RID: 24826 RVA: 0x00184034 File Offset: 0x00182234
	public void Release()
	{
		this.Reset();
		FinalBattleEntityModel.EntityPool.Put(this);
	}

	// Token: 0x060060FB RID: 24827 RVA: 0x00184048 File Offset: 0x00182248
	[NullableContext(1)]
	public IFinalBattleCombatInfo Clone()
	{
		FinalBattleEntityModel finalBattleEntityModel = FinalBattleEntityModel.EntityPool.Get();
		if (finalBattleEntityModel == null)
		{
			finalBattleEntityModel = FinalBattleEntityModel.EntityPool.Create();
		}
		finalBattleEntityModel.Update(this);
		return finalBattleEntityModel;
	}

	// Token: 0x04002E7B RID: 11899
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<FinalBattleEntityModel> EntityPool;
}
