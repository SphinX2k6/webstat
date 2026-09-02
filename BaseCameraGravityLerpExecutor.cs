using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E19 RID: 3609
[NullableContext(1)]
[Nullable(0)]
public class BaseCameraGravityLerpExecutor : IStaticVariableResetter
{
	// Token: 0x06005533 RID: 21811 RVA: 0x000D8302 File Offset: 0x000D6502
	static BaseCameraGravityLerpExecutor()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseCameraGravityLerpExecutor.CreateStaticDefaultValue), new Action(BaseCameraGravityLerpExecutor.ResetStaticDefaultValue));
	}

	// Token: 0x06005534 RID: 21812 RVA: 0x000D8324 File Offset: 0x000D6524
	public unsafe void Init(CameraGravityController owner, CameraGravityLerpConfig lerpConfig)
	{
		this.Owner = owner;
		this.LerpConfig.DeepCopy(lerpConfig);
		this.IsFinished = false;
		this.HasFlatAngleGravityQuatAxis = false;
		this.HasStableModelBufferAxis = false;
		this.FlatAngleGravityQuatAxis.DeepCopy(Vector.RightVectorProxy);
		this.FlatAngleGravityQuatSign = 1f;
		if (BaseCameraGravityLerpExecutor.Debug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraGravity]插值设置重力方向[开始]";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("config", this.LerpConfig.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GravityDirect", this.Owner.GetCurrentCameraGravityDirect().ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlatAngleGravityQuatSign", this.FlatAngleGravityQuatSign);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		this.InitInternal();
	}

	// Token: 0x06005535 RID: 21813 RVA: 0x000D8412 File Offset: 0x000D6612
	public void Update(float deltaTime)
	{
		if (!this.EnableUpdate())
		{
			return;
		}
		float num = this.UpdateInternal(deltaTime);
		this.DrawDebugInfo();
		if (num >= 1f)
		{
			this.Finish();
		}
	}

	// Token: 0x06005536 RID: 21814 RVA: 0x000D8437 File Offset: 0x000D6637
	public bool EnableUpdate()
	{
		return !this.IsFinished;
	}

	// Token: 0x06005537 RID: 21815 RVA: 0x000D8444 File Offset: 0x000D6644
	private void DrawDebugInfo()
	{
		if (!BaseCameraGravityLerpExecutor.Debug)
		{
			return;
		}
		this.Owner.DrawCameraGravityDebugLine(this.FlatAngleGravityQuatAxis, CameraGravityLerpDebugColors.Yellow);
		this.Owner.DrawCameraGravityDebugLine(this.Owner.GetGravityStartLerpVector(), CameraGravityLerpDebugColors.Red);
		this.Owner.DrawCameraGravityDebugLine(this.Owner.GetGravityEndLerpVector(), CameraGravityLerpDebugColors.White);
		this.Owner.DrawCameraGravityDebugArrow(this.Owner.Camera.GravityUp, CameraGravityLerpDebugColors.Pink);
		this.Owner.DrawCameraGravityDebugArrow(Vector.UpVectorProxy, CameraGravityLerpDebugColors.Orange);
	}

	// Token: 0x06005538 RID: 21816 RVA: 0x000D84DC File Offset: 0x000D66DC
	private void DrawGravityQuatDebugInfo(FLinearColor gravityForwardColor)
	{
		if (!BaseCameraGravityLerpExecutor.Debug)
		{
			return;
		}
		this.TempQuat.RotateVector(Vector.ForwardVectorProxy, this.TempVector5);
		this.Owner.DrawCameraGravityDebugArrow(this.TempVector5, gravityForwardColor);
		this.TempVector6.Set((double)this.TempQuat.X, (double)this.TempQuat.Y, (double)this.TempQuat.Z);
		if (this.TempQuat.W < 0f)
		{
			this.TempVector6.MultiplyEqual(-1.0);
		}
		this.Owner.DrawCameraGravityDebugArrow(this.TempVector6, CameraGravityLerpDebugColors.Magenta);
	}

	// Token: 0x06005539 RID: 21817 RVA: 0x000D8588 File Offset: 0x000D6788
	protected unsafe void InternalSetCameraGravityDirect(Vector gravityDirect, Vector flatAngleAxis, float flatAngleSign = 1f)
	{
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
		FightCameraLogicComponent camera = this.Owner.Camera;
		camera.GravityDirect.DeepCopy(gravityDirect);
		camera.GravityDirect.UnaryNegation(camera.GravityUp);
		if (this.Owner.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["功能.通用镜头.锁定镜头重力空间方向"], false))
		{
			if (Math.Abs(camera.GravityUp.DotProduct(Vector.ForwardVectorProxy)) < 0.9999)
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(Vector.ForwardVectorProxy, camera.GravityUp, this.TempQuat);
			}
			else
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(Vector.UpVectorProxy, camera.GravityUp, this.TempQuat);
			}
			this.DrawGravityQuatDebugInfo(CameraGravityLerpDebugColors.Green);
		}
		else if (!this.IsNearOppositeGravityVector(Vector.UpVectorProxy, camera.GravityUp))
		{
			Quat.FindBetween(Vector.UpVectorProxy, camera.GravityUp, this.TempQuat);
			this.DrawGravityQuatDebugInfo(CameraGravityLerpDebugColors.Green);
		}
		else
		{
			Quat.ConstructorByAxisAngle(flatAngleAxis, (float)(3.141592653589793 * (double)flatAngleSign), this.TempQuat);
			this.DrawGravityQuatDebugInfo(CameraGravityLerpDebugColors.Blue);
		}
		camera.GravityQuat.DeepCopy(this.TempQuat);
		camera.GravityQuat.Inverse(camera.GravityInverseQuat);
		if (BaseCameraGravityLerpExecutor.Debug)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[CameraGravity]SetCameraGravityMode";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CameraGravityDirect", camera.GravityDirect);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GravityQuaternion", camera.GravityQuat);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("flatAngleAxis", flatAngleAxis);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Rotation", camera.GravityQuat.Rotator(null));
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x0600553A RID: 21818 RVA: 0x000D8794 File Offset: 0x000D6994
	protected bool SqLerpGravityVector(Vector from, Vector to, float alpha, Vector @out)
	{
		Vector tempVector = this.TempVector4;
		this.Owner.Camera.GetCameraTargetForward(tempVector);
		tempVector.CrossProduct(from, this.TempVector2);
		if (!this.TempVector2.Normalize(9.99999993922529E-09))
		{
			this.TempVector2.DeepCopy(Vector.RightVectorProxy);
			if (Singleton<MathUtils>.Instance.IsNearlyEqual(Math.Abs(Vector.DotProduct(this.TempVector2, from)), 1.0, new double?((double)0.01f)))
			{
				this.TempVector2.DeepCopy(Vector.ForwardVectorProxy);
			}
		}
		from.CrossProduct(this.TempVector2, this.TempVector3);
		if (BaseCameraGravityLerpExecutor.Debug)
		{
			this.Owner.DrawCameraGravityDebugArrow(this.TempVector2, CameraGravityLerpDebugColors.Gray);
			this.Owner.DrawCameraGravityDebugArrow(tempVector, CameraGravityLerpDebugColors.Brown);
		}
		this.TempVector3.Normalize(9.99999993922529E-09);
		this.FlatAngleGravityQuatAxis.DeepCopy(this.TempVector3);
		if (!this.IsNearOppositeGravityVector(from, to))
		{
			Singleton<MathUtils>.Instance.SqLerpVector(from, to, alpha, @out);
			return false;
		}
		float num = this.ResolveNearOppositeGravitySign(this.TempVector3, tempVector);
		this.FlatAngleGravityQuatSign = num;
		this.HasFlatAngleGravityQuatAxis = true;
		Quat.ConstructorByAxisAngle(this.TempVector3, (float)(3.141592653589793 * (double)alpha * (double)num), this.TempQuat);
		this.TempQuat.RotateVector(from, @out);
		return true;
	}

	// Token: 0x0600553B RID: 21819 RVA: 0x000D88FC File Offset: 0x000D6AFC
	protected bool IsNearOppositeGravityVector(Vector from, Vector to)
	{
		return Math.Abs(Math.Acos(Singleton<MathUtils>.Instance.Clamp(Vector.DotProduct(from, to), -1.0, 1.0)) * 57.295780181884766 - 180.0) <= 5.0;
	}

	// Token: 0x0600553C RID: 21820 RVA: 0x000D8958 File Offset: 0x000D6B58
	protected float ResolveNearOppositeGravitySign(Vector flatAngleAxis, Vector cameraTargetForward)
	{
		float? num = this.TryResolveNearOppositeGravitySignByModelBuffer(flatAngleAxis);
		if (num != null)
		{
			return num.Value;
		}
		if (!this.HasFlatAngleGravityQuatAxis)
		{
			return (float)((Vector.DotProduct(this.Owner.Camera.CameraForward, cameraTargetForward) >= 0.0) ? 1 : -1);
		}
		return this.FlatAngleGravityQuatSign;
	}

	// Token: 0x0600553D RID: 21821 RVA: 0x000D89B4 File Offset: 0x000D6BB4
	protected float? TryResolveNearOppositeGravitySignByModelBuffer(Vector flatAngleAxis)
	{
		if (this.HasStableModelBufferAxis)
		{
			return new float?(this.FlatAngleGravityQuatSign);
		}
		FightCameraLogicComponent camera = this.Owner.Camera;
		bool flag;
		if (camera.EnableFocusOnVehicle)
		{
			VehicleAnimationComponent vehicleAnimationComponent = camera.VehicleAnimationComponent;
			if (vehicleAnimationComponent != null && vehicleAnimationComponent.Valid)
			{
				flag = camera.VehicleAnimationComponent.TryGetModelBufferLerpWorldRotation(this.ModelBufferStartQuat, this.ModelBufferTargetQuat);
				goto IL_9A;
			}
		}
		EntityHandle characterEntityHandle = camera.CharacterEntityHandle;
		CharacterAnimationComponent characterAnimationComponent;
		if (characterEntityHandle == null)
		{
			characterAnimationComponent = null;
		}
		else
		{
			WorldEntity entity = characterEntityHandle.Entity;
			characterAnimationComponent = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
		}
		CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
		flag = (characterAnimationComponent2 != null && characterAnimationComponent2.Valid && characterAnimationComponent2.TryGetModelBufferLerpWorldRotation(this.ModelBufferStartQuat, this.ModelBufferTargetQuat));
		IL_9A:
		if (!flag)
		{
			return null;
		}
		this.ModelBufferStartQuat.Inverse(this.ModelBufferInverseQuat);
		this.ModelBufferTargetQuat.Multiply(this.ModelBufferInverseQuat, this.ModelBufferDeltaQuat);
		if (!this.ModelBufferDeltaQuat.Normalize(1E-06f))
		{
			return null;
		}
		float num = Singleton<MathUtils>.Instance.Clamp(this.ModelBufferDeltaQuat.W, -1f, 1f);
		double num2 = Math.Sqrt((double)(1f - num * num));
		if (num2 < 9.999999747378752E-05)
		{
			return null;
		}
		double num3 = (double)this.ModelBufferDeltaQuat.X / num2 * flatAngleAxis.X + (double)this.ModelBufferDeltaQuat.Y / num2 * flatAngleAxis.Y + (double)this.ModelBufferDeltaQuat.Z / num2 * flatAngleAxis.Z;
		if (this.ModelBufferDeltaQuat.W < 0f)
		{
			num3 = -num3;
		}
		if (Math.Abs(num3) < 0.8660253882408142)
		{
			return null;
		}
		this.HasStableModelBufferAxis = true;
		return new float?((float)((num3 >= 0.0) ? 1 : -1));
	}

	// Token: 0x0600553E RID: 21822 RVA: 0x000D8B8C File Offset: 0x000D6D8C
	protected unsafe void Finish()
	{
		this.IsFinished = true;
		this.InternalSetCameraGravityDirect(this.Owner.GetGravityEndLerpVector(), this.FlatAngleGravityQuatAxis, this.FlatAngleGravityQuatSign);
		if (BaseCameraGravityLerpExecutor.Debug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraGravity]插值设置重力方向[结束]";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("config", this.LerpConfig.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GravityDirect", this.Owner.GetCurrentCameraGravityDirect().ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlatAngleGravityQuatSign", this.FlatAngleGravityQuatSign);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
	}

	// Token: 0x0600553F RID: 21823 RVA: 0x000D8C55 File Offset: 0x000D6E55
	protected virtual void InitInternal()
	{
	}

	// Token: 0x06005540 RID: 21824 RVA: 0x000D8C57 File Offset: 0x000D6E57
	protected virtual float UpdateInternal(float deltaTime)
	{
		return 1f;
	}

	// Token: 0x06005541 RID: 21825 RVA: 0x000D8C5E File Offset: 0x000D6E5E
	public static void CreateStaticDefaultValue()
	{
		BaseCameraGravityLerpExecutor.Debug = false;
	}

	// Token: 0x06005542 RID: 21826 RVA: 0x000D8C66 File Offset: 0x000D6E66
	public static void ResetStaticDefaultValue()
	{
		BaseCameraGravityLerpExecutor.Debug = false;
	}

	// Token: 0x04001A3B RID: 6715
	private const float COS_30_DEG = 0.8660254f;

	// Token: 0x04001A3C RID: 6716
	protected const float NearOppositeGravityAngleToleranceDeg = 5f;

	// Token: 0x04001A3D RID: 6717
	[Nullable(2)]
	public CameraGravityController Owner;

	// Token: 0x04001A3E RID: 6718
	public CameraGravityLerpConfig LerpConfig = new CameraGravityLerpConfig();

	// Token: 0x04001A3F RID: 6719
	public bool IsFinished;

	// Token: 0x04001A40 RID: 6720
	public static bool Debug;

	// Token: 0x04001A41 RID: 6721
	protected readonly Vector TempVector = Vector.Create();

	// Token: 0x04001A42 RID: 6722
	protected readonly Vector TempVector2 = Vector.Create();

	// Token: 0x04001A43 RID: 6723
	protected readonly Vector TempVector3 = Vector.Create();

	// Token: 0x04001A44 RID: 6724
	protected readonly Vector TempVector4 = Vector.Create();

	// Token: 0x04001A45 RID: 6725
	protected readonly Vector TempVector5 = Vector.Create();

	// Token: 0x04001A46 RID: 6726
	protected readonly Vector TempVector6 = Vector.Create();

	// Token: 0x04001A47 RID: 6727
	protected readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001A48 RID: 6728
	protected readonly Quat ModelBufferStartQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001A49 RID: 6729
	protected readonly Quat ModelBufferTargetQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001A4A RID: 6730
	protected readonly Quat ModelBufferInverseQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001A4B RID: 6731
	protected readonly Quat ModelBufferDeltaQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001A4C RID: 6732
	protected readonly Vector FlatAngleGravityQuatAxis = Vector.Create();

	// Token: 0x04001A4D RID: 6733
	public float FlatAngleGravityQuatSign = 1f;

	// Token: 0x04001A4E RID: 6734
	public bool HasStableModelBufferAxis;

	// Token: 0x04001A4F RID: 6735
	protected bool HasFlatAngleGravityQuatAxis;
}
