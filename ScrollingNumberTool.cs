using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B85 RID: 11141
[NullableContext(1)]
[Nullable(0)]
public class ScrollingNumberTool
{
	// Token: 0x060162F6 RID: 90870 RVA: 0x00627D90 File Offset: 0x00625F90
	public UniTask InitCurve(string curveResId = "UiCurve_ScrollingTime")
	{
		ScrollingNumberTool.<InitCurve>d__9 <InitCurve>d__;
		<InitCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCurve>d__.<>4__this = this;
		<InitCurve>d__.curveResId = curveResId;
		<InitCurve>d__.<>1__state = -1;
		<InitCurve>d__.<>t__builder.Start<ScrollingNumberTool.<InitCurve>d__9>(ref <InitCurve>d__);
		return <InitCurve>d__.<>t__builder.Task;
	}

	// Token: 0x060162F7 RID: 90871 RVA: 0x00627DDB File Offset: 0x00625FDB
	public void Init(int startValue, int endValue, Action<float> onUpdateCallback, int duration = 1000)
	{
		this.RemoveTimer();
		this.OnUpdateCallback = onUpdateCallback;
		this.StartValue = (float)startValue;
		this.EndValue = (float)endValue;
		this.Duration = (float)duration;
		this.CurrentValue = (float)startValue;
		this.UpdateDisplay();
	}

	// Token: 0x060162F8 RID: 90872 RVA: 0x00627E14 File Offset: 0x00626014
	public void StartScrolling()
	{
		this.IsScrolling = true;
		this.ElapsedTime = 0f;
		this.StartValue = this.CurrentValue;
		this.RemoveTimer();
		this.ScrollingPlayerTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Update), 20f, 1f, null, null, true);
	}

	// Token: 0x060162F9 RID: 90873 RVA: 0x00627E6E File Offset: 0x0062606E
	public void Clear()
	{
		this.UiCurveNumber = null;
		this.OnUpdateCallback = null;
		this.RemoveTimer();
	}

	// Token: 0x060162FA RID: 90874 RVA: 0x00627E84 File Offset: 0x00626084
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<UCurveFloat> LoadCurveFloat(string resId)
	{
		ScrollingNumberTool.<LoadCurveFloat>d__13 <LoadCurveFloat>d__;
		<LoadCurveFloat>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat>.Create();
		<LoadCurveFloat>d__.resId = resId;
		<LoadCurveFloat>d__.<>1__state = -1;
		<LoadCurveFloat>d__.<>t__builder.Start<ScrollingNumberTool.<LoadCurveFloat>d__13>(ref <LoadCurveFloat>d__);
		return <LoadCurveFloat>d__.<>t__builder.Task;
	}

	// Token: 0x060162FB RID: 90875 RVA: 0x00627EC7 File Offset: 0x006260C7
	private void RemoveTimer()
	{
		if (this.ScrollingPlayerTimer != null && TimerSystem.GameplayTimeInstance.Has(this.ScrollingPlayerTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.ScrollingPlayerTimer);
		}
		this.ScrollingPlayerTimer = null;
	}

	// Token: 0x060162FC RID: 90876 RVA: 0x00627EFC File Offset: 0x006260FC
	private void Update(float deltaTime)
	{
		if (!this.IsScrolling)
		{
			return;
		}
		this.ElapsedTime += deltaTime;
		float num = Math.Min(this.ElapsedTime / this.Duration, 1f);
		float num2;
		if (this.UiCurveNumber != null)
		{
			num2 = this.UiCurveNumber.GetFloatValue(num);
		}
		else
		{
			num2 = this.EaseOutQuad(num);
		}
		this.CurrentValue = this.StartValue + (this.EndValue - this.StartValue) * num2;
		this.UpdateDisplay();
		if (num >= 1f)
		{
			this.RemoveTimer();
			this.IsScrolling = false;
			this.CurrentValue = this.EndValue;
			this.UpdateDisplay();
		}
	}

	// Token: 0x060162FD RID: 90877 RVA: 0x00627FA0 File Offset: 0x006261A0
	private void UpdateDisplay()
	{
		Action<float> onUpdateCallback = this.OnUpdateCallback;
		if (onUpdateCallback == null)
		{
			return;
		}
		onUpdateCallback(this.CurrentValue);
	}

	// Token: 0x060162FE RID: 90878 RVA: 0x00627FB8 File Offset: 0x006261B8
	private float EaseOutQuad(float t)
	{
		return t * (2f - t);
	}

	// Token: 0x060162FF RID: 90879 RVA: 0x00627FC3 File Offset: 0x006261C3
	public void SetTargetNumber(int targetNumber, int? duration = null)
	{
		this.EndValue = (float)targetNumber;
		if (duration != null)
		{
			this.Duration = (float)duration.Value;
		}
		this.StartScrolling();
	}

	// Token: 0x06016300 RID: 90880 RVA: 0x00627FEA File Offset: 0x006261EA
	public float GetCurrentValue()
	{
		return this.CurrentValue;
	}

	// Token: 0x0400ABB7 RID: 43959
	[Nullable(2)]
	private UCurveFloat UiCurveNumber;

	// Token: 0x0400ABB8 RID: 43960
	[Nullable(2)]
	private TimerHandle ScrollingPlayerTimer;

	// Token: 0x0400ABB9 RID: 43961
	[Nullable(2)]
	private Action<float> OnUpdateCallback;

	// Token: 0x0400ABBA RID: 43962
	private float StartValue;

	// Token: 0x0400ABBB RID: 43963
	private float EndValue;

	// Token: 0x0400ABBC RID: 43964
	private float CurrentValue;

	// Token: 0x0400ABBD RID: 43965
	private float Duration;

	// Token: 0x0400ABBE RID: 43966
	private float ElapsedTime;

	// Token: 0x0400ABBF RID: 43967
	private bool IsScrolling;
}
