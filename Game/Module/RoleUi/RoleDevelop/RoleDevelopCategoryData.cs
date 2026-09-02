using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005083 RID: 20611
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopCategoryData : IRoleDevelopCategoryData
	{
		// Token: 0x17008BA5 RID: 35749
		// (get) Token: 0x06035239 RID: 217657 RVA: 0x00D52E18 File Offset: 0x00D51018
		// (set) Token: 0x0603523A RID: 217658 RVA: 0x00D52E20 File Offset: 0x00D51020
		public ERoleDevelopCategoryType CategoryType { get; set; }

		// Token: 0x17008BA6 RID: 35750
		// (get) Token: 0x0603523B RID: 217659 RVA: 0x00D52E29 File Offset: 0x00D51029
		// (set) Token: 0x0603523C RID: 217660 RVA: 0x00D52E31 File Offset: 0x00D51031
		public string CategoryName { get; set; }
	}
}
