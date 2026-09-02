using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x02006887 RID: 26759
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class DropCatchConfig : ConfigBase<DropCatchConfig>
	{
		// Token: 0x06042AC8 RID: 273096 RVA: 0x0111DA43 File Offset: 0x0111BC43
		public IReadOnlyList<DropCatchGameplay> GetDropCatchGameplayByActivityId(int activityId)
		{
			return ConfigDropCatchGameplayByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x06042AC9 RID: 273097 RVA: 0x0111DA4C File Offset: 0x0111BC4C
		public IReadOnlyList<DropCatchRole> GetAllDropCatchRole()
		{
			return ConfigDropCatchRoleAll.GetConfigList(true);
		}

		// Token: 0x06042ACA RID: 273098 RVA: 0x0111DA54 File Offset: 0x0111BC54
		public DropCatchGameplay? GetDropCatchGameplayById(int id)
		{
			return ConfigDropCatchGameplayById.GetConfig(id, true);
		}

		// Token: 0x06042ACB RID: 273099 RVA: 0x0111DA5D File Offset: 0x0111BC5D
		public DropCatchRole? GetDropCatchRoleById(int id)
		{
			return ConfigDropCatchRoleById.GetConfig(id, true);
		}

		// Token: 0x06042ACC RID: 273100 RVA: 0x0111DA66 File Offset: 0x0111BC66
		public DropCatchDropItem? GetDropCatchDropItemById(int id)
		{
			return ConfigDropCatchDropItemById.GetConfig(id, true);
		}

		// Token: 0x06042ACD RID: 273101 RVA: 0x0111DA6F File Offset: 0x0111BC6F
		public IReadOnlyList<DropCatchDropItem> GetAllDropItemConfig()
		{
			return ConfigDropCatchDropItemAll.GetConfigList(true);
		}

		// Token: 0x06042ACE RID: 273102 RVA: 0x0111DA77 File Offset: 0x0111BC77
		public DropCatchDropPool? GetDropCatchDropPoolById(int id)
		{
			return ConfigDropCatchDropPoolById.GetConfig(id, true);
		}

		// Token: 0x06042ACF RID: 273103 RVA: 0x0111DA80 File Offset: 0x0111BC80
		public DropCatchReward? GetDropCatchRewardById(int id)
		{
			return ConfigDropCatchRewardById.GetConfig(id, true);
		}

		// Token: 0x06042AD0 RID: 273104 RVA: 0x0111DA8C File Offset: 0x0111BC8C
		public DropCatchGameplay? GetTargetRoleLevelInfo(int activityId, int roleId)
		{
			IReadOnlyList<DropCatchGameplay> dropCatchGameplayByActivityId = this.GetDropCatchGameplayByActivityId(activityId);
			if (dropCatchGameplayByActivityId != null)
			{
				foreach (DropCatchGameplay value in dropCatchGameplayByActivityId)
				{
					if (value.RoleId == roleId && value.ActivityId > 0)
					{
						return new DropCatchGameplay?(value);
					}
				}
			}
			return null;
		}

		// Token: 0x06042AD1 RID: 273105 RVA: 0x0111DB04 File Offset: 0x0111BD04
		public IReadOnlyList<DropCatchRoleBook> GetDropCatchRoleBookAll()
		{
			return ConfigDropCatchRoleBookAll.GetConfigList(true);
		}

		// Token: 0x06042AD2 RID: 273106 RVA: 0x0111DB0C File Offset: 0x0111BD0C
		public DropCatchRoleBook? GetDropCatchRoleBookById(int id)
		{
			return ConfigDropCatchRoleBookById.GetConfig(id, true);
		}
	}
}
