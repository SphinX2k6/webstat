using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200473A RID: 18234
	public class WuYinQuBattleStateFighting1 : WuYinQuBattleStateBase
	{
		// Token: 0x0602F53D RID: 193853 RVA: 0x00B391D8 File Offset: 0x00B373D8
		[NullableContext(1)]
		public WuYinQuBattleStateFighting1(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F53E RID: 193854 RVA: 0x00B391E3 File Offset: 0x00B373E3
		[NullableContext(2)]
		protected virtual PDA_WuYinQuBattleFightingData_C GetFightingData()
		{
			PDA_WuYinQuBattleData_C wuYinQuFightingData = this.Owner.WuYinQuFightingData;
			if (wuYinQuFightingData == null)
			{
				return null;
			}
			return wuYinQuFightingData.WuYinQuFightingData1;
		}

		// Token: 0x0602F53F RID: 193855 RVA: 0x00B391FC File Offset: 0x00B373FC
		protected override void OnEnter(EWuYinQuBattleState? lastState)
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "进入战斗阶段", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Owner.当前状态 = "战斗阶段1";
			UObject fightingData = this.GetFightingData();
			this.Timer = 0f;
			if (UKismetSystemLibrary.IsValid(fightingData))
			{
				UMaterialParameterCollection globalMPC = this.Owner.WuYinQuFightingData.GlobalMPC;
				PDA_WuYinQuBattleData_C wuYinQuFightingData = this.Owner.WuYinQuFightingData;
				if (globalMPC != null)
				{
					UObject world = this.Owner.GetWorld();
					UMaterialParameterCollection collection = globalMPC;
					FName globalLandscapeRadiusAndHardness = WuYinQuBattleNameDefines.GlobalLandscapeRadiusAndHardness;
					FLinearColor flinearColor = new FLinearColor(wuYinQuFightingData.LandscapeShowingRadiusCurve.GetFloatValue(1f), 0.0001f, 0f, 0f);
					UKismetMaterialLibrary.SetVectorParameterValue(world, collection, globalLandscapeRadiusAndHardness, flinearColor);
					UKismetMaterialLibrary.SetScalarParameterValue(this.Owner.GetWorld(), globalMPC, WuYinQuBattleNameDefines.GlobalBlackStoneErosion, 1f);
					return;
				}
			}
			else
			{
				Singleton<Log>.Instance.Warn(ELogModule.RenderBattle, ELogAuthor.HCS, "没有配置有效的战斗氛围数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0602F540 RID: 193856 RVA: 0x00B392E2 File Offset: 0x00B374E2
		protected override void OnUpdate(float delta)
		{
		}

		// Token: 0x0602F541 RID: 193857 RVA: 0x00B392E4 File Offset: 0x00B374E4
		protected override void OnExit(EWuYinQuBattleState lastState)
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "退出战斗阶段", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0401AF2A RID: 110378
		protected float Timer;
	}
}
