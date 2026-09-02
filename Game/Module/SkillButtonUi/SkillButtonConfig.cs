using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F7B RID: 20347
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SkillButtonConfig : ConfigBase<SkillButtonConfig>
	{
		// Token: 0x0603479C RID: 214940 RVA: 0x00D21B7B File Offset: 0x00D1FD7B
		public IReadOnlyList<SkillButton> GetAllSkillButtonConfig(int roleId)
		{
			return ConfigSkillButtonByRoleId.GetConfigList(roleId, true);
		}

		// Token: 0x0603479D RID: 214941 RVA: 0x00D21B84 File Offset: 0x00D1FD84
		public IReadOnlyList<SkillCommonButton> GetAllSkillCommonButtonConfig()
		{
			return ConfigSkillCommonButtonAll.GetConfigList(true);
		}

		// Token: 0x0603479E RID: 214942 RVA: 0x00D21B8C File Offset: 0x00D1FD8C
		public IReadOnlyList<SkillFollowerButton> GetAllSkillFollowerButtonConfig(int pbDataId)
		{
			return ConfigSkillFollowerButtonByPbDataId.GetConfigList(pbDataId, true);
		}

		// Token: 0x0603479F RID: 214943 RVA: 0x00D21B95 File Offset: 0x00D1FD95
		public IReadOnlyList<SkillVehicleButton> GetAllSkillVehicleButtonConfig(int templateId)
		{
			return ConfigSkillVehicleButtonByTemplateId.GetConfigList(templateId, true);
		}

		// Token: 0x060347A0 RID: 214944 RVA: 0x00D21B9E File Offset: 0x00D1FD9E
		public IReadOnlyList<SkillPriorityButton> GetAllSkillPriorityButtonConfig()
		{
			return ConfigSkillPriorityButtonAll.GetConfigList(true);
		}

		// Token: 0x060347A1 RID: 214945 RVA: 0x00D21BA6 File Offset: 0x00D1FDA6
		public SkillButtonIndex? GetSkillIndexConfig(int id)
		{
			return ConfigSkillButtonIndexById.GetConfig(id, true);
		}

		// Token: 0x060347A2 RID: 214946 RVA: 0x00D21BAF File Offset: 0x00D1FDAF
		public SkillIcon? GetSkillIconConfigByTag(int tagId)
		{
			return ConfigSkillIconByTag.GetConfig(tagId, true);
		}

		// Token: 0x060347A3 RID: 214947 RVA: 0x00D21BB8 File Offset: 0x00D1FDB8
		public SkillButtonEffect? GetSkillButtonEffectConfig(int configId)
		{
			return ConfigSkillButtonEffectById.GetConfig(configId, true);
		}

		// Token: 0x060347A4 RID: 214948 RVA: 0x00D21BC1 File Offset: 0x00D1FDC1
		public IReadOnlyList<BehaviorCommonButton> GetAllBehaviorCommonButtonConfig()
		{
			return ConfigBehaviorCommonButtonAll.GetConfigList(true);
		}

		// Token: 0x060347A5 RID: 214949 RVA: 0x00D21BC9 File Offset: 0x00D1FDC9
		public BehaviorCommonButton? GetBehaviorCommonButtonConfig(int configId)
		{
			return ConfigBehaviorCommonButtonById.GetConfig(configId, true);
		}
	}
}
