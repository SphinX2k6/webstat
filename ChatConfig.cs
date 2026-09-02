using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001836 RID: 6198
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ChatConfig : ConfigBase<ChatConfig>
{
	// Token: 0x0600B0F3 RID: 45299 RVA: 0x002F3CAF File Offset: 0x002F1EAF
	public Chat? GetChatConfig(int configId)
	{
		return ConfigChatById.GetConfig(configId, true);
	}

	// Token: 0x0600B0F4 RID: 45300 RVA: 0x002F3CB8 File Offset: 0x002F1EB8
	public IReadOnlyList<QuickChat> GetAllQuickChatConfigList()
	{
		return ConfigQuickChatAll.GetConfigList(true);
	}

	// Token: 0x0600B0F5 RID: 45301 RVA: 0x002F3CC0 File Offset: 0x002F1EC0
	public IReadOnlyList<ChatExpression> GetAllExpressionConfigByGroupId(int expressionGroupId)
	{
		return ConfigChatExpressionByGroupId.GetConfigList(expressionGroupId, true);
	}

	// Token: 0x0600B0F6 RID: 45302 RVA: 0x002F3CC9 File Offset: 0x002F1EC9
	public IReadOnlyList<ChatExpressionGroup> GetAllExpressionGroupConfig()
	{
		return ConfigChatExpressionGroupAll.GetConfigList(true);
	}

	// Token: 0x0600B0F7 RID: 45303 RVA: 0x002F3CD1 File Offset: 0x002F1ED1
	public ChatExpressionGroup? GetExpressionGroupConfig(int groupId)
	{
		return ConfigChatExpressionGroupById.GetConfig(groupId, true);
	}

	// Token: 0x0600B0F8 RID: 45304 RVA: 0x002F3CDA File Offset: 0x002F1EDA
	public ChatExpression? GetExpressionConfig(int expressionId)
	{
		return ConfigChatExpressionById.GetConfig(expressionId, true);
	}

	// Token: 0x0600B0F9 RID: 45305 RVA: 0x002F3CE3 File Offset: 0x002F1EE3
	public IReadOnlyList<ChatExpression> GetAllExpressionConfig()
	{
		return ConfigChatExpressionAll.GetConfigList(true);
	}
}
