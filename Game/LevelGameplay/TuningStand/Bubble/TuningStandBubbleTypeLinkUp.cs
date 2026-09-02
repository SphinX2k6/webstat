using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A8F RID: 27279
	public class TuningStandBubbleTypeLinkUp : TuningStandBubbleTypeBase
	{
		// Token: 0x0604376A RID: 276330 RVA: 0x011618EE File Offset: 0x0115FAEE
		public override bool TryStartBubble(bool canPlay)
		{
			if (!canPlay)
			{
				this.HasPlayedOnce = true;
				return false;
			}
			if (this.PlayFlow == null || this.HasPlayedOnce)
			{
				return false;
			}
			this.HasPlayedOnce = true;
			this.CurIndex = 0;
			base.UpdateBubble();
			return true;
		}

		// Token: 0x04025ADD RID: 154333
		protected new ETuningStandBubbleTriggerType BubbleType = ETuningStandBubbleTriggerType.LinkUp;

		// Token: 0x04025ADE RID: 154334
		protected bool HasPlayedOnce;
	}
}
