using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using UnrealEngine;

// Token: 0x02001DF6 RID: 7670
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GeneralLogicTreeConfigUtil : Singleton<GeneralLogicTreeConfigUtil>
{
	// Token: 0x0600E236 RID: 57910 RVA: 0x003CEA44 File Offset: 0x003CCC44
	public void InitConfig(string dir, Action<string> singleFileLoaded)
	{
		foreach (string text in UKuroStaticLibrary.GetFilesRecursive(dir, "*.json", true, false))
		{
			if (UBlueprintPathsLibrary.FileExists(text))
			{
				string text2 = "";
				UKuroStaticLibrary.LoadFileToString(ref text2, text);
				if (!string.IsNullOrEmpty(text2))
				{
					singleFileLoaded(text2);
				}
			}
		}
	}

	// Token: 0x0600E237 RID: 57911 RVA: 0x003CEAB8 File Offset: 0x003CCCB8
	public void InitBehaviorNodeConfig(Dictionary<int, Dictionary<int, IBtNode>> nodeConfig, int questId, IBehaviorTree tree)
	{
		Dictionary<int, IBtNode> dictionary;
		if (!nodeConfig.TryGetValue(questId, out dictionary))
		{
			dictionary = (nodeConfig[questId] = new Dictionary<int, IBtNode>());
		}
		Dictionary<int, IBtNode> dictionary2 = Aki.TDConfigMgr.Quest.Quest.FlatBehaviorTree(tree);
		dictionary.Clear();
		foreach (KeyValuePair<int, IBtNode> keyValuePair in dictionary2)
		{
			int num;
			IBtNode btNode;
			keyValuePair.Deconstruct(out num, out btNode);
			int key = num;
			IBtNode btNode2 = btNode;
			bool flag;
			if (GeneralLogicTreeConfigUtil.configNodesFilter.TryGetValue(btNode2.Type, out flag) && flag)
			{
				dictionary[key] = btNode2;
			}
		}
	}

	// Token: 0x0600E238 RID: 57912 RVA: 0x003CEB58 File Offset: 0x003CCD58
	public bool IsAlwaysFalseChildNode(long treeIncId, int? parentNodeId)
	{
		if (parentNodeId == null || parentNodeId.Value == 0)
		{
			return false;
		}
		BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
		if (behaviorTree == null)
		{
			return false;
		}
		IBtNode nodeConfig = behaviorTree.GetNodeConfig(parentNodeId.Value);
		return nodeConfig != null && (nodeConfig.Type == EBtNode.AlwaysFalse || this.IsAlwaysFalseChildNode(treeIncId, nodeConfig.ParentNodeId));
	}

	// Token: 0x0600E23A RID: 57914 RVA: 0x003CEBC4 File Offset: 0x003CCDC4
	// Note: this type is marked as 'beforefieldinit'.
	static GeneralLogicTreeConfigUtil()
	{
		Dictionary<EBtNode, bool> dictionary = new Dictionary<EBtNode, bool>();
		dictionary[EBtNode.Action] = true;
		dictionary[EBtNode.ActionWithResult] = true;
		dictionary[EBtNode.ChildQuest] = true;
		dictionary[EBtNode.QuestFailed] = true;
		dictionary[EBtNode.ParallelSelect] = true;
		dictionary[EBtNode.Start] = false;
		dictionary[EBtNode.QuestSucceed] = true;
		dictionary[EBtNode.AlwaysTrue] = true;
		dictionary[EBtNode.AlwaysFalse] = true;
		dictionary[EBtNode.Sequence] = true;
		dictionary[EBtNode.Select] = true;
		dictionary[EBtNode.Condition] = true;
		dictionary[EBtNode.ConditionSelector] = true;
		dictionary[EBtNode.Repeater] = true;
		GeneralLogicTreeConfigUtil.configNodesFilter = dictionary;
	}

	// Token: 0x04006CE9 RID: 27881
	[StaticVariableRuleIgnore]
	private static readonly IReadOnlyDictionary<EBtNode, bool> configNodesFilter;
}
