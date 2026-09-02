using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200668D RID: 26253
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskInstanceDetailLockItemData : IMowingRiskInstanceDetailLockItemData
	{
		// Token: 0x17009FFE RID: 40958
		// (get) Token: 0x06041913 RID: 268563 RVA: 0x010D0F32 File Offset: 0x010CF132
		// (set) Token: 0x06041914 RID: 268564 RVA: 0x010D0F3A File Offset: 0x010CF13A
		public bool IsUnlock { get; set; }

		// Token: 0x17009FFF RID: 40959
		// (get) Token: 0x06041915 RID: 268565 RVA: 0x010D0F43 File Offset: 0x010CF143
		// (set) Token: 0x06041916 RID: 268566 RVA: 0x010D0F4B File Offset: 0x010CF14B
		public string LockDescriptionTextId { get; set; }

		// Token: 0x1700A000 RID: 40960
		// (get) Token: 0x06041917 RID: 268567 RVA: 0x010D0F54 File Offset: 0x010CF154
		// (set) Token: 0x06041918 RID: 268568 RVA: 0x010D0F5C File Offset: 0x010CF15C
		public string[] LockDescriptionTextArgs { get; set; }
	}
}
