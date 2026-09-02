using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.Data
{
	// Token: 0x020050D5 RID: 20693
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopData
	{
		// Token: 0x06035525 RID: 218405 RVA: 0x00D60B70 File Offset: 0x00D5ED70
		public RoleDevelopData(int id)
		{
			this.Id = id;
		}

		// Token: 0x06035526 RID: 218406 RVA: 0x00D60B7F File Offset: 0x00D5ED7F
		public int GetId()
		{
			return this.Id;
		}

		// Token: 0x06035527 RID: 218407 RVA: 0x00D60B88 File Offset: 0x00D5ED88
		public RoleDevelopRoleBaseData GetDevelopRoleData()
		{
			bool flag = RoleDevelopUtil.IsProspectRole(this.Id);
			ERoleDevelopRoleType eroleDevelopRoleType = flag ? ERoleDevelopRoleType.Prospect : ERoleDevelopRoleType.Normal;
			if (this.DevelopRoleData != null && this.DevelopRoleData.GetRoleType() == eroleDevelopRoleType)
			{
				return this.DevelopRoleData;
			}
			this.DevelopRoleData = (flag ? new RoleDevelopRoleProspectData(this.Id) : new RoleDevelopRoleData(this.Id));
			return this.DevelopRoleData;
		}

		// Token: 0x06035528 RID: 218408 RVA: 0x00D60BF0 File Offset: 0x00D5EDF0
		public RoleDevelopProjectBaseData GetProjectData()
		{
			bool flag = RoleDevelopUtil.IsProspectRole(this.Id);
			ERoleDevelopRoleType eroleDevelopRoleType = flag ? ERoleDevelopRoleType.Prospect : ERoleDevelopRoleType.Normal;
			if (this.DevelopProjectData != null && this.DevelopProjectData.GetRoleType() == eroleDevelopRoleType)
			{
				return this.DevelopProjectData;
			}
			RoleDevelopRoleBaseData developRoleData = this.GetDevelopRoleData();
			this.DevelopProjectData = (flag ? new RoleDevelopProjectProspectData(this.Id, developRoleData) : new RoleDevelopProjectData(this.Id, developRoleData));
			return this.DevelopProjectData;
		}

		// Token: 0x06035529 RID: 218409 RVA: 0x00D60C60 File Offset: 0x00D5EE60
		public ERoleDevelopHotRoleTag GetHotRoleTag()
		{
			if (!RoleDevelopUtil.IsHotRoleDevelopValid(this.Id))
			{
				return ERoleDevelopHotRoleTag.None;
			}
			int typeId = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(this.Id).TypeId;
			if (typeId == 1 && RoleDevelopUtil.IsRoleInProspectTime(this.Id))
			{
				return ERoleDevelopHotRoleTag.Forecast;
			}
			if (typeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(this.Id))
			{
				return ERoleDevelopHotRoleTag.Rerun;
			}
			if (typeId == 3 && RoleDevelopUtil.IsRoleInProspectTime(this.Id))
			{
				return ERoleDevelopHotRoleTag.Rerun;
			}
			if (RoleDevelopUtil.GetHotRoleGachaId(this.Id, true) != null)
			{
				return ERoleDevelopHotRoleTag.Summon;
			}
			return ERoleDevelopHotRoleTag.None;
		}

		// Token: 0x0401EA9F RID: 125599
		private int Id;

		// Token: 0x0401EAA0 RID: 125600
		[Nullable(2)]
		private RoleDevelopRoleBaseData DevelopRoleData;

		// Token: 0x0401EAA1 RID: 125601
		[Nullable(2)]
		private RoleDevelopProjectBaseData DevelopProjectData;
	}
}
