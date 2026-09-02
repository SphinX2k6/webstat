using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

// Token: 0x02002F96 RID: 12182
public class GameplayCueController : IStaticVariableResetter
{
	// Token: 0x06018D7D RID: 101757 RVA: 0x00708E99 File Offset: 0x00707099
	static GameplayCueController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GameplayCueController.CreateStaticDefaultValue), new Action(GameplayCueController.ResetStaticDefaultValue));
	}

	// Token: 0x06018D7E RID: 101758 RVA: 0x00708EB8 File Offset: 0x007070B8
	public static GameplayCue? GetConfigById(long cueId)
	{
		GameplayCue? config = ConfigGameplayCueById.GetConfig(cueId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "无法找到Cue配置！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cueId", cueId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06018D7F RID: 101759 RVA: 0x00708F0D File Offset: 0x0070710D
	public static int GenerateHandle()
	{
		return ++GameplayCueController.LastHandle;
	}

	// Token: 0x06018D80 RID: 101760 RVA: 0x00708F1C File Offset: 0x0070711C
	[NullableContext(2)]
	public static EMaterial GetMaterialType(UObject materielObject)
	{
		if (materielObject is PD_CharacterControllerData_C)
		{
			return EMaterial.Data;
		}
		if (materielObject is PD_CharacterControllerDataGroup_C)
		{
			return EMaterial.DataGroup;
		}
		return EMaterial.Other;
	}

	// Token: 0x06018D81 RID: 101761 RVA: 0x00708F33 File Offset: 0x00707133
	public static ETargetSourceType GetTargetSourceType(GameplayCue cueConfig)
	{
		if (!((((cueConfig.ParametersLength > 0) ? cueConfig.Parameters(0) : null) ?? "0") == "1"))
		{
			return ETargetSourceType.LockOn;
		}
		return ETargetSourceType.Skill;
	}

	// Token: 0x06018D82 RID: 101762 RVA: 0x00708F62 File Offset: 0x00707162
	public static void CreateStaticDefaultValue()
	{
		GameplayCueController.LastHandle = 0;
	}

	// Token: 0x06018D83 RID: 101763 RVA: 0x00708F6A File Offset: 0x0070716A
	public static void ResetStaticDefaultValue()
	{
		GameplayCueController.LastHandle = 0;
	}

	// Token: 0x0400C202 RID: 49666
	public const int INVALID_CUE_HANDLE = 0;

	// Token: 0x0400C203 RID: 49667
	public const int INSTANT_CUE_HANDLE = -1;

	// Token: 0x0400C204 RID: 49668
	private static int LastHandle;
}
