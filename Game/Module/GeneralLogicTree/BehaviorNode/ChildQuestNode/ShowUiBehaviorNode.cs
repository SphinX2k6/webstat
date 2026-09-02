using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF2 RID: 23794
	[NullableContext(1)]
	[Nullable(0)]
	public class ShowUiBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFBB RID: 245691 RVA: 0x00F360E9 File Offset: 0x00F342E9
		public ShowUiBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFBC RID: 245692 RVA: 0x00F36100 File Offset: 0x00F34300
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IShowUiCondition showUiCondition = childQuestBtNode.Condition as IShowUiCondition;
			if (showUiCondition == null)
			{
				return false;
			}
			this.UiType = showUiCondition.UiType;
			this.KeepUiOpen = showUiCondition.KeepUiOpen.GetValueOrDefault();
			return true;
		}

		// Token: 0x0603BFBD RID: 245693 RVA: 0x00F36156 File Offset: 0x00F34356
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.UiType = null;
			this.KeepUiOpen = false;
		}

		// Token: 0x0603BFBE RID: 245694 RVA: 0x00F3616C File Offset: 0x00F3436C
		protected override void OnNodeActive()
		{
			base.OnNodeActive();
			if (this.KeepUiOpen && this.UiType.Type == EShowUiType.RogueAbilitySelect)
			{
				ControllerBase<RoguelikeController>.Instance.OpenBuffSelectViewByIdAsync(((IRogueAbilitySelect)this.UiType).BindId);
			}
		}

		// Token: 0x0603BFBF RID: 245695 RVA: 0x00F361A8 File Offset: 0x00F343A8
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			if (this.UiType.Type == EShowUiType.All)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnViewDone));
			}
			if (this.UiType.Type == EShowUiType.CiacconaAvgBoard)
			{
				Singleton<EventSystem>.Instance.Add<int, int>(EEventName.NotifyBtCiacconaChapterFinish, new Action<int, int>(this.OnCiacconaChapterFinish));
			}
			if (this.UiType.Type == EShowUiType.ItemObtain)
			{
				Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnItemObtainViewClose));
				Singleton<EventSystem>.Instance.Add(EEventName.OnShowRewardView, new Action(this.OnRewardViewShow));
			}
		}

		// Token: 0x0603BFC0 RID: 245696 RVA: 0x00F36254 File Offset: 0x00F34454
		protected override void RemoveEventsOnChildQuestEnd()
		{
			base.RemoveEventsOnChildQuestEnd();
			if (this.UiType.Type == EShowUiType.All)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnViewDone));
			}
			if (this.UiType.Type == EShowUiType.CiacconaAvgBoard)
			{
				Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.NotifyBtCiacconaChapterFinish, new Action<int, int>(this.OnCiacconaChapterFinish));
			}
			if (this.UiType.Type == EShowUiType.ItemObtain)
			{
				Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnItemObtainViewClose));
				Singleton<EventSystem>.Instance.Remove(EEventName.OnShowRewardView, new Action(this.OnRewardViewShow));
				this.ItemIdsSnapshot = new List<int>();
			}
		}

		// Token: 0x0603BFC1 RID: 245697 RVA: 0x00F3630A File Offset: 0x00F3450A
		private void OnViewDone()
		{
			this.SubmitNode(null);
		}

		// Token: 0x0603BFC2 RID: 245698 RVA: 0x00F36314 File Offset: 0x00F34514
		private void OnCiacconaChapterFinish(int chapterId, int subEndingId)
		{
			int valueOrDefault = ((ICiacconaAvgBoard)this.UiType).EndingId.GetValueOrDefault();
			if (subEndingId == valueOrDefault || valueOrDefault == 0)
			{
				this.SubmitNode(null);
			}
		}

		// Token: 0x0603BFC3 RID: 245699 RVA: 0x00F36348 File Offset: 0x00F34548
		private void OnRewardViewShow()
		{
			ItemRewardModel instance = ModelBase<ItemRewardModel>.Instance;
			RewardData<IRewardInfo> rewardData = (instance != null) ? instance.GetCurrentRewardData() : null;
			List<RewardItemData> source = ((rewardData != null) ? rewardData.GetItemList() : null) ?? new List<RewardItemData>();
			this.ItemIdsSnapshot = (from item in source
			select item.ConfigId).ToList<int>();
		}

		// Token: 0x0603BFC4 RID: 245700 RVA: 0x00F363AC File Offset: 0x00F345AC
		private void OnItemObtainViewClose(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.QuestRewardView)
			{
				return;
			}
			IItemObtain itemObtain = (IItemObtain)this.UiType;
			if (itemObtain.ItemIds != null && itemObtain.ItemIds.Count > 0 && !itemObtain.ItemIds.All((int id) => this.ItemIdsSnapshot.Contains(id)))
			{
				return;
			}
			this.SubmitNode(null);
		}

		// Token: 0x04021B3A RID: 138042
		[Nullable(2)]
		private IShowUi UiType;

		// Token: 0x04021B3B RID: 138043
		private bool KeepUiOpen;

		// Token: 0x04021B3C RID: 138044
		private List<int> ItemIdsSnapshot = new List<int>();
	}
}
