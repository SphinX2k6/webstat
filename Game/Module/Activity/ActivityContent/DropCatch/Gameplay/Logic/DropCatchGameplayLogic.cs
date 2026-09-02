using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200693C RID: 26940
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayLogic : IGameplayLogicContext
	{
		// Token: 0x06042DAA RID: 273834 RVA: 0x01129244 File Offset: 0x01127444
		public void Init(DropCatchGameplayProxy proxy)
		{
			this.Proxy = proxy;
			this.End();
			DropCatchGameplay? gameplayConfig = this.Proxy.GetGameplayConfig();
			this.GameplayArea = new IDropCatchGameplayArea
			{
				MinX = (double)((gameplayConfig != null) ? gameplayConfig.GetValueOrDefault().Area(0) : 0f),
				MinY = (double)((gameplayConfig != null) ? gameplayConfig.GetValueOrDefault().Area(1) : 0f),
				MaxX = (double)((gameplayConfig != null) ? gameplayConfig.GetValueOrDefault().Area(2) : 0f),
				MaxY = (double)((gameplayConfig != null) ? gameplayConfig.GetValueOrDefault().Area(3) : 0f)
			};
			this.InitManagers();
			this.InitAttributes();
		}

		// Token: 0x06042DAB RID: 273835 RVA: 0x01129320 File Offset: 0x01127520
		private void InitManagers()
		{
			if (this.GameplayModifierMgr == null)
			{
				this.GameplayModifierMgr = new DropCatchGameplayModifierMgr(this);
			}
			this.GameplayModifierMgr.Init();
			if (this.GameplayCommandMgr == null)
			{
				this.GameplayCommandMgr = new DropCatchGameplayCommandMgr(this);
			}
			this.GameplayCommandMgr.Init();
			if (this.GameplayTimeMgr == null)
			{
				this.GameplayTimeMgr = new DropCatchGameplayTimeMgr(this);
			}
			this.GameplayTimeMgr.Init();
			if (this.GameplayInputMgr == null)
			{
				this.GameplayInputMgr = new DropCatchGameplayInputMgr(this);
			}
			this.GameplayInputMgr.Init();
			if (this.GameplayRoleMgr == null)
			{
				this.GameplayRoleMgr = new DropCatchGameplayRoleMgr(this);
			}
			this.GameplayRoleMgr.Init();
			if (this.GameplayDropItemMgr == null)
			{
				this.GameplayDropItemMgr = new DropCatchGameplayDropItemMgr(this);
			}
			this.GameplayDropItemMgr.Init();
			if (this.GameplayCollisionMgr == null)
			{
				this.GameplayCollisionMgr = new DropCatchGameplayCollisionMgr(this);
			}
			this.GameplayCollisionMgr.Init();
		}

		// Token: 0x06042DAC RID: 273836 RVA: 0x01129406 File Offset: 0x01127606
		private void InitAttributes()
		{
			this.AddScoreRate = new DropCatchGameplayAttribute("AddScoreRate", 1f);
			this.EnergyGetRate = new DropCatchGameplayAttribute("EnergyGetRate", 1f);
		}

		// Token: 0x06042DAD RID: 273837 RVA: 0x01129432 File Offset: 0x01127632
		public DropCatchGameplayProxy GetProxy()
		{
			return this.Proxy;
		}

		// Token: 0x06042DAE RID: 273838 RVA: 0x0112943A File Offset: 0x0112763A
		public DropCatchGameplayTimeMgr GetGameplayTimeMgr()
		{
			return this.GameplayTimeMgr;
		}

		// Token: 0x06042DAF RID: 273839 RVA: 0x01129442 File Offset: 0x01127642
		public DropCatchGameplayRoleMgr GetGameplayRoleMgr()
		{
			return this.GameplayRoleMgr;
		}

		// Token: 0x06042DB0 RID: 273840 RVA: 0x0112944A File Offset: 0x0112764A
		public DropCatchGameplayDropItemMgr GetGameplayDropItemMgr()
		{
			return this.GameplayDropItemMgr;
		}

		// Token: 0x06042DB1 RID: 273841 RVA: 0x01129452 File Offset: 0x01127652
		public DropCatchGameplayCollisionMgr GetGameplayCollisionMgr()
		{
			return this.GameplayCollisionMgr;
		}

		// Token: 0x06042DB2 RID: 273842 RVA: 0x0112945A File Offset: 0x0112765A
		public DropCatchGameplayCommandMgr GetGameplayCommandMgr()
		{
			return this.GameplayCommandMgr;
		}

		// Token: 0x06042DB3 RID: 273843 RVA: 0x01129462 File Offset: 0x01127662
		public DropCatchGameplayModifierMgr GetGameplayModifierMgr()
		{
			return this.GameplayModifierMgr;
		}

		// Token: 0x06042DB4 RID: 273844 RVA: 0x0112946A File Offset: 0x0112766A
		public DropCatchGameplayInputMgr GetGameplayInputMgr()
		{
			return this.GameplayInputMgr;
		}

		// Token: 0x06042DB5 RID: 273845 RVA: 0x01129472 File Offset: 0x01127672
		public IDropCatchGameplayArea GetGameplayArea()
		{
			return this.GameplayArea;
		}

		// Token: 0x06042DB6 RID: 273846 RVA: 0x0112947A File Offset: 0x0112767A
		public void Pause()
		{
			if (this.GameplayState == EDropCatchGameplayState.Pause)
			{
				return;
			}
			if (this.TickId != null)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId.Id);
			}
			this.StateBeforePause = this.GameplayState;
			this.GameplayState = EDropCatchGameplayState.Pause;
		}

		// Token: 0x06042DB7 RID: 273847 RVA: 0x011294B7 File Offset: 0x011276B7
		public void Resume()
		{
			if (this.GameplayState != EDropCatchGameplayState.Pause)
			{
				return;
			}
			if (this.TickId != null)
			{
				Singleton<TickSystem>.Instance.Resume(this.TickId.Id);
			}
			this.GameplayState = this.StateBeforePause;
		}

		// Token: 0x06042DB8 RID: 273848 RVA: 0x011294ED File Offset: 0x011276ED
		public void Ready()
		{
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "DropCatchGameplayLogic", ETickingGroup.TG_PrePhysics, true, 0, true);
			this.GameplayState = EDropCatchGameplayState.Ready;
		}

		// Token: 0x06042DB9 RID: 273849 RVA: 0x0112951C File Offset: 0x0112771C
		public void Play()
		{
			this.GameplayState = EDropCatchGameplayState.Play;
			DropCatchGameplayView gameplayView = this.Proxy.GetGameplayView();
			if (gameplayView != null)
			{
				Singleton<UiAudioModel>.Instance.SetLoopAudioEventShow(gameplayView.GetViewId(), gameplayView.GetRootActor(), "play_ui_music_coincatch");
			}
		}

		// Token: 0x06042DBA RID: 273850 RVA: 0x0112955C File Offset: 0x0112775C
		public void End()
		{
			if (this.TickId != null)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId.Id);
				this.TickId = null;
			}
			this.GameplayState = EDropCatchGameplayState.End;
			DropCatchGameplayView gameplayView = this.Proxy.GetGameplayView();
			if (gameplayView != null)
			{
				Singleton<UiAudioModel>.Instance.SetLoopAudioEventDestroy(gameplayView.GetViewId(), gameplayView.GetRootActor(), "play_ui_music_coincatch");
			}
		}

		// Token: 0x06042DBB RID: 273851 RVA: 0x011295BF File Offset: 0x011277BF
		private void OnTick(float deltaTime)
		{
			if (this.GameplayState == EDropCatchGameplayState.Ready)
			{
				this.OnReadyTick(deltaTime);
				return;
			}
			if (this.GameplayState == EDropCatchGameplayState.Play)
			{
				this.OnPlayTick(deltaTime);
			}
		}

		// Token: 0x06042DBC RID: 273852 RVA: 0x011295E1 File Offset: 0x011277E1
		private void OnReadyTick(float deltaTime)
		{
			DropCatchGameplayInputMgr gameplayInputMgr = this.GameplayInputMgr;
			if (gameplayInputMgr != null)
			{
				gameplayInputMgr.OnReadyTick(deltaTime);
			}
			DropCatchGameplayRoleMgr gameplayRoleMgr = this.GameplayRoleMgr;
			if (gameplayRoleMgr == null)
			{
				return;
			}
			gameplayRoleMgr.OnReadyTick(deltaTime);
		}

		// Token: 0x06042DBD RID: 273853 RVA: 0x01129608 File Offset: 0x01127808
		private void OnPlayTick(float deltaTime)
		{
			DropCatchGameplayTimeMgr gameplayTimeMgr = this.GameplayTimeMgr;
			if (gameplayTimeMgr != null)
			{
				gameplayTimeMgr.OnTick(deltaTime);
			}
			DropCatchGameplayModifierMgr gameplayModifierMgr = this.GameplayModifierMgr;
			if (gameplayModifierMgr != null)
			{
				gameplayModifierMgr.OnTick(deltaTime);
			}
			DropCatchGameplayDropItemMgr gameplayDropItemMgr = this.GameplayDropItemMgr;
			if (gameplayDropItemMgr != null)
			{
				gameplayDropItemMgr.OnTick(deltaTime);
			}
			DropCatchGameplayInputMgr gameplayInputMgr = this.GameplayInputMgr;
			if (gameplayInputMgr != null)
			{
				gameplayInputMgr.OnTick(deltaTime);
			}
			DropCatchGameplayRoleMgr gameplayRoleMgr = this.GameplayRoleMgr;
			if (gameplayRoleMgr != null)
			{
				gameplayRoleMgr.OnTick(deltaTime);
			}
			DropCatchGameplayCommandMgr gameplayCommandMgr = this.GameplayCommandMgr;
			if (gameplayCommandMgr != null)
			{
				gameplayCommandMgr.OnTick(deltaTime);
			}
			DropCatchGameplayCollisionMgr gameplayCollisionMgr = this.GameplayCollisionMgr;
			if (gameplayCollisionMgr == null)
			{
				return;
			}
			gameplayCollisionMgr.OnTick(deltaTime);
		}

		// Token: 0x06042DBE RID: 273854 RVA: 0x01129694 File Offset: 0x01127894
		public void UseRoleSkill()
		{
			DropCatchGameplayRoleMgr gameplayRoleMgr = this.GameplayRoleMgr;
			bool flag;
			if (gameplayRoleMgr == null)
			{
				flag = true;
			}
			else
			{
				IRoleInstance role = gameplayRoleMgr.GetRole();
				flag = (((role != null) ? new EDropCatchRoleSkillState?(role.GetSkillState()) : null).GetValueOrDefault() != EDropCatchRoleSkillState.Enable);
			}
			if (flag)
			{
				return;
			}
			DropCatchGameplayRoleMgr gameplayRoleMgr2 = this.GameplayRoleMgr;
			if (gameplayRoleMgr2 != null)
			{
				IRoleInstance role2 = gameplayRoleMgr2.GetRole();
				if (role2 != null)
				{
					role2.UseSkill();
				}
			}
			DropCatchGameplayCommandMgr gameplayCommandMgr = this.GameplayCommandMgr;
			if (gameplayCommandMgr == null)
			{
				return;
			}
			gameplayCommandMgr.ExecuteSkillCommand();
		}

		// Token: 0x06042DBF RID: 273855 RVA: 0x01129709 File Offset: 0x01127909
		public float GetEnergyGetRate()
		{
			return this.EnergyGetRate.GetFinalValue();
		}

		// Token: 0x06042DC0 RID: 273856 RVA: 0x01129716 File Offset: 0x01127916
		public float GetAddScoreRate()
		{
			return this.AddScoreRate.GetFinalValue();
		}

		// Token: 0x06042DC1 RID: 273857 RVA: 0x01129723 File Offset: 0x01127923
		[NullableContext(2)]
		public IRoleInstance GetRole()
		{
			DropCatchGameplayRoleMgr gameplayRoleMgr = this.GameplayRoleMgr;
			if (gameplayRoleMgr == null)
			{
				return null;
			}
			return gameplayRoleMgr.GetRole();
		}

		// Token: 0x06042DC2 RID: 273858 RVA: 0x01129736 File Offset: 0x01127936
		public float GetRemainingTime()
		{
			DropCatchGameplayTimeMgr gameplayTimeMgr = this.GameplayTimeMgr;
			if (gameplayTimeMgr == null)
			{
				return 0f;
			}
			return gameplayTimeMgr.GetRemainingTime();
		}

		// Token: 0x06042DC3 RID: 273859 RVA: 0x0112974D File Offset: 0x0112794D
		public DropCatchGameplayAttribute GetAddScoreRateAttr()
		{
			return this.AddScoreRate;
		}

		// Token: 0x06042DC4 RID: 273860 RVA: 0x01129755 File Offset: 0x01127955
		public DropCatchGameplayAttribute GetEnergyGetRateAttr()
		{
			return this.EnergyGetRate;
		}

		// Token: 0x06042DC5 RID: 273861 RVA: 0x0112975D File Offset: 0x0112795D
		public EDropCatchGameplayState GetGameplayState()
		{
			return this.GameplayState;
		}

		// Token: 0x06042DC6 RID: 273862 RVA: 0x01129768 File Offset: 0x01127968
		public void Destroy()
		{
			this.End();
			DropCatchGameplayTimeMgr gameplayTimeMgr = this.GameplayTimeMgr;
			if (gameplayTimeMgr != null)
			{
				gameplayTimeMgr.Destroy();
			}
			DropCatchGameplayRoleMgr gameplayRoleMgr = this.GameplayRoleMgr;
			if (gameplayRoleMgr != null)
			{
				gameplayRoleMgr.Destroy();
			}
			DropCatchGameplayDropItemMgr gameplayDropItemMgr = this.GameplayDropItemMgr;
			if (gameplayDropItemMgr != null)
			{
				gameplayDropItemMgr.Destroy();
			}
			DropCatchGameplayCollisionMgr gameplayCollisionMgr = this.GameplayCollisionMgr;
			if (gameplayCollisionMgr != null)
			{
				gameplayCollisionMgr.Destroy();
			}
			DropCatchGameplayCommandMgr gameplayCommandMgr = this.GameplayCommandMgr;
			if (gameplayCommandMgr != null)
			{
				gameplayCommandMgr.Destroy();
			}
			DropCatchGameplayInputMgr gameplayInputMgr = this.GameplayInputMgr;
			if (gameplayInputMgr != null)
			{
				gameplayInputMgr.Destroy();
			}
			DropCatchGameplayModifierMgr gameplayModifierMgr = this.GameplayModifierMgr;
			if (gameplayModifierMgr == null)
			{
				return;
			}
			gameplayModifierMgr.Destroy();
		}

		// Token: 0x0402540C RID: 152588
		[Nullable(2)]
		private Ticker TickId;

		// Token: 0x0402540D RID: 152589
		public DropCatchGameplayProxy Proxy;

		// Token: 0x0402540E RID: 152590
		[Nullable(2)]
		private DropCatchGameplayTimeMgr GameplayTimeMgr;

		// Token: 0x0402540F RID: 152591
		[Nullable(2)]
		private DropCatchGameplayRoleMgr GameplayRoleMgr;

		// Token: 0x04025410 RID: 152592
		[Nullable(2)]
		private DropCatchGameplayDropItemMgr GameplayDropItemMgr;

		// Token: 0x04025411 RID: 152593
		[Nullable(2)]
		private DropCatchGameplayCollisionMgr GameplayCollisionMgr;

		// Token: 0x04025412 RID: 152594
		[Nullable(2)]
		private DropCatchGameplayCommandMgr GameplayCommandMgr;

		// Token: 0x04025413 RID: 152595
		[Nullable(2)]
		private DropCatchGameplayModifierMgr GameplayModifierMgr;

		// Token: 0x04025414 RID: 152596
		private IDropCatchGameplayArea GameplayArea;

		// Token: 0x04025415 RID: 152597
		private DropCatchGameplayAttribute AddScoreRate;

		// Token: 0x04025416 RID: 152598
		private DropCatchGameplayAttribute EnergyGetRate;

		// Token: 0x04025417 RID: 152599
		private EDropCatchGameplayState GameplayState = EDropCatchGameplayState.End;

		// Token: 0x04025418 RID: 152600
		private EDropCatchGameplayState StateBeforePause = EDropCatchGameplayState.End;

		// Token: 0x04025419 RID: 152601
		[Nullable(2)]
		private DropCatchGameplayInputMgr GameplayInputMgr;
	}
}
