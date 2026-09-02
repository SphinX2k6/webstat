using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002284 RID: 8836
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MotionConfig : ConfigBase<MotionConfig>
{
	// Token: 0x06010B34 RID: 68404 RVA: 0x00492E31 File Offset: 0x00491031
	public Motion? GetMotionConfig(int id)
	{
		return ConfigMotionById.GetConfig(id, true);
	}

	// Token: 0x06010B35 RID: 68405 RVA: 0x00492E3A File Offset: 0x0049103A
	public IReadOnlyList<Motion> GetMotionConfigsByRoleId(int roleId)
	{
		return ConfigMotionByRoleId.GetConfigList(roleId, true);
	}

	// Token: 0x06010B36 RID: 68406 RVA: 0x00492E43 File Offset: 0x00491043
	public IReadOnlyList<Motion> GetRoleMotionByRoleSkinId(int roleSkinId)
	{
		return ConfigMotionBySkinId.GetConfigList(roleSkinId, true);
	}

	// Token: 0x06010B37 RID: 68407 RVA: 0x00492E4C File Offset: 0x0049104C
	public IReadOnlyList<Motion> GetRoleMotionByType(int roleId, int type)
	{
		return ConfigMotionByRoleIdAndType.GetConfigList(roleId, type, true);
	}

	// Token: 0x06010B38 RID: 68408 RVA: 0x00492E58 File Offset: 0x00491058
	public Motion? GetPerformanceMotionConfigByPosition(int skinId, int position)
	{
		IReadOnlyList<Motion> configList = ConfigMotionBySkinIdAndType.GetConfigList(skinId, 2, true);
		if (configList == null)
		{
			return null;
		}
		foreach (Motion value in configList)
		{
			if (value.Sort == position)
			{
				return new Motion?(value);
			}
		}
		return null;
	}

	// Token: 0x06010B39 RID: 68409 RVA: 0x00492ED0 File Offset: 0x004910D0
	public string GetMotionTitle(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return ConfigMultiTextLang.GetLocalTextNew(motionConfig.Value.Title, null);
	}

	// Token: 0x06010B3A RID: 68410 RVA: 0x00492F08 File Offset: 0x00491108
	public string GetMotionContent(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return ConfigMultiTextLang.GetLocalTextNew(motionConfig.Value.Content, null);
	}

	// Token: 0x06010B3B RID: 68411 RVA: 0x00492F40 File Offset: 0x00491140
	public int? GetMotionUnLockConditionGroup(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return new int?(motionConfig.Value.CondGroupId);
	}

	// Token: 0x06010B3C RID: 68412 RVA: 0x00492F7C File Offset: 0x0049117C
	public int? GetMotionRoleId(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return new int?(motionConfig.Value.RoleId);
	}

	// Token: 0x06010B3D RID: 68413 RVA: 0x00492FB8 File Offset: 0x004911B8
	public int? GetMotionType(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return new int?(motionConfig.Value.Type);
	}

	// Token: 0x06010B3E RID: 68414 RVA: 0x00492FF4 File Offset: 0x004911F4
	public int? GetMotionSort(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return new int?(motionConfig.Value.Sort);
	}

	// Token: 0x06010B3F RID: 68415 RVA: 0x00493030 File Offset: 0x00491230
	public string GetMotionImg(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return motionConfig.Value.MotionImg;
	}

	// Token: 0x06010B40 RID: 68416 RVA: 0x00493060 File Offset: 0x00491260
	public string GetMotionAnimation(int id)
	{
		Motion? motionConfig = this.GetMotionConfig(id);
		if (motionConfig == null)
		{
			return null;
		}
		return motionConfig.Value.AniMontage;
	}
}
