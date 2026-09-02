using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction
{
	// Token: 0x02006F33 RID: 28467
	[NullableContext(1)]
	[Nullable(0)]
	public class GameplayActionTicker
	{
		// Token: 0x06044EB9 RID: 282297 RVA: 0x011F1224 File Offset: 0x011EF424
		public virtual void PushAction(GameplayAction action)
		{
			this.ActionList.Add(action);
		}

		// Token: 0x06044EBA RID: 282298 RVA: 0x011F1234 File Offset: 0x011EF434
		public virtual void TickAction(float delta)
		{
			int i = 0;
			while (i < this.ActionList.Count)
			{
				GameplayAction gameplayAction = this.ActionList[i];
				if (gameplayAction.IsFinish())
				{
					this.ActionList.RemoveAt(i);
				}
				else
				{
					gameplayAction.TickAction(delta);
					i++;
				}
			}
		}

		// Token: 0x06044EBB RID: 282299 RVA: 0x011F1281 File Offset: 0x011EF481
		public virtual void Clear()
		{
			this.ActionList.Clear();
		}

		// Token: 0x040266DE RID: 157406
		protected readonly List<GameplayAction> ActionList = new List<GameplayAction>();
	}
}
