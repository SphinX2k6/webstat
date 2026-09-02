using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005722 RID: 22306
	[NullableContext(2)]
	[Nullable(0)]
	public class MoraleTickPromiseParams
	{
		// Token: 0x04020569 RID: 132457
		public Action StartCallback;

		// Token: 0x0402056A RID: 132458
		public Action<float> TickCallback;

		// Token: 0x0402056B RID: 132459
		public Action EndCallback;
	}
}
