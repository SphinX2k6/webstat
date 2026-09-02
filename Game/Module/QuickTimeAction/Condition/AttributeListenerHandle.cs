using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052C2 RID: 21186
	[NullableContext(1)]
	[Nullable(0)]
	public class AttributeListenerHandle
	{
		// Token: 0x06036299 RID: 221849 RVA: 0x00DA3F5C File Offset: 0x00DA215C
		public AttributeListenerHandle(int id, Action<EAttributeType, float, float> callback)
		{
			this.Id = id;
			this.Callback = callback;
		}

		// Token: 0x0401F1D7 RID: 127447
		public int Id;

		// Token: 0x0401F1D8 RID: 127448
		public Action<EAttributeType, float, float> Callback;
	}
}
