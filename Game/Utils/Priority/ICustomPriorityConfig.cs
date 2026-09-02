using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Priority
{
	// Token: 0x02004705 RID: 18181
	public interface ICustomPriorityConfig<T> where T : struct, Enum
	{
		// Token: 0x17008164 RID: 33124
		// (get) Token: 0x0602F42D RID: 193581
		// (set) Token: 0x0602F42E RID: 193582
		bool Enable { get; set; }

		// Token: 0x17008165 RID: 33125
		// (get) Token: 0x0602F42F RID: 193583
		// (set) Token: 0x0602F430 RID: 193584
		T? Enum { get; set; }

		// Token: 0x17008166 RID: 33126
		// (get) Token: 0x0602F431 RID: 193585
		// (set) Token: 0x0602F432 RID: 193586
		int? Priority { get; set; }

		// Token: 0x17008167 RID: 33127
		// (get) Token: 0x0602F433 RID: 193587
		// (set) Token: 0x0602F434 RID: 193588
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Func<ICustomPriorityCallbackParam, bool> EnterCallback { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008168 RID: 33128
		// (get) Token: 0x0602F435 RID: 193589
		// (set) Token: 0x0602F436 RID: 193590
		bool? EnterReentrant { get; set; }

		// Token: 0x17008169 RID: 33129
		// (get) Token: 0x0602F437 RID: 193591
		// (set) Token: 0x0602F438 RID: 193592
		bool? ForceEnterCallback { get; set; }

		// Token: 0x1700816A RID: 33130
		// (get) Token: 0x0602F439 RID: 193593
		// (set) Token: 0x0602F43A RID: 193594
		bool? CheckEnterValid { get; set; }

		// Token: 0x1700816B RID: 33131
		// (get) Token: 0x0602F43B RID: 193595
		// (set) Token: 0x0602F43C RID: 193596
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Func<ICustomPriorityCallbackParam, bool> ExitCallback { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700816C RID: 33132
		// (get) Token: 0x0602F43D RID: 193597
		// (set) Token: 0x0602F43E RID: 193598
		bool? ForceExitCallback { get; set; }

		// Token: 0x1700816D RID: 33133
		// (get) Token: 0x0602F43F RID: 193599
		// (set) Token: 0x0602F440 RID: 193600
		bool? CheckExitValid { get; set; }
	}
}
