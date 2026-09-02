using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x02004723 RID: 18211
	[NullableContext(1)]
	[Nullable(0)]
	public static class GameCommandFactory
	{
		// Token: 0x0602F4CC RID: 193740 RVA: 0x00B36F97 File Offset: 0x00B35197
		public static IGameCommandWithReceivers<T> CreateGameCommandWithReceivers<[Nullable(0)] T>(TCommandHandleParams<T> @params) where T : ICommandType
		{
			return new GameCommandWithReceivers<T>(@params);
		}

		// Token: 0x0602F4CD RID: 193741 RVA: 0x00B36F9F File Offset: 0x00B3519F
		public static IGameCommand<T> CreateGameCommandBarely<[Nullable(0)] T>([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Action<TCommandHandleParams<T>> execute, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] Action<TCommandHandleParams<T>> undo, TCommandHandleParams<T> @params) where T : ICommandType
		{
			return new GameCommandBarely<T>(execute, undo, @params);
		}
	}
}
