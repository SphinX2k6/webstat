using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005199 RID: 20889
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSelectRoleData
	{
		// Token: 0x06035BAD RID: 220077 RVA: 0x00D80ECC File Offset: 0x00D7F0CC
		public RoguelikeSelectRoleData(ERoguelikeSelectRoleType roleType, List<RoleDataBase> roleIdList, int addRoleLevel, int addWeaponLevel, int maxLevel, List<int> limitRoleList = null, List<int> recommendedRoleList = null)
		{
			this.Type = roleType;
			this.RoleIdList = roleIdList;
			this.AddRoleLevel = addRoleLevel;
			this.AddWeaponLevel = addWeaponLevel;
			this.MaxLevel = maxLevel;
			if (limitRoleList != null)
			{
				this.LimitRoleList = limitRoleList;
			}
			if (recommendedRoleList != null)
			{
				this.RecommendedRoleList = recommendedRoleList;
			}
		}

		// Token: 0x0401ED55 RID: 126293
		public ERoguelikeSelectRoleType Type = ERoguelikeSelectRoleType.Open;

		// Token: 0x0401ED56 RID: 126294
		public List<RoleDataBase> RoleIdList = new List<RoleDataBase>();

		// Token: 0x0401ED57 RID: 126295
		public List<int> LimitRoleList = new List<int>();

		// Token: 0x0401ED58 RID: 126296
		public List<int> RecommendedRoleList = new List<int>();

		// Token: 0x0401ED59 RID: 126297
		public int AddRoleLevel;

		// Token: 0x0401ED5A RID: 126298
		public int AddWeaponLevel;

		// Token: 0x0401ED5B RID: 126299
		public int MaxLevel;
	}
}
