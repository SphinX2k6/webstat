using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A95 RID: 23189
	[NullableContext(2)]
	public interface IAttributeListItem : IKurotatoRoleSkillInfo
	{
		// Token: 0x1700959B RID: 38299
		// (get) Token: 0x0603AAC7 RID: 240327
		// (set) Token: 0x0603AAC8 RID: 240328
		bool? JustChanged { get; set; }

		// Token: 0x1700959C RID: 38300
		// (get) Token: 0x0603AAC9 RID: 240329
		// (set) Token: 0x0603AACA RID: 240330
		IKurotatoAttrPreviewDelta Preview { get; set; }
	}
}
