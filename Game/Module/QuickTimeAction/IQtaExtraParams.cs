using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052A9 RID: 21161
	public class IQtaExtraParams
	{
		// Token: 0x0401F168 RID: 127336
		public long? MessageId;

		// Token: 0x0401F169 RID: 127337
		[Nullable(2)]
		public EntityHandle EntityHandle;

		// Token: 0x0401F16A RID: 127338
		public int? FromSkill;

		// Token: 0x0401F16B RID: 127339
		public bool? IsPendingExternalCompletion;
	}
}
