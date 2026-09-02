using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.ChessGameplay.StackableChess;

// Token: 0x02001287 RID: 4743
public static class ChessManagerCreator
{
	// Token: 0x06007F03 RID: 32515 RVA: 0x0021A012 File Offset: 0x00218212
	[NullableContext(2)]
	public static IChessManager CreateChessManager(EChessMode mode)
	{
		if (mode == EChessMode.Stackable)
		{
			return new StackableChessManager();
		}
		return null;
	}
}
