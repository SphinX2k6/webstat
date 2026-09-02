using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053AE RID: 21422
	public class ChatPopViewData
	{
		// Token: 0x0401F775 RID: 128885
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> FlowId;

		// Token: 0x0401F776 RID: 128886
		[Nullable(2)]
		public Action OnAllShownCallback;

		// Token: 0x0401F777 RID: 128887
		public int Condition;

		// Token: 0x0401F778 RID: 128888
		public int? ParentViewId;
	}
}
