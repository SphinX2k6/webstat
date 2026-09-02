using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058DA RID: 22746
	[NullableContext(2)]
	public interface IMapLifeEventTriggerParam
	{
		// Token: 0x17009384 RID: 37764
		// (get) Token: 0x06039BB0 RID: 236464
		// (set) Token: 0x06039BB1 RID: 236465
		bool State { get; set; }

		// Token: 0x17009385 RID: 37765
		// (get) Token: 0x06039BB2 RID: 236466
		object Data { get; }
	}
}
