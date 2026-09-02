using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013E3 RID: 5091
[NullableContext(2)]
[Nullable(0)]
public class BusinessTipsShopView : UiViewBase
{
	// Token: 0x06008CED RID: 36077 RVA: 0x00250DF1 File Offset: 0x0024EFF1
	[NullableContext(1)]
	public BusinessTipsShopView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008CEE RID: 36078 RVA: 0x00250E10 File Offset: 0x0024F010
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnConfirm)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnSkip))
		};
	}

	// Token: 0x06008CEF RID: 36079 RVA: 0x00250F88 File Offset: 0x0024F188
	private UniTask InitCharacterListModule()
	{
		BusinessTipsShopView.<InitCharacterListModule>d__16 <InitCharacterListModule>d__;
		<InitCharacterListModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCharacterListModule>d__.<>4__this = this;
		<InitCharacterListModule>d__.<>1__state = -1;
		<InitCharacterListModule>d__.<>t__builder.Start<BusinessTipsShopView.<InitCharacterListModule>d__16>(ref <InitCharacterListModule>d__);
		return <InitCharacterListModule>d__.<>t__builder.Task;
	}

	// Token: 0x17000BE5 RID: 3045
	// (get) Token: 0x06008CF0 RID: 36080 RVA: 0x00250FCB File Offset: 0x0024F1CB
	private bool IsShoppingMoreSuccessful
	{
		get
		{
			return ((IBusinessTipsShopData)this.OpenParam).IsMoreSuccessful;
		}
	}

	// Token: 0x06008CF1 RID: 36081 RVA: 0x00250FE0 File Offset: 0x0024F1E0
	private UniTask InitHelperRoleItem()
	{
		BusinessTipsShopView.<InitHelperRoleItem>d__19 <InitHelperRoleItem>d__;
		<InitHelperRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitHelperRoleItem>d__.<>4__this = this;
		<InitHelperRoleItem>d__.<>1__state = -1;
		<InitHelperRoleItem>d__.<>t__builder.Start<BusinessTipsShopView.<InitHelperRoleItem>d__19>(ref <InitHelperRoleItem>d__);
		return <InitHelperRoleItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008CF2 RID: 36082 RVA: 0x00251024 File Offset: 0x0024F224
	private UniTask InitPlayerRoleItem()
	{
		BusinessTipsShopView.<InitPlayerRoleItem>d__20 <InitPlayerRoleItem>d__;
		<InitPlayerRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPlayerRoleItem>d__.<>4__this = this;
		<InitPlayerRoleItem>d__.<>1__state = -1;
		<InitPlayerRoleItem>d__.<>t__builder.Start<BusinessTipsShopView.<InitPlayerRoleItem>d__20>(ref <InitPlayerRoleItem>d__);
		return <InitPlayerRoleItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008CF3 RID: 36083 RVA: 0x00251068 File Offset: 0x0024F268
	private void InitLevelItem()
	{
		IBusinessTipsShopData businessTipsShopData = (IBusinessTipsShopData)this.OpenParam;
		int roleId = businessTipsShopData.RoleId;
		EditTeamData editTeamDataById = ModelBase<MoonChasingBusinessModel>.Instance.GetEditTeamDataById(roleId);
		this.IsShoppingLevelUp = (editTeamDataById.Level > businessTipsShopData.LastData.Level);
		if (this.IsShoppingLevelUp)
		{
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetText(businessTipsShopData.LastData.Level.ToString(), true);
			}
			UUIText text2 = base.GetText(6);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(editTeamDataById.Level.ToString(), true);
			return;
		}
		else
		{
			UUIText text3 = base.GetText(3);
			if (text3 == null)
			{
				return;
			}
			text3.SetText(editTeamDataById.Level.ToString(), true);
			return;
		}
	}

	// Token: 0x06008CF4 RID: 36084 RVA: 0x0025111C File Offset: 0x0024F31C
	private UniTask InitRoleList()
	{
		BusinessTipsShopView.<InitRoleList>d__22 <InitRoleList>d__;
		<InitRoleList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleList>d__.<>4__this = this;
		<InitRoleList>d__.<>1__state = -1;
		<InitRoleList>d__.<>t__builder.Start<BusinessTipsShopView.<InitRoleList>d__22>(ref <InitRoleList>d__);
		return <InitRoleList>d__.<>t__builder.Task;
	}

	// Token: 0x06008CF5 RID: 36085 RVA: 0x00251160 File Offset: 0x0024F360
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessTipsShopView.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessTipsShopView.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008CF6 RID: 36086 RVA: 0x002511A4 File Offset: 0x0024F3A4
	protected override void OnBeforeShow()
	{
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Moonfiesta_PartnerTip5", Array.Empty<object>());
		this.TimeHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.TimeHandle = null;
			this.OnShoppingFinish();
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x06008CF7 RID: 36087 RVA: 0x0025120C File Offset: 0x0024F40C
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

	// Token: 0x06008CF8 RID: 36088 RVA: 0x00251260 File Offset: 0x0024F460
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

	// Token: 0x06008CF9 RID: 36089 RVA: 0x002512D0 File Offset: 0x0024F4D0
	private void OnConfirm()
	{
		base.CloseMe(null);
	}

	// Token: 0x06008CFA RID: 36090 RVA: 0x002512D9 File Offset: 0x0024F4D9
	private void OnSkip()
	{
		if (this.RemoveTimerHandle())
		{
			this.OnShoppingFinish();
		}
	}

	// Token: 0x06008CFB RID: 36091 RVA: 0x002512E9 File Offset: 0x0024F4E9
	[NullableContext(1)]
	private CharacterItemWithAdd InitCharacterItemWithAdd()
	{
		return new CharacterItemWithAdd();
	}

	// Token: 0x06008CFC RID: 36092 RVA: 0x002512F0 File Offset: 0x0024F4F0
	private void OnShoppingFinish()
	{
		if (this.IsShoppingLevelUp)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequencePurely("Success", false, false);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(true);
			}
		}
		else
		{
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 != null)
			{
				uiViewSequence2.PlaySequencePurely("Fail", false, false);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
		}
		if (this.IsShoppingMoreSuccessful)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Moonfiesta_TravelGreatSuccess", Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Moonfiesta_PartnerTip4", Array.Empty<object>());
		}
		IBusinessTipsShopData businessTipsShopData = (IBusinessTipsShopData)this.OpenParam;
		CharacterListModule<CharacterItemWithAdd> characterListModule = this.CharacterListModule;
		if (characterListModule != null)
		{
			characterListModule.SetActive(true);
		}
		this.RefreshAddText();
		UUIButtonComponent button = base.GetButton(7);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(true);
		}
		TrainRoleDialog trainRoleDialogByIdAndType = ConfigBase<BusinessConfig>.Instance.GetTrainRoleDialogByIdAndType(businessTipsShopData.RoleId, businessTipsShopData.TrainType);
		BusinessShopRoleItem helperRoleItem = this.HelperRoleItem;
		if (helperRoleItem != null)
		{
			helperRoleItem.ShowDialog(trainRoleDialogByIdAndType.Dialog);
		}
		BusinessShopRoleItem helperRoleItem2 = this.HelperRoleItem;
		if (helperRoleItem2 != null)
		{
			helperRoleItem2.SwitchRoleSpineAnim(ESpineAnimation.Success, 0f);
		}
		BusinessShopRoleItem playerRoleItem = this.PlayerRoleItem;
		if (playerRoleItem != null)
		{
			playerRoleItem.SwitchRoleSpineAnim(ESpineAnimation.Success, 0f);
		}
		Singleton<AudioSystem>.Instance.ExecuteAction("play_ui_zuiyuejie_loading", EAudioActionType.Stop, null);
		this.PlayCharacterRunFinishAction();
	}

	// Token: 0x06008CFD RID: 36093 RVA: 0x00251465 File Offset: 0x0024F665
	protected bool RemoveTimerHandle()
	{
		if (this.TimeHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimeHandle);
			this.TimeHandle = null;
			return true;
		}
		return false;
	}

	// Token: 0x06008CFE RID: 36094 RVA: 0x0025148C File Offset: 0x0024F68C
	private void RefreshAddText()
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.RefreshAddText();
		}
	}

	// Token: 0x06008CFF RID: 36095 RVA: 0x002514E4 File Offset: 0x0024F6E4
	private void StopTween()
	{
		if (this.ExpTweener != null)
		{
			this.ExpTweener.Kill(false);
			this.ExpTweener = null;
		}
	}

	// Token: 0x06008D00 RID: 36096 RVA: 0x00251504 File Offset: 0x0024F704
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
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_zhuiyuejie_favorability");
	}

	// Token: 0x06008D01 RID: 36097 RVA: 0x002515C4 File Offset: 0x0024F7C4
	private void PlayCharacterEndAction()
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.PlayEndAction();
		}
	}

	// Token: 0x06008D02 RID: 36098 RVA: 0x0025161C File Offset: 0x0024F81C
	private void PlayCurrentValueTween()
	{
		this.ExpTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.ValueDelegate, 0f, 1f, 0.5f, 0f, LTweenEase.OutCubic);
	}

	// Token: 0x06008D03 RID: 36099 RVA: 0x00251649 File Offset: 0x0024F849
	private void OnComplete()
	{
		this.PlayCharacterEndAction();
		this.PlayCurrentValueTween();
	}

	// Token: 0x06008D04 RID: 36100 RVA: 0x00251658 File Offset: 0x0024F858
	private void PlayCurrentValue(float value)
	{
		foreach (CharacterItemWithAdd characterItemWithAdd in this.CharacterListModule.GetItemList())
		{
			characterItemWithAdd.RefreshCurrentValue(value);
		}
	}

	// Token: 0x040041A3 RID: 16803
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected CharacterListModule<CharacterItemWithAdd> CharacterListModule;

	// Token: 0x040041A4 RID: 16804
	protected BusinessShopRoleItem HelperRoleItem;

	// Token: 0x040041A5 RID: 16805
	protected BusinessShopRoleItem PlayerRoleItem;

	// Token: 0x040041A6 RID: 16806
	[Nullable(1)]
	protected List<int> RoleIdList = new List<int>();

	// Token: 0x040041A7 RID: 16807
	[Nullable(1)]
	private List<CharacterData> CharacterList = new List<CharacterData>();

	// Token: 0x040041A8 RID: 16808
	protected ULTweener ExpTweener;

	// Token: 0x040041A9 RID: 16809
	protected FLTweenFloatSetterDynamic Delegate;

	// Token: 0x040041AA RID: 16810
	protected FLTweenFloatSetterDynamic ValueDelegate;

	// Token: 0x040041AB RID: 16811
	protected TimerHandle TimeHandle;

	// Token: 0x040041AC RID: 16812
	private bool IsShoppingLevelUp;

	// Token: 0x040041AD RID: 16813
	private const float SHOP_TWEEN_TIME = 1f;

	// Token: 0x040041AE RID: 16814
	private const float VALUE_TIME = 0.5f;

	// Token: 0x040041AF RID: 16815
	private const int SHOPPING_TIME = 2000;

	// Token: 0x020077D1 RID: 30673
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040293AF RID: 168879
		public const int Title = 0;

		// Token: 0x040293B0 RID: 168880
		public const int CharacterListItem = 1;

		// Token: 0x040293B1 RID: 168881
		public const int SingleLevelItem = 2;

		// Token: 0x040293B2 RID: 168882
		public const int SingleLevel = 3;

		// Token: 0x040293B3 RID: 168883
		public const int MultiLevelItem = 4;

		// Token: 0x040293B4 RID: 168884
		public const int MultiLevelBefore = 5;

		// Token: 0x040293B5 RID: 168885
		public const int MultiLevelAfter = 6;

		// Token: 0x040293B6 RID: 168886
		public const int ConfirmBtn = 7;

		// Token: 0x040293B7 RID: 168887
		public const int BestSuccessItem = 8;

		// Token: 0x040293B8 RID: 168888
		public const int ShoppingItem = 9;

		// Token: 0x040293B9 RID: 168889
		public const int PlayerRoleItem = 10;

		// Token: 0x040293BA RID: 168890
		public const int HelpRoleItem = 11;

		// Token: 0x040293BB RID: 168891
		public const int SkipBtn = 12;
	}
}
