using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E3A RID: 20026
	[NullableContext(2)]
	public interface ITrapDefenseAttrItemData
	{
		// Token: 0x170088C7 RID: 35015
		// (get) Token: 0x06033C41 RID: 212033
		string IconPath { get; }

		// Token: 0x170088C8 RID: 35016
		// (get) Token: 0x06033C42 RID: 212034
		[Nullable(1)]
		string NameKey { [NullableContext(1)] get; }

		// Token: 0x170088C9 RID: 35017
		// (get) Token: 0x06033C43 RID: 212035
		string Value { get; }
	}
}
