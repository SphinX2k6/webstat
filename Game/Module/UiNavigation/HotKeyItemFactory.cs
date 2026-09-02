using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.UiNavigation.UIComponent;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D77 RID: 19831
	[NullableContext(1)]
	[Nullable(0)]
	public class HotKeyItemFactory : IStaticVariableResetter
	{
		// Token: 0x060335ED RID: 210413 RVA: 0x00CD8EBD File Offset: 0x00CD70BD
		static HotKeyItemFactory()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(HotKeyItemFactory.CreateStaticDefaultValue), new Action(HotKeyItemFactory.ResetStaticDefaultValue));
		}

		// Token: 0x170087D5 RID: 34773
		// (get) Token: 0x060335EE RID: 210414 RVA: 0x00CD8EDC File Offset: 0x00CD70DC
		private static Dictionary<string, Type> HotKeyComponentTypeMap
		{
			get
			{
				return HotKeyItemFactory._hotKeyComponentTypeMap;
			}
		}

		// Token: 0x060335EF RID: 210415 RVA: 0x00CD8EE4 File Offset: 0x00CD70E4
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<HotKeyItem> CreateHotKeyItem(AActor actor, string mode, int index)
		{
			HotKeyItemFactory.<CreateHotKeyItem>d__4 <CreateHotKeyItem>d__;
			<CreateHotKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<HotKeyItem>.Create();
			<CreateHotKeyItem>d__.actor = actor;
			<CreateHotKeyItem>d__.mode = mode;
			<CreateHotKeyItem>d__.index = index;
			<CreateHotKeyItem>d__.<>1__state = -1;
			<CreateHotKeyItem>d__.<>t__builder.Start<HotKeyItemFactory.<CreateHotKeyItem>d__4>(ref <CreateHotKeyItem>d__);
			return <CreateHotKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x060335F0 RID: 210416 RVA: 0x00CD8F38 File Offset: 0x00CD7138
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private static UniTask<T> CreateItem<[Nullable(0)] T>(AActor actor, int index) where T : HotKeyItem, new()
		{
			HotKeyItemFactory.<CreateItem>d__5<T> <CreateItem>d__;
			<CreateItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<CreateItem>d__.actor = actor;
			<CreateItem>d__.index = index;
			<CreateItem>d__.<>1__state = -1;
			<CreateItem>d__.<>t__builder.Start<HotKeyItemFactory.<CreateItem>d__5<T>>(ref <CreateItem>d__);
			return <CreateItem>d__.<>t__builder.Task;
		}

		// Token: 0x060335F1 RID: 210417 RVA: 0x00CD8F84 File Offset: 0x00CD7184
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<HotKeyComponent> CreateHotKeyComponent(AActor actor, int hotKeyMapId, HotKeyTypeBase hotKeyType)
		{
			HotKeyItemFactory.<CreateHotKeyComponent>d__6 <CreateHotKeyComponent>d__;
			<CreateHotKeyComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder<HotKeyComponent>.Create();
			<CreateHotKeyComponent>d__.actor = actor;
			<CreateHotKeyComponent>d__.hotKeyMapId = hotKeyMapId;
			<CreateHotKeyComponent>d__.hotKeyType = hotKeyType;
			<CreateHotKeyComponent>d__.<>1__state = -1;
			<CreateHotKeyComponent>d__.<>t__builder.Start<HotKeyItemFactory.<CreateHotKeyComponent>d__6>(ref <CreateHotKeyComponent>d__);
			return <CreateHotKeyComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060335F2 RID: 210418 RVA: 0x00CD8FD8 File Offset: 0x00CD71D8
		public static void CreateStaticDefaultValue()
		{
			HotKeyItemFactory._hotKeyComponentTypeMap = new Dictionary<string, Type>
			{
				{
					"MarkBookNext",
					typeof(MarkBookNextComponent)
				},
				{
					"MarkBookPrev",
					typeof(MarkBookPrevComponent)
				},
				{
					"NavigationNext",
					typeof(NavigationGroupNextComponent)
				},
				{
					"NavigationUpNext",
					typeof(NavigationGroupUpNextComponent)
				},
				{
					"NavigationDownNext",
					typeof(NavigationGroupDownNextComponent)
				},
				{
					"NavigationLeftNext",
					typeof(NavigationGroupLeftNextComponent)
				},
				{
					"NavigationPrev",
					typeof(NavigationGroupPrevComponent)
				},
				{
					"NavigationRightPrev",
					typeof(NavigationGroupRightPrevComponent)
				},
				{
					"NavigationRightPrevLink",
					typeof(NavigationGroupRightPrevLinkComponent)
				},
				{
					"NavigationInside",
					typeof(NavigationGroupInsideComponent)
				},
				{
					"Back",
					typeof(BackComponent)
				},
				{
					"Interact",
					typeof(InteractComponent)
				},
				{
					"ClickButton",
					typeof(ClickBtnComponent)
				},
				{
					"ClickButtonInScroll",
					typeof(ClickBtnInScrollComponent)
				},
				{
					"ClickButtonInside",
					typeof(ClickBtnInsideComponent)
				},
				{
					"ScrollBar",
					typeof(ScrollBarComponent)
				},
				{
					"ScrollBarInside",
					typeof(ScrollBarInsideComponent)
				},
				{
					"ScrollSwitch",
					typeof(ScrollSwitchComponent)
				},
				{
					"HorizontalScrollBar",
					typeof(HorizontalScrollBarComponent)
				},
				{
					"VerticalScrollBar",
					typeof(VerticalScrollBarComponent)
				},
				{
					"InteractRelease",
					typeof(InteractReleaseComponent)
				},
				{
					"InteractReleaseWithoutInterrupt",
					typeof(InteractReleaseWithoutInterruptComponent)
				},
				{
					"ClickButtonRelease",
					typeof(ClickBtnReleaseComponent)
				},
				{
					"ClickButtonInsideRelease",
					typeof(ClickBtnInsideReleaseComponent)
				},
				{
					"MarkBookNextRelease",
					typeof(MarkBookNextReleaseComponent)
				},
				{
					"MarkBookPrevRelease",
					typeof(MarkBookPrevReleaseComponent)
				},
				{
					"LongPress",
					typeof(LongPressComponent)
				},
				{
					"LongPressInside",
					typeof(LongPressInsideComponent)
				},
				{
					"InteractWheel",
					typeof(InteractWheelComponent)
				},
				{
					"SliderIncrease",
					typeof(SliderIncreaseComponent)
				},
				{
					"SliderReduce",
					typeof(SliderReduceComponent)
				},
				{
					"SliderIncreaseInside",
					typeof(SliderIncreaseInsideComponent)
				},
				{
					"SliderReduceInside",
					typeof(SliderReduceInsideComponent)
				},
				{
					"SliderIncreaseReverse",
					typeof(SliderIncreaseReverseComponent)
				},
				{
					"SliderReduceReverse",
					typeof(SliderReduceReverseComponent)
				},
				{
					"LongTimeToTrigger",
					typeof(LongTimeToTriggerComponent)
				},
				{
					"TextInput",
					typeof(TextInputComponent)
				},
				{
					"TextInputInside",
					typeof(TextInputInsideComponent)
				},
				{
					"DraggablePrev",
					typeof(DraggablePrevComponent)
				},
				{
					"DraggableNext",
					typeof(DraggableNextComponent)
				},
				{
					"DraggablePrevInside",
					typeof(DraggablePrevInsideComponent)
				},
				{
					"DraggableNextInside",
					typeof(DraggableNextInsideComponent)
				},
				{
					"StaticJoyStickLeft",
					typeof(StaticJoyStickLeftComponent)
				},
				{
					"StaticJoyStickRight",
					typeof(StaticJoyStickRightComponent)
				},
				{
					"Mask",
					typeof(MaskComponent)
				},
				{
					"ShowOnly",
					typeof(ShowOnlyComponent)
				},
				{
					"WorldMapShowOnly",
					typeof(WorldMapShowOnlyComponent)
				},
				{
					"FollowItem",
					typeof(FollowItemComponent)
				},
				{
					"BagTagNavigationNext",
					typeof(BagTagNavigationNextComponent)
				},
				{
					"CommonConsumeNavigationNext",
					typeof(CommonConsumeNavigationNext)
				},
				{
					"CommonConsumeNavigationInsideNext",
					typeof(CommonConsumeNavigationInsideNext)
				},
				{
					"NavigationNextLatest",
					typeof(NavigationNextLatest)
				},
				{
					"BattleViewCamera",
					typeof(BattleViewCameraComponent)
				},
				{
					"RouletteNavigation",
					typeof(RouletteNavigationComponent)
				},
				{
					"SettingSliderIncreaseInside",
					typeof(SettingSliderIncreaseInsideComponent)
				},
				{
					"SettingSliderReduceInside",
					typeof(SettingSliderReduceInsideComponent)
				},
				{
					"SettingSliderIncreaseReverseInside",
					typeof(SettingSliderIncreaseReverseInsideComponent)
				},
				{
					"SettingSliderReduceReverseInside",
					typeof(SettingSliderReduceReverseInsideComponent)
				},
				{
					"SettingSliderIncrease",
					typeof(SettingSliderIncreaseComponent)
				},
				{
					"SettingSliderReduce",
					typeof(SettingSliderReduceComponent)
				},
				{
					"SettingSliderIncreaseReverse",
					typeof(SettingSliderIncreaseReverseComponent)
				},
				{
					"SettingSliderReduceReverse",
					typeof(SettingSliderReduceReverseComponent)
				},
				{
					"RewardTake",
					typeof(RewardTakeComponent)
				},
				{
					"CommonFilterReset",
					typeof(CommonFilterResetComponent)
				},
				{
					"MapCheck",
					typeof(MapCheckComponent)
				},
				{
					"MapFocusPlayer",
					typeof(MapFocusPlayerComponent)
				},
				{
					"MapMoveForward",
					typeof(MapMoveForwardComponent)
				},
				{
					"MapMoveRight",
					typeof(MapMoveRightComponent)
				},
				{
					"MapZoom",
					typeof(MapZoomComponent)
				},
				{
					"RoleLookUp",
					typeof(RoleLookUpComponent)
				},
				{
					"RoleTurn",
					typeof(RoleTurnComponent)
				},
				{
					"RoleZoom",
					typeof(RoleZoomComponent)
				},
				{
					"RoleReset",
					typeof(RoleResetComponent)
				},
				{
					"GamepadMoveForward",
					typeof(GamepadMoveForwardComponent)
				},
				{
					"GamepadMoveRight",
					typeof(GamepadMoveRightComponent)
				},
				{
					"GamepadCheck",
					typeof(GamepadCheckComponent)
				},
				{
					"GamepadCheckDrag",
					typeof(GamepadCheckDragComponent)
				},
				{
					"GamepadWheel",
					typeof(GamepadWheelComponent)
				},
				{
					"GamepadClick",
					typeof(GamepadClickComponent)
				},
				{
					"PlotMoveForward",
					typeof(PlotMoveForwardComponent)
				},
				{
					"PlotMoveRight",
					typeof(PlotMoveRightComponent)
				},
				{
					"PlotZoom",
					typeof(PlotZoomComponent)
				},
				{
					"PlotNextPage",
					typeof(PlotNextPageComponent)
				},
				{
					"OpenRouletteSetView",
					typeof(OpenRouletteSetViewComponent)
				},
				{
					"RouletteSwitchToggle",
					typeof(RouletteSwitchToggleComponent)
				},
				{
					"PhotographSetVisible",
					typeof(PhotographSetVisibleComponent)
				},
				{
					"MapTravelTaskNavigationNext",
					typeof(MapTravelTaskNavigationNextComponent)
				},
				{
					"ShipTowerSwitchRightTeam",
					typeof(ShipTowerSwitchRightTeamComponent)
				},
				{
					"ShipTowerAutoLeftTeam",
					typeof(ShipTowerAutoLeftTeamComponent)
				},
				{
					"OpenTermExplanationView",
					typeof(TermExplanationComponent)
				},
				{
					"MapRogueQuicklyMove",
					typeof(MapRogueQuicklyMoveComponent)
				},
				{
					"MapDragForward",
					typeof(MapDragForwardComponent)
				},
				{
					"MapDragRight",
					typeof(MapDragRightComponent)
				},
				{
					"DangoLevelUp",
					typeof(InstanceDungeonWorldClickComponent)
				},
				{
					"DangoShop",
					typeof(InstanceDungeonWorldClickComponent)
				},
				{
					"PhantomArenaBattleCardTips",
					typeof(PhantomArenaBattleCardTipsComponent)
				},
				{
					"PhantomArenaBattleCardCancel",
					typeof(PhantomArenaBattleCardCancelComponent)
				},
				{
					"PhantomArenaBattleCardSelect",
					typeof(PhantomArenaBattleCardSelectComponent)
				},
				{
					"PhantomArenaBattleLayoutHoist",
					typeof(PhantomArenaBattleLayoutHoistComponent)
				},
				{
					"PhantomArenaBattleCardRecycle",
					typeof(PhantomArenaBattleCardRecycleComponent)
				},
				{
					"PhantomArenaCardInfo",
					typeof(PhantomArenaCardInfoComponent)
				},
				{
					"PhantomArenaBattleNavigationNext",
					typeof(PhantomArenaBattleNavigationNextComponent)
				},
				{
					"SeekTraceMoveUp",
					typeof(SeekTraceMoveUpComponent)
				},
				{
					"SeekTraceMoveDown",
					typeof(SeekTraceMoveDownComponent)
				},
				{
					"SeekTraceMoveLeft",
					typeof(SeekTraceMoveLeftComponent)
				},
				{
					"SeekTraceMoveRight",
					typeof(SeekTraceMoveRightComponent)
				},
				{
					"SeekTraceSelectItem",
					typeof(SeekTraceSelectItemComponent)
				},
				{
					"SeekTraceResetItem",
					typeof(SeekTraceResetItemComponent)
				},
				{
					"HonamiStoryMoveLeft",
					typeof(HonamiStoryMoveLeftComponent)
				},
				{
					"HonamiStoryMoveRight",
					typeof(HonamiStoryMoveRightComponent)
				},
				{
					"HonamiStoryPickUpDown",
					typeof(HonamiStoryPickUpDownComponent)
				},
				{
					"HonamiStoryQuickEquip",
					typeof(HonamiStoryQuickEquipOnComponent)
				},
				{
					"HonamiStoryQuickEquipOff",
					typeof(HonamiStoryQuickEquipOffComponent)
				},
				{
					"HonamiStoryDiscard",
					typeof(HonamiStoryDiscardComponent)
				},
				{
					"HonamiStoryLock",
					typeof(HonamiStoryLockComponent)
				},
				{
					"HonamiStoryCancel",
					typeof(HonamiStoryCancelComponent)
				},
				{
					"HonamiStoryLook",
					typeof(HonamiStoryLookComponent)
				},
				{
					"HonamiStoryCollect",
					typeof(HonamiStoryCollectComponent)
				},
				{
					"HonamiStorySell",
					typeof(HonamiStorySellComponent)
				},
				{
					"HonamiStoryCancelShowOnly",
					typeof(HonamiStoryCancelShowOnlyComponent)
				},
				{
					"TeachScrollMove",
					typeof(TeachScrollMoveComponent)
				},
				{
					"CloseButton",
					typeof(CloseBtnComponent)
				},
				{
					"KujiLongTimeToTrigger",
					typeof(KujiLongTimeToTriggerComponent)
				},
				{
					"AutoPilotRideShareBtn",
					typeof(AutoPilotRideShareBtnComponent)
				},
				{
					"MotorMusicSortDragCancel",
					typeof(MotorMusicSortDragCancelComponent)
				},
				{
					"FormationChoseRole",
					typeof(FormationChoseRoleComponent)
				},
				{
					"FormationCancelChoseRole",
					typeof(FormationCancelChoseRoleComponent)
				},
				{
					"ProjectionPhotoItemDragCancel",
					typeof(ProjectionPhotoItemDragCancelComponent)
				},
				{
					"ZitherHighPitch",
					typeof(ZitherHighPitchComponent)
				},
				{
					"ZitherCameraZoom",
					typeof(ZitherCameraZoomComponent)
				},
				{
					"ZitherLowPitch",
					typeof(ZitherLowPitchComponent)
				}
			};
		}

		// Token: 0x060335F3 RID: 210419 RVA: 0x00CD9AAE File Offset: 0x00CD7CAE
		public static void ResetStaticDefaultValue()
		{
			HotKeyItemFactory._hotKeyComponentTypeMap = null;
		}

		// Token: 0x0401DC7C RID: 121980
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<string, Type> _hotKeyComponentTypeMap;
	}
}
