using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Movement
{
	// Token: 0x02004ACA RID: 19146
	[NullableContext(1)]
	internal interface IGridMoveParticipantExecution
	{
		// Token: 0x1700851C RID: 34076
		// (get) Token: 0x06031E9F RID: 204447
		IWuWaGoGridMoveParticipant Participant { get; }

		// Token: 0x1700851D RID: 34077
		// (get) Token: 0x06031EA0 RID: 204448
		IWuWaGoGridRelocationContext Context { get; }
	}
}
