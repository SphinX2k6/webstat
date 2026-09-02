using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x0200673F RID: 26431
	[NullableContext(1)]
	[Nullable(0)]
	public class BusinessTipsTravelData : IBusinessTipsTravelData
	{
		// Token: 0x1700A0BB RID: 41147
		// (get) Token: 0x06041ECB RID: 270027 RVA: 0x010EA769 File Offset: 0x010E8969
		// (set) Token: 0x06041ECC RID: 270028 RVA: 0x010EA771 File Offset: 0x010E8971
		public List<int> RoleList { get; set; } = new List<int>();

		// Token: 0x1700A0BC RID: 41148
		// (get) Token: 0x06041ECD RID: 270029 RVA: 0x010EA77A File Offset: 0x010E897A
		// (set) Token: 0x06041ECE RID: 270030 RVA: 0x010EA782 File Offset: 0x010E8982
		public List<int> LastLevelList { get; set; } = new List<int>();

		// Token: 0x1700A0BD RID: 41149
		// (get) Token: 0x06041ECF RID: 270031 RVA: 0x010EA78B File Offset: 0x010E898B
		// (set) Token: 0x06041ED0 RID: 270032 RVA: 0x010EA793 File Offset: 0x010E8993
		public int DelegateId { get; set; }
	}
}
