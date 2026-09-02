using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.PhantomArena.Battle.Area;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand;
using CSharpScript.Game.Module.PhantomArena.Battle.Canvas;
using CSharpScript.Game.Module.PhantomArena.Battle.Dialog;
using CSharpScript.Game.Module.PhantomArena.Battle.Gamepad;
using CSharpScript.Game.Module.PhantomArena.Battle.Guide;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.Opponent;
using CSharpScript.Game.Module.PhantomArena.Battle.Process;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using CSharpScript.Game.Module.PhantomArena.Battle.View.BuffEffect;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Choose;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Discard;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Field;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055A9 RID: 21929
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleProxy
	{
		// Token: 0x06037D02 RID: 228610 RVA: 0x00E2407C File Offset: 0x00E2227C
		public PhantomArenaBattleProxy()
		{
			this.ProcessManager = new PhantomArenaProcessManager(this);
			this.BuffEffectManager = new PhantomArenaBuffEffectManager(this);
			this.GuideManager = new PhantomArenaBattleGuideManager(this);
			this.RoundOverCheck = new PhantomArenaRoundOverCheck(this);
			this.GamepadLogic = new PhantomArenaBattleViewGamepadLogic(this);
			this.ServerActionQueue = new PhantomArenaBattleServerActionQueue(this);
		}

		// Token: 0x06037D03 RID: 228611 RVA: 0x00E2410A File Offset: 0x00E2230A
		public void RegisterView(PhantomArenaBattleView view)
		{
			this.View = view;
		}

		// Token: 0x06037D04 RID: 228612 RVA: 0x00E24114 File Offset: 0x00E22314
		public void RefreshByWorldDone()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "世界加载完成,刷新界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			PhantomArenaBattleController.RequestPhantomBattleStart();
			this.Show(true);
		}

		// Token: 0x06037D05 RID: 228613 RVA: 0x00E2414C File Offset: 0x00E2234C
		public void Show(bool isFromWorldDone)
		{
			this.View.SetTimeEndBtnInteractive(false);
			this.View.RefreshOwnCardLibraryNum();
			this.View.RefreshOpponentCardLibraryNum();
			this.View.RefreshRoundNum();
			this.View.RefreshLimitText();
			this.OwnArea.RefreshAll(isFromWorldDone);
			this.OpponentArea.RefreshAll(isFromWorldDone);
			this.CardRecycle.RefreshCostNum();
		}

		// Token: 0x06037D06 RID: 228614 RVA: 0x00E241B4 File Offset: 0x00E223B4
		public void Destroy()
		{
			this.ProcessManager.Clear();
			this.CanvasManager.ClearAreaCanvas();
			this.OpponentArea.Clear();
			this.DialogManager.Clear();
			ModelBase<PhantomArenaBattleModel>.Instance.ClearWaitBattleData();
		}

		// Token: 0x06037D07 RID: 228615 RVA: 0x00E241EC File Offset: 0x00E223EC
		public UUIItem GetDragRootItem()
		{
			return this.View.GetDragRootItem();
		}

		// Token: 0x06037D08 RID: 228616 RVA: 0x00E241F9 File Offset: 0x00E223F9
		public UUIItem GetOpponentCardLibraryItem()
		{
			return this.View.GetOpponentCardLibraryItem();
		}

		// Token: 0x06037D09 RID: 228617 RVA: 0x00E24206 File Offset: 0x00E22406
		public UUIItem GetSkillTriggerAttachItem()
		{
			return this.View.GetSkillTriggerAttachItem();
		}

		// Token: 0x06037D0A RID: 228618 RVA: 0x00E24214 File Offset: 0x00E22414
		public UniTask PlayShowFieldEffect()
		{
			PhantomArenaBattleProxy.<PlayShowFieldEffect>d__33 <PlayShowFieldEffect>d__;
			<PlayShowFieldEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayShowFieldEffect>d__.<>4__this = this;
			<PlayShowFieldEffect>d__.<>1__state = -1;
			<PlayShowFieldEffect>d__.<>t__builder.Start<PhantomArenaBattleProxy.<PlayShowFieldEffect>d__33>(ref <PlayShowFieldEffect>d__);
			return <PlayShowFieldEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037D0B RID: 228619 RVA: 0x00E24257 File Offset: 0x00E22457
		public void ShowLine()
		{
		}

		// Token: 0x06037D0C RID: 228620 RVA: 0x00E24259 File Offset: 0x00E22459
		public void HideLine()
		{
		}

		// Token: 0x06037D0D RID: 228621 RVA: 0x00E2425B File Offset: 0x00E2245B
		public void SetCaptionItemActive(bool bActive)
		{
			this.View.SetCaptionItemActive(bActive);
		}

		// Token: 0x06037D0E RID: 228622 RVA: 0x00E24269 File Offset: 0x00E22469
		public void ShowAddBuffEffect(EBuffShowType buffShowType, List<int> fightIdList)
		{
			this.OwnArea.FunctionalArea.ShowAddBuffEffect(buffShowType, fightIdList);
			this.OpponentArea.FunctionalArea.ShowAddBuffEffect(buffShowType, fightIdList);
		}

		// Token: 0x06037D0F RID: 228623 RVA: 0x00E24290 File Offset: 0x00E22490
		public unsafe void RegisterCantDragReason(EPhantomArenaCantDragReason reason)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加不可拖动状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("状态", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("状态集合", this.InCantDragStateSet);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.InCantDragStateSet.Add(reason);
		}

		// Token: 0x06037D10 RID: 228624 RVA: 0x00E2430C File Offset: 0x00E2250C
		public unsafe void UnRegisterCantDragReason(EPhantomArenaCantDragReason reason)
		{
			this.InCantDragStateSet.Remove(reason);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "删除不可拖动状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("状态", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("状态集合", this.InCantDragStateSet);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06037D11 RID: 228625 RVA: 0x00E24386 File Offset: 0x00E22586
		public bool InCantDragState()
		{
			return this.InCantDragStateSet.Count > 0;
		}

		// Token: 0x06037D12 RID: 228626 RVA: 0x00E24396 File Offset: 0x00E22596
		public void SetSelectedCardId(int cardId, EPhantomArenaCardClickFromType fromType)
		{
			if (this.SelectedCardId == cardId && this.SelectedFrom == fromType)
			{
				return;
			}
			if (this.SelectedCardId != -1)
			{
				this.SetSelectedCardState(false);
			}
			this.SelectedCardId = cardId;
			this.SelectedFrom = fromType;
			this.SetSelectedCardState(true);
		}

		// Token: 0x06037D13 RID: 228627 RVA: 0x00E243D0 File Offset: 0x00E225D0
		public void CancelSelectedCard()
		{
			if (this.SelectedCardId != -1)
			{
				this.SetSelectedCardState(false);
			}
			this.SelectedCardId = -1;
			this.SelectedFrom = EPhantomArenaCardClickFromType.None;
		}

		// Token: 0x06037D14 RID: 228628 RVA: 0x00E243F0 File Offset: 0x00E225F0
		private void SetSelectedCardState(bool value)
		{
			if (this.SelectedFrom == EPhantomArenaCardClickFromType.OwnHand)
			{
				PhantomArenaHandCardProxy cardProxy = this.OwnArea.HandArea.GetCardProxy(this.SelectedCardId);
				if (cardProxy != null)
				{
					cardProxy.SetCardSelectedState(value);
				}
				return;
			}
			if (this.SelectedFrom == EPhantomArenaCardClickFromType.OwnFunctional)
			{
				PhantomArenaAreaProxyBase cardProxyByCardId = this.OwnArea.FunctionalArea.GetCardProxyByCardId(this.SelectedCardId);
				if (cardProxyByCardId != null)
				{
					cardProxyByCardId.SetCardSelectedState(value);
				}
				return;
			}
			if (this.SelectedFrom == EPhantomArenaCardClickFromType.OpponentFunctional)
			{
				OpponentFunctionAreaProxy cardProxyByCardId2 = this.OpponentArea.FunctionalArea.GetCardProxyByCardId(this.SelectedCardId);
				if (cardProxyByCardId2 != null)
				{
					cardProxyByCardId2.SetCardSelectedState(value);
				}
			}
		}

		// Token: 0x06037D15 RID: 228629 RVA: 0x00E24480 File Offset: 0x00E22680
		public void PlayRoundOverEffect()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "播放回合结束扫光效果", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.View.SetRoundEffectActive(true);
		}

		// Token: 0x06037D16 RID: 228630 RVA: 0x00E244B8 File Offset: 0x00E226B8
		public void HideRoundOverEffect()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "隐藏回合结束扫光效果", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.View.SetRoundEffectActive(false);
		}

		// Token: 0x06037D17 RID: 228631 RVA: 0x00E244F0 File Offset: 0x00E226F0
		public bool CheckRepeatCondition()
		{
			PhantomArenaOwnData ownData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData;
			return (ownData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleCostPoint) != 0 || ownData.HasFourCostInHand()) && ownData.GetHandCardIdList().Count != 0;
		}

		// Token: 0x06037D18 RID: 228632 RVA: 0x00E2452B File Offset: 0x00E2272B
		public UUIItem GetOwnCardLibraryItem()
		{
			return this.View.GetOwnCardLibraryItem();
		}

		// Token: 0x06037D19 RID: 228633 RVA: 0x00E24538 File Offset: 0x00E22738
		public void ShowTimeStart()
		{
			this.UnRegisterCantDragReason(EPhantomArenaCantDragReason.EndTime);
			this.ServerActionQueue.PauseAction();
			this.RegisterCantDragReason(EPhantomArenaCantDragReason.NotInOwnTime);
			int round = ModelBase<PhantomArenaBattleModel>.Instance.Round;
			int replaceNum = ModelBase<PhantomArenaBattleModel>.Instance.ReplaceCardData.ReplaceNum;
			if (round == 1 && replaceNum != 0)
			{
				this.ProcessManager.SetState(EPlayingCardProcessState.OwnChangeCard);
				return;
			}
			this.ProcessManager.SetState(EPlayingCardProcessState.BothDrawCard);
		}

		// Token: 0x06037D1A RID: 228634 RVA: 0x00E24597 File Offset: 0x00E22797
		public void ShowOwnChangeCard()
		{
			PhantomArenaBattleController.OpenPhantomArenaChangeCardView();
		}

		// Token: 0x06037D1B RID: 228635 RVA: 0x00E245A0 File Offset: 0x00E227A0
		public UniTask ShowBothDrawCard()
		{
			PhantomArenaBattleProxy.<ShowBothDrawCard>d__50 <ShowBothDrawCard>d__;
			<ShowBothDrawCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowBothDrawCard>d__.<>4__this = this;
			<ShowBothDrawCard>d__.<>1__state = -1;
			<ShowBothDrawCard>d__.<>t__builder.Start<PhantomArenaBattleProxy.<ShowBothDrawCard>d__50>(ref <ShowBothDrawCard>d__);
			return <ShowBothDrawCard>d__.<>t__builder.Task;
		}

		// Token: 0x06037D1C RID: 228636 RVA: 0x00E245E3 File Offset: 0x00E227E3
		public void ShowOpponentStartPanel()
		{
			PhantomArenaBattleController.OpenPhantomArenaStartView(new PhantomArenaStartViewData
			{
				ContentTextId = "PhantomBattle_1044",
				IsOwn = false,
				Callback = delegate
				{
					this.ProcessManager.SetState(EPlayingCardProcessState.OpponentPlaying);
				}
			});
		}

		// Token: 0x06037D1D RID: 228637 RVA: 0x00E24614 File Offset: 0x00E22814
		public UniTask StartAiOperation()
		{
			PhantomArenaBattleProxy.<StartAiOperation>d__52 <StartAiOperation>d__;
			<StartAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartAiOperation>d__.<>4__this = this;
			<StartAiOperation>d__.<>1__state = -1;
			<StartAiOperation>d__.<>t__builder.Start<PhantomArenaBattleProxy.<StartAiOperation>d__52>(ref <StartAiOperation>d__);
			return <StartAiOperation>d__.<>t__builder.Task;
		}

		// Token: 0x06037D1E RID: 228638 RVA: 0x00E24657 File Offset: 0x00E22857
		public void ShowGameOver()
		{
			PhantomArenaBattleController.TriggerPhantomBattleBoardSettle();
			this.ServerActionQueue.ResumeAction().Forget();
		}

		// Token: 0x06037D1F RID: 228639 RVA: 0x00E2466E File Offset: 0x00E2286E
		public void ShowOwnStartPanel()
		{
			PhantomArenaBattleController.OpenPhantomArenaStartView(new PhantomArenaStartViewData
			{
				ContentTextId = "PhantomBattle_1045",
				IsOwn = true,
				Callback = delegate
				{
					this.ProcessManager.SetState(EPlayingCardProcessState.ShowOwnCoreCard);
				}
			});
		}

		// Token: 0x06037D20 RID: 228640 RVA: 0x00E246A0 File Offset: 0x00E228A0
		public void ShowOwnCoreCard()
		{
			int round = ModelBase<PhantomArenaBattleModel>.Instance.Round;
			PhantomArenaOwnData ownData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData;
			if (round == 1 && ownData.TaskData != null)
			{
				PhantomArenaBattleController.OpenPhantomArenaCoreCardView(delegate
				{
					this.OwnArea.RolePanel.ActiveIsFourCostShowInFirstTime();
					this.ProcessManager.SetState(EPlayingCardProcessState.OwnPlaying);
				});
				return;
			}
			if (ownData.CanShowFourCostView)
			{
				PhantomArenaBattleController.OpenPhantomArenaCoreCardView(delegate
				{
					ownData.CanShowFourCostView = false;
					this.OwnArea.HandArea.AddCard(new List<int>
					{
						ownData.CoreCardId
					}).Forget();
					this.ProcessManager.SetState(EPlayingCardProcessState.OwnPlaying);
				});
				return;
			}
			this.ProcessManager.SetState(EPlayingCardProcessState.OwnPlaying);
		}

		// Token: 0x06037D21 RID: 228641 RVA: 0x00E24722 File Offset: 0x00E22922
		public void ShowOwnPlaying()
		{
			this.ServerActionQueue.ResumeAction().Forget();
			this.RoundOverCheck.StartCheck();
			this.View.SetTimeEndBtnInteractive(true);
			this.UnRegisterCantDragReason(EPhantomArenaCantDragReason.NotInOwnTime);
		}

		// Token: 0x06037D22 RID: 228642 RVA: 0x00E24754 File Offset: 0x00E22954
		public UniTask RoundOver()
		{
			PhantomArenaBattleProxy.<RoundOver>d__57 <RoundOver>d__;
			<RoundOver>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RoundOver>d__.<>4__this = this;
			<RoundOver>d__.<>1__state = -1;
			<RoundOver>d__.<>t__builder.Start<PhantomArenaBattleProxy.<RoundOver>d__57>(ref <RoundOver>d__);
			return <RoundOver>d__.<>t__builder.Task;
		}

		// Token: 0x06037D23 RID: 228643 RVA: 0x00E24797 File Offset: 0x00E22997
		public void JumpLoading()
		{
			PhantomArenaBattleController.OpenPhantomArenaBattleLoading();
		}

		// Token: 0x06037D24 RID: 228644 RVA: 0x00E2479E File Offset: 0x00E2299E
		public void HideLayoutClick()
		{
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.None);
			this.OwnArea.HideCardList();
		}

		// Token: 0x06037D25 RID: 228645 RVA: 0x00E247B2 File Offset: 0x00E229B2
		public void CloseClick()
		{
			if (this.InCantDragStateSet.Contains(EPhantomArenaCantDragReason.EndTime))
			{
				return;
			}
			ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(delegate
			{
				this.GuideManager.TryExitCurrentGuide();
				ModelBase<PhantomArenaBattleModel>.Instance.OnClickExitButtonConfirm();
			}, null, true);
		}

		// Token: 0x06037D26 RID: 228646 RVA: 0x00E247DB File Offset: 0x00E229DB
		public void HelpClick()
		{
			if (this.InCantDragStateSet.Contains(EPhantomArenaCantDragReason.EndTime))
			{
				return;
			}
			if (ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				ControllerBase<TutorialController>.Instance.OpenExclusiveTutorial(EExclusiveTutorialType.PhantomArena);
				return;
			}
			ControllerBase<TutorialController>.Instance.OpenExclusiveTutorial(EExclusiveTutorialType.PhantomArenaNew);
		}

		// Token: 0x06037D27 RID: 228647 RVA: 0x00E24814 File Offset: 0x00E22A14
		public void TimeEndClick()
		{
			if (this.InCantDragState())
			{
				return;
			}
			if (!this.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbEndTurn, Array.Empty<object>()))
			{
				return;
			}
			if (this.ServerActionQueue.InAction())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1189", Array.Empty<object>());
				return;
			}
			Action action = delegate()
			{
				this.GuideManager.FinishCurrentGuide();
				this.ProcessManager.SetState(EPlayingCardProcessState.TimeEnd);
			};
			if (!this.RoundOverCheck.HasAnyOperation && ModelBase<PhantomArenaBattleModel>.Instance.IsNeedShowTimeEndConfirm)
			{
				ControllerBase<PhantomArenaBattleController>.Instance.ShowTimeEndConfirm(action);
				return;
			}
			action();
		}

		// Token: 0x06037D28 RID: 228648 RVA: 0x00E24898 File Offset: 0x00E22A98
		public void OnOwnBattleStatusChange(IReadOnlyList<PhantomBattleRoleStatus> statusList)
		{
			foreach (PhantomBattleRoleStatus phantomBattleRoleStatus in statusList)
			{
				if (phantomBattleRoleStatus == PhantomBattleRoleStatus.PhantomBattleLife || phantomBattleRoleStatus == PhantomBattleRoleStatus.PhantomBattleMaxLife)
				{
					this.OwnArea.RolePanel.RefreshLifeNumWithEffect();
				}
				else if (phantomBattleRoleStatus == PhantomBattleRoleStatus.PhantomBattleCostPoint)
				{
					this.RoundOverCheck.RepeatCheck();
					this.CardRecycle.RefreshCostNum();
					this.OwnArea.HandArea.RefreshHandCardSequence();
					this.OwnArea.RolePanel.RefreshSkillEffect();
				}
			}
		}

		// Token: 0x06037D29 RID: 228649 RVA: 0x00E2492C File Offset: 0x00E22B2C
		public void OnOpponentBattleStatusChange(IReadOnlyList<PhantomBattleRoleStatus> statusList)
		{
			foreach (PhantomBattleRoleStatus phantomBattleRoleStatus in statusList)
			{
				if (phantomBattleRoleStatus == PhantomBattleRoleStatus.PhantomBattleLife || phantomBattleRoleStatus == PhantomBattleRoleStatus.PhantomBattleMaxLife)
				{
					this.OpponentArea.RefreshLifeNumWithEffect();
				}
			}
		}

		// Token: 0x06037D2A RID: 228650 RVA: 0x00E24980 File Offset: 0x00E22B80
		public void OnOwnCardLibraryChange()
		{
			this.View.RefreshOwnCardLibraryNum();
		}

		// Token: 0x06037D2B RID: 228651 RVA: 0x00E24990 File Offset: 0x00E22B90
		public void OnOpponentHandCardChange()
		{
			int handCardNum = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.HandCardNum;
			this.OpponentArea.HandArea.RefreshHandCardNum(handCardNum).Forget();
		}

		// Token: 0x06037D2C RID: 228652 RVA: 0x00E249C3 File Offset: 0x00E22BC3
		public void OnOpponentCardLibraryChange()
		{
			this.View.RefreshOpponentCardLibraryNum();
		}

		// Token: 0x06037D2D RID: 228653 RVA: 0x00E249D0 File Offset: 0x00E22BD0
		public void OnOwnHandCardAdd(IReadOnlyList<int> addCardList)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "刷新手牌", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OwnArea.HandArea.AddCard(addCardList.ToList<int>()).Forget();
		}

		// Token: 0x06037D2E RID: 228654 RVA: 0x00E24A17 File Offset: 0x00E22C17
		public void OnTriggerSkillEffect()
		{
			this.ServerActionQueue.PushSkillEffectAction();
		}

		// Token: 0x06037D2F RID: 228655 RVA: 0x00E24A24 File Offset: 0x00E22C24
		public void OnNotifyCardTaskData(bool isOwn)
		{
			if (isOwn)
			{
				this.OwnArea.RolePanel.RefreshTask();
				return;
			}
			this.OpponentArea.RolePanel.RefreshTask();
		}

		// Token: 0x06037D30 RID: 228656 RVA: 0x00E24A4A File Offset: 0x00E22C4A
		public void OnOwnHandCardRemove(IReadOnlyList<int> discardIdList)
		{
			this.OwnArea.HandArea.DiscardCard(this.View.GetOwnCardLibraryItem(), discardIdList.ToList<int>()).Forget();
		}

		// Token: 0x06037D31 RID: 228657 RVA: 0x00E24A74 File Offset: 0x00E22C74
		public void OnCardAttrRefresh(int cardId)
		{
			if (this.TipsItem.IsInActive && this.TipsItem.GetCardId() == cardId)
			{
				this.TipsItem.RefreshContent();
			}
			this.OpponentArea.FunctionalArea.RefreshBattleCard(cardId);
			this.OwnArea.FunctionalArea.RefreshBattleCard(cardId);
			PhantomArenaFieldData fieldData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.FieldData;
			int? num;
			if (fieldData == null)
			{
				num = null;
			}
			else
			{
				PhantomCardData cardData = fieldData.CardData;
				num = ((cardData != null) ? new int?(cardData.CardId) : null);
			}
			int? num2 = num;
			if (cardId == num2.GetValueOrDefault() & num2 != null)
			{
				this.OwnArea.RefreshFiledArea().Forget();
				return;
			}
			PhantomArenaFieldData fieldData2 = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.FieldData;
			int? num3;
			if (fieldData2 == null)
			{
				num3 = null;
			}
			else
			{
				PhantomCardData cardData2 = fieldData2.CardData;
				num3 = ((cardData2 != null) ? new int?(cardData2.CardId) : null);
			}
			num2 = num3;
			if (cardId == num2.GetValueOrDefault() & num2 != null)
			{
				this.OpponentArea.RefreshFiledArea().Forget();
			}
		}

		// Token: 0x06037D32 RID: 228658 RVA: 0x00E24B8C File Offset: 0x00E22D8C
		public void OnCardFactorsRefresh(int cardId)
		{
			if (this.TipsItem.IsInActive && this.TipsItem.GetCardId() == cardId)
			{
				this.TipsItem.RefreshContent();
			}
			this.OpponentArea.FunctionalArea.RefreshBattleCard(cardId);
			this.OwnArea.FunctionalArea.RefreshBattleCard(cardId);
		}

		// Token: 0x06037D33 RID: 228659 RVA: 0x00E24BE4 File Offset: 0x00E22DE4
		public void OnNotifyBattleCardChange(bool isOwn, int indexA, int indexB)
		{
			if (isOwn)
			{
				this.OwnArea.FunctionalArea.RefreshBattleCard(indexA);
				this.OwnArea.FunctionalArea.RefreshBattleCard(indexB);
				return;
			}
			this.OpponentArea.FunctionalArea.RefreshBattleCard(indexA);
			this.OpponentArea.FunctionalArea.RefreshBattleCard(indexB);
		}

		// Token: 0x06037D34 RID: 228660 RVA: 0x00E24C39 File Offset: 0x00E22E39
		public void OnOwnBattleAttrChange(IReadOnlyList<PhantomBattleCardAttr> attrList)
		{
			if (attrList.Contains(PhantomBattleCardAttr.Defence))
			{
				this.OwnArea.RolePanel.RefreshShieldNum();
			}
		}

		// Token: 0x06037D35 RID: 228661 RVA: 0x00E24C54 File Offset: 0x00E22E54
		public void OnOpponentBattleAttrChange(IReadOnlyList<PhantomBattleCardAttr> attrList)
		{
			if (attrList.Contains(PhantomBattleCardAttr.Defence))
			{
				this.OpponentArea.RolePanel.RefreshShieldNum();
			}
		}

		// Token: 0x06037D36 RID: 228662 RVA: 0x00E24C6F File Offset: 0x00E22E6F
		public void OnRefreshRound()
		{
			this.View.RefreshRoundNum();
		}

		// Token: 0x06037D37 RID: 228663 RVA: 0x00E24C7C File Offset: 0x00E22E7C
		public void OnRefreshBattleCardNum()
		{
			this.View.RefreshLimitText();
		}

		// Token: 0x06037D38 RID: 228664 RVA: 0x00E24C8C File Offset: 0x00E22E8C
		public void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
		{
			if (last == EInputControllerMainType.Gamepad)
			{
				this.GamepadLogic.ResetGamepadOperation();
			}
			bool isGamepad = now == EInputControllerMainType.Gamepad;
			this.OpponentArea.SwitchFieldState(isGamepad);
			this.OpponentArea.RolePanel.RefreshSkillState();
			this.OwnArea.SwitchFieldState(isGamepad);
		}

		// Token: 0x06037D39 RID: 228665 RVA: 0x00E24CD5 File Offset: 0x00E22ED5
		public void OnRefreshHandCardState()
		{
			this.OwnArea.HandArea.RefreshHandCardSequence();
		}

		// Token: 0x06037D3A RID: 228666 RVA: 0x00E24CE7 File Offset: 0x00E22EE7
		public void OnPhantomBattleBoardSettleNotify()
		{
			if (this.ProcessManager.IsNotInOwnPlaying)
			{
				return;
			}
			PhantomArenaBattleController.TriggerPhantomBattleBoardSettle();
		}

		// Token: 0x06037D3B RID: 228667 RVA: 0x00E24CFC File Offset: 0x00E22EFC
		public void OnOpponentSealFieldChange(int remainRound)
		{
			this.OpponentArea.RefreshFiledArea().Forget();
		}

		// Token: 0x06037D3C RID: 228668 RVA: 0x00E24D0E File Offset: 0x00E22F0E
		public void OnOwnSealRecycleChange(int remainRound)
		{
		}

		// Token: 0x06037D3D RID: 228669 RVA: 0x00E24D10 File Offset: 0x00E22F10
		private void SetTipsActive(EPhantomArenaBattleShowTipsType showTipsType)
		{
			this.TipsItem.SetTipsActive(showTipsType == EPhantomArenaBattleShowTipsType.CardTips);
			this.DetailsTipsItem.SetTipsActive(showTipsType);
			this.SkillTipsItem.SetTipsActive(showTipsType == EPhantomArenaBattleShowTipsType.SkillTips);
		}

		// Token: 0x06037D3E RID: 228670 RVA: 0x00E24D3C File Offset: 0x00E22F3C
		public void HideCardTips()
		{
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.None);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomArenaCardDetailShowHideChange, false);
		}

		// Token: 0x06037D3F RID: 228671 RVA: 0x00E24D56 File Offset: 0x00E22F56
		public void ShowCardTips(PhantomCardData cardData, bool isCardItemShow)
		{
			this.TipsItem.RefreshTips(cardData, isCardItemShow);
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.CardTips);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomArenaCardDetailShowHideChange, true);
		}

		// Token: 0x06037D40 RID: 228672 RVA: 0x00E24D7D File Offset: 0x00E22F7D
		public bool SwitchCardTips(PhantomCardData cardData)
		{
			if (this.TipsItem.IsInActive)
			{
				this.HideCardTips();
				return false;
			}
			this.ShowCardTips(cardData, true);
			return true;
		}

		// Token: 0x06037D41 RID: 228673 RVA: 0x00E24DA0 File Offset: 0x00E22FA0
		public void SwitchFourCostTips(bool isOwn, UUIItem triggerItem)
		{
			EPhantomArenaBattleDetailsTipsShowType ephantomArenaBattleDetailsTipsShowType = isOwn ? EPhantomArenaBattleDetailsTipsShowType.OwnFourCost : EPhantomArenaBattleDetailsTipsShowType.OpponentFourCost;
			if (this.DetailsTipsItem.IsInActive && ephantomArenaBattleDetailsTipsShowType == this.DetailsTipsItem.ShowType)
			{
				this.SetTipsActive(EPhantomArenaBattleShowTipsType.None);
				return;
			}
			EPhantomArenaBattleDetailsPositionType positionType = isOwn ? EPhantomArenaBattleDetailsPositionType.RightBottom : EPhantomArenaBattleDetailsPositionType.LeftTop;
			PhantomArenaBattleDetailsTipsData tipsPositionByTriggerItem = new PhantomArenaBattleDetailsTipsData
			{
				TriggerItem = triggerItem,
				PositionType = positionType,
				ShowType = ephantomArenaBattleDetailsTipsShowType
			};
			PhantomArenaCardTaskData taskData = isOwn ? ModelBase<PhantomArenaBattleModel>.Instance.OwnData.TaskData : ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.TaskData;
			this.DetailsTipsItem.RefreshByTaskData(taskData);
			this.DetailsTipsItem.SetTipsPositionByTriggerItem(tipsPositionByTriggerItem);
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.DetailsTips);
		}

		// Token: 0x06037D42 RID: 228674 RVA: 0x00E24E3E File Offset: 0x00E2303E
		public void ShowSkillTips(IPhantomArenaSkillData data, UUIItem attachItem)
		{
			this.SkillTipsItem.Refresh(data);
			this.SkillTipsItem.SetTipsPosition(attachItem, data.IsOwn);
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.SkillTips);
		}

		// Token: 0x06037D43 RID: 228675 RVA: 0x00E24E65 File Offset: 0x00E23065
		public void HideSkillTips()
		{
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.None);
		}

		// Token: 0x06037D44 RID: 228676 RVA: 0x00E24E70 File Offset: 0x00E23070
		public void ShowFiledTips(PhantomArenaFieldData fieldData, UUIItem triggerItem, bool isGamepad)
		{
			EPhantomArenaBattleDetailsTipsShowType ephantomArenaBattleDetailsTipsShowType = fieldData.IsOwn ? EPhantomArenaBattleDetailsTipsShowType.OwnField : EPhantomArenaBattleDetailsTipsShowType.OpponentField;
			if (this.DetailsTipsItem.IsInActive && ephantomArenaBattleDetailsTipsShowType == this.DetailsTipsItem.ShowType)
			{
				this.SetTipsActive(EPhantomArenaBattleShowTipsType.None);
				return;
			}
			EPhantomArenaBattleDetailsPositionType positionType;
			if (isGamepad)
			{
				positionType = (fieldData.IsOwn ? EPhantomArenaBattleDetailsPositionType.RightBottom : EPhantomArenaBattleDetailsPositionType.LeftTop);
			}
			else
			{
				positionType = (fieldData.IsOwn ? EPhantomArenaBattleDetailsPositionType.LeftBottom : EPhantomArenaBattleDetailsPositionType.RightTop);
			}
			PhantomArenaBattleDetailsTipsData tipsPositionByTriggerItem = new PhantomArenaBattleDetailsTipsData
			{
				TriggerItem = triggerItem,
				PositionType = positionType,
				ShowType = ephantomArenaBattleDetailsTipsShowType
			};
			this.DetailsTipsItem.RefreshByCardData(fieldData.CardData);
			this.DetailsTipsItem.SetTipsPositionByTriggerItem(tipsPositionByTriggerItem);
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.FieldDetailsTips);
		}

		// Token: 0x06037D45 RID: 228677 RVA: 0x00E24F0B File Offset: 0x00E2310B
		public void HideFiledTips()
		{
			this.SetTipsActive(EPhantomArenaBattleShowTipsType.None);
		}

		// Token: 0x06037D46 RID: 228678 RVA: 0x00E24F14 File Offset: 0x00E23114
		public UniTask StartTimeDrawCardTween()
		{
			PhantomArenaBattleProxy.<StartTimeDrawCardTween>d__93 <StartTimeDrawCardTween>d__;
			<StartTimeDrawCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartTimeDrawCardTween>d__.<>4__this = this;
			<StartTimeDrawCardTween>d__.<>1__state = -1;
			<StartTimeDrawCardTween>d__.<>t__builder.Start<PhantomArenaBattleProxy.<StartTimeDrawCardTween>d__93>(ref <StartTimeDrawCardTween>d__);
			return <StartTimeDrawCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x06037D47 RID: 228679 RVA: 0x00E24F58 File Offset: 0x00E23158
		public UniTask EndTimeDiscardCardTween()
		{
			PhantomArenaBattleProxy.<EndTimeDiscardCardTween>d__94 <EndTimeDiscardCardTween>d__;
			<EndTimeDiscardCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndTimeDiscardCardTween>d__.<>4__this = this;
			<EndTimeDiscardCardTween>d__.<>1__state = -1;
			<EndTimeDiscardCardTween>d__.<>t__builder.Start<PhantomArenaBattleProxy.<EndTimeDiscardCardTween>d__94>(ref <EndTimeDiscardCardTween>d__);
			return <EndTimeDiscardCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x17008FD1 RID: 36817
		// (get) Token: 0x06037D48 RID: 228680 RVA: 0x00E24F9B File Offset: 0x00E2319B
		public bool IsInPanelInteract
		{
			get
			{
				return this.InPanelInteractType > EPhantomArenaBattlePanelInteractType.MainView;
			}
		}

		// Token: 0x06037D49 RID: 228681 RVA: 0x00E24FA6 File Offset: 0x00E231A6
		public void SetInPanelInteractType(EPhantomArenaBattlePanelInteractType type)
		{
			this.InPanelInteractType = type;
			this.View.RefreshUiBlurBehaviour();
		}

		// Token: 0x06037D4A RID: 228682 RVA: 0x00E24FBA File Offset: 0x00E231BA
		public void SetIsMainInVisible(bool value)
		{
			this.IsMainInVisibleInternal = value;
			this.View.RefreshUiBlurBehaviour();
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirtyByGroupItem(this.View.GetRootItem());
		}

		// Token: 0x17008FD2 RID: 36818
		// (get) Token: 0x06037D4B RID: 228683 RVA: 0x00E24FE3 File Offset: 0x00E231E3
		public bool IsMainInVisible
		{
			get
			{
				return this.IsMainInVisibleInternal;
			}
		}

		// Token: 0x06037D4C RID: 228684 RVA: 0x00E24FEC File Offset: 0x00E231EC
		public UniTask ShowNpcFieldSealEffect()
		{
			PhantomArenaBattleProxy.<ShowNpcFieldSealEffect>d__101 <ShowNpcFieldSealEffect>d__;
			<ShowNpcFieldSealEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNpcFieldSealEffect>d__.<>4__this = this;
			<ShowNpcFieldSealEffect>d__.<>1__state = -1;
			<ShowNpcFieldSealEffect>d__.<>t__builder.Start<PhantomArenaBattleProxy.<ShowNpcFieldSealEffect>d__101>(ref <ShowNpcFieldSealEffect>d__);
			return <ShowNpcFieldSealEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037D4D RID: 228685 RVA: 0x00E25030 File Offset: 0x00E23230
		public UniTask ShowNpcFieldUnlockEffect()
		{
			PhantomArenaBattleProxy.<ShowNpcFieldUnlockEffect>d__102 <ShowNpcFieldUnlockEffect>d__;
			<ShowNpcFieldUnlockEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNpcFieldUnlockEffect>d__.<>4__this = this;
			<ShowNpcFieldUnlockEffect>d__.<>1__state = -1;
			<ShowNpcFieldUnlockEffect>d__.<>t__builder.Start<PhantomArenaBattleProxy.<ShowNpcFieldUnlockEffect>d__102>(ref <ShowNpcFieldUnlockEffect>d__);
			return <ShowNpcFieldUnlockEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037D4E RID: 228686 RVA: 0x00E25074 File Offset: 0x00E23274
		public UniTask ShowOwnFieldSealEffect()
		{
			PhantomArenaBattleProxy.<ShowOwnFieldSealEffect>d__103 <ShowOwnFieldSealEffect>d__;
			<ShowOwnFieldSealEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowOwnFieldSealEffect>d__.<>4__this = this;
			<ShowOwnFieldSealEffect>d__.<>1__state = -1;
			<ShowOwnFieldSealEffect>d__.<>t__builder.Start<PhantomArenaBattleProxy.<ShowOwnFieldSealEffect>d__103>(ref <ShowOwnFieldSealEffect>d__);
			return <ShowOwnFieldSealEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037D4F RID: 228687 RVA: 0x00E250B8 File Offset: 0x00E232B8
		public UniTask ShowOwnFieldUnlockEffect()
		{
			PhantomArenaBattleProxy.<ShowOwnFieldUnlockEffect>d__104 <ShowOwnFieldUnlockEffect>d__;
			<ShowOwnFieldUnlockEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowOwnFieldUnlockEffect>d__.<>4__this = this;
			<ShowOwnFieldUnlockEffect>d__.<>1__state = -1;
			<ShowOwnFieldUnlockEffect>d__.<>t__builder.Start<PhantomArenaBattleProxy.<ShowOwnFieldUnlockEffect>d__104>(ref <ShowOwnFieldUnlockEffect>d__);
			return <ShowOwnFieldUnlockEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037D50 RID: 228688 RVA: 0x00E250FC File Offset: 0x00E232FC
		public void FieldInteractClick(PhantomArenaFieldData fieldData, PhantomArenaFieldItem fieldItem)
		{
			PhantomCardData cardData = fieldData.CardData;
			if (cardData != null && cardData.IsNpcCard)
			{
				return;
			}
			if (this.InCantDragState())
			{
				return;
			}
			if (!this.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbUseFieldCardSkill, Array.Empty<object>()))
			{
				return;
			}
			if (fieldData.IsInSeal)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1133", Array.Empty<object>());
				return;
			}
			if (!fieldData.HasClickActiveSkill)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1132", Array.Empty<object>());
				return;
			}
			if (!fieldData.IsCanInteractive)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "使用领域";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("领域", fieldData.CardConfigId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnHandleFiledClick(fieldData, fieldItem).Forget();
		}

		// Token: 0x06037D51 RID: 228689 RVA: 0x00E251C0 File Offset: 0x00E233C0
		public void FieldFinishSkillInteract(PhantomArenaFieldData fieldData)
		{
			PhantomArenaGuideCardSkillData phantomArenaGuideCardSkillData = new PhantomArenaGuideCardSkillData
			{
				CardId = fieldData.CardData.CardId
			};
			this.GuideManager.TryFinishGuideByType(EBvbPlayerOperationType.BvbUseFieldCardSkill, new object[]
			{
				EPhantomArenaSkillInteractExecuteResult.Success,
				phantomArenaGuideCardSkillData
			});
		}

		// Token: 0x06037D52 RID: 228690 RVA: 0x00E25204 File Offset: 0x00E23404
		protected UniTask OnHandleFiledClick(PhantomArenaFieldData fieldData, PhantomArenaFieldItem fieldItem)
		{
			PhantomArenaBattleProxy.<OnHandleFiledClick>d__107 <OnHandleFiledClick>d__;
			<OnHandleFiledClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHandleFiledClick>d__.<>4__this = this;
			<OnHandleFiledClick>d__.fieldData = fieldData;
			<OnHandleFiledClick>d__.fieldItem = fieldItem;
			<OnHandleFiledClick>d__.<>1__state = -1;
			<OnHandleFiledClick>d__.<>t__builder.Start<PhantomArenaBattleProxy.<OnHandleFiledClick>d__107>(ref <OnHandleFiledClick>d__);
			return <OnHandleFiledClick>d__.<>t__builder.Task;
		}

		// Token: 0x06037D53 RID: 228691 RVA: 0x00E25257 File Offset: 0x00E23457
		public void FieldPointerEnter(PhantomArenaFieldData fieldData, UUIItem attachItem, bool isGamepad)
		{
			this.ShowFiledTips(fieldData, attachItem, isGamepad);
		}

		// Token: 0x06037D54 RID: 228692 RVA: 0x00E25262 File Offset: 0x00E23462
		public void FieldPointerExit()
		{
			this.HideFiledTips();
		}

		// Token: 0x0401FF5D RID: 130909
		private PhantomArenaBattleView View;

		// Token: 0x0401FF5E RID: 130910
		private int SelectedCardId = -1;

		// Token: 0x0401FF5F RID: 130911
		private EPhantomArenaCardClickFromType SelectedFrom;

		// Token: 0x0401FF60 RID: 130912
		public PopupCaptionItem CaptionItem;

		// Token: 0x0401FF61 RID: 130913
		public PhantomArenaOwnArea OwnArea;

		// Token: 0x0401FF62 RID: 130914
		public OpponentArea OpponentArea;

		// Token: 0x0401FF63 RID: 130915
		public PhantomArenaCardRecycle CardRecycle;

		// Token: 0x0401FF64 RID: 130916
		public PhantomArenaDiscardCardPanel DiscardPanel;

		// Token: 0x0401FF65 RID: 130917
		public PhantomArenaChooseCardPanel ChooseCardPanel;

		// Token: 0x0401FF66 RID: 130918
		public PhantomArenaSkillTriggerMask SkillTriggerMask;

		// Token: 0x0401FF67 RID: 130919
		public PhantomArenaCanvasManager CanvasManager = new PhantomArenaCanvasManager();

		// Token: 0x0401FF68 RID: 130920
		public PhantomArenaProcessManager ProcessManager;

		// Token: 0x0401FF69 RID: 130921
		public PhantomArenaBuffEffectManager BuffEffectManager;

		// Token: 0x0401FF6A RID: 130922
		public PhantomArenaBattleGuideManager GuideManager;

		// Token: 0x0401FF6B RID: 130923
		public PhantomArenaBattleDialog DialogManager = new PhantomArenaBattleDialog();

		// Token: 0x0401FF6C RID: 130924
		public PhantomArenaRoundOverCheck RoundOverCheck;

		// Token: 0x0401FF6D RID: 130925
		public PhantomArenaBattleViewGamepadLogic GamepadLogic;

		// Token: 0x0401FF6E RID: 130926
		public PhantomArenaBattleServerActionQueue ServerActionQueue;

		// Token: 0x0401FF6F RID: 130927
		public PhantomArenaBanButtonFunctionModule BanButtonClickModule = new PhantomArenaBanButtonFunctionModule();

		// Token: 0x0401FF70 RID: 130928
		protected HashSet<EPhantomArenaCantDragReason> InCantDragStateSet = new HashSet<EPhantomArenaCantDragReason>();

		// Token: 0x0401FF71 RID: 130929
		public PhantomArenaBattleTips TipsItem;

		// Token: 0x0401FF72 RID: 130930
		public PhantomArenaBattleDetailsTips DetailsTipsItem;

		// Token: 0x0401FF73 RID: 130931
		public PhantomArenaBattleSkillTips SkillTipsItem;

		// Token: 0x0401FF74 RID: 130932
		public EPhantomArenaBattlePanelInteractType InPanelInteractType;

		// Token: 0x0401FF75 RID: 130933
		private bool IsMainInVisibleInternal;
	}
}
