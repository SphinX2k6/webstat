using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02000E0E RID: 3598
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraFixedController : CameraControllerBase<EFightCameraDialogue>, ICanGetConfigMapValue
{
	// Token: 0x060054C9 RID: 21705 RVA: 0x000D2D98 File Offset: 0x000D0F98
	public CameraFixedController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x060054CA RID: 21706 RVA: 0x000D2DA1 File Offset: 0x000D0FA1
	public override string Name()
	{
		return "FixedController";
	}

	// Token: 0x060054CB RID: 21707 RVA: 0x000D2DA8 File Offset: 0x000D0FA8
	public void InitFixedCamera(Vector vectorLoc, Rotator vectorRot, float fov, float fadeInTime, float fadeOutTime)
	{
		if (this.NowInCamera == null || !this.CheckIfTheSameCamera(vectorLoc) || base.CameraModel.CurrentCameraActor != this.NowInCamera)
		{
			this.LastInCamera = this.NowInCamera;
			UObject world = GlobalData.World;
			TSubclassOf<AActor> actorClass = ACameraActor.StaticClass();
			FRotator frotator = vectorRot.ToUeRotator();
			FVectorDouble fvectorDouble = vectorLoc.ToUeVector(false);
			FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
			FVector fvector = fvectorDouble2;
			FTransformDouble ftransformDouble = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
			this.NowInCamera = (UKuroActorManager.D_SpawnActor(world, actorClass, ftransformDouble, ESpawnActorCollisionHandlingMethod.Undefined, null, null, false) as ACameraActor);
			if (this.NowInCamera != null)
			{
				this.FadeInTime = fadeInTime;
				this.FadeOutTime = fadeOutTime;
				this.NowInCamera.CameraComponent.FieldOfView = fov;
				this.NowInCamera.CameraComponent.bConstrainAspectRatio = false;
				this.AddEventSystem();
				this.FixedCameraSetViewTarget();
			}
		}
	}

	// Token: 0x060054CC RID: 21708 RVA: 0x000D2E98 File Offset: 0x000D1098
	private void AddFadeIn()
	{
		if (this.TickIdFadeIn != null && TimerSystem.Instance.Has(this.TickIdFadeIn))
		{
			TimerSystem.Instance.Remove(this.TickIdFadeIn);
			this.OnFadeIn(0f);
		}
		this.RemoveFadeOut();
		if ((double)this.FadeInTime > 0.2)
		{
			this.TickIdFadeIn = TimerSystem.Instance.Delay(new TTimerAction(this.OnFadeIn), this.FadeInTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
			return;
		}
		this.OnFadeIn(0f);
	}

	// Token: 0x060054CD RID: 21709 RVA: 0x000D2F35 File Offset: 0x000D1135
	private void RemoveFadeIn()
	{
		if (this.TickIdFadeIn != null && TimerSystem.Instance.Has(this.TickIdFadeIn))
		{
			TimerSystem.Instance.Remove(this.TickIdFadeIn);
			this.OnFadeIn(0f);
		}
	}

	// Token: 0x060054CE RID: 21710 RVA: 0x000D2F70 File Offset: 0x000D1170
	private void AddFadeOut()
	{
		if (this.TickIdFadeOut != null && TimerSystem.Instance.Has(this.TickIdFadeOut))
		{
			TimerSystem.Instance.Remove(this.TickIdFadeOut);
			this.OnFadeOut(0f);
		}
		this.RemoveFadeIn();
		if ((double)this.FadeOutTime > 0.2)
		{
			this.TickIdFadeOut = TimerSystem.Instance.Delay(new TTimerAction(this.OnFadeOut), this.FadeOutTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
			return;
		}
		this.OnFadeOut(0f);
	}

	// Token: 0x060054CF RID: 21711 RVA: 0x000D300D File Offset: 0x000D120D
	private void RemoveFadeOut()
	{
		if (this.TickIdFadeOut != null && TimerSystem.Instance.Has(this.TickIdFadeOut))
		{
			TimerSystem.Instance.Remove(this.TickIdFadeOut);
		}
	}

	// Token: 0x060054D0 RID: 21712 RVA: 0x000D303A File Offset: 0x000D123A
	private void OnFadeIn(float delta)
	{
		if (this.LastInCamera != this.NowInCamera)
		{
			ACameraActor lastInCamera = this.LastInCamera;
			if (lastInCamera != null)
			{
				lastInCamera.K2_DestroyActor();
			}
			this.LastInCamera = null;
		}
		this.IsChangingCamera = false;
	}

	// Token: 0x060054D1 RID: 21713 RVA: 0x000D306C File Offset: 0x000D126C
	private void OnFadeOut(float delta)
	{
		base.CameraModel.FightCamera.LogicComponent.CameraInputController.Unlock(this);
		ACameraActor nowInCamera = this.NowInCamera;
		if (nowInCamera != null)
		{
			nowInCamera.K2_DestroyActor();
		}
		this.NowInCamera = null;
		ACameraActor lastInCamera = this.LastInCamera;
		if (lastInCamera != null)
		{
			lastInCamera.K2_DestroyActor();
		}
		this.LastInCamera = null;
		this.RemoveEventSystem();
		this.RemoveFadeIn();
		this.RemoveFadeOut();
		this.IsChangingCamera = false;
	}

	// Token: 0x060054D2 RID: 21714 RVA: 0x000D30E0 File Offset: 0x000D12E0
	private void FixedCameraSetViewTarget()
	{
		ControllerBase<CameraController>.Instance.SetViewTarget(this.NowInCamera, "FixedCameraSetViewTarget", this.FadeInTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), base.CameraModel.CameraName, null, null);
		base.CameraModel.FightCamera.LogicComponent.CameraInputController.Lock(this);
		base.CameraModel.FightCamera.LogicComponent.SetIsDitherEffectEnable(false);
		this.IsLockedCamera = true;
		this.IsChangingCamera = true;
		this.AddFadeIn();
	}

	// Token: 0x060054D3 RID: 21715 RVA: 0x000D316C File Offset: 0x000D136C
	public bool FixedCameraResetViewTarget()
	{
		if (this.LastInCamera != this.NowInCamera)
		{
			VirtualCamera desiredCamera = base.CameraModel.FightCamera.LogicComponent.DesiredCamera;
			Rotator armRotation = desiredCamera.ArmRotation;
			ACameraActor nowInCamera = this.NowInCamera;
			FRotator? frotator = (nowInCamera != null) ? new FRotator?(nowInCamera.K2_GetActorRotation()) : null;
			desiredCamera.ArmRotation = new Rotator(frotator.Value.Pitch, frotator.Value.Yaw, armRotation.Roll);
			CameraController instance = ControllerBase<CameraController>.Instance;
			FightCameraDisplayComponent component = base.CameraModel.FightCamera.GetComponent<FightCameraDisplayComponent>();
			instance.SetViewTarget((component != null) ? component.CameraActor : null, "FixedCameraResetViewTarget", this.FadeOutTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), base.CameraModel.CameraName, null, null);
			base.CameraModel.FightCamera.LogicComponent.CameraInputController.Lock(this);
			this.IsChangingCamera = true;
			this.AddFadeOut();
			return true;
		}
		return false;
	}

	// Token: 0x060054D4 RID: 21716 RVA: 0x000D326C File Offset: 0x000D146C
	private void AddEventSystem()
	{
		if (!Singleton<EventSystem>.Instance.Has<float, string>(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged)))
		{
			Singleton<EventSystem>.Instance.Add<float, string>(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged));
		}
		if (!Singleton<EventSystem>.Instance.Has(EEventName.FixedCameraRestored, new Action(this.OnFixedCameraRestored)))
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FixedCameraRestored, new Action(this.OnFixedCameraRestored));
		}
	}

	// Token: 0x060054D5 RID: 21717 RVA: 0x000D32EC File Offset: 0x000D14EC
	private void RemoveEventSystem()
	{
		if (Singleton<EventSystem>.Instance.Has<float, string>(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged)))
		{
			Singleton<EventSystem>.Instance.Remove<float, string>(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged));
		}
		if (Singleton<EventSystem>.Instance.Has(EEventName.FixedCameraRestored, new Action(this.OnFixedCameraRestored)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FixedCameraRestored, new Action(this.OnFixedCameraRestored));
		}
	}

	// Token: 0x060054D6 RID: 21718 RVA: 0x000D336C File Offset: 0x000D156C
	protected void OnViewTargetChanged(float f, string cameraName)
	{
		CameraModelInstance cameraModel = base.CameraModel;
		if (cameraName != ((cameraModel != null) ? cameraModel.CameraName : null))
		{
			return;
		}
		if (this.NowInCamera != null && base.CameraModel.CurrentCameraActor != this.NowInCamera && this.IsLockedCamera)
		{
			base.CameraModel.FightCamera.LogicComponent.CameraInputController.Unlock(this);
			this.RemoveEventSystem();
			this.IsLockedCamera = false;
		}
	}

	// Token: 0x060054D7 RID: 21719 RVA: 0x000D33DF File Offset: 0x000D15DF
	protected void OnFixedCameraRestored()
	{
		if (this.IsLockedCamera)
		{
			this.FixedCameraResetViewTarget();
		}
		base.CameraModel.FightCamera.LogicComponent.SetIsDitherEffectEnable(true);
	}

	// Token: 0x060054D8 RID: 21720 RVA: 0x000D3408 File Offset: 0x000D1608
	private bool CheckIfTheSameCamera(Vector vectorLoc)
	{
		ACameraActor nowInCamera = this.NowInCamera;
		FVectorDouble? fvectorDouble = (nowInCamera != null) ? new FVectorDouble?(nowInCamera.D_K2_GetActorLocation()) : null;
		return Singleton<MathUtils>.Instance.IsNearlyEqual(fvectorDouble.Value.X, vectorLoc.ToUeVector(false).X, new double?(0.0001)) && Singleton<MathUtils>.Instance.IsNearlyEqual(fvectorDouble.Value.Y, vectorLoc.ToUeVector(false).Y, new double?(0.0001)) && Singleton<MathUtils>.Instance.IsNearlyEqual(fvectorDouble.Value.Z, vectorLoc.ToUeVector(false).Z, new double?(0.0001));
	}

	// Token: 0x060054D9 RID: 21721 RVA: 0x000D34CE File Offset: 0x000D16CE
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraDialogue)key);
	}

	// Token: 0x060054DA RID: 21722 RVA: 0x000D34D8 File Offset: 0x000D16D8
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 10:
				if (key == "FadeInTime")
				{
					value = this.FadeInTime;
					return true;
				}
				break;
			case 11:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'N')
					{
						if (key == "NowInCamera")
						{
							value = this.NowInCamera;
							return true;
						}
					}
				}
				else if (key == "FadeOutTime")
				{
					value = this.FadeOutTime;
					return true;
				}
				break;
			}
			case 12:
			{
				char c = key[0];
				if (c != 'L')
				{
					if (c == 'T')
					{
						if (key == "TickIdFadeIn")
						{
							value = this.TickIdFadeIn;
							return true;
						}
					}
				}
				else if (key == "LastInCamera")
				{
					value = this.LastInCamera;
					return true;
				}
				break;
			}
			case 13:
				if (key == "TickIdFadeOut")
				{
					value = this.TickIdFadeOut;
					return true;
				}
				break;
			case 14:
				if (key == "IsLockedCamera")
				{
					value = this.IsLockedCamera;
					return true;
				}
				break;
			case 16:
				if (key == "IsChangingCamera")
				{
					value = this.IsChangingCamera;
					return true;
				}
				break;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x060054DB RID: 21723 RVA: 0x000D364C File Offset: 0x000D184C
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 10:
				if (key == "FadeInTime")
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
					this.FadeInTime = num2;
					return;
				}
				break;
			case 11:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'N')
					{
						if (key == "NowInCamera")
						{
							this.NowInCamera = (ACameraActor)value;
							return;
						}
					}
				}
				else if (key == "FadeOutTime")
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
					this.FadeOutTime = num2;
					return;
				}
				break;
			}
			case 12:
			{
				char c = key[0];
				if (c != 'L')
				{
					if (c == 'T')
					{
						if (key == "TickIdFadeIn")
						{
							this.TickIdFadeIn = (TimerHandle)value;
							return;
						}
					}
				}
				else if (key == "LastInCamera")
				{
					this.LastInCamera = (ACameraActor)value;
					return;
				}
				break;
			}
			case 13:
				if (key == "TickIdFadeOut")
				{
					this.TickIdFadeOut = (TimerHandle)value;
					return;
				}
				break;
			case 14:
				if (key == "IsLockedCamera")
				{
					this.IsLockedCamera = (bool)value;
					return;
				}
				break;
			case 16:
				if (key == "IsChangingCamera")
				{
					this.IsChangingCamera = (bool)value;
					return;
				}
				break;
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x060054DC RID: 21724 RVA: 0x000D38A2 File Offset: 0x000D1AA2
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraFixedController.<MemberIter>d__27 <MemberIter>d__ = new CameraFixedController.<MemberIter>d__27(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x040019CD RID: 6605
	private float FadeInTime;

	// Token: 0x040019CE RID: 6606
	private float FadeOutTime;

	// Token: 0x040019CF RID: 6607
	[Nullable(2)]
	private TimerHandle TickIdFadeIn;

	// Token: 0x040019D0 RID: 6608
	[Nullable(2)]
	private TimerHandle TickIdFadeOut;

	// Token: 0x040019D1 RID: 6609
	public bool IsLockedCamera;

	// Token: 0x040019D2 RID: 6610
	public bool IsChangingCamera;

	// Token: 0x040019D3 RID: 6611
	[Nullable(2)]
	private ACameraActor NowInCamera;

	// Token: 0x040019D4 RID: 6612
	[Nullable(2)]
	private ACameraActor LastInCamera;
}
