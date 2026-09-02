using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C30 RID: 7216
public class FloroRanchGamePlayExplainView : UiViewBase
{
	// Token: 0x0600D1E8 RID: 53736 RVA: 0x0037BDEA File Offset: 0x00379FEA
	[NullableContext(1)]
	public FloroRanchGamePlayExplainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1E9 RID: 53737 RVA: 0x0037BDF4 File Offset: 0x00379FF4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnMaskBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1EA RID: 53738 RVA: 0x0037BFA8 File Offset: 0x0037A1A8
	protected override void OnBeforeShow()
	{
		FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		FloroRanchSubDungeonData floroRanchSubDungeonData = currentActivityData.GetFloroRanchSubDungeonData(subInstanceId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Farm_DungeonTarget", new <>z__ReadOnlyArray<object>(new object[]
		{
			floroRanchSubDungeonData.GetMaxStage(),
			floroRanchSubDungeonData.GetStageDay()
		}));
		FloroRanchTag? floroRanchTagConfig = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchTagConfig(floroRanchSubDungeonData.TagId);
		if (floroRanchTagConfig != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), floroRanchTagConfig.Value.Name, Array.Empty<object>());
		}
		if (currentActivityData.ActivityDataType == EFloroRanchActivityDataType.Normal)
		{
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(floroRanchSubDungeonData.FirstReward.ToString(), true);
			}
			UUIText text2 = base.GetText(5);
			if (text2 != null)
			{
				text2.SetText(floroRanchSubDungeonData.AgainReward.ToString(), true);
			}
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(floroRanchSubDungeonData.AgainReward != 0);
			}
		}
		base.GetItem(8).SetUIActive(currentActivityData.ActivityDataType == EFloroRanchActivityDataType.Normal);
	}

	// Token: 0x0600D1EB RID: 53739 RVA: 0x0037C0D0 File Offset: 0x0037A2D0
	protected override void OnStart()
	{
		this.RegisterTermExplanation();
	}

	// Token: 0x0600D1EC RID: 53740 RVA: 0x0037C0D8 File Offset: 0x0037A2D8
	protected override void OnBeforeDestroy()
	{
		this.UnRegisterTermExplanation();
	}

	// Token: 0x0600D1ED RID: 53741 RVA: 0x0037C0E0 File Offset: 0x0037A2E0
	private void RegisterTermExplanation()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(6),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.FloroRanch,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch)
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D1EE RID: 53742 RVA: 0x0037C126 File Offset: 0x0037A326
	private void UnRegisterTermExplanation()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(6));
	}

	// Token: 0x0600D1EF RID: 53743 RVA: 0x0037C139 File Offset: 0x0037A339
	private void OnMaskBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600D1F0 RID: 53744 RVA: 0x0037C142 File Offset: 0x0037A342
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x02007F18 RID: 32536
	private class EComponents
	{
		// Token: 0x0402B3E3 RID: 177123
		public const int BtnMask = 0;

		// Token: 0x0402B3E4 RID: 177124
		public const int BtnClose = 1;

		// Token: 0x0402B3E5 RID: 177125
		public const int ItemCost = 2;

		// Token: 0x0402B3E6 RID: 177126
		public const int TextTarget = 3;

		// Token: 0x0402B3E7 RID: 177127
		public const int TextFirstReward = 4;

		// Token: 0x0402B3E8 RID: 177128
		public const int TextAgainReward = 5;

		// Token: 0x0402B3E9 RID: 177129
		public const int TextEnvironment = 6;

		// Token: 0x0402B3EA RID: 177130
		public const int ItemAgainRewardPanel = 7;

		// Token: 0x0402B3EB RID: 177131
		public const int RewardPanel = 8;
	}
}
