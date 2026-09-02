using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.Command;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004976 RID: 18806
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PlayerFollowerSwallowHandler : IPlayerFollowerHandler
	{
		// Token: 0x170083D4 RID: 33748
		// (get) Token: 0x06031289 RID: 201353 RVA: 0x00C3DDC2 File Offset: 0x00C3BFC2
		// (set) Token: 0x0603128A RID: 201354 RVA: 0x00C3DDCA File Offset: 0x00C3BFCA
		public CommandInvoker CommandInvoker { get; set; } = new CommandSwallowInvoker();

		// Token: 0x0603128B RID: 201355 RVA: 0x00C3DDD3 File Offset: 0x00C3BFD3
		public virtual IReceiver<ICommandTypeAddFollower> AddFollowerReceiver()
		{
			Receiver<ICommandTypeAddFollower> receiver = new Receiver<ICommandTypeAddFollower>();
			receiver.ReceiveExecute = delegate(TCommandHandleParams<ICommandTypeAddFollower> _)
			{
			};
			return receiver;
		}

		// Token: 0x0603128C RID: 201356 RVA: 0x00C3DDFF File Offset: 0x00C3BFFF
		public virtual IReceiver<ICommandTypeRemoveFollower> RemoveFollowerReceiver()
		{
			Receiver<ICommandTypeRemoveFollower> receiver = new Receiver<ICommandTypeRemoveFollower>();
			receiver.ReceiveExecute = delegate(TCommandHandleParams<ICommandTypeRemoveFollower> _)
			{
			};
			return receiver;
		}

		// Token: 0x0603128D RID: 201357 RVA: 0x00C3DE2B File Offset: 0x00C3C02B
		public virtual IReceiver<ICommandTypeFlushFollower> FlushFollowerReceiver()
		{
			Receiver<ICommandTypeFlushFollower> receiver = new Receiver<ICommandTypeFlushFollower>();
			receiver.ReceiveExecute = delegate(TCommandHandleParams<ICommandTypeFlushFollower> _)
			{
			};
			return receiver;
		}

		// Token: 0x0603128E RID: 201358 RVA: 0x00C3DE57 File Offset: 0x00C3C057
		public virtual bool HasFollower(long creatureDataId)
		{
			return false;
		}

		// Token: 0x0603128F RID: 201359 RVA: 0x00C3DE5A File Offset: 0x00C3C05A
		public virtual void OnClear()
		{
		}
	}
}
