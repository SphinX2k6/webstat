using System;
using System.Runtime.CompilerServices;

// Token: 0x02002BBC RID: 11196
[NullableContext(1)]
[Nullable(0)]
public class TodTimeAdjustingAnimation
{
	// Token: 0x060164F0 RID: 91376 RVA: 0x0062DEE0 File Offset: 0x0062C0E0
	public TodTimeAdjustingAnimation(double maxV, double a, Action<double> onPlaying, Action onFinished)
	{
		this.MaxV = maxV;
		this.A = a;
		this.OnPlaying = onPlaying;
		this.OnFinished = onFinished;
	}

	// Token: 0x17001D6F RID: 7535
	// (get) Token: 0x060164F1 RID: 91377 RVA: 0x0062DF2E File Offset: 0x0062C12E
	public bool IsPlaying
	{
		get
		{
			return this.StartSecond >= 0.0;
		}
	}

	// Token: 0x17001D70 RID: 7536
	// (get) Token: 0x060164F2 RID: 91378 RVA: 0x0062DF44 File Offset: 0x0062C144
	public bool IsFinished
	{
		get
		{
			return this.IsPlaying && this.StartSecond >= this.ToSecond;
		}
	}

	// Token: 0x060164F3 RID: 91379 RVA: 0x0062DF61 File Offset: 0x0062C161
	private void Finish()
	{
		this.Stop();
		this.OnFinished();
	}

	// Token: 0x060164F4 RID: 91380 RVA: 0x0062DF74 File Offset: 0x0062C174
	public void Play(double fromSecond, double toSecond)
	{
		this.Stop();
		this.StartSecond = fromSecond;
		this.ToSecond = toSecond;
		double num = this.MaxV / this.A;
		this.DeAccelerateDistance = Math.Abs(this.GetTimeDistance() - 0.5 * this.A * num * num);
	}

	// Token: 0x060164F5 RID: 91381 RVA: 0x0062DFC9 File Offset: 0x0062C1C9
	private double GetTimeDistance()
	{
		return this.ToSecond - this.StartSecond;
	}

	// Token: 0x060164F6 RID: 91382 RVA: 0x0062DFD8 File Offset: 0x0062C1D8
	public void Tick(double deltaMillionSecond)
	{
		if (!this.IsPlaying)
		{
			return;
		}
		if (this.IsFinished)
		{
			this.Finish();
			return;
		}
		double num = deltaMillionSecond / 1000.0;
		this.CurrentRunTime += num;
		if (this.CurrentAddDistance >= this.DeAccelerateDistance)
		{
			this.DeAccelerateTime += num;
			this.CurrentSpeed = this.CurrentMoveSpeedMax - this.DeAccelerateTime * this.A;
			if (this.CurrentSpeed <= 10000.0)
			{
				this.CurrentSpeed = 10000.0;
			}
		}
		else
		{
			this.CurrentSpeed = this.CurrentRunTime * this.A;
			if (this.CurrentSpeed >= this.MaxV)
			{
				this.CurrentSpeed = this.MaxV;
				this.CurrentMoveSpeedMax = this.MaxV;
			}
			this.CurrentMoveSpeedMax = this.CurrentSpeed;
		}
		double num2 = num * this.CurrentSpeed;
		this.CurrentAddDistance += num2;
		this.StartSecond += num2;
		if (this.IsFinished)
		{
			this.StartSecond = this.ToSecond;
		}
		this.OnPlaying(this.StartSecond);
	}

	// Token: 0x060164F7 RID: 91383 RVA: 0x0062E100 File Offset: 0x0062C300
	public void Stop()
	{
		this.CurrentSpeed = 0.0;
		this.CurrentRunTime = 0.0;
		this.StartSecond = -1.0;
		this.ToSecond = -1.0;
		this.DeAccelerateTime = 0.0;
		this.CurrentAddDistance = 0.0;
		this.DeAccelerateDistance = 0.0;
		this.CurrentMoveSpeedMax = 0.0;
	}

	// Token: 0x060164F8 RID: 91384 RVA: 0x0062E188 File Offset: 0x0062C388
	public unsafe void DebugPrint()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TimeOfDay;
		ELogAuthor author = ELogAuthor.TL;
		string message = "TodTimeAdjustingAnimation";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.MaxV", this.MaxV);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.A", this.A);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("this.StartSecond", this.StartSecond);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("this.ToSecond", this.ToSecond);
		instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
	}

	// Token: 0x0400ACAD RID: 44205
	private readonly double MaxV;

	// Token: 0x0400ACAE RID: 44206
	private readonly double A;

	// Token: 0x0400ACAF RID: 44207
	private readonly Action<double> OnPlaying;

	// Token: 0x0400ACB0 RID: 44208
	private readonly Action OnFinished;

	// Token: 0x0400ACB1 RID: 44209
	private double CurrentSpeed;

	// Token: 0x0400ACB2 RID: 44210
	private double CurrentRunTime;

	// Token: 0x0400ACB3 RID: 44211
	private double CurrentAddDistance;

	// Token: 0x0400ACB4 RID: 44212
	private double StartSecond = -1.0;

	// Token: 0x0400ACB5 RID: 44213
	private double ToSecond = -1.0;

	// Token: 0x0400ACB6 RID: 44214
	private double DeAccelerateDistance;

	// Token: 0x0400ACB7 RID: 44215
	private double DeAccelerateTime;

	// Token: 0x0400ACB8 RID: 44216
	private double CurrentMoveSpeedMax;
}
