using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000E65 RID: 3685
public class StatDefine : IStaticVariableResetter
{
	// Token: 0x060058CB RID: 22731 RVA: 0x001086C6 File Offset: 0x001068C6
	static StatDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(StatDefine.CreateStaticDefaultValue), new Action(StatDefine.ResetStaticDefaultValue));
	}

	// Token: 0x060058CC RID: 22732 RVA: 0x001086E8 File Offset: 0x001068E8
	[return: Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private static Dictionary<string, Stat> InitializeBattleStat()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("BulletTick", "Bullet Tick");
		dictionary.Add("BulletAfterTick", "Bullet AfterTick");
		dictionary.Add("MonsterTick", "Monster Tick");
		dictionary.Add("FightCameraTick", "FightCamera Tick");
		dictionary.Add("BulletCreate", "Bullet Create");
		dictionary.Add("BulletDestroy", "Bullet Destroy");
		Dictionary<string, Stat> dictionary2 = new Dictionary<string, Stat>();
		foreach (KeyValuePair<string, string> keyValuePair in dictionary)
		{
			dictionary2[keyValuePair.Key] = Stat.CreateNoFlameGraph(keyValuePair.Value, "", "STATGROUP_KuroBattle");
		}
		return dictionary2;
	}

	// Token: 0x060058CD RID: 22733 RVA: 0x001087C0 File Offset: 0x001069C0
	[NullableContext(1)]
	private static void StatConsoleCommand(UObject worldContextObject, string command, [Nullable(2)] APlayerController specificPlayer = null)
	{
		double microseconds = KuroTime.GetMicroseconds64();
		Action<UObject, string, APlayerController> action = StatDefine.orgExecuteConsoleCommand;
		if (action != null)
		{
			action(worldContextObject, command, specificPlayer);
		}
		double num = KuroTime.GetMicroseconds64() - microseconds;
		string key = command.Replace("[ .]+", "_");
		FKuroPerfSightHelper.PostValueFloat1("ExecuteConsoleCommand", key, (float)num);
	}

	// Token: 0x060058CE RID: 22734 RVA: 0x0010880C File Offset: 0x00106A0C
	public static void InitStatConsoleCommand()
	{
		Action<UObject, string, APlayerController> action;
		if ((action = StatDefine.<>O.<0>__ExecuteConsoleCommand) == null)
		{
			action = (StatDefine.<>O.<0>__ExecuteConsoleCommand = new Action<UObject, string, APlayerController>(UKismetSystemLibrary.ExecuteConsoleCommand));
		}
		StatDefine.orgExecuteConsoleCommand = action;
	}

	// Token: 0x060058CF RID: 22735 RVA: 0x0010882E File Offset: 0x00106A2E
	public static void CreateStaticDefaultValue()
	{
		StatDefine.battleStat = StatDefine.InitializeBattleStat();
	}

	// Token: 0x060058D0 RID: 22736 RVA: 0x0010883A File Offset: 0x00106A3A
	public static void ResetStaticDefaultValue()
	{
		StatDefine.battleStat = null;
		StatDefine.orgExecuteConsoleCommand = null;
	}

	// Token: 0x04002945 RID: 10565
	public const bool BATTLESTAT_ENABLED = true;

	// Token: 0x04002946 RID: 10566
	[Nullable(1)]
	public const string BATTLESTAT_GROUP = "STATGROUP_KuroBattle";

	// Token: 0x04002947 RID: 10567
	[Nullable(new byte[]
	{
		2,
		1,
		2
	})]
	public static Dictionary<string, Stat> battleStat;

	// Token: 0x04002948 RID: 10568
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		2
	})]
	private static Action<UObject, string, APlayerController> orgExecuteConsoleCommand;

	// Token: 0x02007296 RID: 29334
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027BE7 RID: 162791
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			2
		})]
		public static Action<UObject, string, APlayerController> <0>__ExecuteConsoleCommand;
	}
}
