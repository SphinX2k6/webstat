using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x0200471E RID: 18206
	public interface IGameCommand<T> : IGameCommandBase where T : ICommandType
	{
		// Token: 0x17008195 RID: 33173
		// (get) Token: 0x0602F4B3 RID: 193715
		// (set) Token: 0x0602F4B4 RID: 193716
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		Action<TCommandHandleParams<T>> Execute { [return: Nullable(new byte[]
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

		// Token: 0x17008196 RID: 33174
		// (get) Token: 0x0602F4B5 RID: 193717
		// (set) Token: 0x0602F4B6 RID: 193718
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		Action<TCommandHandleParams<T>> Undo { [return: Nullable(new byte[]
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

		// Token: 0x17008197 RID: 33175
		// (get) Token: 0x0602F4B7 RID: 193719
		// (set) Token: 0x0602F4B8 RID: 193720
		[Nullable(new byte[]
		{
			2,
			1
		})]
		TCommandHandleParams<T> Params { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
