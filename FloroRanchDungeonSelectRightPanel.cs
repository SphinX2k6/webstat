using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C2D RID: 7213
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDungeonSelectRightPanel : UiPanelBase
{
	// Token: 0x0600D1C7 RID: 53703 RVA: 0x0037AF98 File Offset: 0x00379198
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D1C8 RID: 53704 RVA: 0x0037B150 File Offset: 0x00379350
	protected override void OnStart()
	{
		this.DifficultyLayout = new GenericLayout<FloroRanchDifficultyItem, FloroRanchSubDungeonData>(base.GetHorizontalLayout(1), new Func<FloroRanchDifficultyItem>(this.CreateDifficultyItem), null, false, true);
		this.RaceLayout = new GenericLayout<FloroRanchRaceItem, FloroRanchSelectRaceData>(base.GetHorizontalLayout(9), this.CreateRaceItem, null, false, true);
		ITermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(5),
			ViewType = ETermExplanationViewType.Side,
			AttachDirection = new ETermExplanationViewAttachDirection?(ETermExplanationViewAttachDirection.Left),
			AttachItem = base.GetRootItem(),
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch),
			ReportType = ETermExplanationReportType.FloroRanch
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D1C9 RID: 53705 RVA: 0x0037B1EC File Offset: 0x003793EC
	public void RefreshDungeonInfo(FloroRanchDungeonData dungeonData, FloroRanchSubDungeonData subDungeonData = null)
	{
		this.DungeonData = dungeonData;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), dungeonData.GetDungeonName(), Array.Empty<object>());
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(!dungeonData.IsUnLock);
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(dungeonData.IsUnLock);
		}
		if (dungeonData.IsUnLock)
		{
			List<FloroRanchSubDungeonData> dataList = dungeonData.GetSubDungeonData();
			this.DifficultyLayout.DeselectCurrentGridProxy();
			this.DifficultyLayout.RefreshByData(dataList, delegate
			{
				FloroRanchSubDungeonData subDungeonData2 = subDungeonData ?? dataList[0];
				this.RefreshSubDungeonInfo(subDungeonData2);
			}, false);
			return;
		}
		string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(this.DungeonData.ConditionId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), conditionGroupHintText, Array.Empty<object>());
	}

	// Token: 0x0600D1CA RID: 53706 RVA: 0x0037B2CC File Offset: 0x003794CC
	private void RefreshSubDungeonInfo(FloroRanchSubDungeonData subDungeonData)
	{
		this.SubDungeonData = subDungeonData;
		Action<int> onSelectDifficultyCallBack = this.OnSelectDifficultyCallBack;
		if (onSelectDifficultyCallBack != null)
		{
			onSelectDifficultyCallBack(subDungeonData.Id);
		}
		this.DifficultyLayout.SelectGridProxyByKey(subDungeonData.Id, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Farm_DungeonTarget", new <>z__ReadOnlyArray<object>(new object[]
		{
			subDungeonData.GetMaxStage(),
			subDungeonData.GetStageDay()
		}));
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(subDungeonData.FirstReward.ToString(), true);
		}
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetText(subDungeonData.AgainReward.ToString(), true);
		}
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(subDungeonData.AgainReward != 0);
		}
		FloroRanchTag? floroRanchTagConfig = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchTagConfig(subDungeonData.TagId);
		if (floroRanchTagConfig != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), floroRanchTagConfig.Value.Name, Array.Empty<object>());
		}
		this.RefreshRaceList(this.SubDungeonData.SelectedRaceIds);
	}

	// Token: 0x0600D1CB RID: 53707 RVA: 0x0037B3FC File Offset: 0x003795FC
	public void RefreshRaceList(IReadOnlyList<int> raceIdList)
	{
		List<FloroRanchSelectRaceData> list = new List<FloroRanchSelectRaceData>();
		foreach (int raceId in raceIdList)
		{
			list.Add(new FloroRanchSelectRaceData(raceId, this.SubDungeonData, EFloroRanchActivityDataType.Normal));
		}
		this.RaceLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600D1CC RID: 53708 RVA: 0x0037B464 File Offset: 0x00379664
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(5));
	}

	// Token: 0x0600D1CD RID: 53709 RVA: 0x0037B477 File Offset: 0x00379677
	private FloroRanchDifficultyItem CreateDifficultyItem()
	{
		FloroRanchDifficultyItem floroRanchDifficultyItem = new FloroRanchDifficultyItem();
		floroRanchDifficultyItem.SetToggleCallBack(new Action<FloroRanchSubDungeonData>(this.RefreshSubDungeonInfo));
		return floroRanchDifficultyItem;
	}

	// Token: 0x0400640F RID: 25615
	private FloroRanchDungeonData DungeonData;

	// Token: 0x04006410 RID: 25616
	private FloroRanchSubDungeonData SubDungeonData;

	// Token: 0x04006411 RID: 25617
	private GenericLayout<FloroRanchDifficultyItem, FloroRanchSubDungeonData> DifficultyLayout;

	// Token: 0x04006412 RID: 25618
	private GenericLayout<FloroRanchRaceItem, FloroRanchSelectRaceData> RaceLayout;

	// Token: 0x04006413 RID: 25619
	public Action<int> OnSelectDifficultyCallBack;

	// Token: 0x04006414 RID: 25620
	private readonly Func<FloroRanchRaceItem> CreateRaceItem = () => new FloroRanchRaceItem();

	// Token: 0x02007F10 RID: 32528
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B3B9 RID: 177081
		public const int TextTitle = 0;

		// Token: 0x0402B3BA RID: 177082
		public const int LayoutDifficulty = 1;

		// Token: 0x0402B3BB RID: 177083
		public const int TextTarget = 2;

		// Token: 0x0402B3BC RID: 177084
		public const int TextFirstReward = 3;

		// Token: 0x0402B3BD RID: 177085
		public const int TextAgainReward = 4;

		// Token: 0x0402B3BE RID: 177086
		public const int TextEnvironment = 5;

		// Token: 0x0402B3BF RID: 177087
		public const int ItemLockPanel = 6;

		// Token: 0x0402B3C0 RID: 177088
		public const int TextLock = 7;

		// Token: 0x0402B3C1 RID: 177089
		public const int ItemRacePanel = 8;

		// Token: 0x0402B3C2 RID: 177090
		public const int LayoutRace = 9;

		// Token: 0x0402B3C3 RID: 177091
		public const int ItemUnlockPanel = 10;

		// Token: 0x0402B3C4 RID: 177092
		public const int ItemAgainRewardPanel = 11;
	}
}
