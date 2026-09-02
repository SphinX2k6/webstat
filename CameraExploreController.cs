using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02000E0D RID: 3597
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraExploreController : CameraControllerBase<EFightCameraExplore>, ICanGetConfigMapValue
{
	// Token: 0x060054BD RID: 21693 RVA: 0x000D1C54 File Offset: 0x000CFE54
	public CameraExploreController(FightCameraLogicComponent camera) : base(camera)
	{
		this.StateMachine = new StateMachine<CameraExploreController, CameraExploreController.ECameraState>(this, null);
		this.StateMachine.AddState<CameraExploreController.DefaultState>(CameraExploreController.ECameraState.Default, null);
		this.StateMachine.AddState<CameraExploreController.ReadyAdjustState>(CameraExploreController.ECameraState.ReadyAdjust, null);
		this.StateMachine.AddState<CameraExploreController.AdjustState>(CameraExploreController.ECameraState.Adjust, null);
		this.StateMachine.Start(CameraExploreController.ECameraState.Default);
	}

	// Token: 0x060054BE RID: 21694 RVA: 0x000D1CD5 File Offset: 0x000CFED5
	public override string Name()
	{
		return "ExploreController";
	}

	// Token: 0x060054BF RID: 21695 RVA: 0x000D1CDC File Offset: 0x000CFEDC
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraExplore.修正角度Min, "CheckAdjustYawAngleMin");
		base.SetConfigMap(EFightCameraExplore.修正角度Max, "CheckAdjustYawAngleMax");
		base.SetConfigMap(EFightCameraExplore.InRangeMin, "DefaultPitchInRangeMin");
		base.SetConfigMap(EFightCameraExplore.InRangeMax, "DefaultPitchInRangeMax");
		base.SetConfigMap(EFightCameraExplore.OutRangeMin, "DefaultPitchOutRangeMin");
		base.SetConfigMap(EFightCameraExplore.OutRangeMax, "DefaultPitchOutRangeMax");
		base.SetConfigMap(EFightCameraExplore.摄像机合法角度_移动方向_, "CheckCameraDirectionCos");
		base.SetConfigMap(EFightCameraExplore.移动方向合法角度_看向点方向_, "CheckMoveDirectionCos");
		base.RegisterPairConfigKey(EFightCameraExplore.修正角度Min, EFightCameraExplore.修正角度Max, true);
		base.RegisterPairConfigKey(EFightCameraExplore.InRangeMin, EFightCameraExplore.InRangeMax, true);
		base.RegisterPairConfigKey(EFightCameraExplore.OutRangeMin, EFightCameraExplore.OutRangeMax, true);
	}

	// Token: 0x060054C0 RID: 21696 RVA: 0x000D1D64 File Offset: 0x000CFF64
	public void EnterCameraExplore(int id, FVectorDouble? lookAt1, FVectorDouble? lookAt2, float prepTime, float fadeDistance, float armLengthMin, float armLengthMax)
	{
		this.CurrentTriggerRangeId = id;
		this.HasLookAtPoint = (lookAt1 != null && lookAt2 != null);
		if (this.HasLookAtPoint)
		{
			Vector lookAtLocation = this.LookAtLocation1;
			FVectorDouble value = lookAt1.Value;
			lookAtLocation.FromUeVector(value);
			Vector lookAtLocation2 = this.LookAtLocation2;
			value = lookAt2.Value;
			lookAtLocation2.FromUeVector(value);
			this.LookAtDirection.DeepCopy(this.LookAtLocation1);
			this.LookAtDirection.SubtractionEqual(this.LookAtLocation2);
		}
		this.PrepTime = (double)prepTime;
		this.FadeDistance = (double)fadeDistance;
		this.ArmLengthMin = (double)armLengthMin;
		this.ArmLengthMax = (double)armLengthMax;
		this.InTriggerRangeSet[id] = new ValueTuple<FVectorDouble?, FVectorDouble?, double, double, double, double>(lookAt1, lookAt2, (double)prepTime, (double)fadeDistance, (double)armLengthMin, (double)armLengthMax);
		this.LookAtDirection.Normalize(9.999999747378752E-05);
		this.IsInTriggerRange = true;
		CameraExploreController.ECameraState? currentState = this.StateMachine.CurrentState;
		if (currentState != null)
		{
			switch (currentState.GetValueOrDefault())
			{
			case CameraExploreController.ECameraState.Default:
				this.StateMachine.Switch(CameraExploreController.ECameraState.Default);
				return;
			case CameraExploreController.ECameraState.ReadyAdjust:
				this.StateMachine.Switch(CameraExploreController.ECameraState.Default);
				return;
			case CameraExploreController.ECameraState.Adjust:
				this.StateMachine.Switch(CameraExploreController.ECameraState.Adjust);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x060054C1 RID: 21697 RVA: 0x000D1EA0 File Offset: 0x000D00A0
	public void ExitCameraExplore(int id)
	{
		this.InTriggerRangeSet.Remove(id);
		if (this.CurrentTriggerRangeId == id)
		{
			if (this.InTriggerRangeSet.Count > 0)
			{
				using (Dictionary<int, ValueTuple<FVectorDouble?, FVectorDouble?, double, double, double, double>>.Enumerator enumerator = this.InTriggerRangeSet.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<int, ValueTuple<FVectorDouble?, FVectorDouble?, double, double, double, double>> keyValuePair = enumerator.Current;
						int key = keyValuePair.Key;
						ValueTuple<FVectorDouble?, FVectorDouble?, double, double, double, double> value = keyValuePair.Value;
						FVectorDouble? item = value.Item1;
						FVectorDouble? item2 = value.Item2;
						double item3 = value.Item3;
						double item4 = value.Item4;
						double item5 = value.Item5;
						double item6 = value.Item6;
						this.CurrentTriggerRangeId = key;
						this.HasLookAtPoint = (item != null && item2 != null);
						if (this.HasLookAtPoint)
						{
							Vector lookAtLocation = this.LookAtLocation1;
							FVectorDouble value2 = item.Value;
							lookAtLocation.FromUeVector(value2);
							Vector lookAtLocation2 = this.LookAtLocation2;
							value2 = item2.Value;
							lookAtLocation2.FromUeVector(value2);
							this.LookAtDirection.DeepCopy(this.LookAtLocation1);
							this.LookAtDirection.SubtractionEqual(this.LookAtLocation2);
						}
						this.PrepTime = item3;
						this.FadeDistance = item4;
						this.ArmLengthMin = item5;
						this.ArmLengthMax = item6;
						this.LookAtDirection.Normalize(9.999999747378752E-05);
						CameraExploreController.ECameraState? currentState = this.StateMachine.CurrentState;
						if (currentState != null)
						{
							switch (currentState.GetValueOrDefault())
							{
							case CameraExploreController.ECameraState.Default:
								this.StateMachine.Switch(CameraExploreController.ECameraState.Default);
								break;
							case CameraExploreController.ECameraState.ReadyAdjust:
								this.StateMachine.Switch(CameraExploreController.ECameraState.Default);
								break;
							case CameraExploreController.ECameraState.Adjust:
								this.StateMachine.Switch(CameraExploreController.ECameraState.Adjust);
								break;
							}
						}
					}
					return;
				}
			}
			this.IsInTriggerRange = false;
		}
	}

	// Token: 0x060054C2 RID: 21698 RVA: 0x000D207C File Offset: 0x000D027C
	protected override void UpdateInternal(float deltaTime)
	{
		if (this.Camera.IsModifiedArmRotationPitch || this.Camera.IsModifiedArmRotationYaw || this.Camera.IsModifiedArmLength)
		{
			this.StateMachine.Switch(CameraExploreController.ECameraState.Default);
		}
		this.StateMachine.Update(deltaTime);
	}

	// Token: 0x060054C3 RID: 21699 RVA: 0x000D20CC File Offset: 0x000D02CC
	public bool CheckAdjust()
	{
		if (!this.IsInTriggerRange)
		{
			return false;
		}
		Vector vector = Vector.Create(this.Camera.Character.K2_GetActorRotation().Vector());
		Vector vector2 = Vector.Create();
		this.Camera.CameraRotation.Vector(vector2);
		if (vector.DotProduct(vector2) < this.CheckCameraDirectionCos)
		{
			return false;
		}
		if (this.HasLookAtPoint)
		{
			Vector lookAtDirection = this.LookAtDirection;
			double num = vector.DotProduct(lookAtDirection);
			if (num < this.CheckMoveDirectionCos && num > -this.CheckMoveDirectionCos)
			{
				return false;
			}
		}
		ECharMoveState moveState = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterUnifiedStateComponent>().MoveState;
		return moveState - ECharMoveState.Walk <= 5;
	}

	// Token: 0x060054C4 RID: 21700 RVA: 0x000D2183 File Offset: 0x000D0383
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraExplore)key);
	}

	// Token: 0x060054C5 RID: 21701 RVA: 0x000D2190 File Offset: 0x000D0390
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
				if (key == "PrepTime")
				{
					value = this.PrepTime;
					return true;
				}
				break;
			case 12:
			{
				char c = key[10];
				if (c <= 'c')
				{
					if (c != 'a')
					{
						if (c == 'c')
						{
							if (key == "FadeDistance")
							{
								value = this.FadeDistance;
								return true;
							}
						}
					}
					else if (key == "ArmLengthMax")
					{
						value = this.ArmLengthMax;
						return true;
					}
				}
				else if (c != 'i')
				{
					if (c == 'n')
					{
						if (key == "StateMachine")
						{
							value = this.StateMachine;
							return true;
						}
					}
				}
				else if (key == "ArmLengthMin")
				{
					value = this.ArmLengthMin;
					return true;
				}
				break;
			}
			case 14:
				if (key == "HasLookAtPoint")
				{
					value = this.HasLookAtPoint;
					return true;
				}
				break;
			case 15:
			{
				char c = key[14];
				if (c != '1')
				{
					if (c != '2')
					{
						if (c == 'n')
						{
							if (key == "LookAtDirection")
							{
								value = this.LookAtDirection;
								return true;
							}
						}
					}
					else if (key == "LookAtLocation2")
					{
						value = this.LookAtLocation2;
						return true;
					}
				}
				else if (key == "LookAtLocation1")
				{
					value = this.LookAtLocation1;
					return true;
				}
				break;
			}
			case 16:
				if (key == "IsInTriggerRange")
				{
					value = this.IsInTriggerRange;
					return true;
				}
				break;
			case 17:
				if (key == "InTriggerRangeSet")
				{
					value = this.InTriggerRangeSet;
					return true;
				}
				break;
			case 21:
			{
				char c = key[1];
				if (c != 'h')
				{
					if (c == 'u')
					{
						if (key == "CurrentTriggerRangeId")
						{
							value = this.CurrentTriggerRangeId;
							return true;
						}
					}
				}
				else if (key == "CheckMoveDirectionCos")
				{
					value = this.CheckMoveDirectionCos;
					return true;
				}
				break;
			}
			case 22:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'D')
					{
						if (key == "DefaultPitchInRangeMin")
						{
							value = this.DefaultPitchInRangeMin;
							return true;
						}
						if (key == "DefaultPitchInRangeMax")
						{
							value = this.DefaultPitchInRangeMax;
							return true;
						}
					}
				}
				else
				{
					if (key == "CheckAdjustYawAngleMin")
					{
						value = this.CheckAdjustYawAngleMin;
						return true;
					}
					if (key == "CheckAdjustYawAngleMax")
					{
						value = this.CheckAdjustYawAngleMax;
						return true;
					}
				}
				break;
			}
			case 23:
			{
				char c = key[21];
				if (c != 'a')
				{
					if (c != 'i')
					{
						if (c == 'o')
						{
							if (key == "CheckCameraDirectionCos")
							{
								value = this.CheckCameraDirectionCos;
								return true;
							}
						}
					}
					else if (key == "DefaultPitchOutRangeMin")
					{
						value = this.DefaultPitchOutRangeMin;
						return true;
					}
				}
				else if (key == "DefaultPitchOutRangeMax")
				{
					value = this.DefaultPitchOutRangeMax;
					return true;
				}
				break;
			}
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x060054C6 RID: 21702 RVA: 0x000D256C File Offset: 0x000D076C
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			int num = key.Length;
			if (num != 8)
			{
				switch (num)
				{
				case 12:
				{
					char c = key[10];
					if (c != 'a')
					{
						if (c != 'c')
						{
							if (c == 'i')
							{
								if (key == "ArmLengthMin")
								{
									double num3;
									if (value is double)
									{
										double num2 = (double)value;
										num3 = num2;
									}
									else if (value is float)
									{
										float num4 = (float)value;
										num3 = (double)num4;
									}
									else if (value is int)
									{
										int num5 = (int)value;
										num3 = (double)num5;
									}
									else if (value is long)
									{
										long num6 = (long)value;
										num3 = (double)num6;
									}
									else
									{
										num3 = (double)value;
									}
									this.ArmLengthMin = num3;
									return;
								}
							}
						}
						else if (key == "FadeDistance")
						{
							double num3;
							if (value is double)
							{
								double num7 = (double)value;
								num3 = num7;
							}
							else if (value is float)
							{
								float num8 = (float)value;
								num3 = (double)num8;
							}
							else if (value is int)
							{
								int num9 = (int)value;
								num3 = (double)num9;
							}
							else if (value is long)
							{
								long num10 = (long)value;
								num3 = (double)num10;
							}
							else
							{
								num3 = (double)value;
							}
							this.FadeDistance = num3;
							return;
						}
					}
					else if (key == "ArmLengthMax")
					{
						double num3;
						if (value is double)
						{
							double num11 = (double)value;
							num3 = num11;
						}
						else if (value is float)
						{
							float num12 = (float)value;
							num3 = (double)num12;
						}
						else if (value is int)
						{
							int num13 = (int)value;
							num3 = (double)num13;
						}
						else if (value is long)
						{
							long num14 = (long)value;
							num3 = (double)num14;
						}
						else
						{
							num3 = (double)value;
						}
						this.ArmLengthMax = num3;
						return;
					}
					break;
				}
				case 13:
				case 15:
					break;
				case 14:
					if (key == "HasLookAtPoint")
					{
						this.HasLookAtPoint = (bool)value;
						return;
					}
					break;
				case 16:
					if (key == "IsInTriggerRange")
					{
						this.IsInTriggerRange = (bool)value;
						return;
					}
					break;
				default:
					switch (num)
					{
					case 21:
					{
						char c = key[1];
						if (c != 'h')
						{
							if (c == 'u')
							{
								if (key == "CurrentTriggerRangeId")
								{
									if (value is double)
									{
										double num15 = (double)value;
										num = (int)num15;
									}
									else if (value is float)
									{
										float num16 = (float)value;
										num = (int)num16;
									}
									else if (value is int)
									{
										int num17 = (int)value;
										num = num17;
									}
									else if (value is long)
									{
										long num18 = (long)value;
										num = (int)num18;
									}
									else
									{
										num = (int)value;
									}
									this.CurrentTriggerRangeId = num;
									return;
								}
							}
						}
						else if (key == "CheckMoveDirectionCos")
						{
							double num3;
							if (value is double)
							{
								double num19 = (double)value;
								num3 = num19;
							}
							else if (value is float)
							{
								float num20 = (float)value;
								num3 = (double)num20;
							}
							else if (value is int)
							{
								int num21 = (int)value;
								num3 = (double)num21;
							}
							else if (value is long)
							{
								long num22 = (long)value;
								num3 = (double)num22;
							}
							else
							{
								num3 = (double)value;
							}
							this.CheckMoveDirectionCos = num3;
							return;
						}
						break;
					}
					case 22:
					{
						char c = key[0];
						if (c != 'C')
						{
							if (c == 'D')
							{
								if (key == "DefaultPitchInRangeMin")
								{
									double num3;
									if (value is double)
									{
										double num23 = (double)value;
										num3 = num23;
									}
									else if (value is float)
									{
										float num24 = (float)value;
										num3 = (double)num24;
									}
									else if (value is int)
									{
										int num25 = (int)value;
										num3 = (double)num25;
									}
									else if (value is long)
									{
										long num26 = (long)value;
										num3 = (double)num26;
									}
									else
									{
										num3 = (double)value;
									}
									this.DefaultPitchInRangeMin = num3;
									return;
								}
								if (key == "DefaultPitchInRangeMax")
								{
									double num3;
									if (value is double)
									{
										double num27 = (double)value;
										num3 = num27;
									}
									else if (value is float)
									{
										float num28 = (float)value;
										num3 = (double)num28;
									}
									else if (value is int)
									{
										int num29 = (int)value;
										num3 = (double)num29;
									}
									else if (value is long)
									{
										long num30 = (long)value;
										num3 = (double)num30;
									}
									else
									{
										num3 = (double)value;
									}
									this.DefaultPitchInRangeMax = num3;
									return;
								}
							}
						}
						else
						{
							if (key == "CheckAdjustYawAngleMin")
							{
								double num3;
								if (value is double)
								{
									double num31 = (double)value;
									num3 = num31;
								}
								else if (value is float)
								{
									float num32 = (float)value;
									num3 = (double)num32;
								}
								else if (value is int)
								{
									int num33 = (int)value;
									num3 = (double)num33;
								}
								else if (value is long)
								{
									long num34 = (long)value;
									num3 = (double)num34;
								}
								else
								{
									num3 = (double)value;
								}
								this.CheckAdjustYawAngleMin = num3;
								return;
							}
							if (key == "CheckAdjustYawAngleMax")
							{
								double num3;
								if (value is double)
								{
									double num35 = (double)value;
									num3 = num35;
								}
								else if (value is float)
								{
									float num36 = (float)value;
									num3 = (double)num36;
								}
								else if (value is int)
								{
									int num37 = (int)value;
									num3 = (double)num37;
								}
								else if (value is long)
								{
									long num38 = (long)value;
									num3 = (double)num38;
								}
								else
								{
									num3 = (double)value;
								}
								this.CheckAdjustYawAngleMax = num3;
								return;
							}
						}
						break;
					}
					case 23:
					{
						char c = key[21];
						if (c != 'a')
						{
							if (c != 'i')
							{
								if (c == 'o')
								{
									if (key == "CheckCameraDirectionCos")
									{
										double num3;
										if (value is double)
										{
											double num39 = (double)value;
											num3 = num39;
										}
										else if (value is float)
										{
											float num40 = (float)value;
											num3 = (double)num40;
										}
										else if (value is int)
										{
											int num41 = (int)value;
											num3 = (double)num41;
										}
										else if (value is long)
										{
											long num42 = (long)value;
											num3 = (double)num42;
										}
										else
										{
											num3 = (double)value;
										}
										this.CheckCameraDirectionCos = num3;
										return;
									}
								}
							}
							else if (key == "DefaultPitchOutRangeMin")
							{
								double num3;
								if (value is double)
								{
									double num43 = (double)value;
									num3 = num43;
								}
								else if (value is float)
								{
									float num44 = (float)value;
									num3 = (double)num44;
								}
								else if (value is int)
								{
									int num45 = (int)value;
									num3 = (double)num45;
								}
								else if (value is long)
								{
									long num46 = (long)value;
									num3 = (double)num46;
								}
								else
								{
									num3 = (double)value;
								}
								this.DefaultPitchOutRangeMin = num3;
								return;
							}
						}
						else if (key == "DefaultPitchOutRangeMax")
						{
							double num3;
							if (value is double)
							{
								double num47 = (double)value;
								num3 = num47;
							}
							else if (value is float)
							{
								float num48 = (float)value;
								num3 = (double)num48;
							}
							else if (value is int)
							{
								int num49 = (int)value;
								num3 = (double)num49;
							}
							else if (value is long)
							{
								long num50 = (long)value;
								num3 = (double)num50;
							}
							else
							{
								num3 = (double)value;
							}
							this.DefaultPitchOutRangeMax = num3;
							return;
						}
						break;
					}
					}
					break;
				}
			}
			else if (key == "PrepTime")
			{
				double num3;
				if (value is double)
				{
					double num51 = (double)value;
					num3 = num51;
				}
				else if (value is float)
				{
					float num52 = (float)value;
					num3 = (double)num52;
				}
				else if (value is int)
				{
					int num53 = (int)value;
					num3 = (double)num53;
				}
				else if (value is long)
				{
					long num54 = (long)value;
					num3 = (double)num54;
				}
				else
				{
					num3 = (double)value;
				}
				this.PrepTime = num3;
				return;
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x060054C7 RID: 21703 RVA: 0x000D2D80 File Offset: 0x000D0F80
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraExploreController.<MemberIter>d__34 <MemberIter>d__ = new CameraExploreController.<MemberIter>d__34(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x040019B9 RID: 6585
	public double CheckAdjustYawAngleMin;

	// Token: 0x040019BA RID: 6586
	public double CheckAdjustYawAngleMax;

	// Token: 0x040019BB RID: 6587
	public double DefaultPitchInRangeMin;

	// Token: 0x040019BC RID: 6588
	public double DefaultPitchInRangeMax;

	// Token: 0x040019BD RID: 6589
	public double DefaultPitchOutRangeMin;

	// Token: 0x040019BE RID: 6590
	public double DefaultPitchOutRangeMax;

	// Token: 0x040019BF RID: 6591
	public double CheckCameraDirectionCos;

	// Token: 0x040019C0 RID: 6592
	public double CheckMoveDirectionCos;

	// Token: 0x040019C1 RID: 6593
	public readonly Vector LookAtLocation1 = Vector.Create();

	// Token: 0x040019C2 RID: 6594
	public readonly Vector LookAtLocation2 = Vector.Create();

	// Token: 0x040019C3 RID: 6595
	public readonly Vector LookAtDirection = Vector.Create();

	// Token: 0x040019C4 RID: 6596
	private readonly StateMachine<CameraExploreController, CameraExploreController.ECameraState> StateMachine;

	// Token: 0x040019C5 RID: 6597
	public double PrepTime;

	// Token: 0x040019C6 RID: 6598
	public double FadeDistance;

	// Token: 0x040019C7 RID: 6599
	public double ArmLengthMin;

	// Token: 0x040019C8 RID: 6600
	public double ArmLengthMax;

	// Token: 0x040019C9 RID: 6601
	private bool IsInTriggerRange;

	// Token: 0x040019CA RID: 6602
	public bool HasLookAtPoint;

	// Token: 0x040019CB RID: 6603
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly Dictionary<int, ValueTuple<FVectorDouble?, FVectorDouble?, double, double, double, double>> InTriggerRangeSet = new Dictionary<int, ValueTuple<FVectorDouble?, FVectorDouble?, double, double, double, double>>();

	// Token: 0x040019CC RID: 6604
	private int CurrentTriggerRangeId;

	// Token: 0x0200727A RID: 29306
	[NullableContext(0)]
	public enum ECameraState
	{
		// Token: 0x04027B75 RID: 162677
		Default,
		// Token: 0x04027B76 RID: 162678
		ReadyAdjust,
		// Token: 0x04027B77 RID: 162679
		Adjust
	}

	// Token: 0x0200727B RID: 29307
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DefaultState : StateBase<CameraExploreController, CameraExploreController.ECameraState>
	{
		// Token: 0x060468BF RID: 288959 RVA: 0x012B2E0B File Offset: 0x012B100B
		public DefaultState(CameraExploreController owner, CameraExploreController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraExploreController, CameraExploreController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x060468C0 RID: 288960 RVA: 0x012B2E16 File Offset: 0x012B1016
		protected override void OnUpdate(float delta)
		{
			if (this.Owner.CheckAdjust())
			{
				this.StateMachine.Switch(CameraExploreController.ECameraState.ReadyAdjust);
			}
		}
	}

	// Token: 0x0200727C RID: 29308
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ReadyAdjustState : StateBase<CameraExploreController, CameraExploreController.ECameraState>
	{
		// Token: 0x060468C1 RID: 288961 RVA: 0x012B2E32 File Offset: 0x012B1032
		public ReadyAdjustState(CameraExploreController owner, CameraExploreController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraExploreController, CameraExploreController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x060468C2 RID: 288962 RVA: 0x012B2E3D File Offset: 0x012B103D
		protected override void OnEnter(CameraExploreController.ECameraState? state)
		{
			this.ElapseTime = 0.0;
		}

		// Token: 0x060468C3 RID: 288963 RVA: 0x012B2E50 File Offset: 0x012B1050
		protected override void OnUpdate(float delta)
		{
			this.ElapseTime += (double)delta;
			if (!this.Owner.CheckAdjust())
			{
				this.StateMachine.Switch(CameraExploreController.ECameraState.Default);
				return;
			}
			if (this.ElapseTime >= this.Owner.PrepTime)
			{
				this.StateMachine.Switch(CameraExploreController.ECameraState.Adjust);
			}
		}

		// Token: 0x04027B78 RID: 162680
		private double ElapseTime;
	}

	// Token: 0x0200727D RID: 29309
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AdjustState : StateBase<CameraExploreController, CameraExploreController.ECameraState>
	{
		// Token: 0x060468C4 RID: 288964 RVA: 0x012B2EA8 File Offset: 0x012B10A8
		public AdjustState(CameraExploreController owner, CameraExploreController.ECameraState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CameraExploreController, CameraExploreController.ECameraState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x1700A780 RID: 42880
		// (get) Token: 0x060468C5 RID: 288965 RVA: 0x012B2EF5 File Offset: 0x012B10F5
		private double Sign
		{
			get
			{
				return (double)(this.Positive ? 1 : -1);
			}
		}

		// Token: 0x060468C6 RID: 288966 RVA: 0x012B2F04 File Offset: 0x012B1104
		protected override void OnEnter(CameraExploreController.ECameraState? state)
		{
			this.StartCameraArmOffset.DeepCopy(this.CurrentCameraArmOffset);
			this.MoveDistance = 0.0;
			Vector lastCharacterPosition = this.LastCharacterPosition;
			FVectorDouble fvectorDouble = this.Owner.Camera.Character.D_K2_GetActorLocation();
			lastCharacterPosition.FromUeVector(fvectorDouble);
			FRotator frotator = this.Owner.Camera.Character.K2_GetActorRotation();
			this.LookAtVector.DeepCopy(this.Owner.LookAtLocation1);
			this.LookAtVector.SubtractionEqual(this.Owner.LookAtLocation2);
			this.Positive = (Vector.DotProduct(this.LookAtVector, Vector.Create(frotator.Vector())) > 0.0);
			this.LookAtVector.Normalize(9.999999747378752E-05);
			Vector vector = Vector.Create();
			vector.DeepCopy(this.LastCharacterPosition);
			vector.SubtractionEqual(this.Owner.LookAtLocation1);
			this.CharacterStartDistance = Vector.DotProduct(this.LookAtVector, vector);
			if (this.Owner.HasLookAtPoint)
			{
				this.CalculateDesiredRotation();
			}
			this.CalculateDesiredArmLength();
		}

		// Token: 0x060468C7 RID: 288967 RVA: 0x012B3028 File Offset: 0x012B1228
		public override bool CanReEnter()
		{
			return true;
		}

		// Token: 0x060468C8 RID: 288968 RVA: 0x012B302C File Offset: 0x012B122C
		protected override void OnReEnter()
		{
			this.OnEnter(null);
		}

		// Token: 0x060468C9 RID: 288969 RVA: 0x012B3048 File Offset: 0x012B1248
		protected override void OnUpdate(float delta)
		{
			if (!this.Owner.CheckAdjust())
			{
				this.StateMachine.Switch(CameraExploreController.ECameraState.Default);
				return;
			}
			Vector vector = Vector.Create(this.Owner.Camera.Character.D_K2_GetActorLocation());
			this.UpdateMoveDistance(vector);
			this.Interpolate();
			this.LastCharacterPosition.DeepCopy(vector);
		}

		// Token: 0x060468CA RID: 288970 RVA: 0x012B30AC File Offset: 0x012B12AC
		private void UpdateMoveDistance(Vector charPosition)
		{
			if (!charPosition.Equals(this.LastCharacterPosition, 0.0001))
			{
				if (!this.Owner.HasLookAtPoint)
				{
					Vector vector = Vector.Create();
					vector.DeepCopy(charPosition);
					vector.SubtractionEqual(this.Owner.LookAtLocation1);
					double num = Vector.DotProduct(this.LookAtVector, vector);
					this.MoveDistance = (num - this.CharacterStartDistance) * this.Sign;
					return;
				}
				this.MoveDistance += Vector.Dist(charPosition, this.LastCharacterPosition);
			}
		}

		// Token: 0x060468CB RID: 288971 RVA: 0x012B3138 File Offset: 0x012B1338
		private void CalculateDesiredRotation()
		{
			Vector inB = Vector.Create(this.Owner.Camera.PlayerLocation);
			Vector vector = Vector.Create(this.Owner.Camera.CameraActor.K2_GetActorRotation().Vector());
			Vector vector2 = this.Positive ? this.Owner.LookAtLocation1 : this.Owner.LookAtLocation2;
			Vector vector3 = Vector.Create();
			vector2.SubtractionEqual(inB);
			double num = vector3.CosineAngle2D(vector, 9.999999747378752E-05);
			double num2 = vector3.SineAngle2D(vector, 9.999999747378752E-05);
			this.AdjustBeginRotatorYaw = (double)this.Owner.Camera.CameraRotationInGravity.Yaw;
			vector3.Rotation(this.TmpRotator);
			this.AdjustDesiredRotatorYaw = (double)CameraUtility.GetYawInGravity(this.TmpRotator);
			if (num2 < 0.0)
			{
				if (num > Math.Cos(this.Owner.CheckAdjustYawAngleMin * 0.01745329238474369))
				{
					this.AdjustDesiredRotatorYaw += this.Owner.CheckAdjustYawAngleMin;
				}
				else if (num < Math.Cos(this.Owner.CheckAdjustYawAngleMax * 0.01745329238474369))
				{
					this.AdjustDesiredRotatorYaw += this.Owner.CheckAdjustYawAngleMax;
				}
				else
				{
					this.AdjustDesiredRotatorYaw = this.AdjustBeginRotatorYaw;
				}
			}
			else if (num > Math.Cos(this.Owner.CheckAdjustYawAngleMin * 0.01745329238474369))
			{
				this.AdjustDesiredRotatorYaw -= this.Owner.CheckAdjustYawAngleMin;
			}
			else if (num < Math.Cos(this.Owner.CheckAdjustYawAngleMax * 0.01745329238474369))
			{
				this.AdjustDesiredRotatorYaw -= this.Owner.CheckAdjustYawAngleMax;
			}
			else
			{
				this.AdjustDesiredRotatorYaw = this.AdjustBeginRotatorYaw;
			}
			if (this.AdjustBeginRotatorYaw - this.AdjustDesiredRotatorYaw > 180.0)
			{
				this.AdjustDesiredRotatorYaw += 360.0;
			}
			else if (this.AdjustBeginRotatorYaw - this.AdjustDesiredRotatorYaw > 180.0)
			{
				this.AdjustDesiredRotatorYaw -= 360.0;
			}
			if (this.Owner.Camera.IsInNormalGravityMode())
			{
				this.AdjustBeginRotatorPitch = (double)this.Owner.Camera.CameraActor.K2_GetActorRotation().Pitch;
				this.AdjustDesiredRotatorPitch = Singleton<MathUtils>.Instance.RangeClamp(vector3.Z, this.Owner.DefaultPitchInRangeMin, this.Owner.DefaultPitchInRangeMax, this.Owner.DefaultPitchOutRangeMin, this.Owner.DefaultPitchOutRangeMax);
				return;
			}
			this.AdjustBeginRotatorPitch = (double)this.Owner.Camera.CameraRotationInGravity.Pitch;
			this.AdjustDesiredRotatorPitch = Singleton<MathUtils>.Instance.RangeClamp((double)CameraUtility.GetZnInGravity(vector3), this.Owner.DefaultPitchInRangeMin, this.Owner.DefaultPitchInRangeMax, this.Owner.DefaultPitchOutRangeMin, this.Owner.DefaultPitchOutRangeMax);
		}

		// Token: 0x060468CC RID: 288972 RVA: 0x012B3450 File Offset: 0x012B1650
		private void CalculateDesiredArmLength()
		{
			this.AdjustBeginArmLength = (double)this.Owner.Camera.DesiredCamera.ArmLength;
			if (this.AdjustBeginArmLength < this.Owner.ArmLengthMin)
			{
				this.AdjustDesiredArmLength = this.Owner.ArmLengthMin;
				return;
			}
			if (this.AdjustBeginArmLength > this.Owner.ArmLengthMax)
			{
				this.AdjustDesiredArmLength = this.Owner.ArmLengthMax;
				return;
			}
			this.AdjustDesiredArmLength = this.AdjustBeginArmLength;
		}

		// Token: 0x060468CD RID: 288973 RVA: 0x012B34D0 File Offset: 0x012B16D0
		private void Interpolate()
		{
			double num = (this.Owner.FadeDistance > 0.0) ? (this.MoveDistance / this.Owner.FadeDistance) : 1.0;
			num = Singleton<MathUtils>.Instance.Clamp(num, 0.0, 1.0);
			if (this.Owner.HasLookAtPoint)
			{
				double num2 = Singleton<MathUtils>.Instance.LerpSin(this.AdjustBeginRotatorYaw, this.AdjustDesiredRotatorYaw, num);
				double num3 = Singleton<MathUtils>.Instance.LerpSin(this.AdjustBeginRotatorPitch, this.AdjustDesiredRotatorPitch, num);
				if (this.Owner.Camera.IsInNormalGravityMode())
				{
					this.Owner.Camera.DesiredCamera.ArmRotation.Set((float)num3, (float)num2, 0f);
				}
				else
				{
					this.TmpRotator.Set((float)num3, (float)num2, 0f);
					CameraUtility.SetRotatorInGravity(this.Owner.Camera.DesiredCamera.ArmRotation, this.TmpRotator);
				}
				this.Owner.Camera.IsModifiedArmRotationPitch = true;
				this.Owner.Camera.IsModifiedArmRotationYaw = true;
			}
			this.Owner.Camera.DesiredCamera.ArmLength = (float)Singleton<MathUtils>.Instance.RangeClamp(num, 0.0, 1.0, this.AdjustBeginArmLength, this.AdjustDesiredArmLength);
			this.Owner.Camera.IsModifiedArmLength = true;
		}

		// Token: 0x04027B79 RID: 162681
		private double MoveDistance;

		// Token: 0x04027B7A RID: 162682
		private readonly Vector LastCharacterPosition = Vector.Create();

		// Token: 0x04027B7B RID: 162683
		private readonly Vector LookAtVector = Vector.Create();

		// Token: 0x04027B7C RID: 162684
		private double CharacterStartDistance;

		// Token: 0x04027B7D RID: 162685
		private bool Positive;

		// Token: 0x04027B7E RID: 162686
		private double AdjustBeginRotatorPitch;

		// Token: 0x04027B7F RID: 162687
		private double AdjustDesiredRotatorPitch;

		// Token: 0x04027B80 RID: 162688
		public Vector CurrentCameraArmOffset = Vector.Create();

		// Token: 0x04027B81 RID: 162689
		private readonly Vector StartCameraArmOffset = Vector.Create();

		// Token: 0x04027B82 RID: 162690
		private double AdjustBeginRotatorYaw;

		// Token: 0x04027B83 RID: 162691
		private double AdjustDesiredRotatorYaw;

		// Token: 0x04027B84 RID: 162692
		private double AdjustBeginArmLength;

		// Token: 0x04027B85 RID: 162693
		private double AdjustDesiredArmLength;

		// Token: 0x04027B86 RID: 162694
		private readonly Rotator TmpRotator = Rotator.Create();
	}
}
