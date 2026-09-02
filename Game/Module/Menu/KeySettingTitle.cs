using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005753 RID: 22355
	[NullableContext(1)]
	[Nullable(0)]
	public class KeySettingTitle : IKeySettingTitle
	{
		// Token: 0x1700915E RID: 37214
		// (get) Token: 0x06038E8D RID: 233101 RVA: 0x00E6C6F1 File Offset: 0x00E6A8F1
		// (set) Token: 0x06038E8E RID: 233102 RVA: 0x00E6C6F9 File Offset: 0x00E6A8F9
		public int TypeId { get; set; }

		// Token: 0x1700915F RID: 37215
		// (get) Token: 0x06038E8F RID: 233103 RVA: 0x00E6C702 File Offset: 0x00E6A902
		// (set) Token: 0x06038E90 RID: 233104 RVA: 0x00E6C70A File Offset: 0x00E6A90A
		public string TitleNameId { get; set; } = "";

		// Token: 0x17009160 RID: 37216
		// (get) Token: 0x06038E91 RID: 233105 RVA: 0x00E6C713 File Offset: 0x00E6A913
		// (set) Token: 0x06038E92 RID: 233106 RVA: 0x00E6C71B File Offset: 0x00E6A91B
		public string TitleSpriteSprite { get; set; } = "";
	}
}
