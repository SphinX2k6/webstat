using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.Command;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004972 RID: 18802
	[NullableContext(1)]
	public interface IPlayerFollowerHandler
	{
		// Token: 0x0603127B RID: 201339
		IReceiver<ICommandTypeAddFollower> AddFollowerReceiver();

		// Token: 0x0603127C RID: 201340
		IReceiver<ICommandTypeRemoveFollower> RemoveFollowerReceiver();

		// Token: 0x0603127D RID: 201341
		IReceiver<ICommandTypeFlushFollower> FlushFollowerReceiver();

		// Token: 0x170083D3 RID: 33747
		// (get) Token: 0x0603127E RID: 201342
		CommandInvoker CommandInvoker { get; }

		// Token: 0x0603127F RID: 201343
		void OnClear();

		// Token: 0x06031280 RID: 201344
		bool HasFollower(long creatureDataId);
	}
}
