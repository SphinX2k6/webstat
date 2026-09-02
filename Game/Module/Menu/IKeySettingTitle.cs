using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005752 RID: 22354
	[NullableContext(1)]
	public interface IKeySettingTitle
	{
		// Token: 0x1700915B RID: 37211
		// (get) Token: 0x06038E87 RID: 233095
		// (set) Token: 0x06038E88 RID: 233096
		int TypeId { get; set; }

		// Token: 0x1700915C RID: 37212
		// (get) Token: 0x06038E89 RID: 233097
		// (set) Token: 0x06038E8A RID: 233098
		string TitleNameId { get; set; }

		// Token: 0x1700915D RID: 37213
		// (get) Token: 0x06038E8B RID: 233099
		// (set) Token: 0x06038E8C RID: 233100
		string TitleSpriteSprite { get; set; }
	}
}
