using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Utils;
using Cysharp.Threading.Tasks;

// Token: 0x02002DD9 RID: 11737
[NullableContext(2)]
[Nullable(0)]
public class BatchBulletPositionCircle : IBatchBulletPositionShape
{
	// Token: 0x06017A79 RID: 96889 RVA: 0x00699922 File Offset: 0x00697B22
	private BatchBulletPositionCircle()
	{
	}

	// Token: 0x06017A7A RID: 96890 RVA: 0x00699943 File Offset: 0x00697B43
	public bool IsDestroyOnEnd()
	{
		return false;
	}

	// Token: 0x06017A7B RID: 96891 RVA: 0x00699946 File Offset: 0x00697B46
	public bool IsSummonChildBullet()
	{
		return false;
	}

	// Token: 0x06017A7C RID: 96892 RVA: 0x00699949 File Offset: 0x00697B49
	public float GetDelay()
	{
		return 0f;
	}

	// Token: 0x06017A7D RID: 96893 RVA: 0x00699950 File Offset: 0x00697B50
	public void OnBreak()
	{
	}

	// Token: 0x06017A7E RID: 96894 RVA: 0x00699952 File Offset: 0x00697B52
	public void OnEnd()
	{
	}

	// Token: 0x06017A7F RID: 96895 RVA: 0x00699954 File Offset: 0x00697B54
	public UniTask Load()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x06017A80 RID: 96896 RVA: 0x0069995B File Offset: 0x00697B5B
	[NullableContext(1)]
	public static BatchBulletPositionCircle Create(CharacterCustomValueComponent customValueComp, SBatchBulletPositionCircle config)
	{
		BatchBulletPositionCircle batchBulletPositionCircle = new BatchBulletPositionCircle();
		batchBulletPositionCircle.FromUeConfig(customValueComp, config);
		return batchBulletPositionCircle;
	}

	// Token: 0x06017A81 RID: 96897 RVA: 0x0069996C File Offset: 0x00697B6C
	[NullableContext(1)]
	public void FromUeConfig(CharacterCustomValueComponent customValueComp, SBatchBulletPositionCircle config)
	{
		this.AngleInterval = (double)customValueComp.GetBlackboard(config.AngleIntervalKey, TFormulaValue.FromDouble(0.0));
		Vector vector;
		this.Center = (customValueComp.GetBlackboard(config.CenterKey, default(TFormulaValue)).TryGetVector(out vector) ? vector : null);
		this.Clockwise = config.Clockwise;
		Rotator rotator2;
		Rotator rotator = customValueComp.GetBlackboard(config.ForwardKey, default(TFormulaValue)).TryGetRotator(out rotator2) ? rotator2 : null;
		if (rotator != null)
		{
			rotator.Vector(this.Forward);
		}
		this.Radius = (double)customValueComp.GetBlackboard(config.RadiusKey, TFormulaValue.FromDouble(0.0));
		this.BeginAngle = (double)config.BeginAngle;
		this.BeginRotator = config.BeginRotator;
		this.DistToTarget = (double)customValueComp.GetBlackboard(config.DistToTarget, TFormulaValue.FromDouble(0.0));
		Vector vector2;
		this.StartPos = (customValueComp.GetBlackboard(config.StartPosKey, default(TFormulaValue)).TryGetVector(out vector2) ? vector2 : null);
	}

	// Token: 0x06017A82 RID: 96898 RVA: 0x00699AA8 File Offset: 0x00697CA8
	public Transform ToTransform(int index)
	{
		Transform transform = Transform.Create();
		transform.SetLocation(this.Center);
		Vector vector = Vector.Create();
		double num = this.BeginAngle + (double)index * this.AngleInterval * (double)(this.Clockwise ? 1 : -1);
		this.Forward.RotateAngleAxis(num, Vector.UpVectorProxy, vector);
		vector.MultiplyEqual(this.Radius);
		transform.GetLocation().AdditionEqual(vector);
		if (this.BeginRotator == EBatchBulletBeginRotator.切线方向)
		{
			this.Forward.RotateAngleAxis(num + 90.0, Vector.UpVectorProxy, vector);
			Rotator rotator = Rotator.Create();
			vector.Rotation(rotator);
			rotator.Quaternion(transform.GetRotation());
		}
		else if (this.BeginRotator == EBatchBulletBeginRotator.法线方向)
		{
			Rotator rotator2 = Rotator.Create();
			vector.Normalize(9.99999993922529E-09);
			vector.Rotation(rotator2);
			rotator2.Quaternion(transform.GetRotation());
		}
		return transform;
	}

	// Token: 0x06017A83 RID: 96899 RVA: 0x00699B90 File Offset: 0x00697D90
	public Vector ToTargetLocation(Transform transform)
	{
		if (transform == null || Math.Abs(this.DistToTarget) < 1E-08)
		{
			return null;
		}
		Vector vector = Vector.Create();
		transform.GetRotation().GetForwardVector(vector);
		vector.MultiplyEqual(this.DistToTarget);
		if (this.StartPos != null)
		{
			vector.AdditionEqual(this.StartPos);
		}
		else
		{
			vector.AdditionEqual(transform.GetLocation());
		}
		return vector;
	}

	// Token: 0x0400B64E RID: 46670
	public double AngleInterval;

	// Token: 0x0400B64F RID: 46671
	public Vector Center;

	// Token: 0x0400B650 RID: 46672
	public bool Clockwise = true;

	// Token: 0x0400B651 RID: 46673
	[Nullable(1)]
	public Vector Forward = Vector.Create();

	// Token: 0x0400B652 RID: 46674
	public double Radius;

	// Token: 0x0400B653 RID: 46675
	public double BeginAngle;

	// Token: 0x0400B654 RID: 46676
	public EBatchBulletBeginRotator BeginRotator = EBatchBulletBeginRotator.切线方向;

	// Token: 0x0400B655 RID: 46677
	public double DistToTarget;

	// Token: 0x0400B656 RID: 46678
	public Vector StartPos;
}
