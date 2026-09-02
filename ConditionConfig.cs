using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000E5D RID: 3677
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ConditionConfig : ConfigBase<ConditionConfig>
{
	// Token: 0x06005889 RID: 22665 RVA: 0x00106F2C File Offset: 0x0010512C
	public ConditionGroup? GetConditionGroupConfig(int conditionGroupId)
	{
		ConditionGroup? config = ConfigConditionGroupById.GetConfig(conditionGroupId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.TL;
			string message = "获取条件组配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("conditionGroupId", conditionGroupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new ConditionGroup?(config.Value);
	}

	// Token: 0x0600588A RID: 22666 RVA: 0x00106F8C File Offset: 0x0010518C
	public Condition? GetConditionConfig(int conditionId)
	{
		Condition? config = ConfigConditionById.GetConfig(conditionId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.TL;
			string message = "获取条件配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("conditionId", conditionId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new Condition?(config.Value);
	}

	// Token: 0x0600588B RID: 22667 RVA: 0x00106FEC File Offset: 0x001051EC
	public Condition? GetConditionConfigByType(int conditionGroupId, string type)
	{
		ConditionGroup? conditionGroupConfig = this.GetConditionGroupConfig(conditionGroupId);
		if (conditionGroupConfig != null)
		{
			foreach (int conditionId in conditionGroupConfig.Value.GroupId())
			{
				Condition? conditionConfig = this.GetConditionConfig(conditionId);
				if (type == ((conditionConfig != null) ? conditionConfig.GetValueOrDefault().Type : null))
				{
					return conditionConfig;
				}
			}
		}
		return null;
	}

	// Token: 0x0600588C RID: 22668 RVA: 0x00107068 File Offset: 0x00105268
	public int[] GetGroupConditionIds(int conditionGroupId)
	{
		ConditionGroup? conditionGroupConfig = this.GetConditionGroupConfig(conditionGroupId);
		if (conditionGroupConfig == null)
		{
			return new int[0];
		}
		return conditionGroupConfig.Value.GroupId();
	}
}
