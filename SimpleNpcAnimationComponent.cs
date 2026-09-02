using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x0200320D RID: 12813
[NullableContext(1)]
[Nullable(0)]
public class SimpleNpcAnimationComponent : BaseAnimationComponent, IComponentDependency
{
	// Token: 0x17002402 RID: 9218
	// (get) Token: 0x0601A9C9 RID: 109001 RVA: 0x007E53EC File Offset: 0x007E35EC
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(SimpleNpcActorComponent),
				typeof(CreatureDataComponent)
			};
		}
	}

	// Token: 0x17002403 RID: 9219
	// (get) Token: 0x0601A9CA RID: 109002 RVA: 0x007E540E File Offset: 0x007E360E
	[Nullable(2)]
	protected new SimpleNpcActorComponent ActorComp
	{
		[NullableContext(2)]
		get
		{
			return this.ActorComp as SimpleNpcActorComponent;
		}
	}

	// Token: 0x0601A9CB RID: 109003 RVA: 0x007E541C File Offset: 0x007E361C
	private void ResetTemporaryHidden()
	{
		if (this.HiddenCount > 0)
		{
			this.HiddenCount--;
			return;
		}
		if (this.HiddenCount == 0)
		{
			this.ActorComp.EnableActor(this.TemporaryHiddenHandle.Value);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "人物上场隐藏一帧 【隐藏结束】";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity:", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.TemporaryHiddenHandle = null;
			this.ActorComp.Actor.Mesh.VisibilityBasedAnimTickOption = this.DefaultVisibilityBasedAnimTickOption;
			this.HiddenCount = -1;
		}
	}

	// Token: 0x0601A9CC RID: 109004 RVA: 0x007E54C4 File Offset: 0x007E36C4
	protected override bool OnInit()
	{
		base.OnInit();
		this.SlopeStepPeriodicCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/BaseCharacter/Curves/CharacterMovementCurves/AngleToStepFrequency.AngleToStepFrequency");
		this.SlopeStepSizeCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/BaseCharacter/Curves/CharacterMovementCurves/AngleToStepLength.AngleToStepLength");
		if (this.SlopeStepPeriodicCurve == null || this.SlopeStepSizeCurve == null)
		{
			return false;
		}
		float 注释时的抬升角度 = base.Entity.GetComponent<CreatureDataComponent>().GetModelConfig().注释时的抬升角度;
		if (注释时的抬升角度 != 0f)
		{
			this.SightFixQuat = Quat.Create(0f, 0f, 0f, 1f);
			Quat.FindBetween(Vector.ForwardVectorProxy, Vector.Create((double)MathF.Cos(注释时的抬升角度 * 0.017453292f), 0.0, (double)MathF.Sin(注释时的抬升角度 * 0.017453292f)), this.SightFixQuat);
		}
		return true;
	}

	// Token: 0x0601A9CD RID: 109005 RVA: 0x007E558C File Offset: 0x007E378C
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.CheckGetComponent<SimpleNpcActorComponent>();
		TsBaseCharacter actor = this.ActorComp.Actor;
		if (((actor != null) ? actor.Mesh : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "模型仍未初始化";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		base.Actor = this.ActorComp.Actor;
		this.Mesh = base.Actor.Mesh;
		this.GetAnimInstanceFromMesh();
		if (this.MainAnimInstanceInternal == null)
		{
			return false;
		}
		this.InitBaseInfo();
		base.CheckNpcAnimationAssets();
		return true;
	}

	// Token: 0x0601A9CE RID: 109006 RVA: 0x007E5639 File Offset: 0x007E3839
	protected override void InitBaseInfo()
	{
		this.SightDirect.DeepCopy(Vector.RightVectorProxy);
		this.SightDirect2.DeepCopy(Vector.RightVectorProxy);
		this.IsPlayer = false;
		this.DefaultVisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.OnlyTickPoseWhenRendered;
		this.SetAnimParams(true);
	}

	// Token: 0x0601A9CF RID: 109007 RVA: 0x007E5670 File Offset: 0x007E3870
	protected override void OnActivate()
	{
		base.StartAnimInstance();
	}

	// Token: 0x0601A9D0 RID: 109008 RVA: 0x007E5678 File Offset: 0x007E3878
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		this.ResetTemporaryHidden();
		this.UpdateHeadRotation(delta);
	}

	// Token: 0x0601A9D1 RID: 109009 RVA: 0x007E5690 File Offset: 0x007E3890
	protected override void OnDisable(string reason)
	{
		if (this.HiddenCount >= 0)
		{
			this.ActorComp.EnableActor(this.TemporaryHiddenHandle.Value);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "人物上场隐藏一帧 【组件Disable 隐藏结束】";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity:", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.HiddenCount = -1;
		CommonNpcPerformComponent component = base.Entity.GetComponent<CommonNpcPerformComponent>();
		if (component != null && component.AnyIdleLoopMontagePlaying)
		{
			return;
		}
		UAnimInstance mainAnimInstanceInternal = this.MainAnimInstanceInternal;
		if (mainAnimInstanceInternal != null && mainAnimInstanceInternal.IsValid())
		{
			base.MontageManager.StopMontage(new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0f)
			});
			UKuroAnimLibrary.EndAnimNotifyStates(this.MainAnimInstanceInternal);
		}
	}

	// Token: 0x0601A9D2 RID: 109010 RVA: 0x007E5760 File Offset: 0x007E3960
	private void UpdateHeadRotation(float delta)
	{
		if (!this.EnableSightDirectInternal)
		{
			return;
		}
		if (this.SightTargetItemId != 0 || this.SightTargetPoint != null)
		{
			this.UpdateSightTargetRotation(this.TmpTargetSight);
		}
		else
		{
			this.TmpTargetSight.DeepCopy(this.ActorComp.ActorForwardProxy);
		}
		this.LerpSightDirect(delta);
	}

	// Token: 0x0601A9D3 RID: 109011 RVA: 0x007E57B4 File Offset: 0x007E39B4
	private unsafe void LerpSightDirect(float delta)
	{
		this.TmpDirect.FromUeVector(this.TmpTargetSight);
		this.TmpQuat.FromUeQuat(this.Mesh.K2_GetComponentQuaternion());
		this.TmpQuat.Inverse(this.TmpQuat);
		this.TmpDirect2.FromUeVector(this.TmpTargetSight);
		this.TmpQuat.RotateVector(this.TmpTargetSight, this.TmpTargetSight);
		base.ClampSightDirect(this.TmpTargetSight, this.TmpTargetSight);
		if (this.SightDirectIsEqual && this.TmpTargetSight.Equals(this.SightDirect, 9.999999747378752E-05))
		{
			return;
		}
		BaseAnimationComponent.LerpDirect2dByMaxAngle(this.SightDirect2, this.TmpTargetSight, delta * 0.36f, this.SightDirect2, false);
		BaseAnimationComponent.LerpVector2dByAlpha(this.SightDirect, this.SightDirect2, 1f - MathF.Pow(0.04f, delta * 0.001f), this.SightDirect, false);
		this.SightDirectIsEqual = this.SightDirect.Equals(this.SightDirect2, 9.999999747378752E-05);
		if (this.SightDirect.ContainsNaN())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "UpdateHeadRotation Contains Nan.";
			<>y__InlineArray9<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray9<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BeforeRotate", this.TmpDirect);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BeforeClamp", this.TmpDirect2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetDirect", this.TmpTargetSight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("SightDirect", this.SightDirect);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("SightDirect2", this.SightDirect2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("quatInverse", this.TmpQuat);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("IsPlayer", this.IsPlayer);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("CanResponseInput", false);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("Delta", delta);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 9));
			this.SightDirect.Set(0.0, 1.0, 0.0);
			this.SightDirect2.Set(0.0, 1.0, 0.0);
		}
	}

	// Token: 0x0601A9D4 RID: 109012 RVA: 0x007E5A50 File Offset: 0x007E3C50
	private void UpdateSightTargetRotation(Vector @out)
	{
		BaseActorComponent sightTargetItem = base.GetSightTargetItem();
		if (sightTargetItem == null)
		{
			@out.DeepCopy(this.ActorComp.ActorForwardProxy);
			return;
		}
		(this.SightTargetPoint ?? sightTargetItem.ActorLocationProxy).Subtraction(this.ActorComp.ActorLocationProxy, this.TmpDirect);
		BaseCharacterComponent baseCharacterComponent = sightTargetItem as BaseCharacterComponent;
		if (baseCharacterComponent != null)
		{
			this.TmpDirect.Z += (double)(baseCharacterComponent.ScaledHalfHeight - this.ActorComp.ScaledHalfHeight);
		}
		else
		{
			this.TmpDirect.Z -= (double)this.ActorComp.ScaledHalfHeight;
		}
		if (this.TmpDirect.IsNearlyZero(9.999999747378752E-05))
		{
			@out.DeepCopy(this.ActorComp.ActorForwardProxy);
			return;
		}
		@out.DeepCopy(this.TmpDirect);
		this.SightFix(@out);
	}

	// Token: 0x0601A9D5 RID: 109013 RVA: 0x007E5B2C File Offset: 0x007E3D2C
	private void SightFix(Vector sightDirect)
	{
		if (this.SightFixQuat == null)
		{
			return;
		}
		this.ActorComp.ActorQuatProxy.Inverse(this.TmpQuat);
		this.TmpQuat.RotateVector(sightDirect, sightDirect);
		this.SightFixQuat.RotateVector(sightDirect, sightDirect);
		this.ActorComp.ActorQuatProxy.RotateVector(sightDirect, sightDirect);
	}

	// Token: 0x0601A9D6 RID: 109014 RVA: 0x007E5B84 File Offset: 0x007E3D84
	private void SetAnimParams(bool bUseDistanceMap = true)
	{
		bool flag = Singleton<Info>.Instance.IsMobilePlatform();
		FAnimUpdateRateParameters fanimUpdateRateParameters = new FAnimUpdateRateParameters();
		int num = this.Mesh.LODInfo.Num();
		if (bUseDistanceMap)
		{
			fanimUpdateRateParameters.bShouldUseDistanceMap = true;
			fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Empty(true);
			fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 50 : 800));
			fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 200 : 1500));
			fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 500 : 4000));
			fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 1500 : 5000));
			fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 2500 : 8000));
		}
		else
		{
			fanimUpdateRateParameters.bShouldUseLodMap = true;
			fanimUpdateRateParameters.LODToFrameSkipMap.Empty(0);
			for (int i = 0; i < num; i++)
			{
				fanimUpdateRateParameters.LODToFrameSkipMap.Add(i, (i < 2) ? 0 : (i - 1));
			}
		}
		fanimUpdateRateParameters.BaseNonRenderedUpdateRate = 8;
		fanimUpdateRateParameters.MaxEvalRateForInterpolation = 8;
		FAnimUpdateRateParameters fanimUpdateRateParameters2 = new FAnimUpdateRateParameters();
		TArray<UActorComponent> tarray = base.Actor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		for (int j = 0; j < tarray.Num(); j++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(j) as USkeletalMeshComponent;
			uskeletalMeshComponent.bEnableUpdateRateOptimizations = true;
			uskeletalMeshComponent.SetAnimUpdateRateParameters(ref fanimUpdateRateParameters2);
			uskeletalMeshComponent.VisibilityBasedAnimTickOption = this.DefaultVisibilityBasedAnimTickOption;
		}
	}

	// Token: 0x0601A9D7 RID: 109015 RVA: 0x007E5CF8 File Offset: 0x007E3EF8
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		SimpleNpcAnimationComponent simpleNpcAnimationComponent = (SimpleNpcAnimationComponent)componentTemplate;
		if (base.CanResetComponentProperty("SlopeStepPeriodicCurve"))
		{
			if (simpleNpcAnimationComponent.SlopeStepPeriodicCurve == null)
			{
				this.SlopeStepPeriodicCurve = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.SlopeStepPeriodicCurve), "SlopeStepPeriodicCurve"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SlopeStepSizeCurve"))
		{
			if (simpleNpcAnimationComponent.SlopeStepSizeCurve == null)
			{
				this.SlopeStepSizeCurve = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.SlopeStepSizeCurve), "SlopeStepSizeCurve"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpTargetSight") && simpleNpcAnimationComponent.TmpTargetSight != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpTargetSight), "TmpTargetSight"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SightFixQuat"))
		{
			if (simpleNpcAnimationComponent.SightFixQuat == null)
			{
				this.SightFixQuat = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.SightFixQuat), "SightFixQuat"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpQuat") && simpleNpcAnimationComponent.TmpQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat), "TmpQuat"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpDirect") && simpleNpcAnimationComponent.TmpDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpDirect), "TmpDirect"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpDirect2") && simpleNpcAnimationComponent.TmpDirect2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpDirect2), "TmpDirect2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TemporaryHiddenHandle"))
		{
			this.TemporaryHiddenHandle = simpleNpcAnimationComponent.TemporaryHiddenHandle;
		}
		if (base.CanResetComponentProperty("HiddenCount"))
		{
			this.HiddenCount = simpleNpcAnimationComponent.HiddenCount;
		}
		return true;
	}

	// Token: 0x0400D773 RID: 55155
	[Nullable(2)]
	protected UCurveFloat SlopeStepPeriodicCurve;

	// Token: 0x0400D774 RID: 55156
	[Nullable(2)]
	protected UCurveFloat SlopeStepSizeCurve;

	// Token: 0x0400D775 RID: 55157
	private readonly Vector TmpTargetSight = Vector.Create();

	// Token: 0x0400D776 RID: 55158
	[Nullable(2)]
	private Quat SightFixQuat;

	// Token: 0x0400D777 RID: 55159
	private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400D778 RID: 55160
	private readonly Vector TmpDirect = Vector.Create();

	// Token: 0x0400D779 RID: 55161
	private readonly Vector TmpDirect2 = Vector.Create();

	// Token: 0x0400D77A RID: 55162
	private int? TemporaryHiddenHandle = new int?(0);

	// Token: 0x0400D77B RID: 55163
	private int HiddenCount = -1;

	// Token: 0x0400D77C RID: 55164
	private const float TURN_SPEED = 0.36f;

	// Token: 0x0400D77D RID: 55165
	private const float TURN_RATIO = 0.04f;
}
