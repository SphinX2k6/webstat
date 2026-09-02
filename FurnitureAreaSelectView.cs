using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001081 RID: 4225
[NullableContext(2)]
[Nullable(0)]
public class FurnitureAreaSelectView : UiViewBase
{
	// Token: 0x06006DE9 RID: 28137 RVA: 0x001C8884 File Offset: 0x001C6A84
	[NullableContext(1)]
	public FurnitureAreaSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006DEA RID: 28138 RVA: 0x001C8908 File Offset: 0x001C6B08
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUISprite)),
			new ValueTuple<int, Type>(14, typeof(UUISprite)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(21, new Action(this.OnConfirmButtonClick)),
			new ValueTuple<int, Delegate>(24, new Action(this.OnShopButtonClick)),
			new ValueTuple<int, Delegate>(26, new Action(this.OnHandBookButtonClick))
		};
	}

	// Token: 0x06006DEB RID: 28139 RVA: 0x001C8C20 File Offset: 0x001C6E20
	protected override UniTask OnBeforeStartAsync()
	{
		FurnitureAreaSelectView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurnitureAreaSelectView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006DEC RID: 28140 RVA: 0x001C8C64 File Offset: 0x001C6E64
	protected override void OnStart()
	{
		int num = (this.OpenParam is int) ? ((int)this.OpenParam) : 0;
		if (num == 0)
		{
			num = 101;
		}
		this.SetAreaSelectedData(num);
		ControllerBase<FurnitureController>.Instance.SetFurnitureAreaRedDotAsRead(num);
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.CurSelectedAreaId);
		if (furnitureAreaConfig == null)
		{
			return;
		}
		this.SetFloorSelectedData(furnitureAreaConfig.Value.Floor);
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetCloseCallBack(new Action(this.OnCloseClick));
		}
		this.FloorToggleMap.Add(1, base.GetExtendToggle(2));
		this.FloorToggleMap.Add(2, base.GetExtendToggle(3));
		foreach (KeyValuePair<int, UUIExtendToggle> keyValuePair in this.FloorToggleMap)
		{
			int floorId = keyValuePair.Key;
			keyValuePair.Value.OnStateChange.Add(delegate(EToggleState toggleState)
			{
				if (toggleState == EToggleState.ETT_Checked)
				{
					this.OnFloorToggleClick(floorId);
				}
			});
		}
		this.RefreshFloorToggleState();
		this.RefreshFloorAreaRootItemShowState();
	}

	// Token: 0x06006DED RID: 28141 RVA: 0x001C8DA0 File Offset: 0x001C6FA0
	protected override void OnBeforeShow()
	{
		this.UpdateAreaItemData();
		this.UpdateLevelItemData();
		this.RefreshAreaItem();
		this.RefreshLevelItem();
		this.RefreshDetail();
		this.RefreshButton();
		this.RefreshFloorRedDot();
	}

	// Token: 0x06006DEE RID: 28142 RVA: 0x001C8DCC File Offset: 0x001C6FCC
	private void SetFloorSelectedData(int floorId)
	{
		this.CurSelectedFloorId = floorId;
	}

	// Token: 0x06006DEF RID: 28143 RVA: 0x001C8DD5 File Offset: 0x001C6FD5
	private void SetAreaSelectedData(int areaId)
	{
		this.CurSelectedAreaId = areaId;
	}

	// Token: 0x06006DF0 RID: 28144 RVA: 0x001C8DE0 File Offset: 0x001C6FE0
	private void UpdateAreaItemData()
	{
		foreach (int num in this.FurnitureAreaSelectItemMap.Keys)
		{
			IFurnitureAreaSelectItemData furnitureAreaSelectItemData = this.BuildAreaItemData(num);
			if (furnitureAreaSelectItemData != null)
			{
				if (this.AreaItemDataMap.ContainsKey(num))
				{
					this.AreaItemDataMap[num] = furnitureAreaSelectItemData;
				}
				else
				{
					this.AreaItemDataMap.Add(num, furnitureAreaSelectItemData);
				}
			}
		}
	}

	// Token: 0x06006DF1 RID: 28145 RVA: 0x001C8E68 File Offset: 0x001C7068
	private void UpdateLevelItemData()
	{
		IFurnitureAtmosphereLevelData atmosphereLevelData = ModelBase<FurnitureModel>.Instance.GetAtmosphereLevelData();
		if (atmosphereLevelData != null)
		{
			this.LevelItemData = atmosphereLevelData;
		}
	}

	// Token: 0x06006DF2 RID: 28146 RVA: 0x001C8E8C File Offset: 0x001C708C
	private IFurnitureAreaSelectItemData BuildAreaItemData(int areaId)
	{
		FurnitureModel instance = ModelBase<FurnitureModel>.Instance;
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(areaId);
		if (furnitureAreaConfig == null)
		{
			return null;
		}
		bool areaIsUnlock = instance.GetAreaIsUnlock(areaId);
		bool isSelected = this.CurSelectedAreaId == areaId;
		int areaPlacedSlotCount = instance.GetAreaPlacedSlotCount(areaId);
		int maxSlotCount = furnitureAreaConfig.Value.MaxSlotCount;
		bool redDotShowState = instance.CheckFurnitureAreaRedDot(areaId);
		return new FurnitureAreaSelectItemData
		{
			AreaId = areaId,
			FloorId = furnitureAreaConfig.Value.Floor,
			AreaName = furnitureAreaConfig.Value.AreaName,
			LockAreaIcon = furnitureAreaConfig.Value.AreaUnFinishedBigIcon,
			UnlockAreaIcon = furnitureAreaConfig.Value.AreaFinishedBigIcon,
			IsSelected = isSelected,
			IsUnlock = areaIsUnlock,
			PlacedSlotCount = areaPlacedSlotCount,
			MaxSlotCount = maxSlotCount,
			RedDotShowState = redDotShowState,
			OnSelected = new Action<int>(this.OnAreaItemClick)
		};
	}

	// Token: 0x06006DF3 RID: 28147 RVA: 0x001C8F88 File Offset: 0x001C7188
	public void RefreshAreaItem()
	{
		foreach (KeyValuePair<int, FurnitureAreaSelectItem> keyValuePair in this.FurnitureAreaSelectItemMap)
		{
			int key = keyValuePair.Key;
			FurnitureAreaSelectItem value = keyValuePair.Value;
			IFurnitureAreaSelectItemData data;
			if (this.AreaItemDataMap.TryGetValue(key, out data))
			{
				value.Refresh(data);
			}
		}
	}

	// Token: 0x06006DF4 RID: 28148 RVA: 0x001C8FFC File Offset: 0x001C71FC
	public void RefreshFloorToggleState()
	{
		foreach (KeyValuePair<int, UUIExtendToggle> keyValuePair in this.FloorToggleMap)
		{
			int key = keyValuePair.Key;
			keyValuePair.Value.SetToggleState((key == this.CurSelectedFloorId) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x06006DF5 RID: 28149 RVA: 0x001C9070 File Offset: 0x001C7270
	public void RefreshFloorAreaRootItemShowState()
	{
		base.GetItem(4).SetUIActive(this.CurSelectedFloorId == 1);
		base.GetItem(11).SetUIActive(this.CurSelectedFloorId == 2);
	}

	// Token: 0x06006DF6 RID: 28150 RVA: 0x001C90A0 File Offset: 0x001C72A0
	public void RefreshDetail()
	{
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.CurSelectedAreaId);
		if (furnitureAreaConfig == null)
		{
			return;
		}
		FurnitureModel instance = ModelBase<FurnitureModel>.Instance;
		bool areaIsUnlock = instance.GetAreaIsUnlock(this.CurSelectedAreaId);
		base.GetItem(17).SetUIActive(!areaIsUnlock);
		base.GetItem(16).SetUIActive(areaIsUnlock);
		base.GetItem(23).SetUIActive(!areaIsUnlock);
		base.GetButton(21).RootUIComp.Get().SetUIActive(areaIsUnlock);
		UUISprite sprite = base.GetSprite(14);
		UUISprite sprite2 = base.GetSprite(13);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), furnitureAreaConfig.Value.AreaName, Array.Empty<object>());
		if (!areaIsUnlock)
		{
			sprite.SetUIActive(false);
			sprite2.SetUIActive(true);
			this.SetSpriteByPath(furnitureAreaConfig.Value.AreaUnFinishedSmallIcon, sprite2, false, null, null);
			base.GetItem(22).SetUIActive(false);
			return;
		}
		sprite.SetUIActive(true);
		sprite2.SetUIActive(false);
		this.SetSpriteByPath(furnitureAreaConfig.Value.AreaFinishedSmallIcon, sprite, false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), furnitureAreaConfig.Value.AreaDescription, Array.Empty<object>());
		int areaAtmosphere = instance.GetAreaAtmosphere(this.CurSelectedAreaId);
		base.GetText(18).SetText(areaAtmosphere.ToString(), true);
		int areaPlacedSlotCount = instance.GetAreaPlacedSlotCount(this.CurSelectedAreaId);
		int maxSlotCount = furnitureAreaConfig.Value.MaxSlotCount;
		bool flag = areaPlacedSlotCount >= maxSlotCount;
		UUIText text = base.GetText(19);
		UUIItem uuiitem = text;
		bool bUseChangeColor = flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "DIY_RegionAtmosphere_Content_1", new <>z__ReadOnlyArray<object>(new object[]
		{
			areaPlacedSlotCount,
			maxSlotCount
		}));
		base.GetItem(22).SetUIActive(flag);
	}

	// Token: 0x06006DF7 RID: 28151 RVA: 0x001C92B0 File Offset: 0x001C74B0
	public void PlayDetailSwitchAnimation()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlayOrReplaySequenceByName("Switch01", false, null);
	}

	// Token: 0x06006DF8 RID: 28152 RVA: 0x001C92DC File Offset: 0x001C74DC
	private void RefreshLevelItem()
	{
		if (this.LevelItemData != null)
		{
			FurnitureAtmosphereLevelItem levelItem = this.LevelItem;
			if (levelItem == null)
			{
				return;
			}
			levelItem.Refresh(this.LevelItemData);
		}
	}

	// Token: 0x06006DF9 RID: 28153 RVA: 0x001C92FC File Offset: 0x001C74FC
	public void RefreshButton()
	{
		FurnitureModel instance = ModelBase<FurnitureModel>.Instance;
		bool furnitureHandBookFunctionIsUnlocked = instance.GetFurnitureHandBookFunctionIsUnlocked();
		bool furnitureShopFunctionIsUnlocked = instance.GetFurnitureShopFunctionIsUnlocked();
		base.GetButton(24).RootUIComp.Get().SetUIActive(furnitureShopFunctionIsUnlocked);
		base.GetButton(26).RootUIComp.Get().SetUIActive(furnitureHandBookFunctionIsUnlocked);
		if (furnitureShopFunctionIsUnlocked)
		{
			base.GetItem(25).SetUIActive(instance.CheckFurnitureShopRedDot());
		}
		if (furnitureHandBookFunctionIsUnlocked)
		{
			base.GetItem(27).SetUIActive(instance.CheckFurnitureHandBookRedDot());
		}
	}

	// Token: 0x06006DFA RID: 28154 RVA: 0x001C9380 File Offset: 0x001C7580
	public void RefreshFirstFloorRedDot()
	{
		UUIItem item = base.GetItem(28);
		FurnitureModel instance = ModelBase<FurnitureModel>.Instance;
		item.SetUIActive(instance.CheckFurnitureFloorRedDot(1));
	}

	// Token: 0x06006DFB RID: 28155 RVA: 0x001C93A8 File Offset: 0x001C75A8
	public void RefreshSecondFloorRedDot()
	{
		UUIItem item = base.GetItem(29);
		FurnitureModel instance = ModelBase<FurnitureModel>.Instance;
		item.SetUIActive(instance.CheckFurnitureFloorRedDot(2));
	}

	// Token: 0x06006DFC RID: 28156 RVA: 0x001C93CF File Offset: 0x001C75CF
	public void RefreshFloorRedDot()
	{
		this.RefreshFirstFloorRedDot();
		this.RefreshSecondFloorRedDot();
	}

	// Token: 0x06006DFD RID: 28157 RVA: 0x001C93E0 File Offset: 0x001C75E0
	private void OnFloorToggleClick(int floorId)
	{
		int curSelectedFloorId = this.CurSelectedFloorId;
		if (curSelectedFloorId == floorId)
		{
			return;
		}
		UUIExtendToggle uuiextendToggle;
		if (this.FloorToggleMap.TryGetValue(curSelectedFloorId, out uuiextendToggle))
		{
			uuiextendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		UUIExtendToggle uuiextendToggle2;
		if (this.FloorToggleMap.TryGetValue(floorId, out uuiextendToggle2))
		{
			uuiextendToggle2.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		this.SetFloorSelectedData(floorId);
		this.RefreshFloorAreaRootItemShowState();
		this.PlayFloorSwitchAnimation();
	}

	// Token: 0x06006DFE RID: 28158 RVA: 0x001C9444 File Offset: 0x001C7644
	private void PlayFloorSwitchAnimation()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
	}

	// Token: 0x06006DFF RID: 28159 RVA: 0x001C9470 File Offset: 0x001C7670
	private void OnAreaItemClick(int areaId)
	{
		int curSelectedAreaId = this.CurSelectedAreaId;
		if (curSelectedAreaId == areaId)
		{
			return;
		}
		FurnitureAreaSelectItem furnitureAreaSelectItem = null;
		this.FurnitureAreaSelectItemMap.TryGetValue(curSelectedAreaId, out furnitureAreaSelectItem);
		IFurnitureAreaSelectItemData furnitureAreaSelectItemData;
		if (this.AreaItemDataMap.TryGetValue(curSelectedAreaId, out furnitureAreaSelectItemData))
		{
			furnitureAreaSelectItemData.IsSelected = false;
		}
		if (furnitureAreaSelectItem != null)
		{
			furnitureAreaSelectItem.RefreshToggleState();
		}
		FurnitureAreaSelectItem furnitureAreaSelectItem2 = null;
		this.FurnitureAreaSelectItemMap.TryGetValue(areaId, out furnitureAreaSelectItem2);
		IFurnitureAreaSelectItemData furnitureAreaSelectItemData2;
		if (this.AreaItemDataMap.TryGetValue(areaId, out furnitureAreaSelectItemData2))
		{
			furnitureAreaSelectItemData2.IsSelected = true;
			if (furnitureAreaSelectItemData2.RedDotShowState)
			{
				ControllerBase<FurnitureController>.Instance.SetFurnitureAreaRedDotAsRead(areaId);
				furnitureAreaSelectItemData2.RedDotShowState = false;
			}
		}
		if (furnitureAreaSelectItem2 != null && furnitureAreaSelectItemData2 != null)
		{
			furnitureAreaSelectItem2.RefreshToggleState();
			furnitureAreaSelectItem2.RefreshRedDot();
			int floorId = furnitureAreaSelectItemData2.FloorId;
			if (floorId == 1)
			{
				this.RefreshFirstFloorRedDot();
			}
			else if (floorId == 2)
			{
				this.RefreshSecondFloorRedDot();
			}
		}
		this.SetAreaSelectedData(areaId);
		this.RefreshDetail();
		this.PlayDetailSwitchAnimation();
	}

	// Token: 0x06006E00 RID: 28160 RVA: 0x001C9546 File Offset: 0x001C7746
	private void OnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06006E01 RID: 28161 RVA: 0x001C9550 File Offset: 0x001C7750
	private void OnConfirmButtonClick()
	{
		if (!ModelBase<FurnitureModel>.Instance.GetAreaIsUnlock(this.CurSelectedAreaId))
		{
			return;
		}
		FurnitureDesignViewOpenData param = new FurnitureDesignViewOpenData
		{
			MapId = ModelBase<FurnitureModel>.Instance.MapId,
			ToSelectAreaId = this.CurSelectedAreaId
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FurnitureDesignView, param, null);
	}

	// Token: 0x06006E02 RID: 28162 RVA: 0x001C95A3 File Offset: 0x001C77A3
	private void OnShopButtonClick()
	{
		ControllerBase<FurnitureController>.Instance.OpenFurnitureShopViewAsync(0);
	}

	// Token: 0x06006E03 RID: 28163 RVA: 0x001C95B1 File Offset: 0x001C77B1
	private void OnHandBookButtonClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FurnitureHandBookView, null, null);
	}

	// Token: 0x06006E04 RID: 28164 RVA: 0x001C95C4 File Offset: 0x001C77C4
	private void OnLockTipButtonClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAtmosphereLevelView, null, null);
	}

	// Token: 0x0400343F RID: 13375
	private int CurSelectedFloorId;

	// Token: 0x04003440 RID: 13376
	private int CurSelectedAreaId;

	// Token: 0x04003441 RID: 13377
	[Nullable(1)]
	private readonly Dictionary<int, IFurnitureAreaSelectItemData> AreaItemDataMap = new Dictionary<int, IFurnitureAreaSelectItemData>();

	// Token: 0x04003442 RID: 13378
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003443 RID: 13379
	private IFurnitureAtmosphereLevelData LevelItemData;

	// Token: 0x04003444 RID: 13380
	private FurnitureAtmosphereLevelItem LevelItem;

	// Token: 0x04003445 RID: 13381
	private FurnitureAreaFinishTipItem FinishTipItem;

	// Token: 0x04003446 RID: 13382
	private FurnitureAreaLockTipItem LockTipItem;

	// Token: 0x04003447 RID: 13383
	[Nullable(1)]
	private readonly Dictionary<int, UUIExtendToggle> FloorToggleMap = new Dictionary<int, UUIExtendToggle>();

	// Token: 0x04003448 RID: 13384
	[Nullable(1)]
	private readonly Dictionary<int, FurnitureAreaSelectItem> FurnitureAreaSelectItemMap = new Dictionary<int, FurnitureAreaSelectItem>();

	// Token: 0x04003449 RID: 13385
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0400344A RID: 13386
	[Nullable(1)]
	private readonly Dictionary<int, int> AreaItemBindMap = new Dictionary<int, int>
	{
		{
			5,
			106
		},
		{
			6,
			104
		},
		{
			7,
			102
		},
		{
			8,
			101
		},
		{
			9,
			103
		},
		{
			10,
			105
		},
		{
			12,
			107
		}
	};
}
