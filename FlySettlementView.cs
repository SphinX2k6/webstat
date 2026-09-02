using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E05 RID: 7685
public class FlySettlementView : UiViewBase
{
	// Token: 0x0600E2F1 RID: 58097 RVA: 0x003D20B3 File Offset: 0x003D02B3
	[NullableContext(1)]
	public FlySettlementView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E2F2 RID: 58098 RVA: 0x003D20C4 File Offset: 0x003D02C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickChallengeAgain));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600E2F3 RID: 58099 RVA: 0x003D2214 File Offset: 0x003D0414
	protected override void OnStart()
	{
		FlySettlementViewParams flySettlementViewParams = this.OpenParam as FlySettlementViewParams;
		this.IncId = flySettlementViewParams.IncId;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(flySettlementViewParams.Score.ToString(), true);
		}
		string resourceId;
		if (flySettlementViewParams.Score >= flySettlementViewParams.RankS)
		{
			resourceId = "T_FlyScoreS";
		}
		else if (flySettlementViewParams.Score >= flySettlementViewParams.RankA)
		{
			resourceId = "T_FlyScoreA";
		}
		else
		{
			resourceId = "T_FlyScoreB";
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		UUITexture texture = base.GetTexture(1);
		base.SetTextureByPath(resourcePath, texture, null, null);
		bool uiactive = flySettlementViewParams.Score > flySettlementViewParams.BestRecordScore;
		UUITexture texture2 = base.GetTexture(4);
		if (texture2 != null)
		{
			texture2.SetUIActive(uiactive);
		}
		UUIText text2 = base.GetText(5);
		if (text2 == null)
		{
			return;
		}
		text2.SetUIActive(uiactive);
	}

	// Token: 0x0600E2F4 RID: 58100 RVA: 0x003D22E7 File Offset: 0x003D04E7
	protected override void OnAfterDestroy()
	{
		this.OnCloseView(this.Result, this.IncId);
	}

	// Token: 0x0600E2F5 RID: 58101 RVA: 0x003D22FB File Offset: 0x003D04FB
	private void OnClickChallengeAgain()
	{
		this.Result = 1;
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0600E2F6 RID: 58102 RVA: 0x003D231A File Offset: 0x003D051A
	private void OnClickConfirm()
	{
		this.Result = 0;
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0600E2F7 RID: 58103 RVA: 0x003D2339 File Offset: 0x003D0539
	private void OnCloseView(int result, int incId)
	{
		ControllerBase<GeneralLogicTreeController>.Instance.OpenSystemBoardResultRequest(result, incId);
	}

	// Token: 0x04006D29 RID: 27945
	private int Result;

	// Token: 0x04006D2A RID: 27946
	private int IncId = -1;

	// Token: 0x02008172 RID: 33138
	private static class EViewComponent
	{
		// Token: 0x0402BF81 RID: 180097
		public const int ChallengeAgainBtn = 0;

		// Token: 0x0402BF82 RID: 180098
		public const int TexScore = 1;

		// Token: 0x0402BF83 RID: 180099
		public const int TxtNum = 2;

		// Token: 0x0402BF84 RID: 180100
		public const int ConfirmBtn = 3;

		// Token: 0x0402BF85 RID: 180101
		public const int NewRecordTexture = 4;

		// Token: 0x0402BF86 RID: 180102
		public const int NewRecordText = 5;
	}
}
