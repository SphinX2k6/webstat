using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053AD RID: 21421
	[NullableContext(1)]
	[Nullable(0)]
	public class ChatItemData
	{
		// Token: 0x0401F76E RID: 128878
		public string Icon = "";

		// Token: 0x0401F76F RID: 128879
		public string Name = "";

		// Token: 0x0401F770 RID: 128880
		public string Message = "";

		// Token: 0x0401F771 RID: 128881
		public string Time = "";

		// Token: 0x0401F772 RID: 128882
		[Nullable(2)]
		public string TidTalk;

		// Token: 0x0401F773 RID: 128883
		public bool IsCompleted;

		// Token: 0x0401F774 RID: 128884
		public ChatItemDisplayMode? DisplayMode;
	}
}
