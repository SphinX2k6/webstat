using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D71 RID: 23921
	[NullableContext(2)]
	[Nullable(0)]
	public class FlagChallengeRoleCategoryItemData
	{
		// Token: 0x04021E03 RID: 138755
		public EFlagChallengeRoleCategoryType CategoryType;

		// Token: 0x04021E04 RID: 138756
		[Nullable(1)]
		public string TitleKey = "";

		// Token: 0x04021E05 RID: 138757
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RoleDataBase> RoleList;

		// Token: 0x04021E06 RID: 138758
		public Func<int, EToggleState, bool> CanSelectRole;

		// Token: 0x04021E07 RID: 138759
		public Action<int, EToggleState> OnSelectRole;
	}
}
