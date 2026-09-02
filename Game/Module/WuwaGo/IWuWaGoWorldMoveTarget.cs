using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA5 RID: 19109
	[NullableContext(2)]
	public interface IWuWaGoWorldMoveTarget
	{
		// Token: 0x170084DE RID: 34014
		// (get) Token: 0x06031D46 RID: 204102
		WuWaGoBaseUnit Unit { get; }

		// Token: 0x170084DF RID: 34015
		// (get) Token: 0x06031D47 RID: 204103
		AActor Actor { get; }

		// Token: 0x170084E0 RID: 34016
		// (get) Token: 0x06031D48 RID: 204104
		Vector FromWorldPosition { get; }

		// Token: 0x170084E1 RID: 34017
		// (get) Token: 0x06031D49 RID: 204105
		Vector ToWorldPosition { get; }
	}
}
