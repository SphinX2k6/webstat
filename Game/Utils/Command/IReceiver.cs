using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x0200471A RID: 18202
	[NullableContext(1)]
	public interface IReceiver<[Nullable(0)] T> where T : ICommandType
	{
		// Token: 0x17008190 RID: 33168
		// (get) Token: 0x0602F4A9 RID: 193705
		// (set) Token: 0x0602F4AA RID: 193706
		Action<TCommandHandleParams<T>> ReceiveExecute { get; set; }

		// Token: 0x17008191 RID: 33169
		// (get) Token: 0x0602F4AB RID: 193707
		// (set) Token: 0x0602F4AC RID: 193708
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		Action<TCommandHandleParams<T>> ReceiveUndo { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }
	}
}
