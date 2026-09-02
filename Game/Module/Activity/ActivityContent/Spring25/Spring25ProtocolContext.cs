using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x0200635E RID: 25438
	[NullableContext(1)]
	[Nullable(0)]
	public class Spring25ProtocolContext : ActivityBaseData
	{
		// Token: 0x0603FDD7 RID: 261591 RVA: 0x01061F5F File Offset: 0x0106015F
		public Spring25ProtocolContext(Spring25Model model)
		{
			this.AttachedModel = model;
		}

		// Token: 0x0603FDD8 RID: 261592 RVA: 0x01061F84 File Offset: 0x01060184
		public void Dispose()
		{
			this.CanInvite = false;
			this.TaskCacheInternal.Clear();
			this.InvitedRoleSetInternal.Clear();
		}

		// Token: 0x0603FDD9 RID: 261593 RVA: 0x01061FA4 File Offset: 0x010601A4
		protected override void PhraseEx(ActivityData data)
		{
			SpringSignInfo springSignInfo = data.SpringSignInfo;
			if (springSignInfo != null)
			{
				this.ParseActivityInfo(springSignInfo);
				if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.Spring25DialogueView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.Spring25EnvelopeView))
				{
					this.AttachedModel.ResetCurrentSignId();
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.Spring25ActivityParseDone);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x0603FDDA RID: 261594 RVA: 0x01062015 File Offset: 0x01060215
		public override bool GetExDataRedPointShowState()
		{
			return this.AttachedModel.HasRedDot;
		}

		// Token: 0x17009CC5 RID: 40133
		// (get) Token: 0x0603FDDB RID: 261595 RVA: 0x01062022 File Offset: 0x01060222
		public int SignCountRemain
		{
			get
			{
				return (this.CanInvite > false) ? 1 : 0;
			}
		}

		// Token: 0x17009CC6 RID: 40134
		// (get) Token: 0x0603FDDC RID: 261596 RVA: 0x01062030 File Offset: 0x01060230
		public int FinishTaskCount
		{
			get
			{
				int num = 0;
				using (Dictionary<int, ActivityTask>.ValueCollection.Enumerator enumerator = this.TaskCacheInternal.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Status > ActivityTaskState.ActivityTaskRunning)
						{
							num++;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x17009CC7 RID: 40135
		// (get) Token: 0x0603FDDD RID: 261597 RVA: 0x01062090 File Offset: 0x01060290
		public int InvitedCount
		{
			get
			{
				return this.InvitedRoleSetInternal.Count;
			}
		}

		// Token: 0x17009CC8 RID: 40136
		// (get) Token: 0x0603FDDE RID: 261598 RVA: 0x0106209D File Offset: 0x0106029D
		public Dictionary<int, ActivityTask> TaskCache
		{
			get
			{
				return this.TaskCacheInternal;
			}
		}

		// Token: 0x17009CC9 RID: 40137
		// (get) Token: 0x0603FDDF RID: 261599 RVA: 0x010620A5 File Offset: 0x010602A5
		public HashSet<int> InvitedRoleSet
		{
			get
			{
				return this.InvitedRoleSetInternal;
			}
		}

		// Token: 0x17009CCA RID: 40138
		// (get) Token: 0x0603FDE0 RID: 261600 RVA: 0x010620B0 File Offset: 0x010602B0
		public bool HasAnyReward
		{
			get
			{
				using (Dictionary<int, ActivityTask>.ValueCollection.Enumerator enumerator = this.TaskCacheInternal.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Status == ActivityTaskState.ActivityTaskFinish)
						{
							return true;
						}
					}
				}
				return this.AttachedModel.IsAllInvited && !this.IsSkinRewarded;
			}
		}

		// Token: 0x17009CCB RID: 40139
		// (get) Token: 0x0603FDE1 RID: 261601 RVA: 0x01062128 File Offset: 0x01060328
		public bool IsInviteAvailable
		{
			get
			{
				return this.CanInvite;
			}
		}

		// Token: 0x0603FDE2 RID: 261602 RVA: 0x01062130 File Offset: 0x01060330
		public int GetTaskCurrentByTaskId(int id)
		{
			ActivityTask activityTask;
			if (!this.TaskCacheInternal.TryGetValue(id, out activityTask))
			{
				return 0;
			}
			return activityTask.Current;
		}

		// Token: 0x0603FDE3 RID: 261603 RVA: 0x01062158 File Offset: 0x01060358
		public int GetTaskTargetByTaskId(int id)
		{
			ActivityTask activityTask;
			if (!this.TaskCacheInternal.TryGetValue(id, out activityTask))
			{
				return 0;
			}
			return activityTask.Target;
		}

		// Token: 0x0603FDE4 RID: 261604 RVA: 0x01062180 File Offset: 0x01060380
		public ActivityTaskState GetTaskStateByTaskId(int id)
		{
			ActivityTask activityTask;
			if (!this.TaskCacheInternal.TryGetValue(id, out activityTask))
			{
				return ActivityTaskState.ActivityTaskRunning;
			}
			return activityTask.Status;
		}

		// Token: 0x0603FDE5 RID: 261605 RVA: 0x010621A8 File Offset: 0x010603A8
		public List<TItem> GetTaskRewardPreviewByTaskId(int id)
		{
			List<TItem> list = new List<TItem>();
			ActivityTask activityTask;
			if (!this.TaskCacheInternal.TryGetValue(id, out activityTask))
			{
				return list;
			}
			MapField<int, int> preItemMap = activityTask.PreItemMap;
			if (preItemMap == null)
			{
				return list;
			}
			foreach (KeyValuePair<int, int> keyValuePair in preItemMap)
			{
				InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0);
				TItem item = new TItem(itemData, keyValuePair.Value);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603FDE6 RID: 261606 RVA: 0x01062238 File Offset: 0x01060438
		public bool IsRoleInvitedById(int id)
		{
			return this.InvitedRoleSetInternal.Contains(id);
		}

		// Token: 0x0603FDE7 RID: 261607 RVA: 0x01062248 File Offset: 0x01060448
		private void ParseActivityInfo(SpringSignInfo data)
		{
			this.CanInvite = data.CanInvite;
			this.TaskCacheInternal.Clear();
			foreach (ActivityTask activityTask in data.SpringSignActivityTasks)
			{
				this.TaskCacheInternal[activityTask.Id] = activityTask;
			}
			this.InvitedRoleSetInternal.Clear();
			foreach (int item in data.DrawRoles)
			{
				this.InvitedRoleSetInternal.Add(item);
			}
			this.IsSkinRewarded = data.SkinReward;
		}

		// Token: 0x0603FDE8 RID: 261608 RVA: 0x01062310 File Offset: 0x01060510
		public void SyncTaskStateByTaskId(int id)
		{
			ActivityTask activityTask;
			if (this.TaskCache.TryGetValue(id, out activityTask))
			{
				ActivityTask activityTask2 = activityTask;
				int num = activityTask2.Current;
				activityTask2.Current = num + 1;
				activityTask.Status = ActivityTaskState.ActivityTaskTaken;
			}
		}

		// Token: 0x0603FDE9 RID: 261609 RVA: 0x01062344 File Offset: 0x01060544
		public void SyncSkinReward()
		{
			this.IsSkinRewarded = true;
		}

		// Token: 0x04023E61 RID: 147041
		private readonly Spring25Model AttachedModel;

		// Token: 0x04023E62 RID: 147042
		public bool IsSkinRewarded;

		// Token: 0x04023E63 RID: 147043
		public bool CanInvite;

		// Token: 0x04023E64 RID: 147044
		private readonly Dictionary<int, ActivityTask> TaskCacheInternal = new Dictionary<int, ActivityTask>();

		// Token: 0x04023E65 RID: 147045
		private readonly HashSet<int> InvitedRoleSetInternal = new HashSet<int>();
	}
}
