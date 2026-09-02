using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;

// Token: 0x02000BB2 RID: 2994
[NullableContext(1)]
[Nullable(0)]
public abstract class ControllerGenericBase : IControllerBase
{
	// Token: 0x17000096 RID: 150
	// (get) Token: 0x0600309F RID: 12447 RVA: 0x0001AB3D File Offset: 0x00018D3D
	protected virtual bool IsTickEvenPausedInternal
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000097 RID: 151
	// (get) Token: 0x060030A0 RID: 12448 RVA: 0x0001AB40 File Offset: 0x00018D40
	public bool IsTickEvenPaused
	{
		get
		{
			return this.IsTickEvenPausedInternal;
		}
	}

	// Token: 0x060030A1 RID: 12449 RVA: 0x0001AB48 File Offset: 0x00018D48
	public void SetControllerManager(IControllerManagerBase manager)
	{
		this.Manager = manager;
	}

	// Token: 0x060030A2 RID: 12450 RVA: 0x0001AB51 File Offset: 0x00018D51
	public virtual bool Init()
	{
		return this.OnInit();
	}

	// Token: 0x060030A3 RID: 12451 RVA: 0x0001AB59 File Offset: 0x00018D59
	public virtual bool Clear()
	{
		this.IsClear = true;
		return this.OnClear();
	}

	// Token: 0x060030A4 RID: 12452 RVA: 0x0001AB68 File Offset: 0x00018D68
	protected void PauseTick()
	{
		this.CanTick = false;
	}

	// Token: 0x060030A5 RID: 12453 RVA: 0x0001AB71 File Offset: 0x00018D71
	protected void ResumeTick()
	{
		this.CanTick = true;
	}

	// Token: 0x060030A6 RID: 12454 RVA: 0x0001AB7A File Offset: 0x00018D7A
	protected void InitTickOptimize(int tickInterval = 1, int tickIntervalInFight = 1)
	{
		this.TickInterval = tickInterval;
		this.TickIntervalInFight = tickIntervalInFight;
		this.DefaultTickSetting = false;
	}

	// Token: 0x17000098 RID: 152
	// (get) Token: 0x060030A7 RID: 12455 RVA: 0x0001AB91 File Offset: 0x00018D91
	// (set) Token: 0x060030A8 RID: 12456 RVA: 0x0001AB99 File Offset: 0x00018D99
	private bool CanTick
	{
		get
		{
			return this.CanTickInternal;
		}
		set
		{
			if (this.CanTickInternal != value)
			{
				this.CanTickInternal = value;
				this.DefaultTickSetting = false;
				this.CurrentTickInterval = 0;
				this.CurrentTickDeltaTime = 0f;
			}
		}
	}

	// Token: 0x060030A9 RID: 12457 RVA: 0x0001ABC4 File Offset: 0x00018DC4
	public bool CheckTick(bool inFight, float deltaTime)
	{
		if (this.DefaultTickSetting)
		{
			return true;
		}
		if (!this.CanTick)
		{
			return false;
		}
		if (inFight)
		{
			if (this.TickIntervalInFight < 0)
			{
				return false;
			}
			this.CurrentTickInterval++;
			this.CurrentTickDeltaTime += deltaTime;
			if (this.TickIntervalInFight > this.CurrentTickInterval)
			{
				return false;
			}
		}
		else
		{
			if (this.TickInterval < 0)
			{
				return false;
			}
			this.CurrentTickInterval++;
			this.CurrentTickDeltaTime += deltaTime;
			if (this.TickInterval > this.CurrentTickInterval)
			{
				return false;
			}
		}
		this.CurrentTickInterval = 0;
		return true;
	}

	// Token: 0x060030AA RID: 12458 RVA: 0x0001AC60 File Offset: 0x00018E60
	public unsafe void Tick(float delta)
	{
		if (this.IsClear)
		{
			return;
		}
		float delta2 = delta;
		if (this.CurrentTickDeltaTime != 0f)
		{
			delta2 = this.CurrentTickDeltaTime;
			this.CurrentTickDeltaTime = 0f;
		}
		try
		{
			this.OnTick(delta2);
		}
		catch (Exception ex) when (1)
		{
			if (ex != null)
			{
				Exception ex2 = ex;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Controller;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "Tick方法执行异常";
				Exception error = ex2;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex2.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Controller;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "Tick方法执行异常";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("name", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("error", ex.ToString());
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
		}
	}

	// Token: 0x060030AB RID: 12459 RVA: 0x0001ADA0 File Offset: 0x00018FA0
	public void AfterTick(float delta)
	{
		if (this.IsClear)
		{
			return;
		}
		this.OnAfterTick(delta);
	}

	// Token: 0x060030AC RID: 12460 RVA: 0x0001ADB2 File Offset: 0x00018FB2
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<string, CustomPromise<bool>>? Preload()
	{
		return this.OnPreload();
	}

	// Token: 0x060030AD RID: 12461 RVA: 0x0001ADBA File Offset: 0x00018FBA
	public bool LeaveLevel()
	{
		return this.OnLeaveLevel();
	}

	// Token: 0x060030AE RID: 12462 RVA: 0x0001ADC2 File Offset: 0x00018FC2
	public bool ChangeMode()
	{
		return this.OnChangeMode();
	}

	// Token: 0x060030AF RID: 12463 RVA: 0x0001ADCA File Offset: 0x00018FCA
	public void SetPerformanceStateObject(string name, string desc = "", string group = "")
	{
		this.PerformanceState = Stat.CreateNoFlameGraph(name, desc, group);
	}

	// Token: 0x060030B0 RID: 12464 RVA: 0x0001ADDA File Offset: 0x00018FDA
	public Stat GetPerformanceStateObject()
	{
		return this.OnGetPerformanceStateObject();
	}

	// Token: 0x060030B1 RID: 12465 RVA: 0x0001ADE2 File Offset: 0x00018FE2
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x060030B2 RID: 12466 RVA: 0x0001ADE5 File Offset: 0x00018FE5
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x060030B3 RID: 12467 RVA: 0x0001ADE7 File Offset: 0x00018FE7
	protected virtual void OnAfterTick(float delta)
	{
	}

	// Token: 0x060030B4 RID: 12468 RVA: 0x0001ADE9 File Offset: 0x00018FE9
	protected virtual bool OnClear()
	{
		return true;
	}

	// Token: 0x060030B5 RID: 12469 RVA: 0x0001ADEC File Offset: 0x00018FEC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	protected virtual ValueTuple<string, CustomPromise<bool>>? OnPreload()
	{
		return null;
	}

	// Token: 0x060030B6 RID: 12470 RVA: 0x0001AE02 File Offset: 0x00019002
	protected virtual bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x060030B7 RID: 12471 RVA: 0x0001AE05 File Offset: 0x00019005
	protected virtual Stat OnGetPerformanceStateObject()
	{
		return this.PerformanceState;
	}

	// Token: 0x060030B8 RID: 12472 RVA: 0x0001AE0D File Offset: 0x0001900D
	protected virtual bool OnChangeMode()
	{
		return true;
	}

	// Token: 0x04000411 RID: 1041
	protected IControllerManagerBase Manager;

	// Token: 0x04000412 RID: 1042
	protected Stat PerformanceState;

	// Token: 0x04000413 RID: 1043
	private bool IsClear;

	// Token: 0x04000414 RID: 1044
	private bool DefaultTickSetting = true;

	// Token: 0x04000415 RID: 1045
	private bool CanTickInternal = true;

	// Token: 0x04000416 RID: 1046
	protected int TickIntervalInFight = 1;

	// Token: 0x04000417 RID: 1047
	protected int TickInterval = 1;

	// Token: 0x04000418 RID: 1048
	private int CurrentTickInterval;

	// Token: 0x04000419 RID: 1049
	private float CurrentTickDeltaTime;
}
