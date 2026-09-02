using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022CE RID: 8910
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyEditPresetPanel : UiPanelBase
{
	// Token: 0x06010DC6 RID: 69062 RVA: 0x0049D7E8 File Offset: 0x0049B9E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
	}

	// Token: 0x06010DC7 RID: 69063 RVA: 0x0049D8E0 File Offset: 0x0049BAE0
	protected override void OnStart()
	{
		this.StickerScrollView = new GenericScrollViewNew<MotorcycleDiyPresetStickerItem, MotorcycleDiyEditStickerDecoItemData>(base.GetScrollViewWithScrollbar(5), new Func<MotorcycleDiyPresetStickerItem>(this.InitStickerScrollItem), null, false, null);
		this.DecorateScrollView = new GenericScrollViewNew<MotorcycleDiyPresetDecorationItem, MotorcycleDiyEditStickerDecoItemData>(base.GetScrollViewWithScrollbar(8), new Func<MotorcycleDiyPresetDecorationItem>(this.InitDecorateScrollItem), null, false, null);
	}

	// Token: 0x06010DC8 RID: 69064 RVA: 0x0049D92F File Offset: 0x0049BB2F
	private MotorcycleDiyPresetStickerItem InitStickerScrollItem()
	{
		return new MotorcycleDiyPresetStickerItem
		{
			OnClickToggleBack = new Action<MotorcycleDiyEditStickerDecoItemData>(this.OnClickStickerItem)
		};
	}

	// Token: 0x06010DC9 RID: 69065 RVA: 0x0049D948 File Offset: 0x0049BB48
	private MotorcycleDiyPresetDecorationItem InitDecorateScrollItem()
	{
		return new MotorcycleDiyPresetDecorationItem
		{
			OnClickToggleBack = new Action<MotorcycleDiyEditStickerDecoItemData>(this.OnClickDecorationItem)
		};
	}

	// Token: 0x06010DCA RID: 69066 RVA: 0x0049D964 File Offset: 0x0049BB64
	public void Refresh(int selectFrame, List<int> selectStickers, List<int> selectDecorations, [Nullable(2)] MotorcycleDiyPresetData presetData = null)
	{
		bool isChange = presetData != null && presetData.FrameId != selectFrame;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		if (presetData != null)
		{
			isChange = (presetData.FrameId != selectFrame);
			for (int i = 0; i < presetData.StickerIds.Length; i++)
			{
				int? num = (i < selectStickers.Count) ? new int?(selectStickers[i]) : null;
				int num2 = presetData.StickerIds[i];
				int? num3 = num;
				if (!(num2 == num3.GetValueOrDefault() & num3 != null))
				{
					list.Add(i + 1);
				}
			}
			for (int j = 0; j < presetData.DecorateIds.Length; j++)
			{
				int? num4 = (j < selectDecorations.Count) ? new int?(selectDecorations[j]) : null;
				int num5 = presetData.DecorateIds[j];
				int? num3 = num4;
				if (!(num5 == num3.GetValueOrDefault() & num3 != null))
				{
					list2.Add(j + 1);
				}
			}
		}
		this.RefreshFrameList(selectFrame, isChange);
		this.RefreshStickerList(selectStickers, list);
		this.RefreshDecorationList(selectDecorations, list2);
	}

	// Token: 0x06010DCB RID: 69067 RVA: 0x0049DA88 File Offset: 0x0049BC88
	private void RefreshFrameList(int frameId, bool isChange)
	{
		if (frameId > 0)
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(frameId);
			MotorFramePart? motorFramePartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFramePartConfig();
			if (motorFrameConfig != null && motorFramePartConfig != null)
			{
				base.SetTextureByPath(motorFramePartConfig.Value.Icon, base.GetTexture(1), null, null);
				base.SetTextureByPath(motorFrameConfig.Value.ModelIconPath, base.GetTexture(3), null, null);
			}
		}
		base.GetItem(2).SetUIActive(isChange);
	}

	// Token: 0x06010DCC RID: 69068 RVA: 0x0049DB1C File Offset: 0x0049BD1C
	private void RefreshStickerList(List<int> showStickerIds, List<int> changeParts)
	{
		List<MotorcycleDiyEditStickerDecoItemData> list = new List<MotorcycleDiyEditStickerDecoItemData>();
		MotorSticker? motorSticker = null;
		for (int i = 0; i < showStickerIds.Count; i++)
		{
			int num = showStickerIds[i];
			if (num > 0)
			{
				motorSticker = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
			}
			MotorcycleDiyEditStickerDecoItemData item = new MotorcycleDiyEditStickerDecoItemData
			{
				Part = i + 1,
				ItemId = num,
				QualityId = ((motorSticker != null) ? motorSticker.Value.QualityId : 0),
				SortIndex = ((motorSticker != null) ? motorSticker.Value.SortIndex : 0),
				IsSticker = true,
				HasChange = changeParts.Contains(i + 1)
			};
			list.Add(item);
		}
		GenericScrollViewNew<MotorcycleDiyPresetStickerItem, MotorcycleDiyEditStickerDecoItemData> stickerScrollView = this.StickerScrollView;
		if (stickerScrollView == null)
		{
			return;
		}
		stickerScrollView.RefreshByData(list, delegate
		{
			GenericScrollViewNew<MotorcycleDiyPresetStickerItem, MotorcycleDiyEditStickerDecoItemData> stickerScrollView2 = this.StickerScrollView;
			List<MotorcycleDiyPresetStickerItem> list2 = (stickerScrollView2 != null) ? stickerScrollView2.GetScrollItemList() : null;
			if (list2 == null)
			{
				return;
			}
			foreach (MotorcycleDiyPresetStickerItem motorcycleDiyPresetStickerItem in list2)
			{
				motorcycleDiyPresetStickerItem.SetEnableClick(true);
			}
		}, false);
	}

	// Token: 0x06010DCD RID: 69069 RVA: 0x0049DC00 File Offset: 0x0049BE00
	private void RefreshDecorationList(List<int> showDecorationIds, List<int> changeParts)
	{
		List<MotorcycleDiyEditStickerDecoItemData> list = new List<MotorcycleDiyEditStickerDecoItemData>();
		MotorDecorations? motorDecorations = null;
		for (int i = 0; i < showDecorationIds.Count; i++)
		{
			int num = showDecorationIds[i];
			if (num > 0)
			{
				motorDecorations = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num);
			}
			MotorcycleDiyEditStickerDecoItemData item = new MotorcycleDiyEditStickerDecoItemData
			{
				Part = i + 1,
				ItemId = num,
				QualityId = ((motorDecorations != null) ? motorDecorations.Value.QualityId : 0),
				SortIndex = ((motorDecorations != null) ? motorDecorations.Value.SortIndex : 0),
				IsSticker = false,
				HasChange = changeParts.Contains(i + 1)
			};
			list.Add(item);
		}
		GenericScrollViewNew<MotorcycleDiyPresetDecorationItem, MotorcycleDiyEditStickerDecoItemData> decorateScrollView = this.DecorateScrollView;
		if (decorateScrollView == null)
		{
			return;
		}
		decorateScrollView.RefreshByData(list, delegate
		{
			GenericScrollViewNew<MotorcycleDiyPresetDecorationItem, MotorcycleDiyEditStickerDecoItemData> decorateScrollView2 = this.DecorateScrollView;
			List<MotorcycleDiyPresetDecorationItem> list2 = (decorateScrollView2 != null) ? decorateScrollView2.GetScrollItemList() : null;
			if (list2 == null)
			{
				return;
			}
			foreach (MotorcycleDiyPresetDecorationItem motorcycleDiyPresetDecorationItem in list2)
			{
				motorcycleDiyPresetDecorationItem.SetEnableClick(true);
			}
		}, false);
	}

	// Token: 0x06010DCE RID: 69070 RVA: 0x0049DCE1 File Offset: 0x0049BEE1
	private void OnClickStickerItem(MotorcycleDiyEditStickerDecoItemData data)
	{
		this.JumpToEditTab(EUiTabViewName.MotorcycleDiyEditStickerTabView, data.Part);
	}

	// Token: 0x06010DCF RID: 69071 RVA: 0x0049DCF4 File Offset: 0x0049BEF4
	private void OnClickDecorationItem(MotorcycleDiyEditStickerDecoItemData data)
	{
		this.JumpToEditTab(EUiTabViewName.MotorcycleDiyEditDecorationTabView, data.Part);
	}

	// Token: 0x06010DD0 RID: 69072 RVA: 0x0049DD07 File Offset: 0x0049BF07
	private void JumpToEditTab(EUiTabViewName tabViewName, int partTabIndex)
	{
		MotorcycleDiyEditRootView motorcycleDiyEditRootView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MotorcycleDiyEditRootView) as MotorcycleDiyEditRootView;
		if (motorcycleDiyEditRootView == null)
		{
			return;
		}
		motorcycleDiyEditRootView.SwitchToTabPart(tabViewName, new int?(partTabIndex));
	}

	// Token: 0x040084E4 RID: 34020
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MotorcycleDiyPresetStickerItem, MotorcycleDiyEditStickerDecoItemData> StickerScrollView;

	// Token: 0x040084E5 RID: 34021
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MotorcycleDiyPresetDecorationItem, MotorcycleDiyEditStickerDecoItemData> DecorateScrollView;

	// Token: 0x020085A8 RID: 34216
	[NullableContext(0)]
	private class EPresetInfoComponent
	{
		// Token: 0x0402D37B RID: 185211
		public const int PnlFrame = 0;

		// Token: 0x0402D37C RID: 185212
		public const int TexFramePartIcon = 1;

		// Token: 0x0402D37D RID: 185213
		public const int PnlFrameTag = 2;

		// Token: 0x0402D37E RID: 185214
		public const int TexFrameIcon = 3;

		// Token: 0x0402D37F RID: 185215
		public const int PnlSticker = 4;

		// Token: 0x0402D380 RID: 185216
		public const int StickerScroll = 5;

		// Token: 0x0402D381 RID: 185217
		public const int StickerItem = 6;

		// Token: 0x0402D382 RID: 185218
		public const int PnlDecoration = 7;

		// Token: 0x0402D383 RID: 185219
		public const int DecorationScroll = 8;

		// Token: 0x0402D384 RID: 185220
		public const int DecorationItem = 9;
	}
}
