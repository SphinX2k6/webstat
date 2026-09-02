using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E92 RID: 20114
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseEventTrapModel : TowerDefenseEventEntityModel, ITowerDefenseEventTrapInfo, ITowerDefenseEventTrapBaseInfo, ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x1700891C RID: 35100
		// (get) Token: 0x06033F82 RID: 212866 RVA: 0x00D00533 File Offset: 0x00CFE733
		// (set) Token: 0x06033F83 RID: 212867 RVA: 0x00D0053B File Offset: 0x00CFE73B
		public int ConfigId { get; set; }

		// Token: 0x1700891D RID: 35101
		// (get) Token: 0x06033F84 RID: 212868 RVA: 0x00D00544 File Offset: 0x00CFE744
		// (set) Token: 0x06033F85 RID: 212869 RVA: 0x00D0054C File Offset: 0x00CFE74C
		public int TrapId { get; set; }

		// Token: 0x1700891E RID: 35102
		// (get) Token: 0x06033F86 RID: 212870 RVA: 0x00D00555 File Offset: 0x00CFE755
		// (set) Token: 0x06033F87 RID: 212871 RVA: 0x00D0055D File Offset: 0x00CFE75D
		public int Level { get; set; }

		// Token: 0x1700891F RID: 35103
		// (get) Token: 0x06033F88 RID: 212872 RVA: 0x00D00566 File Offset: 0x00CFE766
		// (set) Token: 0x06033F89 RID: 212873 RVA: 0x00D0056E File Offset: 0x00CFE76E
		public int BranchId { get; set; }

		// Token: 0x17008920 RID: 35104
		// (get) Token: 0x06033F8A RID: 212874 RVA: 0x00D00577 File Offset: 0x00CFE777
		// (set) Token: 0x06033F8B RID: 212875 RVA: 0x00D0057F File Offset: 0x00CFE77F
		public int DefaultCost { get; set; }

		// Token: 0x17008921 RID: 35105
		// (get) Token: 0x06033F8C RID: 212876 RVA: 0x00D00588 File Offset: 0x00CFE788
		// (set) Token: 0x06033F8D RID: 212877 RVA: 0x00D00590 File Offset: 0x00CFE790
		public int DeconstructReturn { get; set; }

		// Token: 0x17008922 RID: 35106
		// (get) Token: 0x06033F8E RID: 212878 RVA: 0x00D00599 File Offset: 0x00CFE799
		// (set) Token: 0x06033F8F RID: 212879 RVA: 0x00D005A1 File Offset: 0x00CFE7A1
		public Vector2D GridSize { get; set; } = new Vector2D();

		// Token: 0x17008923 RID: 35107
		// (get) Token: 0x06033F90 RID: 212880 RVA: 0x00D005AA File Offset: 0x00CFE7AA
		// (set) Token: 0x06033F91 RID: 212881 RVA: 0x00D005B2 File Offset: 0x00CFE7B2
		public ETowerDefenseEventTrapPlacementType PlacementType { get; set; } = ETowerDefenseEventTrapPlacementType.Ground;

		// Token: 0x17008924 RID: 35108
		// (get) Token: 0x06033F92 RID: 212882 RVA: 0x00D005BB File Offset: 0x00CFE7BB
		// (set) Token: 0x06033F93 RID: 212883 RVA: 0x00D005C3 File Offset: 0x00CFE7C3
		public bool CanRotate { get; set; } = true;

		// Token: 0x17008925 RID: 35109
		// (get) Token: 0x06033F94 RID: 212884 RVA: 0x00D005CC File Offset: 0x00CFE7CC
		// (set) Token: 0x06033F95 RID: 212885 RVA: 0x00D005D4 File Offset: 0x00CFE7D4
		[Nullable(2)]
		public string GridId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008926 RID: 35110
		// (get) Token: 0x06033F96 RID: 212886 RVA: 0x00D005DD File Offset: 0x00CFE7DD
		// (set) Token: 0x06033F97 RID: 212887 RVA: 0x00D005E5 File Offset: 0x00CFE7E5
		public Vector2D Coords { get; set; } = new Vector2D();

		// Token: 0x17008927 RID: 35111
		// (get) Token: 0x06033F98 RID: 212888 RVA: 0x00D005EE File Offset: 0x00CFE7EE
		// (set) Token: 0x06033F99 RID: 212889 RVA: 0x00D005F6 File Offset: 0x00CFE7F6
		public int Degree { get; set; }

		// Token: 0x06033F9A RID: 212890 RVA: 0x00D00600 File Offset: 0x00CFE800
		[return: Nullable(2)]
		public new static ITowerDefenseEventCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			EntityComponentPb entityComponentPb;
			if (!componentDataMap.ContainsKey("SimpleCombatComponentPb") || !componentDataMap.ContainsKey("GridObjectComponentPb") || !componentDataMap.TryGetValue("TrapDefenseComponentPb", out entityComponentPb))
			{
				return null;
			}
			if (entityComponentPb.TrapDefenseComponentPb.BuildingPbData == null)
			{
				return null;
			}
			TowerDefenseEventTrapModel towerDefenseEventTrapModel = TowerDefenseEventTrapModel.TrapPool.Get() ?? TowerDefenseEventTrapModel.TrapPool.Create();
			towerDefenseEventTrapModel.InitFromProto(entityData, componentDataMap);
			return towerDefenseEventTrapModel;
		}

		// Token: 0x06033F9B RID: 212891 RVA: 0x00D00667 File Offset: 0x00CFE867
		public new static void Clear()
		{
			TowerDefenseEventTrapModel.TrapPool.Clear();
		}

		// Token: 0x06033F9C RID: 212892 RVA: 0x00D00673 File Offset: 0x00CFE873
		public static TowerDefenseEventTrapModel GetTrapModel(ITowerDefenseEventTrapBaseInfo baseInfo)
		{
			TowerDefenseEventTrapModel towerDefenseEventTrapModel = TowerDefenseEventTrapModel.TrapPool.Get() ?? TowerDefenseEventTrapModel.TrapPool.Create();
			towerDefenseEventTrapModel.Update(baseInfo);
			return towerDefenseEventTrapModel;
		}

		// Token: 0x06033F9D RID: 212893 RVA: 0x00D00694 File Offset: 0x00CFE894
		protected override void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			base.InitFromProto(entityData, componentDataMap);
			GridObjectComponentPb gridObjectComponentPb = componentDataMap["GridObjectComponentPb"].GridObjectComponentPb;
			this.GridId = gridObjectComponentPb.InitGridPlacementPbInfo.ActorGuid;
			this.Coords.Set((double)gridObjectComponentPb.InitGridPlacementPbInfo.X, (double)gridObjectComponentPb.InitGridPlacementPbInfo.Y);
			this.Degree = TowerDefenseEventUtility.ConvertDirection2Degree(new GridPbDirection?(gridObjectComponentPb.InitGridPlacementPbInfo.Direction));
			TrapDefenseComponentPb trapDefenseComponentPb = componentDataMap["TrapDefenseComponentPb"].TrapDefenseComponentPb;
			this.ConfigId = trapDefenseComponentPb.BuildingPbData.ConfigId;
			this.TrapId = 0;
			this.Level = trapDefenseComponentPb.BuildingPbData.BattleLevel;
			this.BranchId = 0;
			this.DefaultCost = 0;
			this.DeconstructReturn = trapDefenseComponentPb.BuildingPbData.DeconstructReturn;
			this.GridSize.Set(0.0, 0.0);
			this.PlacementType = ETowerDefenseEventTrapPlacementType.Ground;
			this.CanRotate = true;
		}

		// Token: 0x06033F9E RID: 212894 RVA: 0x00D00790 File Offset: 0x00CFE990
		public override void Update(ITowerDefenseEventCombatInfo other)
		{
			base.Update(other);
			ITowerDefenseEventTrapBaseInfo towerDefenseEventTrapBaseInfo = other as ITowerDefenseEventTrapBaseInfo;
			if (towerDefenseEventTrapBaseInfo != null)
			{
				this.ConfigId = towerDefenseEventTrapBaseInfo.ConfigId;
				this.TrapId = towerDefenseEventTrapBaseInfo.TrapId;
				this.Level = towerDefenseEventTrapBaseInfo.Level;
				this.BranchId = towerDefenseEventTrapBaseInfo.BranchId;
				this.DefaultCost = towerDefenseEventTrapBaseInfo.DefaultCost;
				this.GridSize.Set(towerDefenseEventTrapBaseInfo.GridSize.X, towerDefenseEventTrapBaseInfo.GridSize.Y);
				this.PlacementType = towerDefenseEventTrapBaseInfo.PlacementType;
				this.CanRotate = towerDefenseEventTrapBaseInfo.CanRotate;
				this.Degree = towerDefenseEventTrapBaseInfo.Degree;
			}
			else
			{
				this.ConfigId = 0;
				this.TrapId = 0;
				this.Level = 0;
				this.BranchId = 0;
				this.DefaultCost = 0;
				this.GridSize.Set(0.0, 0.0);
				this.PlacementType = ETowerDefenseEventTrapPlacementType.Ground;
				this.CanRotate = true;
				this.Degree = 0;
			}
			ITowerDefenseEventTrapInfo towerDefenseEventTrapInfo = other as ITowerDefenseEventTrapInfo;
			if (towerDefenseEventTrapInfo != null)
			{
				this.GridId = towerDefenseEventTrapInfo.GridId;
				this.Coords.Set(towerDefenseEventTrapInfo.Coords.X, towerDefenseEventTrapInfo.Coords.Y);
				return;
			}
			this.GridId = null;
			this.Coords.Set(0.0, 0.0);
		}

		// Token: 0x06033F9F RID: 212895 RVA: 0x00D008E5 File Offset: 0x00CFEAE5
		public void UpdateTransform(FVectorDouble position, FRotator rotation)
		{
			base.Position.Set(position.X, position.Y, position.Z);
			base.Rotation.Set(rotation.Pitch, rotation.Yaw, rotation.Roll);
		}

		// Token: 0x06033FA0 RID: 212896 RVA: 0x00D00921 File Offset: 0x00CFEB21
		public void UpdateData(string gridId, Vector2D coords)
		{
			this.GridId = gridId;
			this.Coords.Set(coords.X, coords.Y);
		}

		// Token: 0x06033FA1 RID: 212897 RVA: 0x00D00944 File Offset: 0x00CFEB44
		public override void Reset()
		{
			base.Reset();
			this.ConfigId = 0;
			this.TrapId = 0;
			this.Level = 0;
			this.BranchId = 0;
			this.DefaultCost = 0;
			this.GridSize.Set(0.0, 0.0);
			this.PlacementType = ETowerDefenseEventTrapPlacementType.Ground;
			this.CanRotate = true;
			this.GridId = null;
			this.Coords.Set(0.0, 0.0);
			this.Degree = 0;
		}

		// Token: 0x06033FA2 RID: 212898 RVA: 0x00D009D0 File Offset: 0x00CFEBD0
		public override void Release()
		{
			this.Reset();
			TowerDefenseEventTrapModel.TrapPool.Put(this);
		}

		// Token: 0x06033FA3 RID: 212899 RVA: 0x00D009E4 File Offset: 0x00CFEBE4
		public new ITowerDefenseEventCombatInfo Clone()
		{
			TowerDefenseEventTrapModel towerDefenseEventTrapModel = TowerDefenseEventTrapModel.TrapPool.Get() ?? TowerDefenseEventTrapModel.TrapPool.Create();
			towerDefenseEventTrapModel.Update(this);
			return towerDefenseEventTrapModel;
		}

		// Token: 0x0401E0BA RID: 123066
		[StaticVariableRuleIgnore]
		private static readonly Pool<TowerDefenseEventTrapModel> TrapPool = new Pool<TowerDefenseEventTrapModel>(100, () => new TowerDefenseEventTrapModel(), null);
	}
}
