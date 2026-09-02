using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C67 RID: 27751
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemInstanceEntrance : OpenSystemBase
	{
		// Token: 0x06044286 RID: 279174 RVA: 0x011B221D File Offset: 0x011B041D
		public OpenSystemInstanceEntrance(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044287 RID: 279175 RVA: 0x011B2228 File Offset: 0x011B0428
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemInstanceEntrance.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemInstanceEntrance.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044288 RID: 279176 RVA: 0x011B2274 File Offset: 0x011B0474
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.InstanceDungeonEntranceView);
			}
			EInstanceEntranceFlowType instanceDungeonEntranceFlowId = (EInstanceEntranceFlowType)ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetInstanceDungeonEntranceFlowId(inParams.BoardId);
			if (instanceDungeonEntranceFlowId == EInstanceEntranceFlowType.SingleTimeTower)
			{
				return new EUiViewName?(EUiViewName.SingleTimeTowerView);
			}
			if (instanceDungeonEntranceFlowId == EInstanceEntranceFlowType.CycleTower)
			{
				return new EUiViewName?(EUiViewName.CycleTowerView);
			}
			if (instanceDungeonEntranceFlowId == EInstanceEntranceFlowType.BossRush)
			{
				return new EUiViewName?(EUiViewName.BossRushMainView);
			}
			if (instanceDungeonEntranceFlowId == EInstanceEntranceFlowType.NewTower)
			{
				return new EUiViewName?((ModelBase<TowerModel>.Instance.GetMaxDifficulty() != 3) ? EUiViewName.TowerNormalView : EUiViewName.TowerVariationView);
			}
			if (instanceDungeonEntranceFlowId == EInstanceEntranceFlowType.Attached)
			{
				return new EUiViewName?(EUiViewName.InstanceDungeonEntranceView);
			}
			if (instanceDungeonEntranceFlowId == EInstanceEntranceFlowType.FarmGold)
			{
				return new EUiViewName?(EUiViewName.ActivityInstanceEntranceView);
			}
			if (instanceDungeonEntranceFlowId == EInstanceEntranceFlowType.LordGym)
			{
				return new EUiViewName?(EUiViewName.LordGymThirdBossSelectView);
			}
			return new EUiViewName?(EUiViewName.InstanceDungeonEntranceView);
		}
	}
}
