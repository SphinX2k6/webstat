using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC1 RID: 24257
	[NullableContext(1)]
	public interface ICiacconaGalReChooseChoiceParam
	{
		// Token: 0x170099DE RID: 39390
		// (get) Token: 0x0603CF79 RID: 249721
		// (set) Token: 0x0603CF7A RID: 249722
		string Text { get; set; }

		// Token: 0x170099DF RID: 39391
		// (get) Token: 0x0603CF7B RID: 249723
		// (set) Token: 0x0603CF7C RID: 249724
		EToggleState TogState { get; set; }

		// Token: 0x170099E0 RID: 39392
		// (get) Token: 0x0603CF7D RID: 249725
		// (set) Token: 0x0603CF7E RID: 249726
		string IconResId { get; set; }

		// Token: 0x170099E1 RID: 39393
		// (get) Token: 0x0603CF7F RID: 249727
		// (set) Token: 0x0603CF80 RID: 249728
		Action OnClick { get; set; }
	}
}
