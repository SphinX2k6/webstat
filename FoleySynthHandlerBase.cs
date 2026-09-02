using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003002 RID: 12290
[NullableContext(2)]
[Nullable(0)]
public abstract class FoleySynthHandlerBase
{
	// Token: 0x0601909F RID: 102559 RVA: 0x0071BA3C File Offset: 0x00719C3C
	protected FoleySynthHandlerBase(CharacterActorComponent actorComp, CharacterAkComponent akComp, int recordCount)
	{
	}

	// Token: 0x170021B9 RID: 8633
	// (get) Token: 0x060190A0 RID: 102560 RVA: 0x0071BAB1 File Offset: 0x00719CB1
	// (set) Token: 0x060190A1 RID: 102561 RVA: 0x0071BAB9 File Offset: 0x00719CB9
	public CharacterActorComponent ActorComp { get; private set; } = actorComp;

	// Token: 0x170021BA RID: 8634
	// (get) Token: 0x060190A2 RID: 102562 RVA: 0x0071BAC2 File Offset: 0x00719CC2
	// (set) Token: 0x060190A3 RID: 102563 RVA: 0x0071BACA File Offset: 0x00719CCA
	public CharacterAkComponent AkComp { get; private set; } = akComp;

	// Token: 0x170021BB RID: 8635
	// (get) Token: 0x060190A4 RID: 102564 RVA: 0x0071BAD3 File Offset: 0x00719CD3
	// (set) Token: 0x060190A5 RID: 102565 RVA: 0x0071BADB File Offset: 0x00719CDB
	public int RecordCount { get; private set; } = recordCount;

	// Token: 0x060190A6 RID: 102566 RVA: 0x0071BAE4 File Offset: 0x00719CE4
	public virtual void Tick(float deltaTime)
	{
		if (!this.IsActive)
		{
			return;
		}
		this.CalCurrentFoleySynthTick(deltaTime);
	}

	// Token: 0x060190A7 RID: 102567 RVA: 0x0071BAF6 File Offset: 0x00719CF6
	public void SetActive(bool active)
	{
		this.IsActive = active;
	}

	// Token: 0x060190A8 RID: 102568 RVA: 0x0071BAFF File Offset: 0x00719CFF
	public virtual void Clear()
	{
		this.ActorComp = null;
		this.AkComp = null;
		this.UeAkComp = null;
	}

	// Token: 0x060190A9 RID: 102569 RVA: 0x0071BB18 File Offset: 0x00719D18
	private void CalCurrentFoleySynthTick(float deltaTime)
	{
		float num = deltaTime * 0.001f;
		if (this.IsDebug)
		{
			this.DebugTime += num;
		}
		if (this.RecordTickCount == 0)
		{
			this.PreCacheBoneLocation();
			this.RecordTickCount++;
			return;
		}
		this.CalBoneRecord(num);
		if (this.RecordTickCount > this.RecordCount + this.RecordErrorFlag)
		{
			this.OnParseBoneSpeedForAudio();
		}
		this.RecordTickCount++;
		if (this.RecordTickCount == 2147483647)
		{
			this.RecordTickCount = this.RecordCount;
			this.RecordErrorFlag = 0;
		}
	}

	// Token: 0x060190AA RID: 102570
	protected abstract void PreCacheBoneLocation();

	// Token: 0x060190AB RID: 102571
	protected abstract void CalBoneRecord(float deltaTime);

	// Token: 0x060190AC RID: 102572 RVA: 0x0071BBB1 File Offset: 0x00719DB1
	protected virtual void OnParseBoneSpeedForAudio()
	{
	}

	// Token: 0x060190AD RID: 102573 RVA: 0x0071BBB4 File Offset: 0x00719DB4
	[NullableContext(1)]
	[return: Nullable(0)]
	protected ValueTuple<double, double> CalBoneSpeed(Vector nowLocation, Vector preLocation, float deltaTime)
	{
		this.TempVector.DeepCopy(nowLocation);
		this.TempVector.SubtractionEqual(preLocation);
		this.TempVector.DivisionEqual((double)deltaTime);
		double item = this.TempVector.Size();
		this.TempVector.AdditionEqual(this.ActorComp.ActorVelocityProxy);
		return new ValueTuple<double, double>(this.TempVector.Size(), item);
	}

	// Token: 0x060190AE RID: 102574 RVA: 0x0071BC1C File Offset: 0x00719E1C
	protected int GetPreRecordIndex(int size)
	{
		return (this.RecordIndex + this.RecordCount - size) % this.RecordCount;
	}

	// Token: 0x060190AF RID: 102575 RVA: 0x0071BC34 File Offset: 0x00719E34
	[NullableContext(1)]
	protected FoleySynthRecord GetCurrentRecord(int configIndex)
	{
		return this.FoleySynthRecordsModel[this.RecordIndex][configIndex];
	}

	// Token: 0x060190B0 RID: 102576 RVA: 0x0071BC50 File Offset: 0x00719E50
	public void SetDebug(bool debug)
	{
		if (debug)
		{
			this.SavedPath = string.Concat(new string[]
			{
				UKismetSystemLibrary.GetProjectDirectory(),
				"/Saved/FoleySynth/FoleySynthRecord_",
				base.GetType().Name,
				"_",
				this.ActorComp.Actor.GetName(),
				".txt"
			});
			this.SavedRecords = "";
			this.IsDebug = true;
			this.DebugTime = 0f;
			return;
		}
		this.SavedRecords = "";
		this.IsDebug = false;
	}

	// Token: 0x060190B1 RID: 102577 RVA: 0x0071BCE4 File Offset: 0x00719EE4
	public unsafe void SaveDebugInfo(FName? boneName, double speed, double acceleration, double boneSpeed)
	{
		if (!this.IsDebug)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 5);
		defaultInterpolatedStringHandler.AppendFormatted((boneName != null) ? boneName.GetValueOrDefault().ToString() : null);
		defaultInterpolatedStringHandler.AppendLiteral(",speed:");
		defaultInterpolatedStringHandler.AppendFormatted<double>(speed);
		defaultInterpolatedStringHandler.AppendLiteral(",acceleration:");
		defaultInterpolatedStringHandler.AppendFormatted<double>(acceleration);
		defaultInterpolatedStringHandler.AppendLiteral(",boneSpeed:");
		defaultInterpolatedStringHandler.AppendFormatted<double>(boneSpeed);
		defaultInterpolatedStringHandler.AppendLiteral(",debugTime:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.DebugTime);
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		this.SavedRecords = this.SavedRecords + "\n" + text;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "-------------Ak[FoleySynth] Debug信息";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.ActorComp.Actor.GetName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Info", text);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0400C3FD RID: 50173
	protected UAkComponent UeAkComp;

	// Token: 0x0400C3FE RID: 50174
	[Nullable(1)]
	protected readonly List<List<FoleySynthRecord>> FoleySynthRecordsModel = new List<List<FoleySynthRecord>>();

	// Token: 0x0400C3FF RID: 50175
	[Nullable(1)]
	protected readonly List<FoleySynthDynamicConfig> FoleySynthModelDynamicConfigs = new List<FoleySynthDynamicConfig>();

	// Token: 0x0400C400 RID: 50176
	[Nullable(1)]
	protected readonly List<Vector> PreModelBoneComponentLocations = new List<Vector>();

	// Token: 0x0400C401 RID: 50177
	protected int RecordIndex;

	// Token: 0x0400C402 RID: 50178
	protected int RecordTickCount;

	// Token: 0x0400C403 RID: 50179
	protected int RecordErrorFlag;

	// Token: 0x0400C404 RID: 50180
	[Nullable(1)]
	protected readonly Vector TempVector = Vector.Create();

	// Token: 0x0400C405 RID: 50181
	[Nullable(1)]
	protected readonly Vector TempBoneLocation = Vector.Create();

	// Token: 0x0400C406 RID: 50182
	protected bool IsActive;

	// Token: 0x0400C407 RID: 50183
	[Nullable(1)]
	protected string SavedRecords = "";

	// Token: 0x0400C408 RID: 50184
	protected bool IsDebug;

	// Token: 0x0400C409 RID: 50185
	[Nullable(1)]
	protected string SavedPath = "";

	// Token: 0x0400C40A RID: 50186
	protected float DebugTime;
}
