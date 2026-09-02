using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005259 RID: 21081
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleRoleData : RoleDataBase
	{
		// Token: 0x06035F80 RID: 221056 RVA: 0x00D94577 File Offset: 0x00D92777
		public RogueBattleRoleData(int id) : base(id)
		{
		}

		// Token: 0x06035F81 RID: 221057 RVA: 0x00D94580 File Offset: 0x00D92780
		public override bool IsTrialRole()
		{
			return false;
		}

		// Token: 0x06035F82 RID: 221058 RVA: 0x00D94583 File Offset: 0x00D92783
		public override string GetName(int? playerId = null)
		{
			return this.GetRoleInstanceData().GetName(playerId);
		}

		// Token: 0x06035F83 RID: 221059 RVA: 0x00D94591 File Offset: 0x00D92791
		public override int GetRoleId()
		{
			return this.Id;
		}

		// Token: 0x06035F84 RID: 221060 RVA: 0x00D94599 File Offset: 0x00D92799
		public override bool IsOnlineRole()
		{
			return false;
		}

		// Token: 0x06035F85 RID: 221061 RVA: 0x00D9459C File Offset: 0x00D9279C
		public override bool CanChangeName()
		{
			return false;
		}

		// Token: 0x06035F86 RID: 221062 RVA: 0x00D9459F File Offset: 0x00D9279F
		public override int GetRoleCreateTime()
		{
			return 0;
		}

		// Token: 0x06035F87 RID: 221063 RVA: 0x00D945A2 File Offset: 0x00D927A2
		public override bool GetIsNew()
		{
			return false;
		}

		// Token: 0x06035F88 RID: 221064 RVA: 0x00D945A5 File Offset: 0x00D927A5
		public override int GetRoleSkinId()
		{
			return this.GetRoleInstanceData().GetRoleSkinId();
		}

		// Token: 0x06035F89 RID: 221065 RVA: 0x00D945B2 File Offset: 0x00D927B2
		protected RoleDataBase GetRoleInstanceData()
		{
			return ModelBase<RoleModel>.Instance.GetRoleDataById(this.GetRoleId(), true);
		}
	}
}
