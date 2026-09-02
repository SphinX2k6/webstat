using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013E1 RID: 5089
[NullableContext(2)]
[Nullable(0)]
public class BusinessTipsResultView : UiViewBase
{
	// Token: 0x06008CC8 RID: 36040 RVA: 0x002503FF File Offset: 0x0024E5FF
	[NullableContext(1)]
	public BusinessTipsResultView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008CC9 RID: 36041 RVA: 0x00250408 File Offset: 0x0024E608
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnSkip))
		};
	}

	// Token: 0x06008CCA RID: 36042 RVA: 0x002504F4 File Offset: 0x0024E6F4
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessTipsResultView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessTipsResultView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008CCB RID: 36043 RVA: 0x00250537 File Offset: 0x0024E737
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BusinessInvestResult, new Action(this.BusinessInvestResult));
	}

	// Token: 0x06008CCC RID: 36044 RVA: 0x00250555 File Offset: 0x0024E755
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BusinessInvestResult, new Action(this.BusinessInvestResult));
	}

	// Token: 0x06008CCD RID: 36045 RVA: 0x00250573 File Offset: 0x0024E773
	protected override void OnBeforeDestroy()
	{
		this.RemoveTimerHandle();
	}

	// Token: 0x06008CCE RID: 36046 RVA: 0x0025057B File Offset: 0x0024E77B
	private void OnSkip()
	{
		if (this.TimerHandleField == null)
		{
			return;
		}
		this.RemoveTimerHandle();
		this.ShowSettlement();
	}

	// Token: 0x06008CCF RID: 36047 RVA: 0x00250594 File Offset: 0x0024E794
	private void BusinessInvestResult()
	{
		BusinessTipsInvestModule investModule = this.InvestModule;
		if (investModule != null)
		{
			investModule.SetActive(false);
		}
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		this.SwitchRoleSpineAnim(ESpineAnimation.Success, 0.1f);
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_zuiyuejie_loading");
		this.RefreshCurrencyItem();
		base.PlaySequenceAsync("Run", false, false, null).ContinueWith(delegate()
		{
			UUIButtonComponent button = base.GetButton(5);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(true);
			}
			this.AddTimerHandle();
		}).Forget();
	}

	// Token: 0x06008CD0 RID: 36048 RVA: 0x0025062C File Offset: 0x0024E82C
	private UniTask RefreshRoleTexture()
	{
		BusinessTipsResultView.<RefreshRoleTexture>d__14 <RefreshRoleTexture>d__;
		<RefreshRoleTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleTexture>d__.<>4__this = this;
		<RefreshRoleTexture>d__.<>1__state = -1;
		<RefreshRoleTexture>d__.<>t__builder.Start<BusinessTipsResultView.<RefreshRoleTexture>d__14>(ref <RefreshRoleTexture>d__);
		return <RefreshRoleTexture>d__.<>t__builder.Task;
	}

	// Token: 0x06008CD1 RID: 36049 RVA: 0x00250670 File Offset: 0x0024E870
	private UniTask InitCurrencyItem()
	{
		BusinessTipsResultView.<InitCurrencyItem>d__15 <InitCurrencyItem>d__;
		<InitCurrencyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCurrencyItem>d__.<>4__this = this;
		<InitCurrencyItem>d__.<>1__state = -1;
		<InitCurrencyItem>d__.<>t__builder.Start<BusinessTipsResultView.<InitCurrencyItem>d__15>(ref <InitCurrencyItem>d__);
		return <InitCurrencyItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008CD2 RID: 36050 RVA: 0x002506B4 File Offset: 0x0024E8B4
	private void InitDialogText()
	{
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		EntrustRole entrustRoleById = ConfigBase<BusinessConfig>.Instance.GetEntrustRoleById(resultData.TriggerEventRoleId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), entrustRoleById.InvestDialog, Array.Empty<object>());
	}

	// Token: 0x06008CD3 RID: 36051 RVA: 0x002506FC File Offset: 0x0024E8FC
	private UniTask InitInvestModule()
	{
		BusinessTipsResultView.<InitInvestModule>d__17 <InitInvestModule>d__;
		<InitInvestModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitInvestModule>d__.<>4__this = this;
		<InitInvestModule>d__.<>1__state = -1;
		<InitInvestModule>d__.<>t__builder.Start<BusinessTipsResultView.<InitInvestModule>d__17>(ref <InitInvestModule>d__);
		return <InitInvestModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008CD4 RID: 36052 RVA: 0x00250740 File Offset: 0x0024E940
	private UniTask InitSettlementModule()
	{
		BusinessTipsResultView.<InitSettlementModule>d__18 <InitSettlementModule>d__;
		<InitSettlementModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSettlementModule>d__.<>4__this = this;
		<InitSettlementModule>d__.<>1__state = -1;
		<InitSettlementModule>d__.<>t__builder.Start<BusinessTipsResultView.<InitSettlementModule>d__18>(ref <InitSettlementModule>d__);
		return <InitSettlementModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008CD5 RID: 36053 RVA: 0x00250783 File Offset: 0x0024E983
	private void AddTimerHandle()
	{
		this.TimerHandleField = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.TimerHandleField = null;
			this.ShowSettlement();
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x06008CD6 RID: 36054 RVA: 0x002507AE File Offset: 0x0024E9AE
	private void RemoveTimerHandle()
	{
		if (this.TimerHandleField != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandleField);
			this.TimerHandleField = null;
		}
	}

	// Token: 0x06008CD7 RID: 36055 RVA: 0x002507D0 File Offset: 0x0024E9D0
	private void ShowSettlement()
	{
		Singleton<AudioSystem>.Instance.ExecuteAction("play_ui_zuiyuejie_loading", EAudioActionType.Stop, null);
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		EntrustRole entrustRoleById = ConfigBase<BusinessConfig>.Instance.GetEntrustRoleById(resultData.TriggerEventRoleId);
		string textStringId = resultData.IsInvestSuccess ? entrustRoleById.InvestSuccessDialog : entrustRoleById.InvestFailDialog;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
		ESpineAnimation animName = resultData.IsInvestSuccess ? ESpineAnimation.Success : ESpineAnimation.Fail;
		this.SwitchRoleSpineAnim(animName, 0.1f);
		BusinessTipsSettlementModule settlementModule = this.SettlementModule;
		if (settlementModule != null)
		{
			settlementModule.SetActive(true);
		}
		if (resultData.IsInvestSuccess)
		{
			base.PlaySequence("Success", delegate
			{
				BusinessTipsSettlementModule settlementModule2 = this.SettlementModule;
				if (settlementModule2 == null)
				{
					return;
				}
				settlementModule2.StartCharacterAnim();
			}, false);
			return;
		}
		base.PlaySequence("Fail", null, false);
	}

	// Token: 0x06008CD8 RID: 36056 RVA: 0x002508CA File Offset: 0x0024EACA
	private void SwitchRoleSpineAnim(ESpineAnimation animName, float mixDuration)
	{
		UTrackEntry utrackEntry = base.GetSpine(0).SetAnimation(0, animName.ToString(), true);
		if (utrackEntry == null)
		{
			return;
		}
		utrackEntry.SetMixDuration(mixDuration);
	}

	// Token: 0x06008CD9 RID: 36057 RVA: 0x002508F4 File Offset: 0x0024EAF4
	private void RefreshCurrencyItem()
	{
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		int targetValue = resultData.OriginGold - resultData.CostGold;
		this.CurrencyItem.PlayReduceTweener(resultData.OriginGold, targetValue);
	}

	// Token: 0x04004198 RID: 16792
	protected BusinessTipsInvestModule InvestModule;

	// Token: 0x04004199 RID: 16793
	protected BusinessTipsSettlementModule SettlementModule;

	// Token: 0x0400419A RID: 16794
	protected TimerHandle TimerHandleField;

	// Token: 0x0400419B RID: 16795
	protected BusinessTipsCurrencyItem CurrencyItem;

	// Token: 0x0400419C RID: 16796
	private const int ANIM_TIME = 2000;

	// Token: 0x020077C8 RID: 30664
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029387 RID: 168839
		public const int RoleSpine = 0;

		// Token: 0x04029388 RID: 168840
		public const int DialogItem = 1;

		// Token: 0x04029389 RID: 168841
		public const int DialogText = 2;

		// Token: 0x0402938A RID: 168842
		public const int InvestItem = 3;

		// Token: 0x0402938B RID: 168843
		public const int ResultItem = 4;

		// Token: 0x0402938C RID: 168844
		public const int SkipBtn = 5;

		// Token: 0x0402938D RID: 168845
		public const int TitleItem = 6;

		// Token: 0x0402938E RID: 168846
		public const int CurrencyItem = 7;
	}
}
