using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C3D RID: 23613
	public class LordInInstanceExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA83 RID: 244355 RVA: 0x00F1D050 File Offset: 0x00F1B250
		public override bool Checker()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && LordInInstanceExitHandler.CheckSubTypes.Contains((EDungeonSubType)config.Value.InstSubType);
		}

		// Token: 0x0603BA84 RID: 244356 RVA: 0x00F1D0AC File Offset: 0x00F1B2AC
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			LordInInstanceExitHandler.<>c__DisplayClass2_0 CS$<>8__locals1 = new LordInInstanceExitHandler.<>c__DisplayClass2_0();
			CS$<>8__locals1.data = data;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleTrialLeaveInstanceConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			Dictionary<int, Action> functionMap = confirmBoxDataNew.FunctionMap;
			int key = 0;
			InstanceDungeonExitHandlerData data2 = CS$<>8__locals1.data;
			functionMap[key] = ((data2 != null) ? data2.CancelBack : null);
			confirmBoxDataNew.FunctionMap[1] = new Action(CS$<>8__locals1.<HandleExit>g__ReChallenge|1);
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<HandleExit>g__Leave|0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x040218F5 RID: 137461
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly HashSet<EDungeonSubType> CheckSubTypes = new HashSet<EDungeonSubType>
		{
			EDungeonSubType.LordInInstance,
			EDungeonSubType.Boss,
			EDungeonSubType.PlayInstShare,
			EDungeonSubType.MonsterSettlementInstShare,
			EDungeonSubType.NightmareLordInstShare,
			EDungeonSubType.LordInstShare,
			EDungeonSubType.SilentAreaInstShare
		};
	}
}
