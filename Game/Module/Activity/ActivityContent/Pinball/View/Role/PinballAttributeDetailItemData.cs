using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C3 RID: 26051
	public class PinballAttributeDetailItemData : IPinballAttributeDetailItemData
	{
		// Token: 0x17009EE6 RID: 40678
		// (get) Token: 0x06041185 RID: 266629 RVA: 0x010B3AF5 File Offset: 0x010B1CF5
		// (set) Token: 0x06041186 RID: 266630 RVA: 0x010B3AFD File Offset: 0x010B1CFD
		public bool IsBgShow { get; set; }

		// Token: 0x17009EE7 RID: 40679
		// (get) Token: 0x06041187 RID: 266631 RVA: 0x010B3B06 File Offset: 0x010B1D06
		// (set) Token: 0x06041188 RID: 266632 RVA: 0x010B3B0E File Offset: 0x010B1D0E
		public PinballPropertyIndex AttributeConfig { get; set; }

		// Token: 0x17009EE8 RID: 40680
		// (get) Token: 0x06041189 RID: 266633 RVA: 0x010B3B17 File Offset: 0x010B1D17
		// (set) Token: 0x0604118A RID: 266634 RVA: 0x010B3B1F File Offset: 0x010B1D1F
		public int AttributeValue { get; set; }

		// Token: 0x17009EE9 RID: 40681
		// (get) Token: 0x0604118B RID: 266635 RVA: 0x010B3B28 File Offset: 0x010B1D28
		// (set) Token: 0x0604118C RID: 266636 RVA: 0x010B3B30 File Offset: 0x010B1D30
		public bool IsExpanded { get; set; }
	}
}
