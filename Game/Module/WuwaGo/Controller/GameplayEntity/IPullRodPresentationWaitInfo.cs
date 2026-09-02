using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B12 RID: 19218
	[NullableContext(1)]
	public interface IPullRodPresentationWaitInfo
	{
		// Token: 0x17008591 RID: 34193
		// (get) Token: 0x060321F3 RID: 205299
		SceneInteractionActor SceneActor { get; }

		// Token: 0x17008592 RID: 34194
		// (get) Token: 0x060321F4 RID: 205300
		ULevelSequence Sequence { get; }

		// Token: 0x17008593 RID: 34195
		// (get) Token: 0x060321F5 RID: 205301
		float PlayRate { get; }
	}
}
