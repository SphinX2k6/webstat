using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.BuffEffect
{
	// Token: 0x020055E2 RID: 21986
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBuffEffectManager
	{
		// Token: 0x06038067 RID: 229479 RVA: 0x00E316A4 File Offset: 0x00E2F8A4
		public PhantomArenaBuffEffectManager(PhantomArenaBattleProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06038068 RID: 229480 RVA: 0x00E316B4 File Offset: 0x00E2F8B4
		public UniTask ShowSkillEffect()
		{
			PhantomArenaBuffEffectManager.<ShowSkillEffect>d__2 <ShowSkillEffect>d__;
			<ShowSkillEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowSkillEffect>d__.<>4__this = this;
			<ShowSkillEffect>d__.<>1__state = -1;
			<ShowSkillEffect>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<ShowSkillEffect>d__2>(ref <ShowSkillEffect>d__);
			return <ShowSkillEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038069 RID: 229481 RVA: 0x00E316F8 File Offset: 0x00E2F8F8
		public UniTask TriggerSkillEffectByNpc(IBuffEffectData effectData)
		{
			PhantomArenaBuffEffectManager.<TriggerSkillEffectByNpc>d__3 <TriggerSkillEffectByNpc>d__;
			<TriggerSkillEffectByNpc>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TriggerSkillEffectByNpc>d__.<>4__this = this;
			<TriggerSkillEffectByNpc>d__.effectData = effectData;
			<TriggerSkillEffectByNpc>d__.<>1__state = -1;
			<TriggerSkillEffectByNpc>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<TriggerSkillEffectByNpc>d__3>(ref <TriggerSkillEffectByNpc>d__);
			return <TriggerSkillEffectByNpc>d__.<>t__builder.Task;
		}

		// Token: 0x0603806A RID: 229482 RVA: 0x00E31744 File Offset: 0x00E2F944
		private UniTask ExecuteEffectContext(IBuffEffectData effectData)
		{
			PhantomArenaBuffEffectManager.<ExecuteEffectContext>d__4 <ExecuteEffectContext>d__;
			<ExecuteEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteEffectContext>d__.<>4__this = this;
			<ExecuteEffectContext>d__.effectData = effectData;
			<ExecuteEffectContext>d__.<>1__state = -1;
			<ExecuteEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<ExecuteEffectContext>d__4>(ref <ExecuteEffectContext>d__);
			return <ExecuteEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x0603806B RID: 229483 RVA: 0x00E31790 File Offset: 0x00E2F990
		private UniTask PhantomBattleDealEffectContext(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<PhantomBattleDealEffectContext>d__5 <PhantomBattleDealEffectContext>d__;
			<PhantomBattleDealEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PhantomBattleDealEffectContext>d__.<>4__this = this;
			<PhantomBattleDealEffectContext>d__.info = info;
			<PhantomBattleDealEffectContext>d__.<>1__state = -1;
			<PhantomBattleDealEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<PhantomBattleDealEffectContext>d__5>(ref <PhantomBattleDealEffectContext>d__);
			return <PhantomBattleDealEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x0603806C RID: 229484 RVA: 0x00E317DC File Offset: 0x00E2F9DC
		private UniTask NpcPhantomBattleDealEffectContext(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<NpcPhantomBattleDealEffectContext>d__6 <NpcPhantomBattleDealEffectContext>d__;
			<NpcPhantomBattleDealEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NpcPhantomBattleDealEffectContext>d__.<>4__this = this;
			<NpcPhantomBattleDealEffectContext>d__.info = info;
			<NpcPhantomBattleDealEffectContext>d__.<>1__state = -1;
			<NpcPhantomBattleDealEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<NpcPhantomBattleDealEffectContext>d__6>(ref <NpcPhantomBattleDealEffectContext>d__);
			return <NpcPhantomBattleDealEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x0603806D RID: 229485 RVA: 0x00E31828 File Offset: 0x00E2FA28
		private UniTask PhantomBattleAddBuffEffectContext(IBuffEffectData info)
		{
			PhantomBattleEffectResultInfo effect = info.Effect;
			if (((effect != null) ? effect.PhantomBattleAddBuffEffectCtx : null) != null)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "触发添加buff效果", default(ReadOnlySpan<ValueTuple<string, object>>));
				new PhantomArenaBuffEffectAddBuff(info, this).ShowBuffEffect();
			}
			return UniTask.CompletedTask;
		}

		// Token: 0x0603806E RID: 229486 RVA: 0x00E3187C File Offset: 0x00E2FA7C
		private UniTask PhantomBattleCardSelectEffectContext(IBuffEffectData info)
		{
			PhantomBattleEffectResultInfo effect = info.Effect;
			if (((effect != null) ? effect.PhantomBattleCardSelectEffectCtx : null) != null)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "触发选牌效果", default(ReadOnlySpan<ValueTuple<string, object>>));
				new PhantomArenaBuffEffectChooseCard(info, this).ShowChooseCard();
			}
			return UniTask.CompletedTask;
		}

		// Token: 0x0603806F RID: 229487 RVA: 0x00E318D0 File Offset: 0x00E2FAD0
		private UniTask NpcPhantomBattleCardSelectEffectContext(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<NpcPhantomBattleCardSelectEffectContext>d__9 <NpcPhantomBattleCardSelectEffectContext>d__;
			<NpcPhantomBattleCardSelectEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NpcPhantomBattleCardSelectEffectContext>d__.<>4__this = this;
			<NpcPhantomBattleCardSelectEffectContext>d__.info = info;
			<NpcPhantomBattleCardSelectEffectContext>d__.<>1__state = -1;
			<NpcPhantomBattleCardSelectEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<NpcPhantomBattleCardSelectEffectContext>d__9>(ref <NpcPhantomBattleCardSelectEffectContext>d__);
			return <NpcPhantomBattleCardSelectEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x06038070 RID: 229488 RVA: 0x00E3191C File Offset: 0x00E2FB1C
		private UniTask PhantomBattleCopyCardEffectContext(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<PhantomBattleCopyCardEffectContext>d__10 <PhantomBattleCopyCardEffectContext>d__;
			<PhantomBattleCopyCardEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PhantomBattleCopyCardEffectContext>d__.<>4__this = this;
			<PhantomBattleCopyCardEffectContext>d__.info = info;
			<PhantomBattleCopyCardEffectContext>d__.<>1__state = -1;
			<PhantomBattleCopyCardEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<PhantomBattleCopyCardEffectContext>d__10>(ref <PhantomBattleCopyCardEffectContext>d__);
			return <PhantomBattleCopyCardEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x06038071 RID: 229489 RVA: 0x00E31968 File Offset: 0x00E2FB68
		private UniTask PhantomBattleDestroyCardEffectContext(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<PhantomBattleDestroyCardEffectContext>d__11 <PhantomBattleDestroyCardEffectContext>d__;
			<PhantomBattleDestroyCardEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PhantomBattleDestroyCardEffectContext>d__.<>4__this = this;
			<PhantomBattleDestroyCardEffectContext>d__.info = info;
			<PhantomBattleDestroyCardEffectContext>d__.<>1__state = -1;
			<PhantomBattleDestroyCardEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<PhantomBattleDestroyCardEffectContext>d__11>(ref <PhantomBattleDestroyCardEffectContext>d__);
			return <PhantomBattleDestroyCardEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x06038072 RID: 229490 RVA: 0x00E319B4 File Offset: 0x00E2FBB4
		private UniTask PhantomBattleTakeTargetAttrEffectContext(IBuffEffectData info)
		{
			PhantomBattleEffectResultInfo effect = info.Effect;
			if (((effect != null) ? effect.PhantomBattleTakeTargetAttrEffectCtx : null) != null)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "触发获取目标属性效果", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (info.Effect.PhantomBattleTakeTargetAttrEffectCtx.Camp == PhantomBattleEffectCardCamp.GamerFighterPlayer)
				{
					ModelBase<PhantomArenaBattleModel>.Instance.OwnData.RefreshCardAttr(info.Effect.PhantomBattleTakeTargetAttrEffectCtx.TargetUid, info.Effect.PhantomBattleTakeTargetAttrEffectCtx.TakeAttrInfo.BattleStatus.ToDictionary<int, int>());
				}
				else if (info.Effect.PhantomBattleTakeTargetAttrEffectCtx.Camp == PhantomBattleEffectCardCamp.GamerFighterNpc)
				{
					ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.RefreshCardAttr(info.Effect.PhantomBattleTakeTargetAttrEffectCtx.TargetUid, info.Effect.PhantomBattleTakeTargetAttrEffectCtx.TakeAttrInfo.BattleStatus.ToDictionary<int, int>());
				}
			}
			return UniTask.CompletedTask;
		}

		// Token: 0x06038073 RID: 229491 RVA: 0x00E31A98 File Offset: 0x00E2FC98
		private UniTask PhantomBattleCallCardEffectContext(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<PhantomBattleCallCardEffectContext>d__13 <PhantomBattleCallCardEffectContext>d__;
			<PhantomBattleCallCardEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PhantomBattleCallCardEffectContext>d__.<>4__this = this;
			<PhantomBattleCallCardEffectContext>d__.info = info;
			<PhantomBattleCallCardEffectContext>d__.<>1__state = -1;
			<PhantomBattleCallCardEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<PhantomBattleCallCardEffectContext>d__13>(ref <PhantomBattleCallCardEffectContext>d__);
			return <PhantomBattleCallCardEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x06038074 RID: 229492 RVA: 0x00E31AE4 File Offset: 0x00E2FCE4
		private UniTask HandleNpcFieldSealEffect(NpcPhantomBattleAreaLockEffectCtx effectContext)
		{
			PhantomArenaBuffEffectManager.<HandleNpcFieldSealEffect>d__14 <HandleNpcFieldSealEffect>d__;
			<HandleNpcFieldSealEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleNpcFieldSealEffect>d__.<>4__this = this;
			<HandleNpcFieldSealEffect>d__.effectContext = effectContext;
			<HandleNpcFieldSealEffect>d__.<>1__state = -1;
			<HandleNpcFieldSealEffect>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<HandleNpcFieldSealEffect>d__14>(ref <HandleNpcFieldSealEffect>d__);
			return <HandleNpcFieldSealEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038075 RID: 229493 RVA: 0x00E31B30 File Offset: 0x00E2FD30
		private UniTask HandleOwnFieldSealEffect(NpcPhantomBattleAreaLockEffectCtx context)
		{
			PhantomArenaBuffEffectManager.<HandleOwnFieldSealEffect>d__15 <HandleOwnFieldSealEffect>d__;
			<HandleOwnFieldSealEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleOwnFieldSealEffect>d__.<>4__this = this;
			<HandleOwnFieldSealEffect>d__.context = context;
			<HandleOwnFieldSealEffect>d__.<>1__state = -1;
			<HandleOwnFieldSealEffect>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<HandleOwnFieldSealEffect>d__15>(ref <HandleOwnFieldSealEffect>d__);
			return <HandleOwnFieldSealEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038076 RID: 229494 RVA: 0x00E31B7C File Offset: 0x00E2FD7C
		private UniTask NpcPhantomBattleAreaLockEffectContext(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<NpcPhantomBattleAreaLockEffectContext>d__16 <NpcPhantomBattleAreaLockEffectContext>d__;
			<NpcPhantomBattleAreaLockEffectContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NpcPhantomBattleAreaLockEffectContext>d__.<>4__this = this;
			<NpcPhantomBattleAreaLockEffectContext>d__.info = info;
			<NpcPhantomBattleAreaLockEffectContext>d__.<>1__state = -1;
			<NpcPhantomBattleAreaLockEffectContext>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<NpcPhantomBattleAreaLockEffectContext>d__16>(ref <NpcPhantomBattleAreaLockEffectContext>d__);
			return <NpcPhantomBattleAreaLockEffectContext>d__.<>t__builder.Task;
		}

		// Token: 0x06038077 RID: 229495 RVA: 0x00E31BC8 File Offset: 0x00E2FDC8
		private UniTask PhantomBattleDirectDamage(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<PhantomBattleDirectDamage>d__17 <PhantomBattleDirectDamage>d__;
			<PhantomBattleDirectDamage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PhantomBattleDirectDamage>d__.<>4__this = this;
			<PhantomBattleDirectDamage>d__.info = info;
			<PhantomBattleDirectDamage>d__.<>1__state = -1;
			<PhantomBattleDirectDamage>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<PhantomBattleDirectDamage>d__17>(ref <PhantomBattleDirectDamage>d__);
			return <PhantomBattleDirectDamage>d__.<>t__builder.Task;
		}

		// Token: 0x06038078 RID: 229496 RVA: 0x00E31C14 File Offset: 0x00E2FE14
		private UniTask PhantomBattleReconstruct(IBuffEffectData info)
		{
			PhantomArenaBuffEffectManager.<PhantomBattleReconstruct>d__18 <PhantomBattleReconstruct>d__;
			<PhantomBattleReconstruct>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PhantomBattleReconstruct>d__.<>4__this = this;
			<PhantomBattleReconstruct>d__.info = info;
			<PhantomBattleReconstruct>d__.<>1__state = -1;
			<PhantomBattleReconstruct>d__.<>t__builder.Start<PhantomArenaBuffEffectManager.<PhantomBattleReconstruct>d__18>(ref <PhantomBattleReconstruct>d__);
			return <PhantomBattleReconstruct>d__.<>t__builder.Task;
		}

		// Token: 0x0402008C RID: 131212
		public PhantomArenaBattleProxy Proxy;
	}
}
