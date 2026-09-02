using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02003017 RID: 12311
public class RotationSetting : IClear
{
	// Token: 0x06019169 RID: 102761 RVA: 0x00721B34 File Offset: 0x0071FD34
	public bool ClearObject()
	{
		this.MinSpeed = 360f;
		this.MaxSpeed = 600f;
		this.MinOffset = 0f;
		this.MaxOffset = 180f;
		this.Curve = CurveUtils.DefaultLinear;
		return true;
	}

	// Token: 0x0601916A RID: 102762 RVA: 0x00721B70 File Offset: 0x0071FD70
	[NullableContext(1)]
	public void UpdateSettings(SMovementRotationSetting setting)
	{
		this.MinSpeed = setting.最小旋转速度;
		this.MaxSpeed = setting.最大旋转速度;
		this.MinOffset = setting.最小角度差;
		this.MaxOffset = setting.最大角度差;
		this.Curve = CurveUtils.CreateCurveByStruct(setting.渐变曲线);
	}

	// Token: 0x0601916B RID: 102763 RVA: 0x00721BBE File Offset: 0x0071FDBE
	public float GetMaxSpeed()
	{
		return this.MaxSpeed;
	}

	// Token: 0x0601916C RID: 102764 RVA: 0x00721BC8 File Offset: 0x0071FDC8
	public float GetSpeed(float offset)
	{
		float key = (offset - this.MinOffset) / (this.MaxOffset - this.MinOffset);
		return this.MinSpeed + this.Curve.GetCurrentValue(key) * (this.MaxSpeed - this.MinSpeed);
	}

	// Token: 0x0400C4AD RID: 50349
	protected float MinSpeed = 360f;

	// Token: 0x0400C4AE RID: 50350
	protected float MaxSpeed = 600f;

	// Token: 0x0400C4AF RID: 50351
	protected float MinOffset;

	// Token: 0x0400C4B0 RID: 50352
	protected float MaxOffset = 180f;

	// Token: 0x0400C4B1 RID: 50353
	[Nullable(1)]
	protected CurveBase Curve = CurveUtils.DefaultLinear;
}
