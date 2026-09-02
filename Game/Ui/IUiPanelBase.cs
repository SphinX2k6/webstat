using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004998 RID: 18840
	[NullableContext(2)]
	public interface IUiPanelBase
	{
		// Token: 0x170083FB RID: 33787
		// (get) Token: 0x0603136C RID: 201580
		// (set) Token: 0x0603136D RID: 201581
		bool SkipDestroyActor { get; set; }

		// Token: 0x0603136E RID: 201582
		void SetUiActive(bool visibility);

		// Token: 0x0603136F RID: 201583
		UUIItem GetRootItem();
	}
}
