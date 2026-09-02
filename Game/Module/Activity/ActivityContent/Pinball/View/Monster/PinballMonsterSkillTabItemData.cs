using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Monster
{
	// Token: 0x020065F0 RID: 26096
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballMonsterSkillTabItemData : IPinballMonsterSkillTabItemData
	{
		// Token: 0x17009F23 RID: 40739
		// (get) Token: 0x0604131D RID: 267037 RVA: 0x010B9C6C File Offset: 0x010B7E6C
		// (set) Token: 0x0604131E RID: 267038 RVA: 0x010B9C74 File Offset: 0x010B7E74
		public bool IsSelected { get; set; }

		// Token: 0x17009F24 RID: 40740
		// (get) Token: 0x0604131F RID: 267039 RVA: 0x010B9C7D File Offset: 0x010B7E7D
		// (set) Token: 0x06041320 RID: 267040 RVA: 0x010B9C85 File Offset: 0x010B7E85
		public string Name { get; set; }

		// Token: 0x17009F25 RID: 40741
		// (get) Token: 0x06041321 RID: 267041 RVA: 0x010B9C8E File Offset: 0x010B7E8E
		// (set) Token: 0x06041322 RID: 267042 RVA: 0x010B9C96 File Offset: 0x010B7E96
		public Action<int> OnSelected { get; set; }
	}
}
