using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction
{
	// Token: 0x02006F30 RID: 28464
	[NullableContext(1)]
	[Nullable(0)]
	public class GameplayActionGroup
	{
		// Token: 0x06044EAC RID: 282284 RVA: 0x011F0E4C File Offset: 0x011EF04C
		public void PushAction(GameplayAction task)
		{
			this.ActionList.Add(task);
		}

		// Token: 0x06044EAD RID: 282285 RVA: 0x011F0E5C File Offset: 0x011EF05C
		[NullableContext(2)]
		public void ExecuteActionGroup(GameplayActionTicker ticker = null, Action<int> onFinish = null)
		{
			this.State = EActionGroupState.Executing;
			foreach (GameplayAction gameplayAction in this.ActionList)
			{
				gameplayAction.ExecuteAction(new Action(this.CheckGroupFinish));
				if (gameplayAction.NeedTick() && ticker != null)
				{
					ticker.PushAction(gameplayAction);
				}
			}
			this.OnActionGroupFinish = onFinish;
			this.CheckGroupFinish();
		}

		// Token: 0x06044EAE RID: 282286 RVA: 0x011F0EE0 File Offset: 0x011EF0E0
		public void InterruptActionGroup()
		{
			foreach (GameplayAction gameplayAction in this.ActionList)
			{
				gameplayAction.InterruptAction();
			}
			this.State = EActionGroupState.Finish;
		}

		// Token: 0x06044EAF RID: 282287 RVA: 0x011F0F38 File Offset: 0x011EF138
		public EActionGroupState GetState()
		{
			return this.State;
		}

		// Token: 0x06044EB0 RID: 282288 RVA: 0x011F0F40 File Offset: 0x011EF140
		private void CheckGroupFinish()
		{
			foreach (GameplayAction gameplayAction in this.ActionList)
			{
				if (!gameplayAction.IsLoop() && !gameplayAction.IsFinish())
				{
					return;
				}
			}
			foreach (GameplayAction gameplayAction2 in this.ActionList)
			{
				if (!gameplayAction2.IsFinish())
				{
					gameplayAction2.InterruptAction();
				}
			}
			this.State = EActionGroupState.Finish;
			Action<int> onActionGroupFinish = this.OnActionGroupFinish;
			if (onActionGroupFinish == null)
			{
				return;
			}
			onActionGroupFinish(this.OwnerId);
		}

		// Token: 0x040266D5 RID: 157397
		public int OwnerId;

		// Token: 0x040266D6 RID: 157398
		private readonly List<GameplayAction> ActionList = new List<GameplayAction>();

		// Token: 0x040266D7 RID: 157399
		private EActionGroupState State;

		// Token: 0x040266D8 RID: 157400
		[Nullable(2)]
		private Action<int> OnActionGroupFinish;
	}
}
