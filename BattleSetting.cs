using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003259 RID: 12889
public class BattleSetting : IStaticVariableResetter
{
	// Token: 0x0601ADCF RID: 110031 RVA: 0x008042F6 File Offset: 0x008024F6
	static BattleSetting()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BattleSetting.CreateStaticDefaultValue), new Action(BattleSetting.ResetStaticDefaultValue));
	}

	// Token: 0x17002477 RID: 9335
	// (get) Token: 0x0601ADD0 RID: 110032 RVA: 0x00804315 File Offset: 0x00802515
	[Nullable(1)]
	private static Dictionary<BattleModule, bool> moduleNetworkState
	{
		[NullableContext(1)]
		get
		{
			return BattleSetting._moduleNetworkState;
		}
	}

	// Token: 0x0601ADD1 RID: 110033 RVA: 0x0080431C File Offset: 0x0080251C
	public static void RequestSetModuleNetworkState(BattleModule module, bool isClientControl)
	{
		SwitchBattleModeRequest switchBattleModeRequest = SwitchBattleModeRequest.Create();
		switchBattleModeRequest.ClientControllerModule = module;
		switchBattleModeRequest.Client = isClientControl;
		Singleton<Net>.Instance.Call<SwitchBattleModeResponse>(ERequestMessageId.SwitchBattleModeRequest, switchBattleModeRequest, delegate(SwitchBattleModeResponse response, Net.CallbackStatus _)
		{
			BattleSetting.ReceiveSetModuleNetworkState(module, response.Client);
		}, 0);
	}

	// Token: 0x0601ADD2 RID: 110034 RVA: 0x0080436C File Offset: 0x0080256C
	public static bool IsModuleClientControl(BattleModule module)
	{
		bool flag;
		return !BattleSetting.moduleNetworkState.TryGetValue(module, out flag) || flag;
	}

	// Token: 0x0601ADD3 RID: 110035 RVA: 0x0080438B File Offset: 0x0080258B
	public static void ReceiveSetModuleNetworkState(BattleModule module, bool isClientControl)
	{
		BattleSetting.moduleNetworkState[module] = isClientControl;
	}

	// Token: 0x0601ADD4 RID: 110036 RVA: 0x00804399 File Offset: 0x00802599
	public static void CreateStaticDefaultValue()
	{
		BattleSetting._moduleNetworkState = new Dictionary<BattleModule, bool>();
	}

	// Token: 0x0601ADD5 RID: 110037 RVA: 0x008043A5 File Offset: 0x008025A5
	public static void ResetStaticDefaultValue()
	{
		BattleSetting._moduleNetworkState = null;
	}

	// Token: 0x0400DA17 RID: 55831
	[Nullable(2)]
	private static Dictionary<BattleModule, bool> _moduleNetworkState;
}
