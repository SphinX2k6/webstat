using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013E2 RID: 5090
[NullableContext(2)]
[Nullable(0)]
public class BusinessTipsSettlementModule : UiPanelBase
{
	// Token: 0x06008CDD RID: 36061 RVA: 0x00250980 File Offset: 0x0024EB80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnConfirm))
		};
	}

	// Token: 0x06008CDE RID: 36062 RVA: 0x00250A14 File Offset: 0x0024EC14
	private UniTask InitCharacterListModule()
	{
		BusinessTipsSettlementModule.<InitCharacterListModule>d__8 <InitCharacterListModule>d__;
		<InitCharacterListModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCharacterListModule>d__.<>4__this = this;
		<InitCharacterListModule>d__.<>1__state = -1;
		<InitCharacterListModule>d__.<>t__builder.Start<BusinessTipsSettlementModule.<InitCharacterListModule>d__8>(ref <InitCharacterListModule>d__);
		return <InitCharacterListModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008CDF RID: 36063 RVA: 0x00250A58 File Offset: 0x0024EC58
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessTipsSettlementModule.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessTipsSettlementModule.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008CE0 RID: 36064 RVA: 0x00250A9C File Offset: 0x0024EC9C
	protected override void OnBeforeShow()
	{
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		if (resultData.IsInvestSuccess)
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(resultData.Ratio.ToString() + "%", true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Moonfiesta_EventSuccess", Array.Empty<object>());
			return;
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText("100%", true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Moonfiesta_EventFail", Array.Empty<object>());
	}

	// Token: 0x06008CE1 RID: 36065 RVA: 0x00250B34 File Offset: 0x0024ED34
	protected override void OnBeforeDestroy()
	{
		if (this.Delegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.PlayFillAmount));
			this.Delegate = null;
		}
		if (this.ValueDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.PlayCurrentValue));
			this.ValueDelegate = null;
		}
		this.StopTween();
	}

	// Token: 0x06008CE2 RID: 36066 RVA: 0x00250B87 File Offset: 0x0024ED87
	private void StopTween()
	{
		if (this.ExpTweener != null)
		{
			this.ExpTweener.Kill(false);
			this.ExpTweener = null;
		}
	}

	// Token: 0x06008CE3 RID: 36067 RVA: 0x00250BA4 File Offset: 0x0024EDA4
	private void PlayCharacterRunFinishAction()
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.SetLightProgressWidth();
			characterItemWithAdd.PlayAddAction();
			characterItemWithAdd.RefreshAddText();
		}
		this.ExpTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, 0f, 1f, 1f, 0f, LTweenEase.OutCubic);
		ULTweener expTweener = this.ExpTweener;
		if (expTweener != null)
		{
			expTweener.OnCompleteCallBack.Bind(new Action(this.OnComplete));
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_figure_up_1s");
	}

	// Token: 0x06008CE4 RID: 36068 RVA: 0x00250C64 File Offset: 0x0024EE64
	private void PlayCharacterEndAction()
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.PlayEndAction();
		}
	}

	// Token: 0x06008CE5 RID: 36069 RVA: 0x00250CBC File Offset: 0x0024EEBC
	private void PlayCurrentValueTween()
	{
		this.ExpTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.ValueDelegate, 0f, 1f, 0.5f, 0f, LTweenEase.OutCubic);
	}

	// Token: 0x06008CE6 RID: 36070 RVA: 0x00250CE9 File Offset: 0x0024EEE9
	private void OnConfirm()
	{
		ControllerBase<MoonChasingController>.Instance.OpenTipsFinishView();
	}

	// Token: 0x06008CE7 RID: 36071 RVA: 0x00250CF5 File Offset: 0x0024EEF5
	[NullableContext(1)]
	private CharacterItemWithAdd InitCharacterItemWithAdd()
	{
		return new CharacterItemWithAdd();
	}

	// Token: 0x06008CE8 RID: 36072 RVA: 0x00250CFC File Offset: 0x0024EEFC
	private void PlayFillAmount(float value)
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.RefreshProgressAdd(value);
			if (value == 1f)
			{
				characterItemWithAdd.RefreshProgress(value);
				characterItemWithAdd.SetLightProgressWidth();
			}
		}
	}

	// Token: 0x06008CE9 RID: 36073 RVA: 0x00250D6C File Offset: 0x0024EF6C
	private void PlayCurrentValue(float value)
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.RefreshCurrentValue(value);
		}
	}

	// Token: 0x06008CEA RID: 36074 RVA: 0x00250DC4 File Offset: 0x0024EFC4
	private void OnComplete()
	{
		this.PlayCharacterEndAction();
		this.PlayCurrentValueTween();
	}

	// Token: 0x06008CEB RID: 36075 RVA: 0x00250DD2 File Offset: 0x0024EFD2
	public void StartCharacterAnim()
	{
		ModelBase<MoonChasingBusinessModel>.Instance.GetResultData().UseInvestProperData();
		this.PlayCharacterRunFinishAction();
	}

	// Token: 0x0400419D RID: 16797
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected CharacterListModule<CharacterItemWithAdd> CharacterListModule;

	// Token: 0x0400419E RID: 16798
	protected ULTweener ExpTweener;

	// Token: 0x0400419F RID: 16799
	protected FLTweenFloatSetterDynamic Delegate;

	// Token: 0x040041A0 RID: 16800
	protected FLTweenFloatSetterDynamic ValueDelegate;

	// Token: 0x040041A1 RID: 16801
	private const float TWEEN_TIME = 1f;

	// Token: 0x040041A2 RID: 16802
	private const float VALUE_TIME = 0.5f;

	// Token: 0x020077CE RID: 30670
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040293A3 RID: 168867
		public const int Title = 0;

		// Token: 0x040293A4 RID: 168868
		public const int ReturnRatio = 1;

		// Token: 0x040293A5 RID: 168869
		public const int ConfirmBtn = 2;

		// Token: 0x040293A6 RID: 168870
		public const int CharacterListItem = 3;
	}
}
