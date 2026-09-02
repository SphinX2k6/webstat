using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006940 RID: 26944
	public class DropCatchGameplayTimeMgr : DropCatchGameplayBaseMgr
	{
		// Token: 0x06042E00 RID: 273920 RVA: 0x0112A896 File Offset: 0x01128A96
		[NullableContext(1)]
		public DropCatchGameplayTimeMgr(IGameplayLogicContext context) : base(context)
		{
		}

		// Token: 0x06042E01 RID: 273921 RVA: 0x0112A8A0 File Offset: 0x01128AA0
		public override void Init()
		{
			DropCatchGameplay? gameplayConfig = this.Context.GetProxy().GetGameplayConfig();
			this.TotalTime = (float)(((gameplayConfig != null) ? gameplayConfig.GetValueOrDefault().GameplayTime : 0) * Singleton<TimeUtil>.Instance.InverseMillisecond);
			this.GameplayTime = 0f;
			this.UpdateTime(0f);
		}

		// Token: 0x06042E02 RID: 273922 RVA: 0x0112A901 File Offset: 0x01128B01
		public override void OnTick(float deltaTime)
		{
			this.UpdateTime(deltaTime);
			this.CheckGameOver();
		}

		// Token: 0x06042E03 RID: 273923 RVA: 0x0112A910 File Offset: 0x01128B10
		private void CheckGameOver()
		{
			if (this.RemainingTime <= 0f)
			{
				this.Context.GetProxy().SettleGameplay(EDropCatchGameplaySettleReason.TimeUp);
				Singleton<EventSystem>.Instance.Emit<EArcadeGameplayType, int>(EEventName.OnArcadeGameplayFinish, EArcadeGameplayType.DropCatch, this.Context.GetProxy().GetCurGameplayId());
			}
		}

		// Token: 0x06042E04 RID: 273924 RVA: 0x0112A95C File Offset: 0x01128B5C
		public void UpdateTime(float deltaTime)
		{
			this.GameplayTime += deltaTime;
			this.RemainingTime = Math.Max(0f, this.TotalTime - this.GameplayTime);
			DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
			if (gameplayView == null)
			{
				return;
			}
			gameplayView.UpdateRemainTime();
		}

		// Token: 0x06042E05 RID: 273925 RVA: 0x0112A9AE File Offset: 0x01128BAE
		public float GetTime()
		{
			return this.GameplayTime;
		}

		// Token: 0x06042E06 RID: 273926 RVA: 0x0112A9B6 File Offset: 0x01128BB6
		public float GetRemainingTime()
		{
			return this.RemainingTime;
		}

		// Token: 0x06042E07 RID: 273927 RVA: 0x0112A9BE File Offset: 0x01128BBE
		public void AddTime(float time)
		{
			this.TotalTime += time * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			DropCatchGameplayViewModel gameplayViewModel = this.Context.GetProxy().GetGameplayViewModel();
			if (gameplayViewModel == null)
			{
				return;
			}
			gameplayViewModel.AddAddTime(time);
		}

		// Token: 0x0402543B RID: 152635
		private float GameplayTime;

		// Token: 0x0402543C RID: 152636
		private float TotalTime;

		// Token: 0x0402543D RID: 152637
		private float RemainingTime;
	}
}
