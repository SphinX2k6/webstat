using System;
using System.Runtime.CompilerServices;

// Token: 0x020030EA RID: 12522
[NullableContext(1)]
[Nullable(0)]
public class WhirlpoolPoint : IClear, IStaticVariableResetter
{
	// Token: 0x06019E25 RID: 106021 RVA: 0x00791DEC File Offset: 0x0078FFEC
	static WhirlpoolPoint()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(WhirlpoolPoint.CreateStaticDefaultValue), new Action(WhirlpoolPoint.ResetStaticDefaultValue));
	}

	// Token: 0x06019E26 RID: 106022 RVA: 0x00791E0B File Offset: 0x0079000B
	public static int GenId()
	{
		return WhirlpoolPoint.GlobalId++;
	}

	// Token: 0x06019E27 RID: 106023 RVA: 0x00791E1A File Offset: 0x0079001A
	public bool GetEnable()
	{
		return this.Enable;
	}

	// Token: 0x06019E28 RID: 106024 RVA: 0x00791E22 File Offset: 0x00790022
	public bool GetCancelByHit()
	{
		return this.CancelByHit;
	}

	// Token: 0x06019E29 RID: 106025 RVA: 0x00791E2A File Offset: 0x0079002A
	public float GetMoveTime()
	{
		return this.MoveTime;
	}

	// Token: 0x06019E2A RID: 106026 RVA: 0x00791E32 File Offset: 0x00790032
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06019E2B RID: 106027 RVA: 0x00791E3C File Offset: 0x0079003C
	public void Begin(int id, float moveTime, Vector location, Vector beginLocation, float duration = -1f, EVelocityCurveType curveType = EVelocityCurveType.None, bool cancelByHit = true, int needTagId = 0)
	{
		this.Id = id;
		this.MoveTime = moveTime;
		this.ToLocation.FromUeVector(location);
		this.BeginLocation.FromUeVector(beginLocation);
		this.Enable = true;
		this.ElapsedTime = 0f;
		this.Duration = duration;
		this.CurveType = curveType;
		this.CancelByHit = cancelByHit;
		this.NeedTagId = needTagId;
	}

	// Token: 0x06019E2C RID: 106028 RVA: 0x00791EA2 File Offset: 0x007900A2
	public void UpdateLocation(Vector location)
	{
		this.ToLocation.FromUeVector(location);
	}

	// Token: 0x06019E2D RID: 106029 RVA: 0x00791EB0 File Offset: 0x007900B0
	public bool OnTick(float delta)
	{
		this.ElapsedTime += delta;
		if (this.Duration > 0f && this.Duration <= this.ElapsedTime)
		{
			this.ElapsedTime = this.Duration;
			return false;
		}
		return true;
	}

	// Token: 0x06019E2E RID: 106030 RVA: 0x00791EEA File Offset: 0x007900EA
	public void OnEnd()
	{
		this.Enable = false;
	}

	// Token: 0x06019E2F RID: 106031 RVA: 0x00791EF3 File Offset: 0x007900F3
	public bool ClearObject()
	{
		this.Id = 0;
		this.MoveTime = 0f;
		this.Enable = false;
		this.ElapsedTime = 0f;
		this.Duration = 0f;
		return true;
	}

	// Token: 0x06019E30 RID: 106032 RVA: 0x00791F28 File Offset: 0x00790128
	public float GetAlpha()
	{
		float num = this.ElapsedTime / this.MoveTime;
		switch (this.CurveType)
		{
		case EVelocityCurveType.Convex:
			return 1f + MathF.Pow(num - 1f, 3f);
		case EVelocityCurveType.LinearityDown:
			return 1f - num;
		case EVelocityCurveType.Concave:
			return MathF.Pow(num, 3f);
		}
		return num;
	}

	// Token: 0x06019E31 RID: 106033 RVA: 0x00791F8F File Offset: 0x0079018F
	public static void CreateStaticDefaultValue()
	{
		WhirlpoolPoint.GlobalId = 0;
	}

	// Token: 0x06019E32 RID: 106034 RVA: 0x00791F97 File Offset: 0x00790197
	public static void ResetStaticDefaultValue()
	{
		WhirlpoolPoint.GlobalId = 0;
	}

	// Token: 0x06019E33 RID: 106035 RVA: 0x00791F9F File Offset: 0x0079019F
	public int GetNeedTagId()
	{
		return this.NeedTagId;
	}

	// Token: 0x0400CF84 RID: 53124
	private int Id;

	// Token: 0x0400CF85 RID: 53125
	public readonly Vector ToLocation = Vector.Create();

	// Token: 0x0400CF86 RID: 53126
	public readonly Vector BeginLocation = Vector.Create();

	// Token: 0x0400CF87 RID: 53127
	private bool Enable;

	// Token: 0x0400CF88 RID: 53128
	private float MoveTime;

	// Token: 0x0400CF89 RID: 53129
	private static int GlobalId;

	// Token: 0x0400CF8A RID: 53130
	private float ElapsedTime;

	// Token: 0x0400CF8B RID: 53131
	private float Duration = -1f;

	// Token: 0x0400CF8C RID: 53132
	private EVelocityCurveType CurveType;

	// Token: 0x0400CF8D RID: 53133
	private bool CancelByHit;

	// Token: 0x0400CF8E RID: 53134
	private int NeedTagId;
}
