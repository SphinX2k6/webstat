using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003026 RID: 12326
internal class AkComponentStatic : IStaticVariableResetter
{
	// Token: 0x060192BF RID: 103103 RVA: 0x0072D7A6 File Offset: 0x0072B9A6
	static AkComponentStatic()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AkComponentStatic.CreateStaticDefaultValue), new Action(AkComponentStatic.ResetStaticDefaultValue));
	}

	// Token: 0x060192C0 RID: 103104 RVA: 0x0072D7C5 File Offset: 0x0072B9C5
	public static bool Load()
	{
		if (AkComponentStatic.Init)
		{
			return true;
		}
		Singleton<AudioSystem>.Instance.SetState("role_move", "Normal", true);
		AkComponentStatic.Init = true;
		return true;
	}

	// Token: 0x060192C1 RID: 103105 RVA: 0x0072D7EC File Offset: 0x0072B9EC
	public static void CreateStaticDefaultValue()
	{
		AkComponentStatic.Init = false;
		AkComponentStatic.AkMoveState = EAkMoveState.Normal;
		Dictionary<EAkMoveState, int> dictionary = new Dictionary<EAkMoveState, int>();
		dictionary[EAkMoveState.Fall] = GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.下落"];
		dictionary[EAkMoveState.Fly] = GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.滑翔"];
		dictionary[EAkMoveState.HighSpeed] = GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.高速移动"];
		dictionary[EAkMoveState.Sit] = GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.坐下"];
		dictionary[EAkMoveState.Slide] = GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.滑坡"];
		AkComponentStatic.AkMoveStateMap = dictionary;
	}

	// Token: 0x060192C2 RID: 103106 RVA: 0x0072D87D File Offset: 0x0072BA7D
	public static void ResetStaticDefaultValue()
	{
		AkComponentStatic.Init = false;
		AkComponentStatic.AkMoveState = EAkMoveState.Normal;
		AkComponentStatic.AkMoveStateMap = null;
	}

	// Token: 0x0400C59E RID: 50590
	public static bool Init;

	// Token: 0x0400C59F RID: 50591
	public static EAkMoveState AkMoveState;

	// Token: 0x0400C5A0 RID: 50592
	[Nullable(1)]
	public static Dictionary<EAkMoveState, int> AkMoveStateMap;
}
