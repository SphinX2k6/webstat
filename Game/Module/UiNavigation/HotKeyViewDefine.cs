using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C81 RID: 19585
	[NullableContext(1)]
	[Nullable(0)]
	public class HotKeyViewDefine
	{
		// Token: 0x0401DB00 RID: 121600
		public const string SPECIAL_TEXT = "Hide";

		// Token: 0x0401DB01 RID: 121601
		public const string ANY_KEY = "AnyKey";

		// Token: 0x0401DB02 RID: 121602
		public const string EXIT_TAG = "tag1";

		// Token: 0x0401DB03 RID: 121603
		public const string HOME_TAG = "tag_home";

		// Token: 0x0401DB04 RID: 121604
		public const int ID_SEGMENT = 10000;

		// Token: 0x0401DB05 RID: 121605
		public static readonly IReadOnlyDictionary<HotKeyViewDefine.ELogicMode, string> LogicModeLogString = new Dictionary<HotKeyViewDefine.ELogicMode, string>
		{
			{
				HotKeyViewDefine.ELogicMode.Min,
				"None"
			},
			{
				HotKeyViewDefine.ELogicMode.SelfActive,
				"自身显隐状态"
			},
			{
				HotKeyViewDefine.ELogicMode.ListenerActive,
				"监听组件控制显隐"
			},
			{
				HotKeyViewDefine.ELogicMode.BlockView,
				"界面阻挡/切换"
			},
			{
				HotKeyViewDefine.ELogicMode.ListenerNotifyShield,
				"被监听组件通知屏蔽"
			},
			{
				HotKeyViewDefine.ELogicMode.LogicByNoController,
				"控制器屏蔽"
			},
			{
				HotKeyViewDefine.ELogicMode.NoText,
				"文本屏蔽"
			},
			{
				HotKeyViewDefine.ELogicMode.ConfigShield,
				"表格配置操作类型屏蔽"
			},
			{
				HotKeyViewDefine.ELogicMode.CustomShield,
				"业务自定义屏蔽"
			},
			{
				HotKeyViewDefine.ELogicMode.ShowMouseShield,
				"呼出鼠标屏蔽"
			},
			{
				HotKeyViewDefine.ELogicMode.Max,
				"None"
			}
		};

		// Token: 0x0200AD3E RID: 44350
		[NullableContext(0)]
		[Flags]
		public enum ELogicMode
		{
			// Token: 0x04035CB0 RID: 220336
			Min = 0,
			// Token: 0x04035CB1 RID: 220337
			SelfActive = 1,
			// Token: 0x04035CB2 RID: 220338
			ListenerActive = 2,
			// Token: 0x04035CB3 RID: 220339
			BlockView = 4,
			// Token: 0x04035CB4 RID: 220340
			ListenerNotifyShield = 8,
			// Token: 0x04035CB5 RID: 220341
			LogicByNoController = 16,
			// Token: 0x04035CB6 RID: 220342
			NoText = 32,
			// Token: 0x04035CB7 RID: 220343
			ConfigShield = 64,
			// Token: 0x04035CB8 RID: 220344
			CustomShield = 128,
			// Token: 0x04035CB9 RID: 220345
			ShowMouseShield = 256,
			// Token: 0x04035CBA RID: 220346
			Max = 257
		}

		// Token: 0x0200AD3F RID: 44351
		[NullableContext(0)]
		public enum EHotKeyApplicableType
		{
			// Token: 0x04035CBC RID: 220348
			KeyboardAndHandle,
			// Token: 0x04035CBD RID: 220349
			OnlyKeyboard,
			// Token: 0x04035CBE RID: 220350
			OnlyHandle,
			// Token: 0x04035CBF RID: 220351
			OnlyKeyboardTransparent,
			// Token: 0x04035CC0 RID: 220352
			OnlyHandleTransparent,
			// Token: 0x04035CC1 RID: 220353
			KeyboardAndHandleTransparent,
			// Token: 0x04035CC2 RID: 220354
			OnlyKeyboardTransparentExceptLongPress
		}

		// Token: 0x0200AD40 RID: 44352
		[Nullable(0)]
		public class EHotKeyModeDefine
		{
			// Token: 0x04035CC3 RID: 220355
			public const string SingleHotKey = "SingleHotKey";

			// Token: 0x04035CC4 RID: 220356
			public const string MultipleHotKey = "MultipleHotKey";
		}

		// Token: 0x0200AD41 RID: 44353
		[NullableContext(0)]
		public enum EHotKeyAxisDirectionType
		{
			// Token: 0x04035CC6 RID: 220358
			All,
			// Token: 0x04035CC7 RID: 220359
			Reverse,
			// Token: 0x04035CC8 RID: 220360
			Positive
		}

		// Token: 0x0200AD42 RID: 44354
		[Nullable(0)]
		public class EHotKeyFunctionType
		{
			// Token: 0x04035CC9 RID: 220361
			public const string MarkBookNext = "MarkBookNext";

			// Token: 0x04035CCA RID: 220362
			public const string MarkBookPrev = "MarkBookPrev";

			// Token: 0x04035CCB RID: 220363
			public const string NavigationNext = "NavigationNext";

			// Token: 0x04035CCC RID: 220364
			public const string NavigationUpNext = "NavigationUpNext";

			// Token: 0x04035CCD RID: 220365
			public const string NavigationDownNext = "NavigationDownNext";

			// Token: 0x04035CCE RID: 220366
			public const string NavigationLeftNext = "NavigationLeftNext";

			// Token: 0x04035CCF RID: 220367
			public const string NavigationPrev = "NavigationPrev";

			// Token: 0x04035CD0 RID: 220368
			public const string NavigationRightPrev = "NavigationRightPrev";

			// Token: 0x04035CD1 RID: 220369
			public const string NavigationRightPrevLink = "NavigationRightPrevLink";

			// Token: 0x04035CD2 RID: 220370
			public const string NavigationInside = "NavigationInside";

			// Token: 0x04035CD3 RID: 220371
			public const string Back = "Back";

			// Token: 0x04035CD4 RID: 220372
			public const string Interact = "Interact";

			// Token: 0x04035CD5 RID: 220373
			public const string ClickButton = "ClickButton";

			// Token: 0x04035CD6 RID: 220374
			public const string ClickButtonInScroll = "ClickButtonInScroll";

			// Token: 0x04035CD7 RID: 220375
			public const string ClickButtonInside = "ClickButtonInside";

			// Token: 0x04035CD8 RID: 220376
			public const string ScrollBar = "ScrollBar";

			// Token: 0x04035CD9 RID: 220377
			public const string ScrollBarInside = "ScrollBarInside";

			// Token: 0x04035CDA RID: 220378
			public const string ScrollSwitch = "ScrollSwitch";

			// Token: 0x04035CDB RID: 220379
			public const string HorizontalScrollBar = "HorizontalScrollBar";

			// Token: 0x04035CDC RID: 220380
			public const string VerticalScrollBar = "VerticalScrollBar";

			// Token: 0x04035CDD RID: 220381
			public const string InteractRelease = "InteractRelease";

			// Token: 0x04035CDE RID: 220382
			public const string InteractReleaseWithoutInterrupt = "InteractReleaseWithoutInterrupt";

			// Token: 0x04035CDF RID: 220383
			public const string ClickButtonRelease = "ClickButtonRelease";

			// Token: 0x04035CE0 RID: 220384
			public const string ClickButtonInsideRelease = "ClickButtonInsideRelease";

			// Token: 0x04035CE1 RID: 220385
			public const string MarkBookNextRelease = "MarkBookNextRelease";

			// Token: 0x04035CE2 RID: 220386
			public const string MarkBookPrevRelease = "MarkBookPrevRelease";

			// Token: 0x04035CE3 RID: 220387
			public const string LongPress = "LongPress";

			// Token: 0x04035CE4 RID: 220388
			public const string LongPressInside = "LongPressInside";

			// Token: 0x04035CE5 RID: 220389
			public const string InteractWheel = "InteractWheel";

			// Token: 0x04035CE6 RID: 220390
			public const string SliderIncrease = "SliderIncrease";

			// Token: 0x04035CE7 RID: 220391
			public const string SliderIncreaseInside = "SliderIncreaseInside";

			// Token: 0x04035CE8 RID: 220392
			public const string SliderReduce = "SliderReduce";

			// Token: 0x04035CE9 RID: 220393
			public const string SliderReduceInside = "SliderReduceInside";

			// Token: 0x04035CEA RID: 220394
			public const string SliderIncreaseReverse = "SliderIncreaseReverse";

			// Token: 0x04035CEB RID: 220395
			public const string SliderReduceReverse = "SliderReduceReverse";

			// Token: 0x04035CEC RID: 220396
			public const string LongTimeToTrigger = "LongTimeToTrigger";

			// Token: 0x04035CED RID: 220397
			public const string TextInput = "TextInput";

			// Token: 0x04035CEE RID: 220398
			public const string TextInputInside = "TextInputInside";

			// Token: 0x04035CEF RID: 220399
			public const string DraggablePrev = "DraggablePrev";

			// Token: 0x04035CF0 RID: 220400
			public const string DraggableNext = "DraggableNext";

			// Token: 0x04035CF1 RID: 220401
			public const string DraggablePrevInside = "DraggablePrevInside";

			// Token: 0x04035CF2 RID: 220402
			public const string DraggableNextInside = "DraggableNextInside";

			// Token: 0x04035CF3 RID: 220403
			public const string StaticJoyStickLeft = "StaticJoyStickLeft";

			// Token: 0x04035CF4 RID: 220404
			public const string StaticJoyStickRight = "StaticJoyStickRight";

			// Token: 0x04035CF5 RID: 220405
			public const string Mask = "Mask";

			// Token: 0x04035CF6 RID: 220406
			public const string ShowOnly = "ShowOnly";

			// Token: 0x04035CF7 RID: 220407
			public const string WorldMapShowOnly = "WorldMapShowOnly";

			// Token: 0x04035CF8 RID: 220408
			public const string FollowItem = "FollowItem";

			// Token: 0x04035CF9 RID: 220409
			public const string BagTagNavigationNext = "BagTagNavigationNext";

			// Token: 0x04035CFA RID: 220410
			public const string CommonConsumeNavigationNext = "CommonConsumeNavigationNext";

			// Token: 0x04035CFB RID: 220411
			public const string CommonConsumeNavigationInsideNext = "CommonConsumeNavigationInsideNext";

			// Token: 0x04035CFC RID: 220412
			public const string NavigationNextLatest = "NavigationNextLatest";

			// Token: 0x04035CFD RID: 220413
			public const string BattleViewCamera = "BattleViewCamera";

			// Token: 0x04035CFE RID: 220414
			public const string RouletteNavigation = "RouletteNavigation";

			// Token: 0x04035CFF RID: 220415
			public const string SettingSliderIncreaseInside = "SettingSliderIncreaseInside";

			// Token: 0x04035D00 RID: 220416
			public const string SettingSliderReduceInside = "SettingSliderReduceInside";

			// Token: 0x04035D01 RID: 220417
			public const string SettingSliderIncreaseReverseInside = "SettingSliderIncreaseReverseInside";

			// Token: 0x04035D02 RID: 220418
			public const string SettingSliderReduceReverseInside = "SettingSliderReduceReverseInside";

			// Token: 0x04035D03 RID: 220419
			public const string SettingSliderIncrease = "SettingSliderIncrease";

			// Token: 0x04035D04 RID: 220420
			public const string SettingSliderReduce = "SettingSliderReduce";

			// Token: 0x04035D05 RID: 220421
			public const string SettingSliderIncreaseReverse = "SettingSliderIncreaseReverse";

			// Token: 0x04035D06 RID: 220422
			public const string SettingSliderReduceReverse = "SettingSliderReduceReverse";

			// Token: 0x04035D07 RID: 220423
			public const string RewardTake = "RewardTake";

			// Token: 0x04035D08 RID: 220424
			public const string CommonFilterReset = "CommonFilterReset";

			// Token: 0x04035D09 RID: 220425
			public const string MapCheck = "MapCheck";

			// Token: 0x04035D0A RID: 220426
			public const string MapFocusPlayer = "MapFocusPlayer";

			// Token: 0x04035D0B RID: 220427
			public const string MapMoveForward = "MapMoveForward";

			// Token: 0x04035D0C RID: 220428
			public const string MapMoveRight = "MapMoveRight";

			// Token: 0x04035D0D RID: 220429
			public const string MapZoom = "MapZoom";

			// Token: 0x04035D0E RID: 220430
			public const string RoleLookUp = "RoleLookUp";

			// Token: 0x04035D0F RID: 220431
			public const string RoleTurn = "RoleTurn";

			// Token: 0x04035D10 RID: 220432
			public const string RoleZoom = "RoleZoom";

			// Token: 0x04035D11 RID: 220433
			public const string RoleReset = "RoleReset";

			// Token: 0x04035D12 RID: 220434
			public const string GamepadMoveForward = "GamepadMoveForward";

			// Token: 0x04035D13 RID: 220435
			public const string GamepadMoveRight = "GamepadMoveRight";

			// Token: 0x04035D14 RID: 220436
			public const string GamepadCheck = "GamepadCheck";

			// Token: 0x04035D15 RID: 220437
			public const string GamepadCheckDrag = "GamepadCheckDrag";

			// Token: 0x04035D16 RID: 220438
			public const string GamepadWheel = "GamepadWheel";

			// Token: 0x04035D17 RID: 220439
			public const string GamepadClick = "GamepadClick";

			// Token: 0x04035D18 RID: 220440
			public const string PlotMoveForward = "PlotMoveForward";

			// Token: 0x04035D19 RID: 220441
			public const string PlotMoveRight = "PlotMoveRight";

			// Token: 0x04035D1A RID: 220442
			public const string PlotZoom = "PlotZoom";

			// Token: 0x04035D1B RID: 220443
			public const string PlotNextPage = "PlotNextPage";

			// Token: 0x04035D1C RID: 220444
			public const string OpenRouletteSetView = "OpenRouletteSetView";

			// Token: 0x04035D1D RID: 220445
			public const string RouletteSwitchToggle = "RouletteSwitchToggle";

			// Token: 0x04035D1E RID: 220446
			public const string PhotographSetVisible = "PhotographSetVisible";

			// Token: 0x04035D1F RID: 220447
			public const string MapTravelTaskNavigationNext = "MapTravelTaskNavigationNext";

			// Token: 0x04035D20 RID: 220448
			public const string ShipTowerSwitchRightTeam = "ShipTowerSwitchRightTeam";

			// Token: 0x04035D21 RID: 220449
			public const string ShipTowerAutoLeftTeam = "ShipTowerAutoLeftTeam";

			// Token: 0x04035D22 RID: 220450
			public const string OpenTermExplanationView = "OpenTermExplanationView";

			// Token: 0x04035D23 RID: 220451
			public const string MapRogueQuicklyMove = "MapRogueQuicklyMove";

			// Token: 0x04035D24 RID: 220452
			public const string MapDragForward = "MapDragForward";

			// Token: 0x04035D25 RID: 220453
			public const string MapDragRight = "MapDragRight";

			// Token: 0x04035D26 RID: 220454
			public const string DangoLevelUp = "DangoLevelUp";

			// Token: 0x04035D27 RID: 220455
			public const string DangoShop = "DangoShop";

			// Token: 0x04035D28 RID: 220456
			public const string PhantomArenaBattleCardTips = "PhantomArenaBattleCardTips";

			// Token: 0x04035D29 RID: 220457
			public const string PhantomArenaBattleCardCancel = "PhantomArenaBattleCardCancel";

			// Token: 0x04035D2A RID: 220458
			public const string PhantomArenaBattleCardSelect = "PhantomArenaBattleCardSelect";

			// Token: 0x04035D2B RID: 220459
			public const string PhantomArenaBattleLayoutHoist = "PhantomArenaBattleLayoutHoist";

			// Token: 0x04035D2C RID: 220460
			public const string PhantomArenaBattleCardRecycle = "PhantomArenaBattleCardRecycle";

			// Token: 0x04035D2D RID: 220461
			public const string PhantomArenaCardInfo = "PhantomArenaCardInfo";

			// Token: 0x04035D2E RID: 220462
			public const string PhantomArenaBattleNavigationNext = "PhantomArenaBattleNavigationNext";

			// Token: 0x04035D2F RID: 220463
			public const string SeekTraceMoveUp = "SeekTraceMoveUp";

			// Token: 0x04035D30 RID: 220464
			public const string SeekTraceMoveDown = "SeekTraceMoveDown";

			// Token: 0x04035D31 RID: 220465
			public const string SeekTraceMoveLeft = "SeekTraceMoveLeft";

			// Token: 0x04035D32 RID: 220466
			public const string SeekTraceMoveRight = "SeekTraceMoveRight";

			// Token: 0x04035D33 RID: 220467
			public const string SeekTraceSelectItem = "SeekTraceSelectItem";

			// Token: 0x04035D34 RID: 220468
			public const string SeekTraceResetItem = "SeekTraceResetItem";

			// Token: 0x04035D35 RID: 220469
			public const string HonamiStoryMoveLeft = "HonamiStoryMoveLeft";

			// Token: 0x04035D36 RID: 220470
			public const string HonamiStoryMoveRight = "HonamiStoryMoveRight";

			// Token: 0x04035D37 RID: 220471
			public const string HonamiStoryPickUpDown = "HonamiStoryPickUpDown";

			// Token: 0x04035D38 RID: 220472
			public const string HonamiStoryQuickEquip = "HonamiStoryQuickEquip";

			// Token: 0x04035D39 RID: 220473
			public const string HonamiStoryQuickEquipOff = "HonamiStoryQuickEquipOff";

			// Token: 0x04035D3A RID: 220474
			public const string HonamiStoryDiscard = "HonamiStoryDiscard";

			// Token: 0x04035D3B RID: 220475
			public const string HonamiStoryLock = "HonamiStoryLock";

			// Token: 0x04035D3C RID: 220476
			public const string HonamiStoryCancel = "HonamiStoryCancel";

			// Token: 0x04035D3D RID: 220477
			public const string HonamiStoryLook = "HonamiStoryLook";

			// Token: 0x04035D3E RID: 220478
			public const string HonamiStoryCollect = "HonamiStoryCollect";

			// Token: 0x04035D3F RID: 220479
			public const string HonamiStorySell = "HonamiStorySell";

			// Token: 0x04035D40 RID: 220480
			public const string HonamiStoryCancelShowOnly = "HonamiStoryCancelShowOnly";

			// Token: 0x04035D41 RID: 220481
			public const string TeachScrollMove = "TeachScrollMove";

			// Token: 0x04035D42 RID: 220482
			public const string CloseButton = "CloseButton";

			// Token: 0x04035D43 RID: 220483
			public const string KujiLongTimeToTrigger = "KujiLongTimeToTrigger";

			// Token: 0x04035D44 RID: 220484
			public const string AutoPilotRideShareBtn = "AutoPilotRideShareBtn";

			// Token: 0x04035D45 RID: 220485
			public const string MotorMusicSortDragCancel = "MotorMusicSortDragCancel";

			// Token: 0x04035D46 RID: 220486
			public const string FormationChoseRole = "FormationChoseRole";

			// Token: 0x04035D47 RID: 220487
			public const string FormationCancelChoseRole = "FormationCancelChoseRole";

			// Token: 0x04035D48 RID: 220488
			public const string ProjectionPhotoItemDragCancel = "ProjectionPhotoItemDragCancel";

			// Token: 0x04035D49 RID: 220489
			public const string ZitherHighPitch = "ZitherHighPitch";

			// Token: 0x04035D4A RID: 220490
			public const string ZitherCameraZoom = "ZitherCameraZoom";

			// Token: 0x04035D4B RID: 220491
			public const string ZitherLowPitch = "ZitherLowPitch";
		}

		// Token: 0x0200AD43 RID: 44355
		[NullableContext(0)]
		public enum EHotKeyType
		{
			// Token: 0x04035D4D RID: 220493
			Multiple
		}
	}
}
