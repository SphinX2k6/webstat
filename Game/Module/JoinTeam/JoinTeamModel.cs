using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.JoinTeam
{
	// Token: 0x02005AFF RID: 23295
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class JoinTeamModel : ModelBase<JoinTeamModel>
	{
		// Token: 0x0603AE78 RID: 241272 RVA: 0x00EF00E9 File Offset: 0x00EEE2E9
		public void SetRoleDescriptionId(int? roleDescriptionId)
		{
			this.RoleDescriptionId = roleDescriptionId;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshJoinTeamRole);
		}

		// Token: 0x0603AE79 RID: 241273 RVA: 0x00EF0102 File Offset: 0x00EEE302
		public int? GetRoleDescriptionId()
		{
			return this.RoleDescriptionId;
		}

		// Token: 0x04021440 RID: 136256
		private int? RoleDescriptionId;
	}
}
