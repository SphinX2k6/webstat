using System;

// Token: 0x02000E1B RID: 3611
public class CameraGravityLerpByAngleExecutor : BaseCameraGravityLerpExecutor
{
	// Token: 0x06005547 RID: 21831 RVA: 0x000D8F24 File Offset: 0x000D7124
	protected unsafe override float UpdateInternal(float deltaTime)
	{
		float num = this.LerpConfig.LerpAngleVelocity * deltaTime;
		double num2 = Math.Acos(Singleton<MathUtils>.Instance.Clamp(Vector.DotProduct(this.Owner.GetCurrentCameraGravityDirect(), this.Owner.GetGravityEndLerpVector()), -1.0, 1.0)) * 57.295780181884766;
		float num3 = (num2 > 0.0) ? ((float)Singleton<MathUtils>.Instance.Clamp((double)num / num2, 0.0, 1.0)) : 1f;
		bool flag = base.SqLerpGravityVector(this.Owner.GetCurrentCameraGravityDirect(), this.Owner.GetGravityEndLerpVector(), num3, this.TempVector);
		base.InternalSetCameraGravityDirect(this.TempVector, this.FlatAngleGravityQuatAxis, this.FlatAngleGravityQuatSign);
		if (BaseCameraGravityLerpExecutor.Debug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraGravity]插值设置重力方向[更新][角速度]";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("alpha", num3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("lerpAngle", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("deltaAngle", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("flatAngle", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("GravityDirect", this.Owner.GetCurrentCameraGravityDirect().ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("LerpConfig", this.LerpConfig.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
		}
		return num3;
	}
}
