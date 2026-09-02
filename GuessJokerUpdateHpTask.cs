using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020010F9 RID: 4345
public class GuessJokerUpdateHpTask : GuessJokerTaskBase
{
	// Token: 0x06007126 RID: 28966 RVA: 0x001D9607 File Offset: 0x001D7807
	[NullableContext(1)]
	public GuessJokerUpdateHpTask(JokerGuessHpAction data)
	{
		this.PlayerType = GuessJokerUtils.ServerPlayerTransToClient(data.Actor);
		this.Hp = data.HealthHp;
	}

	// Token: 0x06007127 RID: 28967 RVA: 0x001D9634 File Offset: 0x001D7834
	protected override void OnExecute()
	{
		ModelBase<GuessJokerGamePlayModel>.Instance.UpdateHp(this.PlayerType, this.Hp);
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		list.Add(new GuessJokerUpdateHpAction(this.PlayerType, this.Hp));
		if (this.Hp == 0)
		{
			GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
			list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.ShowWinLoseReasonTip(this.PlayerType, "GuessJoker_HpZeroTipText", false, complete);
			}));
		}
		list.Add(new GuessJokerCallbackAction(new Action(base.FinishTask)));
		ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list);
	}

	// Token: 0x0400366D RID: 13933
	public EGuessJokerPlayerType PlayerType = EGuessJokerPlayerType.Ai;

	// Token: 0x0400366E RID: 13934
	public int Hp;
}
