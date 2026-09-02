using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Framework
{
	// Token: 0x02007128 RID: 28968
	public interface IControllerManagerBase
	{
		// Token: 0x06046284 RID: 287364
		[return: Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		List<ValueTuple<string, CustomPromise<bool>>> Preload();

		// Token: 0x06046285 RID: 287365
		void ChangeMode();
	}
}
