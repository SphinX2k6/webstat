using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC2 RID: 24258
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalReChooseChoiceParam : ICiacconaGalReChooseChoiceParam
	{
		// Token: 0x170099E2 RID: 39394
		// (get) Token: 0x0603CF81 RID: 249729 RVA: 0x00F7BE62 File Offset: 0x00F7A062
		// (set) Token: 0x0603CF82 RID: 249730 RVA: 0x00F7BE6A File Offset: 0x00F7A06A
		public string Text { get; set; }

		// Token: 0x170099E3 RID: 39395
		// (get) Token: 0x0603CF83 RID: 249731 RVA: 0x00F7BE73 File Offset: 0x00F7A073
		// (set) Token: 0x0603CF84 RID: 249732 RVA: 0x00F7BE7B File Offset: 0x00F7A07B
		public EToggleState TogState { get; set; }

		// Token: 0x170099E4 RID: 39396
		// (get) Token: 0x0603CF85 RID: 249733 RVA: 0x00F7BE84 File Offset: 0x00F7A084
		// (set) Token: 0x0603CF86 RID: 249734 RVA: 0x00F7BE8C File Offset: 0x00F7A08C
		public string IconResId { get; set; }

		// Token: 0x170099E5 RID: 39397
		// (get) Token: 0x0603CF87 RID: 249735 RVA: 0x00F7BE95 File Offset: 0x00F7A095
		// (set) Token: 0x0603CF88 RID: 249736 RVA: 0x00F7BE9D File Offset: 0x00F7A09D
		public Action OnClick { get; set; }
	}
}
