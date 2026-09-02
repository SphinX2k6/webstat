using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;

// Token: 0x02000E03 RID: 3587
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraClimbController : CameraControllerBase<EFightCameraClimb>, ICanGetConfigMapValue
{
	// Token: 0x0600543E RID: 21566 RVA: 0x000C9AA2 File Offset: 0x000C7CA2
	public override string Name()
	{
		return "ClimbController";
	}

	// Token: 0x0600543F RID: 21567 RVA: 0x000C9AAC File Offset: 0x000C7CAC
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraClimb.退出攀爬淡出时间, "FadeOutDuration");
		base.SetConfigMap(EFightCameraClimb.无操作等待时间, "PrepTime");
		base.SetConfigMap(EFightCameraClimb.持续移动进入修正时间, "MoveDelayTime");
		base.SetConfigMap(EFightCameraClimb.镜头角度插值速度, "DefaultInterpSpeed");
		base.SetConfigMap(EFightCameraClimb.角色移动基准速度, "ReferToMoveSpeed");
		base.SetConfigMap(EFightCameraClimb.进入攀爬增加臂长, "AdditionalArmLength");
		base.SetConfigMap(EFightCameraClimb.进入攀爬修正时间, "FadeInCenterTime");
		base.SetConfigMap(EFightCameraClimb.进入攀爬淡出系数, "CenterStateBlendInExp");
		base.SetConfigMap(EFightCameraClimb.攀爬基准臂长, "DefaultArmLength");
		base.SetConfigMap(EFightCameraClimb.臂长插值速度, "ArmLengthSpeed");
		base.SetConfigMap(EFightCameraClimb.镜头预期朝向与角色移动方向夹角, "DesiredAngle");
		base.SetConfigMap(EFightCameraClimb.镜头预期朝向仰视角压缩倍率, "PitchUpRate");
		base.SetConfigMap(EFightCameraClimb.镜头预期朝向俯视角压缩倍率, "PitchDownRate");
		base.SetConfigMap(EFightCameraClimb.镜头预期朝向和角色面朝方向夹角合法范围, "ApplicableAngleWithCharacter");
		base.SetConfigMap(EFightCameraClimb.登顶镜头插值速度, "ReachThePeakSpeed");
		base.SetConfigMap(EFightCameraClimb.登顶镜头预期Pitch, "ReachThePeakPitch");
		base.SetConfigMap(EFightCameraClimb.大跨度输入角度阈值, "LargeAngleTurnThreshold");
		base.SetConfigMap(EFightCameraClimb.大跨度输入角度延迟响应时间, "LargeAngleTurnDelay");
		base.SetConfigMap(EFightCameraClimb.输入粘滞时间, "StopInputDelay");
		base.SetConfigMap(EFightCameraClimb.停止输入延迟响应时间, "StartInputDelay");
	}

	// Token: 0x06005440 RID: 21568 RVA: 0x000C9BB8 File Offset: 0x000C7DB8
	public CameraClimbController(FightCameraLogicComponent camera) : base(camera)
	{
		this.StateMachine = new StateMachine<CameraClimbController, CameraClimbController.ECameraState>(this, null);
		this.StateMachine.AddState<CameraClimbController.DefaultState>(CameraClimbController.ECameraState.Default, null);
		this.StateMachine.AddState<CameraClimbController.CenterState>(CameraClimbController.ECameraState.Center, null);
		this.StateMachine.AddState<CameraClimbController.ReadyState>(CameraClimbController.ECameraState.Ready, null);
		this.StateMachine.AddState<CameraClimbController.AdjustState>(CameraClimbController.ECameraState.Adjust, null);
		this.StateMachine.AddState<CameraClimbController.FadeOutState>(CameraClimbController.ECameraState.FadeOut, null);
		this.StateMachine.AddState<CameraClimbController.ReachThePeakState>(CameraClimbController.ECameraState.ReachThePeak, null);
		this.StateMachine.Start(CameraClimbController.ECameraState.Default);
	}

	// Token: 0x06005441 RID: 21569 RVA: 0x000C9C8C File Offset: 0x000C7E8C
	protected override void OnEnable()
	{
		EExitClimb exitClimbType = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterClimbComponent>().GetExitClimbType();
		if (this.CheckReachThePeak(exitClimbType))
		{
			this.StateMachine.Switch(CameraClimbController.ECameraState.Default);
		}
		else
		{
			this.StateMachine.Switch(CameraClimbController.ECameraState.Center);
		}
		this.Camera.CameraAdjustController.Lock(this);
		this.Camera.CameraAutoController.Lock(this);
		this.Camera.CameraSidestepController.Lock(this);
		this.LastValidInput.Reset();
		this.NextChangeInputTime = (float)(Singleton<Time>.Instance.Now + (double)(this.StartInputDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
		this.NextStopTime = 0f;
		this.IsMoving = false;
		Singleton<EventSystem>.Instance.Add<int, EExitClimb>(EEventName.CharClimbStartExit, new Action<int, EExitClimb>(this.OnCharClimbStartExit));
	}

	// Token: 0x06005442 RID: 21570 RVA: 0x000C9D68 File Offset: 0x000C7F68
	protected override void OnDisable()
	{
		this.Camera.CameraAdjustController.Unlock(this);
		this.Camera.CameraAutoController.Unlock(this);
		this.Camera.CameraSidestepController.Unlock(this);
		if (Singleton<EventSystem>.Instance.Has<int, EExitClimb>(EEventName.CharClimbStartExit, new Action<int, EExitClimb>(this.OnCharClimbStartExit)))
		{
			Singleton<EventSystem>.Instance.Remove<int, EExitClimb>(EEventName.CharClimbStartExit, new Action<int, EExitClimb>(this.OnCharClimbStartExit));
		}
	}

	// Token: 0x06005443 RID: 21571 RVA: 0x000C9DDB File Offset: 0x000C7FDB
	protected override bool UpdateCustomEnableCondition()
	{
		return this.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"], false);
	}

	// Token: 0x06005444 RID: 21572 RVA: 0x000C9DF8 File Offset: 0x000C7FF8
	protected override void UpdateInternal(float deltaSeconds)
	{
		this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>().GetMoveVector(this.TmpVector);
		if (this.CheckStateMayChange(this.TmpVector))
		{
			if (Singleton<Time>.Instance.Now > (double)this.NextChangeInputTime)
			{
				this.LastValidInput.DeepCopy(this.TmpVector);
				this.TmpVector.Set(0.0, this.LastValidInput.Y, this.LastValidInput.X);
				this.Camera.Character.CharacterActorComponent.ActorQuatProxy.RotateVector(this.TmpVector, this.MoveDirection);
				this.IsMoving = true;
				float speed = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterMoveComponent>().Speed;
				this.ElapseTimeScale = ((speed > this.ReferToMoveSpeed) ? (speed / this.ReferToMoveSpeed) : 1f);
				this.NextChangeInputTime = (float)(Singleton<Time>.Instance.Now + (double)(this.LargeAngleTurnDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
			}
			else if (this.IsMoving && Singleton<Time>.Instance.Now > (double)this.NextStopTime)
			{
				this.IsMoving = false;
				this.NextChangeInputTime = (float)(Singleton<Time>.Instance.Now + (double)(this.StartInputDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
			}
		}
		else if (this.IsMoving)
		{
			float speed2 = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterMoveComponent>().Speed;
			this.ElapseTimeScale = ((speed2 > this.ReferToMoveSpeed) ? (speed2 / this.ReferToMoveSpeed) : 1f);
		}
		this.StateMachine.Update(deltaSeconds);
	}

	// Token: 0x06005445 RID: 21573 RVA: 0x000C9FB0 File Offset: 0x000C81B0
	private bool CheckStateMayChange(Vector inputDirect)
	{
		bool flag = inputDirect.X != 0.0 || inputDirect.Y != 0.0;
		if (this.IsMoving)
		{
			if (flag)
			{
				this.NextStopTime = (float)(Singleton<Time>.Instance.Now + (double)(this.StopInputDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
				if (this.LastValidInput.X * inputDirect.X + this.LastValidInput.Y * inputDirect.Y > Math.Cos((double)(this.LargeAngleTurnThreshold * 0.017453292f)))
				{
					this.NextChangeInputTime = (float)(Singleton<Time>.Instance.Now + (double)(this.LargeAngleTurnDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
					float speed = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterMoveComponent>().Speed;
					this.ElapseTimeScale = ((speed > this.ReferToMoveSpeed) ? (speed / this.ReferToMoveSpeed) : 1f);
					return false;
				}
			}
			else
			{
				this.NextChangeInputTime = (float)(Singleton<Time>.Instance.Now + (double)(this.LargeAngleTurnDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
			}
		}
		else
		{
			this.NextStopTime = (float)(Singleton<Time>.Instance.Now + (double)(this.StopInputDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
			if (!flag)
			{
				this.NextChangeInputTime = (float)(Singleton<Time>.Instance.Now + (double)(this.StartInputDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
				return false;
			}
		}
		return true;
	}

	// Token: 0x06005446 RID: 21574 RVA: 0x000CA130 File Offset: 0x000C8330
	public void UpdateInterp(float deltaTime, float interpSpeed, Vector moveDirection)
	{
		CameraUtility.GetVectorInGravity(this.Camera.Character.CharacterActorComponent.ActorForwardProxy, this.ActorForwardInGravity);
		CameraUtility.GetVectorInGravity(moveDirection, this.MoveDirectionInGravity);
		this.TmpVector.DeepCopy(this.ActorForwardInGravity);
		this.TmpVector2.DeepCopy(this.MoveDirectionInGravity);
		if (Math.Abs(Math.Acos(this.TmpVector.DotProduct(this.TmpVector2)) * 57.295780181884766) > (double)this.DesiredAngle)
		{
			this.TmpVector.CrossProduct(this.TmpVector2, this.TmpVector2);
			this.TmpVector2.CrossProduct(this.TmpVector, this.TmpVector2);
			float num = this.DesiredAngle * 0.017453292f;
			this.TmpVector.MultiplyEqual(Math.Cos((double)num));
			this.TmpVector2.MultiplyEqual(Math.Sin((double)num));
			this.TmpVector.AdditionEqual(this.TmpVector2);
		}
		else
		{
			this.TmpVector.DeepCopy(this.MoveDirectionInGravity);
		}
		if (this.Camera.IsInNormalGravityMode())
		{
			this.Camera.CurrentCamera.ArmRotation.Vector(this.TmpVector2);
		}
		else
		{
			CameraUtility.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.TmpRotator);
			this.TmpRotator.Vector(this.TmpVector2);
		}
		double num2 = this.TmpVector2.X * this.ActorForwardInGravity.Y - this.TmpVector2.Y * this.ActorForwardInGravity.X;
		double num3 = this.TmpVector2.X * this.TmpVector.Y - this.TmpVector2.Y * this.TmpVector.X;
		double num4 = this.TmpVector.X * this.ActorForwardInGravity.Y - this.TmpVector.Y * this.ActorForwardInGravity.X;
		bool invertYaw = num2 * num3 < 0.0 && num2 * num4 < 0.0;
		Singleton<MathUtils>.Instance.LerpDirect2dByMaxAngle(this.TmpVector2, this.TmpVector, (double)((this.TmpVector.Z < 0.0) ? this.PitchDownRate : this.PitchUpRate), (double)(deltaTime * interpSpeed * this.ElapseTimeScale), invertYaw, this.TmpVector);
		if (this.Camera.IsInNormalGravityMode())
		{
			Rotator armRotation = this.Camera.DesiredCamera.ArmRotation;
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TmpVector, Vector.UpVectorProxy, armRotation);
		}
		else
		{
			this.TmpVector.Rotation(this.TmpRotator);
			CameraUtility.SetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.TmpRotator);
		}
		this.Camera.IsModifiedArmRotationPitch = true;
		this.Camera.IsModifiedArmRotationYaw = true;
	}

	// Token: 0x06005447 RID: 21575 RVA: 0x000CA418 File Offset: 0x000C8618
	public void OnCharClimbStartExit(int charId, EExitClimb exitClimbType)
	{
		if (this.Camera.CharacterEntityHandle.Id == charId && this.CheckReachThePeak(exitClimbType))
		{
			if (this.StateMachine.CurrentState.GetValueOrDefault() == CameraClimbController.ECameraState.Adjust)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.ReachThePeak);
				return;
			}
			if (this.StateMachine.CurrentState.GetValueOrDefault() == CameraClimbController.ECameraState.Center)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Default);
			}
		}
	}

	// Token: 0x06005448 RID: 21576 RVA: 0x000CA488 File Offset: 0x000C8688
	private bool CheckReachThePeak(EExitClimb exitClimbType)
	{
		return exitClimbType == EExitClimb.到顶退出 || exitClimbType - EExitClimb.地面登上 <= 2;
	}

	// Token: 0x06005449 RID: 21577 RVA: 0x000CA4A6 File Offset: 0x000C86A6
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraClimb)key);
	}

	// Token: 0x0600544A RID: 21578 RVA: 0x000CA4B0 File Offset: 0x000C86B0
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
			{
				char c = key[0];
				if (c != 'I')
				{
					if (c == 'P')
					{
						if (key == "PrepTime")
						{
							value = this.PrepTime;
							return true;
						}
					}
				}
				else if (key == "IsMoving")
				{
					value = this.IsMoving;
					return true;
				}
				break;
			}
			case 9:
				if (key == "TmpVector")
				{
					value = this.TmpVector;
					return true;
				}
				break;
			case 10:
			{
				char c = key[3];
				if (c != 'R')
				{
					if (c == 'V')
					{
						if (key == "TmpVector2")
						{
							value = this.TmpVector2;
							return true;
						}
					}
				}
				else if (key == "TmpRotator")
				{
					value = this.TmpRotator;
					return true;
				}
				break;
			}
			case 11:
				if (key == "PitchUpRate")
				{
					value = this.PitchUpRate;
					return true;
				}
				break;
			case 12:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c != 'N')
					{
						if (c == 'S')
						{
							if (key == "StateMachine")
							{
								value = this.StateMachine;
								return true;
							}
						}
					}
					else if (key == "NextStopTime")
					{
						value = this.NextStopTime;
						return true;
					}
				}
				else if (key == "DesiredAngle")
				{
					value = this.DesiredAngle;
					return true;
				}
				break;
			}
			case 13:
			{
				char c = key[5];
				if (c != 'D')
				{
					if (c != 'e')
					{
						if (c == 'i')
						{
							if (key == "MoveDirection")
							{
								value = this.MoveDirection;
								return true;
							}
						}
					}
					else if (key == "MoveDelayTime")
					{
						value = this.MoveDelayTime;
						return true;
					}
				}
				else if (key == "PitchDownRate")
				{
					value = this.PitchDownRate;
					return true;
				}
				break;
			}
			case 14:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c != 'L')
					{
						if (c == 'S')
						{
							if (key == "StopInputDelay")
							{
								value = this.StopInputDelay;
								return true;
							}
						}
					}
					else if (key == "LastValidInput")
					{
						value = this.LastValidInput;
						return true;
					}
				}
				else if (key == "ArmLengthSpeed")
				{
					value = this.ArmLengthSpeed;
					return true;
				}
				break;
			}
			case 15:
			{
				char c = key[0];
				if (c != 'E')
				{
					if (c != 'F')
					{
						if (c == 'S')
						{
							if (key == "StartInputDelay")
							{
								value = this.StartInputDelay;
								return true;
							}
						}
					}
					else if (key == "FadeOutDuration")
					{
						value = this.FadeOutDuration;
						return true;
					}
				}
				else if (key == "ElapseTimeScale")
				{
					value = this.ElapseTimeScale;
					return true;
				}
				break;
			}
			case 16:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c != 'F')
					{
						if (c == 'R')
						{
							if (key == "ReferToMoveSpeed")
							{
								value = this.ReferToMoveSpeed;
								return true;
							}
						}
					}
					else if (key == "FadeInCenterTime")
					{
						value = this.FadeInCenterTime;
						return true;
					}
				}
				else if (key == "DefaultArmLength")
				{
					value = this.DefaultArmLength;
					return true;
				}
				break;
			}
			case 17:
			{
				char c = key[12];
				if (c != 'P')
				{
					if (c == 'S')
					{
						if (key == "ReachThePeakSpeed")
						{
							value = this.ReachThePeakSpeed;
							return true;
						}
					}
				}
				else if (key == "ReachThePeakPitch")
				{
					value = this.ReachThePeakPitch;
					return true;
				}
				break;
			}
			case 18:
				if (key == "DefaultInterpSpeed")
				{
					value = this.DefaultInterpSpeed;
					return true;
				}
				break;
			case 19:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c != 'L')
					{
						if (c == 'N')
						{
							if (key == "NextChangeInputTime")
							{
								value = this.NextChangeInputTime;
								return true;
							}
						}
					}
					else if (key == "LargeAngleTurnDelay")
					{
						value = this.LargeAngleTurnDelay;
						return true;
					}
				}
				else if (key == "AdditionalArmLength")
				{
					value = this.AdditionalArmLength;
					return true;
				}
				break;
			}
			case 21:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c == 'C')
					{
						if (key == "CenterStateBlendInExp")
						{
							value = this.CenterStateBlendInExp;
							return true;
						}
					}
				}
				else if (key == "ActorForwardInGravity")
				{
					value = this.ActorForwardInGravity;
					return true;
				}
				break;
			}
			case 22:
				if (key == "MoveDirectionInGravity")
				{
					value = this.MoveDirectionInGravity;
					return true;
				}
				break;
			case 23:
				if (key == "LargeAngleTurnThreshold")
				{
					value = this.LargeAngleTurnThreshold;
					return true;
				}
				break;
			case 28:
				if (key == "ApplicableAngleWithCharacter")
				{
					value = this.ApplicableAngleWithCharacter;
					return true;
				}
				break;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x0600544B RID: 21579 RVA: 0x000CAAE0 File Offset: 0x000C8CE0
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
			{
				char c = key[0];
				if (c != 'I')
				{
					if (c == 'P')
					{
						if (key == "PrepTime")
						{
							float num2;
							if (value is double)
							{
								double num = (double)value;
								num2 = (float)num;
							}
							else if (value is float)
							{
								float num3 = (float)value;
								num2 = num3;
							}
							else if (value is int)
							{
								int num4 = (int)value;
								num2 = (float)num4;
							}
							else if (value is long)
							{
								long num5 = (long)value;
								num2 = (float)num5;
							}
							else
							{
								num2 = (float)value;
							}
							this.PrepTime = num2;
							return;
						}
					}
				}
				else if (key == "IsMoving")
				{
					this.IsMoving = (bool)value;
					return;
				}
				break;
			}
			case 11:
				if (key == "PitchUpRate")
				{
					float num2;
					if (value is double)
					{
						double num6 = (double)value;
						num2 = (float)num6;
					}
					else if (value is float)
					{
						float num7 = (float)value;
						num2 = num7;
					}
					else if (value is int)
					{
						int num8 = (int)value;
						num2 = (float)num8;
					}
					else if (value is long)
					{
						long num9 = (long)value;
						num2 = (float)num9;
					}
					else
					{
						num2 = (float)value;
					}
					this.PitchUpRate = num2;
					return;
				}
				break;
			case 12:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c == 'N')
					{
						if (key == "NextStopTime")
						{
							float num2;
							if (value is double)
							{
								double num10 = (double)value;
								num2 = (float)num10;
							}
							else if (value is float)
							{
								float num11 = (float)value;
								num2 = num11;
							}
							else if (value is int)
							{
								int num12 = (int)value;
								num2 = (float)num12;
							}
							else if (value is long)
							{
								long num13 = (long)value;
								num2 = (float)num13;
							}
							else
							{
								num2 = (float)value;
							}
							this.NextStopTime = num2;
							return;
						}
					}
				}
				else if (key == "DesiredAngle")
				{
					float num2;
					if (value is double)
					{
						double num14 = (double)value;
						num2 = (float)num14;
					}
					else if (value is float)
					{
						float num15 = (float)value;
						num2 = num15;
					}
					else if (value is int)
					{
						int num16 = (int)value;
						num2 = (float)num16;
					}
					else if (value is long)
					{
						long num17 = (long)value;
						num2 = (float)num17;
					}
					else
					{
						num2 = (float)value;
					}
					this.DesiredAngle = num2;
					return;
				}
				break;
			}
			case 13:
			{
				char c = key[0];
				if (c != 'M')
				{
					if (c == 'P')
					{
						if (key == "PitchDownRate")
						{
							float num2;
							if (value is double)
							{
								double num18 = (double)value;
								num2 = (float)num18;
							}
							else if (value is float)
							{
								float num19 = (float)value;
								num2 = num19;
							}
							else if (value is int)
							{
								int num20 = (int)value;
								num2 = (float)num20;
							}
							else if (value is long)
							{
								long num21 = (long)value;
								num2 = (float)num21;
							}
							else
							{
								num2 = (float)value;
							}
							this.PitchDownRate = num2;
							return;
						}
					}
				}
				else if (key == "MoveDelayTime")
				{
					float num2;
					if (value is double)
					{
						double num22 = (double)value;
						num2 = (float)num22;
					}
					else if (value is float)
					{
						float num23 = (float)value;
						num2 = num23;
					}
					else if (value is int)
					{
						int num24 = (int)value;
						num2 = (float)num24;
					}
					else if (value is long)
					{
						long num25 = (long)value;
						num2 = (float)num25;
					}
					else
					{
						num2 = (float)value;
					}
					this.MoveDelayTime = num2;
					return;
				}
				break;
			}
			case 14:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c == 'S')
					{
						if (key == "StopInputDelay")
						{
							float num2;
							if (value is double)
							{
								double num26 = (double)value;
								num2 = (float)num26;
							}
							else if (value is float)
							{
								float num27 = (float)value;
								num2 = num27;
							}
							else if (value is int)
							{
								int num28 = (int)value;
								num2 = (float)num28;
							}
							else if (value is long)
							{
								long num29 = (long)value;
								num2 = (float)num29;
							}
							else
							{
								num2 = (float)value;
							}
							this.StopInputDelay = num2;
							return;
						}
					}
				}
				else if (key == "ArmLengthSpeed")
				{
					float num2;
					if (value is double)
					{
						double num30 = (double)value;
						num2 = (float)num30;
					}
					else if (value is float)
					{
						float num31 = (float)value;
						num2 = num31;
					}
					else if (value is int)
					{
						int num32 = (int)value;
						num2 = (float)num32;
					}
					else if (value is long)
					{
						long num33 = (long)value;
						num2 = (float)num33;
					}
					else
					{
						num2 = (float)value;
					}
					this.ArmLengthSpeed = num2;
					return;
				}
				break;
			}
			case 15:
			{
				char c = key[0];
				if (c != 'E')
				{
					if (c != 'F')
					{
						if (c == 'S')
						{
							if (key == "StartInputDelay")
							{
								float num2;
								if (value is double)
								{
									double num34 = (double)value;
									num2 = (float)num34;
								}
								else if (value is float)
								{
									float num35 = (float)value;
									num2 = num35;
								}
								else if (value is int)
								{
									int num36 = (int)value;
									num2 = (float)num36;
								}
								else if (value is long)
								{
									long num37 = (long)value;
									num2 = (float)num37;
								}
								else
								{
									num2 = (float)value;
								}
								this.StartInputDelay = num2;
								return;
							}
						}
					}
					else if (key == "FadeOutDuration")
					{
						float num2;
						if (value is double)
						{
							double num38 = (double)value;
							num2 = (float)num38;
						}
						else if (value is float)
						{
							float num39 = (float)value;
							num2 = num39;
						}
						else if (value is int)
						{
							int num40 = (int)value;
							num2 = (float)num40;
						}
						else if (value is long)
						{
							long num41 = (long)value;
							num2 = (float)num41;
						}
						else
						{
							num2 = (float)value;
						}
						this.FadeOutDuration = num2;
						return;
					}
				}
				else if (key == "ElapseTimeScale")
				{
					float num2;
					if (value is double)
					{
						double num42 = (double)value;
						num2 = (float)num42;
					}
					else if (value is float)
					{
						float num43 = (float)value;
						num2 = num43;
					}
					else if (value is int)
					{
						int num44 = (int)value;
						num2 = (float)num44;
					}
					else if (value is long)
					{
						long num45 = (long)value;
						num2 = (float)num45;
					}
					else
					{
						num2 = (float)value;
					}
					this.ElapseTimeScale = num2;
					return;
				}
				break;
			}
			case 16:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c != 'F')
					{
						if (c == 'R')
						{
							if (key == "ReferToMoveSpeed")
							{
								float num2;
								if (value is double)
								{
									double num46 = (double)value;
									num2 = (float)num46;
								}
								else if (value is float)
								{
									float num47 = (float)value;
									num2 = num47;
								}
								else if (value is int)
								{
									int num48 = (int)value;
									num2 = (float)num48;
								}
								else if (value is long)
								{
									long num49 = (long)value;
									num2 = (float)num49;
								}
								else
								{
									num2 = (float)value;
								}
								this.ReferToMoveSpeed = num2;
								return;
							}
						}
					}
					else if (key == "FadeInCenterTime")
					{
						float num2;
						if (value is double)
						{
							double num50 = (double)value;
							num2 = (float)num50;
						}
						else if (value is float)
						{
							float num51 = (float)value;
							num2 = num51;
						}
						else if (value is int)
						{
							int num52 = (int)value;
							num2 = (float)num52;
						}
						else if (value is long)
						{
							long num53 = (long)value;
							num2 = (float)num53;
						}
						else
						{
							num2 = (float)value;
						}
						this.FadeInCenterTime = num2;
						return;
					}
				}
				else if (key == "DefaultArmLength")
				{
					float num2;
					if (value is double)
					{
						double num54 = (double)value;
						num2 = (float)num54;
					}
					else if (value is float)
					{
						float num55 = (float)value;
						num2 = num55;
					}
					else if (value is int)
					{
						int num56 = (int)value;
						num2 = (float)num56;
					}
					else if (value is long)
					{
						long num57 = (long)value;
						num2 = (float)num57;
					}
					else
					{
						num2 = (float)value;
					}
					this.DefaultArmLength = num2;
					return;
				}
				break;
			}
			case 17:
			{
				char c = key[12];
				if (c != 'P')
				{
					if (c == 'S')
					{
						if (key == "ReachThePeakSpeed")
						{
							float num2;
							if (value is double)
							{
								double num58 = (double)value;
								num2 = (float)num58;
							}
							else if (value is float)
							{
								float num59 = (float)value;
								num2 = num59;
							}
							else if (value is int)
							{
								int num60 = (int)value;
								num2 = (float)num60;
							}
							else if (value is long)
							{
								long num61 = (long)value;
								num2 = (float)num61;
							}
							else
							{
								num2 = (float)value;
							}
							this.ReachThePeakSpeed = num2;
							return;
						}
					}
				}
				else if (key == "ReachThePeakPitch")
				{
					float num2;
					if (value is double)
					{
						double num62 = (double)value;
						num2 = (float)num62;
					}
					else if (value is float)
					{
						float num63 = (float)value;
						num2 = num63;
					}
					else if (value is int)
					{
						int num64 = (int)value;
						num2 = (float)num64;
					}
					else if (value is long)
					{
						long num65 = (long)value;
						num2 = (float)num65;
					}
					else
					{
						num2 = (float)value;
					}
					this.ReachThePeakPitch = num2;
					return;
				}
				break;
			}
			case 18:
				if (key == "DefaultInterpSpeed")
				{
					float num2;
					if (value is double)
					{
						double num66 = (double)value;
						num2 = (float)num66;
					}
					else if (value is float)
					{
						float num67 = (float)value;
						num2 = num67;
					}
					else if (value is int)
					{
						int num68 = (int)value;
						num2 = (float)num68;
					}
					else if (value is long)
					{
						long num69 = (long)value;
						num2 = (float)num69;
					}
					else
					{
						num2 = (float)value;
					}
					this.DefaultInterpSpeed = num2;
					return;
				}
				break;
			case 19:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c != 'L')
					{
						if (c == 'N')
						{
							if (key == "NextChangeInputTime")
							{
								float num2;
								if (value is double)
								{
									double num70 = (double)value;
									num2 = (float)num70;
								}
								else if (value is float)
								{
									float num71 = (float)value;
									num2 = num71;
								}
								else if (value is int)
								{
									int num72 = (int)value;
									num2 = (float)num72;
								}
								else if (value is long)
								{
									long num73 = (long)value;
									num2 = (float)num73;
								}
								else
								{
									num2 = (float)value;
								}
								this.NextChangeInputTime = num2;
								return;
							}
						}
					}
					else if (key == "LargeAngleTurnDelay")
					{
						float num2;
						if (value is double)
						{
							double num74 = (double)value;
							num2 = (float)num74;
						}
						else if (value is float)
						{
							float num75 = (float)value;
							num2 = num75;
						}
						else if (value is int)
						{
							int num76 = (int)value;
							num2 = (float)num76;
						}
						else if (value is long)
						{
							long num77 = (long)value;
							num2 = (float)num77;
						}
						else
						{
							num2 = (float)value;
						}
						this.LargeAngleTurnDelay = num2;
						return;
					}
				}
				else if (key == "AdditionalArmLength")
				{
					float num2;
					if (value is double)
					{
						double num78 = (double)value;
						num2 = (float)num78;
					}
					else if (value is float)
					{
						float num79 = (float)value;
						num2 = num79;
					}
					else if (value is int)
					{
						int num80 = (int)value;
						num2 = (float)num80;
					}
					else if (value is long)
					{
						long num81 = (long)value;
						num2 = (float)num81;
					}
					else
					{
						num2 = (float)value;
					}
					this.AdditionalArmLength = num2;
					return;
				}
				break;
			}
			case 21:
				if (key == "CenterStateBlendInExp")
				{
					float num2;
					if (value is double)
					{
						double num82 = (double)value;
						num2 = (float)num82;
					}
					else if (value is float)
					{
						float num83 = (float)value;
						num2 = num83;
					}
					else if (value is int)
					{
						int num84 = (int)value;
						num2 = (float)num84;
					}
					else if (value is long)
					{
						long num85 = (long)value;
						num2 = (float)num85;
					}
					else
					{
						num2 = (float)value;
					}
					this.CenterStateBlendInExp = num2;
					return;
				}
				break;
			case 23:
				if (key == "LargeAngleTurnThreshold")
				{
					float num2;
					if (value is double)
					{
						double num86 = (double)value;
						num2 = (float)num86;
					}
					else if (value is float)
					{
						float num87 = (float)value;
						num2 = num87;
					}
					else if (value is int)
					{
						int num88 = (int)value;
						num2 = (float)num88;
					}
					else if (value is long)
					{
						long num89 = (long)value;
						num2 = (float)num89;
					}
					else
					{
						num2 = (float)value;
					}
					this.LargeAngleTurnThreshold = num2;
					return;
				}
				break;
			case 28:
				if (key == "ApplicableAngleWithCharacter")
				{
					float num2;
					if (value is double)
					{
						double num90 = (double)value;
						num2 = (float)num90;
					}
					else if (value is float)
					{
						float num91 = (float)value;
						num2 = num91;
					}
					else if (value is int)
					{
						int num92 = (int)value;
						num2 = (float)num92;
					}
					else if (value is long)
					{
						long num93 = (long)value;
						num2 = (float)num93;
					}
					else
					{
						num2 = (float)value;
					}
					this.ApplicableAngleWithCharacter = num2;
					return;
				}
				break;
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x0600544C RID: 21580 RVA: 0x000CB8E8 File Offset: 0x000C9AE8
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraClimbController.<MemberIter>d__54 <MemberIter>d__ = new CameraClimbController.<MemberIter>d__54(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x0400190D RID: 6413
	public const bool IsDebug = false;

	// Token: 0x0400190E RID: 6414
	public float FadeOutDuration;

	// Token: 0x0400190F RID: 6415
	public float PrepTime;

	// Token: 0x04001910 RID: 6416
	public float MoveDelayTime;

	// Token: 0x04001911 RID: 6417
	public float DefaultInterpSpeed;

	// Token: 0x04001912 RID: 6418
	public float ReferToMoveSpeed;

	// Token: 0x04001913 RID: 6419
	public float AdditionalArmLength;

	// Token: 0x04001914 RID: 6420
	public float FadeInCenterTime;

	// Token: 0x04001915 RID: 6421
	public float CenterStateBlendInExp;

	// Token: 0x04001916 RID: 6422
	public float DefaultArmLength;

	// Token: 0x04001917 RID: 6423
	public float ArmLengthSpeed;

	// Token: 0x04001918 RID: 6424
	public float DesiredAngle;

	// Token: 0x04001919 RID: 6425
	public float PitchUpRate;

	// Token: 0x0400191A RID: 6426
	public float PitchDownRate;

	// Token: 0x0400191B RID: 6427
	public float ApplicableAngleWithCharacter;

	// Token: 0x0400191C RID: 6428
	public float StopInputDelay;

	// Token: 0x0400191D RID: 6429
	public float ReachThePeakSpeed;

	// Token: 0x0400191E RID: 6430
	public float ReachThePeakPitch;

	// Token: 0x0400191F RID: 6431
	public float LargeAngleTurnThreshold;

	// Token: 0x04001920 RID: 6432
	public float LargeAngleTurnDelay;

	// Token: 0x04001921 RID: 6433
	public float StartInputDelay;

	// Token: 0x04001922 RID: 6434
	public float ElapseTimeScale = 1f;

	// Token: 0x04001923 RID: 6435
	public bool IsMoving;

	// Token: 0x04001924 RID: 6436
	private readonly Vector LastValidInput = Vector.Create();

	// Token: 0x04001925 RID: 6437
	private float NextChangeInputTime;

	// Token: 0x04001926 RID: 6438
	private float NextStopTime;

	// Token: 0x04001927 RID: 6439
	public readonly Vector MoveDirection = Vector.Create();

	// Token: 0x04001928 RID: 6440
	private readonly StateMachine<CameraClimbController, CameraClimbController.ECameraState> StateMachine;

	// Token: 0x04001929 RID: 6441
	private readonly Vector ActorForwardInGravity = Vector.Create();

	// Token: 0x0400192A RID: 6442
	private readonly Vector MoveDirectionInGravity = Vector.Create();

	// Token: 0x0400192B RID: 6443
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400192C RID: 6444
	private readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400192D RID: 6445
	private readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x0200726B RID: 29291
	[NullableContext(0)]
	public enum ECameraState
	{
		// Token: 0x04027B41 RID: 162625
		Default,
		// Token: 0x04027B42 RID: 162626
		Center,
		// Token: 0x04027B43 RID: 162627
		Ready,
		// Token: 0x04027B44 RID: 162628
		Adjust,
		// Token: 0x04027B45 RID: 162629
		FadeOut,
		// Token: 0x04027B46 RID: 162630
		ReachThePeak
	}

	// Token: 0x0200726C RID: 29292
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DefaultState : StateBase<CameraClimbController, CameraClimbController.ECameraState>
	{
		// Token: 0x0604687D RID: 288893 RVA: 0x012B06FF File Offset: 0x012AE8FF
		public DefaultState(CameraClimbController owner, CameraClimbController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraClimbController, CameraClimbController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0604687E RID: 288894 RVA: 0x012B070A File Offset: 0x012AE90A
		protected override void OnEnter(CameraClimbController.ECameraState? stat)
		{
			this.ElapseTime = 0f;
		}

		// Token: 0x0604687F RID: 288895 RVA: 0x012B0717 File Offset: 0x012AE917
		protected override void OnUpdate(float delta)
		{
			this.ElapseTime += delta * this.Owner.ElapseTimeScale;
			if (this.ElapseTime > this.Owner.PrepTime)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Ready);
			}
		}

		// Token: 0x04027B47 RID: 162631
		private float ElapseTime;
	}

	// Token: 0x0200726D RID: 29293
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CenterState : StateBase<CameraClimbController, CameraClimbController.ECameraState>
	{
		// Token: 0x06046880 RID: 288896 RVA: 0x012B0753 File Offset: 0x012AE953
		public CenterState(CameraClimbController owner, CameraClimbController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraClimbController, CameraClimbController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06046881 RID: 288897 RVA: 0x012B077F File Offset: 0x012AE97F
		public override bool CanReEnter()
		{
			return true;
		}

		// Token: 0x06046882 RID: 288898 RVA: 0x012B0784 File Offset: 0x012AE984
		protected override void OnReEnter()
		{
			this.OnEnter(null);
		}

		// Token: 0x06046883 RID: 288899 RVA: 0x012B07A0 File Offset: 0x012AE9A0
		protected override void OnEnter(CameraClimbController.ECameraState? state)
		{
			if (this.Owner.Camera.IsInNormalGravityMode())
			{
				this.StartRotator.DeepCopy(this.Owner.Camera.CurrentCamera.ArmRotation);
				this.DesiredRotator.DeepCopy(this.Owner.Camera.PlayerRotator);
			}
			else
			{
				CameraUtility.GetRotatorInGravity(this.Owner.Camera.CurrentCamera.ArmRotation, this.StartRotator);
				this.DesiredRotator.DeepCopy(this.Owner.Camera.PlayerRotatorInGravity);
			}
			this.ElapseTime = 0f;
		}

		// Token: 0x06046884 RID: 288900 RVA: 0x012B0844 File Offset: 0x012AEA44
		protected override void OnUpdate(float delta)
		{
			if (this.Owner.Camera.IsModifiedArmRotationPitch || this.Owner.Camera.IsModifiedArmRotationYaw)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Default);
				return;
			}
			float num = delta / this.Owner.FadeInCenterTime * this.Owner.AdditionalArmLength * this.Owner.ElapseTimeScale;
			this.Owner.Camera.DesiredCamera.ArmLength = this.Owner.Camera.CurrentCamera.ArmLength + num;
			this.Owner.Camera.IsModifiedArmLength = true;
			this.ElapseTime += delta;
			float alpha = this.ElapseTime / this.Owner.FadeInCenterTime;
			alpha = (float)Singleton<MathUtils>.Instance.BlendEaseIn(0.0, 1.0, alpha, (double)this.Owner.CenterStateBlendInExp);
			Rotator.Lerp(this.StartRotator, this.DesiredRotator, alpha, this.TmpRotator);
			if (this.Owner.Camera.IsInNormalGravityMode())
			{
				this.Owner.Camera.DesiredCamera.ArmRotation.DeepCopy(this.TmpRotator);
			}
			else
			{
				CameraUtility.SetRotatorInGravity(this.Owner.Camera.DesiredCamera.ArmRotation, this.TmpRotator);
			}
			this.Owner.Camera.IsModifiedArmRotationPitch = true;
			this.Owner.Camera.IsModifiedArmRotationYaw = true;
			if (this.ElapseTime > this.Owner.FadeInCenterTime)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Ready);
			}
		}

		// Token: 0x04027B48 RID: 162632
		private readonly Rotator StartRotator = Rotator.Create();

		// Token: 0x04027B49 RID: 162633
		private readonly Rotator DesiredRotator = Rotator.Create();

		// Token: 0x04027B4A RID: 162634
		private float ElapseTime;

		// Token: 0x04027B4B RID: 162635
		private readonly Rotator TmpRotator = Rotator.Create();
	}

	// Token: 0x0200726E RID: 29294
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ReadyState : StateBase<CameraClimbController, CameraClimbController.ECameraState>
	{
		// Token: 0x06046885 RID: 288901 RVA: 0x012B09E1 File Offset: 0x012AEBE1
		public ReadyState(CameraClimbController owner, CameraClimbController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraClimbController, CameraClimbController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06046886 RID: 288902 RVA: 0x012B09EC File Offset: 0x012AEBEC
		protected override void OnEnter(CameraClimbController.ECameraState? lastState)
		{
			this.ElapseTime = 0f;
		}

		// Token: 0x06046887 RID: 288903 RVA: 0x012B09FC File Offset: 0x012AEBFC
		protected override void OnUpdate(float delta)
		{
			if (this.Owner.Camera.IsModifiedArmRotationPitch || this.Owner.Camera.IsModifiedArmRotationYaw)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Default);
				return;
			}
			if (!this.Owner.IsMoving)
			{
				this.ElapseTime = 0f;
				return;
			}
			this.ElapseTime += delta * this.Owner.ElapseTimeScale;
			if (this.ElapseTime > this.Owner.MoveDelayTime)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Adjust);
			}
		}

		// Token: 0x04027B4C RID: 162636
		private float ElapseTime;
	}

	// Token: 0x0200726F RID: 29295
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AdjustState : StateBase<CameraClimbController, CameraClimbController.ECameraState>
	{
		// Token: 0x06046888 RID: 288904 RVA: 0x012B0A8E File Offset: 0x012AEC8E
		public AdjustState(CameraClimbController owner, CameraClimbController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraClimbController, CameraClimbController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06046889 RID: 288905 RVA: 0x012B0AAF File Offset: 0x012AECAF
		protected override void OnEnter(CameraClimbController.ECameraState? lastState)
		{
			this.Applicable = false;
		}

		// Token: 0x0604688A RID: 288906 RVA: 0x012B0AB8 File Offset: 0x012AECB8
		protected override void OnUpdate(float delta)
		{
			if (this.Owner.Camera.IsModifiedArmRotationPitch || this.Owner.Camera.IsModifiedArmRotationYaw)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Default);
				return;
			}
			if (!this.Owner.IsMoving)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.FadeOut);
				return;
			}
			this.Owner.Camera.PlayerRotator.Vector(this.PlayerFacing);
			this.Owner.UpdateInterp(delta, this.Owner.DefaultInterpSpeed, this.Owner.MoveDirection);
			this.Owner.Camera.DesiredCamera.ArmRotation.Vector(this.CameraFacing);
			if (!this.Owner.Camera.IsInNormalGravityMode())
			{
				CameraUtility.GetVectorInGravity(this.PlayerFacing, this.PlayerFacing);
				CameraUtility.GetVectorInGravity(this.CameraFacing, this.CameraFacing);
			}
			bool flag = Math.Abs(Math.Acos(Vector.DotProduct(this.PlayerFacing, this.CameraFacing)) * 57.295780181884766) <= (double)this.Owner.ApplicableAngleWithCharacter;
			if (!flag && this.Applicable)
			{
				Vector vector = Vector.Create();
				this.PlayerFacing.CrossProduct(this.CameraFacing, vector);
				Vector vector2 = Vector.Create();
				if (vector.Normalize(9.99999993922529E-09))
				{
					this.PlayerFacing.RotateAngleAxis((double)this.Owner.ApplicableAngleWithCharacter, vector, vector2);
				}
				else
				{
					vector2.DeepCopy(this.PlayerFacing);
				}
				vector2.Rotation(this.Owner.Camera.DesiredCamera.ArmRotation);
				this.Owner.Camera.IsModifiedArmRotationPitch = true;
				this.Owner.Camera.IsModifiedArmRotationYaw = true;
				this.Applicable = true;
			}
			else
			{
				this.Applicable = flag;
			}
			if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.Owner.Camera.CurrentCamera.ArmLength, (double)this.Owner.DefaultArmLength, null))
			{
				float num = this.Owner.DefaultArmLength - this.Owner.Camera.CurrentCamera.ArmLength;
				float num2 = this.Owner.ArmLengthSpeed * delta;
				if (Math.Abs(num2) > Math.Abs(num))
				{
					this.Owner.Camera.DesiredCamera.ArmLength = this.Owner.DefaultArmLength;
				}
				else
				{
					num2 = ((num > 0f) ? num2 : (-num2));
					this.Owner.Camera.DesiredCamera.ArmLength = this.Owner.Camera.CurrentCamera.ArmLength + num2;
				}
				this.Owner.Camera.IsModifiedArmLength = true;
			}
		}

		// Token: 0x04027B4D RID: 162637
		private bool Applicable;

		// Token: 0x04027B4E RID: 162638
		private readonly Vector PlayerFacing = Vector.Create();

		// Token: 0x04027B4F RID: 162639
		private readonly Vector CameraFacing = Vector.Create();
	}

	// Token: 0x02007270 RID: 29296
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FadeOutState : StateBase<CameraClimbController, CameraClimbController.ECameraState>
	{
		// Token: 0x0604688B RID: 288907 RVA: 0x012B0D7E File Offset: 0x012AEF7E
		public FadeOutState(CameraClimbController owner, CameraClimbController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraClimbController, CameraClimbController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0604688C RID: 288908 RVA: 0x012B0D89 File Offset: 0x012AEF89
		protected override void OnEnter(CameraClimbController.ECameraState? state)
		{
			this.ElapseTime = 0f;
		}

		// Token: 0x0604688D RID: 288909 RVA: 0x012B0D98 File Offset: 0x012AEF98
		protected override void OnUpdate(float delta)
		{
			if (this.Owner.Camera.IsModifiedArmRotationPitch || this.Owner.Camera.IsModifiedArmRotationYaw)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Default);
				return;
			}
			if (this.Owner.IsMoving)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Adjust);
				return;
			}
			if (this.ElapseTime >= this.Owner.FadeOutDuration)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Ready);
				return;
			}
			this.ElapseTime += delta;
			float interpSpeed = Singleton<MathUtils>.Instance.RangeClamp(this.ElapseTime, 0f, this.Owner.FadeOutDuration, this.Owner.DefaultInterpSpeed, 0f);
			this.Owner.UpdateInterp(delta, interpSpeed, this.Owner.MoveDirection);
		}

		// Token: 0x04027B50 RID: 162640
		private float ElapseTime;
	}

	// Token: 0x02007271 RID: 29297
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ReachThePeakState : StateBase<CameraClimbController, CameraClimbController.ECameraState>
	{
		// Token: 0x0604688E RID: 288910 RVA: 0x012B0E6A File Offset: 0x012AF06A
		public ReachThePeakState(CameraClimbController owner, CameraClimbController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraClimbController, CameraClimbController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0604688F RID: 288911 RVA: 0x012B0E8C File Offset: 0x012AF08C
		protected override void OnEnter(CameraClimbController.ECameraState? state)
		{
			this.TargetRotator.DeepCopy(this.Owner.Camera.PlayerRotator);
			this.TargetRotator.Pitch = this.Owner.ReachThePeakPitch;
			this.TargetRotator.Vector(this.TargetLookAt);
		}

		// Token: 0x06046890 RID: 288912 RVA: 0x012B0EDC File Offset: 0x012AF0DC
		protected override void OnUpdate(float delta)
		{
			if (this.Owner.Camera.IsModifiedArmRotationPitch || this.Owner.Camera.IsModifiedArmRotationYaw)
			{
				this.StateMachine.Switch(CameraClimbController.ECameraState.Default);
				return;
			}
			this.Owner.UpdateInterp(delta, this.Owner.ReachThePeakSpeed, this.TargetLookAt);
		}

		// Token: 0x04027B51 RID: 162641
		private readonly Vector TargetLookAt = Vector.Create();

		// Token: 0x04027B52 RID: 162642
		private readonly Rotator TargetRotator = Rotator.Create();
	}
}
