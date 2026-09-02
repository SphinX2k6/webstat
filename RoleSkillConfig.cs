using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020028A4 RID: 10404
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleSkillConfig : ConfigBase<RoleSkillConfig>
{
	// Token: 0x06014A84 RID: 84612 RVA: 0x005B901C File Offset: 0x005B721C
	public Aki.Config.Skill? GetSkillConfigById(int skillId)
	{
		Aki.Config.Skill? config = ConfigSkillById.GetConfig(skillId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "当前选中的技能配置为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", skillId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06014A85 RID: 84613 RVA: 0x005B9068 File Offset: 0x005B7268
	public unsafe SkillLevel? GetSkillLevelConfigByGroupIdAndLevel(int skillLevelGroupId, int level)
	{
		SkillLevel? config = ConfigSkillLevelBySkillLevelGroupIdAndSkillId.GetConfig(skillLevelGroupId, level, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "技能配置为空";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillLevelGroupId", skillLevelGroupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("level", level);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}

	// Token: 0x06014A86 RID: 84614 RVA: 0x005B90E5 File Offset: 0x005B72E5
	public IReadOnlyList<SkillLevel> GetSkillLevelConfigList(int skillId)
	{
		return ConfigSkillLevelBySkillLevelGroupId.GetConfigList(skillId, true);
	}

	// Token: 0x06014A87 RID: 84615 RVA: 0x005B90F0 File Offset: 0x005B72F0
	public string GetSkillTypeNameLocalText(int skillTypeId)
	{
		SkillType? config = ConfigSkillTypeById.GetConfig(skillTypeId, true);
		if (config != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(config.Value.TypeName, null);
		}
		return null;
	}

	// Token: 0x06014A88 RID: 84616 RVA: 0x005B9125 File Offset: 0x005B7325
	public IReadOnlyList<Aki.Config.Skill> GetSkillList(int skillGroupId)
	{
		return ConfigSkillBySkillGroupId.GetConfigList(skillGroupId, true);
	}

	// Token: 0x06014A89 RID: 84617 RVA: 0x005B9130 File Offset: 0x005B7330
	public SkillTree? GetSkillTreeNode(int nodeId)
	{
		SkillTree? config = ConfigSkillTreeById.GetConfig(nodeId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "技能树配置为空，Id = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("nodeId", nodeId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06014A8A RID: 84618 RVA: 0x005B917B File Offset: 0x005B737B
	public IReadOnlyList<SkillTree> GetSkillTreeNodeListByGroupId(int nodeGroupId)
	{
		return ConfigSkillTreeByNodeGroup.GetConfigList(nodeGroupId, true);
	}

	// Token: 0x06014A8B RID: 84619 RVA: 0x005B9184 File Offset: 0x005B7384
	public SkillTree? GetSkillTreeNodeByGroupIdAndIndex(int nodeGroupId, int nodeIndex)
	{
		SkillTree? config = ConfigSkillTreeByNodeGroupAndNodeIndex.GetConfig(nodeGroupId, nodeIndex, true);
		if (config == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.LZK, "技能树配置为空，NodeGroup = " + nodeGroupId.ToString() + ", NodeIndex = " + nodeIndex.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return config;
	}

	// Token: 0x06014A8C RID: 84620 RVA: 0x005B91D8 File Offset: 0x005B73D8
	public SkillTree? GetSkillTreeNodeByGroupIdAndSkillId(int nodeGroupId, int skillId)
	{
		IReadOnlyList<SkillTree> skillTreeNodeListByGroupId = this.GetSkillTreeNodeListByGroupId(nodeGroupId);
		if (skillTreeNodeListByGroupId == null)
		{
			return null;
		}
		foreach (SkillTree value in skillTreeNodeListByGroupId)
		{
			if (value.SkillId == skillId)
			{
				return new SkillTree?(value);
			}
		}
		return null;
	}

	// Token: 0x06014A8D RID: 84621 RVA: 0x005B9250 File Offset: 0x005B7450
	public SkillCondition? GetSkillConditionById(int skillConditionId)
	{
		SkillCondition? config = ConfigSkillConditionById.GetConfig(skillConditionId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "技能条件配置为空，Id = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillConditionId", skillConditionId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06014A8E RID: 84622 RVA: 0x005B929B File Offset: 0x005B749B
	[NullableContext(1)]
	public IEnumerable<DicIntInt?> GetRoleSkillTreeConsume(int skillNodeId, int level)
	{
		RoleSkillConfig.<GetRoleSkillTreeConsume>d__10 <GetRoleSkillTreeConsume>d__ = new RoleSkillConfig.<GetRoleSkillTreeConsume>d__10(-2);
		<GetRoleSkillTreeConsume>d__.<>4__this = this;
		<GetRoleSkillTreeConsume>d__.<>3__skillNodeId = skillNodeId;
		<GetRoleSkillTreeConsume>d__.<>3__level = level;
		return <GetRoleSkillTreeConsume>d__;
	}

	// Token: 0x06014A8F RID: 84623 RVA: 0x005B92BC File Offset: 0x005B74BC
	public SkillDescription? GetRoleSkillDescriptionConfigById(int id)
	{
		SkillDescription? config = ConfigSkillDescriptionById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "技能描述配置为空，Id = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06014A90 RID: 84624 RVA: 0x005B9308 File Offset: 0x005B7508
	public IReadOnlyList<SkillDescription> GetAllRoleSkillDescConfigByGroupId(int groupId)
	{
		IReadOnlyList<SkillDescription> configList = ConfigSkillDescriptionBySkillLevelGroupId.GetConfigList(groupId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "技能描述配置为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("GroupId", groupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return configList;
	}

	// Token: 0x06014A91 RID: 84625 RVA: 0x005B934C File Offset: 0x005B754C
	public SkillInput? GetSkillInputConfigById(int skillInputId)
	{
		SkillInput? config = ConfigSkillInputById.GetConfig(skillInputId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "技能出招表配置为空，Id = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillInputId", skillInputId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06014A92 RID: 84626 RVA: 0x005B9397 File Offset: 0x005B7597
	public RoleSkillInput? GetRoleSkillInputConfigById(int roleId)
	{
		return ConfigRoleSkillInputById.GetConfig(roleId, true);
	}

	// Token: 0x06014A93 RID: 84627 RVA: 0x005B93A0 File Offset: 0x005B75A0
	public int? GetRoleSkillMaxLevelBySkillNodeId(int skillNodeId)
	{
		int skillId = this.GetSkillTreeNode(skillNodeId).Value.SkillId;
		if (skillId <= 0)
		{
			return null;
		}
		Aki.Config.Skill? skillConfigById = this.GetSkillConfigById(skillId);
		if (skillConfigById == null)
		{
			return null;
		}
		return new int?(skillConfigById.GetValueOrDefault().MaxSkillLevel);
	}

	// Token: 0x06014A94 RID: 84628 RVA: 0x005B9408 File Offset: 0x005B7608
	public RoleSkillFightTrick[] GetRoleSkillFightTrickList(int roleId)
	{
		IReadOnlyList<RoleSkillFightTrick> configList = ConfigRoleSkillFightTrickByRoleId.GetConfigList(roleId, true);
		if (configList.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "没有找到任意的战斗技巧表数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return configList.ToArray<RoleSkillFightTrick>();
	}
}
