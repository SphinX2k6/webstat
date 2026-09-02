using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A93 RID: 27283
	public class TuningStandBubbleTypeTooLong : TuningStandBubbleTypeBase
	{
		// Token: 0x06043772 RID: 276338 RVA: 0x011619C8 File Offset: 0x0115FBC8
		public override bool TryStartBubble(bool canPlay)
		{
			if (this.PlayFlow == null || this.HasPlayedOnce)
			{
				return false;
			}
			this.HasPlayedOnce = true;
			this.CurIndex = 0;
			ITuningStandBubbleData tuningStandBubbleData = this.TalkList[0];
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TuningStandTooLongTime, tuningStandBubbleData.MainRoleTex != null);
			base.UpdateBubble();
			return true;
		}

		// Token: 0x04025AE3 RID: 154339
		protected new ETuningStandBubbleTriggerType BubbleType = ETuningStandBubbleTriggerType.TooLong;

		// Token: 0x04025AE4 RID: 154340
		protected bool HasPlayedOnce;
	}
}
