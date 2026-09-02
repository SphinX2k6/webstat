using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E90 RID: 20112
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseEventEntityModel : ITowerDefenseEventCombatInfo, ITowerDefenseEventEntityBaseModel
	{
		// Token: 0x17008909 RID: 35081
		// (get) Token: 0x06033F48 RID: 212808 RVA: 0x00CFFE3F File Offset: 0x00CFE03F
		// (set) Token: 0x06033F49 RID: 212809 RVA: 0x00CFFE47 File Offset: 0x00CFE047
		public long Uid { get; set; }

		// Token: 0x1700890A RID: 35082
		// (get) Token: 0x06033F4A RID: 212810 RVA: 0x00CFFE50 File Offset: 0x00CFE050
		// (set) Token: 0x06033F4B RID: 212811 RVA: 0x00CFFE58 File Offset: 0x00CFE058
		public long OwnerId { get; set; }

		// Token: 0x1700890B RID: 35083
		// (get) Token: 0x06033F4C RID: 212812 RVA: 0x00CFFE61 File Offset: 0x00CFE061
		// (set) Token: 0x06033F4D RID: 212813 RVA: 0x00CFFE69 File Offset: 0x00CFE069
		public int TemplateId { get; set; }

		// Token: 0x1700890C RID: 35084
		// (get) Token: 0x06033F4E RID: 212814 RVA: 0x00CFFE72 File Offset: 0x00CFE072
		// (set) Token: 0x06033F4F RID: 212815 RVA: 0x00CFFE7A File Offset: 0x00CFE07A
		public int CombatId { get; set; }

		// Token: 0x1700890D RID: 35085
		// (get) Token: 0x06033F50 RID: 212816 RVA: 0x00CFFE83 File Offset: 0x00CFE083
		// (set) Token: 0x06033F51 RID: 212817 RVA: 0x00CFFE8B File Offset: 0x00CFE08B
		public int SubTypeId { get; set; }

		// Token: 0x1700890E RID: 35086
		// (get) Token: 0x06033F52 RID: 212818 RVA: 0x00CFFE94 File Offset: 0x00CFE094
		// (set) Token: 0x06033F53 RID: 212819 RVA: 0x00CFFE9C File Offset: 0x00CFE09C
		[Nullable(2)]
		public string PrefabPath { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700890F RID: 35087
		// (get) Token: 0x06033F54 RID: 212820 RVA: 0x00CFFEA5 File Offset: 0x00CFE0A5
		// (set) Token: 0x06033F55 RID: 212821 RVA: 0x00CFFEAD File Offset: 0x00CFE0AD
		[Nullable(2)]
		public string AssetPath { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008910 RID: 35088
		// (get) Token: 0x06033F56 RID: 212822 RVA: 0x00CFFEB6 File Offset: 0x00CFE0B6
		// (set) Token: 0x06033F57 RID: 212823 RVA: 0x00CFFEBE File Offset: 0x00CFE0BE
		public int PropertyId { get; set; }

		// Token: 0x17008911 RID: 35089
		// (get) Token: 0x06033F58 RID: 212824 RVA: 0x00CFFEC7 File Offset: 0x00CFE0C7
		// (set) Token: 0x06033F59 RID: 212825 RVA: 0x00CFFECF File Offset: 0x00CFE0CF
		public int? SplineId { get; set; }

		// Token: 0x17008912 RID: 35090
		// (get) Token: 0x06033F5A RID: 212826 RVA: 0x00CFFED8 File Offset: 0x00CFE0D8
		// (set) Token: 0x06033F5B RID: 212827 RVA: 0x00CFFEE0 File Offset: 0x00CFE0E0
		[Nullable(2)]
		public Dictionary<int, int> BuffIdLayers { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008913 RID: 35091
		// (get) Token: 0x06033F5C RID: 212828 RVA: 0x00CFFEE9 File Offset: 0x00CFE0E9
		// (set) Token: 0x06033F5D RID: 212829 RVA: 0x00CFFEF1 File Offset: 0x00CFE0F1
		public global::Vector Position { get; set; } = global::Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x17008914 RID: 35092
		// (get) Token: 0x06033F5E RID: 212830 RVA: 0x00CFFEFA File Offset: 0x00CFE0FA
		// (set) Token: 0x06033F5F RID: 212831 RVA: 0x00CFFF02 File Offset: 0x00CFE102
		public global::Rotator Rotation { get; set; } = global::Rotator.Create(0f, 0f, 0f);

		// Token: 0x17008915 RID: 35093
		// (get) Token: 0x06033F60 RID: 212832 RVA: 0x00CFFF0B File Offset: 0x00CFE10B
		// (set) Token: 0x06033F61 RID: 212833 RVA: 0x00CFFF13 File Offset: 0x00CFE113
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<ETowerDefenseEventCombatExtraInfoType, CombatExtraInfoBase> ExtraInfo { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x06033F62 RID: 212834 RVA: 0x00CFFF1C File Offset: 0x00CFE11C
		[return: Nullable(2)]
		public static ITowerDefenseEventCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			if (!componentDataMap.ContainsKey("SimpleCombatComponentPb"))
			{
				return null;
			}
			TowerDefenseEventEntityModel towerDefenseEventEntityModel = TowerDefenseEventEntityModel.EntityPool.Get() ?? TowerDefenseEventEntityModel.EntityPool.Create();
			towerDefenseEventEntityModel.InitFromProto(entityData, componentDataMap);
			return towerDefenseEventEntityModel;
		}

		// Token: 0x06033F63 RID: 212835 RVA: 0x00CFFF4D File Offset: 0x00CFE14D
		public static void Clear()
		{
			TowerDefenseEventEntityModel.EntityPool.Clear();
		}

		// Token: 0x06033F64 RID: 212836 RVA: 0x00CFFF5C File Offset: 0x00CFE15C
		protected virtual void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			SimpleCombatComponentPb simpleCombatComponentPb = componentDataMap["SimpleCombatComponentPb"].SimpleCombatComponentPb;
			this.Uid = entityData.Id;
			this.OwnerId = entityData.OwnerIncId;
			this.TemplateId = entityData.ConfigId;
			this.CombatId = 0;
			this.SubTypeId = simpleCombatComponentPb.SubTypeId;
			this.PrefabPath = null;
			this.AssetPath = null;
			this.PropertyId = 0;
			this.BuffIdLayers = new Dictionary<int, int>();
			foreach (KeyValuePair<int, int> keyValuePair in simpleCombatComponentPb.BuffLayers)
			{
				this.BuffIdLayers[keyValuePair.Key] = keyValuePair.Value;
			}
			if (simpleCombatComponentPb.SplineMoveType != null)
			{
				this.SplineId = new int?(simpleCombatComponentPb.SplineMoveType.ConfigId);
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

		// Token: 0x06033F65 RID: 212837 RVA: 0x00D00094 File Offset: 0x00CFE294
		public virtual void Update(ITowerDefenseEventCombatInfo other)
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
			this.Position.Set(other.Position.X, other.Position.Y, other.Position.Z);
			this.Rotation.Set(other.Rotation.Pitch, other.Rotation.Yaw, other.Rotation.Roll);
		}

		// Token: 0x06033F66 RID: 212838 RVA: 0x00D00171 File Offset: 0x00CFE371
		public virtual bool IsValid()
		{
			return this.Uid > 0L;
		}

		// Token: 0x06033F67 RID: 212839 RVA: 0x00D00180 File Offset: 0x00CFE380
		public virtual void Reset()
		{
			this.Uid = 0L;
			this.OwnerId = 0L;
			this.TemplateId = 0;
			this.CombatId = 0;
			this.SubTypeId = 0;
			this.PrefabPath = null;
			this.AssetPath = null;
			this.PropertyId = 0;
			this.SplineId = null;
			this.BuffIdLayers = null;
			this.Position.Set(0.0, 0.0, 0.0);
			this.Rotation.Set(0f, 0f, 0f);
		}

		// Token: 0x06033F68 RID: 212840 RVA: 0x00D0021D File Offset: 0x00CFE41D
		public virtual void Release()
		{
			this.Reset();
			TowerDefenseEventEntityModel.EntityPool.Put(this);
		}

		// Token: 0x06033F69 RID: 212841 RVA: 0x00D00231 File Offset: 0x00CFE431
		public ITowerDefenseEventCombatInfo Clone()
		{
			TowerDefenseEventEntityModel towerDefenseEventEntityModel = TowerDefenseEventEntityModel.EntityPool.Get() ?? TowerDefenseEventEntityModel.EntityPool.Create();
			towerDefenseEventEntityModel.Update(this);
			return towerDefenseEventEntityModel;
		}

		// Token: 0x0401E098 RID: 123032
		public const int ENTITY_POOL_SIZE = 100;

		// Token: 0x0401E0A6 RID: 123046
		[StaticVariableRuleIgnore]
		private static readonly Pool<TowerDefenseEventEntityModel> EntityPool = new Pool<TowerDefenseEventEntityModel>(100, () => new TowerDefenseEventEntityModel(), null);
	}
}
