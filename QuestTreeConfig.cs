using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002694 RID: 9876
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class QuestTreeConfig : ConfigBase<QuestTreeConfig>
{
	// Token: 0x060137D2 RID: 79826 RVA: 0x0056F86C File Offset: 0x0056DA6C
	protected override bool OnInit()
	{
		foreach (QuestTreeCustomJumpConfig value in this.GetAllCustomGotoConfig())
		{
			Dictionary<string, QuestTreeCustomJumpConfig> dictionary;
			if (!this.CustomGotoConfigMap.TryGetValue(value.QuestId, out dictionary))
			{
				dictionary = new Dictionary<string, QuestTreeCustomJumpConfig>();
				this.CustomGotoConfigMap[value.QuestId] = dictionary;
			}
			dictionary[value.PreConditionType] = value;
		}
		return true;
	}

	// Token: 0x060137D3 RID: 79827 RVA: 0x0056F8F0 File Offset: 0x0056DAF0
	protected override bool OnClear()
	{
		foreach (KeyValuePair<int, Dictionary<string, QuestTreeCustomJumpConfig>> keyValuePair in this.CustomGotoConfigMap)
		{
			keyValuePair.Value.Clear();
		}
		this.CustomGotoConfigMap.Clear();
		return true;
	}

	// Token: 0x060137D4 RID: 79828 RVA: 0x0056F954 File Offset: 0x0056DB54
	public IReadOnlyList<QuestTreeChapter> GetAllChapters()
	{
		return ConfigQuestTreeChapterAll.GetConfigList(true) ?? new List<QuestTreeChapter>();
	}

	// Token: 0x060137D5 RID: 79829 RVA: 0x0056F965 File Offset: 0x0056DB65
	public QuestTreeChapter? GetChapterById(int chapterId)
	{
		return ConfigQuestTreeChapterById.GetConfig(chapterId, true);
	}

	// Token: 0x060137D6 RID: 79830 RVA: 0x0056F96E File Offset: 0x0056DB6E
	public IReadOnlyList<QuestTreeNode> GetNodeListByChapterId(int chapterId)
	{
		return ConfigQuestTreeNodeByChapterId.GetConfigList(chapterId, true) ?? new List<QuestTreeNode>();
	}

	// Token: 0x060137D7 RID: 79831 RVA: 0x0056F980 File Offset: 0x0056DB80
	public QuestTreeNode? GetNodeById(int nodeId)
	{
		return ConfigQuestTreeNodeById.GetConfig(nodeId, true);
	}

	// Token: 0x060137D8 RID: 79832 RVA: 0x0056F989 File Offset: 0x0056DB89
	public QuestTreeNodeUnlock? GetNodeUnlockConditionById(int unlockId)
	{
		return ConfigQuestTreeNodeUnlockById.GetConfig(unlockId, true);
	}

	// Token: 0x060137D9 RID: 79833 RVA: 0x0056F992 File Offset: 0x0056DB92
	public NodeUnlockDefault? GetNodeUnlockConditionDefaultConfigByType(string type)
	{
		return ConfigNodeUnlockDefaultById.GetConfig(type, true);
	}

	// Token: 0x060137DA RID: 79834 RVA: 0x0056F99C File Offset: 0x0056DB9C
	public int GetMoonChasingQuestId()
	{
		return ConfigCommonParamById.GetIntConfig("MoonChasingQuestId").GetValueOrDefault();
	}

	// Token: 0x060137DB RID: 79835 RVA: 0x0056F9BC File Offset: 0x0056DBBC
	public float GetScrollingScaleDelta()
	{
		return ConfigCommonParamById.GetFloatConfig("QuestTreeScrollingScaleDelta").GetValueOrDefault(0.01f);
	}

	// Token: 0x060137DC RID: 79836 RVA: 0x0056F9E0 File Offset: 0x0056DBE0
	public QuestTreeCustomJumpConfig? GetCustomGotoConfigByQuestIdAndType(int questId, string type)
	{
		Dictionary<string, QuestTreeCustomJumpConfig> dictionary;
		QuestTreeCustomJumpConfig value;
		if (this.CustomGotoConfigMap.TryGetValue(questId, out dictionary) && dictionary.TryGetValue(type, out value))
		{
			return new QuestTreeCustomJumpConfig?(value);
		}
		return null;
	}

	// Token: 0x060137DD RID: 79837 RVA: 0x0056FA18 File Offset: 0x0056DC18
	public IReadOnlyList<QuestTreeCustomJumpConfig> GetAllCustomGotoConfig()
	{
		return ConfigQuestTreeCustomJumpConfigAll.GetConfigList(true) ?? new List<QuestTreeCustomJumpConfig>();
	}

	// Token: 0x040097C9 RID: 38857
	private readonly Dictionary<int, Dictionary<string, QuestTreeCustomJumpConfig>> CustomGotoConfigMap = new Dictionary<int, Dictionary<string, QuestTreeCustomJumpConfig>>();
}
