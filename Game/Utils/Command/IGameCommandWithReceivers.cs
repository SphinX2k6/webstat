using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x0200471F RID: 18207
	[NullableContext(1)]
	public interface IGameCommandWithReceivers<[Nullable(0)] T> : IGameCommand<T>, IGameCommandBase where T : ICommandType
	{
		// Token: 0x17008198 RID: 33176
		// (get) Token: 0x0602F4B9 RID: 193721
		// (set) Token: 0x0602F4BA RID: 193722
		HashSet<IReceiver<T>> Receivers { get; set; }

		// Token: 0x0602F4BB RID: 193723
		void AddReceiver(IReceiver<T> receiver);

		// Token: 0x0602F4BC RID: 193724
		void RemoveReceiver(IReceiver<T> receiver);
	}
}
