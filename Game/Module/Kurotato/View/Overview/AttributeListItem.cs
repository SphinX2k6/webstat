using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A96 RID: 23190
	[NullableContext(2)]
	[Nullable(0)]
	public class AttributeListItem : KurotatoRoleSkillInfo, IAttributeListItem, IKurotatoRoleSkillInfo
	{
		// Token: 0x1700959D RID: 38301
		// (get) Token: 0x0603AACB RID: 240331 RVA: 0x00EDE342 File Offset: 0x00EDC542
		// (set) Token: 0x0603AACC RID: 240332 RVA: 0x00EDE34A File Offset: 0x00EDC54A
		public bool? JustChanged { get; set; }

		// Token: 0x1700959E RID: 38302
		// (get) Token: 0x0603AACD RID: 240333 RVA: 0x00EDE353 File Offset: 0x00EDC553
		// (set) Token: 0x0603AACE RID: 240334 RVA: 0x00EDE35B File Offset: 0x00EDC55B
		public IKurotatoAttrPreviewDelta Preview { get; set; }
	}
}
