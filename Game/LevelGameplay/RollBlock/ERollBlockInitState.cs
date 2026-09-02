using System;

namespace CSharpScript.Game.LevelGamePlay.RollBlock
{
	// Token: 0x02006B1B RID: 27419
	public enum ERollBlockInitState
	{
		// Token: 0x04025E15 RID: 155157
		None,
		// Token: 0x04025E16 RID: 155158
		Enter,
		// Token: 0x04025E17 RID: 155159
		WaitEntitiesCreate,
		// Token: 0x04025E18 RID: 155160
		WaitSceneItemLoadCompleted,
		// Token: 0x04025E19 RID: 155161
		HandleBirthEffect,
		// Token: 0x04025E1A RID: 155162
		WaitGuideGroupFinished,
		// Token: 0x04025E1B RID: 155163
		WaitGameplayReadyResponse,
		// Token: 0x04025E1C RID: 155164
		AllCompleted
	}
}
