using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform;
using CSharpScript.Game.Module.Teleport;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState
{
	// Token: 0x02006AA9 RID: 27305
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritFlyingEffectState : SunSpiritBaseState
	{
		// Token: 0x06043859 RID: 276569 RVA: 0x01167AD4 File Offset: 0x01165CD4
		protected SunSpiritFlyingEffectState(ESunSpiritStateType stateType, SunSpiritData sunSpiritData, float waitBeforeFlyDuration, float flyingDuration) : base(stateType, sunSpiritData)
		{
			this.WaitBeforeFlyDuration = waitBeforeFlyDuration;
			this.FlyingDuration = flyingDuration;
		}

		// Token: 0x0604385A RID: 276570 RVA: 0x01167B24 File Offset: 0x01165D24
		protected override bool OnEnter()
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritConfig sunSpiritConfig = (instance != null) ? instance.GetSunSpiritConfig() : null;
			if (sunSpiritConfig == null)
			{
				return false;
			}
			this.TempVector.Reset();
			this.TempQuat.Reset();
			this.MaxFlyDistSquared = sunSpiritConfig.FlyingEffectMaxDist * sunSpiritConfig.FlyingEffectMaxDist;
			this.MinFlyDistSquared = sunSpiritConfig.FlyingEffectMinDist * sunSpiritConfig.FlyingEffectMinDist;
			this.MaxFailingCount = sunSpiritConfig.FlyingEffectUpdateFailMaxCount;
			this.MaxFailingTime = sunSpiritConfig.FlyingEffectUpdateFailMaxTimeSec;
			this.MaxFlyingTime = sunSpiritConfig.FlyingEffectMaxFlyingDuration;
			if (!Singleton<EventSystem>.Instance.Has(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.LeaveInstanceDungeon, new Action(this.OnTeleportOrTransition)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.OnTeleportOrTransition));
			}
			return true;
		}

		// Token: 0x0604385B RID: 276571 RVA: 0x01167C1C File Offset: 0x01165E1C
		protected override void OnExit()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.LeaveInstanceDungeon, new Action(this.OnTeleportOrTransition)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.OnTeleportOrTransition));
			}
			if (!this.KeepEffect)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.FlyingEffectHandle, "SunSpiritFlyToTargetEnd", false, null);
				this.FlyingEffectHandle = 0;
			}
			if (this.IsInterrupt)
			{
				Action flyingInterruptCallback = this.FlyingInterruptCallback;
				if (flyingInterruptCallback == null)
				{
					return;
				}
				flyingInterruptCallback();
				return;
			}
			else
			{
				Action flyingFinishCallback = this.FlyingFinishCallback;
				if (flyingFinishCallback == null)
				{
					return;
				}
				flyingFinishCallback();
				return;
			}
		}

		// Token: 0x0604385C RID: 276572 RVA: 0x01167CF3 File Offset: 0x01165EF3
		private void OnTeleportStart(bool loading)
		{
			this.OnTeleportOrTransition();
		}

		// Token: 0x0604385D RID: 276573 RVA: 0x01167CFC File Offset: 0x01165EFC
		private unsafe void OnTeleportOrTransition()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SunSpirit;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "日灵: 飞行中遇到传送或切场景，直接尝试设置到终点并结束";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SunSpiritId", this.SunSpiritData.SunSpiritId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SunSpiritConfigId", this.SunSpiritData.ConfigId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Vector tempVector = this.TempVector;
			Quat tempQuat = this.TempQuat;
			Func<Vector, Quat, bool> flyingTargetGetter = this.FlyingTargetGetter;
			if (flyingTargetGetter != null && flyingTargetGetter(tempVector, tempQuat))
			{
				this.SunSpiritData.SetLocationAndRotation(tempVector, tempQuat);
			}
			this.OnSunSpiritFlyToTargetEnd(false, true);
		}

		// Token: 0x0604385E RID: 276574 RVA: 0x01167DB8 File Offset: 0x01165FB8
		private unsafe void OnFlyingFailing(float deltaSeconds)
		{
			this.FlyingFailingTime += deltaSeconds;
			if (this.FlyingFailingTime > this.MaxFailingTime)
			{
				int num = this.FlyingFailingCount + 1;
				this.FlyingFailingCount = num;
				if (num > this.MaxFailingCount)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SunSpirit;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "日灵: 飞行中错误累积超时，直接结束";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SunSpiritId", this.SunSpiritData.SunSpiritId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SunSpiritConfigId", this.SunSpiritData.ConfigId);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.OnSunSpiritFlyToTargetEnd(false, true);
					return;
				}
				this.FlyingFailingTime = 0f;
			}
		}

		// Token: 0x0604385F RID: 276575 RVA: 0x01167E88 File Offset: 0x01166088
		protected unsafe override void OnTick(float deltaSeconds)
		{
			TeleportModel instance = ModelBase<TeleportModel>.Instance;
			if (instance == null || !instance.IsTeleport)
			{
				GameModeModel instance2 = ModelBase<GameModeModel>.Instance;
				if (instance2 != null && instance2.WorldDoneAndLoadingClosed)
				{
					if (this.CurrentWaitingBeforeFlyDuration < this.WaitBeforeFlyDuration)
					{
						this.CurrentWaitingBeforeFlyDuration = Singleton<MathUtils>.Instance.Clamp(this.CurrentWaitingBeforeFlyDuration + deltaSeconds, 0f, this.WaitBeforeFlyDuration);
						if (!(this.SunSpiritData.GetSunSpiritPerform() is SunSpiritNonePerform))
						{
							Transform transform = Transform.Create();
							((ISunSpiritScenePerform)this.SunSpiritData.GetSunSpiritPerform()).GetTransform(transform);
							this.SunSpiritData.ChangeSunSpiritPerform(new SunSpiritNonePerform(this.SunSpiritData, transform));
						}
						return;
					}
					this.CurrentFlyingDuration = Singleton<MathUtils>.Instance.Clamp(this.CurrentFlyingDuration + deltaSeconds, 0f, this.FlyingDuration);
					if (!(this.SunSpiritData.GetSunSpiritPerform() is SunSpiritEffectPerform))
					{
						Transform transform2 = Transform.Create();
						((ISunSpiritScenePerform)this.SunSpiritData.GetSunSpiritPerform()).GetTransform(transform2);
						this.SunSpiritData.ChangeSunSpiritPerform(new SunSpiritEffectPerform(this.SunSpiritData, transform2));
					}
					Vector tempVector = this.TempVector;
					Quat tempQuat = this.TempQuat;
					Func<Vector, Quat, bool> flyingTargetGetter = this.FlyingTargetGetter;
					if (flyingTargetGetter == null || !flyingTargetGetter(tempVector, tempQuat))
					{
						this.OnFlyingFailing(deltaSeconds);
						return;
					}
					Vector location = this.SunSpiritData.Location;
					Quat quaternion = this.SunSpiritData.Quaternion;
					if (location == null || quaternion == null)
					{
						this.OnFlyingFailing(deltaSeconds);
						return;
					}
					this.FlyingFailingTime = 0f;
					this.FlyingFailingCount = 0;
					if (this.CurrentFlyingDuration > this.MaxFlyingTime)
					{
						this.SunSpiritData.SetLocationAndRotation(tempVector, tempQuat);
						this.OnSunSpiritFlyToTargetEnd(false, false);
						return;
					}
					double num = Vector.DistSquared(location, tempVector);
					if (num > (double)this.MaxFlyDistSquared || num < (double)this.MinFlyDistSquared)
					{
						this.SunSpiritData.SetLocationAndRotation(tempVector, tempQuat);
						this.OnSunSpiritFlyToTargetEnd(false, false);
						return;
					}
					float num2 = this.FlyingDuration - this.CurrentFlyingDuration;
					float num3 = Singleton<MathUtils>.Instance.Clamp(deltaSeconds / num2, 0f, 1f);
					Vector.Lerp(location, tempVector, (double)num3, tempVector);
					Quat.Slerp(quaternion, tempQuat, num3, tempQuat);
					this.SunSpiritData.SetLocationAndRotation(tempVector, tempQuat);
					SundryModel instance3 = ModelBase<SundryModel>.Instance;
					if (((instance3 != null) ? instance3.GetModuleDebugLevel("SunSpirit") : 0) >= 2)
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.SunSpirit;
						ELogAuthor author = ELogAuthor.ZYL;
						string message = "日灵: 飞行中信息";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SunSpiritId", this.SunSpiritData.SunSpiritId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SunSpiritConfigId", this.SunSpiritData.ConfigId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Pos", tempVector);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Rot", tempQuat);
						instance4.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					}
					return;
				}
			}
			this.OnTeleportOrTransition();
		}

		// Token: 0x06043860 RID: 276576 RVA: 0x01168178 File Offset: 0x01166378
		public override bool IsSameState(SunSpiritBaseState otherState)
		{
			if (base.IsSameState(otherState))
			{
				SunSpiritFlyingEffectState sunSpiritFlyingEffectState = otherState as SunSpiritFlyingEffectState;
				if (sunSpiritFlyingEffectState != null && this.FlyingTargetGetter == sunSpiritFlyingEffectState.FlyingTargetGetter && this.FlyingFinishCallback == sunSpiritFlyingEffectState.FlyingFinishCallback)
				{
					return this.FlyingInterruptCallback == sunSpiritFlyingEffectState.FlyingInterruptCallback;
				}
			}
			return false;
		}

		// Token: 0x06043861 RID: 276577 RVA: 0x011681D1 File Offset: 0x011663D1
		protected virtual void OnSunSpiritFlyToTargetEnd(bool bKeepEffect = false, bool bIsInterrupt = false)
		{
			this.KeepEffect = bKeepEffect;
			this.IsInterrupt = bIsInterrupt;
			this.IsFinished = true;
		}

		// Token: 0x04025B8B RID: 154507
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x04025B8C RID: 154508
		private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04025B8D RID: 154509
		private float FlyingFailingTime;

		// Token: 0x04025B8E RID: 154510
		private int FlyingFailingCount;

		// Token: 0x04025B8F RID: 154511
		private int FlyingEffectHandle;

		// Token: 0x04025B90 RID: 154512
		private float CurrentWaitingBeforeFlyDuration;

		// Token: 0x04025B91 RID: 154513
		private float CurrentFlyingDuration;

		// Token: 0x04025B92 RID: 154514
		private float MaxFlyDistSquared;

		// Token: 0x04025B93 RID: 154515
		private float MaxFailingTime;

		// Token: 0x04025B94 RID: 154516
		private int MaxFailingCount;

		// Token: 0x04025B95 RID: 154517
		private float MinFlyDistSquared;

		// Token: 0x04025B96 RID: 154518
		private float MaxFlyingTime;

		// Token: 0x04025B97 RID: 154519
		protected bool IsInterrupt;

		// Token: 0x04025B98 RID: 154520
		protected bool KeepEffect;

		// Token: 0x04025B99 RID: 154521
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Func<Vector, Quat, bool> FlyingTargetGetter;

		// Token: 0x04025B9A RID: 154522
		[Nullable(2)]
		public Action FlyingFinishCallback;

		// Token: 0x04025B9B RID: 154523
		[Nullable(2)]
		public Action FlyingInterruptCallback;

		// Token: 0x04025B9C RID: 154524
		public float WaitBeforeFlyDuration;

		// Token: 0x04025B9D RID: 154525
		public float FlyingDuration;
	}
}
