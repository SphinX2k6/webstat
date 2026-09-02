using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB3 RID: 19123
	[NullableContext(1)]
	public interface IMovableFloorMoveRequest
	{
		// Token: 0x17008510 RID: 34064
		// (get) Token: 0x06031D9F RID: 204191
		MovableFloorController Controller { get; }

		// Token: 0x17008511 RID: 34065
		// (get) Token: 0x06031DA0 RID: 204192
		IWuWaGoGridRelocationRequest RelocationRequest { get; }
	}
}
