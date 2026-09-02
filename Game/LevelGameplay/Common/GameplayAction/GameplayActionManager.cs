using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction
{
	// Token: 0x02006F32 RID: 28466
	[NullableContext(1)]
	[Nullable(0)]
	public class GameplayActionManager
	{
		// Token: 0x06044EB3 RID: 282291 RVA: 0x011F102B File Offset: 0x011EF22B
		public void Init(GameplayActionTicker actionTicker)
		{
			this.ActionTicker = actionTicker;
		}

		// Token: 0x06044EB4 RID: 282292 RVA: 0x011F1034 File Offset: 0x011EF234
		public virtual void Clear()
		{
			this.Interrupt();
			this.ActionTicker = null;
		}

		// Token: 0x06044EB5 RID: 282293 RVA: 0x011F1044 File Offset: 0x011EF244
		public void Interrupt()
		{
			GameplayActionTicker actionTicker = this.ActionTicker;
			if (actionTicker != null)
			{
				actionTicker.Clear();
			}
			foreach (KeyValuePair<int, ActionGroupQueue> keyValuePair in this.ActionGroupQueueMap)
			{
				Queue<GameplayActionGroup> queue = keyValuePair.Value.Queue;
				while (queue.Size > 0)
				{
					queue.Pop().InterruptActionGroup();
				}
			}
			this.ActionGroupQueueMap.Clear();
		}

		// Token: 0x06044EB6 RID: 282294 RVA: 0x011F10D0 File Offset: 0x011EF2D0
		protected void ExecuteActionGroups(List<GameplayActionGroup> actionGroups, [Nullable(2)] Action onAllFinish = null)
		{
			if (actionGroups.Count <= 0)
			{
				if (onAllFinish != null)
				{
					onAllFinish();
				}
				return;
			}
			int num = this.QueueId + 1;
			this.QueueId = num;
			int num2 = num;
			ActionGroupQueue actionGroupQueue = new ActionGroupQueue();
			actionGroupQueue.OnFinish = onAllFinish;
			this.ActionGroupQueueMap[num2] = actionGroupQueue;
			foreach (GameplayActionGroup gameplayActionGroup in actionGroups)
			{
				gameplayActionGroup.OwnerId = num2;
				actionGroupQueue.Queue.Push(gameplayActionGroup);
			}
			actionGroupQueue.Queue.Front.ExecuteActionGroup(this.ActionTicker, new Action<int>(this.OnActionGroupFinish));
		}

		// Token: 0x06044EB7 RID: 282295 RVA: 0x011F1190 File Offset: 0x011EF390
		private void OnActionGroupFinish(int ownerId)
		{
			ActionGroupQueue actionGroupQueue;
			if (!this.ActionGroupQueueMap.TryGetValue(ownerId, out actionGroupQueue))
			{
				return;
			}
			Queue<GameplayActionGroup> queue = actionGroupQueue.Queue;
			queue.Pop();
			if (queue.Size > 0)
			{
				queue.Front.ExecuteActionGroup(this.ActionTicker, new Action<int>(this.OnActionGroupFinish));
				return;
			}
			ActionGroupQueue actionGroupQueue2;
			if (this.ActionGroupQueueMap.TryGetValue(ownerId, out actionGroupQueue2))
			{
				Action onFinish = actionGroupQueue2.OnFinish;
				if (onFinish != null)
				{
					onFinish();
				}
			}
			this.ActionGroupQueueMap.Remove(ownerId);
		}

		// Token: 0x040266DB RID: 157403
		private int QueueId;

		// Token: 0x040266DC RID: 157404
		private readonly Dictionary<int, ActionGroupQueue> ActionGroupQueueMap = new Dictionary<int, ActionGroupQueue>();

		// Token: 0x040266DD RID: 157405
		[Nullable(2)]
		private GameplayActionTicker ActionTicker;
	}
}
