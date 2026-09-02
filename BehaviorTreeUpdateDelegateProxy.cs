using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;

// Token: 0x02001DBB RID: 7611
[NullableContext(1)]
[Nullable(0)]
public class BehaviorTreeUpdateDelegateProxy
{
	// Token: 0x0600E0EB RID: 57579 RVA: 0x003C78DC File Offset: 0x003C5ADC
	public void Init()
	{
		this.Clear();
	}

	// Token: 0x0600E0EC RID: 57580 RVA: 0x003C78E4 File Offset: 0x003C5AE4
	public void Clear()
	{
		this.TempTreeVarDelegateMap.Clear();
		this.BehaviorTreeVarMap.Clear();
	}

	// Token: 0x0600E0ED RID: 57581 RVA: 0x003C78FC File Offset: 0x003C5AFC
	public void SetBehaviorTreeVarRelation(Dictionary<string, string> varType2VarNameMap)
	{
		this.BehaviorTreeVarMap.Clear();
		InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
		foreach (KeyValuePair<string, string> keyValuePair in varType2VarNameMap)
		{
			string text;
			string text2;
			keyValuePair.Deconstruct(out text, out text2);
			string key = text;
			string text3 = text2;
			this.BehaviorTreeVarMap[key] = text3;
			HashSet<TTreeVarUpdateDelegate> hashSet;
			if (this.TempTreeVarDelegateMap.TryGetValue(key, out hashSet) && instanceDungeonInfo != null && instanceDungeonInfo.Tree != null)
			{
				foreach (TTreeVarUpdateDelegate ttreeVarUpdateDelegate in hashSet)
				{
					instanceDungeonInfo.Tree.AddTreeVarUpdateDelegate(text3, ttreeVarUpdateDelegate);
					ttreeVarUpdateDelegate(null, instanceDungeonInfo.Tree.GetTreeVarByKey(text3));
				}
				this.TempTreeVarDelegateMap.Remove(key);
			}
		}
	}

	// Token: 0x0600E0EE RID: 57582 RVA: 0x003C7A04 File Offset: 0x003C5C04
	[return: Nullable(2)]
	public VarDefinePb GetBehaviorTreeVar(string varType)
	{
		string key;
		if (!this.BehaviorTreeVarMap.TryGetValue(varType, out key))
		{
			return null;
		}
		InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
		if (instanceDungeonInfo == null)
		{
			return null;
		}
		BaseBehaviorTree tree = instanceDungeonInfo.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetTreeVarByKey(key);
	}

	// Token: 0x0600E0EF RID: 57583 RVA: 0x003C7A44 File Offset: 0x003C5C44
	public long GetBehaviorTreeVarToNumber(string varType)
	{
		VarDefinePb behaviorTreeVar = this.GetBehaviorTreeVar(varType);
		if (behaviorTreeVar == null)
		{
			return 0L;
		}
		return behaviorTreeVar.Int;
	}

	// Token: 0x0600E0F0 RID: 57584 RVA: 0x003C7A5C File Offset: 0x003C5C5C
	public void AddTreeVarUpdateDelegate(string varType, TTreeVarUpdateDelegate @delegate)
	{
		InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
		if (instanceDungeonInfo == null || instanceDungeonInfo.Tree == null)
		{
			return;
		}
		string key;
		if (this.BehaviorTreeVarMap.TryGetValue(varType, out key))
		{
			instanceDungeonInfo.Tree.AddTreeVarUpdateDelegate(key, @delegate);
			return;
		}
		this.SaveTempTreeVarDelegate(varType, @delegate);
	}

	// Token: 0x0600E0F1 RID: 57585 RVA: 0x003C7AA8 File Offset: 0x003C5CA8
	public void RemoveTreeVarUpdateDelegate(string varType, TTreeVarUpdateDelegate @delegate)
	{
		InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
		if (instanceDungeonInfo == null || instanceDungeonInfo.Tree == null)
		{
			return;
		}
		string key;
		if (this.BehaviorTreeVarMap.TryGetValue(varType, out key))
		{
			instanceDungeonInfo.Tree.RemoveTreeVarUpdateDelegate(key, @delegate);
			return;
		}
		this.RemoveTempTreeVarDelegate(varType, @delegate);
	}

	// Token: 0x0600E0F2 RID: 57586 RVA: 0x003C7AF4 File Offset: 0x003C5CF4
	private void SaveTempTreeVarDelegate(string varType, TTreeVarUpdateDelegate @delegate)
	{
		HashSet<TTreeVarUpdateDelegate> hashSet;
		if (!this.TempTreeVarDelegateMap.TryGetValue(varType, out hashSet))
		{
			hashSet = (this.TempTreeVarDelegateMap[varType] = new HashSet<TTreeVarUpdateDelegate>());
		}
		hashSet.Add(@delegate);
	}

	// Token: 0x0600E0F3 RID: 57587 RVA: 0x003C7B2C File Offset: 0x003C5D2C
	private void RemoveTempTreeVarDelegate(string varType, TTreeVarUpdateDelegate @delegate)
	{
		HashSet<TTreeVarUpdateDelegate> hashSet;
		if (this.TempTreeVarDelegateMap.TryGetValue(varType, out hashSet))
		{
			hashSet.Remove(@delegate);
		}
	}

	// Token: 0x04006BCE RID: 27598
	private readonly Dictionary<string, string> BehaviorTreeVarMap = new Dictionary<string, string>();

	// Token: 0x04006BCF RID: 27599
	private readonly Dictionary<string, HashSet<TTreeVarUpdateDelegate>> TempTreeVarDelegateMap = new Dictionary<string, HashSet<TTreeVarUpdateDelegate>>();
}
