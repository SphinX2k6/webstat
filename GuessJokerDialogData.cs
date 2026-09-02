using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020010EA RID: 4330
[NullableContext(2)]
[Nullable(0)]
public class GuessJokerDialogData : IGuessJokerDialogData
{
	// Token: 0x1700091F RID: 2335
	// (get) Token: 0x060070C8 RID: 28872 RVA: 0x001D7006 File Offset: 0x001D5206
	// (set) Token: 0x060070C9 RID: 28873 RVA: 0x001D700E File Offset: 0x001D520E
	public Func<EGuessJokerPlayerType, UUIItem> GetDialogItem { get; set; }

	// Token: 0x17000920 RID: 2336
	// (get) Token: 0x060070CA RID: 28874 RVA: 0x001D7017 File Offset: 0x001D5217
	// (set) Token: 0x060070CB RID: 28875 RVA: 0x001D701F File Offset: 0x001D521F
	public Func<EGuessJokerPlayerType, UUIText> GetDialogText { get; set; }

	// Token: 0x17000921 RID: 2337
	// (get) Token: 0x060070CC RID: 28876 RVA: 0x001D7028 File Offset: 0x001D5228
	// (set) Token: 0x060070CD RID: 28877 RVA: 0x001D7030 File Offset: 0x001D5230
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<EGuessJokerPlayerType, string, Action> OnDialogStart { [return: Nullable(new byte[]
	{
		2,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1
	})] set; }

	// Token: 0x17000922 RID: 2338
	// (get) Token: 0x060070CE RID: 28878 RVA: 0x001D7039 File Offset: 0x001D5239
	// (set) Token: 0x060070CF RID: 28879 RVA: 0x001D7041 File Offset: 0x001D5241
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<EGuessJokerPlayerType, Action> OnDialogEnd { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000923 RID: 2339
	// (get) Token: 0x060070D0 RID: 28880 RVA: 0x001D704A File Offset: 0x001D524A
	// (set) Token: 0x060070D1 RID: 28881 RVA: 0x001D7052 File Offset: 0x001D5252
	public Action<EGuessJokerPlayerType> OnCancelDialogStartAnim { get; set; }
}
