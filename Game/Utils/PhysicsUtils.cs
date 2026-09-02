using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F9 RID: 18169
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhysicsUtils : Singleton<PhysicsUtils>
	{
		// Token: 0x0401AEAC RID: 110252
		public FHitResult DefaultHitResult = new FHitResult();
	}
}
