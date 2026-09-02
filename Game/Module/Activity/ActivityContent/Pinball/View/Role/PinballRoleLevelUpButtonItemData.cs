using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D8 RID: 26072
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballRoleLevelUpButtonItemData : IPinballRoleLevelUpButtonItemData
	{
		// Token: 0x17009F0E RID: 40718
		// (get) Token: 0x06041227 RID: 266791 RVA: 0x010B58D4 File Offset: 0x010B3AD4
		// (set) Token: 0x06041228 RID: 266792 RVA: 0x010B58DC File Offset: 0x010B3ADC
		public int Times { get; set; }

		// Token: 0x17009F0F RID: 40719
		// (get) Token: 0x06041229 RID: 266793 RVA: 0x010B58E5 File Offset: 0x010B3AE5
		// (set) Token: 0x0604122A RID: 266794 RVA: 0x010B58ED File Offset: 0x010B3AED
		public bool IsToMaxLevel { get; set; }

		// Token: 0x17009F10 RID: 40720
		// (get) Token: 0x0604122B RID: 266795 RVA: 0x010B58F6 File Offset: 0x010B3AF6
		// (set) Token: 0x0604122C RID: 266796 RVA: 0x010B58FE File Offset: 0x010B3AFE
		public Action<int> ConfirmDelegate { get; set; }

		// Token: 0x17009F11 RID: 40721
		// (get) Token: 0x0604122D RID: 266797 RVA: 0x010B5907 File Offset: 0x010B3B07
		// (set) Token: 0x0604122E RID: 266798 RVA: 0x010B590F File Offset: 0x010B3B0F
		public ICostData CostItemData { get; set; }
	}
}
