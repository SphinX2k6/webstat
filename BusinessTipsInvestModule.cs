using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013DF RID: 5087
public class BusinessTipsInvestModule : UiPanelBase
{
	// Token: 0x06008CAE RID: 36014 RVA: 0x0024FA3C File Offset: 0x0024DC3C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnCancel)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnConfirm))
		};
	}

	// Token: 0x06008CAF RID: 36015 RVA: 0x0024FB2C File Offset: 0x0024DD2C
	protected override void OnStart()
	{
		int coinItemId = ConfigBase<BusinessConfig>.Instance.GetCoinItemId();
		base.SetItemIcon(base.GetTexture(5), coinItemId, null, null);
		this.CostNum = base.GetText(6);
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(resultData.EntrustId);
		int coinValue = ModelBase<MoonChasingModel>.Instance.GetCoinValue();
		int num = (coinValue > delegationConfig.InvestLimit) ? delegationConfig.InvestLimit : coinValue;
		this.NumberSelect = new NumberSelectComponent(base.GetItem(2));
		this.NumberSelect.SetLimitMaxValueForce(num);
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = num,
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
	}

	// Token: 0x06008CB0 RID: 36016 RVA: 0x0024FBF4 File Offset: 0x0024DDF4
	private void ValueChangeFunction(int invest)
	{
		IInvestData investData = ModelBase<MoonChasingBusinessModel>.Instance.GetInvestData(invest);
		base.GetText(0).SetText(investData.SuccessProbability.ToString(), true);
		base.GetText(1).SetText(investData.Ratio.ToString(), true);
		UUIText costNum = this.CostNum;
		if (costNum == null)
		{
			return;
		}
		costNum.SetText(invest.ToString(), true);
	}

	// Token: 0x06008CB1 RID: 36017 RVA: 0x0024FC5C File Offset: 0x0024DE5C
	private void OnCancel()
	{
		IInvestData investData = ModelBase<MoonChasingBusinessModel>.Instance.GetInvestData(0);
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		ControllerBase<MoonChasingController>.Instance.InvestRequest(resultData.EntrustId, 0, investData.Ratio, investData.Ratio);
	}

	// Token: 0x06008CB2 RID: 36018 RVA: 0x0024FCA0 File Offset: 0x0024DEA0
	private void OnConfirm()
	{
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		int selectNumber = this.NumberSelect.GetSelectNumber();
		IInvestData investData = ModelBase<MoonChasingBusinessModel>.Instance.GetInvestData(selectNumber);
		IInvestData investData2 = ModelBase<MoonChasingBusinessModel>.Instance.GetInvestData(0);
		ControllerBase<MoonChasingController>.Instance.InvestRequest(resultData.EntrustId, selectNumber, investData.Ratio, investData2.Ratio);
	}

	// Token: 0x0400418C RID: 16780
	[Nullable(1)]
	protected NumberSelectComponent NumberSelect;

	// Token: 0x0400418D RID: 16781
	[Nullable(2)]
	private UUIText CostNum;

	// Token: 0x020077C1 RID: 30657
	private static class EComponentDefine
	{
		// Token: 0x04029360 RID: 168800
		public const int SuccessProbability = 0;

		// Token: 0x04029361 RID: 168801
		public const int ReturnRatio = 1;

		// Token: 0x04029362 RID: 168802
		public const int NumberSelectItem = 2;

		// Token: 0x04029363 RID: 168803
		public const int CancelBtn = 3;

		// Token: 0x04029364 RID: 168804
		public const int ConfirmBtn = 4;

		// Token: 0x04029365 RID: 168805
		public const int CostIcon = 5;

		// Token: 0x04029366 RID: 168806
		public const int CostNum = 6;
	}
}
