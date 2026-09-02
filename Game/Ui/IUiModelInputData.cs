using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A4 RID: 18852
	[NullableContext(1)]
	public interface IUiModelInputData
	{
		// Token: 0x17008400 RID: 33792
		// (get) Token: 0x06031396 RID: 201622
		// (set) Token: 0x06031397 RID: 201623
		UUIDraggableComponent DragComponent { get; set; }

		// Token: 0x17008401 RID: 33793
		// (get) Token: 0x06031398 RID: 201624
		// (set) Token: 0x06031399 RID: 201625
		UiModelBase ModelBase { get; set; }
	}
}
