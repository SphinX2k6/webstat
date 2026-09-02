using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using UnrealEngine;

// Token: 0x020017CC RID: 6092
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BuildingGridModel : ModelBase<BuildingGridModel>
{
	// Token: 0x0600ACE4 RID: 44260 RVA: 0x002E1C24 File Offset: 0x002DFE24
	public BuildingGridModel()
	{
		this.CellModelPool = new Pool<BuildingGridCellModel>(100, () => new BuildingGridCellModel(), null);
		this.TempGridCellVector = default(FKuroBuildingGridCellVector);
	}

	// Token: 0x0600ACE5 RID: 44261 RVA: 0x002E1C7C File Offset: 0x002DFE7C
	public bool UpdateGridCell(GridCellUpdateNotify data)
	{
		LevelGridPbData levelGridData = data.LevelGridData;
		GridPlacementPbInfo gridPlacementPbInfo = (levelGridData != null) ? levelGridData.GridPlacementPbInfo : null;
		if (gridPlacementPbInfo == null)
		{
			return false;
		}
		string actorGuid = gridPlacementPbInfo.ActorGuid;
		int x = gridPlacementPbInfo.X;
		int y = gridPlacementPbInfo.Y;
		AKuroBuildingGrid akuroBuildingGrid = UKuroBuildingGridSubsystem.K2_FindBuildingGrid(GlobalData.World, actorGuid);
		if (akuroBuildingGrid == null)
		{
			return false;
		}
		this.TempGridCellVector.X = x;
		this.TempGridCellVector.Y = y;
		int num = 0;
		if (!akuroBuildingGrid.GetCellIndex(this.TempGridCellVector, ref num))
		{
			return false;
		}
		int key = num;
		Dictionary<int, BuildingGridCellModel> dictionary;
		if (!this.GridCellModels.TryGetValue(actorGuid, out dictionary))
		{
			if (!data.IsAdd)
			{
				return false;
			}
			dictionary = new Dictionary<int, BuildingGridCellModel>();
			this.GridCellModels[actorGuid] = dictionary;
		}
		BuildingGridCellModel buildingGridCellModel;
		if (!dictionary.TryGetValue(key, out buildingGridCellModel))
		{
			if (!data.IsAdd)
			{
				return false;
			}
			buildingGridCellModel = this.CellModelPool.Get();
			if (buildingGridCellModel == null)
			{
				buildingGridCellModel = this.CellModelPool.Create();
			}
			dictionary[key] = buildingGridCellModel;
		}
		if (!data.IsAdd)
		{
			dictionary.Remove(key);
			if (dictionary.Count == 0)
			{
				this.GridCellModels.Remove(actorGuid);
			}
			this.CellModelPool.Put(buildingGridCellModel);
			return true;
		}
		buildingGridCellModel.GridId = actorGuid;
		buildingGridCellModel.X = x;
		buildingGridCellModel.Y = y;
		buildingGridCellModel.CreatureId = 0L;
		LevelGridPbData levelGridData2 = data.LevelGridData;
		if (((levelGridData2 != null) ? levelGridData2.PollutedGridPbData : null) != null)
		{
			buildingGridCellModel.CreatureId = -1L;
		}
		else
		{
			LevelGridPbData levelGridData3 = data.LevelGridData;
			if (((levelGridData3 != null) ? levelGridData3.EntityGridPbData : null) != null)
			{
				buildingGridCellModel.CreatureId = data.LevelGridData.EntityGridPbData.Id;
			}
		}
		return true;
	}

	// Token: 0x0600ACE6 RID: 44262 RVA: 0x002E1E10 File Offset: 0x002E0010
	public int IsCellPolluted(string gridId, int index)
	{
		Dictionary<int, BuildingGridCellModel> dictionary;
		if (!this.GridCellModels.TryGetValue(gridId, out dictionary))
		{
			return -1;
		}
		BuildingGridCellModel buildingGridCellModel;
		if (!dictionary.TryGetValue(index, out buildingGridCellModel))
		{
			return -1;
		}
		ITowerDefenseEventCombatInfo entity = ModelBase<TowerDefenseEventModel>.Instance.GetEntity(buildingGridCellModel.CreatureId);
		ITowerDefenseEventSpecialCellInfo towerDefenseEventSpecialCellInfo = entity as ITowerDefenseEventSpecialCellInfo;
		if (towerDefenseEventSpecialCellInfo != null && towerDefenseEventSpecialCellInfo.CellType == 2)
		{
			TowerDefenseEventEntityModel towerDefenseEventEntityModel = entity as TowerDefenseEventEntityModel;
			return (int)((towerDefenseEventEntityModel != null) ? towerDefenseEventEntityModel.Uid : -1L);
		}
		return -1;
	}

	// Token: 0x0600ACE7 RID: 44263 RVA: 0x002E1E78 File Offset: 0x002E0078
	protected override bool OnLeaveLevel()
	{
		foreach (Dictionary<int, BuildingGridCellModel> dictionary in this.GridCellModels.Values)
		{
			foreach (BuildingGridCellModel value in dictionary.Values)
			{
				this.CellModelPool.Put(value);
			}
			dictionary.Clear();
		}
		this.GridCellModels.Clear();
		this.CellModelPool.Clear();
		return base.OnLeaveLevel();
	}

	// Token: 0x040051DD RID: 20957
	private Pool<BuildingGridCellModel> CellModelPool;

	// Token: 0x040051DE RID: 20958
	private FKuroBuildingGridCellVector TempGridCellVector;

	// Token: 0x040051DF RID: 20959
	private readonly Dictionary<string, Dictionary<int, BuildingGridCellModel>> GridCellModels = new Dictionary<string, Dictionary<int, BuildingGridCellModel>>();
}
