using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020010E9 RID: 4329
[NullableContext(2)]
public interface IGuessJokerDialogData
{
	// Token: 0x1700091A RID: 2330
	// (get) Token: 0x060070C3 RID: 28867
	Func<EGuessJokerPlayerType, UUIItem> GetDialogItem { get; }

	// Token: 0x1700091B RID: 2331
	// (get) Token: 0x060070C4 RID: 28868
	Func<EGuessJokerPlayerType, UUIText> GetDialogText { get; }

	// Token: 0x1700091C RID: 2332
	// (get) Token: 0x060070C5 RID: 28869
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	Action<EGuessJokerPlayerType, string, Action> OnDialogStart { [return: Nullable(new byte[]
	{
		2,
		1,
		1
	})] get; }

	// Token: 0x1700091D RID: 2333
	// (get) Token: 0x060070C6 RID: 28870
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Action<EGuessJokerPlayerType, Action> OnDialogEnd { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; }

	// Token: 0x1700091E RID: 2334
	// (get) Token: 0x060070C7 RID: 28871
	Action<EGuessJokerPlayerType> OnCancelDialogStartAnim { get; }
}
