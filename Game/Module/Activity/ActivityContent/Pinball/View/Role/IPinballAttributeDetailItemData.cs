using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C2 RID: 26050
	public interface IPinballAttributeDetailItemData
	{
		// Token: 0x17009EE2 RID: 40674
		// (get) Token: 0x0604117D RID: 266621
		// (set) Token: 0x0604117E RID: 266622
		bool IsBgShow { get; set; }

		// Token: 0x17009EE3 RID: 40675
		// (get) Token: 0x0604117F RID: 266623
		// (set) Token: 0x06041180 RID: 266624
		PinballPropertyIndex AttributeConfig { get; set; }

		// Token: 0x17009EE4 RID: 40676
		// (get) Token: 0x06041181 RID: 266625
		// (set) Token: 0x06041182 RID: 266626
		int AttributeValue { get; set; }

		// Token: 0x17009EE5 RID: 40677
		// (get) Token: 0x06041183 RID: 266627
		// (set) Token: 0x06041184 RID: 266628
		bool IsExpanded { get; set; }
	}
}
