using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013E4 RID: 5092
[NullableContext(2)]
[Nullable(0)]
public class BusinessTipsTravelView : UiViewBase
{
	// Token: 0x06008D06 RID: 36102 RVA: 0x002516BF File Offset: 0x0024F8BF
	[NullableContext(1)]
	public BusinessTipsTravelView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008D07 RID: 36103 RVA: 0x002516E8 File Offset: 0x0024F8E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnSkip))
		};
	}

	// Token: 0x06008D08 RID: 36104 RVA: 0x00251794 File Offset: 0x0024F994
	private UniTask InitCharacterListModule()
	{
		BusinessTipsTravelView.<InitCharacterListModule>d__24 <InitCharacterListModule>d__;
		<InitCharacterListModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCharacterListModule>d__.<>4__this = this;
		<InitCharacterListModule>d__.<>1__state = -1;
		<InitCharacterListModule>d__.<>t__builder.Start<BusinessTipsTravelView.<InitCharacterListModule>d__24>(ref <InitCharacterListModule>d__);
		return <InitCharacterListModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008D09 RID: 36105 RVA: 0x002517D8 File Offset: 0x0024F9D8
	private UniTask InitRoleItemList()
	{
		BusinessTipsTravelView.<InitRoleItemList>d__25 <InitRoleItemList>d__;
		<InitRoleItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleItemList>d__.<>4__this = this;
		<InitRoleItemList>d__.<>1__state = -1;
		<InitRoleItemList>d__.<>t__builder.Start<BusinessTipsTravelView.<InitRoleItemList>d__25>(ref <InitRoleItemList>d__);
		return <InitRoleItemList>d__.<>t__builder.Task;
	}

	// Token: 0x06008D0A RID: 36106 RVA: 0x0025181C File Offset: 0x0024FA1C
	private UniTask InitRoleList()
	{
		BusinessTipsTravelView.<InitRoleList>d__26 <InitRoleList>d__;
		<InitRoleList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleList>d__.<>4__this = this;
		<InitRoleList>d__.<>1__state = -1;
		<InitRoleList>d__.<>t__builder.Start<BusinessTipsTravelView.<InitRoleList>d__26>(ref <InitRoleList>d__);
		return <InitRoleList>d__.<>t__builder.Task;
	}

	// Token: 0x06008D0B RID: 36107 RVA: 0x00251860 File Offset: 0x0024FA60
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessTipsTravelView.<OnBeforeStartAsync>d__27 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessTipsTravelView.<OnBeforeStartAsync>d__27>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008D0C RID: 36108 RVA: 0x002518A4 File Offset: 0x0024FAA4
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		BusinessTipsTravelView.<OnBeforeShowAsyncImplementImplement>d__28 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<BusinessTipsTravelView.<OnBeforeShowAsyncImplementImplement>d__28>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008D0D RID: 36109 RVA: 0x002518E7 File Offset: 0x0024FAE7
	protected override void OnAfterPlayStartSequence()
	{
		this.ShowAddCharacter();
	}

	// Token: 0x06008D0E RID: 36110 RVA: 0x002518F0 File Offset: 0x0024FAF0
	protected override void OnBeforeDestroy()
	{
		this.RemoveTimerHandle();
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
		this.RemoveSkipAnimDelayTimerHandle();
		this.RemoveRunTimerHandle();
		this.RemoveSkipResultTimeHandle();
	}

	// Token: 0x06008D0F RID: 36111 RVA: 0x00251960 File Offset: 0x0024FB60
	protected void ShowAddCharacter()
	{
		if (this.IsFinishShowLastRole())
		{
			return;
		}
		this.ShowIndex++;
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		this.RoleIdList = resultData.GetRoleIdList();
		int roleId = this.RoleIdList[this.ShowIndex];
		IRoleResultData roleResultDataById = resultData.GetRoleResultDataById(roleId);
		for (int i = 0; i < 3; i++)
		{
			int currentValue = this.CharacterList[i].CurrentValue + roleResultDataById.CharacterValueList[i];
			this.CharacterList[i].SetCurrentValue(currentValue);
		}
		this.PlayStartAction();
		this.PlayCharacterStartAction();
		this.AddSkipAnimDelayTimerHandle();
		this.AddRunTimerHandle();
	}

	// Token: 0x06008D10 RID: 36112 RVA: 0x00251A0C File Offset: 0x0024FC0C
	[NullableContext(1)]
	private CharacterItemWithAdd InitCharacterItemWithAdd()
	{
		return new CharacterItemWithAdd();
	}

	// Token: 0x06008D11 RID: 36113 RVA: 0x00251A13 File Offset: 0x0024FC13
	[NullableContext(1)]
	private BusinessTravelRoleItem InitRoleItem()
	{
		return new BusinessTravelRoleItem();
	}

	// Token: 0x06008D12 RID: 36114 RVA: 0x00251A1C File Offset: 0x0024FC1C
	private UniTask OnPreparingFestival()
	{
		BusinessTipsTravelView.<OnPreparingFestival>d__34 <OnPreparingFestival>d__;
		<OnPreparingFestival>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPreparingFestival>d__.<>4__this = this;
		<OnPreparingFestival>d__.<>1__state = -1;
		<OnPreparingFestival>d__.<>t__builder.Start<BusinessTipsTravelView.<OnPreparingFestival>d__34>(ref <OnPreparingFestival>d__);
		return <OnPreparingFestival>d__.<>t__builder.Task;
	}

	// Token: 0x06008D13 RID: 36115 RVA: 0x00251A60 File Offset: 0x0024FC60
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

	// Token: 0x06008D14 RID: 36116 RVA: 0x00251AD0 File Offset: 0x0024FCD0
	private void PlayCurrentValue(float value)
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.RefreshCurrentValue(value);
		}
	}

	// Token: 0x06008D15 RID: 36117 RVA: 0x00251B28 File Offset: 0x0024FD28
	private void StopTween()
	{
		if (this.ExpTweener != null)
		{
			this.ExpTweener.Kill(false);
			this.ExpTweener = null;
		}
	}

	// Token: 0x06008D16 RID: 36118 RVA: 0x00251B45 File Offset: 0x0024FD45
	private void PlayStartAction()
	{
		BusinessTravelRoleItem layoutItemByKey = this.RoleLayout.GetLayoutItemByKey(this.ShowIndex);
		if (layoutItemByKey == null)
		{
			return;
		}
		layoutItemByKey.PlayStartAction();
	}

	// Token: 0x06008D17 RID: 36119 RVA: 0x00251B68 File Offset: 0x0024FD68
	private void PlayCharacterStartAction()
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.PlayStartAction();
		}
	}

	// Token: 0x06008D18 RID: 36120 RVA: 0x00251BC0 File Offset: 0x0024FDC0
	private void PlayRunFinishAction()
	{
		BusinessTravelRoleItem layoutItemByKey = this.RoleLayout.GetLayoutItemByKey(this.ShowIndex);
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		int roleId = layoutItemByKey.GetRoleId();
		IRoleResultData roleResultDataById = resultData.GetRoleResultDataById(roleId);
		List<int> lastLevelList = ((IBusinessTipsTravelData)this.OpenParam).LastLevelList;
		if (layoutItemByKey != null)
		{
			layoutItemByKey.PlayRunFinishAction(roleResultDataById.SuccessResult, lastLevelList[this.ShowIndex]);
		}
		this.AddSkipResultTimeHandle();
	}

	// Token: 0x06008D19 RID: 36121 RVA: 0x00251C2E File Offset: 0x0024FE2E
	private void PlayStopRunAction()
	{
		BusinessTravelRoleItem layoutItemByKey = this.RoleLayout.GetLayoutItemByKey(this.ShowIndex);
		if (layoutItemByKey == null)
		{
			return;
		}
		layoutItemByKey.StopRunToLastFrame();
	}

	// Token: 0x06008D1A RID: 36122 RVA: 0x00251C50 File Offset: 0x0024FE50
	private void PlayCharacterRunFinishAction()
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.PlayAddAction();
			characterItemWithAdd.RefreshAddText();
		}
	}

	// Token: 0x06008D1B RID: 36123 RVA: 0x00251CAC File Offset: 0x0024FEAC
	private void PlayEndAction()
	{
		this.IsInResult = false;
		BusinessTravelRoleItem layoutItemByKey = this.RoleLayout.GetLayoutItemByKey(this.ShowIndex);
		if (layoutItemByKey == null)
		{
			return;
		}
		layoutItemByKey.PlayEndAction();
	}

	// Token: 0x06008D1C RID: 36124 RVA: 0x00251CD8 File Offset: 0x0024FED8
	private void PlayCharacterEndAction()
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.PlayEndAction();
		}
	}

	// Token: 0x06008D1D RID: 36125 RVA: 0x00251D30 File Offset: 0x0024FF30
	private bool IsFinishShowLastRole()
	{
		List<int> roleIdList = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData().GetRoleIdList();
		return this.ShowIndex >= roleIdList.Count - 1;
	}

	// Token: 0x06008D1E RID: 36126 RVA: 0x00251D60 File Offset: 0x0024FF60
	private void SkipToNextStep()
	{
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		ModelBase<MoonChasingBusinessModel>.Instance.GetResultData().SetResultCharacterList(this.CharacterList);
		ControllerBase<MoonChasingController>.Instance.TipsTravelSkipToNextStep();
	}

	// Token: 0x06008D1F RID: 36127 RVA: 0x00251DAC File Offset: 0x0024FFAC
	private void AddSkipAnimDelayTimerHandle()
	{
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		int skipAnimDelayTime = ConfigBase<BusinessConfig>.Instance.GetSkipAnimDelayTime();
		this.SkipAnimDelayTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			UUIButtonComponent button2 = base.GetButton(2);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(true);
			}
			this.SkipAnimDelayTimerHandle = null;
		}, (float)skipAnimDelayTime, null, null, true, 1f);
	}

	// Token: 0x06008D20 RID: 36128 RVA: 0x00251E0A File Offset: 0x0025000A
	private void RemoveSkipAnimDelayTimerHandle()
	{
		if (this.SkipAnimDelayTimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.SkipAnimDelayTimerHandle);
			this.SkipAnimDelayTimerHandle = null;
		}
	}

	// Token: 0x06008D21 RID: 36129 RVA: 0x00251E2C File Offset: 0x0025002C
	private void AddRunTimerHandle()
	{
		this.RunTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.RunFinishCallback();
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x06008D22 RID: 36130 RVA: 0x00251E57 File Offset: 0x00250057
	private bool RemoveRunTimerHandle()
	{
		if (this.RunTimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RunTimerHandle);
			this.RunTimerHandle = null;
			return true;
		}
		return false;
	}

	// Token: 0x06008D23 RID: 36131 RVA: 0x00251E7C File Offset: 0x0025007C
	private void AddSkipResultTimeHandle()
	{
		this.SkipResultTimeHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.RemoveSkipResultTimeHandle();
			this.IsInResult = true;
		}, 800f, null, null, true, 1f);
	}

	// Token: 0x06008D24 RID: 36132 RVA: 0x00251EA7 File Offset: 0x002500A7
	private bool RemoveSkipResultTimeHandle()
	{
		if (this.SkipResultTimeHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.SkipResultTimeHandle);
			this.SkipResultTimeHandle = null;
			return true;
		}
		return false;
	}

	// Token: 0x06008D25 RID: 36133 RVA: 0x00251ECC File Offset: 0x002500CC
	private void RunFinishCallback()
	{
		this.RunTimerHandle = null;
		this.PlayRunFinishAction();
		this.PlayCharacterRunFinishAction();
		this.ExpTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, 0f, 1f, 1f, 0f, LTweenEase.OutCubic);
		ULTweener expTweener = this.ExpTweener;
		if (expTweener != null)
		{
			expTweener.OnCompleteCallBack.Bind(new Action(this.OnCompleteDelegate));
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_figure_up_1s");
	}

	// Token: 0x06008D26 RID: 36134 RVA: 0x00251F49 File Offset: 0x00250149
	private void PlayCurrentValueTween()
	{
		this.ExpTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.ValueDelegate, 0f, 1f, 0.5f, 0f, LTweenEase.OutCubic);
	}

	// Token: 0x06008D27 RID: 36135 RVA: 0x00251F76 File Offset: 0x00250176
	private void OnCompleteDelegate()
	{
		this.OnComplete(false);
	}

	// Token: 0x06008D28 RID: 36136 RVA: 0x00251F80 File Offset: 0x00250180
	private void OnComplete(bool isSkip)
	{
		this.PlayCharacterEndAction();
		this.PlayCurrentValueTween();
		this.RemoveTimerHandle();
		if (!isSkip)
		{
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.TimerHandle = null;
				if (this.IsFinishShowLastRole())
				{
					this.DelayToSkipToNextStep();
					return;
				}
				this.PlayEndAction();
				this.ShowAddCharacter();
			}, 1000f, null, null, true, 1f);
			return;
		}
		if (this.IsFinishShowLastRole())
		{
			this.DelayToSkipToNextStep();
			return;
		}
		this.PlayEndAction();
		this.ShowAddCharacter();
	}

	// Token: 0x06008D29 RID: 36137 RVA: 0x00251FE8 File Offset: 0x002501E8
	private void DelayToSkipToNextStep()
	{
		this.IsLastFinishShow = true;
		this.IsInResult = false;
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.TimerHandle = null;
			this.SkipToNextStep();
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x06008D2A RID: 36138 RVA: 0x00252021 File Offset: 0x00250221
	private bool RemoveTimerHandle()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
			return true;
		}
		return false;
	}

	// Token: 0x06008D2B RID: 36139 RVA: 0x00252048 File Offset: 0x00250248
	private void OnSkip()
	{
		if (this.IsLastFinishShow)
		{
			this.RemoveTimerHandle();
			this.SkipToNextStep();
			return;
		}
		if (!this.IsInResult)
		{
			if (this.RemoveRunTimerHandle())
			{
				this.RunFinishCallback();
			}
			return;
		}
		this.PlayStopRunAction();
		if (!this.RemoveTimerHandle())
		{
			if (this.ExpTweener != null)
			{
				this.ExpTweener.Kill(false);
				this.ExpTweener = null;
			}
			this.OnComplete(true);
			return;
		}
		if (this.IsFinishShowLastRole())
		{
			this.DelayToSkipToNextStep();
			return;
		}
		this.PlayEndAction();
		this.ShowAddCharacter();
	}

	// Token: 0x040041B0 RID: 16816
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected CharacterListModule<CharacterItemWithAdd> CharacterListModule;

	// Token: 0x040041B1 RID: 16817
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<BusinessTravelRoleItem, int> RoleLayout;

	// Token: 0x040041B2 RID: 16818
	[Nullable(1)]
	protected List<int> RoleIdList = new List<int>();

	// Token: 0x040041B3 RID: 16819
	protected int DelegateId;

	// Token: 0x040041B4 RID: 16820
	protected int ShowIndex = -1;

	// Token: 0x040041B5 RID: 16821
	[Nullable(1)]
	private List<CharacterData> CharacterList = new List<CharacterData>();

	// Token: 0x040041B6 RID: 16822
	protected ULTweener ExpTweener;

	// Token: 0x040041B7 RID: 16823
	protected FLTweenFloatSetterDynamic Delegate;

	// Token: 0x040041B8 RID: 16824
	protected FLTweenFloatSetterDynamic ValueDelegate;

	// Token: 0x040041B9 RID: 16825
	protected TimerHandle SkipAnimDelayTimerHandle;

	// Token: 0x040041BA RID: 16826
	protected TimerHandle RunTimerHandle;

	// Token: 0x040041BB RID: 16827
	protected bool IsLastFinishShow;

	// Token: 0x040041BC RID: 16828
	protected bool IsInResult;

	// Token: 0x040041BD RID: 16829
	protected TimerHandle SkipResultTimeHandle;

	// Token: 0x040041BE RID: 16830
	protected TimerHandle TimerHandle;

	// Token: 0x040041BF RID: 16831
	private const float TWEEN_TIME = 1f;

	// Token: 0x040041C0 RID: 16832
	private const float VALUE_TIME = 0.5f;

	// Token: 0x040041C1 RID: 16833
	private const int RUN_TIME = 2000;

	// Token: 0x040041C2 RID: 16834
	private const int LAST_SHOW = 2000;

	// Token: 0x040041C3 RID: 16835
	private const int NORMAL_SHOW = 1000;

	// Token: 0x040041C4 RID: 16836
	private const int SKIP_RESULT_DELAY = 800;

	// Token: 0x020077D7 RID: 30679
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040293D1 RID: 168913
		public const int Title = 0;

		// Token: 0x040293D2 RID: 168914
		public const int CharacterListItem = 1;

		// Token: 0x040293D3 RID: 168915
		public const int SkipBtn = 2;

		// Token: 0x040293D4 RID: 168916
		public const int RoleLayout = 3;

		// Token: 0x040293D5 RID: 168917
		public const int RoleItem = 4;
	}
}
