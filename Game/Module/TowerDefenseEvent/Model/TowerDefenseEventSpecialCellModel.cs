using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E93 RID: 20115
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseEventSpecialCellModel : TowerDefenseEventEntityModel, ITowerDefenseEventSpecialCellInfo, ITowerDefenseEventSpecialCellBaseInfo, ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x17008928 RID: 35112
		// (get) Token: 0x06033FA6 RID: 212902 RVA: 0x00D00A50 File Offset: 0x00CFEC50
		// (set) Token: 0x06033FA7 RID: 212903 RVA: 0x00D00A58 File Offset: 0x00CFEC58
		public int ConfigId { get; set; }

		// Token: 0x17008929 RID: 35113
		// (get) Token: 0x06033FA8 RID: 212904 RVA: 0x00D00A61 File Offset: 0x00CFEC61
		// (set) Token: 0x06033FA9 RID: 212905 RVA: 0x00D00A69 File Offset: 0x00CFEC69
		public int CellType { get; set; }

		// Token: 0x1700892A RID: 35114
		// (get) Token: 0x06033FAA RID: 212906 RVA: 0x00D00A72 File Offset: 0x00CFEC72
		// (set) Token: 0x06033FAB RID: 212907 RVA: 0x00D00A7A File Offset: 0x00CFEC7A
		public Vector2D GridSize { get; set; } = new Vector2D();

		// Token: 0x1700892B RID: 35115
		// (get) Token: 0x06033FAC RID: 212908 RVA: 0x00D00A83 File Offset: 0x00CFEC83
		// (set) Token: 0x06033FAD RID: 212909 RVA: 0x00D00A8B File Offset: 0x00CFEC8B
		[Nullable(2)]
		public string GridId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700892C RID: 35116
		// (get) Token: 0x06033FAE RID: 212910 RVA: 0x00D00A94 File Offset: 0x00CFEC94
		// (set) Token: 0x06033FAF RID: 212911 RVA: 0x00D00A9C File Offset: 0x00CFEC9C
		public Vector2D Coords { get; set; } = new Vector2D();

		// Token: 0x06033FB0 RID: 212912 RVA: 0x00D00AA8 File Offset: 0x00CFECA8
		[return: Nullable(2)]
		public new static ITowerDefenseEventCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			EntityComponentPb entityComponentPb;
			if (!componentDataMap.ContainsKey("SimpleCombatComponentPb") || !componentDataMap.ContainsKey("GridObjectComponentPb") || !componentDataMap.TryGetValue("TrapDefenseComponentPb", out entityComponentPb))
			{
				return null;
			}
			if (entityComponentPb.TrapDefenseComponentPb.SpecialCellPbData == null)
			{
				return null;
			}
			TowerDefenseEventSpecialCellModel towerDefenseEventSpecialCellModel = TowerDefenseEventSpecialCellModel.SpecialCellPool.Get() ?? TowerDefenseEventSpecialCellModel.SpecialCellPool.Create();
			towerDefenseEventSpecialCellModel.InitFromProto(entityData, componentDataMap);
			return towerDefenseEventSpecialCellModel;
		}

		// Token: 0x06033FB1 RID: 212913 RVA: 0x00D00B0F File Offset: 0x00CFED0F
		public new static void Clear()
		{
			TowerDefenseEventSpecialCellModel.SpecialCellPool.Clear();
		}

		// Token: 0x06033FB2 RID: 212914 RVA: 0x00D00B1B File Offset: 0x00CFED1B
		public static TowerDefenseEventSpecialCellModel GetSpecialCellModel(ITowerDefenseEventTrapBaseInfo baseInfo)
		{
			TowerDefenseEventSpecialCellModel towerDefenseEventSpecialCellModel = TowerDefenseEventSpecialCellModel.SpecialCellPool.Get() ?? TowerDefenseEventSpecialCellModel.SpecialCellPool.Create();
			towerDefenseEventSpecialCellModel.Update(baseInfo);
			return towerDefenseEventSpecialCellModel;
		}

		// Token: 0x06033FB3 RID: 212915 RVA: 0x00D00B3C File Offset: 0x00CFED3C
		protected override void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			base.InitFromProto(entityData, componentDataMap);
			GridObjectComponentPb gridObjectComponentPb = componentDataMap["GridObjectComponentPb"].GridObjectComponentPb;
			this.GridId = gridObjectComponentPb.InitGridPlacementPbInfo.ActorGuid;
			this.Coords.Set((double)gridObjectComponentPb.InitGridPlacementPbInfo.X, (double)gridObjectComponentPb.InitGridPlacementPbInfo.Y);
			this.GridSize.Set(0.0, 0.0);
			TrapDefenseComponentPb trapDefenseComponentPb = componentDataMap["TrapDefenseComponentPb"].TrapDefenseComponentPb;
			this.ConfigId = trapDefenseComponentPb.SpecialCellPbData.ConfigId;
		}

		// Token: 0x06033FB4 RID: 212916 RVA: 0x00D00BD8 File Offset: 0x00CFEDD8
		public override void Update(ITowerDefenseEventCombatInfo other)
		{
			base.Update(other);
			ITowerDefenseEventSpecialCellInfo towerDefenseEventSpecialCellInfo = other as ITowerDefenseEventSpecialCellInfo;
			if (towerDefenseEventSpecialCellInfo != null)
			{
				this.ConfigId = towerDefenseEventSpecialCellInfo.ConfigId;
				this.CellType = towerDefenseEventSpecialCellInfo.CellType;
				this.GridId = towerDefenseEventSpecialCellInfo.GridId;
				this.GridSize.Set(towerDefenseEventSpecialCellInfo.GridSize.X, towerDefenseEventSpecialCellInfo.GridSize.Y);
				this.Coords.Set(towerDefenseEventSpecialCellInfo.Coords.X, towerDefenseEventSpecialCellInfo.Coords.Y);
				return;
			}
			this.ConfigId = 0;
			this.CellType = 0;
			this.GridId = null;
			this.GridSize.Set(0.0, 0.0);
			this.Coords.Set(0.0, 0.0);
		}

		// Token: 0x06033FB5 RID: 212917 RVA: 0x00D00CAC File Offset: 0x00CFEEAC
		public void UpdateTransform(FVectorDouble position, FRotator rotation)
		{
			base.Position.Set(position.X, position.Y, position.Z);
			base.Rotation.Set(rotation.Pitch, rotation.Yaw, rotation.Roll);
		}

		// Token: 0x06033FB6 RID: 212918 RVA: 0x00D00CE8 File Offset: 0x00CFEEE8
		public void UpdateData(string gridId, FKuroBuildingGridCellVector coords)
		{
			this.GridId = gridId;
			this.Coords.Set((double)coords.X, (double)coords.Y);
		}

		// Token: 0x06033FB7 RID: 212919 RVA: 0x00D00D0C File Offset: 0x00CFEF0C
		public override void Reset()
		{
			base.Reset();
			this.ConfigId = 0;
			this.GridId = null;
			this.Coords.Set(0.0, 0.0);
			this.GridSize.Set(0.0, 0.0);
		}

		// Token: 0x06033FB8 RID: 212920 RVA: 0x00D00D67 File Offset: 0x00CFEF67
		public override void Release()
		{
			this.Reset();
			TowerDefenseEventSpecialCellModel.SpecialCellPool.Put(this);
		}

		// Token: 0x06033FB9 RID: 212921 RVA: 0x00D00D7B File Offset: 0x00CFEF7B
		public new ITowerDefenseEventCombatInfo Clone()
		{
			TowerDefenseEventSpecialCellModel towerDefenseEventSpecialCellModel = TowerDefenseEventSpecialCellModel.SpecialCellPool.Get() ?? TowerDefenseEventSpecialCellModel.SpecialCellPool.Create();
			towerDefenseEventSpecialCellModel.Update(this);
			return towerDefenseEventSpecialCellModel;
		}

		// Token: 0x0401E0C0 RID: 123072
		[StaticVariableRuleIgnore]
		private static readonly Pool<TowerDefenseEventSpecialCellModel> SpecialCellPool = new Pool<TowerDefenseEventSpecialCellModel>(100, () => new TowerDefenseEventSpecialCellModel(), null);
	}
}
