using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002326 RID: 8998
public class MotorRaceSettlementView : UiViewBase
{
	// Token: 0x060111E6 RID: 70118 RVA: 0x004B3EEF File Offset: 0x004B20EF
	[NullableContext(1)]
	public MotorRaceSettlementView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060111E7 RID: 70119 RVA: 0x004B3F00 File Offset: 0x004B2100
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnReChallengeBtnClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnExitBtnClick))
		};
	}

	// Token: 0x060111E8 RID: 70120 RVA: 0x004B408C File Offset: 0x004B228C
	protected override void OnBeforeShow()
	{
		MotorSettlementViewParams motorSettlementViewParams = this.OpenParam as MotorSettlementViewParams;
		this.IncId = (int)motorSettlementViewParams.IncId;
		ELevel elevel = ELevel.B;
		if (motorSettlementViewParams.Score >= motorSettlementViewParams.RankS)
		{
			elevel = ELevel.S;
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_moto_parkour_settlement_level_s");
		}
		else if (motorSettlementViewParams.Score >= motorSettlementViewParams.RankB)
		{
			elevel = ELevel.A;
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_moto_parkour_settlement_level_a");
		}
		else
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_moto_parkour_settlement_level_others");
		}
		base.GetItem(0).SetUIActive(elevel == ELevel.S);
		base.GetItem(1).SetUIActive(elevel == ELevel.A);
		base.GetItem(2).SetUIActive(elevel == ELevel.B);
		base.GetItem(5).SetUIActive(elevel == ELevel.S);
		base.GetItem(6).SetUIActive(elevel == ELevel.A);
		base.GetItem(7).SetUIActive(elevel == ELevel.B);
		base.GetText(11).SetText(motorSettlementViewParams.RankS.ToString(), true);
		base.GetText(12).SetText(motorSettlementViewParams.RankA.ToString(), true);
		base.GetText(13).SetText(motorSettlementViewParams.RankB.ToString(), true);
		UUIText text = base.GetText(8);
		if (text == null)
		{
			return;
		}
		text.SetText(motorSettlementViewParams.Score.ToString(), true);
	}

	// Token: 0x060111E9 RID: 70121 RVA: 0x004B41D0 File Offset: 0x004B23D0
	protected override void OnAfterDestroy()
	{
		this.OnCloseView(this.Result, this.IncId);
	}

	// Token: 0x060111EA RID: 70122 RVA: 0x004B41E4 File Offset: 0x004B23E4
	private void OnReChallengeBtnClick()
	{
		this.Result = 1;
		base.CloseMe(null);
	}

	// Token: 0x060111EB RID: 70123 RVA: 0x004B41F4 File Offset: 0x004B23F4
	private void OnExitBtnClick()
	{
		this.Result = 0;
		base.CloseMe(null);
	}

	// Token: 0x060111EC RID: 70124 RVA: 0x004B4204 File Offset: 0x004B2404
	private void OnCloseView(int result, int incId)
	{
		ControllerBase<GeneralLogicTreeController>.Instance.OpenSystemBoardResultRequest(result, incId);
	}

	// Token: 0x04008694 RID: 34452
	private int Result;

	// Token: 0x04008695 RID: 34453
	private int IncId = -1;

	// Token: 0x02008639 RID: 34361
	private class EComponents
	{
		// Token: 0x0402D64A RID: 185930
		public const int ItemFirstBg = 0;

		// Token: 0x0402D64B RID: 185931
		public const int ItemSecondBg = 1;

		// Token: 0x0402D64C RID: 185932
		public const int ItemThirdBg = 2;

		// Token: 0x0402D64D RID: 185933
		public const int BtnReChallenge = 3;

		// Token: 0x0402D64E RID: 185934
		public const int BtnExit = 4;

		// Token: 0x0402D64F RID: 185935
		public const int ItemFirstNum = 5;

		// Token: 0x0402D650 RID: 185936
		public const int ItemSecondNum = 6;

		// Token: 0x0402D651 RID: 185937
		public const int ItemThirdNum = 7;

		// Token: 0x0402D652 RID: 185938
		public const int TextMyScore = 8;

		// Token: 0x0402D653 RID: 185939
		public const int ItemNewRecord = 9;

		// Token: 0x0402D654 RID: 185940
		public const int TextBestRecordTime = 10;

		// Token: 0x0402D655 RID: 185941
		public const int TextFirstScore = 11;

		// Token: 0x0402D656 RID: 185942
		public const int TextSecondScore = 12;

		// Token: 0x0402D657 RID: 185943
		public const int TextThirdTimeScore = 13;
	}
}
