using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x0200158D RID: 5517
public class RunEndData : UiViewData
{
	// Token: 0x06009B3E RID: 39742 RVA: 0x0028A5C6 File Offset: 0x002887C6
	[NullableContext(1)]
	public void Phrase(ParkourChallengeEndNotify message)
	{
		this.CurrentChallengeId = message.ChallengeId;
		this.CurrentScore = message.Score;
		this.CurrentTime = (long)message.Duration;
	}

	// Token: 0x06009B3F RID: 39743 RVA: 0x0028A5ED File Offset: 0x002887ED
	public void SetIfNewRecord(bool state)
	{
		this.IfNewRecord = state;
	}

	// Token: 0x0400476F RID: 18287
	public int CurrentChallengeId;

	// Token: 0x04004770 RID: 18288
	public int CurrentScore;

	// Token: 0x04004771 RID: 18289
	public long CurrentTime;

	// Token: 0x04004772 RID: 18290
	public bool IfNewRecord;
}
