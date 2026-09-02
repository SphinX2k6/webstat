using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Define.TdConfigExtensions
{
	// Token: 0x02007137 RID: 28983
	[NullableContext(1)]
	public interface TService
	{
		// Token: 0x060462DC RID: 287452
		bool Invoke(string name, List<object> args, [Nullable(2)] out object result);
	}
}
