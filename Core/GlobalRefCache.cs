using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Core
{
	// Token: 0x02007118 RID: 28952
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GlobalRefCache : Singleton<GlobalRefCache>
	{
		// Token: 0x04027558 RID: 161112
		public FHitResult HitResult = new FHitResult();
	}
}
