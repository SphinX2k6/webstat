using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200708F RID: 28815
	[NullableContext(1)]
	[Nullable(0)]
	public class SeparateCameraLayout
	{
		// Token: 0x06045D44 RID: 286020 RVA: 0x012489F4 File Offset: 0x01246BF4
		public SeparateCameraLayout(CameraModelInstance cameraModeInstance)
		{
		}

		// Token: 0x1700A5A3 RID: 42403
		// (get) Token: 0x06045D45 RID: 286021 RVA: 0x01248A5B File Offset: 0x01246C5B
		public CameraModelInstance CameraModeInstance { get; } = cameraModeInstance;

		// Token: 0x06045D46 RID: 286022 RVA: 0x01248A64 File Offset: 0x01246C64
		public unsafe void SetViewInfo(Vector2D viewLocation, Vector2D viewSize, bool enableScissorOffset)
		{
			this.CurrentBlendState = ESeparateBlendState.Stay;
			this.UpdateViewLocation(viewLocation);
			this.UpdateViewSize(viewSize);
			this.UpdateScissorOffset(enableScissorOffset);
			if (SeparateCameraLayout.Debug)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[分屏相机]设置分屏信息";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", this.CameraModeInstance.CameraName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewLocation", this.GetFormatVector2D(this.CurrentViewLocation));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ViewSize", this.GetFormatVector2D(this.CurrentViewSize));
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}

		// Token: 0x06045D47 RID: 286023 RVA: 0x01248B24 File Offset: 0x01246D24
		public unsafe void SetTargetViewInfo(float blendTime, Vector2D targetViewLocation, Vector2D targetViewSize, bool enableScissorOffset, [Nullable(2)] UCurveFloat curveFloat, [Nullable(2)] Action callback = null)
		{
			this.BlendTime = blendTime;
			this.TargetViewLocation.DeepCopy(targetViewLocation);
			this.TargetViewSize.DeepCopy(targetViewSize);
			this.UpdateScissorOffset(enableScissorOffset);
			this.BlendCurve = curveFloat;
			this.FinishCallback = callback;
			this.CurrentBlendState = ESeparateBlendState.Blend;
			this.StartViewLocation.DeepCopy(this.CurrentViewLocation);
			this.StartViewSize.DeepCopy(this.CurrentViewSize);
			this.CurrentBlendTime = 0f;
			if (SeparateCameraLayout.Debug)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[分屏相机]开始插值分屏信息";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", this.CameraModeInstance.CameraName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BlendTime", this.BlendTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ViewLocation(from)", this.GetFormatVector2D(this.CurrentViewLocation));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ViewSize(from)", this.GetFormatVector2D(this.CurrentViewSize));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("ViewLocation(to)", this.GetFormatVector2D(this.TargetViewLocation));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("ViewSize(to)", this.GetFormatVector2D(this.TargetViewSize));
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
		}

		// Token: 0x06045D48 RID: 286024 RVA: 0x01248C9C File Offset: 0x01246E9C
		public unsafe void BlendToTarget(float deltaTime)
		{
			if (this.CurrentBlendState != ESeparateBlendState.Blend)
			{
				return;
			}
			this.CurrentBlendTime += deltaTime * 0.001f;
			float num = (this.BlendTime <= 0f) ? 1f : Math.Min(this.CurrentBlendTime / this.BlendTime, 1f);
			float num2 = num;
			if (this.BlendCurve != null)
			{
				num2 = Singleton<MathUtils>.Instance.Clamp(this.BlendCurve.GetFloatValue(num), 0f, 1f);
			}
			double inX = Singleton<MathUtils>.Instance.Lerp(this.StartViewLocation.X, this.TargetViewLocation.X, (double)num2);
			double inY = Singleton<MathUtils>.Instance.Lerp(this.StartViewLocation.Y, this.TargetViewLocation.Y, (double)num2);
			this.TmpVector2D.Set(inX, inY);
			this.UpdateViewLocation(this.TmpVector2D);
			double inX2 = Singleton<MathUtils>.Instance.Lerp(this.StartViewSize.X, this.TargetViewSize.X, (double)num2);
			double inY2 = Singleton<MathUtils>.Instance.Lerp(this.StartViewSize.Y, this.TargetViewSize.Y, (double)num2);
			this.TmpVector2D.Set(inX2, inY2);
			this.UpdateViewSize(this.TmpVector2D);
			if (num >= 1f)
			{
				this.CurrentBlendState = ESeparateBlendState.Stay;
				Action finishCallback = this.FinishCallback;
				if (finishCallback != null)
				{
					finishCallback();
				}
			}
			if (SeparateCameraLayout.Debug)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[分屏相机]插值分屏信息";
				<>y__InlineArray10<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray10<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", this.CameraModeInstance.CameraName);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "Alpha";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<float>(num, "F2");
				ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item2 = "Ratio";
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<float>(num2, "F2");
				ptr2 = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("State", this.CurrentBlendState);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("ViewLocation(current)", this.GetFormatVector2D(this.CurrentViewLocation));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("ViewSize(current)", this.GetFormatVector2D(this.CurrentViewSize));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("ViewLocation(from)", this.GetFormatVector2D(this.StartViewLocation));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("ViewSize(from)", this.GetFormatVector2D(this.StartViewSize));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("ViewLocation(to)", this.GetFormatVector2D(this.TargetViewLocation));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 9) = new ValueTuple<string, object>("ViewSize(to)", this.GetFormatVector2D(this.TargetViewSize));
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 10));
			}
		}

		// Token: 0x06045D49 RID: 286025 RVA: 0x01248FAD File Offset: 0x012471AD
		private void UpdateViewLocation(Vector2D viewLocation)
		{
			this.CurrentViewLocation.DeepCopy(viewLocation);
			this.CameraModeInstance.PlayerCameraManager.ViewPointOverride = viewLocation.ToUeVector2D(false);
		}

		// Token: 0x06045D4A RID: 286026 RVA: 0x01248FD2 File Offset: 0x012471D2
		private void UpdateViewSize(Vector2D viewSize)
		{
			this.CurrentViewSize.DeepCopy(viewSize);
			this.CameraModeInstance.PlayerCameraManager.ViewSizeOverride = viewSize.ToUeVector2D(false);
		}

		// Token: 0x06045D4B RID: 286027 RVA: 0x01248FF7 File Offset: 0x012471F7
		private void UpdateScissorOffset(bool enableScissorOffset)
		{
			this.EnableScissorOffset = enableScissorOffset;
			if (this.CameraModeInstance.CurrentCameraComponent != null && this.CameraModeInstance.CurrentCameraComponent.IsValid())
			{
				this.CameraModeInstance.CurrentCameraComponent.bEnableScissorOffCenter = enableScissorOffset;
			}
		}

		// Token: 0x06045D4C RID: 286028 RVA: 0x01249030 File Offset: 0x01247230
		private string GetFormatVector2D(Vector2D vector)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(vector.X, "F4");
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>(vector.Y, "F4");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04027179 RID: 160121
		[StaticVariableRuleIgnore]
		public static bool Debug;

		// Token: 0x0402717A RID: 160122
		public Vector2D TargetViewLocation = Vector2D.Create();

		// Token: 0x0402717B RID: 160123
		public Vector2D TargetViewSize = Vector2D.Create();

		// Token: 0x0402717C RID: 160124
		public float BlendTime;

		// Token: 0x0402717D RID: 160125
		[Nullable(2)]
		public UCurveFloat BlendCurve;

		// Token: 0x0402717E RID: 160126
		[Nullable(2)]
		public Action FinishCallback;

		// Token: 0x0402717F RID: 160127
		public Vector2D StartViewLocation = Vector2D.Create();

		// Token: 0x04027180 RID: 160128
		public Vector2D StartViewSize = Vector2D.Create();

		// Token: 0x04027181 RID: 160129
		public Vector2D CurrentViewLocation = Vector2D.Create();

		// Token: 0x04027182 RID: 160130
		public Vector2D CurrentViewSize = Vector2D.Create();

		// Token: 0x04027183 RID: 160131
		public float CurrentBlendTime;

		// Token: 0x04027184 RID: 160132
		public ESeparateBlendState CurrentBlendState;

		// Token: 0x04027185 RID: 160133
		public bool EnableScissorOffset;

		// Token: 0x04027186 RID: 160134
		private readonly Vector2D TmpVector2D = Vector2D.Create();
	}
}
