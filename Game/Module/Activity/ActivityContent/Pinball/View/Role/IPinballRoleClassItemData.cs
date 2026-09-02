using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D1 RID: 26065
	[NullableContext(1)]
	public interface IPinballRoleClassItemData
	{
		// Token: 0x17009EFA RID: 40698
		// (get) Token: 0x060411EB RID: 266731
		// (set) Token: 0x060411EC RID: 266732
		string Name { get; set; }

		// Token: 0x17009EFB RID: 40699
		// (get) Token: 0x060411ED RID: 266733
		// (set) Token: 0x060411EE RID: 266734
		string IconPath { get; set; }

		// Token: 0x17009EFC RID: 40700
		// (get) Token: 0x060411EF RID: 266735
		// (set) Token: 0x060411F0 RID: 266736
		string BgColor { get; set; }
	}
}
