using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.ResponsibilityChain
{
	// Token: 0x02004701 RID: 18177
	[NullableContext(1)]
	public interface IParameterHandler<[Nullable(0)] T> where T : IParameterContext
	{
		// Token: 0x0602F419 RID: 193561
		IParameterHandler<T> SetNext(IParameterHandler<T> handler);

		// Token: 0x0602F41A RID: 193562
		bool Handle(T context);

		// Token: 0x0602F41B RID: 193563
		bool Stop(T context);
	}
}
