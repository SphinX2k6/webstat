using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Utils;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002DDA RID: 11738
[NullableContext(2)]
[Nullable(0)]
public class BatchBulletPositionDotMatrix : IBatchBulletPositionShape
{
	// Token: 0x06017A84 RID: 96900 RVA: 0x00699BFD File Offset: 0x00697DFD
	private BatchBulletPositionDotMatrix()
	{
	}

	// Token: 0x06017A85 RID: 96901 RVA: 0x00699C0C File Offset: 0x00697E0C
	public void OnBreak()
	{
	}

	// Token: 0x06017A86 RID: 96902 RVA: 0x00699C0E File Offset: 0x00697E0E
	public void OnEnd()
	{
	}

	// Token: 0x06017A87 RID: 96903 RVA: 0x00699C10 File Offset: 0x00697E10
	public UniTask Load()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x06017A88 RID: 96904 RVA: 0x00699C17 File Offset: 0x00697E17
	public float GetDelay()
	{
		return 0f;
	}

	// Token: 0x06017A89 RID: 96905 RVA: 0x00699C1E File Offset: 0x00697E1E
	public bool IsDestroyOnEnd()
	{
		return false;
	}

	// Token: 0x06017A8A RID: 96906 RVA: 0x00699C21 File Offset: 0x00697E21
	public bool IsSummonChildBullet()
	{
		return false;
	}

	// Token: 0x06017A8B RID: 96907 RVA: 0x00699C24 File Offset: 0x00697E24
	[NullableContext(1)]
	public static BatchBulletPositionDotMatrix Create(CharacterCustomValueComponent customValueComp, SBatchBulletPositionPointMatrix config)
	{
		BatchBulletPositionDotMatrix batchBulletPositionDotMatrix = new BatchBulletPositionDotMatrix();
		batchBulletPositionDotMatrix.FromUeConfig(customValueComp, config);
		return batchBulletPositionDotMatrix;
	}

	// Token: 0x06017A8C RID: 96908 RVA: 0x00699C34 File Offset: 0x00697E34
	[NullableContext(1)]
	public void FromUeConfig(CharacterCustomValueComponent customValueComp, SBatchBulletPositionPointMatrix config)
	{
		Vector vector;
		this.Center = (customValueComp.GetBlackboard(config.CenterKey, default(TFormulaValue)).TryGetVector(out vector) ? vector : null);
		this.PositionOffset = new List<Vector>();
		TArray<FVector> positionOffset = config.PositionOffset;
		int num = positionOffset.Num();
		for (int i = 0; i < num; i++)
		{
			this.PositionOffset.Add(Vector.Create(positionOffset.Get(i)));
		}
		this.PositionOffsetScale = (double)config.PositionOffsetScale;
		Rotator rotator;
		this.Rotator = (customValueComp.GetBlackboard(config.RotatorKey, default(TFormulaValue)).TryGetRotator(out rotator) ? rotator : null);
		this.RotatorOffset = Rotator.Create(config.RotatorOffset);
		this.BeginRotator = config.BeginRotator;
	}

	// Token: 0x06017A8D RID: 96909 RVA: 0x00699D18 File Offset: 0x00697F18
	public Transform ToTransform(int index)
	{
		if (this.PositionOffset.Count <= index)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.HCW, "批量生成子弹失败，生成子弹数量超出 位置偏移 数量", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		Transform transform = Transform.Create();
		transform.SetLocation(this.Center);
		transform.SetRotation(this.Rotator.Quaternion(null));
		Vector vector = this.PositionOffset[index];
		Vector vector2 = Vector.Create();
		vector.Multiply(this.PositionOffsetScale, vector2);
		transform.TransformPosition(vector2, vector2);
		transform.SetLocation(vector2);
		if (this.BeginRotator == EBatchBulletBeginRotator.切线方向)
		{
			vector2.SubtractionEqual(this.Center);
			vector2.Normalize(9.99999993922529E-09);
			Rotator rotator = Rotator.Create();
			vector2.Rotation(rotator);
			Singleton<MathUtils>.Instance.ComposeRotator(rotator, this.RotatorOffset, transform.GetRotation());
		}
		return transform;
	}

	// Token: 0x06017A8E RID: 96910 RVA: 0x00699DEE File Offset: 0x00697FEE
	public Vector ToTargetLocation(Transform transform)
	{
		return null;
	}

	// Token: 0x0400B657 RID: 46679
	public Vector Center;

	// Token: 0x0400B658 RID: 46680
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<Vector> PositionOffset;

	// Token: 0x0400B659 RID: 46681
	public double PositionOffsetScale;

	// Token: 0x0400B65A RID: 46682
	public Rotator Rotator;

	// Token: 0x0400B65B RID: 46683
	public Rotator RotatorOffset;

	// Token: 0x0400B65C RID: 46684
	public EBatchBulletBeginRotator BeginRotator = EBatchBulletBeginRotator.切线方向;
}
