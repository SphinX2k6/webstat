using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C6 RID: 26054
	public interface IPinballAttributeItemData
	{
		// Token: 0x17009EEA RID: 40682
		// (get) Token: 0x06041198 RID: 266648
		// (set) Token: 0x06041199 RID: 266649
		bool IsBgShow { get; set; }

		// Token: 0x17009EEB RID: 40683
		// (get) Token: 0x0604119A RID: 266650
		// (set) Token: 0x0604119B RID: 266651
		PinballPropertyIndex AttributeConfig { get; set; }

		// Token: 0x17009EEC RID: 40684
		// (get) Token: 0x0604119C RID: 266652
		// (set) Token: 0x0604119D RID: 266653
		int AttributeValue { get; set; }
	}
}
