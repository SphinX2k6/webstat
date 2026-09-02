using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x0200676F RID: 26479
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityFunPlayChallengeData : ActivityExData
	{
		// Token: 0x06042016 RID: 270358 RVA: 0x010EF74E File Offset: 0x010ED94E
		public ActivityFunPlayChallengeData(int id) : base(id)
		{
		}

		// Token: 0x06042017 RID: 270359 RVA: 0x010EF76C File Offset: 0x010ED96C
		public void Phrase(FunPlayChallengeInfo data)
		{
			this.ChallengeId = data.ChallengeId;
			this.Config = ConfigBase<ActivityFunPlayConfig>.Instance.GetFunPlayActivityChallenge(this.ChallengeId);
			this.UnlockTime = data.UnlockTime / 1000L;
			this.RewardStatus = data.RewardStatus;
			this.SharpCommentList.Clear();
			if (data.SharpCommentIds != null)
			{
				foreach (int commentId in data.SharpCommentIds)
				{
					FunPlaySharpComment? funPlaySharpComment = ConfigBase<ActivityFunPlayConfig>.Instance.GetFunPlaySharpComment(commentId);
					if (funPlaySharpComment != null)
					{
						this.SharpCommentList.Add(funPlaySharpComment.Value);
					}
				}
			}
			this.SharpCommentList.Sort((FunPlaySharpComment a, FunPlaySharpComment b) => a.VarPriority - b.VarPriority);
			this.FinishTime = data.FinishTime;
			this.SaveUnlockState();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityFunPlayRedDot, this.ChallengeId);
			base.RefreshActivityRedPoint();
		}

		// Token: 0x06042018 RID: 270360 RVA: 0x010EF888 File Offset: 0x010EDA88
		public void SetIndex(int index)
		{
			this.Index = index;
		}

		// Token: 0x06042019 RID: 270361 RVA: 0x010EF894 File Offset: 0x010EDA94
		public string GetTitle()
		{
			if (this.Config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityFunPlay;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应的趣味活动挑战配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", this.ChallengeId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return string.Empty;
			}
			return this.Config.Value.Title;
		}

		// Token: 0x0604201A RID: 270362 RVA: 0x010EF8FC File Offset: 0x010EDAFC
		public string GetDesc()
		{
			if (this.Config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityFunPlay;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应的趣味活动挑战配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", this.ChallengeId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return string.Empty;
			}
			return this.Config.Value.Desc;
		}

		// Token: 0x0604201B RID: 270363 RVA: 0x010EF964 File Offset: 0x010EDB64
		public string GetTabTitle()
		{
			if (this.Config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityFunPlay;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应的趣味活动挑战配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", this.ChallengeId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return string.Empty;
			}
			return this.Config.Value.TabTitle;
		}

		// Token: 0x0604201C RID: 270364 RVA: 0x010EF9CC File Offset: 0x010EDBCC
		public string GetBackgroundTexturePath()
		{
			if (this.Config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityFunPlay;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应的趣味活动挑战配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", this.ChallengeId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return string.Empty;
			}
			return this.Config.Value.BackGroundTexture;
		}

		// Token: 0x0604201D RID: 270365 RVA: 0x010EFA33 File Offset: 0x010EDC33
		public bool GetIsUnlock()
		{
			return Singleton<TimeUtil>.Instance.GetServerTime() >= (double)this.UnlockTime;
		}

		// Token: 0x0604201E RID: 270366 RVA: 0x010EFA4C File Offset: 0x010EDC4C
		public string GetLeftTimeText()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double remainTime = Math.Max((double)this.UnlockTime - serverTime, 1.0);
			return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(remainTime).CountDownText ?? string.Empty;
		}

		// Token: 0x0604201F RID: 270367 RVA: 0x010EFA95 File Offset: 0x010EDC95
		public bool CheckRewardStatus(FunPlayChallengeRewardStatus status)
		{
			return this.RewardStatus == status;
		}

		// Token: 0x06042020 RID: 270368 RVA: 0x010EFAA0 File Offset: 0x010EDCA0
		public List<FunPlaySharpComment> GetSharpComments()
		{
			return this.SharpCommentList;
		}

		// Token: 0x06042021 RID: 270369 RVA: 0x010EFAA8 File Offset: 0x010EDCA8
		public int GetChallengeId()
		{
			return this.ChallengeId;
		}

		// Token: 0x06042022 RID: 270370 RVA: 0x010EFAB0 File Offset: 0x010EDCB0
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"Month",
			"Day"
		})]
		public ValueTuple<int, int> GetFinishMonthAndDay()
		{
			DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds(this.FinishTime).LocalDateTime;
			return new ValueTuple<int, int>(localDateTime.Month, localDateTime.Day);
		}

		// Token: 0x06042023 RID: 270371 RVA: 0x010EFAE4 File Offset: 0x010EDCE4
		public long GetUnlockTime()
		{
			return this.UnlockTime;
		}

		// Token: 0x06042024 RID: 270372 RVA: 0x010EFAEC File Offset: 0x010EDCEC
		[NullableContext(2)]
		public List<TItem> GetPreviewReward()
		{
			if (this.Config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityFunPlay;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应的趣味活动挑战配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", this.ChallengeId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (this.Config.Value.RewardId == 0)
			{
				return null;
			}
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.Config.Value.RewardId);
		}

		// Token: 0x06042025 RID: 270373 RVA: 0x010EFB70 File Offset: 0x010EDD70
		public bool GetRedPoint()
		{
			return this.GetUnlockRedDot() || this.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayCanReward);
		}

		// Token: 0x06042026 RID: 270374 RVA: 0x010EFB88 File Offset: 0x010EDD88
		private bool GetUnlockRedDot()
		{
			return this.GetIsUnlock() && this.GetLockCache() == 1;
		}

		// Token: 0x06042027 RID: 270375 RVA: 0x010EFBA0 File Offset: 0x010EDDA0
		private void SaveUnlockState()
		{
			bool isUnlock = this.GetIsUnlock();
			int lockCache = this.GetLockCache();
			if (!isUnlock)
			{
				if (lockCache == -1)
				{
					ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, this.ChallengeId, 10, 0, 1);
				}
				return;
			}
			if (lockCache == 1)
			{
				ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, 0, 200, 0, 0);
				base.RefreshActivityRedPoint();
			}
		}

		// Token: 0x06042028 RID: 270376 RVA: 0x010EFBFD File Offset: 0x010EDDFD
		private int GetLockCache()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, -1, this.ChallengeId, 10, 0);
		}

		// Token: 0x06042029 RID: 270377 RVA: 0x010EFC19 File Offset: 0x010EDE19
		public void RefreshUnlockRedDot()
		{
			if (this.GetIsUnlock())
			{
				ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, this.ChallengeId, 10, 0, 0);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityFunPlayRedDot, this.ChallengeId);
				base.RefreshActivityRedPoint();
			}
		}

		// Token: 0x04024CFB RID: 150779
		private int ChallengeId;

		// Token: 0x04024CFC RID: 150780
		private long UnlockTime;

		// Token: 0x04024CFD RID: 150781
		private FunPlayChallengeRewardStatus RewardStatus;

		// Token: 0x04024CFE RID: 150782
		private FunPlayActivityChallenge? Config;

		// Token: 0x04024CFF RID: 150783
		private readonly List<FunPlaySharpComment> SharpCommentList = new List<FunPlaySharpComment>();

		// Token: 0x04024D00 RID: 150784
		private long FinishTime;

		// Token: 0x04024D01 RID: 150785
		public int Index = -1;

		// Token: 0x04024D02 RID: 150786
		private const int CLICKQUESTKEY = 200;

		// Token: 0x04024D03 RID: 150787
		private const int LOCKKEY = 10;
	}
}
