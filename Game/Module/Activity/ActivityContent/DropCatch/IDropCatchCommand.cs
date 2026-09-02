using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068A5 RID: 26789
	[NullableContext(1)]
	public interface IDropCatchCommand
	{
		// Token: 0x06042B17 RID: 273175
		void Execute(ICommandContext context, [Nullable(2)] object @params);
	}
}
