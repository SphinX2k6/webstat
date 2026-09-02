using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A5 RID: 18853
	[NullableContext(1)]
	[Nullable(0)]
	public class UiModelInputData : IUiModelInputData
	{
		// Token: 0x17008402 RID: 33794
		// (get) Token: 0x0603139A RID: 201626 RVA: 0x00C41E14 File Offset: 0x00C40014
		// (set) Token: 0x0603139B RID: 201627 RVA: 0x00C41E1C File Offset: 0x00C4001C
		public UUIDraggableComponent DragComponent { get; set; }

		// Token: 0x17008403 RID: 33795
		// (get) Token: 0x0603139C RID: 201628 RVA: 0x00C41E25 File Offset: 0x00C40025
		// (set) Token: 0x0603139D RID: 201629 RVA: 0x00C41E2D File Offset: 0x00C4002D
		public UiModelBase ModelBase { get; set; }
	}
}
