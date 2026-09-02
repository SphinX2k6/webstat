using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Area;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.Opponent;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Choose;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Discard;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055B1 RID: 21937
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleView : UiViewBase
	{
		// Token: 0x06037D86 RID: 228742 RVA: 0x00E25CAB File Offset: 0x00E23EAB
		public PhantomArenaBattleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06037D87 RID: 228743 RVA: 0x00E25CBC File Offset: 0x00E23EBC
		protected override void OnRegisterComponent()
		{
			this.Proxy = new PhantomArenaBattleProxy();
			this.Proxy.RegisterView(this);
			this.OpenParam = this.Proxy;
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIText)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIText)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIText)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIItem)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUISprite)),
				new ValueTuple<int, Type>(25, typeof(UUISprite)),
				new ValueTuple<int, Type>(26, typeof(UUIItem)),
				new ValueTuple<int, Type>(27, typeof(UUITexture)),
				new ValueTuple<int, Type>(28, typeof(UUIItem)),
				new ValueTuple<int, Type>(29, typeof(UUINiagara)),
				new ValueTuple<int, Type>(30, typeof(UUINiagara)),
				new ValueTuple<int, Type>(31, typeof(UUINiagara)),
				new ValueTuple<int, Type>(32, typeof(UUINiagara)),
				new ValueTuple<int, Type>(33, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.Proxy.HideLayoutClick)),
				new ValueTuple<int, Delegate>(7, new Action(this.Proxy.TimeEndClick))
			};
		}

		// Token: 0x06037D88 RID: 228744 RVA: 0x00E26044 File Offset: 0x00E24244
		private UniTask InitLibrarySprite()
		{
			PhantomArenaBattleView.<InitLibrarySprite>d__7 <InitLibrarySprite>d__;
			<InitLibrarySprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLibrarySprite>d__.<>4__this = this;
			<InitLibrarySprite>d__.<>1__state = -1;
			<InitLibrarySprite>d__.<>t__builder.Start<PhantomArenaBattleView.<InitLibrarySprite>d__7>(ref <InitLibrarySprite>d__);
			return <InitLibrarySprite>d__.<>t__builder.Task;
		}

		// Token: 0x06037D89 RID: 228745 RVA: 0x00E26088 File Offset: 0x00E24288
		private UniTask InitDesktopBg()
		{
			PhantomArenaBattleView.<InitDesktopBg>d__8 <InitDesktopBg>d__;
			<InitDesktopBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDesktopBg>d__.<>4__this = this;
			<InitDesktopBg>d__.<>1__state = -1;
			<InitDesktopBg>d__.<>t__builder.Start<PhantomArenaBattleView.<InitDesktopBg>d__8>(ref <InitDesktopBg>d__);
			return <InitDesktopBg>d__.<>t__builder.Task;
		}

		// Token: 0x06037D8A RID: 228746 RVA: 0x00E260CC File Offset: 0x00E242CC
		private void InitCaption()
		{
			this.Proxy.CaptionItem = new PopupCaptionItem(base.GetItem(15));
			this.Proxy.CaptionItem.SetCloseCallBack(new Action(this.Proxy.CloseClick));
			this.Proxy.CaptionItem.SetHelpCallBack(new Action(this.Proxy.HelpClick));
		}

		// Token: 0x06037D8B RID: 228747 RVA: 0x00E26134 File Offset: 0x00E24334
		private UniTask InitOwnArea()
		{
			PhantomArenaBattleView.<InitOwnArea>d__10 <InitOwnArea>d__;
			<InitOwnArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOwnArea>d__.<>4__this = this;
			<InitOwnArea>d__.<>1__state = -1;
			<InitOwnArea>d__.<>t__builder.Start<PhantomArenaBattleView.<InitOwnArea>d__10>(ref <InitOwnArea>d__);
			return <InitOwnArea>d__.<>t__builder.Task;
		}

		// Token: 0x06037D8C RID: 228748 RVA: 0x00E26178 File Offset: 0x00E24378
		private UniTask InitOpponentArea()
		{
			PhantomArenaBattleView.<InitOpponentArea>d__11 <InitOpponentArea>d__;
			<InitOpponentArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOpponentArea>d__.<>4__this = this;
			<InitOpponentArea>d__.<>1__state = -1;
			<InitOpponentArea>d__.<>t__builder.Start<PhantomArenaBattleView.<InitOpponentArea>d__11>(ref <InitOpponentArea>d__);
			return <InitOpponentArea>d__.<>t__builder.Task;
		}

		// Token: 0x06037D8D RID: 228749 RVA: 0x00E261BC File Offset: 0x00E243BC
		private UniTask InitCardLibrary()
		{
			PhantomArenaBattleView.<InitCardLibrary>d__12 <InitCardLibrary>d__;
			<InitCardLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCardLibrary>d__.<>4__this = this;
			<InitCardLibrary>d__.<>1__state = -1;
			<InitCardLibrary>d__.<>t__builder.Start<PhantomArenaBattleView.<InitCardLibrary>d__12>(ref <InitCardLibrary>d__);
			return <InitCardLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x06037D8E RID: 228750 RVA: 0x00E26200 File Offset: 0x00E24400
		private UniTask InitTipsItem()
		{
			PhantomArenaBattleView.<InitTipsItem>d__13 <InitTipsItem>d__;
			<InitTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsItem>d__.<>4__this = this;
			<InitTipsItem>d__.<>1__state = -1;
			<InitTipsItem>d__.<>t__builder.Start<PhantomArenaBattleView.<InitTipsItem>d__13>(ref <InitTipsItem>d__);
			return <InitTipsItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037D8F RID: 228751 RVA: 0x00E26244 File Offset: 0x00E24444
		private UniTask InitDetailsTips()
		{
			PhantomArenaBattleView.<InitDetailsTips>d__14 <InitDetailsTips>d__;
			<InitDetailsTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDetailsTips>d__.<>4__this = this;
			<InitDetailsTips>d__.<>1__state = -1;
			<InitDetailsTips>d__.<>t__builder.Start<PhantomArenaBattleView.<InitDetailsTips>d__14>(ref <InitDetailsTips>d__);
			return <InitDetailsTips>d__.<>t__builder.Task;
		}

		// Token: 0x06037D90 RID: 228752 RVA: 0x00E26288 File Offset: 0x00E24488
		private UniTask InitSkillTips()
		{
			PhantomArenaBattleView.<InitSkillTips>d__15 <InitSkillTips>d__;
			<InitSkillTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillTips>d__.<>4__this = this;
			<InitSkillTips>d__.<>1__state = -1;
			<InitSkillTips>d__.<>t__builder.Start<PhantomArenaBattleView.<InitSkillTips>d__15>(ref <InitSkillTips>d__);
			return <InitSkillTips>d__.<>t__builder.Task;
		}

		// Token: 0x06037D91 RID: 228753 RVA: 0x00E262CC File Offset: 0x00E244CC
		private UniTask InitDiscardPanel()
		{
			PhantomArenaBattleView.<InitDiscardPanel>d__16 <InitDiscardPanel>d__;
			<InitDiscardPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDiscardPanel>d__.<>4__this = this;
			<InitDiscardPanel>d__.<>1__state = -1;
			<InitDiscardPanel>d__.<>t__builder.Start<PhantomArenaBattleView.<InitDiscardPanel>d__16>(ref <InitDiscardPanel>d__);
			return <InitDiscardPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06037D92 RID: 228754 RVA: 0x00E26310 File Offset: 0x00E24510
		private UniTask InitChooseCardPanel()
		{
			PhantomArenaBattleView.<InitChooseCardPanel>d__17 <InitChooseCardPanel>d__;
			<InitChooseCardPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitChooseCardPanel>d__.<>4__this = this;
			<InitChooseCardPanel>d__.<>1__state = -1;
			<InitChooseCardPanel>d__.<>t__builder.Start<PhantomArenaBattleView.<InitChooseCardPanel>d__17>(ref <InitChooseCardPanel>d__);
			return <InitChooseCardPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06037D93 RID: 228755 RVA: 0x00E26354 File Offset: 0x00E24554
		private UniTask InitSkillTriggerMask()
		{
			PhantomArenaBattleView.<InitSkillTriggerMask>d__18 <InitSkillTriggerMask>d__;
			<InitSkillTriggerMask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillTriggerMask>d__.<>4__this = this;
			<InitSkillTriggerMask>d__.<>1__state = -1;
			<InitSkillTriggerMask>d__.<>t__builder.Start<PhantomArenaBattleView.<InitSkillTriggerMask>d__18>(ref <InitSkillTriggerMask>d__);
			return <InitSkillTriggerMask>d__.<>t__builder.Task;
		}

		// Token: 0x06037D94 RID: 228756 RVA: 0x00E26398 File Offset: 0x00E24598
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037D95 RID: 228757 RVA: 0x00E263DC File Offset: 0x00E245DC
		protected override void OnStart()
		{
			this.DissolveTween = new LguiFloatTween();
			this.DissolveTween.SetCurrentEase(LTweenEase.InOutSine);
			this.DissolveTween.BindUpdateTween(new Action<float>(this.OnDissolveTweenUpdate));
			this.SetNiagaraNpcActive(false);
			this.SetNiagaraPlayerActive(false);
			this.SetNiagaraNpcStartActive(false);
			this.Proxy.BanButtonClickModule.RegisterButton(base.GetButton(7));
			this.Proxy.BanButtonClickModule.RegisterButton(this.Proxy.CaptionItem.GetCloseBtn());
			this.Proxy.BanButtonClickModule.RegisterButton(this.Proxy.CaptionItem.GetHelpBtn());
		}

		// Token: 0x06037D96 RID: 228758 RVA: 0x00E26484 File Offset: 0x00E24684
		protected override void OnBeforeShow()
		{
			if (this.FirstShowDirty)
			{
				this.FirstShowDirty = false;
				return;
			}
			this.Proxy.Show(false);
		}

		// Token: 0x06037D97 RID: 228759 RVA: 0x00E264A4 File Offset: 0x00E246A4
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OwnBattleStatusChange, new Action<IReadOnlyList<PhantomBattleRoleStatus>>(this.Proxy.OnOwnBattleStatusChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OpponentBattleStatusChange, new Action<IReadOnlyList<PhantomBattleRoleStatus>>(this.Proxy.OnOpponentBattleStatusChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OwnCardLibraryChange, new Action(this.Proxy.OnOwnCardLibraryChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OpponentHandCardChange, new Action(this.Proxy.OnOpponentHandCardChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OpponentCardLibraryChange, new Action(this.Proxy.OnOpponentCardLibraryChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OwnHandCardAdd, new Action<IReadOnlyList<int>>(this.Proxy.OnOwnHandCardAdd));
			Singleton<EventSystem>.Instance.Add(EEventName.PhantomArenaTriggerSkillEffect, new Action(this.Proxy.OnTriggerSkillEffect));
			Singleton<EventSystem>.Instance.Add(EEventName.NotifyCardTaskData, new Action<bool>(this.Proxy.OnNotifyCardTaskData));
			Singleton<EventSystem>.Instance.Add(EEventName.OwnHandCardRemove, new Action<IReadOnlyList<int>>(this.Proxy.OnOwnHandCardRemove));
			Singleton<EventSystem>.Instance.Add(EEventName.PhantomArenaCardAttrRefresh, new Action<int>(this.Proxy.OnCardAttrRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.PhantomArenaCardFactorsRefresh, new Action<int>(this.Proxy.OnCardFactorsRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.NotifyBattleCardChange, new Action<bool, int, int>(this.Proxy.OnNotifyBattleCardChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OwnBattleAttrChange, new Action<IReadOnlyList<PhantomBattleCardAttr>>(this.Proxy.OnOwnBattleAttrChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OpponentBattleAttrChange, new Action<IReadOnlyList<PhantomBattleCardAttr>>(this.Proxy.OnOpponentBattleAttrChange));
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshRound, new Action(this.Proxy.OnRefreshRound));
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshBattleCardNum, new Action(this.Proxy.OnRefreshBattleCardNum));
			Singleton<EventSystem>.Instance.Add(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.Proxy.OnInputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshHandCardState, new Action(this.Proxy.OnRefreshHandCardState));
			Singleton<EventSystem>.Instance.Add(EEventName.PhantomBattleBoardSettleNotify, new Action(this.Proxy.OnPhantomBattleBoardSettleNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.OpponentSealFieldChange, new Action<int>(this.Proxy.OnOpponentSealFieldChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OwnSealRecycleChange, new Action<int>(this.Proxy.OnOwnSealRecycleChange));
		}

		// Token: 0x06037D98 RID: 228760 RVA: 0x00E26768 File Offset: 0x00E24968
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OwnBattleStatusChange, new Action<IReadOnlyList<PhantomBattleRoleStatus>>(this.Proxy.OnOwnBattleStatusChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpponentBattleStatusChange, new Action<IReadOnlyList<PhantomBattleRoleStatus>>(this.Proxy.OnOpponentBattleStatusChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OwnCardLibraryChange, new Action(this.Proxy.OnOwnCardLibraryChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpponentHandCardChange, new Action(this.Proxy.OnOpponentHandCardChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpponentCardLibraryChange, new Action(this.Proxy.OnOpponentCardLibraryChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OwnHandCardAdd, new Action<IReadOnlyList<int>>(this.Proxy.OnOwnHandCardAdd));
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomArenaTriggerSkillEffect, new Action(this.Proxy.OnTriggerSkillEffect));
			Singleton<EventSystem>.Instance.Remove(EEventName.NotifyCardTaskData, new Action<bool>(this.Proxy.OnNotifyCardTaskData));
			Singleton<EventSystem>.Instance.Remove(EEventName.OwnHandCardRemove, new Action<IReadOnlyList<int>>(this.Proxy.OnOwnHandCardRemove));
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomArenaCardAttrRefresh, new Action<int>(this.Proxy.OnCardAttrRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomArenaCardFactorsRefresh, new Action<int>(this.Proxy.OnCardFactorsRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.NotifyBattleCardChange, new Action<bool, int, int>(this.Proxy.OnNotifyBattleCardChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OwnBattleAttrChange, new Action<IReadOnlyList<PhantomBattleCardAttr>>(this.Proxy.OnOwnBattleAttrChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpponentBattleAttrChange, new Action<IReadOnlyList<PhantomBattleCardAttr>>(this.Proxy.OnOpponentBattleAttrChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshRound, new Action(this.Proxy.OnRefreshRound));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshBattleCardNum, new Action(this.Proxy.OnRefreshBattleCardNum));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.Proxy.OnInputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshHandCardState, new Action(this.Proxy.OnRefreshHandCardState));
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomBattleBoardSettleNotify, new Action(this.Proxy.OnPhantomBattleBoardSettleNotify));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpponentSealFieldChange, new Action<int>(this.Proxy.OnOpponentSealFieldChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OwnSealRecycleChange, new Action<int>(this.Proxy.OnOwnSealRecycleChange));
		}

		// Token: 0x06037D99 RID: 228761 RVA: 0x00E26A2A File Offset: 0x00E24C2A
		protected override void OnBeforeDestroy()
		{
			this.Proxy.Destroy();
			this.DissolveTween.Destroy();
		}

		// Token: 0x06037D9A RID: 228762 RVA: 0x00E26A42 File Offset: 0x00E24C42
		public UUIItem GetDragRootItem()
		{
			return base.GetItem(4);
		}

		// Token: 0x06037D9B RID: 228763 RVA: 0x00E26A4B File Offset: 0x00E24C4B
		public UUIItem GetOwnCardLibraryItem()
		{
			return base.GetItem(17);
		}

		// Token: 0x06037D9C RID: 228764 RVA: 0x00E26A55 File Offset: 0x00E24C55
		public UUIItem GetOpponentCardLibraryItem()
		{
			return base.GetItem(18);
		}

		// Token: 0x06037D9D RID: 228765 RVA: 0x00E26A5F File Offset: 0x00E24C5F
		public UUIItem GetSkillTriggerAttachItem()
		{
			return base.GetItem(6);
		}

		// Token: 0x06037D9E RID: 228766 RVA: 0x00E26A68 File Offset: 0x00E24C68
		public void SetCaptionItemActive(bool bActive)
		{
			base.GetItem(15).SetUIActive(bActive);
		}

		// Token: 0x06037D9F RID: 228767 RVA: 0x00E26A78 File Offset: 0x00E24C78
		public void SetRoundEffectActive(bool bActive)
		{
			base.GetItem(20).SetUIActive(bActive);
		}

		// Token: 0x06037DA0 RID: 228768 RVA: 0x00E26A88 File Offset: 0x00E24C88
		public void RefreshOwnCardLibraryNum()
		{
			int cardLibraryNum = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.CardLibraryNum;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "PhantomBattle_1022", new <>z__ReadOnlySingleElementList<object>(cardLibraryNum));
		}

		// Token: 0x06037DA1 RID: 228769 RVA: 0x00E26AC8 File Offset: 0x00E24CC8
		public void RefreshOpponentCardLibraryNum()
		{
			int cardLibraryNum = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.CardLibraryNum;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "PhantomBattle_1022", new <>z__ReadOnlySingleElementList<object>(cardLibraryNum));
		}

		// Token: 0x06037DA2 RID: 228770 RVA: 0x00E26B08 File Offset: 0x00E24D08
		public void SetTimeEndBtnInteractive(bool bInteractive)
		{
			UUIButtonComponent button = base.GetButton(7);
			if (bInteractive)
			{
				this.Proxy.BanButtonClickModule.ResumeButton(button, "TimeEndBtn.SetTimeEndBtnInteractive");
				return;
			}
			this.Proxy.BanButtonClickModule.BanButton(button, "TimeEndBtn.SetTimeEndBtnInteractive");
		}

		// Token: 0x06037DA3 RID: 228771 RVA: 0x00E26B50 File Offset: 0x00E24D50
		public void RefreshRoundNum()
		{
			int challengeId = ModelBase<PhantomArenaBattleModel>.Instance.ChallengeId;
			PhantomBattleChallenge phantomBattleChallengeConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeConfig(challengeId);
			int round = ModelBase<PhantomArenaBattleModel>.Instance.Round;
			int maxRoundNum = phantomBattleChallengeConfig.MaxRoundNum;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "PhantomBattle_1082", new <>z__ReadOnlyArray<object>(new object[]
			{
				round,
				maxRoundNum
			}));
		}

		// Token: 0x06037DA4 RID: 228772 RVA: 0x00E26BBC File Offset: 0x00E24DBC
		public void RefreshLimitText()
		{
			int monsterCardLength = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.MonsterCardLength;
			base.GetText(19).SetText(monsterCardLength.ToString() + "/" + 4.ToString(), true);
		}

		// Token: 0x06037DA5 RID: 228773 RVA: 0x00E26C04 File Offset: 0x00E24E04
		public UniTask PlayShowFieldEffect()
		{
			PhantomArenaBattleView.<PlayShowFieldEffect>d__36 <PlayShowFieldEffect>d__;
			<PlayShowFieldEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayShowFieldEffect>d__.<>4__this = this;
			<PlayShowFieldEffect>d__.<>1__state = -1;
			<PlayShowFieldEffect>d__.<>t__builder.Start<PhantomArenaBattleView.<PlayShowFieldEffect>d__36>(ref <PlayShowFieldEffect>d__);
			return <PlayShowFieldEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037DA6 RID: 228774 RVA: 0x00E26C47 File Offset: 0x00E24E47
		public void LockNpcField()
		{
			this.DissolveTween.PlayTween(0.55f, 0f, 0.5f, null);
		}

		// Token: 0x06037DA7 RID: 228775 RVA: 0x00E26C64 File Offset: 0x00E24E64
		public void UnlockNpcField()
		{
			this.RefreshNiagaraNpc();
			this.SetNiagaraNpcActive(true);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequencePurely("FieldReleaseNpc", false, false);
			}
			this.DissolveTween.PlayTween(0f, 0.55f, 0.5f, null);
		}

		// Token: 0x06037DA8 RID: 228776 RVA: 0x00E26CB1 File Offset: 0x00E24EB1
		private void SetNiagaraNpcActive(bool value)
		{
			base.GetUiNiagara(30).SetUIActive(value);
		}

		// Token: 0x06037DA9 RID: 228777 RVA: 0x00E26CC1 File Offset: 0x00E24EC1
		private void SetNiagaraNpcStartActive(bool value)
		{
			base.GetUiNiagara(31).SetUIActive(value);
		}

		// Token: 0x06037DAA RID: 228778 RVA: 0x00E26CD1 File Offset: 0x00E24ED1
		private void SetNiagaraPlayerActive(bool value)
		{
			base.GetUiNiagara(29).SetUIActive(value);
		}

		// Token: 0x06037DAB RID: 228779 RVA: 0x00E26CE4 File Offset: 0x00E24EE4
		private void RefreshNiagaraNpc()
		{
			PhantomArenaFieldData fieldData = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.FieldData;
			if (fieldData == null)
			{
				return;
			}
			UUINiagara uiNiagara = base.GetUiNiagara(30);
			if (!StringUtils.IsBlank(fieldData.BaseColor))
			{
				FColor fcolor = FColor.FromHex(fieldData.BaseColor);
				FLinearColor value = new FLinearColor(ref fcolor);
				uiNiagara.SetNiagaraVarLinearColor("Base_Color", value);
			}
			if (!StringUtils.IsBlank(fieldData.BackGroundColor))
			{
				FColor fcolor = FColor.FromHex(fieldData.BackGroundColor);
				FLinearColor value2 = new FLinearColor(ref fcolor);
				uiNiagara.SetNiagaraVarLinearColor("Background_Color", value2);
			}
		}

		// Token: 0x06037DAC RID: 228780 RVA: 0x00E26D6C File Offset: 0x00E24F6C
		private UniTask RefreshPlayerTexture()
		{
			PhantomArenaBattleView.<RefreshPlayerTexture>d__43 <RefreshPlayerTexture>d__;
			<RefreshPlayerTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshPlayerTexture>d__.<>4__this = this;
			<RefreshPlayerTexture>d__.<>1__state = -1;
			<RefreshPlayerTexture>d__.<>t__builder.Start<PhantomArenaBattleView.<RefreshPlayerTexture>d__43>(ref <RefreshPlayerTexture>d__);
			return <RefreshPlayerTexture>d__.<>t__builder.Task;
		}

		// Token: 0x06037DAD RID: 228781 RVA: 0x00E26DB0 File Offset: 0x00E24FB0
		private UniTask RefreshNiagaraPlayer()
		{
			PhantomArenaBattleView.<RefreshNiagaraPlayer>d__44 <RefreshNiagaraPlayer>d__;
			<RefreshNiagaraPlayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshNiagaraPlayer>d__.<>4__this = this;
			<RefreshNiagaraPlayer>d__.<>1__state = -1;
			<RefreshNiagaraPlayer>d__.<>t__builder.Start<PhantomArenaBattleView.<RefreshNiagaraPlayer>d__44>(ref <RefreshNiagaraPlayer>d__);
			return <RefreshNiagaraPlayer>d__.<>t__builder.Task;
		}

		// Token: 0x06037DAE RID: 228782 RVA: 0x00E26DF4 File Offset: 0x00E24FF4
		protected override UUIItem OnGetBlurRootItem()
		{
			if (this.Proxy.IsMainInVisible)
			{
				return this.RootItem;
			}
			if (this.Proxy.InPanelInteractType == EPhantomArenaBattlePanelInteractType.ChooseCardPanel)
			{
				return this.Proxy.ChooseCardPanel.GetRootItem();
			}
			if (this.Proxy.InPanelInteractType == EPhantomArenaBattlePanelInteractType.DiscardCardPanel)
			{
				return this.Proxy.DiscardPanel.GetRootItem();
			}
			return this.RootItem;
		}

		// Token: 0x06037DAF RID: 228783 RVA: 0x00E26E59 File Offset: 0x00E25059
		private void SetNiagaraNpcDissolve(float value)
		{
			base.GetUiNiagara(30).SetNiagaraVarFloat("Dissolve", value);
		}

		// Token: 0x06037DB0 RID: 228784 RVA: 0x00E26E6E File Offset: 0x00E2506E
		private void OnDissolveTweenUpdate(float value)
		{
			this.SetNiagaraNpcDissolve(value);
		}

		// Token: 0x06037DB1 RID: 228785 RVA: 0x00E26E78 File Offset: 0x00E25078
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "CardEffect" || a == "CardAttr" || a == "DetailCard" || a == "CardFullInfo")
			{
				PhantomArenaBattleTips tipsItem = this.Proxy.TipsItem;
				if (tipsItem == null)
				{
					return null;
				}
				return tipsItem.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else if (a == "BattleCard" || a == "BattleCardById" || a == "BattleCardSkillById")
			{
				if (configParams[1] == "Own")
				{
					PhantomArenaFunctionalArea functionalArea = this.Proxy.OwnArea.FunctionalArea;
					if (functionalArea == null)
					{
						return null;
					}
					return functionalArea.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
				else
				{
					OpponentFunctionArea functionalArea2 = this.Proxy.OpponentArea.FunctionalArea;
					if (functionalArea2 == null)
					{
						return null;
					}
					return functionalArea2.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
			}
			else if (a == "HandCard")
			{
				PhantomArenaOwnArea ownArea = this.Proxy.OwnArea;
				if (ownArea == null)
				{
					return null;
				}
				PhantomArenaHandArea handArea = ownArea.HandArea;
				if (handArea == null)
				{
					return null;
				}
				return handArea.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (a == "HandArea")
				{
					PhantomArenaOwnArea ownArea2 = this.Proxy.OwnArea;
					UUIItem[] array;
					if (ownArea2 == null)
					{
						array = null;
					}
					else
					{
						PhantomArenaHandArea handArea2 = ownArea2.HandArea;
						array = ((handArea2 != null) ? handArea2.GetGuideUiItemAndUiItemForShowEx(configParams) : null);
					}
					UUIItem[] array2 = array;
					if (array2 != null && array2.Length > 1)
					{
						array2[1] = base.GetGuideUiItem("8");
					}
					return array2;
				}
				if (a == "Task")
				{
					PhantomArenaOwnArea ownArea3 = this.Proxy.OwnArea;
					if (ownArea3 == null)
					{
						return null;
					}
					PhantomArenaOwnRolePanel rolePanel = ownArea3.RolePanel;
					if (rolePanel == null)
					{
						return null;
					}
					return rolePanel.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
				else if (a == "BattleCardDiscardById")
				{
					PhantomArenaDiscardCardPanel discardPanel = this.Proxy.DiscardPanel;
					if (discardPanel == null)
					{
						return null;
					}
					return discardPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
				else
				{
					if (!(a == "BattleCardChooseById"))
					{
						return null;
					}
					PhantomArenaChooseCardPanel chooseCardPanel = this.Proxy.ChooseCardPanel;
					if (chooseCardPanel == null)
					{
						return null;
					}
					return chooseCardPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
			}
		}

		// Token: 0x0401FF8E RID: 130958
		private PhantomArenaBattleProxy Proxy;

		// Token: 0x0401FF8F RID: 130959
		protected AActor DesktopBg;

		// Token: 0x0401FF90 RID: 130960
		protected bool FirstShowDirty = true;

		// Token: 0x0401FF91 RID: 130961
		protected LguiFloatTween DissolveTween;

		// Token: 0x0200B55A RID: 46426
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040381EE RID: 229870
			public const int OwnHandItem = 0;

			// Token: 0x040381EF RID: 229871
			public const int OwnFunctionalItem = 1;

			// Token: 0x040381F0 RID: 229872
			public const int OpponentHandItem = 2;

			// Token: 0x040381F1 RID: 229873
			public const int OpponentFunctionalItem = 3;

			// Token: 0x040381F2 RID: 229874
			public const int DragRootItem = 4;

			// Token: 0x040381F3 RID: 229875
			public const int HideLayoutBtn = 5;

			// Token: 0x040381F4 RID: 229876
			public const int SkillTriggerAttachItem = 6;

			// Token: 0x040381F5 RID: 229877
			public const int TimeEndBtn = 7;

			// Token: 0x040381F6 RID: 229878
			public const int CardLibrary = 8;

			// Token: 0x040381F7 RID: 229879
			public const int AttachItem = 9;

			// Token: 0x040381F8 RID: 229880
			public const int OwnRoleItem = 10;

			// Token: 0x040381F9 RID: 229881
			public const int OpponentRoleItem = 11;

			// Token: 0x040381FA RID: 229882
			public const int OwnCardLibraryNum = 12;

			// Token: 0x040381FB RID: 229883
			public const int OpponentCardLibraryNum = 13;

			// Token: 0x040381FC RID: 229884
			public const int TipsItem = 14;

			// Token: 0x040381FD RID: 229885
			public const int CaptionItem = 15;

			// Token: 0x040381FE RID: 229886
			public const int RoundNum = 16;

			// Token: 0x040381FF RID: 229887
			public const int OwnCardLibraryItem = 17;

			// Token: 0x04038200 RID: 229888
			public const int OpponentCardLibraryItem = 18;

			// Token: 0x04038201 RID: 229889
			public const int LimitText = 19;

			// Token: 0x04038202 RID: 229890
			public const int RoundEffect = 20;

			// Token: 0x04038203 RID: 229891
			public const int HeadItem = 21;

			// Token: 0x04038204 RID: 229892
			public const int OwnFiledItem = 22;

			// Token: 0x04038205 RID: 229893
			public const int OpponentFiledItem = 23;

			// Token: 0x04038206 RID: 229894
			public const int OpponentLibrarySprite = 24;

			// Token: 0x04038207 RID: 229895
			public const int OwnLibrarySprite = 25;

			// Token: 0x04038208 RID: 229896
			public const int DesktopBg = 26;

			// Token: 0x04038209 RID: 229897
			public const int FieldBg = 27;

			// Token: 0x0403820A RID: 229898
			public const int FieldAttachItem = 28;

			// Token: 0x0403820B RID: 229899
			public const int NiagaraPlayer = 29;

			// Token: 0x0403820C RID: 229900
			public const int NiagaraNpc = 30;

			// Token: 0x0403820D RID: 229901
			public const int NiagaraNpcStart = 31;

			// Token: 0x0403820E RID: 229902
			public const int NiagaraPlayerElement = 32;

			// Token: 0x0403820F RID: 229903
			public const int AttachDetailsTipsItem = 33;
		}
	}
}
