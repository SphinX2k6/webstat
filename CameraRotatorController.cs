using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;

// Token: 0x02000E2F RID: 3631
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraRotatorController : CameraControllerBase<EFightCameraExplore>, ICanGetConfigMapValue
{
	// Token: 0x060055F7 RID: 22007 RVA: 0x000E8D54 File Offset: 0x000E6F54
	public CameraRotatorController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x060055F8 RID: 22008 RVA: 0x000E8DA6 File Offset: 0x000E6FA6
	public override string Name()
	{
		return "RotatorController";
	}

	// Token: 0x060055F9 RID: 22009 RVA: 0x000E8DB0 File Offset: 0x000E6FB0
	public void PlayCameraRotator(Vector lookAt1, Vector lookAt2, Rotator addRotator, float time, bool canBreakByInput = true, float stayTime = 0f)
	{
		this.BeginCameraRotator(lookAt1, lookAt2, addRotator, time, stayTime, 0f, 1f, canBreakByInput, null);
	}

	// Token: 0x060055FA RID: 22010 RVA: 0x000E8DD8 File Offset: 0x000E6FD8
	public void PlayCameraRotatorWithCurve(Vector lookAt1, Vector lookAt2, Rotator addRotator, float time, float minAlpha, float maxAlpha, CurveBase curve, bool canBreakByInput = true, float stayTime = 0f, [Nullable(2)] Action callback = null)
	{
		this.RotatorAlphaCurve = curve;
		this.BeginCameraRotator(lookAt1, lookAt2, addRotator, time, stayTime, minAlpha, maxAlpha, canBreakByInput, callback);
	}

	// Token: 0x060055FB RID: 22011 RVA: 0x000E8E02 File Offset: 0x000E7002
	public void PlayCameraEulerRotator(Rotator desRotator, float time, bool canBreakByInput = true, float stayTime = 0f)
	{
		this.BeginCameraEulerRotator(desRotator, time, stayTime, 0f, 1f, canBreakByInput);
	}

	// Token: 0x060055FC RID: 22012 RVA: 0x000E8E19 File Offset: 0x000E7019
	public void PlayCameraEulerRotatorWithCurve(Rotator desRotator, float time, float minAlpha, float maxAlpha, CurveBase curve, bool canBreakByInput = true, float stayTime = 0f)
	{
		this.RotatorAlphaCurve = curve;
		this.BeginCameraEulerRotator(desRotator, time, stayTime, minAlpha, maxAlpha, canBreakByInput);
	}

	// Token: 0x060055FD RID: 22013 RVA: 0x000E8E34 File Offset: 0x000E7034
	private void UpdateArmRotationModifier(float deltaTime)
	{
		if (!this.IsActive)
		{
			return;
		}
		ValueTuple<float, float> cameraInput = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>().GetCameraInput();
		float item = cameraInput.Item1;
		float item2 = cameraInput.Item2;
		if (this.CanBreakByInput && (Math.Abs(item) > 0f || Math.Abs(item2) > 0f))
		{
			this.FinishCameraRotator();
			return;
		}
		float num = this.CurrentTime / this.Time;
		if (this.RotatorAlphaCurve != null)
		{
			this.Alpha = this.RotatorAlphaCurve.GetCurrentValue(num);
		}
		else
		{
			this.Alpha = num;
		}
		this.Alpha = Singleton<MathUtils>.Instance.Clamp(this.Alpha, this.MinAlpha, this.MaxAlpha);
		if (this.IsSustainingMode)
		{
			this.SustainingLookAt.Subtraction(this.Camera.PlayerLocation, this.SustainingTemp);
			this.SustainingTemp.Rotation(this.DesRotator);
			if (!this.Camera.IsInNormalGravityMode())
			{
				CameraUtility.GetRotatorInGravity(this.DesRotator, this.DesRotator);
			}
		}
		Rotator.Lerp(this.StartRotator, this.DesRotator, this.Alpha, this.CurrentRotator);
		if (this.Camera.IsInNormalGravityMode())
		{
			this.Camera.DesiredCamera.ArmRotation = Rotator.Create(this.CurrentRotator);
		}
		else
		{
			CameraUtility.SetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.CurrentRotator);
		}
		if (this.CurrentTime >= this.Time + this.StayTime)
		{
			this.FinishCameraRotator();
		}
		this.CurrentTime += deltaTime;
	}

	// Token: 0x060055FE RID: 22014 RVA: 0x000E8FD0 File Offset: 0x000E71D0
	private void BeginCameraRotator(Vector lookAt1, Vector lookAt2, Rotator addRotator, float time, float stayTime, float minAlpha, float maxAlpha, bool canBreakByInput, [Nullable(2)] Action finishCallback = null)
	{
		this.IsActive = true;
		if (this.Camera.IsInNormalGravityMode())
		{
			this.StartRotator.FromUeRotator(this.Camera.CurrentCamera.ArmRotation);
		}
		else
		{
			CameraUtility.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.StartRotator);
		}
		Vector vector = Vector.Create();
		lookAt2.Subtraction(lookAt1, vector);
		vector.Rotation(this.DesRotator);
		if (!this.Camera.IsInNormalGravityMode())
		{
			CameraUtility.GetRotatorInGravity(this.DesRotator, this.DesRotator);
		}
		this.Time = time;
		this.StayTime = stayTime;
		this.CurrentTime = 0f;
		this.Alpha = 0f;
		this.MinAlpha = minAlpha;
		this.MaxAlpha = maxAlpha;
		this.CanBreakByInput = canBreakByInput;
		this.FinishCallback = finishCallback;
		Singleton<MathUtils>.Instance.ComposeRotator(this.DesRotator, addRotator, this.DesRotator);
		this.UpdateCameraInputState();
	}

	// Token: 0x060055FF RID: 22015 RVA: 0x000E90C8 File Offset: 0x000E72C8
	public void BeginCameraSustainingRotator(Vector lookAtPosition, float time, float stayTime, int minAlpha, int maxAlpha, bool canBreakByInput, [Nullable(2)] Action callback = null)
	{
		this.IsActive = true;
		this.IsSustainingMode = true;
		if (this.Camera.IsInNormalGravityMode())
		{
			this.StartRotator.FromUeRotator(this.Camera.CurrentCamera.ArmRotation);
		}
		else
		{
			CameraUtility.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.StartRotator);
		}
		this.SustainingLookAt.DeepCopy(lookAtPosition);
		this.Time = time;
		this.StayTime = stayTime;
		this.CurrentTime = 0f;
		this.Alpha = 0f;
		this.MinAlpha = (float)minAlpha;
		this.MaxAlpha = (float)maxAlpha;
		this.CanBreakByInput = canBreakByInput;
		this.FinishCallback = callback;
		this.UpdateCameraInputState();
	}

	// Token: 0x06005600 RID: 22016 RVA: 0x000E9184 File Offset: 0x000E7384
	private void BeginCameraEulerRotator(Rotator desRotator, float time, float stayTime, float minAlpha, float maxAlpha, bool canBreakByInput)
	{
		this.IsActive = true;
		if (this.Camera.IsInNormalGravityMode())
		{
			this.StartRotator.FromUeRotator(this.Camera.CurrentCamera.ArmRotation);
			this.DesRotator.Set(desRotator.Pitch, desRotator.Yaw, desRotator.Roll);
		}
		else
		{
			CameraUtility.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.StartRotator);
			CameraUtility.GetRotatorInGravity(desRotator, this.DesRotator);
		}
		this.Time = time;
		this.StayTime = stayTime;
		this.CurrentTime = 0f;
		this.Alpha = 0f;
		this.MinAlpha = minAlpha;
		this.MaxAlpha = maxAlpha;
		this.CanBreakByInput = canBreakByInput;
		this.UpdateCameraInputState();
	}

	// Token: 0x06005601 RID: 22017 RVA: 0x000E924C File Offset: 0x000E744C
	private void FinishCameraRotator()
	{
		this.IsActive = false;
		this.IsSustainingMode = false;
		this.RotatorAlphaCurve = null;
		this.Camera.CameraInputController.Unlock(this);
		this.Camera.CameraRotationZone.Unlock(this);
		Action finishCallback = this.FinishCallback;
		if (finishCallback != null)
		{
			finishCallback();
		}
		this.FinishCallback = null;
	}

	// Token: 0x06005602 RID: 22018 RVA: 0x000E92A8 File Offset: 0x000E74A8
	private void UpdateCameraInputState()
	{
		if (this.CanBreakByInput)
		{
			this.Camera.CameraInputController.Unlock(this);
		}
		else
		{
			this.Camera.CameraInputController.Lock(this);
		}
		this.Camera.CameraRotationZone.Lock(this);
	}

	// Token: 0x06005603 RID: 22019 RVA: 0x000E92E7 File Offset: 0x000E74E7
	protected override void UpdateInternal(float deltaTime)
	{
		this.UpdateArmRotationModifier(deltaTime);
	}

	// Token: 0x06005604 RID: 22020 RVA: 0x000E92F0 File Offset: 0x000E74F0
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraExplore)key);
	}

	// Token: 0x06005605 RID: 22021 RVA: 0x000E92FC File Offset: 0x000E74FC
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 4:
				if (key == "Time")
				{
					value = this.Time;
					return true;
				}
				break;
			case 5:
				if (key == "Alpha")
				{
					value = this.Alpha;
					return true;
				}
				break;
			case 8:
			{
				char c = key[1];
				if (c <= 'i')
				{
					if (c != 'a')
					{
						if (c == 'i')
						{
							if (key == "MinAlpha")
							{
								value = this.MinAlpha;
								return true;
							}
						}
					}
					else if (key == "MaxAlpha")
					{
						value = this.MaxAlpha;
						return true;
					}
				}
				else if (c != 's')
				{
					if (c == 't')
					{
						if (key == "StayTime")
						{
							value = this.StayTime;
							return true;
						}
					}
				}
				else if (key == "IsActive")
				{
					value = this.IsActive;
					return true;
				}
				break;
			}
			case 10:
				if (key == "DesRotator")
				{
					value = this.DesRotator;
					return true;
				}
				break;
			case 11:
				if (key == "CurrentTime")
				{
					value = this.CurrentTime;
					return true;
				}
				break;
			case 12:
				if (key == "StartRotator")
				{
					value = this.StartRotator;
					return true;
				}
				break;
			case 14:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c != 'F')
					{
						if (c == 'S')
						{
							if (key == "SustainingTemp")
							{
								value = this.SustainingTemp;
								return true;
							}
						}
					}
					else if (key == "FinishCallback")
					{
						value = this.FinishCallback;
						return true;
					}
				}
				else if (key == "CurrentRotator")
				{
					value = this.CurrentRotator;
					return true;
				}
				break;
			}
			case 15:
				if (key == "CanBreakByInput")
				{
					value = this.CanBreakByInput;
					return true;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'I')
				{
					if (c == 'S')
					{
						if (key == "SustainingLookAt")
						{
							value = this.SustainingLookAt;
							return true;
						}
					}
				}
				else if (key == "IsSustainingMode")
				{
					value = this.IsSustainingMode;
					return true;
				}
				break;
			}
			case 17:
				if (key == "RotatorAlphaCurve")
				{
					value = this.RotatorAlphaCurve;
					return true;
				}
				break;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x06005606 RID: 22022 RVA: 0x000E95FC File Offset: 0x000E77FC
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 4:
				if (key == "Time")
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
					this.Time = num2;
					return;
				}
				break;
			case 5:
				if (key == "Alpha")
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
					this.Alpha = num2;
					return;
				}
				break;
			case 8:
			{
				char c = key[1];
				if (c <= 'i')
				{
					if (c != 'a')
					{
						if (c == 'i')
						{
							if (key == "MinAlpha")
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
								this.MinAlpha = num2;
								return;
							}
						}
					}
					else if (key == "MaxAlpha")
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
						this.MaxAlpha = num2;
						return;
					}
				}
				else if (c != 's')
				{
					if (c == 't')
					{
						if (key == "StayTime")
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
							this.StayTime = num2;
							return;
						}
					}
				}
				else if (key == "IsActive")
				{
					this.IsActive = (bool)value;
					return;
				}
				break;
			}
			case 11:
				if (key == "CurrentTime")
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
					this.CurrentTime = num2;
					return;
				}
				break;
			case 14:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'S')
					{
						if (key == "SustainingTemp")
						{
							this.SustainingTemp = (Vector)value;
							return;
						}
					}
				}
				else if (key == "FinishCallback")
				{
					this.FinishCallback = (Action)value;
					return;
				}
				break;
			}
			case 15:
				if (key == "CanBreakByInput")
				{
					this.CanBreakByInput = (bool)value;
					return;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'I')
				{
					if (c == 'S')
					{
						if (key == "SustainingLookAt")
						{
							this.SustainingLookAt = (Vector)value;
							return;
						}
					}
				}
				else if (key == "IsSustainingMode")
				{
					this.IsSustainingMode = (bool)value;
					return;
				}
				break;
			}
			case 17:
				if (key == "RotatorAlphaCurve")
				{
					this.RotatorAlphaCurve = (CurveBase)value;
					return;
				}
				break;
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x06005607 RID: 22023 RVA: 0x000E9AF1 File Offset: 0x000E7CF1
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraRotatorController.<MemberIter>d__32 <MemberIter>d__ = new CameraRotatorController.<MemberIter>d__32(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001BAD RID: 7085
	public readonly Rotator StartRotator = Rotator.Create();

	// Token: 0x04001BAE RID: 7086
	public readonly Rotator DesRotator = Rotator.Create();

	// Token: 0x04001BAF RID: 7087
	public readonly Rotator CurrentRotator = Rotator.Create();

	// Token: 0x04001BB0 RID: 7088
	private bool IsActive;

	// Token: 0x04001BB1 RID: 7089
	private float Time;

	// Token: 0x04001BB2 RID: 7090
	private float StayTime;

	// Token: 0x04001BB3 RID: 7091
	private float CurrentTime;

	// Token: 0x04001BB4 RID: 7092
	public float Alpha;

	// Token: 0x04001BB5 RID: 7093
	private float MinAlpha;

	// Token: 0x04001BB6 RID: 7094
	private float MaxAlpha;

	// Token: 0x04001BB7 RID: 7095
	[Nullable(2)]
	private CurveBase RotatorAlphaCurve;

	// Token: 0x04001BB8 RID: 7096
	private bool CanBreakByInput = true;

	// Token: 0x04001BB9 RID: 7097
	private Vector SustainingLookAt = Vector.Create();

	// Token: 0x04001BBA RID: 7098
	private Vector SustainingTemp = Vector.Create();

	// Token: 0x04001BBB RID: 7099
	private bool IsSustainingMode;

	// Token: 0x04001BBC RID: 7100
	[Nullable(2)]
	private Action FinishCallback;
}
