using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x0200689F RID: 26783
	public class IShowLeftMsgCommandParams
	{
		// Token: 0x04025220 RID: 152096
		public EDropCatchGameplayLeftMsgType Type;

		// Token: 0x04025221 RID: 152097
		[Nullable(2)]
		public string Icon;

		// Token: 0x04025222 RID: 152098
		[Nullable(1)]
		public string TextId;

		// Token: 0x04025223 RID: 152099
		public float? Duration;
	}
}
