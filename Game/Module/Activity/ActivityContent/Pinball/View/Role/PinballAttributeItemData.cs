using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C7 RID: 26055
	public class PinballAttributeItemData : IPinballAttributeItemData
	{
		// Token: 0x17009EED RID: 40685
		// (get) Token: 0x0604119E RID: 266654 RVA: 0x010B3F2B File Offset: 0x010B212B
		// (set) Token: 0x0604119F RID: 266655 RVA: 0x010B3F33 File Offset: 0x010B2133
		public bool IsBgShow { get; set; }

		// Token: 0x17009EEE RID: 40686
		// (get) Token: 0x060411A0 RID: 266656 RVA: 0x010B3F3C File Offset: 0x010B213C
		// (set) Token: 0x060411A1 RID: 266657 RVA: 0x010B3F44 File Offset: 0x010B2144
		public PinballPropertyIndex AttributeConfig { get; set; }

		// Token: 0x17009EEF RID: 40687
		// (get) Token: 0x060411A2 RID: 266658 RVA: 0x010B3F4D File Offset: 0x010B214D
		// (set) Token: 0x060411A3 RID: 266659 RVA: 0x010B3F55 File Offset: 0x010B2155
		public int AttributeValue { get; set; }
	}
}
