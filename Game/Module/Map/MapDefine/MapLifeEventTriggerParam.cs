using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058DB RID: 22747
	[NullableContext(2)]
	[Nullable(0)]
	public class MapLifeEventTriggerParam<T> : IMapLifeEventTriggerParam
	{
		// Token: 0x17009386 RID: 37766
		// (get) Token: 0x06039BB3 RID: 236467 RVA: 0x00EA0470 File Offset: 0x00E9E670
		// (set) Token: 0x06039BB4 RID: 236468 RVA: 0x00EA0478 File Offset: 0x00E9E678
		public bool State { get; set; }

		// Token: 0x17009387 RID: 37767
		// (get) Token: 0x06039BB5 RID: 236469 RVA: 0x00EA0481 File Offset: 0x00E9E681
		object IMapLifeEventTriggerParam.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x04020BC3 RID: 134083
		public T Data;
	}
}
