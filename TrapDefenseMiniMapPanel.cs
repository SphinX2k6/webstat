using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D9F RID: 7583
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseMiniMapPanel : BattleChildViewPanel
{
	// Token: 0x0600DF95 RID: 57237 RVA: 0x003C25B4 File Offset: 0x003C07B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OpenMap))
		};
	}

	// Token: 0x0600DF96 RID: 57238 RVA: 0x003C26A0 File Offset: 0x003C08A0
	public override void InitializeTemp()
	{
		this.MapType = (((this.OpenParam as EBattleUiChild?).GetValueOrDefault() != EBattleUiChild.MiniMap) ? 1 : 0);
		this.SetUp();
	}

	// Token: 0x0600DF97 RID: 57239 RVA: 0x003C26D8 File Offset: 0x003C08D8
	public void OnTowerDefenseStepUpdate(ETowerDefenseEventProcessStatus status)
	{
		foreach (KeyValuePair<int, TrapDefenseMarkView> keyValuePair in this.MarkViewMap)
		{
			keyValuePair.Value.OnTowerDefenseStepUpdate(status);
		}
		this.ProcessPhantomPointVisible();
		if (status == ETowerDefenseEventProcessStatus.Ready)
		{
			ModelBase<TrapDefenseModel>.Instance.MapData.InitSplineData();
			this.ShowPhantomPreviewRoute();
			return;
		}
		this.StopShowPhantomPreviewRoute();
	}

	// Token: 0x0600DF98 RID: 57240 RVA: 0x003C2758 File Offset: 0x003C0958
	private void ProcessPhantomPointVisible()
	{
		List<TrapDefensePhantomPointMarkItem> dynamicMarksByMarkType = ModelBase<TrapDefenseModel>.Instance.MapData.GetDynamicMarksByMarkType<TrapDefensePhantomPointMarkItem>(TrapDefenseDefine.ETrapDefenseMarkType.PhantomPoint);
		dynamicMarksByMarkType.Sort(delegate(TrapDefensePhantomPointMarkItem a, TrapDefensePhantomPointMarkItem b)
		{
			if (a.IsActivated() == b.IsActivated())
			{
				return a.MarkId - b.MarkId;
			}
			if (!a.IsActivated())
			{
				return -1;
			}
			return 1;
		});
		List<global::Vector> list = new List<global::Vector>();
		foreach (TrapDefensePhantomPointMarkItem trapDefensePhantomPointMarkItem in dynamicMarksByMarkType)
		{
			list.Add(trapDefensePhantomPointMarkItem.WorldPosition);
		}
		global::Vector vector = global::Vector.Create();
		for (int i = 0; i < dynamicMarksByMarkType.Count; i++)
		{
			bool uiActive = true;
			for (int j = i + 1; j < dynamicMarksByMarkType.Count; j++)
			{
				list[j].Subtraction(list[i], vector);
				if (vector.IsNearlyZero(9.999999747378752E-05))
				{
					uiActive = false;
					break;
				}
			}
			TrapDefenseMarkView trapDefenseMarkView;
			if (this.MarkViewMap.TryGetValue(dynamicMarksByMarkType[i].MarkId, out trapDefenseMarkView))
			{
				trapDefenseMarkView.SetUiActive(uiActive);
			}
		}
	}

	// Token: 0x0600DF99 RID: 57241 RVA: 0x003C2874 File Offset: 0x003C0A74
	private void RefreshMap(int mapId)
	{
		TrapDefenseMap? trapDefenseMapConfigById = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseMapConfigById(mapId);
		if (trapDefenseMapConfigById == null)
		{
			this.RootItem.SetUIActive(false);
			return;
		}
		string path = (this.MapType == 0) ? trapDefenseMapConfigById.Value.MiniMapResourcePath : trapDefenseMapConfigById.Value.MapResourcePath;
		this.Scale = ((this.MapType == 0) ? trapDefenseMapConfigById.Value.MiniMapScale : trapDefenseMapConfigById.Value.MapScale);
		float[] array = (this.MapType == 0) ? trapDefenseMapConfigById.Value.GetUiOffsetArray() : trapDefenseMapConfigById.Value.GetBigMapUiOffsetArray();
		if (array != null && array.Length >= 2)
		{
			this.UiOffset.Set((double)array[0], (double)array[1]);
		}
		else
		{
			this.UiOffset.Reset();
		}
		if (trapDefenseMapConfigById.Value.GetCenterOffsetArray() != null && trapDefenseMapConfigById.Value.GetCenterOffsetArray().Length >= 2)
		{
			this.CenterOffset.Set((double)trapDefenseMapConfigById.Value.GetCenterOffsetArray()[0], (double)trapDefenseMapConfigById.Value.GetCenterOffsetArray()[1]);
			if (this.MapType == 1)
			{
				this.CenterOffset.MultiplyEqual(2.0);
			}
		}
		AActor owner = base.GetButton(7).GetOwner();
		UUIItem uuiitem = ((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem;
		if (uuiitem != null)
		{
			uuiitem.SetAnchorOffset(this.UiOffset.ToUeVector2D(false));
		}
		base.SetTextureByPath(path, base.GetTexture(0), null, null);
		base.GetItem(1).SetUIActive(false);
		base.SetTextureByPath(trapDefenseMapConfigById.Value.MiniMapLightResourcePath, base.GetTexture(6), null, null);
	}

	// Token: 0x0600DF9A RID: 57242 RVA: 0x003C2A49 File Offset: 0x003C0C49
	protected override void OnStart()
	{
		this.TimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Update), 50f, 1f, null, null, true);
	}

	// Token: 0x0600DF9B RID: 57243 RVA: 0x003C2A74 File Offset: 0x003C0C74
	protected override void OnBeforeDestroy()
	{
		if (this.TimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			this.TimerId = null;
		}
		this.StopShowPhantomPreviewRoute();
		if (this.MapType == 0)
		{
			ModelBase<TrapDefenseModel>.Instance.MapData.ClearAllSpline();
			ModelBase<TrapDefenseModel>.Instance.MapData.ClearMapChanged();
		}
		foreach (KeyValuePair<int, TrapDefenseMarkView> keyValuePair in this.MarkViewMap)
		{
			keyValuePair.Value.Destroy(null);
		}
		this.MarkViewMap.Clear();
	}

	// Token: 0x0600DF9C RID: 57244 RVA: 0x003C2B24 File Offset: 0x003C0D24
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseActivityDataUpdate, new Action(this.SetUp));
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseMapMarkRemoved, new Action<int>(this.RemoveMark));
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseMapChanged, new Action<int>(this.OnChangeMap));
	}

	// Token: 0x0600DF9D RID: 57245 RVA: 0x003C2B88 File Offset: 0x003C0D88
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseActivityDataUpdate, new Action(this.SetUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseMapMarkRemoved, new Action<int>(this.RemoveMark));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseMapChanged, new Action<int>(this.OnChangeMap));
	}

	// Token: 0x0600DF9E RID: 57246 RVA: 0x003C2BEC File Offset: 0x003C0DEC
	private void SetUp()
	{
		if (ModelBase<TrapDefenseModel>.Instance.MapData.MapId != 0)
		{
			this.RootItem.SetUIActive(true);
			this.CreateAllMarks();
			this.RefreshMap(ModelBase<TrapDefenseModel>.Instance.MapData.MapId);
			ETowerDefenseEventProcessStatus processStatus = ControllerBase<TowerDefenseEventController>.Instance.ProcessStatus;
			this.OnTowerDefenseStepUpdate(processStatus);
		}
	}

	// Token: 0x0600DF9F RID: 57247 RVA: 0x003C2C44 File Offset: 0x003C0E44
	public override void Reset()
	{
		if (this.TimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			this.TimerId = null;
		}
		base.Reset();
	}

	// Token: 0x0600DFA0 RID: 57248 RVA: 0x003C2C6C File Offset: 0x003C0E6C
	private UniTask CreateAllMarks()
	{
		TrapDefenseMiniMapPanel.<CreateAllMarks>d__22 <CreateAllMarks>d__;
		<CreateAllMarks>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAllMarks>d__.<>4__this = this;
		<CreateAllMarks>d__.<>1__state = -1;
		<CreateAllMarks>d__.<>t__builder.Start<TrapDefenseMiniMapPanel.<CreateAllMarks>d__22>(ref <CreateAllMarks>d__);
		return <CreateAllMarks>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFA1 RID: 57249 RVA: 0x003C2CB0 File Offset: 0x003C0EB0
	private UniTask CreateMark(int markId)
	{
		TrapDefenseMiniMapPanel.<CreateMark>d__23 <CreateMark>d__;
		<CreateMark>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMark>d__.<>4__this = this;
		<CreateMark>d__.markId = markId;
		<CreateMark>d__.<>1__state = -1;
		<CreateMark>d__.<>t__builder.Start<TrapDefenseMiniMapPanel.<CreateMark>d__23>(ref <CreateMark>d__);
		return <CreateMark>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFA2 RID: 57250 RVA: 0x003C2CFB File Offset: 0x003C0EFB
	private void Update(float deltaTime)
	{
		this.UpdateEnemyPosition();
		this.UpdateAllMarkItems(false);
		this.UpdatePointPositions();
	}

	// Token: 0x0600DFA3 RID: 57251 RVA: 0x003C2D10 File Offset: 0x003C0F10
	private void UpdateAllMarkItems(bool force = false)
	{
		foreach (KeyValuePair<int, TrapDefenseMarkView> keyValuePair in this.MarkViewMap)
		{
			TrapDefenseMarkView value = keyValuePair.Value;
			if ((value.NeedUpdatePosition || force) && value.IsShow && value.GetMarkData() != null)
			{
				value.UpdatePosition(this.Scale, this.CenterOffset);
			}
		}
	}

	// Token: 0x0600DFA4 RID: 57252 RVA: 0x003C2D90 File Offset: 0x003C0F90
	private void UpdateEnemyPosition()
	{
		ControllerBase<TrapDefenseController>.Instance.UpdateEnemyPositions();
		foreach (TrapDefenseMonsterMarkItem trapDefenseMonsterMarkItem in ModelBase<TrapDefenseModel>.Instance.MapData.GetDynamicMarksByMarkType<TrapDefenseMonsterMarkItem>(TrapDefenseDefine.ETrapDefenseMarkType.Phantom))
		{
			TrapDefenseMarkView trapDefenseMarkView;
			if (this.MarkViewMap.TryGetValue(trapDefenseMonsterMarkItem.MarkId, out trapDefenseMarkView))
			{
				if (trapDefenseMarkView.NeedUpdatePosition && trapDefenseMarkView.IsShow && trapDefenseMarkView.GetMarkData() != null)
				{
					trapDefenseMarkView.UpdatePosition(this.Scale, this.CenterOffset);
				}
			}
			else
			{
				this.CreateMark(trapDefenseMonsterMarkItem.MarkId);
			}
		}
	}

	// Token: 0x0600DFA5 RID: 57253 RVA: 0x003C2E40 File Offset: 0x003C1040
	private void RemoveMark(int markId)
	{
		TrapDefenseMarkView trapDefenseMarkView;
		if (this.MarkViewMap.TryGetValue(markId, out trapDefenseMarkView))
		{
			trapDefenseMarkView.Destroy(null);
			this.MarkViewMap.Remove(markId);
		}
	}

	// Token: 0x0600DFA6 RID: 57254 RVA: 0x003C2E71 File Offset: 0x003C1071
	private void OnChangeMap(int mapId)
	{
		this.RefreshMap(mapId);
	}

	// Token: 0x0600DFA7 RID: 57255 RVA: 0x003C2E7A File Offset: 0x003C107A
	private void ShowPhantomPreviewRoute()
	{
		if (this.PreviewRouteTimerId != null)
		{
			return;
		}
		this.PreviewRouteTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.GenerateRoutePreviewGroup), (float)ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseRoutePreviewInterval(), 1f, null, null, true);
	}

	// Token: 0x0600DFA8 RID: 57256 RVA: 0x003C2EB4 File Offset: 0x003C10B4
	private void GenerateRoutePreviewGroup(float deltaTime)
	{
		List<TrapDefensePhantomPointMarkItem> dynamicMarksByMarkType = ModelBase<TrapDefenseModel>.Instance.MapData.GetDynamicMarksByMarkType<TrapDefensePhantomPointMarkItem>(TrapDefenseDefine.ETrapDefenseMarkType.PhantomPoint);
		List<int> list = new List<int>();
		foreach (TrapDefensePhantomPointMarkItem trapDefensePhantomPointMarkItem in dynamicMarksByMarkType)
		{
			if (trapDefensePhantomPointMarkItem.IsActivated())
			{
				list.Add(trapDefensePhantomPointMarkItem.SplineId);
			}
		}
		foreach (int key in list)
		{
			if (!this.SplinePointView.ContainsKey(key))
			{
				this.SplinePointView[key] = new List<List<TrapDefenseRoutePointView>>();
			}
			this.SplinePointView[key].Add(new List<TrapDefenseRoutePointView>());
			List<List<TrapDefenseRoutePointView>> list2 = this.SplinePointView[key];
			List<TrapDefenseRoutePointView> list3 = list2[list2.Count - 1];
			int trapDefenseRoutePointShootInterval = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseRoutePointShootInterval();
			for (int i = 0; i < ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseRoutePointNum(); i++)
			{
				TrapDefenseRoutePointView trapDefenseRoutePointView = new TrapDefenseRoutePointView();
				trapDefenseRoutePointView.StartTimestamp = TimerSystem.GameplayTimeInstance.Now + (double)(trapDefenseRoutePointShootInterval * i);
				trapDefenseRoutePointView.Index = i;
				trapDefenseRoutePointView.CreateThenShowByPathAsync("/Game/Aki/UI/UIResources/UiFight/Prefabs/Activity/TowerDefense/DynMapPointIcon.DynMapPointIcon", base.GetItem(3), false);
				list3.Add(trapDefenseRoutePointView);
			}
		}
	}

	// Token: 0x0600DFA9 RID: 57257 RVA: 0x003C3020 File Offset: 0x003C1220
	private void UpdatePointPositions()
	{
		int trapDefenseRoutePreviewTime = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseRoutePreviewTime();
		foreach (KeyValuePair<int, List<List<TrapDefenseRoutePointView>>> keyValuePair in this.SplinePointView)
		{
			int key = keyValuePair.Key;
			List<List<TrapDefenseRoutePointView>> value = keyValuePair.Value;
			USplineComponent splineComponent = ModelBase<TrapDefenseModel>.Instance.MapData.GetSplineComponent(key);
			float splineLength = splineComponent.GetSplineLength();
			for (int i = 0; i < value.Count; i++)
			{
				List<TrapDefenseRoutePointView> list = value[i];
				List<TrapDefenseRoutePointView> list2 = new List<TrapDefenseRoutePointView>();
				for (int j = 0; j < list.Count; j++)
				{
					TrapDefenseRoutePointView trapDefenseRoutePointView = list[j];
					double num = TimerSystem.GameplayTimeInstance.Now - trapDefenseRoutePointView.StartTimestamp;
					if (num >= (double)trapDefenseRoutePreviewTime)
					{
						trapDefenseRoutePointView.Destroy(null);
					}
					else
					{
						double num2 = (double)splineLength * Math.Min((double)trapDefenseRoutePreviewTime, num) / (double)trapDefenseRoutePreviewTime;
						FVectorDouble fvectorDouble = splineComponent.D_GetLocationAtDistanceAlongSpline((float)num2, ESplineCoordinateSpace.World);
						trapDefenseRoutePointView.UpdatePosition(fvectorDouble, this.Scale, this.CenterOffset);
						list2.Add(trapDefenseRoutePointView);
					}
				}
				value[i] = list2;
			}
		}
	}

	// Token: 0x0600DFAA RID: 57258 RVA: 0x003C3178 File Offset: 0x003C1378
	private void StopShowPhantomPreviewRoute()
	{
		this.StopSplineTimers();
		this.ClearPreviewRoute();
		if (this.MapType == 0)
		{
			ModelBase<TrapDefenseModel>.Instance.MapData.ClearAllSpline();
		}
	}

	// Token: 0x0600DFAB RID: 57259 RVA: 0x003C319D File Offset: 0x003C139D
	private void StopSplineTimers()
	{
		if (this.PreviewRouteTimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.PreviewRouteTimerId);
			this.PreviewRouteTimerId = null;
		}
	}

	// Token: 0x0600DFAC RID: 57260 RVA: 0x003C31C0 File Offset: 0x003C13C0
	private void ClearPreviewRoute()
	{
		foreach (List<List<TrapDefenseRoutePointView>> list in this.SplinePointView.Values)
		{
			foreach (List<TrapDefenseRoutePointView> list2 in list)
			{
				foreach (TrapDefenseRoutePointView trapDefenseRoutePointView in list2)
				{
					trapDefenseRoutePointView.Destroy(null);
				}
			}
		}
		this.SplinePointView.Clear();
	}

	// Token: 0x0600DFAD RID: 57261 RVA: 0x003C328C File Offset: 0x003C148C
	private void OpenMap()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseMapView, null, null);
	}

	// Token: 0x0600DFAE RID: 57262 RVA: 0x003C32A0 File Offset: 0x003C14A0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (configParams[0] != "DynActivityTowerMap")
		{
			return null;
		}
		UUIItem guideUiItem = base.GetGuideUiItem("0");
		if (guideUiItem == null)
		{
			return null;
		}
		UUIButtonComponent button = base.GetButton(7);
		UUIItem uuiitem = (button != null) ? button.GetRootComponent() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			guideUiItem
		};
	}

	// Token: 0x04006B73 RID: 27507
	private const int UPDATE_INTERVAL = 50;

	// Token: 0x04006B74 RID: 27508
	private int MapType;

	// Token: 0x04006B75 RID: 27509
	private readonly Dictionary<int, TrapDefenseMarkView> MarkViewMap = new Dictionary<int, TrapDefenseMarkView>();

	// Token: 0x04006B76 RID: 27510
	[Nullable(2)]
	private TimerHandle TimerId;

	// Token: 0x04006B77 RID: 27511
	private readonly Vector2D UiOffset = Vector2D.Create();

	// Token: 0x04006B78 RID: 27512
	private readonly Vector2D CenterOffset = Vector2D.Create();

	// Token: 0x04006B79 RID: 27513
	private float Scale = 1f;

	// Token: 0x04006B7A RID: 27514
	[Nullable(2)]
	private TimerHandle PreviewRouteTimerId;

	// Token: 0x04006B7B RID: 27515
	private readonly Dictionary<int, List<List<TrapDefenseRoutePointView>>> SplinePointView = new Dictionary<int, List<List<TrapDefenseRoutePointView>>>();

	// Token: 0x0200813C RID: 33084
	[NullableContext(0)]
	private static class EChildComponentType
	{
		// Token: 0x0402BEC7 RID: 179911
		public const int TextureMap = 0;

		// Token: 0x0402BEC8 RID: 179912
		public const int PanelAnim = 1;

		// Token: 0x0402BEC9 RID: 179913
		public const int Arrow = 2;

		// Token: 0x0402BECA RID: 179914
		public const int MiniMapRoot = 3;

		// Token: 0x0402BECB RID: 179915
		public const int PlayerItem = 4;

		// Token: 0x0402BECC RID: 179916
		public const int PlayerSight = 5;

		// Token: 0x0402BECD RID: 179917
		public const int TextureLight = 6;

		// Token: 0x0402BECE RID: 179918
		public const int PanelPos = 7;
	}

	// Token: 0x0200813D RID: 33085
	[NullableContext(0)]
	private static class EMapShowType
	{
		// Token: 0x0402BECF RID: 179919
		public const int MiniMap = 0;

		// Token: 0x0402BED0 RID: 179920
		public const int BigMap = 1;
	}
}
