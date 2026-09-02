using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02001DA7 RID: 7591
public class TrapDefenseBattleGuideManager : IStaticVariableResetter
{
	// Token: 0x0600E00D RID: 57357 RVA: 0x003C466D File Offset: 0x003C286D
	static TrapDefenseBattleGuideManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TrapDefenseBattleGuideManager.CreateStaticDefaultValue), new Action(TrapDefenseBattleGuideManager.ResetStaticDefaultValue));
	}

	// Token: 0x0600E00E RID: 57358 RVA: 0x003C468C File Offset: 0x003C288C
	public static void CreateStaticDefaultValue()
	{
		TrapDefenseBattleGuideManager.CurrentDataMap = new Dictionary<ETrapDefensePlayerOperationType, TrapDefenseBattleGuideData>();
	}

	// Token: 0x0600E00F RID: 57359 RVA: 0x003C4698 File Offset: 0x003C2898
	public static void ResetStaticDefaultValue()
	{
		TrapDefenseBattleGuideManager.CurrentDataMap = null;
	}

	// Token: 0x0600E010 RID: 57360 RVA: 0x003C46A0 File Offset: 0x003C28A0
	public static void Initialize()
	{
	}

	// Token: 0x0600E011 RID: 57361 RVA: 0x003C46A2 File Offset: 0x003C28A2
	public static void Clear()
	{
		TrapDefenseBattleGuideManager.CurrentDataMap.Clear();
	}

	// Token: 0x0600E012 RID: 57362 RVA: 0x003C46B0 File Offset: 0x003C28B0
	[NullableContext(1)]
	public static void RegisterBehaviorTreeGuideData(TrapDefensePlayerOperationConstraint param)
	{
		if (param.IsConstrained)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.TowerDefenseBattle;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "注册塔防行为约束";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", param.DisableOperation.Type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			TrapDefenseBattleGuideData trapDefenseBattleGuideData = new TrapDefenseBattleGuideData();
			trapDefenseBattleGuideData.BanType = param.DisableOperation.Type;
			trapDefenseBattleGuideData.Tips = param.TidPromptTxt;
			TrapDefenseBattleGuideManager.CurrentDataMap[param.DisableOperation.Type] = trapDefenseBattleGuideData;
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.TowerDefenseBattle;
		ELogAuthor author2 = ELogAuthor.XXJ;
		string message2 = "删除塔防行为约束";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", param.DisableOperation.Type);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		TrapDefenseBattleGuideManager.CurrentDataMap.Remove(param.DisableOperation.Type);
	}

	// Token: 0x0600E013 RID: 57363 RVA: 0x003C4788 File Offset: 0x003C2988
	public static bool CheckCanExecuteAndShowFailTips(ETrapDefensePlayerOperationType type)
	{
		if (TrapDefenseBattleGuideManager.CurrentDataMap.Count <= 0)
		{
			return true;
		}
		TrapDefenseBattleGuideData trapDefenseBattleGuideData;
		if (TrapDefenseBattleGuideManager.CurrentDataMap.TryGetValue(type, out trapDefenseBattleGuideData))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(trapDefenseBattleGuideData.Tips, Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x04006B91 RID: 27537
	[Nullable(1)]
	private static Dictionary<ETrapDefensePlayerOperationType, TrapDefenseBattleGuideData> CurrentDataMap;
}
