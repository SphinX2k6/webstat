using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AFE RID: 6910
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssRankView : UiViewBase
{
	// Token: 0x0600C6F3 RID: 50931 RVA: 0x00349C6C File Offset: 0x00347E6C
	public DangoAbyssRankView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C6F4 RID: 50932 RVA: 0x00349C78 File Offset: 0x00347E78
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 5;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnSingleRankTabToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnOnlineRankTabToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnButtonLeftClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnButtonRightClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C6F5 RID: 50933 RVA: 0x00349ED6 File Offset: 0x003480D6
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C6F6 RID: 50934 RVA: 0x00349EE8 File Offset: 0x003480E8
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssRankView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssRankView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6F7 RID: 50935 RVA: 0x00349F2C File Offset: 0x0034812C
	private bool CanToggleExecuteChange()
	{
		if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - this.LastChangeToggleTime < 1000L)
		{
			return false;
		}
		this.LastChangeToggleTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		this.ChangeToggleByRequest();
		return false;
	}

	// Token: 0x0600C6F8 RID: 50936 RVA: 0x00349F74 File Offset: 0x00348174
	private UniTask ChangeToggleByRequest()
	{
		DangoAbyssRankView.<ChangeToggleByRequest>d__17 <ChangeToggleByRequest>d__;
		<ChangeToggleByRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ChangeToggleByRequest>d__.<>4__this = this;
		<ChangeToggleByRequest>d__.<>1__state = -1;
		<ChangeToggleByRequest>d__.<>t__builder.Start<DangoAbyssRankView.<ChangeToggleByRequest>d__17>(ref <ChangeToggleByRequest>d__);
		return <ChangeToggleByRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6F9 RID: 50937 RVA: 0x00349FB7 File Offset: 0x003481B7
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C6FA RID: 50938 RVA: 0x00349FC0 File Offset: 0x003481C0
	private UniTask InitOwnRankItem()
	{
		DangoAbyssRankView.<InitOwnRankItem>d__19 <InitOwnRankItem>d__;
		<InitOwnRankItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitOwnRankItem>d__.<>4__this = this;
		<InitOwnRankItem>d__.<>1__state = -1;
		<InitOwnRankItem>d__.<>t__builder.Start<DangoAbyssRankView.<InitOwnRankItem>d__19>(ref <InitOwnRankItem>d__);
		return <InitOwnRankItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6FB RID: 50939 RVA: 0x0034A003 File Offset: 0x00348203
	private void InitRankScroll()
	{
		this.RankScroll = new LoopScrollView<DangoAbyssRankItem, DangoRankItemData>(base.GetLoopScrollViewComponent(3), base.GetItem(4).GetOwner() as AUIBaseActor, new Func<DangoAbyssRankItem>(this.InitRankItem), false);
	}

	// Token: 0x0600C6FC RID: 50940 RVA: 0x0034A035 File Offset: 0x00348235
	private DangoAbyssRankItem InitRankItem()
	{
		return new DangoAbyssRankItem(false);
	}

	// Token: 0x0600C6FD RID: 50941 RVA: 0x0034A03D File Offset: 0x0034823D
	private void OnSingleRankTabToggleClick(EToggleState toggleState)
	{
		this.CurrentMode = ERankMode.Single;
		this.RefreshToggleByCurrentMode();
		this.RefreshRankLayout(false, null);
	}

	// Token: 0x0600C6FE RID: 50942 RVA: 0x0034A055 File Offset: 0x00348255
	private void OnOnlineRankTabToggleClick(EToggleState toggleState)
	{
		this.CurrentMode = ERankMode.Online;
		this.RefreshToggleByCurrentMode();
		this.RefreshRankLayout(this.CurrentMode == ERankMode.Online, null);
	}

	// Token: 0x0600C6FF RID: 50943 RVA: 0x0034A078 File Offset: 0x00348278
	private void RefreshToggleByCurrentMode()
	{
		EToggleState state = (this.CurrentMode == ERankMode.Single) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		EToggleState state2 = (this.CurrentMode == ERankMode.Online) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(1);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600C700 RID: 50944 RVA: 0x0034A0D0 File Offset: 0x003482D0
	private void OnButtonLeftClick()
	{
		this.CurrentPage = Math.Max(this.CurrentPage - 1, 0);
		this.RefreshButtonState();
		this.RefreshLevelText();
		this.RefreshRankLayout(this.CurrentMode == ERankMode.Online, delegate
		{
			UUIInturnAnimController attributeTurnAniComponentL = this.AttributeTurnAniComponentL;
			if (attributeTurnAniComponentL == null)
			{
				return;
			}
			attributeTurnAniComponentL.Play("", -1, false);
		});
		this.RefreshAnonymousToggle();
	}

	// Token: 0x0600C701 RID: 50945 RVA: 0x0034A120 File Offset: 0x00348320
	private void OnButtonRightClick()
	{
		this.CurrentPage = Math.Min(this.CurrentPage + 1, this.MaxPage);
		this.RefreshButtonState();
		this.RefreshLevelText();
		this.RefreshRankLayout(this.CurrentMode == ERankMode.Online, delegate
		{
			UUIInturnAnimController attributeTurnAniComponentR = this.AttributeTurnAniComponentR;
			if (attributeTurnAniComponentR == null)
			{
				return;
			}
			attributeTurnAniComponentR.Play("", -1, false);
		});
		this.RefreshAnonymousToggle();
	}

	// Token: 0x0600C702 RID: 50946 RVA: 0x0034A174 File Offset: 0x00348374
	private void RefreshButtonState()
	{
		bool uiactive = this.CurrentPage > 0;
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(uiactive);
		}
		bool uiactive2 = this.CurrentPage < this.MaxPage;
		UUIButtonComponent button2 = base.GetButton(6);
		if (button2 == null)
		{
			return;
		}
		button2.RootUIComp.Get().SetUIActive(uiactive2);
	}

	// Token: 0x0600C703 RID: 50947 RVA: 0x0034A1DC File Offset: 0x003483DC
	protected override void OnBeforeShow()
	{
		this.OpenData = (this.OpenParam as DangoAbyssRankData);
		this.ChallengeRankData = ModelBase<DangoAbyssModel>.Instance.GetChallengeRankInfo();
		this.MaxPage = this.OpenData.DangoAbyssData.Length - 1;
		int num = this.OpenData.DangoAbyssData.Length;
		for (int i = 0; i < num; i++)
		{
			AbyssInst? abyssInst;
			int? num2 = (this.OpenData.DangoAbyssData[i].GetConfig() != null) ? new int?(abyssInst.GetValueOrDefault().Id) : null;
			int openChallengeId = this.OpenData.OpenChallengeId;
			if (num2.GetValueOrDefault() == openChallengeId & num2 != null)
			{
				this.CurrentPage = i;
				break;
			}
		}
		this.InitMode();
		this.RefreshRankLayout(this.CurrentMode == ERankMode.Online, null);
		this.RefreshLevelText();
		this.RefreshButtonState();
		this.RefreshAnonymousToggle();
	}

	// Token: 0x0600C704 RID: 50948 RVA: 0x0034A2CC File Offset: 0x003484CC
	private void RefreshAnonymousToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		int id = this.OpenData.DangoAbyssData[this.CurrentPage].GetConfig().Value.Id;
		bool challengeAnonymousNameState = ModelBase<DangoAbyssModel>.Instance.GetChallengeAnonymousNameState(id);
		extendToggle.SetToggleStateForce((!challengeAnonymousNameState) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600C705 RID: 50949 RVA: 0x0034A324 File Offset: 0x00348524
	private void InitMode()
	{
		int id = this.OpenData.DangoAbyssData[this.CurrentPage].GetConfig().Value.Id;
		AbyssRankChallengeInfo challengeRankData = this.ChallengeRankData;
		if (challengeRankData != null)
		{
			challengeRankData.RefreshAllPassDataRank(id);
		}
		this.CurrentMode = (this.ChallengeRankData.IsOwnSingleBestScore(id) ? ERankMode.Single : ERankMode.Online);
		this.RefreshToggleByCurrentMode();
	}

	// Token: 0x0600C706 RID: 50950 RVA: 0x0034A38C File Offset: 0x0034858C
	private void RefreshLevelText()
	{
		string title = this.OpenData.DangoAbyssData[this.CurrentPage].GetConfig().Value.Title;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), title, Array.Empty<object>());
	}

	// Token: 0x0600C707 RID: 50951 RVA: 0x0034A3D8 File Offset: 0x003485D8
	[NullableContext(2)]
	private UniTask RefreshRankLayout(bool onlineState, Action finishCall = null)
	{
		DangoAbyssRankView.<RefreshRankLayout>d__32 <RefreshRankLayout>d__;
		<RefreshRankLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRankLayout>d__.<>4__this = this;
		<RefreshRankLayout>d__.onlineState = onlineState;
		<RefreshRankLayout>d__.finishCall = finishCall;
		<RefreshRankLayout>d__.<>1__state = -1;
		<RefreshRankLayout>d__.<>t__builder.Start<DangoAbyssRankView.<RefreshRankLayout>d__32>(ref <RefreshRankLayout>d__);
		return <RefreshRankLayout>d__.<>t__builder.Task;
	}

	// Token: 0x04005F4F RID: 24399
	private const int CD = 1000;

	// Token: 0x04005F50 RID: 24400
	private DangoAbyssRankData OpenData;

	// Token: 0x04005F51 RID: 24401
	[Nullable(2)]
	private AbyssRankChallengeInfo ChallengeRankData;

	// Token: 0x04005F52 RID: 24402
	private ERankMode CurrentMode;

	// Token: 0x04005F53 RID: 24403
	private int CurrentPage;

	// Token: 0x04005F54 RID: 24404
	private int MaxPage;

	// Token: 0x04005F55 RID: 24405
	private LoopScrollView<DangoAbyssRankItem, DangoRankItemData> RankScroll;

	// Token: 0x04005F56 RID: 24406
	private DangoAbyssRankItem OwnRankItem;

	// Token: 0x04005F57 RID: 24407
	private long LastChangeToggleTime;

	// Token: 0x04005F58 RID: 24408
	[Nullable(2)]
	private UUIInturnAnimController AttributeTurnAniComponentR;

	// Token: 0x04005F59 RID: 24409
	[Nullable(2)]
	private UUIInturnAnimController AttributeTurnAniComponentL;

	// Token: 0x02007DD1 RID: 32209
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ADAE RID: 175534
		public const int SingleRankTabToggle = 0;

		// Token: 0x0402ADAF RID: 175535
		public const int OnlineRankTabToggle = 1;

		// Token: 0x0402ADB0 RID: 175536
		public const int LevelText = 2;

		// Token: 0x0402ADB1 RID: 175537
		public const int RankScroller = 3;

		// Token: 0x0402ADB2 RID: 175538
		public const int RankScrollerItem = 4;

		// Token: 0x0402ADB3 RID: 175539
		public const int ButtonLeft = 5;

		// Token: 0x0402ADB4 RID: 175540
		public const int ButtonRight = 6;

		// Token: 0x0402ADB5 RID: 175541
		public const int CloseBtn = 7;

		// Token: 0x0402ADB6 RID: 175542
		public const int SelfRankItem = 8;

		// Token: 0x0402ADB7 RID: 175543
		public const int AnonymousToggle = 9;

		// Token: 0x0402ADB8 RID: 175544
		public const int TurnAnimationItem = 10;
	}
}
