using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AAF RID: 19119
	[NullableContext(1)]
	public interface IRoundStepExecutor
	{
		// Token: 0x06031D96 RID: 204182
		UniTask Execute(ERoundStep step, IReadOnlyList<IExecutableUnit> units, int executionToken);
	}
}
