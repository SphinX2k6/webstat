using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02000E11 RID: 3601
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraGravityController : CameraControllerBase<EFightCameraGravity>, ICanGetConfigMapValue, IStaticVariableResetter
{
	// Token: 0x060054FB RID: 21755 RVA: 0x000D7533 File Offset: 0x000D5733
	public CameraGravityController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x060054FC RID: 21756 RVA: 0x000D7568 File Offset: 0x000D5768
	static CameraGravityController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CameraGravityController.CreateStaticDefaultValue), new Action(CameraGravityController.ResetStaticDefaultValue));
	}

	// Token: 0x060054FD RID: 21757 RVA: 0x000D7616 File Offset: 0x000D5816
	public override string Name()
	{
		return "GravityController";
	}

	// Token: 0x060054FE RID: 21758 RVA: 0x000D761D File Offset: 0x000D581D
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraGravity.开启过渡到指定重力方向, "EnableGravityLerp");
		base.SetConfigMap(EFightCameraGravity.过渡角速度, "GravityLerpAngleVelocity");
	}

	// Token: 0x060054FF RID: 21759 RVA: 0x000D7637 File Offset: 0x000D5837
	public override void PostProcessConfig(Dictionary<EFightCameraGravity, float> config, Dictionary<EFightCameraGravity, CurveBase> curveConfig)
	{
		base.PostProcessConfig(config, curveConfig);
		this.RefreshDefaultCameraGravityLerpConfig();
	}

	// Token: 0x06005500 RID: 21760 RVA: 0x000D7647 File Offset: 0x000D5847
	protected override bool UpdateCustomEnableCondition()
	{
		BaseCameraGravityLerpExecutor baseCameraGravityLerpExecutor = this.BaseCameraGravityLerpExecutor;
		return baseCameraGravityLerpExecutor != null && baseCameraGravityLerpExecutor.EnableUpdate();
	}

	// Token: 0x06005501 RID: 21761 RVA: 0x000D765A File Offset: 0x000D585A
	protected override void UpdateInternal(float deltaTime)
	{
		BaseCameraGravityLerpExecutor baseCameraGravityLerpExecutor = this.BaseCameraGravityLerpExecutor;
		if (baseCameraGravityLerpExecutor != null)
		{
			baseCameraGravityLerpExecutor.Update(deltaTime);
		}
		BaseCameraGravityLerpExecutor baseCameraGravityLerpExecutor2 = this.BaseCameraGravityLerpExecutor;
		if (baseCameraGravityLerpExecutor2 != null && baseCameraGravityLerpExecutor2.IsFinished && this.OverrideCameraGravityLerpConfig != null)
		{
			this.OverrideCameraGravityLerpConfig = null;
		}
	}

	// Token: 0x06005502 RID: 21762 RVA: 0x000D7691 File Offset: 0x000D5891
	public void DrawCameraGravityDebugArrow(Vector direction, FLinearColor color)
	{
	}

	// Token: 0x06005503 RID: 21763 RVA: 0x000D7693 File Offset: 0x000D5893
	public void DrawCameraGravityDebugLine(Vector direction, FLinearColor color)
	{
	}

	// Token: 0x06005504 RID: 21764 RVA: 0x000D7698 File Offset: 0x000D5898
	private void RefreshDefaultCameraGravityLerpConfig()
	{
		this.DefaultCameraGravityLerpConfig.LerpTime = 0f;
		this.DefaultCameraGravityLerpConfig.LerpTimeCurve = null;
		this.DefaultCameraGravityLerpConfig.LerpAngleWhenFinish = false;
		float lerpAngleVelocity = Math.Max(this.GravityLerpAngleVelocity, 0f);
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)this.EnableGravityLerp, null))
		{
			this.DefaultCameraGravityLerpConfig.LerpMode = ECameraGravityLerpMode.AngleVelocity;
			this.DefaultCameraGravityLerpConfig.LerpAngleVelocity = lerpAngleVelocity;
		}
		else
		{
			this.DefaultCameraGravityLerpConfig.LerpMode = ECameraGravityLerpMode.None;
			this.DefaultCameraGravityLerpConfig.LerpAngleVelocity = 0f;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[CameraGravity]刷新默认的重力方向插值配置";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DefaultCameraGravityLerpConfig", this.DefaultCameraGravityLerpConfig.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06005505 RID: 21765 RVA: 0x000D7764 File Offset: 0x000D5964
	private void SetOverrideCameraGravityLerpConfig(CameraGravityConfig config)
	{
		if (this.OverrideCameraGravityLerpConfig == null)
		{
			this.OverrideCameraGravityLerpConfig = new CameraGravityLerpConfig();
		}
		this.OverrideCameraGravityLerpConfig.LerpMode = config.LerpMode;
		this.OverrideCameraGravityLerpConfig.LerpTime = config.LerpTime;
		this.OverrideCameraGravityLerpConfig.LerpTimeCurve = config.LerpTimeCurve;
		this.OverrideCameraGravityLerpConfig.LerpAngleVelocity = config.LerpAngleVelocity;
		this.OverrideCameraGravityLerpConfig.LerpAngleWhenFinish = config.LerpAngleWhenFinish;
	}

	// Token: 0x06005506 RID: 21766 RVA: 0x000D77D9 File Offset: 0x000D59D9
	private void SetCameraGravityDirConfig(CameraGravityConfig config)
	{
		this.CameraGravityDirConfig.GravityMode = config.GravityMode;
		this.CameraGravityDirConfig.TargetGravity.DeepCopy(config.TargetGravity);
		this.RebuildBaseCameraGravity();
		this.RebuildBaseCameraGravityLerpExecutor();
	}

	// Token: 0x06005507 RID: 21767 RVA: 0x000D7810 File Offset: 0x000D5A10
	private void RebuildBaseCameraGravity()
	{
		Type type;
		if (!CameraGravityController.ECameraGravityMap.TryGetValue(this.GetCurrentCameraGravityMode(), out type))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraGravity]未找到对应的GravityMode";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("config.GravityMode", this.GetCurrentCameraGravityMode());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.BaseCameraGravity = (BaseCameraGravity)Activator.CreateInstance(type);
		this.BaseCameraGravity.Init(this, this.CameraGravityDirConfig);
	}

	// Token: 0x06005508 RID: 21768 RVA: 0x000D7888 File Offset: 0x000D5A88
	private void RebuildBaseCameraGravityLerpExecutor()
	{
		CameraGravityLerpConfig cameraGravityLerpConfig = this.OverrideCameraGravityLerpConfig ?? this.DefaultCameraGravityLerpConfig;
		Type type;
		if (!CameraGravityController.ECameraGravityLerpExecutorMap.TryGetValue(cameraGravityLerpConfig.LerpMode, out type))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraGravity]未找到对应的LerpMode";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activeLerpConfig.LerpMode", cameraGravityLerpConfig.LerpMode);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.BaseCameraGravityLerpExecutor = (BaseCameraGravityLerpExecutor)Activator.CreateInstance(type);
		this.BaseCameraGravityLerpExecutor.Init(this, cameraGravityLerpConfig);
	}

	// Token: 0x06005509 RID: 21769 RVA: 0x000D790A File Offset: 0x000D5B0A
	public ECameraGravityMode GetCurrentCameraGravityMode()
	{
		return this.CameraGravityDirConfig.GravityMode;
	}

	// Token: 0x0600550A RID: 21770 RVA: 0x000D7917 File Offset: 0x000D5B17
	public Vector GetGravityStartLerpVector()
	{
		BaseCameraGravity baseCameraGravity = this.BaseCameraGravity;
		return ((baseCameraGravity != null) ? baseCameraGravity.GravityStartLerpVector() : null) ?? Vector.DownVectorProxy;
	}

	// Token: 0x0600550B RID: 21771 RVA: 0x000D7934 File Offset: 0x000D5B34
	public Vector GetGravityEndLerpVector()
	{
		BaseCameraGravity baseCameraGravity = this.BaseCameraGravity;
		return ((baseCameraGravity != null) ? baseCameraGravity.GravityEndLerpVector() : null) ?? Vector.DownVectorProxy;
	}

	// Token: 0x0600550C RID: 21772 RVA: 0x000D7951 File Offset: 0x000D5B51
	public Vector GetGravityDirectForActor()
	{
		GravityUtils instance = Singleton<GravityUtils>.Instance;
		TsBaseCharacter character = this.Camera.Character;
		return instance.GetGravityDirectForActor((character != null) ? character.CharacterActorComponent : null);
	}

	// Token: 0x0600550D RID: 21773 RVA: 0x000D7974 File Offset: 0x000D5B74
	public Vector GetCurrentCameraGravityDirect()
	{
		return this.Camera.GravityDirect;
	}

	// Token: 0x0600550E RID: 21774 RVA: 0x000D7984 File Offset: 0x000D5B84
	public void SetCurrentCameraGravityMode(ECameraGravityMode cameraGravityMode)
	{
		this.Camera.GravityMode = cameraGravityMode;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[CameraGravity]InternalSetCameraGravityMode";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.CameraGravityMode", cameraGravityMode);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600550F RID: 21775 RVA: 0x000D79CC File Offset: 0x000D5BCC
	[NullableContext(2)]
	public void SetCameraGravityMode(ECameraGravityMode cameraGravityMode, Vector gravityDirect = null)
	{
		if (gravityDirect == null)
		{
			gravityDirect = Vector.DownVectorProxy;
		}
		if (!gravityDirect.IsNormalized())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraGravity]设置相机重力方向失败，因为不是归一化的向量";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("gravityDirect", gravityDirect);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		CameraGravityController.TempCameraGravityConfig.Reset();
		if (cameraGravityMode == ECameraGravityMode.None)
		{
			CameraGravityController.TempCameraGravityConfig.GravityMode = ECameraGravityMode.None;
			CameraGravityController.TempCameraGravityConfig.LerpMode = ECameraGravityLerpMode.Time;
			CameraGravityController.TempCameraGravityConfig.LerpTime = 0f;
		}
		else if (cameraGravityMode == ECameraGravityMode.FixedGravityDirect)
		{
			CameraGravityController.TempCameraGravityConfig.GravityMode = ECameraGravityMode.FixedGravityDirect;
			CameraGravityController.TempCameraGravityConfig.LerpMode = ECameraGravityLerpMode.Time;
			CameraGravityController.TempCameraGravityConfig.TargetGravity.DeepCopy(gravityDirect);
			CameraGravityController.TempCameraGravityConfig.LerpTime = 0f;
		}
		else if (cameraGravityMode == ECameraGravityMode.CameraTargetGravityDirect)
		{
			CameraGravityController.TempCameraGravityConfig.GravityMode = ECameraGravityMode.CameraTargetGravityDirect;
			CameraGravityController.TempCameraGravityConfig.LerpMode = ECameraGravityLerpMode.Time;
			CameraGravityController.TempCameraGravityConfig.LerpTime = 0f;
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[CameraGravity]设置相机重力模式失败，因为传入了未知的重力模式, 回退到默认的CameraTargetGravityDirect模式";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("cameraGravityMode", cameraGravityMode);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		this.SetCameraGravityModeByConfig(CameraGravityController.TempCameraGravityConfig);
		Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraGravity]SetCameraGravityMode", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06005510 RID: 21776 RVA: 0x000D7B03 File Offset: 0x000D5D03
	public void SetCameraGravityModeByUeConfig(SCamera_ChangeGravity config)
	{
		CameraGravityController.TempCameraGravityConfig.SetConfig(config);
		this.SetOverrideCameraGravityLerpConfig(CameraGravityController.TempCameraGravityConfig);
		this.SetCameraGravityDirConfig(CameraGravityController.TempCameraGravityConfig);
	}

	// Token: 0x06005511 RID: 21777 RVA: 0x000D7B26 File Offset: 0x000D5D26
	public void SetCameraGravityModeByConfig(CameraGravityConfig config)
	{
		this.SetOverrideCameraGravityLerpConfig(config);
		this.SetCameraGravityDirConfig(config);
	}

	// Token: 0x06005512 RID: 21778 RVA: 0x000D7B38 File Offset: 0x000D5D38
	public void UpdateCharacterGravity()
	{
		if (this.Camera.GravityMode != ECameraGravityMode.CameraTargetGravityDirect)
		{
			return;
		}
		if (this.BaseCameraGravityLerpExecutor != null && this.BaseCameraGravityLerpExecutor.EnableUpdate())
		{
			return;
		}
		this.RebuildBaseCameraGravityLerpExecutor();
		Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraGravity]CharGravityDirectChanged", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06005513 RID: 21779 RVA: 0x000D7B8C File Offset: 0x000D5D8C
	public bool IsInNormalGravityMode()
	{
		return this.Camera.GravityMode == ECameraGravityMode.None || Singleton<MathUtils>.Instance.IsNearlyEqual(this.Camera.GravityDirect.Z, -1.0, new double?((double)1E-08f));
	}

	// Token: 0x06005514 RID: 21780 RVA: 0x000D7BCB File Offset: 0x000D5DCB
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06005515 RID: 21781 RVA: 0x000D7BCD File Offset: 0x000D5DCD
	public static void ResetStaticDefaultValue()
	{
	}

	// Token: 0x06005516 RID: 21782 RVA: 0x000D7BD0 File Offset: 0x000D5DD0
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			int length = key.Length;
			if (length <= 18)
			{
				if (length != 12)
				{
					if (length != 17)
					{
						if (length == 18)
						{
							if (key == "DebugLineDirection")
							{
								value = this.DebugLineDirection;
								return true;
							}
						}
					}
					else
					{
						char c = key[0];
						if (c != 'B')
						{
							if (c == 'E')
							{
								if (key == "EnableGravityLerp")
								{
									value = this.EnableGravityLerp;
									return true;
								}
							}
						}
						else if (key == "BaseCameraGravity")
						{
							value = this.BaseCameraGravity;
							return true;
						}
					}
				}
				else if (key == "DebugLineEnd")
				{
					value = this.DebugLineEnd;
					return true;
				}
			}
			else if (length != 22)
			{
				if (length != 24)
				{
					switch (length)
					{
					case 29:
						if (key == "BaseCameraGravityLerpExecutor")
						{
							value = this.BaseCameraGravityLerpExecutor;
							return true;
						}
						break;
					case 30:
						if (key == "DefaultCameraGravityLerpConfig")
						{
							value = this.DefaultCameraGravityLerpConfig;
							return true;
						}
						break;
					case 31:
						if (key == "OverrideCameraGravityLerpConfig")
						{
							value = this.OverrideCameraGravityLerpConfig;
							return true;
						}
						break;
					}
				}
				else if (key == "GravityLerpAngleVelocity")
				{
					value = this.GravityLerpAngleVelocity;
					return true;
				}
			}
			else if (key == "CameraGravityDirConfig")
			{
				value = this.CameraGravityDirConfig;
				return true;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x06005517 RID: 21783 RVA: 0x000D7D54 File Offset: 0x000D5F54
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key == "EnableGravityLerp")
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
			this.EnableGravityLerp = num2;
			return;
		}
		if (key == "GravityLerpAngleVelocity")
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
			this.GravityLerpAngleVelocity = num2;
			return;
		}
		if (key == "OverrideCameraGravityLerpConfig")
		{
			this.OverrideCameraGravityLerpConfig = (CameraGravityLerpConfig)value;
			return;
		}
		if (key == "BaseCameraGravityLerpExecutor")
		{
			this.BaseCameraGravityLerpExecutor = (BaseCameraGravityLerpExecutor)value;
			return;
		}
		if (!(key == "BaseCameraGravity"))
		{
			base.SetMember(key, value);
			return;
		}
		this.BaseCameraGravity = (BaseCameraGravity)value;
	}

	// Token: 0x06005518 RID: 21784 RVA: 0x000D7EC4 File Offset: 0x000D60C4
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraGravityController.<MemberIter>d__44 <MemberIter>d__ = new CameraGravityController.<MemberIter>d__44(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001A17 RID: 6679
	[StaticVariableRuleIgnore]
	public static CameraGravityConfig TempCameraGravityConfig = new CameraGravityConfig();

	// Token: 0x04001A18 RID: 6680
	public float EnableGravityLerp;

	// Token: 0x04001A19 RID: 6681
	public float GravityLerpAngleVelocity;

	// Token: 0x04001A1A RID: 6682
	private readonly CameraGravityLerpConfig DefaultCameraGravityLerpConfig = new CameraGravityLerpConfig();

	// Token: 0x04001A1B RID: 6683
	[Nullable(2)]
	private CameraGravityLerpConfig OverrideCameraGravityLerpConfig;

	// Token: 0x04001A1C RID: 6684
	[Nullable(2)]
	private BaseCameraGravityLerpExecutor BaseCameraGravityLerpExecutor;

	// Token: 0x04001A1D RID: 6685
	private readonly CameraGravityDirectionConfig CameraGravityDirConfig = new CameraGravityDirectionConfig();

	// Token: 0x04001A1E RID: 6686
	[Nullable(2)]
	private BaseCameraGravity BaseCameraGravity;

	// Token: 0x04001A1F RID: 6687
	private readonly Vector DebugLineDirection = Vector.Create();

	// Token: 0x04001A20 RID: 6688
	private readonly Vector DebugLineEnd = Vector.Create();

	// Token: 0x04001A21 RID: 6689
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<ECameraGravityLerpMode, Type> ECameraGravityLerpExecutorMap = new Dictionary<ECameraGravityLerpMode, Type>
	{
		{
			ECameraGravityLerpMode.None,
			typeof(CameraGravityLerpByImmediatelySetExecutor)
		},
		{
			ECameraGravityLerpMode.Time,
			typeof(CameraGravityLerpByTimeExecutor)
		},
		{
			ECameraGravityLerpMode.AngleVelocity,
			typeof(CameraGravityLerpByAngleExecutor)
		}
	};

	// Token: 0x04001A22 RID: 6690
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<ECameraGravityMode, Type> ECameraGravityMap = new Dictionary<ECameraGravityMode, Type>
	{
		{
			ECameraGravityMode.None,
			typeof(DefaultCameraGravity)
		},
		{
			ECameraGravityMode.FixedGravityDirect,
			typeof(FixedCameraGravity)
		},
		{
			ECameraGravityMode.CameraTargetGravityDirect,
			typeof(TargetCameraGravity)
		}
	};

	// Token: 0x04001A23 RID: 6691
	private const float CAMERA_GRAVITY_DEBUG_LINE_LENGTH = 1800f;

	// Token: 0x04001A24 RID: 6692
	private const float CAMERA_GRAVITY_DEBUG_LINE_SIZE = 6f;

	// Token: 0x04001A25 RID: 6693
	private const float CAMERA_GRAVITY_DEBUG_GRAVITY_FORWARD_ARROW_SIZE = 300f;
}
