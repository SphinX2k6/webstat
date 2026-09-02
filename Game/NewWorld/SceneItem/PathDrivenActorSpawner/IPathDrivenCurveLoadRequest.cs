using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x0200483E RID: 18494
	public interface IPathDrivenCurveLoadRequest
	{
		// Token: 0x17008264 RID: 33380
		// (get) Token: 0x060301F6 RID: 197110
		// (set) Token: 0x060301F7 RID: 197111
		int HandleId { get; set; }

		// Token: 0x17008265 RID: 33381
		// (get) Token: 0x060301F8 RID: 197112
		// (set) Token: 0x060301F9 RID: 197113
		[Nullable(new byte[]
		{
			1,
			2
		})]
		CustomPromise<UCurveFloat> Promise { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			2
		})] set; }
	}
}
