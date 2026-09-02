using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using UnrealEngine;

// Token: 0x02000E1F RID: 3615
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraHookController : CameraControllerBase<EFightCameraHook>, ICanGetConfigMapValue
{
	// Token: 0x0600556A RID: 21866 RVA: 0x000DC6F3 File Offset: 0x000DA8F3
	public CameraHookController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x0600556B RID: 21867 RVA: 0x000DC71D File Offset: 0x000DA91D
	public override string Name()
	{
		return "HookController";
	}

	// Token: 0x0600556C RID: 21868 RVA: 0x000DC724 File Offset: 0x000DA924
	public void ApplyCameraHook(GrapplingHookPointComponent point, [Nullable(2)] GrapplingHookPointComponent currentTarget = null)
	{
		this.LookAtPoint = point;
		this.GazeParams = ((currentTarget != null) ? new GazeParams(currentTarget, true) : new GazeParams(point, false));
		this.Enable = true;
		this.OnEnter();
	}

	// Token: 0x0600556D RID: 21869 RVA: 0x000DC753 File Offset: 0x000DA953
	public void ExitCameraHook(bool fadeOut = true)
	{
		this.Enable = false;
		if (this.BlendState != CameraHookController.EBlendState.Default)
		{
			this.OnExit(fadeOut);
		}
	}

	// Token: 0x0600556E RID: 21870 RVA: 0x000DC76C File Offset: 0x000DA96C
	private void OnEnter()
	{
		this.BlendState = CameraHookController.EBlendState.BlendIn;
		this.ElapsedTime = 0f;
		this.FadeOutElapsedTime = 0f;
		this.StartFadeInCameraLookAt.DeepCopy(this.Camera.CameraForward);
		if (this.GazeParams.LockCamera)
		{
			base.CameraModel.FightCamera.LogicComponent.CameraInputController.Lock(this);
			base.CameraModel.FightCamera.LogicComponent.CameraFocusController.Lock(this);
		}
	}

	// Token: 0x0600556F RID: 21871 RVA: 0x000DC7EF File Offset: 0x000DA9EF
	protected override bool UpdateCustomEnableCondition()
	{
		return this.Enable;
	}

	// Token: 0x06005570 RID: 21872 RVA: 0x000DC7F8 File Offset: 0x000DA9F8
	protected override void UpdateInternal(float delta)
	{
		if (!this.LookAtPoint.Valid)
		{
			this.ExitCameraHook(true);
			return;
		}
		this.ElapsedTime += delta;
		if (this.Camera.IsModifiedArmRotationPitch || this.Camera.IsModifiedArmRotationYaw || this.Camera.IsModifiedArmLength)
		{
			this.OnExit(true);
		}
		this.CalcLookAt();
		switch (this.BlendState)
		{
		case CameraHookController.EBlendState.BlendIn:
		{
			float num = (this.GazeParams.FadeInTime > 0f) ? (this.ElapsedTime / this.GazeParams.FadeInTime) : 1f;
			num = Singleton<MathUtils>.Instance.Clamp(num, 0f, 1f);
			this.UpdateFadeIn(num);
			if (this.ElapsedTime > this.GazeParams.FadeInTime)
			{
				this.BlendState = CameraHookController.EBlendState.Staying;
				return;
			}
			break;
		}
		case CameraHookController.EBlendState.Staying:
			this.UpdateStaying();
			if (this.GazeParams.StayTime >= 0f && this.ElapsedTime > this.GazeParams.FadeInTime + this.GazeParams.StayTime)
			{
				if (this.GazeParams.FadeOutTime == null)
				{
					this.BlendState = CameraHookController.EBlendState.Default;
					this.OnExit(true);
					return;
				}
				this.BlendState = CameraHookController.EBlendState.BlendOut;
				this.StartFadeOutCameraLookAt.DeepCopy(this.Camera.CameraForward);
				return;
			}
			break;
		case CameraHookController.EBlendState.BlendOut:
		{
			this.FadeOutElapsedTime += delta;
			float num2 = (this.GazeParams.FadeOutTime.Value > 0f) ? (this.FadeOutElapsedTime / this.GazeParams.FadeOutTime.Value) : 1f;
			num2 = Singleton<MathUtils>.Instance.Clamp(num2, 0f, 1f);
			this.UpdateFadeOut(num2);
			float fadeOutElapsedTime = this.FadeOutElapsedTime;
			float? fadeOutTime = this.GazeParams.FadeOutTime;
			if (fadeOutElapsedTime > fadeOutTime.GetValueOrDefault() & fadeOutTime != null)
			{
				this.BlendState = CameraHookController.EBlendState.Default;
				this.OnExit(true);
			}
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x06005571 RID: 21873 RVA: 0x000DC9F0 File Offset: 0x000DABF0
	protected override void UpdateDeactivateInternal(float delta)
	{
		if (this.BlendState == CameraHookController.EBlendState.BlendOut)
		{
			this.FadeOutElapsedTime += delta;
			float num = (this.GazeParams.FadeOutTime.Value > 0f) ? (this.FadeOutElapsedTime / this.GazeParams.FadeOutTime.Value) : 1f;
			num = Singleton<MathUtils>.Instance.Clamp(num, 0f, 1f);
			this.UpdateFadeOut(num);
			float fadeOutElapsedTime = this.FadeOutElapsedTime;
			float? fadeOutTime = this.GazeParams.FadeOutTime;
			if (fadeOutElapsedTime > fadeOutTime.GetValueOrDefault() & fadeOutTime != null)
			{
				this.BlendState = CameraHookController.EBlendState.Default;
				this.OnExit(true);
			}
		}
	}

	// Token: 0x06005572 RID: 21874 RVA: 0x000DCAA0 File Offset: 0x000DACA0
	private void UpdateFadeIn(float alpha)
	{
		Vector vector = Vector.Create();
		Vector.LerpSin(this.StartFadeInCameraLookAt, this.LookAt, alpha, vector);
		FRotator frotator = vector.ToUeVector(false).Rotation();
		this.Camera.DesiredCamera.ArmRotation.DeepCopy(frotator);
		this.Camera.IsModifiedArmRotationPitch = true;
		this.Camera.IsModifiedArmRotationYaw = true;
	}

	// Token: 0x06005573 RID: 21875 RVA: 0x000DCB08 File Offset: 0x000DAD08
	private void UpdateStaying()
	{
		FRotator frotator = this.LookAt.ToUeVector(false).Rotation();
		this.Camera.DesiredCamera.ArmRotation.DeepCopy(frotator);
		this.Camera.IsModifiedArmRotationPitch = true;
		this.Camera.IsModifiedArmRotationYaw = true;
	}

	// Token: 0x06005574 RID: 21876 RVA: 0x000DCB5C File Offset: 0x000DAD5C
	private void UpdateFadeOut(float alpha)
	{
		Vector vector = Vector.Create();
		Vector.LerpSin(this.StartFadeOutCameraLookAt, this.StartFadeInCameraLookAt, alpha, vector);
		FRotator frotator = vector.ToUeVector(false).Rotation();
		this.Camera.DesiredCamera.ArmRotation.DeepCopy(frotator);
		this.Camera.IsModifiedArmRotationPitch = true;
		this.Camera.IsModifiedArmRotationYaw = true;
	}

	// Token: 0x06005575 RID: 21877 RVA: 0x000DCBC4 File Offset: 0x000DADC4
	private void CalcLookAt()
	{
		Vector hookLocation = this.LookAtPoint.HookLocation;
		Vector playerLocation = this.Camera.PlayerLocation;
		hookLocation.Subtraction(playerLocation, this.LookAt);
		this.LookAt.Normalize(9.99999993922529E-09);
		if (Math.Abs(this.LookAt.X) < 1E-08 && Math.Abs(this.LookAt.Y) < 1E-08)
		{
			this.LookAt = Vector.ZeroVectorProxy;
		}
	}

	// Token: 0x06005576 RID: 21878 RVA: 0x000DCC4C File Offset: 0x000DAE4C
	private void OnExit(bool fadeOut = true)
	{
		this.Enable = false;
		CameraHookController.EBlendState blendState = this.BlendState;
		bool flag = blendState - CameraHookController.EBlendState.BlendIn <= 1;
		if (flag)
		{
			GrapplingHookPointComponent lookAtPoint = this.LookAtPoint;
			if (lookAtPoint != null && lookAtPoint.Valid)
			{
				GazeParams gazeParams = this.GazeParams;
				if (gazeParams != null && gazeParams.FadeOutTime != null)
				{
					this.BlendState = CameraHookController.EBlendState.BlendOut;
					this.FadeOutElapsedTime = (fadeOut ? 0f : this.GazeParams.FadeOutTime.Value);
					this.StartFadeOutCameraLookAt.DeepCopy(this.Camera.CameraForward);
					return;
				}
			}
		}
		base.CameraModel.FightCamera.LogicComponent.CameraInputController.Unlock(this);
		base.CameraModel.FightCamera.LogicComponent.CameraFocusController.Unlock(this);
	}

	// Token: 0x06005577 RID: 21879 RVA: 0x000DCD17 File Offset: 0x000DAF17
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraHook)key);
	}

	// Token: 0x06005578 RID: 21880 RVA: 0x000DCD24 File Offset: 0x000DAF24
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			int length = key.Length;
			if (length <= 11)
			{
				if (length != 6)
				{
					if (length != 10)
					{
						if (length == 11)
						{
							char c = key[0];
							if (c != 'E')
							{
								if (c == 'L')
								{
									if (key == "LookAtPoint")
									{
										value = this.LookAtPoint;
										return true;
									}
								}
							}
							else if (key == "ElapsedTime")
							{
								value = this.ElapsedTime;
								return true;
							}
						}
					}
					else
					{
						char c = key[0];
						if (c != 'B')
						{
							if (c == 'G')
							{
								if (key == "GazeParams")
								{
									value = this.GazeParams;
									return true;
								}
							}
						}
						else if (key == "BlendState")
						{
							value = this.BlendState;
							return true;
						}
					}
				}
				else
				{
					char c = key[0];
					if (c != 'E')
					{
						if (c == 'L')
						{
							if (key == "LookAt")
							{
								value = this.LookAt;
								return true;
							}
						}
					}
					else if (key == "Enable")
					{
						value = this.Enable;
						return true;
					}
				}
			}
			else if (length != 18)
			{
				if (length != 23)
				{
					if (length == 24)
					{
						if (key == "StartFadeOutCameraLookAt")
						{
							value = this.StartFadeOutCameraLookAt;
							return true;
						}
					}
				}
				else if (key == "StartFadeInCameraLookAt")
				{
					value = this.StartFadeInCameraLookAt;
					return true;
				}
			}
			else if (key == "FadeOutElapsedTime")
			{
				value = this.FadeOutElapsedTime;
				return true;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x06005579 RID: 21881 RVA: 0x000DCED8 File Offset: 0x000DB0D8
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			int length = key.Length;
			if (length <= 10)
			{
				if (length != 6)
				{
					if (length == 10)
					{
						char c = key[0];
						if (c != 'B')
						{
							if (c == 'G')
							{
								if (key == "GazeParams")
								{
									this.GazeParams = (GazeParams)value;
									return;
								}
							}
						}
						else if (key == "BlendState")
						{
							this.BlendState = (CameraHookController.EBlendState)value;
							return;
						}
					}
				}
				else
				{
					char c = key[0];
					if (c != 'E')
					{
						if (c == 'L')
						{
							if (key == "LookAt")
							{
								this.LookAt = (Vector)value;
								return;
							}
						}
					}
					else if (key == "Enable")
					{
						this.Enable = (bool)value;
						return;
					}
				}
			}
			else if (length != 11)
			{
				if (length == 18)
				{
					if (key == "FadeOutElapsedTime")
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
						this.FadeOutElapsedTime = num2;
						return;
					}
				}
			}
			else
			{
				char c = key[0];
				if (c != 'E')
				{
					if (c == 'L')
					{
						if (key == "LookAtPoint")
						{
							this.LookAtPoint = (GrapplingHookPointComponent)value;
							return;
						}
					}
				}
				else if (key == "ElapsedTime")
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
					this.ElapsedTime = num2;
					return;
				}
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x0600557A RID: 21882 RVA: 0x000DD115 File Offset: 0x000DB315
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraHookController.<MemberIter>d__26 <MemberIter>d__ = new CameraHookController.<MemberIter>d__26(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001A8B RID: 6795
	[Nullable(2)]
	private GrapplingHookPointComponent LookAtPoint;

	// Token: 0x04001A8C RID: 6796
	[Nullable(2)]
	private GazeParams GazeParams;

	// Token: 0x04001A8D RID: 6797
	private CameraHookController.EBlendState BlendState;

	// Token: 0x04001A8E RID: 6798
	private float ElapsedTime;

	// Token: 0x04001A8F RID: 6799
	private float FadeOutElapsedTime;

	// Token: 0x04001A90 RID: 6800
	private readonly Vector StartFadeInCameraLookAt = Vector.Create();

	// Token: 0x04001A91 RID: 6801
	private readonly Vector StartFadeOutCameraLookAt = Vector.Create();

	// Token: 0x04001A92 RID: 6802
	private Vector LookAt = Vector.Create();

	// Token: 0x04001A93 RID: 6803
	private bool Enable;

	// Token: 0x02007284 RID: 29316
	[NullableContext(0)]
	internal enum EBlendState
	{
		// Token: 0x04027BA6 RID: 162726
		Default,
		// Token: 0x04027BA7 RID: 162727
		BlendIn,
		// Token: 0x04027BA8 RID: 162728
		Staying,
		// Token: 0x04027BA9 RID: 162729
		BlendOut
	}
}
