using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001397 RID: 5015
[NullableContext(1)]
[Nullable(0)]
public class MapTravelMainView : UiViewBase
{
	// Token: 0x060089DD RID: 35293 RVA: 0x00244270 File Offset: 0x00242470
	public MapTravelMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060089DE RID: 35294 RVA: 0x002442F4 File Offset: 0x002424F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 28;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIMultiTemplateLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickedPreLevelButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedNextLevelButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060089DF RID: 35295 RVA: 0x0024472C File Offset: 0x0024292C
	protected override UniTask OnBeforeStartAsync()
	{
		MapTravelMainView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MapTravelMainView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060089E0 RID: 35296 RVA: 0x00244770 File Offset: 0x00242970
	private UniTask CreateSubViewButton()
	{
		MapTravelMainView.<CreateSubViewButton>d__26 <CreateSubViewButton>d__;
		<CreateSubViewButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateSubViewButton>d__.<>4__this = this;
		<CreateSubViewButton>d__.<>1__state = -1;
		<CreateSubViewButton>d__.<>t__builder.Start<MapTravelMainView.<CreateSubViewButton>d__26>(ref <CreateSubViewButton>d__);
		return <CreateSubViewButton>d__.<>t__builder.Task;
	}

	// Token: 0x060089E1 RID: 35297 RVA: 0x002447B4 File Offset: 0x002429B4
	protected override void OnStart()
	{
		this.LevelUpButton.SetRedDotVisible(true);
		this.SelectedLevel = this.ActivityBaseData.TravelLevel;
		MapTravelConfig activityConfig = this.ActivityBaseData.GetActivityConfig();
		this.CaptionComponent.SetTitleByTextIdAndArgNew(activityConfig.GetTabName(0), Array.Empty<object>());
		base.GetSpine(22).SetTimeScale(1.5f);
		UUIItem item = base.GetItem(25);
		UUIItem item2 = base.GetItem(27);
		FVector fvector = item2.K2_GetComponentLocation();
		this.BgOffset = Math.Abs(item.K2_GetComponentLocation().X - fvector.X);
		int num = 2520;
		this.BgScale = (this.BgOffset + (float)num) / (float)num * item2.K2_GetComponentScale().X;
		this.BgLocation = new FVector?(base.GetItem(27).K2_GetComponentLocation());
		this.BgLocation = new FVector?(new FVector(item.K2_GetComponentLocation().X, fvector.Y, item.K2_GetComponentLocation().Z));
	}

	// Token: 0x060089E2 RID: 35298 RVA: 0x002448B5 File Offset: 0x00242AB5
	protected override void OnBeforeShow()
	{
		this.RefreshMainView();
	}

	// Token: 0x060089E3 RID: 35299 RVA: 0x002448BD File Offset: 0x00242ABD
	protected override void OnBeforeDestroy()
	{
		this.BgLocation = null;
	}

	// Token: 0x060089E4 RID: 35300 RVA: 0x002448CB File Offset: 0x00242ACB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
	}

	// Token: 0x060089E5 RID: 35301 RVA: 0x00244902 File Offset: 0x00242B02
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
	}

	// Token: 0x060089E6 RID: 35302 RVA: 0x00244939 File Offset: 0x00242B39
	private void RefreshMainView()
	{
		this.RefreshExpComponent(this.SelectedLevel);
		this.RefreshSubViewButton();
	}

	// Token: 0x060089E7 RID: 35303 RVA: 0x0024494D File Offset: 0x00242B4D
	private void CloseButtonClicked()
	{
		if (this.SelectedViewType == EMapTravelSubType.Main)
		{
			base.CloseMe(null);
			return;
		}
		this.CloseSubView();
	}

	// Token: 0x060089E8 RID: 35304 RVA: 0x00244966 File Offset: 0x00242B66
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "LevelChange")
		{
			this.RefreshExpComponent(this.SelectedLevel);
		}
	}

	// Token: 0x060089E9 RID: 35305 RVA: 0x00244984 File Offset: 0x00242B84
	private void RefreshExpComponent(int level)
	{
		bool flag = level < this.ActivityBaseData.TravelLevel;
		if (level < this.ActivityBaseData.TravelLevel)
		{
			this.SetPerformanceFinishedLevel(level);
		}
		else if (level == this.ActivityBaseData.TravelLevel)
		{
			this.SetPerformanceCurrentLevel(level);
		}
		else
		{
			this.SetPerformanceUnFinishedLevel(level);
		}
		IMapTravelLevelData mapTravelLevelData = this.ActivityBaseData.TravelLevelData[level];
		MapLevelExp value = ConfigBase<ActivityMapTravelConfig>.Instance.GetLevelExpConfig(mapTravelLevelData.Id).Value;
		base.GetText(1).SetText(level.ToString(), true);
		this.CurrentRewardSoarStrengthCount = 0;
		int? intConfig = ConfigCommonParamById.GetIntConfig("FlyStrengthItemId");
		List<TItem> list = (value.RewardDropId > 0) ? ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(value.RewardDropId) : new List<TItem>();
		List<IItemGridData> list2 = new List<IItemGridData>();
		foreach (TItem titem in list)
		{
			ItemGridData item = new ItemGridData
			{
				Item = titem,
				HasClaimed = flag
			};
			list2.Add(item);
			int itemId = titem.ItemData.ItemId;
			int? num = intConfig;
			if (itemId == num.GetValueOrDefault() & num != null)
			{
				this.CurrentRewardSoarStrengthCount++;
			}
		}
		this.LevelRewardLayout.RefreshByData(list2, null, false);
		base.GetItem(6).SetUIActive(list2.Count > 0);
		base.GetItem(9).SetUIActive(!StringUtils.IsEmpty(value.TipsLock));
		if (!StringUtils.IsEmpty(value.TipsLock))
		{
			string textStringId = flag ? value.TipsDone : value.TipsLock;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), textStringId, Array.Empty<object>());
		}
		base.GetButton(4).RootUIComp.Get().SetUIActive(level > 0);
		base.GetButton(5).RootUIComp.Get().SetUIActive(level < this.ActivityBaseData.MaxTravelLevel);
	}

	// Token: 0x060089EA RID: 35306 RVA: 0x00244BA0 File Offset: 0x00242DA0
	private void SetLevelProgress(int current, int target)
	{
		this.SetBarProgress((float)current / (float)target);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "MapTravelExpYellow_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			current,
			target
		}));
		base.GetText(3).SetUIActive(true);
	}

	// Token: 0x060089EB RID: 35307 RVA: 0x00244BF8 File Offset: 0x00242DF8
	private void SetBarProgress(float percent)
	{
		float num = Singleton<MathUtils>.Instance.Clamp(percent, 0f, 1f);
		base.GetTexture(2).SetFillAmount(num);
		float yaw = (1f - num) * 360f;
		this.EffectRotator.Yaw = yaw;
		base.GetItem(24).SetUIActive(num > 0.5f);
		base.GetItem(23).SetUIRelativeRotation(this.EffectRotator);
		base.GetItem(24).SetUIRelativeRotation(this.EffectRotator);
	}

	// Token: 0x060089EC RID: 35308 RVA: 0x00244C80 File Offset: 0x00242E80
	private void SetPerformanceFinishedLevel(int level)
	{
		IMapTravelLevelData mapTravelLevelData = this.ActivityBaseData.TravelLevelData[level];
		int targetExp = mapTravelLevelData.TargetExp;
		int targetExp2 = mapTravelLevelData.TargetExp;
		this.SetLevelProgress(targetExp, targetExp2);
		this.PanelLock.SetUiActive(false);
		this.PanelActivate.SetUiActive(true);
		this.LevelUpButton.SetUiActive(false);
		this.PanelActivate.SetTextByTextId("MapTravelReward_Get", Array.Empty<string>());
	}

	// Token: 0x060089ED RID: 35309 RVA: 0x00244CEC File Offset: 0x00242EEC
	private void SetPerformanceCurrentLevel(int level)
	{
		bool flag = this.ActivityBaseData.MaxTravelLevel == level;
		bool flag2 = !flag && this.ActivityBaseData.CanTravelLevelUp();
		int currentExp = this.ActivityBaseData.GetCurrentExp();
		int currentTargetExp = this.ActivityBaseData.GetCurrentTargetExp();
		if (flag)
		{
			this.SetBarProgress(1f);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "MapTravelLevelMaxYellow_Text", Array.Empty<object>());
			base.GetText(3).SetUIActive(true);
		}
		else
		{
			this.SetLevelProgress(currentExp, currentTargetExp);
		}
		this.PanelLock.SetUiActive(!flag && !flag2);
		this.PanelLock.SetTextByTextId("PrefabTextItem_2462272635_Text", Array.Empty<string>());
		this.PanelActivate.SetUiActive(flag);
		this.LevelUpButton.SetUiActive(flag2);
		if (flag)
		{
			this.PanelActivate.SetTextByTextId("MapTravelLv_Max", Array.Empty<string>());
		}
		if (flag2)
		{
			this.UiViewSequence.PlaySequence("PreLevelUp", false, null);
		}
	}

	// Token: 0x060089EE RID: 35310 RVA: 0x00244DEC File Offset: 0x00242FEC
	private void SetPerformanceUnFinishedLevel(int level)
	{
		IMapTravelLevelData mapTravelLevelData = this.ActivityBaseData.TravelLevelData[level];
		bool flag = this.ActivityBaseData.MaxTravelLevel == level;
		int current = 0;
		int target = flag ? mapTravelLevelData.AccumulateExp : mapTravelLevelData.TargetExp;
		if (flag)
		{
			this.SetBarProgress(0f);
			base.GetText(3).SetUIActive(false);
		}
		else
		{
			this.SetLevelProgress(current, target);
		}
		this.PanelLock.SetUiActive(true);
		this.PanelLock.SetTextByTextId("MapTravelLevelOverUp_Text", Array.Empty<string>());
		this.PanelActivate.SetUiActive(false);
		this.LevelUpButton.SetUiActive(false);
	}

	// Token: 0x060089EF RID: 35311 RVA: 0x00244E8C File Offset: 0x0024308C
	private void OnClickedPreLevelButton()
	{
		this.SelectedLevel--;
		this.UiViewSequence.PlaySequence("SwitchLeft", true, null);
	}

	// Token: 0x060089F0 RID: 35312 RVA: 0x00244EC4 File Offset: 0x002430C4
	private void OnClickedNextLevelButton()
	{
		this.SelectedLevel++;
		this.UiViewSequence.PlaySequence("SwitchRight", true, null);
	}

	// Token: 0x060089F1 RID: 35313 RVA: 0x00244EF9 File Offset: 0x002430F9
	private void OnClickedLevelUpButton()
	{
		ControllerBase<ActivityMapTravelController>.Instance.RequestMapTravelLevelUp(delegate(bool success)
		{
			this.NeedLevelUp = success;
		});
	}

	// Token: 0x060089F2 RID: 35314 RVA: 0x00244F14 File Offset: 0x00243114
	private void LevelUp()
	{
		if (this.NeedLevelUp)
		{
			this.UiViewSequence.PlaySequence("LevelUp", false, null);
			this.SelectedLevel++;
			this.RefreshExpComponent(this.SelectedLevel);
			this.RefreshSubViewButton();
		}
	}

	// Token: 0x060089F3 RID: 35315 RVA: 0x00244F64 File Offset: 0x00243164
	private void OnRewardViewClose(EUiViewName viewName, int ViewId)
	{
		if (this.SelectedViewType != EMapTravelSubType.Main)
		{
			return;
		}
		if (viewName == EUiViewName.CommonRewardView)
		{
			if (this.CurrentRewardSoarStrengthCount > 0)
			{
				this.OpenSoarStrengthView();
			}
			else
			{
				this.LevelUp();
			}
		}
		if (viewName == EUiViewName.RoleLevelUpSuccessAttributeView)
		{
			this.LevelUp();
		}
	}

	// Token: 0x060089F4 RID: 35316 RVA: 0x00244FB4 File Offset: 0x002431B4
	private void OpenSoarStrengthView()
	{
		int value = ConfigCommonParamById.GetIntConfig("FlyStrengthItemId").Value;
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(value);
		if (itemConfig == null || itemConfig.Value.ParametersLength == 0)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		if (num2 < itemConfig.Value.ParametersLength)
		{
			num = itemConfig.Value.Parameters(num2).Value.Value;
		}
		if (num == 0)
		{
			return;
		}
		PropRewardConf? config = ConfigPropRewardConfById.GetConfig(num, true);
		if (config == null)
		{
			return;
		}
		float num3 = 0f;
		for (int i = 0; i < config.Value.PropsLength; i++)
		{
			ConfigPropValue value2 = config.Value.Props(i).Value;
			if (value2.Id == 10)
			{
				num3 = value2.Value;
				break;
			}
		}
		if (num3 == 0f)
		{
			return;
		}
		num3 *= (float)this.CurrentRewardSoarStrengthCount;
		ControllerBase<ActivityMapTravelController>.Instance.OpenSoarStrengthView(num3);
	}

	// Token: 0x060089F5 RID: 35317 RVA: 0x002450D0 File Offset: 0x002432D0
	private void RefreshSubViewButton()
	{
		MapTravelConfig activityConfig = this.ActivityBaseData.GetActivityConfig();
		foreach (KeyValuePair<EMapTravelSubType, MapTravelSubViewButton> keyValuePair in this.SubViewButtonMap)
		{
			EMapTravelSubType emapTravelSubType;
			MapTravelSubViewButton mapTravelSubViewButton;
			keyValuePair.Deconstruct(out emapTravelSubType, out mapTravelSubViewButton);
			EMapTravelSubType emapTravelSubType2 = emapTravelSubType;
			MapTravelSubViewButton mapTravelSubViewButton2 = mapTravelSubViewButton;
			ValueTuple<int, int> typeProgress = this.ActivityBaseData.GetTypeProgress(emapTravelSubType2);
			int item = typeProgress.Item1;
			int item2 = typeProgress.Item2;
			double value = Math.Ceiling((double)((float)item / (float)item2 * 100f));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(value);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			mapTravelSubViewButton2.SetProgressText(defaultInterpolatedStringHandler.ToStringAndClear());
			mapTravelSubViewButton2.SetProgressTextChangeColor(item != item2);
			mapTravelSubViewButton2.SetNameTextId(activityConfig.GetTabName((int)emapTravelSubType2));
			bool typeRedDotState = this.ActivityBaseData.GetTypeRedDotState(emapTravelSubType2);
			bool typeNewState = this.ActivityBaseData.GetTypeNewState(emapTravelSubType2);
			mapTravelSubViewButton2.SetItemNew(!typeRedDotState && typeNewState);
			mapTravelSubViewButton2.RefreshRedDot(typeRedDotState);
			mapTravelSubViewButton2.SetItemDone(item == item2);
		}
	}

	// Token: 0x060089F6 RID: 35318 RVA: 0x002451F4 File Offset: 0x002433F4
	protected void OnOpenSubView(EMapTravelSubType type)
	{
		this.StartSubView(type);
	}

	// Token: 0x060089F7 RID: 35319 RVA: 0x00245200 File Offset: 0x00243400
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<IMapTravelViewProxy> GetSubViewProxy(EMapTravelSubType type)
	{
		MapTravelMainView.<GetSubViewProxy>d__49 <GetSubViewProxy>d__;
		<GetSubViewProxy>d__.<>t__builder = AsyncUniTaskMethodBuilder<IMapTravelViewProxy>.Create();
		<GetSubViewProxy>d__.<>4__this = this;
		<GetSubViewProxy>d__.type = type;
		<GetSubViewProxy>d__.<>1__state = -1;
		<GetSubViewProxy>d__.<>t__builder.Start<MapTravelMainView.<GetSubViewProxy>d__49>(ref <GetSubViewProxy>d__);
		return <GetSubViewProxy>d__.<>t__builder.Task;
	}

	// Token: 0x060089F8 RID: 35320 RVA: 0x0024524C File Offset: 0x0024344C
	private UniTask StartSubView(EMapTravelSubType type)
	{
		MapTravelMainView.<StartSubView>d__50 <StartSubView>d__;
		<StartSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartSubView>d__.<>4__this = this;
		<StartSubView>d__.type = type;
		<StartSubView>d__.<>1__state = -1;
		<StartSubView>d__.<>t__builder.Start<MapTravelMainView.<StartSubView>d__50>(ref <StartSubView>d__);
		return <StartSubView>d__.<>t__builder.Task;
	}

	// Token: 0x060089F9 RID: 35321 RVA: 0x00245298 File Offset: 0x00243498
	private UniTask CloseSubView()
	{
		MapTravelMainView.<CloseSubView>d__51 <CloseSubView>d__;
		<CloseSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseSubView>d__.<>4__this = this;
		<CloseSubView>d__.<>1__state = -1;
		<CloseSubView>d__.<>t__builder.Start<MapTravelMainView.<CloseSubView>d__51>(ref <CloseSubView>d__);
		return <CloseSubView>d__.<>t__builder.Task;
	}

	// Token: 0x060089FA RID: 35322 RVA: 0x002452DC File Offset: 0x002434DC
	private void PlayTween(EMapTravelSubType type, bool isOpen)
	{
		List<ULGUIPlayTweenComponent> list = (from component in (isOpen ? base.GetItem(20) : base.GetItem(21)).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass())
		select component as ULGUIPlayTweenComponent).ToList<ULGUIPlayTweenComponent>();
		int[] array = isOpen ? this.openTweenGroupDefine : this.closeTweenGroupDefine;
		for (int i = 0; i < list.Count; i++)
		{
			ULGUIPlayTweenComponent ulguiplayTweenComponent = list[i];
			int num = array[i];
			if (num != 0)
			{
				if (num == 1)
				{
					ULGUIPlayTween_Vector3 tween = ulguiplayTweenComponent.GetPlayTween() as ULGUIPlayTween_Vector3;
					FVector location = this.SubViewButtonMap[type].GetIconItem().K2_GetComponentLocation();
					if (isOpen)
					{
						this.SetTweenLocation(tween, location, true);
						this.SetTweenLocation(tween, this.BgLocation.Value, false);
					}
					else
					{
						this.SetTweenLocation(tween, this.BgLocation.Value, true);
						this.SetTweenLocation(tween, location, false);
					}
				}
			}
			else
			{
				ULGUIPlayTween_Vector3 tween2 = ulguiplayTweenComponent.GetPlayTween() as ULGUIPlayTween_Vector3;
				this.SetTweenLocation(tween2, new FVector(this.BgScale, this.BgScale, this.BgScale), !isOpen);
			}
			ulguiplayTweenComponent.Stop();
			ulguiplayTweenComponent.Play();
		}
	}

	// Token: 0x060089FB RID: 35323 RVA: 0x00245424 File Offset: 0x00243624
	private void SetTweenLocation(ULGUIPlayTween_Vector3 tween, FVector location, bool isFrom)
	{
		if (isFrom)
		{
			tween.from = location;
			return;
		}
		tween.to = location;
	}

	// Token: 0x04004099 RID: 16537
	private const float SPINE_PLAY_TIME_SCALE = 1.5f;

	// Token: 0x0400409A RID: 16538
	private readonly int[] openTweenGroupDefine = new int[]
	{
		0,
		-1,
		-1,
		1
	};

	// Token: 0x0400409B RID: 16539
	private readonly int[] closeTweenGroupDefine = new int[]
	{
		1,
		-1,
		0,
		-1
	};

	// Token: 0x0400409C RID: 16540
	private const int SPINE_LAYER_WIDTH = 2520;

	// Token: 0x0400409D RID: 16541
	[Nullable(2)]
	private PopupCaptionItem CaptionComponent;

	// Token: 0x0400409E RID: 16542
	[Nullable(2)]
	private LevelSequencePlayer CaptionSequencePlayer;

	// Token: 0x0400409F RID: 16543
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ActivitySmallItemGrid, IItemGridData> LevelRewardLayout;

	// Token: 0x040040A0 RID: 16544
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x040040A1 RID: 16545
	[Nullable(2)]
	private FunctionalPanelConditionActivate PanelActivate;

	// Token: 0x040040A2 RID: 16546
	[Nullable(2)]
	private ActivityButtonItem LevelUpButton;

	// Token: 0x040040A3 RID: 16547
	private readonly Dictionary<EMapTravelSubType, MapTravelSubViewButton> SubViewButtonMap = new Dictionary<EMapTravelSubType, MapTravelSubViewButton>();

	// Token: 0x040040A4 RID: 16548
	protected readonly Dictionary<EMapTravelSubType, IMapTravelViewProxy> SubViewProxyMap = new Dictionary<EMapTravelSubType, IMapTravelViewProxy>();

	// Token: 0x040040A5 RID: 16549
	protected ActivityMapTravelData ActivityBaseData;

	// Token: 0x040040A6 RID: 16550
	private EMapTravelSubType SelectedViewType;

	// Token: 0x040040A7 RID: 16551
	private int SelectedLevel = -1;

	// Token: 0x040040A8 RID: 16552
	private bool NeedLevelUp;

	// Token: 0x040040A9 RID: 16553
	private int CurrentRewardSoarStrengthCount;

	// Token: 0x040040AA RID: 16554
	private FRotator EffectRotator = new FRotator(0f, 0f, 0f);

	// Token: 0x040040AB RID: 16555
	protected float BgOffset;

	// Token: 0x040040AC RID: 16556
	protected float BgScale = 1f;

	// Token: 0x040040AD RID: 16557
	protected FVector? BgLocation;

	// Token: 0x02007738 RID: 30520
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040290D2 RID: 168146
		public const int CaptionItem = 0;

		// Token: 0x040290D3 RID: 168147
		public const int TxtLevel = 1;

		// Token: 0x040290D4 RID: 168148
		public const int TexExpProgress = 2;

		// Token: 0x040290D5 RID: 168149
		public const int TxtExpProgress = 3;

		// Token: 0x040290D6 RID: 168150
		public const int BtnLevelLeft = 4;

		// Token: 0x040290D7 RID: 168151
		public const int BtnLevelRight = 5;

		// Token: 0x040290D8 RID: 168152
		public const int LevelRewardItem = 6;

		// Token: 0x040290D9 RID: 168153
		public const int LevelRewardLayout = 7;

		// Token: 0x040290DA RID: 168154
		public const int LevelRewardGrid = 8;

		// Token: 0x040290DB RID: 168155
		public const int LevelTipsItem = 9;

		// Token: 0x040290DC RID: 168156
		public const int TxtLevelTips = 10;

		// Token: 0x040290DD RID: 168157
		public const int BtnLevelUp = 11;

		// Token: 0x040290DE RID: 168158
		public const int PanelActive = 12;

		// Token: 0x040290DF RID: 168159
		public const int PanelLock = 13;

		// Token: 0x040290E0 RID: 168160
		public const int SubView1 = 14;

		// Token: 0x040290E1 RID: 168161
		public const int SubView2 = 15;

		// Token: 0x040290E2 RID: 168162
		public const int SubView3 = 16;

		// Token: 0x040290E3 RID: 168163
		public const int SubView4 = 17;

		// Token: 0x040290E4 RID: 168164
		public const int SubViewContent = 18;

		// Token: 0x040290E5 RID: 168165
		public const int TexIcon = 19;

		// Token: 0x040290E6 RID: 168166
		public const int AniOpen = 20;

		// Token: 0x040290E7 RID: 168167
		public const int AniClose = 21;

		// Token: 0x040290E8 RID: 168168
		public const int SpineBook = 22;

		// Token: 0x040290E9 RID: 168169
		public const int BarEffectRight = 23;

		// Token: 0x040290EA RID: 168170
		public const int BarEffectLeft = 24;

		// Token: 0x040290EB RID: 168171
		public const int AnchorLeft = 25;

		// Token: 0x040290EC RID: 168172
		public const int BgItem = 26;

		// Token: 0x040290ED RID: 168173
		public const int SpineItem = 27;
	}

	// Token: 0x02007739 RID: 30521
	[NullableContext(0)]
	private class ETweenType
	{
		// Token: 0x040290EE RID: 168174
		public const int None = -1;

		// Token: 0x040290EF RID: 168175
		public const int SpineScale = 0;

		// Token: 0x040290F0 RID: 168176
		public const int SpineLocation = 1;
	}
}
