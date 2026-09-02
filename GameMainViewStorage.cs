using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;

// Token: 0x02001D18 RID: 7448
[NullableContext(1)]
[Nullable(0)]
public class GameMainViewStorage : IStaticVariableResetter
{
	// Token: 0x0600DAE2 RID: 56034 RVA: 0x003AC78E File Offset: 0x003AA98E
	static GameMainViewStorage()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GameMainViewStorage.CreateStaticDefaultValue), new Action(GameMainViewStorage.ResetStaticDefaultValue));
	}

	// Token: 0x0600DAE3 RID: 56035 RVA: 0x003AC7AD File Offset: 0x003AA9AD
	public static void CreateStaticDefaultValue()
	{
		GameMainViewStorage.MainViewInfoMap = new Dictionary<EDungeonSubType, Type>();
		GameMainViewStorage.MainViewInfoMapWorldInstance = new Dictionary<EWorldDungeonSubType, Type>();
		GameMainViewStorage.OtherMainViewInfoMap = new Dictionary<EDungeonSubType, EUiViewName>();
	}

	// Token: 0x0600DAE4 RID: 56036 RVA: 0x003AC7CD File Offset: 0x003AA9CD
	public static void ResetStaticDefaultValue()
	{
		GameMainViewStorage.MainViewInfoMap = null;
		GameMainViewStorage.MainViewInfoMapWorldInstance = null;
		GameMainViewStorage.OtherMainViewInfoMap = null;
	}

	// Token: 0x0600DAE5 RID: 56037 RVA: 0x003AC7E1 File Offset: 0x003AA9E1
	public static void RegisterMainViewInfo(EDungeonSubType dungeonSubType, Type viewProxy)
	{
		GameMainViewStorage.MainViewInfoMap[dungeonSubType] = viewProxy;
	}

	// Token: 0x0600DAE6 RID: 56038 RVA: 0x003AC7EF File Offset: 0x003AA9EF
	public static void RegisterMainViewInfoWorldInstance(EWorldDungeonSubType worldDungeonType, Type viewProxy)
	{
		GameMainViewStorage.MainViewInfoMapWorldInstance[worldDungeonType] = viewProxy;
	}

	// Token: 0x0600DAE7 RID: 56039 RVA: 0x003AC7FD File Offset: 0x003AA9FD
	public static void RegisterOtherMainViewInfo(EDungeonSubType dungeonSubType, EUiViewName viewName)
	{
		GameMainViewStorage.OtherMainViewInfoMap[dungeonSubType] = viewName;
	}

	// Token: 0x0600DAE8 RID: 56040 RVA: 0x003AC80C File Offset: 0x003AAA0C
	[NullableContext(2)]
	public static Type GetMainViewInfo(EDungeonSubType dungeonSubType, EWorldDungeonSubType worldDungeonType)
	{
		if (dungeonSubType == EDungeonSubType.WorldInstance)
		{
			Type result;
			if (!GameMainViewStorage.MainViewInfoMapWorldInstance.TryGetValue(worldDungeonType, out result))
			{
				return null;
			}
			return result;
		}
		else
		{
			Type result2;
			if (!GameMainViewStorage.MainViewInfoMap.TryGetValue(dungeonSubType, out result2))
			{
				return null;
			}
			return result2;
		}
	}

	// Token: 0x0600DAE9 RID: 56041 RVA: 0x003AC844 File Offset: 0x003AAA44
	public static EUiViewName GetMainViewName(EDungeonSubType dungeonSubType, EWorldDungeonSubType worldDungeonType)
	{
		if (dungeonSubType == EDungeonSubType.WorldInstance && GameMainViewStorage.MainViewInfoMapWorldInstance.ContainsKey(worldDungeonType))
		{
			return EUiViewName.CommonGameMainView;
		}
		EUiViewName? valueOrNull = GameMainViewStorage.OtherMainViewInfoMap.GetValueOrNull(dungeonSubType);
		if (valueOrNull != null)
		{
			return valueOrNull.Value;
		}
		if (GameMainViewStorage.MainViewInfoMap.ContainsKey(dungeonSubType))
		{
			return EUiViewName.CommonGameMainView;
		}
		return EUiViewName.BattleView;
	}

	// Token: 0x04006874 RID: 26740
	private static Dictionary<EDungeonSubType, Type> MainViewInfoMap;

	// Token: 0x04006875 RID: 26741
	private static Dictionary<EWorldDungeonSubType, Type> MainViewInfoMapWorldInstance;

	// Token: 0x04006876 RID: 26742
	private static Dictionary<EDungeonSubType, EUiViewName> OtherMainViewInfoMap;
}
