using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x020017CA RID: 6090
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BuildingGridController : ControllerBase<BuildingGridController>
{
	// Token: 0x0600ACDA RID: 44250 RVA: 0x002E1991 File Offset: 0x002DFB91
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.Register<GridCellUpdateNotify>(ENotifyMessageId.GridCellUpdateNotify, new Action<GridCellUpdateNotify, Net.CallbackStatus>(this.OnGridCellUpdateNotify));
		return true;
	}

	// Token: 0x0600ACDB RID: 44251 RVA: 0x002E19B0 File Offset: 0x002DFBB0
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GridCellUpdateNotify);
		return true;
	}

	// Token: 0x0600ACDC RID: 44252 RVA: 0x002E19C3 File Offset: 0x002DFBC3
	[NullableContext(2)]
	private void OnGridCellUpdateNotify(GridCellUpdateNotify data, Net.CallbackStatus _)
	{
		if (data != null)
		{
			ModelBase<BuildingGridModel>.Instance.UpdateGridCell(data);
		}
	}

	// Token: 0x0600ACDD RID: 44253 RVA: 0x002E19D4 File Offset: 0x002DFBD4
	private void ForEachGridCell(global::Vector position, int radius, bool useDirMask, int dirMask, Action<string, FKuroBuildingGridCellVector, int> callback)
	{
		if (BuildingGridController.ForEachIntersectingCellMethod == null)
		{
			return;
		}
		ParameterInfo[] parameters = BuildingGridController.ForEachIntersectingCellMethod.GetParameters();
		if (parameters.Length == 0)
		{
			return;
		}
		ParameterInfo[] array = parameters;
		Type parameterType = array[array.Length - 1].ParameterType;
		MethodInfo method = typeof(global::DelegateUtils).GetMethod("ToManualReleaseDelegate");
		MethodInfo methodInfo = (method != null) ? method.MakeGenericMethod(new Type[]
		{
			parameterType
		}) : null;
		if (methodInfo == null)
		{
			return;
		}
		object obj = methodInfo.Invoke(null, new object[]
		{
			callback
		});
		try
		{
			object[] array2 = new object[]
			{
				GlobalData.World,
				position.ToUeVector(false),
				radius,
				useDirMask,
				dirMask,
				obj
			};
			BuildingGridController.CoerceArgsToParameterTypes(array2, parameters);
			BuildingGridController.ForEachIntersectingCellMethod.Invoke(null, array2);
		}
		finally
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(callback);
		}
	}

	// Token: 0x0600ACDE RID: 44254 RVA: 0x002E1AC4 File Offset: 0x002DFCC4
	private static void CoerceArgsToParameterTypes([Nullable(new byte[]
	{
		1,
		2
	})] object[] args, ParameterInfo[] parameters)
	{
		int num = Math.Min(args.Length, parameters.Length);
		for (int i = 0; i < num; i++)
		{
			object obj = args[i];
			if (obj != null)
			{
				Type type = parameters[i].ParameterType;
				if (type.IsByRef)
				{
					type = type.GetElementType();
				}
				if (!(obj.GetType() == type) && obj is IConvertible && (type == typeof(double) || type == typeof(float) || type == typeof(int) || type == typeof(long)))
				{
					args[i] = Convert.ChangeType(obj, type);
				}
			}
		}
	}

	// Token: 0x0600ACDF RID: 44255 RVA: 0x002E1B7C File Offset: 0x002DFD7C
	public void LandFireGrids(global::Vector position, int radius, bool clearCell, Action<string, FKuroBuildingGridCellVector> callback)
	{
		this.ForEachGridCell(position, radius, true, 1, delegate(string gridId, FKuroBuildingGridCellVector coords, int cellIndex)
		{
			if (clearCell && ModelBase<BuildingGridModel>.Instance.IsCellPolluted(gridId, cellIndex) > 0)
			{
				return;
			}
			callback(gridId, coords);
		});
	}

	// Token: 0x0600ACE0 RID: 44256 RVA: 0x002E1BB4 File Offset: 0x002DFDB4
	public List<GridPlacementPbInfo> PolluteGrids(global::Vector position, int radius)
	{
		List<GridPlacementPbInfo> gridCells = new List<GridPlacementPbInfo>();
		this.ForEachGridCell(position, radius, true, 7, delegate(string gridId, FKuroBuildingGridCellVector coords, int cellIndex)
		{
			if (ModelBase<BuildingGridModel>.Instance.IsCellPolluted(gridId, cellIndex) > 0)
			{
				return;
			}
			GridPlacementPbInfo gridPlacementPbInfo = GridPlacementPbInfo.Create();
			gridPlacementPbInfo.ActorGuid = gridId;
			gridPlacementPbInfo.X = coords.X;
			gridPlacementPbInfo.Y = coords.Y;
			gridPlacementPbInfo.Direction = GridPbDirection.GridForward;
			gridCells.Add(gridPlacementPbInfo);
		});
		return gridCells;
	}

	// Token: 0x040051D8 RID: 20952
	[Nullable(2)]
	[StaticVariableRuleIgnore]
	private static readonly MethodInfo ForEachIntersectingCellMethod = typeof(UKuroBuildingGridSubsystem).GetMethod("K2_ForEachIntersectingCell");
}
