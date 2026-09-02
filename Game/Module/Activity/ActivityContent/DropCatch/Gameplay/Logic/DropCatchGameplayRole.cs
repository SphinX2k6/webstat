using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200693E RID: 26942
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayRole : IRoleInstance
	{
		// Token: 0x1700A1CC RID: 41420
		// (get) Token: 0x06042DD1 RID: 273873 RVA: 0x01129D2F File Offset: 0x01127F2F
		// (set) Token: 0x06042DD2 RID: 273874 RVA: 0x01129D38 File Offset: 0x01127F38
		protected float Energy
		{
			get
			{
				return this.EnergyInner;
			}
			set
			{
				if (this.EnergyInner == value)
				{
					return;
				}
				if (value == 0f && this.SkillState == EDropCatchRoleSkillState.InSkill)
				{
					this.EndSkill();
				}
				EDropCatchRoleSkillState edropCatchRoleSkillState = this.ComputeSkillStateByEnergy(value, this.MaxEnergy);
				if (edropCatchRoleSkillState != this.SkillState)
				{
					this.SkillState = edropCatchRoleSkillState;
					DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
					if (gameplayView != null)
					{
						gameplayView.UpdateRoleSkillState();
					}
				}
				this.EnergyInner = value;
				DropCatchGameplayView gameplayView2 = this.Context.GetProxy().GetGameplayView();
				if (gameplayView2 == null)
				{
					return;
				}
				gameplayView2.UpdateRoleEnergy();
			}
		}

		// Token: 0x06042DD3 RID: 273875 RVA: 0x01129DC0 File Offset: 0x01127FC0
		private EDropCatchRoleSkillState ComputeSkillStateByEnergy(float energy, float maxEnergy)
		{
			if (energy == 0f)
			{
				return EDropCatchRoleSkillState.Disable;
			}
			if (energy.Equals(maxEnergy))
			{
				if (this.SkillState != EDropCatchRoleSkillState.InSkill)
				{
					return EDropCatchRoleSkillState.Enable;
				}
				return EDropCatchRoleSkillState.InSkill;
			}
			else
			{
				if (this.SkillState != EDropCatchRoleSkillState.InSkill)
				{
					return EDropCatchRoleSkillState.Disable;
				}
				return EDropCatchRoleSkillState.InSkill;
			}
		}

		// Token: 0x06042DD4 RID: 273876 RVA: 0x01129DF0 File Offset: 0x01127FF0
		public void Init(IDropCatchRoleParams @params)
		{
			this.Context = @params.Context;
			DropCatchGameplay? gameplayConfig = this.Context.GetProxy().GetGameplayConfig();
			if (gameplayConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "GetGameplayConfig is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.MoveDirection = EDropCatchRoleDirection.None;
			this.FacingDirection = EDropCatchRoleDirection.Right;
			this.SkillStartTime = 0f;
			this.SkillState = EDropCatchRoleSkillState.Disable;
			this.ShieldTime = 0f;
			this.AnimState = EDropCatchRoleAnimState.IdleBowlRight;
			this.RoleId = @params.RoleId;
			DropCatchRole? dropCatchRoleById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchRoleById(this.RoleId);
			if (dropCatchRoleById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 1);
				defaultInterpolatedStringHandler.AppendLiteral("DropCatchRoleById is null, RoleId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.RoleId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Speed = new DropCatchGameplayAttribute("RoleSpeed", dropCatchRoleById.Value.MoveSpeed);
			this.Energy = 0f;
			this.MaxEnergy = dropCatchRoleById.Value.MaxEnergy;
			this.EnergyGetRate = dropCatchRoleById.Value.EnergyGetRate;
			this.EnergySelfRecover = dropCatchRoleById.Value.EnergySelfRecover;
			this.SkillReduceEnergy = dropCatchRoleById.Value.SkillReduceEnergy;
			this.SkillReduceEnergyRateInterval = dropCatchRoleById.Value.SkillReduceEnergyRateInterval * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.SkillReduceEnergyRate = dropCatchRoleById.Value.SkillReduceEnergyRate;
			this.RolePos.Set((double)gameplayConfig.Value.RoleBornPos(0), (double)gameplayConfig.Value.RoleBornPos(1));
			this.RoleSize.Set((double)dropCatchRoleById.Value.RoleSize(0), (double)dropCatchRoleById.Value.RoleSize(1));
			this.BowlSize.Set((double)dropCatchRoleById.Value.BowlSize(0), (double)dropCatchRoleById.Value.BowlSize(1));
			this.RoleBoundsOffset.Set((double)dropCatchRoleById.Value.RoleSizeBiasNew(0), (double)dropCatchRoleById.Value.RoleSizeBiasNew(1));
			this.BowlBoundsOffset.Set((double)dropCatchRoleById.Value.BowlSizeBiasNew(0), (double)dropCatchRoleById.Value.BowlSizeBiasNew(1));
			this.MaxOffsetX = (float)Math.Max(this.BowlSize.X, this.RoleSize.X) / 2f;
			this.UpdatePosition(0f);
			this.UpdateBounds();
		}

		// Token: 0x06042DD5 RID: 273877 RVA: 0x0112A0BF File Offset: 0x011282BF
		public void OnReadyTick(float deltaTime)
		{
			this.UpdateDirection();
			this.UpdatePosition(deltaTime);
			this.UpdateAnimationState();
		}

		// Token: 0x06042DD6 RID: 273878 RVA: 0x0112A0D4 File Offset: 0x011282D4
		public void OnTick(float deltaTime)
		{
			this.UpdateDirection();
			this.UpdateEnergy(deltaTime);
			this.UpdateShieldTime(deltaTime);
			this.UpdatePosition(deltaTime);
			this.UpdateBounds();
			this.UpdateAnimationState();
		}

		// Token: 0x06042DD7 RID: 273879 RVA: 0x0112A0FD File Offset: 0x011282FD
		protected void UpdateDirection()
		{
			this.MoveDirection = this.Context.GetGameplayInputMgr().Get(EDropCatchGameplayInputChannel.MoveDirection, EDropCatchRoleDirection.None);
			if (this.MoveDirection != EDropCatchRoleDirection.None)
			{
				this.FacingDirection = this.MoveDirection;
			}
		}

		// Token: 0x06042DD8 RID: 273880 RVA: 0x0112A12C File Offset: 0x0112832C
		protected void UpdatePosition(float deltaTime)
		{
			this.RolePos.X = Singleton<MathUtils>.Instance.Clamp(this.RolePos.X + (double)(this.Speed.GetFinalValue() * (float)this.MoveDirection * deltaTime), this.Context.GetGameplayArea().MinX + (double)this.MaxOffsetX, this.Context.GetGameplayArea().MaxX - (double)this.MaxOffsetX);
			DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
			if (gameplayView == null)
			{
				return;
			}
			DropCatchGameplayRoleView roleView = gameplayView.GetRoleView();
			if (roleView == null)
			{
				return;
			}
			roleView.UpdateRolePos(this.RolePos);
		}

		// Token: 0x06042DD9 RID: 273881 RVA: 0x0112A1CC File Offset: 0x011283CC
		protected void UpdateAnimationState()
		{
			bool flag = this.MoveDirection > EDropCatchRoleDirection.None;
			EDropCatchRoleAnimState edropCatchRoleAnimState;
			if (this.FacingDirection == EDropCatchRoleDirection.Left)
			{
				edropCatchRoleAnimState = (flag ? EDropCatchRoleAnimState.WalkBowlLeft : EDropCatchRoleAnimState.IdleBowlLeft);
			}
			else
			{
				edropCatchRoleAnimState = (flag ? EDropCatchRoleAnimState.WalkBowlRight : EDropCatchRoleAnimState.IdleBowlRight);
			}
			if (this.AnimState != edropCatchRoleAnimState)
			{
				this.AnimState = edropCatchRoleAnimState;
				DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
				if (gameplayView == null)
				{
					return;
				}
				DropCatchGameplayRoleView roleView = gameplayView.GetRoleView();
				if (roleView == null)
				{
					return;
				}
				roleView.PlayAnimation(this.AnimState);
			}
		}

		// Token: 0x06042DDA RID: 273882 RVA: 0x0112A238 File Offset: 0x01128438
		protected void UpdateBounds()
		{
			this.RoleBoundCenter.Set(this.RolePos.X + this.RoleBoundsOffset.X, this.RolePos.Y + this.RoleBoundsOffset.Y);
			this.BowlBoundCenter.Set(this.RolePos.X + this.BowlBoundsOffset.X, this.RolePos.Y + this.BowlBoundsOffset.Y);
			DropCatchGameplayHelper.CalculateBounds(this.RoleBoundCenter, this.RoleSize, this.RoleBounds);
			DropCatchGameplayHelper.CalculateBounds(this.BowlBoundCenter, this.BowlSize, this.BowlBounds);
		}

		// Token: 0x06042DDB RID: 273883 RVA: 0x0112A2E5 File Offset: 0x011284E5
		protected void UpdateEnergy(float deltaTime)
		{
			if (this.SkillState == EDropCatchRoleSkillState.InSkill)
			{
				this.ConsumeEnergy(deltaTime);
				return;
			}
			this.AddEnergy((float)((double)(this.EnergySelfRecover * deltaTime) * Singleton<TimeUtil>.Instance.Millisecond), false);
		}

		// Token: 0x06042DDC RID: 273884 RVA: 0x0112A314 File Offset: 0x01128514
		public IDropCatchBounds GetBowlBounds()
		{
			return this.BowlBounds;
		}

		// Token: 0x06042DDD RID: 273885 RVA: 0x0112A31C File Offset: 0x0112851C
		public IDropCatchBounds GetRoleBounds()
		{
			return this.RoleBounds;
		}

		// Token: 0x06042DDE RID: 273886 RVA: 0x0112A324 File Offset: 0x01128524
		public void AddEnergy(float energy, bool calRate)
		{
			float num = energy;
			if (num > 0f)
			{
				float num2 = num * (calRate ? this.EnergyGetRate : 1f);
				DropCatchGameplayLogic gameplayLogic = this.Context.GetProxy().GetGameplayLogic();
				num = num2 * ((gameplayLogic != null) ? gameplayLogic.GetEnergyGetRate() : 1f);
			}
			this.Energy = Singleton<MathUtils>.Instance.Clamp(this.Energy + num, 0f, this.MaxEnergy);
		}

		// Token: 0x06042DDF RID: 273887 RVA: 0x0112A392 File Offset: 0x01128592
		public void FullEnergy()
		{
			this.Energy = this.MaxEnergy;
		}

		// Token: 0x06042DE0 RID: 273888 RVA: 0x0112A3A0 File Offset: 0x011285A0
		protected void ConsumeEnergy(float deltaTime)
		{
			if (this.SkillState != EDropCatchRoleSkillState.InSkill)
			{
				return;
			}
			double y = Math.Floor((double)((this.Context.GetGameplayTimeMgr().GetTime() - this.SkillStartTime) / this.SkillReduceEnergyRateInterval));
			double num = Math.Pow((double)this.SkillReduceEnergyRate, y);
			double num2 = (double)this.SkillReduceEnergy * num * (double)deltaTime * Singleton<TimeUtil>.Instance.Millisecond;
			this.Energy = Math.Max(0f, this.Energy - (float)num2);
		}

		// Token: 0x06042DE1 RID: 273889 RVA: 0x0112A41B File Offset: 0x0112861B
		public void UseSkill()
		{
			this.SkillStartTime = this.Context.GetGameplayTimeMgr().GetTime();
			this.SkillState = EDropCatchRoleSkillState.InSkill;
			DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
			if (gameplayView != null)
			{
				gameplayView.UpdateRoleSkillState();
			}
			this.OnSkillStart();
		}

		// Token: 0x06042DE2 RID: 273890 RVA: 0x0112A45B File Offset: 0x0112865B
		protected virtual void OnSkillStart()
		{
		}

		// Token: 0x06042DE3 RID: 273891 RVA: 0x0112A460 File Offset: 0x01128660
		private void EndSkill()
		{
			if (this.SkillState != EDropCatchRoleSkillState.InSkill)
			{
				return;
			}
			this.SkillStartTime = 0f;
			this.SkillState = EDropCatchRoleSkillState.Disable;
			DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
			if (gameplayView != null)
			{
				gameplayView.UpdateRoleSkillState();
			}
			this.Context.GetGameplayModifierMgr().ClearAllSkillModifiers();
			this.OnSkillEnd();
		}

		// Token: 0x06042DE4 RID: 273892 RVA: 0x0112A4BA File Offset: 0x011286BA
		protected virtual void OnSkillEnd()
		{
		}

		// Token: 0x06042DE5 RID: 273893 RVA: 0x0112A4BC File Offset: 0x011286BC
		public void AddShield(float time)
		{
			this.ShieldTime = time * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
			if (gameplayView != null)
			{
				DropCatchGameplayRoleView roleView = gameplayView.GetRoleView();
				if (roleView != null)
				{
					DropCatchGameplayRoleFxView fxView = roleView.GetFxView();
					if (fxView != null)
					{
						fxView.PlayShield();
					}
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DropCatch;
			ELogAuthor author = ELogAuthor.CB;
			string message = "添加护盾";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("time", time);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06042DE6 RID: 273894 RVA: 0x0112A53C File Offset: 0x0112873C
		public void RemoveShield()
		{
			this.ShieldTime = 0f;
			DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
			if (gameplayView != null)
			{
				DropCatchGameplayRoleView roleView = gameplayView.GetRoleView();
				if (roleView != null)
				{
					DropCatchGameplayRoleFxView fxView = roleView.GetFxView();
					if (fxView != null)
					{
						fxView.PlayShieldEnd();
					}
				}
			}
			Singleton<Log>.Instance.Info(ELogModule.DropCatch, ELogAuthor.CB, "移除护盾", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06042DE7 RID: 273895 RVA: 0x0112A5A4 File Offset: 0x011287A4
		public void UpdateShieldTime(float deltaTime)
		{
			if (this.ShieldTime <= 0f)
			{
				return;
			}
			if (this.ShieldTime > 0f)
			{
				this.ShieldTime -= deltaTime;
				if (this.ShieldTime <= 0f)
				{
					this.RemoveShield();
				}
			}
		}

		// Token: 0x06042DE8 RID: 273896 RVA: 0x0112A5E2 File Offset: 0x011287E2
		public bool IsInShield()
		{
			return this.ShieldTime > 0f;
		}

		// Token: 0x06042DE9 RID: 273897 RVA: 0x0112A5F1 File Offset: 0x011287F1
		public EDropCatchRoleSkillState GetSkillState()
		{
			return this.SkillState;
		}

		// Token: 0x06042DEA RID: 273898 RVA: 0x0112A5F9 File Offset: 0x011287F9
		public int GetRoleId()
		{
			return this.RoleId;
		}

		// Token: 0x06042DEB RID: 273899 RVA: 0x0112A601 File Offset: 0x01128801
		public float GetEnergy()
		{
			return this.Energy;
		}

		// Token: 0x06042DEC RID: 273900 RVA: 0x0112A609 File Offset: 0x01128809
		public float GetMaxEnergy()
		{
			return this.MaxEnergy;
		}

		// Token: 0x06042DED RID: 273901 RVA: 0x0112A611 File Offset: 0x01128811
		public Vector2D GetRolePos()
		{
			return this.RolePos;
		}

		// Token: 0x06042DEE RID: 273902 RVA: 0x0112A619 File Offset: 0x01128819
		public DropCatchGameplayAttribute GetSpeedAttr()
		{
			return this.Speed;
		}

		// Token: 0x06042DEF RID: 273903 RVA: 0x0112A624 File Offset: 0x01128824
		public Vector2D GetFloatEffPos()
		{
			this.FloatEffPos.Set(this.RolePos.X, this.RolePos.Y + this.RoleSize.Y / 2.0 + this.BowlSize.Y);
			return this.FloatEffPos;
		}

		// Token: 0x06042DF0 RID: 273904 RVA: 0x0112A67A File Offset: 0x0112887A
		public float GetEnergyGetRate()
		{
			return this.EnergyGetRate;
		}

		// Token: 0x06042DF1 RID: 273905 RVA: 0x0112A682 File Offset: 0x01128882
		public float GetEnergySelfRecover()
		{
			return this.EnergySelfRecover;
		}

		// Token: 0x06042DF2 RID: 273906 RVA: 0x0112A68A File Offset: 0x0112888A
		public float GetSkillReduceEnergy()
		{
			return this.SkillReduceEnergy;
		}

		// Token: 0x06042DF3 RID: 273907 RVA: 0x0112A692 File Offset: 0x01128892
		public float GetSkillReduceEnergyRateInterval()
		{
			return this.SkillReduceEnergyRateInterval;
		}

		// Token: 0x06042DF4 RID: 273908 RVA: 0x0112A69A File Offset: 0x0112889A
		public float GetSkillReduceEnergyRate()
		{
			return this.SkillReduceEnergyRate;
		}

		// Token: 0x06042DF5 RID: 273909 RVA: 0x0112A6A2 File Offset: 0x011288A2
		public float GetShieldTime()
		{
			return this.ShieldTime;
		}

		// Token: 0x06042DF6 RID: 273910 RVA: 0x0112A6AA File Offset: 0x011288AA
		public EDropCatchRoleAnimState GetAnimState()
		{
			return this.AnimState;
		}

		// Token: 0x06042DF7 RID: 273911 RVA: 0x0112A6B2 File Offset: 0x011288B2
		public Vector2D GetRoleSize()
		{
			return this.RoleSize;
		}

		// Token: 0x06042DF8 RID: 273912 RVA: 0x0112A6BA File Offset: 0x011288BA
		public Vector2D GetBowlSize()
		{
			return this.BowlSize;
		}

		// Token: 0x0402541F RID: 152607
		protected Vector2D RolePos = Vector2D.Create();

		// Token: 0x04025420 RID: 152608
		protected Vector2D RoleBoundCenter = Vector2D.Create();

		// Token: 0x04025421 RID: 152609
		protected Vector2D BowlBoundCenter = Vector2D.Create();

		// Token: 0x04025422 RID: 152610
		protected Vector2D RoleSize = Vector2D.Create();

		// Token: 0x04025423 RID: 152611
		protected Vector2D BowlSize = Vector2D.Create();

		// Token: 0x04025424 RID: 152612
		protected Vector2D RoleBoundsOffset = Vector2D.Create();

		// Token: 0x04025425 RID: 152613
		protected Vector2D BowlBoundsOffset = Vector2D.Create();

		// Token: 0x04025426 RID: 152614
		protected int RoleId;

		// Token: 0x04025427 RID: 152615
		protected EDropCatchRoleAnimState AnimState = EDropCatchRoleAnimState.IdleBowlRight;

		// Token: 0x04025428 RID: 152616
		protected EDropCatchRoleSkillState SkillState;

		// Token: 0x04025429 RID: 152617
		protected DropCatchGameplayAttribute Speed;

		// Token: 0x0402542A RID: 152618
		protected float EnergyInner;

		// Token: 0x0402542B RID: 152619
		protected float MaxEnergy;

		// Token: 0x0402542C RID: 152620
		protected float EnergyGetRate;

		// Token: 0x0402542D RID: 152621
		protected float EnergySelfRecover;

		// Token: 0x0402542E RID: 152622
		protected float SkillReduceEnergy;

		// Token: 0x0402542F RID: 152623
		protected float SkillReduceEnergyRateInterval;

		// Token: 0x04025430 RID: 152624
		protected float SkillReduceEnergyRate;

		// Token: 0x04025431 RID: 152625
		protected float SkillStartTime;

		// Token: 0x04025432 RID: 152626
		protected readonly IDropCatchBounds BowlBounds = new IDropCatchBounds
		{
			Left = 0.0,
			Right = 0.0,
			Top = 0.0,
			Bottom = 0.0
		};

		// Token: 0x04025433 RID: 152627
		protected readonly IDropCatchBounds RoleBounds = new IDropCatchBounds
		{
			Left = 0.0,
			Right = 0.0,
			Top = 0.0,
			Bottom = 0.0
		};

		// Token: 0x04025434 RID: 152628
		protected EDropCatchRoleDirection MoveDirection;

		// Token: 0x04025435 RID: 152629
		protected EDropCatchRoleDirection FacingDirection = EDropCatchRoleDirection.Right;

		// Token: 0x04025436 RID: 152630
		protected float MaxOffsetX;

		// Token: 0x04025437 RID: 152631
		protected float ShieldTime;

		// Token: 0x04025438 RID: 152632
		protected IGameplayLogicContext Context;

		// Token: 0x04025439 RID: 152633
		protected Vector2D FloatEffPos = Vector2D.Create();
	}
}
