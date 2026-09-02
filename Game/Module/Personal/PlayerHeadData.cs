using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Personal
{
	// Token: 0x0200564D RID: 22093
	[NullableContext(1)]
	[Nullable(0)]
	public class PlayerHeadData
	{
		// Token: 0x060384DD RID: 230621 RVA: 0x00E40F04 File Offset: 0x00E3F104
		public PlayerHeadData(PlayerHeadRe config)
		{
			this.Id = config.Id;
			this.Config = config;
			if (config.RoleSkinId > 0)
			{
				this.RoleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(config.RoleSkinId);
			}
		}

		// Token: 0x17009086 RID: 36998
		// (get) Token: 0x060384DE RID: 230622 RVA: 0x00E40F53 File Offset: 0x00E3F153
		// (set) Token: 0x060384DF RID: 230623 RVA: 0x00E40F5B File Offset: 0x00E3F15B
		public bool Lock
		{
			get
			{
				return this.LockInternal;
			}
			set
			{
				this.LockInternal = value;
			}
		}

		// Token: 0x060384E0 RID: 230624 RVA: 0x00E40F64 File Offset: 0x00E3F164
		public string GetName()
		{
			if (this.RoleSkinData != null)
			{
				return this.RoleSkinData.GetRoleSkinConfig().Name;
			}
			return this.Config.Name;
		}

		// Token: 0x060384E1 RID: 230625 RVA: 0x00E40F9C File Offset: 0x00E3F19C
		public string GetRoleHeadIconLarge()
		{
			if (this.RoleSkinData != null)
			{
				return this.RoleSkinData.GetRoleSkinConfig().RoleHeadIconLarge;
			}
			return this.Config.RoleHeadIconLarge;
		}

		// Token: 0x060384E2 RID: 230626 RVA: 0x00E40FD4 File Offset: 0x00E3F1D4
		public string GetRoleHeadIcon()
		{
			if (this.RoleSkinData != null)
			{
				return this.RoleSkinData.GetRoleSkinConfig().RoleHeadIcon;
			}
			return this.Config.RoleHeadIcon;
		}

		// Token: 0x060384E3 RID: 230627 RVA: 0x00E4100C File Offset: 0x00E3F20C
		public string GetRoleCardHeadIcon()
		{
			if (this.RoleSkinData != null)
			{
				return this.RoleSkinData.GetRoleSkinConfig().Card;
			}
			return this.Config.Card;
		}

		// Token: 0x060384E4 RID: 230628 RVA: 0x00E41044 File Offset: 0x00E3F244
		public string GetRoleHeadIconCircle()
		{
			if (this.RoleSkinData != null)
			{
				return this.RoleSkinData.GetRoleSkinConfig().RoleHeadIconCircle;
			}
			return this.Config.RoleHeadIconCircle;
		}

		// Token: 0x04020206 RID: 131590
		public readonly int Id;

		// Token: 0x04020207 RID: 131591
		public readonly PlayerHeadRe Config;

		// Token: 0x04020208 RID: 131592
		private bool LockInternal = true;

		// Token: 0x04020209 RID: 131593
		[Nullable(2)]
		private readonly RoleSkinData RoleSkinData;
	}
}
