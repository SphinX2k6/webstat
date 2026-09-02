using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x02004721 RID: 18209
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class GameCommandWithReceivers<[Nullable(0)] T> : GameCommandWithValidators<T>, IGameCommandWithReceivers<T>, IGameCommand<T>, IGameCommandBase where T : ICommandType
	{
		// Token: 0x1700819C RID: 33180
		// (get) Token: 0x0602F4C6 RID: 193734 RVA: 0x00B36F31 File Offset: 0x00B35131
		// (set) Token: 0x0602F4C7 RID: 193735 RVA: 0x00B36F39 File Offset: 0x00B35139
		public HashSet<IReceiver<T>> Receivers { get; set; } = new HashSet<IReceiver<T>>();

		// Token: 0x0602F4C8 RID: 193736 RVA: 0x00B36F42 File Offset: 0x00B35142
		public GameCommandWithReceivers(TCommandHandleParams<T> @params)
		{
			base.Params = @params;
		}

		// Token: 0x0602F4C9 RID: 193737 RVA: 0x00B36F5C File Offset: 0x00B3515C
		public void AddReceiver(IReceiver<T> receiver)
		{
			this.Receivers.Add(receiver);
		}

		// Token: 0x0602F4CA RID: 193738 RVA: 0x00B36F6B File Offset: 0x00B3516B
		public void RemoveReceiver(IReceiver<T> receiver)
		{
			this.Receivers.Remove(receiver);
		}
	}
}
