using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A8C RID: 27276
	public class TuningStandBubbleTypeEnter : TuningStandBubbleTypeBase
	{
		// Token: 0x06043764 RID: 276324 RVA: 0x0116181C File Offset: 0x0115FA1C
		public override bool TryStartBubble(bool canPlay)
		{
			if (this.PlayFlow == null || this.HasPlayedOnce)
			{
				return false;
			}
			this.HasPlayedOnce = true;
			base.UpdateBubble();
			return true;
		}

		// Token: 0x04025AD7 RID: 154327
		protected new ETuningStandBubbleTriggerType BubbleType;

		// Token: 0x04025AD8 RID: 154328
		protected bool HasPlayedOnce;
	}
}
