using System;

// Token: 0x02000E1A RID: 3610
public class CameraGravityLerpByTimeExecutor : BaseCameraGravityLerpExecutor
{
	// Token: 0x06005544 RID: 21828 RVA: 0x000D8D81 File Offset: 0x000D6F81
	protected override void InitInternal()
	{
		this.LerpTime = 0f;
		if (this.LerpConfig.LerpTime <= 0f)
		{
			base.Finish();
		}
	}

	// Token: 0x06005545 RID: 21829 RVA: 0x000D8DA8 File Offset: 0x000D6FA8
	protected unsafe override float UpdateInternal(float deltaTime)
	{
		this.LerpTime += deltaTime;
		float num = (this.LerpConfig.LerpTime > 0f) ? Singleton<MathUtils>.Instance.Clamp(this.LerpTime / this.LerpConfig.LerpTime, 0f, 1f) : 1f;
		float alpha = (this.LerpConfig.LerpTimeCurve != null) ? this.LerpConfig.LerpTimeCurve.GetFloatValue(num) : num;
		bool flag = base.SqLerpGravityVector(this.Owner.GetGravityStartLerpVector(), this.Owner.GetGravityEndLerpVector(), alpha, this.TempVector);
		base.InternalSetCameraGravityDirect(this.TempVector, this.FlatAngleGravityQuatAxis, this.FlatAngleGravityQuatSign);
		if (BaseCameraGravityLerpExecutor.Debug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraGravity]插值设置重力方向[更新][Time]";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("alpha", num.ToString("F2"));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ratio", alpha.ToString("F2"));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("flatAngle", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("GravityDirect", this.Owner.GetCurrentCameraGravityDirect().ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		return num;
	}

	// Token: 0x04001A50 RID: 6736
	protected float LerpTime;
}
