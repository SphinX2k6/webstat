using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E3B RID: 20027
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseAttrItemData : ITrapDefenseAttrItemData
	{
		// Token: 0x170088CA RID: 35018
		// (get) Token: 0x06033C44 RID: 212036 RVA: 0x00CF0B5F File Offset: 0x00CEED5F
		// (set) Token: 0x06033C45 RID: 212037 RVA: 0x00CF0B67 File Offset: 0x00CEED67
		public string IconPath { get; set; }

		// Token: 0x170088CB RID: 35019
		// (get) Token: 0x06033C46 RID: 212038 RVA: 0x00CF0B70 File Offset: 0x00CEED70
		// (set) Token: 0x06033C47 RID: 212039 RVA: 0x00CF0B78 File Offset: 0x00CEED78
		[Nullable(1)]
		public string NameKey { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170088CC RID: 35020
		// (get) Token: 0x06033C48 RID: 212040 RVA: 0x00CF0B81 File Offset: 0x00CEED81
		// (set) Token: 0x06033C49 RID: 212041 RVA: 0x00CF0B89 File Offset: 0x00CEED89
		public string Value { get; set; }
	}
}
