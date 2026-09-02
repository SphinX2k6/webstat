using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A58 RID: 27224
	public class InteractSecondConfirmContext : GeneralContext
	{
		// Token: 0x06043531 RID: 275761 RVA: 0x0114DFC9 File Offset: 0x0114C1C9
		public InteractSecondConfirmContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.InteractSecondConfirm);
		}

		// Token: 0x06043532 RID: 275762 RVA: 0x0114DFE0 File Offset: 0x0114C1E0
		[NullableContext(1)]
		public static InteractSecondConfirmContext Create(int handle, CommonInteractOption option)
		{
			InteractSecondConfirmContext interactSecondConfirmContext = GeneralContext.GetObj(EGeneralContextType.InteractSecondConfirm, null, () => new InteractSecondConfirmContext()) as InteractSecondConfirmContext;
			interactSecondConfirmContext.Handle = handle;
			interactSecondConfirmContext.Option = option;
			return interactSecondConfirmContext;
		}

		// Token: 0x040258AE RID: 153774
		public int Handle;

		// Token: 0x040258AF RID: 153775
		[Nullable(2)]
		public CommonInteractOption Option;

		// Token: 0x040258B0 RID: 153776
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, bool, CommonInteractOption> ConfirmCallback;
	}
}
