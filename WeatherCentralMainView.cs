using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D1A RID: 11546
[NullableContext(1)]
[Nullable(0)]
public class WeatherCentralMainView : UiViewBase
{
	// Token: 0x060174F3 RID: 95475 RVA: 0x0067636E File Offset: 0x0067456E
	public WeatherCentralMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060174F4 RID: 95476 RVA: 0x00676380 File Offset: 0x00674580
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060174F5 RID: 95477 RVA: 0x006764B0 File Offset: 0x006746B0
	protected override UniTask OnBeforeStartAsync()
	{
		WeatherCentralMainView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeatherCentralMainView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060174F6 RID: 95478 RVA: 0x006764F4 File Offset: 0x006746F4
	protected override void OnStart()
	{
		PopupCaptionItem caption = this.Caption;
		if (caption != null)
		{
			caption.SetCloseCallBack(delegate
			{
				this.CloseMe(null);
			});
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(7);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChange));
		}
		WeatherCentralBottomItem bottomItem = this.BottomItem;
		if (bottomItem != null)
		{
			bottomItem.SetClickConfirmCallback(new Action(this.OnClickConfirm));
		}
		this.CircleItem = base.GetItem(5);
		this.LeftItems = new List<UUIItem>();
		foreach (WeatherToggleItem weatherToggleItem in this.ListLeft.GetLayoutItemList())
		{
			this.LeftItems.Add(weatherToggleItem.GetRootItem());
		}
		this.RightItems = new List<UUIItem>();
		foreach (WeatherToggleItem weatherToggleItem2 in this.ListRight.GetLayoutItemList())
		{
			this.RightItems.Add(weatherToggleItem2.GetRootItem());
		}
		int index = 0;
		IEnumerable<WeatherSwitch> weatherSwitchConfigAll = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfigAll();
		int? configId = this.OpenParam as int?;
		if (configId == null)
		{
			int currentWeatherId = ModelBase<WeatherModel>.Instance.CurrentWeatherId;
			configId = new int?(ModelBase<WeatherModel>.Instance.GetSwitchConfigIdByWeatherId(currentWeatherId));
		}
		int num = weatherSwitchConfigAll.ToList<WeatherSwitch>().FindIndex(delegate(WeatherSwitch item)
		{
			int id = item.Id;
			int? configId = configId;
			return id == configId.GetValueOrDefault() & configId != null;
		});
		if (num >= 0)
		{
			index = num;
		}
		this.SelectToggle(index);
		this.OnRedDotUpdate();
	}

	// Token: 0x060174F7 RID: 95479 RVA: 0x006766B4 File Offset: 0x006748B4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnWeatherCentralRedDotUpdate, new Action(this.OnRedDotUpdate));
	}

	// Token: 0x060174F8 RID: 95480 RVA: 0x006766D2 File Offset: 0x006748D2
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnWeatherCentralRedDotUpdate, new Action(this.OnRedDotUpdate));
	}

	// Token: 0x060174F9 RID: 95481 RVA: 0x006766F0 File Offset: 0x006748F0
	private void SelectToggle(int index)
	{
		if (index % 2 == 0)
		{
			int index2 = index / 2;
			WeatherToggleItem layoutItemByIndex = this.ListLeft.GetLayoutItemByIndex(index2);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetToggleStateForce(true, true, true);
				return;
			}
		}
		else
		{
			int index3 = (index - 1) / 2;
			WeatherToggleItem layoutItemByIndex2 = this.ListRight.GetLayoutItemByIndex(index3);
			if (layoutItemByIndex2 != null)
			{
				layoutItemByIndex2.SetToggleStateForce(true, true, true);
			}
		}
	}

	// Token: 0x060174FA RID: 95482 RVA: 0x00676740 File Offset: 0x00674940
	private void OnRedDotUpdate()
	{
		GenericLayout<WeatherToggleItem, IWeatherToggleData> listLeft = this.ListLeft;
		IEnumerable<WeatherToggleItem> enumerable = (listLeft != null) ? listLeft.GetLayoutItemList() : null;
		foreach (WeatherToggleItem weatherToggleItem in (enumerable ?? Enumerable.Empty<WeatherToggleItem>()))
		{
			weatherToggleItem.RefreshRedDot();
		}
		GenericLayout<WeatherToggleItem, IWeatherToggleData> listRight = this.ListRight;
		enumerable = ((listRight != null) ? listRight.GetLayoutItemList() : null);
		foreach (WeatherToggleItem weatherToggleItem2 in (enumerable ?? Enumerable.Empty<WeatherToggleItem>()))
		{
			weatherToggleItem2.RefreshRedDot();
		}
	}

	// Token: 0x060174FB RID: 95483 RVA: 0x006767F4 File Offset: 0x006749F4
	private UniTask InitializeWeatherToggleList()
	{
		WeatherCentralMainView.<InitializeWeatherToggleList>d__17 <InitializeWeatherToggleList>d__;
		<InitializeWeatherToggleList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeWeatherToggleList>d__.<>4__this = this;
		<InitializeWeatherToggleList>d__.<>1__state = -1;
		<InitializeWeatherToggleList>d__.<>t__builder.Start<WeatherCentralMainView.<InitializeWeatherToggleList>d__17>(ref <InitializeWeatherToggleList>d__);
		return <InitializeWeatherToggleList>d__.<>t__builder.Task;
	}

	// Token: 0x060174FC RID: 95484 RVA: 0x00676838 File Offset: 0x00674A38
	private WeatherToggleItem CreateLeftWeatherToggleItem()
	{
		WeatherToggleItem item = new WeatherToggleItem();
		item.SetToggleClickCallback(delegate
		{
			this.OnToggleClick(true, item);
		});
		item.SetCanExecuteChange((int index) => this.CanExecuteChange(true, index));
		return item;
	}

	// Token: 0x060174FD RID: 95485 RVA: 0x00676894 File Offset: 0x00674A94
	private WeatherToggleItem CreateRightWeatherToggleItem()
	{
		WeatherToggleItem item = new WeatherToggleItem();
		item.SetToggleClickCallback(delegate
		{
			this.OnToggleClick(false, item);
		});
		item.SetCanExecuteChange((int index) => this.CanExecuteChange(false, index));
		return item;
	}

	// Token: 0x060174FE RID: 95486 RVA: 0x006768F0 File Offset: 0x00674AF0
	private void OnClickConfirm()
	{
		if (this.SelectedConfigId < 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Weather, ELogAuthor.LJ, "选择的天气非法或没有选择天气！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
		int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(currentAreaId);
		int num = ModelBase<WeatherModel>.Instance.IsInValidArea(levelOneAreaId) ? 1 : 0;
		bool flag = ModelBase<WeatherModel>.Instance.IsWeatherBanArea(this.SelectedConfigId, levelOneAreaId);
		if (num == 0 || flag)
		{
			int markId = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(this.SelectedConfigId).Value.MarkConfigId;
			if (!ModelBase<MapModel>.Instance.IsConfigMarkIdUnlock(markId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WeatherControl_InvalidAreaTips", Array.Empty<object>());
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WeatherCentralTeleportConfirm);
			TOnTelSuccessCallBack <>9__1;
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				WorldMapController instance = ControllerBase<WorldMapController>.Instance;
				int markId = markId;
				TOnTelSuccessCallBack successAction;
				if ((successAction = <>9__1) == null)
				{
					successAction = (<>9__1 = delegate()
					{
						WeatherModel instance2 = ModelBase<WeatherModel>.Instance;
						if (instance2 == null)
						{
							return;
						}
						instance2.SetTargetWeatherSwitchConfigId(this.SelectedConfigId);
					});
				}
				instance.TryTeleport(markId, successAction);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		else
		{
			if (!ModelBase<WeatherModel>.Instance.IsCurrentTimeInValidTime(this.SelectedConfigId) && ModelBase<WeatherModel>.Instance.TimeSwitchConfirmNeedShow)
			{
				ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.WeatherCentralTimeSwitchConfirm);
				confirmBoxDataNew2.HasToggle = true;
				confirmBoxDataNew2.ToggleText = ConfigBase<TextConfig>.Instance.GetTextById("PlotSkipConfirmToggle");
				confirmBoxDataNew2.SetToggleFunction(delegate(bool isSelectOn)
				{
					ModelBase<WeatherModel>.Instance.TimeSwitchConfirmNeedShow = !isSelectOn;
				});
				confirmBoxDataNew2.FunctionMap.Add(2, delegate
				{
					this.ClickConfirm(levelOneAreaId);
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
				return;
			}
			this.ClickConfirm(levelOneAreaId);
			return;
		}
	}

	// Token: 0x060174FF RID: 95487 RVA: 0x00676AC4 File Offset: 0x00674CC4
	private void ClickConfirm(int levelOneAreaId)
	{
		Singleton<UiManager>.Instance.ResetToBattleView(null);
		ControllerBase<AutoPilotController>.Instance.ExitAutoPilot("WeatherSwitch", false).Forget();
		int accelerateWeatherTime = ModelBase<WeatherModel>.Instance.GetAccelerateWeatherTime(this.SelectedConfigId);
		if (accelerateWeatherTime <= 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Weather, ELogAuthor.LJ, "无需时间加速", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OnAccelerateTimeFinished();
			ModelBase<WeatherModel>.Instance.ObservatoryModule.PlayWeatherControlSequence(new Action(this.OnAllSequencePlayCompleted));
			return;
		}
		ModelBase<WeatherModel>.Instance.ObservatoryModule.AccelerateTime(levelOneAreaId, accelerateWeatherTime, new Action(this.OnAllSequencePlayCompleted), new Action(this.OnAccelerateTimeFinished));
	}

	// Token: 0x06017500 RID: 95488 RVA: 0x00676B74 File Offset: 0x00674D74
	private void OnAccelerateTimeFinished()
	{
		WeatherModel instance = ModelBase<WeatherModel>.Instance;
		if (instance != null)
		{
			instance.RecordSwitchTime();
		}
		double second = ModelBase<TimeOfDayModel>.Instance.GameTime.Second;
		ControllerBase<TimeOfDayController>.Instance.AdjustTime(second, SceneDateUpdateReason.PlayerOperate, 0U, true);
	}

	// Token: 0x06017501 RID: 95489 RVA: 0x00676BAF File Offset: 0x00674DAF
	private void OnAllSequencePlayCompleted()
	{
		ControllerBase<WeatherController>.Instance.RequestSwitchWeather(this.SelectedConfigId).Forget();
	}

	// Token: 0x06017502 RID: 95490 RVA: 0x00676BC8 File Offset: 0x00674DC8
	private void OnToggleClick(bool isLeftSide, WeatherToggleItem item)
	{
		if (isLeftSide)
		{
			GenericLayout<WeatherToggleItem, IWeatherToggleData> listRight = this.ListRight;
			if (listRight != null)
			{
				listRight.DeselectCurrentGridProxy();
			}
			GenericLayout<WeatherToggleItem, IWeatherToggleData> listLeft = this.ListLeft;
			if (listLeft != null)
			{
				listLeft.SelectGridProxy(item.GridIndex, false);
			}
		}
		else
		{
			GenericLayout<WeatherToggleItem, IWeatherToggleData> listLeft2 = this.ListLeft;
			if (listLeft2 != null)
			{
				listLeft2.DeselectCurrentGridProxy();
			}
			GenericLayout<WeatherToggleItem, IWeatherToggleData> listRight2 = this.ListRight;
			if (listRight2 != null)
			{
				listRight2.SelectGridProxy(item.GridIndex, false);
			}
		}
		WeatherCentralBottomItem bottomItem = this.BottomItem;
		if (bottomItem != null)
		{
			bottomItem.RefreshByConfigId(item.ConfigId);
		}
		this.SelectedConfigId = item.ConfigId;
		if (ModelBase<WeatherModel>.Instance.IsWeatherSwitchConfigUnlocked(item.ConfigId))
		{
			ModelBase<WeatherModel>.Instance.RecordWeatherClicked(item.ConfigId);
		}
	}

	// Token: 0x06017503 RID: 95491 RVA: 0x00676C71 File Offset: 0x00674E71
	private bool CanExecuteChange(bool isLeftSide, int index)
	{
		if (isLeftSide)
		{
			GenericLayout<WeatherToggleItem, IWeatherToggleData> listLeft = this.ListLeft;
			return listLeft == null || listLeft.GetSelectedGridIndex() != index;
		}
		GenericLayout<WeatherToggleItem, IWeatherToggleData> listRight = this.ListRight;
		return listRight == null || listRight.GetSelectedGridIndex() != index;
	}

	// Token: 0x06017504 RID: 95492 RVA: 0x00676CA8 File Offset: 0x00674EA8
	private void OnScrollValueChange(FVector2D inVector)
	{
		float num = 0.1f;
		float num2 = 0.35f;
		float y = this.CircleItem.GetLGUISpaceAbsolutePosition().Y;
		float radius = this.CircleItem.Width / 2f;
		float[] array = this.CalculateCircularOffsets(this.LeftItems, y, radius);
		for (int i = 0; i < this.LeftItems.Count; i++)
		{
			float alpha = array[i];
			this.LeftItems[i].SetPivot(new FVector2D(Singleton<MathUtils>.Instance.Lerp(0.5f + num, 0f - num2, alpha), 0.5f));
		}
		float[] array2 = this.CalculateCircularOffsets(this.RightItems, y, radius);
		for (int j = 0; j < this.RightItems.Count; j++)
		{
			float alpha2 = array2[j];
			this.RightItems[j].SetPivot(new FVector2D(Singleton<MathUtils>.Instance.Lerp(0.5f - num, 1f + num2, alpha2), 0.5f));
		}
	}

	// Token: 0x06017505 RID: 95493 RVA: 0x00676DB4 File Offset: 0x00674FB4
	private float[] CalculateCircularOffsets(List<UUIItem> items, float centerY, float radius)
	{
		List<float> list = new List<float>();
		foreach (UUIItem uuiitem in items)
		{
			float num = Math.Min(Math.Abs(uuiitem.GetLGUISpaceAbsolutePosition().Y - centerY) / radius, 1f);
			float item = (float)Math.Sqrt((double)(1f - num * num));
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x06017506 RID: 95494 RVA: 0x00676E3C File Offset: 0x0067503C
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
		if (configParams[0] == "WeatherNotSelected")
		{
			foreach (WeatherToggleItem weatherToggleItem in this.ListLeft.GetLayoutItemList())
			{
				if (weatherToggleItem.GetToggleState() == EToggleState.ETT_UnChecked)
				{
					UUIItem toggleItem = weatherToggleItem.GetToggleItem();
					if (toggleItem != null)
					{
						return new UUIItem[]
						{
							toggleItem,
							toggleItem
						};
					}
				}
			}
		}
		return null;
	}

	// Token: 0x0400B30B RID: 45835
	[Nullable(2)]
	private PopupCaptionItem Caption;

	// Token: 0x0400B30C RID: 45836
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeatherToggleItem, IWeatherToggleData> ListLeft;

	// Token: 0x0400B30D RID: 45837
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeatherToggleItem, IWeatherToggleData> ListRight;

	// Token: 0x0400B30E RID: 45838
	[Nullable(2)]
	private WeatherCentralBottomItem BottomItem;

	// Token: 0x0400B30F RID: 45839
	[Nullable(2)]
	private UUIItem CircleItem;

	// Token: 0x0400B310 RID: 45840
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUIItem> LeftItems;

	// Token: 0x0400B311 RID: 45841
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUIItem> RightItems;

	// Token: 0x0400B312 RID: 45842
	private int SelectedConfigId = -1;

	// Token: 0x0400B313 RID: 45843
	private const int MAX_TOGGLE_COUNT = 8;
}
