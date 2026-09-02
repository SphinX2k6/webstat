using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.RecallQuest.Model
{
	// Token: 0x02005297 RID: 21143
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RecallQuestModel : ModelBase<RecallQuestModel>
	{
		// Token: 0x060360DC RID: 221404 RVA: 0x00D9BADA File Offset: 0x00D99CDA
		protected override bool OnInit()
		{
			this.InventoryData.Clear();
			this.HasQueriedItemBag = false;
			this.CurrentRecallId = 0;
			return true;
		}

		// Token: 0x060360DD RID: 221405 RVA: 0x00D9BAF6 File Offset: 0x00D99CF6
		protected override bool OnClear()
		{
			this.RecallDataMap.Clear();
			this.InventoryData.Clear();
			this.HasQueriedItemBag = false;
			this.CurrentRecallId = 0;
			return true;
		}

		// Token: 0x060360DE RID: 221406 RVA: 0x00D9BB20 File Offset: 0x00D99D20
		protected override bool OnLeaveLevel()
		{
			if (this.CurrentRecallId > 0 && this.CurrentRecallTrackQuestId == 0)
			{
				if (this.HasQueriedItemBag)
				{
					this.HasQueriedItemBag = false;
					this.InventoryData.Clear();
					ModelBase<InventoryModel>.Instance.ResetInventoryDataProxy();
				}
				global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
				if (curTrackedQuest != null)
				{
					this.CurrentRecallTrackQuestId = ((curTrackedQuest.Id > 0) ? curTrackedQuest.Id : 0);
					curTrackedQuest.SetTrack(false, ESetTrackReason.None);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "缓存当前回顾跟踪任务Id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurrentRecallTrackQuestId", this.CurrentRecallTrackQuestId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return true;
		}

		// Token: 0x060360DF RID: 221407 RVA: 0x00D9BBC8 File Offset: 0x00D99DC8
		public void TryReTrackRecallQuest()
		{
			if (this.CurrentRecallTrackQuestId > 0)
			{
				global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.CurrentRecallTrackQuestId);
				if (quest != null)
				{
					quest.SetTrack(true, ESetTrackReason.None);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.QuestRecall;
					ELogAuthor author = ELogAuthor.YZY;
					string message = "回顾副本：尝试重新追踪之前的任务";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questId", this.CurrentRecallTrackQuestId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.CurrentRecallTrackQuestId = 0;
			}
		}

		// Token: 0x060360E0 RID: 221408 RVA: 0x00D9BC34 File Offset: 0x00D99E34
		public void SetPastRecallIds(IEnumerable<RecallInfo> data)
		{
			foreach (RecallInfo recallInfo in data)
			{
				int recallId = recallInfo.RecallId;
				ERecallStatus status = (ERecallStatus)recallInfo.Status;
				this.RecallDataMap[recallId] = new RecallData(recallId, status);
			}
		}

		// Token: 0x060360E1 RID: 221409 RVA: 0x00D9BC94 File Offset: 0x00D99E94
		public bool IsRecallCanContinue(int recallId)
		{
			RecallData recallData;
			return this.RecallDataMap.TryGetValue(recallId, out recallData) && recallData.Status == ERecallStatus.InProgress;
		}

		// Token: 0x060360E2 RID: 221410 RVA: 0x00D9BCBD File Offset: 0x00D99EBD
		public RecallInventoryData GetInventoryData()
		{
			return this.InventoryData;
		}

		// Token: 0x060360E3 RID: 221411 RVA: 0x00D9BCC5 File Offset: 0x00D99EC5
		public void ClearInventoryData()
		{
			this.InventoryData.Clear();
		}

		// Token: 0x060360E4 RID: 221412 RVA: 0x00D9BCD4 File Offset: 0x00D99ED4
		public void SetCurrentRecallId(int recallId)
		{
			this.CurrentRecallId = recallId;
			RecallConfig? recallQuestConfig = ConfigBase<RecallQuestConfig>.Instance.GetRecallQuestConfig(recallId);
			for (int i = 0; i < recallQuestConfig.Value.RecallQuestsLength; i++)
			{
				DicIntInt? dicIntInt = recallQuestConfig.Value.RecallQuests(i);
				if (dicIntInt != null)
				{
					this.CurrentRecallQuestMap[dicIntInt.Value.Value] = dicIntInt.Value.Key;
				}
			}
		}

		// Token: 0x060360E5 RID: 221413 RVA: 0x00D9BD53 File Offset: 0x00D99F53
		public int GetCurrentRecallId()
		{
			return this.CurrentRecallId;
		}

		// Token: 0x060360E6 RID: 221414 RVA: 0x00D9BD5C File Offset: 0x00D99F5C
		public int TryGetRecallQuestIdByQuestId(int questId)
		{
			if (!this.IsInRecallInstance())
			{
				return questId;
			}
			int num;
			this.CurrentRecallQuestMap.TryGetValue(questId, out num);
			if (num == 0)
			{
				return questId;
			}
			return num;
		}

		// Token: 0x060360E7 RID: 221415 RVA: 0x00D9BD88 File Offset: 0x00D99F88
		public bool IsInRecallInstance()
		{
			InstanceDungeon? instanceDungeon;
			return ((ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().InstType) : null).GetValueOrDefault() == 6;
		}

		// Token: 0x0401F108 RID: 127240
		private readonly Dictionary<int, RecallData> RecallDataMap = new Dictionary<int, RecallData>();

		// Token: 0x0401F109 RID: 127241
		private readonly RecallInventoryData InventoryData = new RecallInventoryData();

		// Token: 0x0401F10A RID: 127242
		public bool HasQueriedItemBag;

		// Token: 0x0401F10B RID: 127243
		private int CurrentRecallId;

		// Token: 0x0401F10C RID: 127244
		private readonly Dictionary<int, int> CurrentRecallQuestMap = new Dictionary<int, int>();

		// Token: 0x0401F10D RID: 127245
		public int CurrentRecallTrackQuestId;
	}
}
