using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x02004725 RID: 18213
	public class CommandSwallowInvoker : CommandInvoker
	{
		// Token: 0x0602F4D4 RID: 193748 RVA: 0x00B371B0 File Offset: 0x00B353B0
		[NullableContext(1)]
		public new void SubmitCommand<[Nullable(0)] T>(IGameCommand<T> command, bool immediatelyExecuteCommands) where T : ICommandType
		{
		}

		// Token: 0x0602F4D5 RID: 193749 RVA: 0x00B371B2 File Offset: 0x00B353B2
		public new void ExecuteAllCommand()
		{
		}

		// Token: 0x0602F4D6 RID: 193750 RVA: 0x00B371B4 File Offset: 0x00B353B4
		public new void Undo()
		{
		}
	}
}
