using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E0A RID: 24074
	[NullableContext(1)]
	public interface ICookRoleItemData
	{
		// Token: 0x17009918 RID: 39192
		// (get) Token: 0x0603C94C RID: 248140
		// (set) Token: 0x0603C94D RID: 248141
		int RoleId { get; set; }

		// Token: 0x17009919 RID: 39193
		// (get) Token: 0x0603C94E RID: 248142
		// (set) Token: 0x0603C94F RID: 248143
		string RoleName { get; set; }

		// Token: 0x1700991A RID: 39194
		// (get) Token: 0x0603C950 RID: 248144
		// (set) Token: 0x0603C951 RID: 248145
		string RoleIcon { get; set; }

		// Token: 0x1700991B RID: 39195
		// (get) Token: 0x0603C952 RID: 248146
		// (set) Token: 0x0603C953 RID: 248147
		bool IsBuff { get; set; }

		// Token: 0x1700991C RID: 39196
		// (get) Token: 0x0603C954 RID: 248148
		// (set) Token: 0x0603C955 RID: 248149
		int ItemId { get; set; }
	}
}
