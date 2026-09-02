using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200588D RID: 22669
	[NullableContext(1)]
	public interface IMarkItemComponentContext
	{
		// Token: 0x17009300 RID: 37632
		// (get) Token: 0x060399EE RID: 236014
		// (set) Token: 0x060399EF RID: 236015
		MarkItemEntity MarkItemEntity { get; set; }

		// Token: 0x17009301 RID: 37633
		// (get) Token: 0x060399F0 RID: 236016
		// (set) Token: 0x060399F1 RID: 236017
		UUISprite TopRightIconSprite { get; set; }

		// Token: 0x17009302 RID: 37634
		// (get) Token: 0x060399F2 RID: 236018
		// (set) Token: 0x060399F3 RID: 236019
		TSetSpriteByPathAction SetSpriteByPathAction { get; set; }

		// Token: 0x17009303 RID: 37635
		// (get) Token: 0x060399F4 RID: 236020
		// (set) Token: 0x060399F5 RID: 236021
		UUIItem MarkComponentContainer { get; set; }

		// Token: 0x17009304 RID: 37636
		// (get) Token: 0x060399F6 RID: 236022
		// (set) Token: 0x060399F7 RID: 236023
		UUIItem MarkParentItem { get; set; }

		// Token: 0x17009305 RID: 37637
		// (get) Token: 0x060399F8 RID: 236024
		// (set) Token: 0x060399F9 RID: 236025
		UUIItem MarkRootItem { get; set; }

		// Token: 0x17009306 RID: 37638
		// (get) Token: 0x060399FA RID: 236026
		// (set) Token: 0x060399FB RID: 236027
		MarkItem MarkItem { get; set; }

		// Token: 0x060399FC RID: 236028
		bool CanExecuteComponentLogic();
	}
}
