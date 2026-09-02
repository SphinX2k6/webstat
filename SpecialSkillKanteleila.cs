using System;
using System.Runtime.CompilerServices;

// Token: 0x02003149 RID: 12617
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillKanteleila : SpecialSkillBase
{
	// Token: 0x0601A203 RID: 107011 RVA: 0x007AAB98 File Offset: 0x007A8D98
	public SpecialSkillKanteleila(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A204 RID: 107012 RVA: 0x007AABC4 File Offset: 0x007A8DC4
	public override void OnTick(float delta)
	{
		if (this.EnableAddMoveByInputDirect)
		{
			delta *= (float)Singleton<TimeUtil>.Instance.Millisecond;
			CharacterActorComponent component = this.SpecialSkillComponent.Entity.GetComponent<CharacterActorComponent>();
			BaseMoveComponent component2 = this.SpecialSkillComponent.Entity.GetComponent<BaseMoveComponent>();
			Vector moveDirectionCache = this.SpecialSkillComponent.Entity.GetComponent<CharacterInputComponent>().GetMoveDirectionCache();
			Vector offset = this.GetOffset(component.InputDirectProxy, moveDirectionCache, delta);
			if (!offset.IsNearlyZero(9.999999747378752E-05) && component2 != null)
			{
				component2.MoveCharacter(offset, delta, "SpecialSkillKanteleila");
			}
		}
	}

	// Token: 0x0601A205 RID: 107013 RVA: 0x007AAC50 File Offset: 0x007A8E50
	public void BeginAddMoveByInputDirect(float maxSpeed, float accelerationTime, float decelerationTime, float delayTime)
	{
		this.EnableAddMoveByInputDirect = true;
		this.CurrentSpeed = 0f;
		this.TotalTime = 0f;
		this.DelayTime = delayTime;
		this.InputDirectCache.Reset();
		this.MoveDirCache.Reset();
		this.MaxSpeed = ((maxSpeed > 0f) ? maxSpeed : 0f);
		this.Acceleration = ((accelerationTime > 0f) ? (this.MaxSpeed / accelerationTime) : 0f);
		this.Deceleration = ((decelerationTime > 0f) ? (this.MaxSpeed / decelerationTime) : 0f);
	}

	// Token: 0x0601A206 RID: 107014 RVA: 0x007AACE8 File Offset: 0x007A8EE8
	public override void EndAddMoveByInputDirect()
	{
		this.EnableAddMoveByInputDirect = false;
	}

	// Token: 0x0601A207 RID: 107015 RVA: 0x007AACF4 File Offset: 0x007A8EF4
	private Vector GetOffset(Vector inputDirect, Vector moveDirect, float delta)
	{
		if (!this.MoveDirCache.Equals(moveDirect, 9.999999747378752E-05))
		{
			this.TotalTime = 0f;
		}
		this.MoveDirCache.DeepCopy(moveDirect);
		this.TotalTime += delta;
		if (this.TotalTime < this.DelayTime || inputDirect.IsNearlyZero(9.999999747378752E-05))
		{
			this.CurrentSpeed -= this.Deceleration * delta;
			this.CurrentSpeed = MathF.Max(this.CurrentSpeed, 0f);
		}
		else
		{
			this.CurrentSpeed += this.Acceleration * delta;
			this.CurrentSpeed = MathF.Min(this.CurrentSpeed, this.MaxSpeed);
			this.InputDirectCache.DeepCopy(inputDirect);
		}
		this.TmpVector.DeepCopy(this.InputDirectCache);
		this.TmpVector.Normalize(9.99999993922529E-09);
		this.TmpVector.MultiplyEqual((double)(this.CurrentSpeed * delta));
		return this.TmpVector;
	}

	// Token: 0x0400D1BA RID: 53690
	private bool EnableAddMoveByInputDirect;

	// Token: 0x0400D1BB RID: 53691
	private float MaxSpeed;

	// Token: 0x0400D1BC RID: 53692
	private float Acceleration;

	// Token: 0x0400D1BD RID: 53693
	private float Deceleration;

	// Token: 0x0400D1BE RID: 53694
	private float CurrentSpeed;

	// Token: 0x0400D1BF RID: 53695
	private float TotalTime;

	// Token: 0x0400D1C0 RID: 53696
	private float DelayTime;

	// Token: 0x0400D1C1 RID: 53697
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400D1C2 RID: 53698
	private readonly Vector InputDirectCache = Vector.Create();

	// Token: 0x0400D1C3 RID: 53699
	private readonly Vector MoveDirCache = Vector.Create();
}
