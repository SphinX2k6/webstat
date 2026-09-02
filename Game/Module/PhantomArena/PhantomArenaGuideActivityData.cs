using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x020054A0 RID: 21664
	public class PhantomArenaGuideActivityData : ActivityBaseData
	{
		// Token: 0x060371BC RID: 225724 RVA: 0x00DFD9B4 File Offset: 0x00DFBBB4
		protected override bool GetExDataFinishShowState()
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			using (Dictionary<int, ActivityTask>.ValueCollection.Enumerator enumerator = instance.GetPhantomArenaActivityData(this.PhantomArenaActivityId).GetTaskMap().Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status != ActivityTaskState.ActivityTaskTaken)
					{
						return false;
					}
				}
			}
			PhantomArenaActivityData phantomArenaActivityData = instance.GetPhantomArenaActivityData(this.PhantomArenaActivityId);
			foreach (int rewardId in instance.GetCardRewardConfigList(this.PhantomArenaActivityId))
			{
				if (!phantomArenaActivityData.GetCardRewardInfoById(rewardId).IsRewarded)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060371BD RID: 225725 RVA: 0x00DFDA88 File Offset: 0x00DFBC88
		public override bool GetExDataRedPointShowState()
		{
			return ModelBase<ActivityModel>.Instance.IsActivityOpen(this.PhantomArenaActivityId) && ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityRedDot(this.PhantomArenaActivityId);
		}

		// Token: 0x060371BE RID: 225726 RVA: 0x00DFDAB0 File Offset: 0x00DFBCB0
		[NullableContext(1)]
		protected override void PhraseEx(ActivityData data)
		{
			PhantomBattleGuideActivity phantomBattleGuideActivity = data.PhantomBattleGuideActivity;
			if (phantomBattleGuideActivity == null)
			{
				return;
			}
			this.QuestId = phantomBattleGuideActivity.QuestId;
			this.DropId = phantomBattleGuideActivity.DropId;
			this.TargetNum = phantomBattleGuideActivity.RewardTotalNum;
			this.IsReceiveReward = phantomBattleGuideActivity.SendReward;
			this.PhantomArenaActivityId = phantomBattleGuideActivity.RecordActId;
		}

		// Token: 0x060371BF RID: 225727 RVA: 0x00DFDB04 File Offset: 0x00DFBD04
		public void UpdateReceiveState(bool isReceive)
		{
			this.IsReceiveReward = isReceive;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x060371C0 RID: 225728 RVA: 0x00DFDB23 File Offset: 0x00DFBD23
		public int GetQuestId()
		{
			return this.QuestId;
		}

		// Token: 0x060371C1 RID: 225729 RVA: 0x00DFDB2B File Offset: 0x00DFBD2B
		public int GetDropId()
		{
			return this.DropId;
		}

		// Token: 0x060371C2 RID: 225730 RVA: 0x00DFDB33 File Offset: 0x00DFBD33
		public int GetTargetNum()
		{
			return this.TargetNum;
		}

		// Token: 0x060371C3 RID: 225731 RVA: 0x00DFDB3B File Offset: 0x00DFBD3B
		public bool GetIsReceiveReward()
		{
			return this.IsReceiveReward;
		}

		// Token: 0x060371C4 RID: 225732 RVA: 0x00DFDB43 File Offset: 0x00DFBD43
		public int GetPhantomArenaActivityId()
		{
			return this.PhantomArenaActivityId;
		}

		// Token: 0x0401FBCC RID: 129996
		private int QuestId;

		// Token: 0x0401FBCD RID: 129997
		private int DropId;

		// Token: 0x0401FBCE RID: 129998
		private int TargetNum;

		// Token: 0x0401FBCF RID: 129999
		private bool IsReceiveReward;

		// Token: 0x0401FBD0 RID: 130000
		private int PhantomArenaActivityId;
	}
}
