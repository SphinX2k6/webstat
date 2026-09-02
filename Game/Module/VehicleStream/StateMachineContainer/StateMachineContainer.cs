using System;

namespace CSharpScript.Game.Module.VehicleStream.StateMachineContainer
{
	// Token: 0x02004C58 RID: 19544
	public abstract class StateMachineContainer
	{
		// Token: 0x17008773 RID: 34675
		// (get) Token: 0x06032EC0 RID: 208576
		public abstract EStateContainerType Type { get; }

		// Token: 0x17008774 RID: 34676
		// (get) Token: 0x06032EC1 RID: 208577
		public abstract int Id { get; }
	}
}
