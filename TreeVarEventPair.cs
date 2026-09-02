using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Monster.Common;
using CSharpScript.Game.Module.InstanceDungeon;
using UnrealEngine;

// Token: 0x02000D03 RID: 3331
[NullableContext(1)]
[Nullable(0)]
public class TreeVarEventPair : LevelVarEventPair
{
	// Token: 0x060042A0 RID: 17056 RVA: 0x0007791C File Offset: 0x00075B1C
	public unsafe override bool Init(SAiLevelVar levelVar, UKuroBooleanEventBinder boolEventBinder)
	{
		base.Init(levelVar, boolEventBinder);
		EAiLevelVarSource eaiLevelVarSource = levelVar.VarSource;
		if (eaiLevelVarSource != EAiLevelVarSource.Quest)
		{
			if (eaiLevelVarSource != EAiLevelVarSource.LevelPlay)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.CH;
				string message = "添加监听的变量来源非树";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", levelVar.VarName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Source", eaiLevelVarSource);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (!this.ParseLevelPlayerValue(true))
			{
				return false;
			}
		}
		else if (!this.ParseQuestTreeValue(true))
		{
			return false;
		}
		this.IsInit = true;
		return true;
	}

	// Token: 0x060042A1 RID: 17057 RVA: 0x000779C4 File Offset: 0x00075BC4
	public unsafe override bool Init(SAiLevelVar levelVar, UKuroIntEventBinder intEventBinder)
	{
		base.Init(levelVar, intEventBinder);
		EAiLevelVarSource eaiLevelVarSource = levelVar.VarSource;
		if (eaiLevelVarSource != EAiLevelVarSource.Quest)
		{
			if (eaiLevelVarSource != EAiLevelVarSource.LevelPlay)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.CH;
				string message = "添加监听的变量来源非树";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", levelVar.VarName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Source", eaiLevelVarSource);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (!this.ParseLevelPlayerValue(true))
			{
				return false;
			}
		}
		else if (!this.ParseQuestTreeValue(true))
		{
			return false;
		}
		this.IsInit = true;
		return true;
	}

	// Token: 0x060042A2 RID: 17058 RVA: 0x00077A6C File Offset: 0x00075C6C
	public unsafe void OnReceiveTreeVar()
	{
		if (!this.IsInit)
		{
			return;
		}
		EAiLevelVarSource eaiLevelVarSource = this.LevelVar.VarSource;
		if (eaiLevelVarSource == EAiLevelVarSource.Quest)
		{
			this.ParseQuestTreeValue(false);
			return;
		}
		if (eaiLevelVarSource == EAiLevelVarSource.LevelPlay)
		{
			this.ParseLevelPlayerValue(false);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.AI;
		ELogAuthor author = ELogAuthor.CH;
		string message = "添加监听的变量来源非树";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", this.LevelVar.VarName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Source", eaiLevelVarSource);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x060042A3 RID: 17059 RVA: 0x00077B10 File Offset: 0x00075D10
	private unsafe bool ParseQuestTreeValue(bool isInit = true)
	{
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.LevelVar.Id);
		BaseBehaviorTree baseBehaviorTree = (quest != null) ? quest.Tree : null;
		if (baseBehaviorTree == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CH;
			string message = "添加监听的变量来源树未找到";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", this.LevelVar.VarName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("QuestId", this.LevelVar.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		VarDefinePb treeVarByKey = baseBehaviorTree.GetTreeVarByKey(this.LevelVar.VarName);
		this.TreeIncId = new long?(baseBehaviorTree.TreeIncId);
		return base.ParseValue(treeVarByKey, isInit);
	}

	// Token: 0x060042A4 RID: 17060 RVA: 0x00077BDC File Offset: 0x00075DDC
	private unsafe bool ParseLevelPlayerValue(bool isInit = true)
	{
		int id = this.LevelVar.Id;
		global::LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(id);
		BaseBehaviorTree baseBehaviorTree = (levelPlayInfo != null) ? levelPlayInfo.Tree : null;
		if (baseBehaviorTree == null)
		{
			InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
			if (instanceDungeonInfo != null)
			{
				int? treeConfigId = instanceDungeonInfo.TreeConfigId;
				int num = id;
				if (treeConfigId.GetValueOrDefault() == num & treeConfigId != null)
				{
					baseBehaviorTree = instanceDungeonInfo.Tree;
				}
			}
		}
		if (baseBehaviorTree == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CH;
			string message = "添加监听的变量来源树未找到";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", this.LevelVar.VarName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("QuestId", this.LevelVar.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		VarDefinePb treeVarByKey = baseBehaviorTree.GetTreeVarByKey(this.LevelVar.VarName);
		this.TreeIncId = new long?(baseBehaviorTree.TreeIncId);
		return base.ParseValue(treeVarByKey, isInit);
	}

	// Token: 0x040010EF RID: 4335
	public long? TreeIncId;
}
