using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Guide;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card.Logic
{
	// Token: 0x02005625 RID: 22053
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PhantomArenaCardLogic
	{
		// Token: 0x06038341 RID: 230209 RVA: 0x00E3B609 File Offset: 0x00E39809
		public PhantomArenaCardLogic(PhantomArenaCard card, PhantomArenaBattleProxy viewProxy)
		{
			this.Card = card;
			this.ViewProxy = viewProxy;
		}

		// Token: 0x06038342 RID: 230210 RVA: 0x00E3B61F File Offset: 0x00E3981F
		public Tuple<bool, EPhantomCardSettingFailReason> CheckRecycleSettingConditionFromHead()
		{
			return this.OnCheckRecycleSettingConditionFromHead();
		}

		// Token: 0x06038343 RID: 230211 RVA: 0x00E3B627 File Offset: 0x00E39827
		public Tuple<bool, EPhantomCardSettingFailReason> CheckRecycleSettingConditionFromFunctional()
		{
			return this.OnCheckRecycleSettingConditionFromFunctional();
		}

		// Token: 0x06038344 RID: 230212
		public abstract Tuple<bool, EPhantomCardSettingFailReason> CheckFunctionalSettingCondition(PhantomArenaCard oldCard);

		// Token: 0x06038345 RID: 230213
		public abstract Tuple<bool, EPhantomCardSettingFailReason> CheckMonsterSettingCondition(PhantomArenaCard oldCard);

		// Token: 0x06038346 RID: 230214
		protected abstract Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromHead();

		// Token: 0x06038347 RID: 230215
		protected abstract Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromFunctional();

		// Token: 0x06038348 RID: 230216 RVA: 0x00E3B62F File Offset: 0x00E3982F
		public void BeforeStart()
		{
			this.OnBeforeStart();
		}

		// Token: 0x06038349 RID: 230217 RVA: 0x00E3B637 File Offset: 0x00E39837
		public virtual List<TCardComponentsRegisterInfoByResourceId> GetComponentsDataList()
		{
			return new List<TCardComponentsRegisterInfoByResourceId>();
		}

		// Token: 0x0603834A RID: 230218 RVA: 0x00E3B63E File Offset: 0x00E3983E
		public void Refresh(PhantomCardData data)
		{
			this.Card.Data = data;
			this.OnRefresh();
		}

		// Token: 0x0603834B RID: 230219 RVA: 0x00E3B652 File Offset: 0x00E39852
		public void SetSelectedState(bool value)
		{
			this.OnSetSelectedState(value);
		}

		// Token: 0x0603834C RID: 230220 RVA: 0x00E3B65C File Offset: 0x00E3985C
		public UniTask RefreshEffect(int curEffectCount)
		{
			PhantomArenaCardLogic.<RefreshEffect>d__13 <RefreshEffect>d__;
			<RefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffect>d__.<>4__this = this;
			<RefreshEffect>d__.curEffectCount = curEffectCount;
			<RefreshEffect>d__.<>1__state = -1;
			<RefreshEffect>d__.<>t__builder.Start<PhantomArenaCardLogic.<RefreshEffect>d__13>(ref <RefreshEffect>d__);
			return <RefreshEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0603834D RID: 230221 RVA: 0x00E3B6A8 File Offset: 0x00E398A8
		public void TryFinishCurrentGuide()
		{
			PhantomArenaGuideCardSkillData phantomArenaGuideCardSkillData = new PhantomArenaGuideCardSkillData
			{
				CardId = this.Card.Data.CardId
			};
			this.ViewProxy.GuideManager.TryFinishGuideByType(EBvbPlayerOperationType.BvbUseItemCardSkill, new object[]
			{
				phantomArenaGuideCardSkillData
			});
		}

		// Token: 0x0603834E RID: 230222 RVA: 0x00E3B6EC File Offset: 0x00E398EC
		protected virtual void OnBeforeStart()
		{
		}

		// Token: 0x0603834F RID: 230223 RVA: 0x00E3B6EE File Offset: 0x00E398EE
		protected virtual void OnRefresh()
		{
		}

		// Token: 0x06038350 RID: 230224 RVA: 0x00E3B6F0 File Offset: 0x00E398F0
		protected virtual void OnSetSelectedState(bool value)
		{
		}

		// Token: 0x06038351 RID: 230225 RVA: 0x00E3B6F2 File Offset: 0x00E398F2
		protected virtual UniTask OnRefreshEffect(int curEffectCount)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06038352 RID: 230226 RVA: 0x00E3B6F9 File Offset: 0x00E398F9
		protected void SkillBtnClick()
		{
			this.TriggerToolActiveSkill().Forget();
		}

		// Token: 0x06038353 RID: 230227 RVA: 0x00E3B708 File Offset: 0x00E39908
		private UniTask TriggerToolActiveSkill()
		{
			PhantomArenaCardLogic.<TriggerToolActiveSkill>d__20 <TriggerToolActiveSkill>d__;
			<TriggerToolActiveSkill>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TriggerToolActiveSkill>d__.<>4__this = this;
			<TriggerToolActiveSkill>d__.<>1__state = -1;
			<TriggerToolActiveSkill>d__.<>t__builder.Start<PhantomArenaCardLogic.<TriggerToolActiveSkill>d__20>(ref <TriggerToolActiveSkill>d__);
			return <TriggerToolActiveSkill>d__.<>t__builder.Task;
		}

		// Token: 0x0402019D RID: 131485
		protected PhantomArenaCard Card;

		// Token: 0x0402019E RID: 131486
		protected PhantomArenaBattleProxy ViewProxy;
	}
}
