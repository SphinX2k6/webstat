using System;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Process
{
	// Token: 0x020055EF RID: 21999
	public enum EPlayingCardProcessState
	{
		// Token: 0x040200B1 RID: 131249
		None,
		// Token: 0x040200B2 RID: 131250
		TimeStart,
		// Token: 0x040200B3 RID: 131251
		OwnChangeCard,
		// Token: 0x040200B4 RID: 131252
		BothDrawCard,
		// Token: 0x040200B5 RID: 131253
		OpponentTimeStart,
		// Token: 0x040200B6 RID: 131254
		OpponentPlaying,
		// Token: 0x040200B7 RID: 131255
		GameOverByOpponent,
		// Token: 0x040200B8 RID: 131256
		OwnTimeStart,
		// Token: 0x040200B9 RID: 131257
		ShowOwnCoreCard,
		// Token: 0x040200BA RID: 131258
		OwnPlaying,
		// Token: 0x040200BB RID: 131259
		TimeEnd,
		// Token: 0x040200BC RID: 131260
		JumpLoading
	}
}
