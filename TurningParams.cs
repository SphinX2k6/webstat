using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D94 RID: 3476
internal class TurningParams
{
	// Token: 0x06004D31 RID: 19761 RVA: 0x000AD63B File Offset: 0x000AB83B
	public TurningParams(float totalTime)
	{
		this.TotalTime = totalTime;
	}

	// Token: 0x06004D32 RID: 19762 RVA: 0x000AD64C File Offset: 0x000AB84C
	[NullableContext(1)]
	public unsafe void CalcTurningRate(CharacterActorComponent actorComp, float startTime, float deltaTime)
	{
		CharacterAnimationComponent component = actorComp.Entity.GetComponent<CharacterAnimationComponent>();
		this.EndAngle = component.MainAnimInstance.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_LOOK, this.TotalTime - startTime, false, false);
		this.StartAngle = component.MainAnimInstance.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_LOOK, 0f, false, false);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "TurnAdd 1058338";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", actorComp.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("endAngle", this.EndAngle);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("startTime", startTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("startAngle", this.StartAngle);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		float num = this.EndAngle - this.StartAngle;
		if (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null))
		{
			return;
		}
		float num2 = Singleton<MathUtils>.Instance.WrapAngle(Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInput(actorComp));
		float num3 = this.IsRootMotionValid ? (num2 - num) : num2;
		float addRate = num3 / num;
		this.AddRate = addRate;
		this.NeedTurn = true;
		this.PreFrameAngle = this.StartAngle;
		this.IsInit = true;
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Test;
		ELogAuthor author2 = ELogAuthor.LCZ;
		string message2 = "TurnAdd 1058338";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", actorComp.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("needAddAngle", num3);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Current", actorComp.ActorRotationProxy);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("Input", actorComp.InputRotatorProxy);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("Delta", num2);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
	}

	// Token: 0x04001630 RID: 5680
	public bool NeedTurn;

	// Token: 0x04001631 RID: 5681
	public float AddRate;

	// Token: 0x04001632 RID: 5682
	public float TotalTime;

	// Token: 0x04001633 RID: 5683
	public float StartAngle;

	// Token: 0x04001634 RID: 5684
	public float EndAngle;

	// Token: 0x04001635 RID: 5685
	public float PreFrameAngle;

	// Token: 0x04001636 RID: 5686
	public bool IsInit;

	// Token: 0x04001637 RID: 5687
	public bool IsRootMotionValid;
}
