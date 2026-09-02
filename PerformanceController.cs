using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnrealEngine;

// Token: 0x02000BDB RID: 3035
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PerformanceController : Singleton<PerformanceController>
{
	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x060031D8 RID: 12760 RVA: 0x0001F4D3 File Offset: 0x0001D6D3
	public bool IsEntityTickPerformanceTest
	{
		get
		{
			return this.IsEntityTickPerformanceTestInternal;
		}
	}

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x060031D9 RID: 12761 RVA: 0x0001F4DB File Offset: 0x0001D6DB
	public bool IsEntityPerformanceTest
	{
		get
		{
			return this.IsEntityTickPerformanceTestInternal || this.IsEntityGpuPerformanceTestInternal;
		}
	}

	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x060031DA RID: 12762 RVA: 0x0001F4ED File Offset: 0x0001D6ED
	public bool IsPlayerPerformanceTest
	{
		get
		{
			return this.IsPlayerTickPerformanceTestInternal;
		}
	}

	// Token: 0x060031DB RID: 12763 RVA: 0x0001F4F8 File Offset: 0x0001D6F8
	public void SetEntityTickPerformanceTest(bool isOpen)
	{
		this.IsEntityTickPerformanceTestInternal = isOpen;
		if (isOpen)
		{
			this.TickPerformanceMap = new Dictionary<string, double[]>();
			this.EffectTickPerformanceMap = new Dictionary<string, EffectPerformanceRecords>();
			this.EntityComponentTickDataMap = new Dictionary<int, Dictionary<string, double[]>>();
			this.StartFrameCount = new long?(UKismetSystemLibrary.GetFrameCount());
			return;
		}
		this.TickPerformanceMap.Clear();
		this.EffectTickPerformanceMap.Clear();
		this.EntityComponentTickDataMap.Clear();
		this.TickPerformanceMap = null;
		this.EffectTickPerformanceMap = null;
		this.EntityComponentTickDataMap = null;
	}

	// Token: 0x060031DC RID: 12764 RVA: 0x0001F578 File Offset: 0x0001D778
	public void SetPlayerTickPerformanceTest(bool isOpen)
	{
		this.IsPlayerTickPerformanceTestInternal = isOpen;
		if (isOpen)
		{
			this.TickPerformanceMap = new Dictionary<string, double[]>();
			this.EffectTickPerformanceMap = new Dictionary<string, EffectPerformanceRecords>();
			this.EntityComponentTickDataMap = new Dictionary<int, Dictionary<string, double[]>>();
			this.StartFrameCount = new long?(UKismetSystemLibrary.GetFrameCount());
			return;
		}
		this.TickPerformanceMap.Clear();
		this.EffectTickPerformanceMap.Clear();
		this.EntityComponentTickDataMap.Clear();
		this.TickPerformanceMap = null;
		this.EffectTickPerformanceMap = null;
		this.EntityComponentTickDataMap = null;
	}

	// Token: 0x060031DD RID: 12765 RVA: 0x0001F5F7 File Offset: 0x0001D7F7
	public void SetEntityGpuPerformanceTest(bool isOpen)
	{
		this.IsEntityGpuPerformanceTestInternal = isOpen;
	}

	// Token: 0x060031DE RID: 12766 RVA: 0x0001F600 File Offset: 0x0001D800
	public void CollectPlayerSkeletalTickPerformanceInfo(string key, int entityId, float tickTime, long? bornFrame = null)
	{
		if (bornFrame != null)
		{
			long? num = bornFrame;
			long? startFrameCount = this.StartFrameCount;
			if (num.GetValueOrDefault() < startFrameCount.GetValueOrDefault() & (num != null & startFrameCount != null))
			{
				return;
			}
		}
		if (this.InStatisticsMode && this.TargetEntity != -1 && this.TargetEntity == entityId)
		{
			if (this.TickFrameTimeMap == null)
			{
				this.TickFrameTimeMap = new Dictionary<string, ValueTuple<long, double, int, bool>>();
			}
			long frameCount = UKismetSystemLibrary.GetFrameCount();
			ValueTuple<long, double, int, bool> valueTuple;
			if (this.TickFrameTimeMap.TryGetValue(key, out valueTuple))
			{
				if (frameCount == valueTuple.Item1)
				{
					valueTuple.Item2 += (double)tickTime;
					this.TickFrameTimeMap[key] = valueTuple;
					return;
				}
				string str = this.MeasureModeStringMap[1];
				this.AddStatistics(key + "." + str, EMeasureMode.Tick, valueTuple.Item2, new long?(valueTuple.Item1));
				valueTuple.Item1 = frameCount;
				valueTuple.Item2 = (double)tickTime;
				this.TickFrameTimeMap[key] = valueTuple;
				return;
			}
			else
			{
				this.TickFrameTimeMap[key] = new ValueTuple<long, double, int, bool>(frameCount, (double)tickTime, 1, false);
			}
		}
	}

	// Token: 0x060031DF RID: 12767 RVA: 0x0001F71C File Offset: 0x0001D91C
	public void CollectTickPerformanceInfo(string key, bool isTickCount, double tickTime, EMeasureMode measureMode = EMeasureMode.Tick, long? bornFrame = null)
	{
		if (bornFrame != null)
		{
			long? num = bornFrame;
			long? startFrameCount = this.StartFrameCount;
			if (num.GetValueOrDefault() < startFrameCount.GetValueOrDefault() & (num != null & startFrameCount != null))
			{
				return;
			}
		}
		if (this.TickPerformanceMap == null)
		{
			this.TickPerformanceMap = new Dictionary<string, double[]>();
		}
		double[] array;
		if (this.TickPerformanceMap.TryGetValue(key, out array))
		{
			array[0] = array[0] + (isTickCount > false);
			array[1] = array[1] + tickTime;
		}
		else
		{
			this.TickPerformanceMap[key] = new double[]
			{
				1.0,
				tickTime
			};
		}
		if (this.InStatisticsMode)
		{
			if (key.Contains("EntityTick"))
			{
				int num2 = int.Parse(key.Substring(10));
				if (this.TargetEntity != -1 && this.TargetEntity != num2)
				{
					return;
				}
			}
			if (this.TickFrameTimeMap == null)
			{
				this.TickFrameTimeMap = new Dictionary<string, ValueTuple<long, double, int, bool>>();
			}
			string text = Regex.Replace(key, "\\d", "");
			long frameCount = UKismetSystemLibrary.GetFrameCount();
			if (measureMode == EMeasureMode.Create)
			{
				this.AddStatistics(text + "." + this.MeasureModeStringMap[(int)measureMode], measureMode, tickTime, new long?(frameCount));
				return;
			}
			ValueTuple<long, double, int, bool> valueTuple;
			if (this.TickFrameTimeMap.TryGetValue(text, out valueTuple))
			{
				if (frameCount == valueTuple.Item1)
				{
					valueTuple.Item2 += tickTime;
					this.TickFrameTimeMap[text] = valueTuple;
					return;
				}
				string str = this.MeasureModeStringMap[(int)measureMode];
				this.AddStatistics(text + "." + str, measureMode, valueTuple.Item2, new long?(valueTuple.Item1));
				valueTuple.Item1 = frameCount;
				valueTuple.Item2 = tickTime;
				this.TickFrameTimeMap[text] = valueTuple;
				this.AddStatistics("GameThread.Tick", measureMode, (double)UKuroRenderingRuntimeBPPluginBPLibrary.GetGameThreadTime(), new long?(valueTuple.Item1));
				return;
			}
			else
			{
				this.TickFrameTimeMap[text] = new ValueTuple<long, double, int, bool>(frameCount, tickTime, (int)measureMode, false);
			}
		}
	}

	// Token: 0x060031E0 RID: 12768 RVA: 0x0001F914 File Offset: 0x0001DB14
	public unsafe double ConsumeTickTime(string key)
	{
		double[] array;
		if (!this.TickPerformanceMap.TryGetValue(key, out array))
		{
			return 0.0;
		}
		double num = array[0];
		double num2 = array[1];
		double result = (num == 0.0) ? 0.0 : (num2 / num);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Temp;
		ELogAuthor author = ELogAuthor.ZFJ;
		string message = "ConsumeTickTime";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("time", num2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("count", num);
		instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.TickPerformanceMap.Remove(key);
		return result;
	}

	// Token: 0x060031E1 RID: 12769 RVA: 0x0001F9C8 File Offset: 0x0001DBC8
	public void CollectComponentTickPerformanceInfo(int entityId, string componentName, bool isTickCount, float tickTime)
	{
		if (this.EntityComponentTickDataMap == null)
		{
			this.EntityComponentTickDataMap = new Dictionary<int, Dictionary<string, double[]>>();
		}
		Dictionary<string, double[]> dictionary;
		if (this.EntityComponentTickDataMap.TryGetValue(entityId, out dictionary))
		{
			double[] array;
			if (dictionary.TryGetValue(componentName, out array))
			{
				array[0] = array[0] + (isTickCount > false);
				array[1] = array[1] + (double)tickTime;
			}
			else
			{
				dictionary[componentName] = new double[]
				{
					1.0,
					(double)tickTime
				};
			}
		}
		else
		{
			Dictionary<string, double[]> dictionary2 = new Dictionary<string, double[]>();
			dictionary2[componentName] = new double[]
			{
				1.0,
				(double)tickTime
			};
			this.EntityComponentTickDataMap[entityId] = dictionary2;
		}
		if (this.InStatisticsMode && (this.TargetEntity == -1 || this.TargetEntity == entityId))
		{
			if (this.TickFrameTimeMap == null)
			{
				this.TickFrameTimeMap = new Dictionary<string, ValueTuple<long, double, int, bool>>();
			}
			string text = "Entity.Tick." + componentName;
			ValueTuple<long, double, int, bool> valueTuple;
			if (this.TickFrameTimeMap.TryGetValue(text, out valueTuple))
			{
				long frameCount = UKismetSystemLibrary.GetFrameCount();
				if (frameCount == valueTuple.Item1)
				{
					valueTuple.Item2 += (double)tickTime;
					this.TickFrameTimeMap[text] = valueTuple;
					return;
				}
				this.AddStatistics(text, EMeasureMode.Tick, valueTuple.Item2, new long?(valueTuple.Item1));
				valueTuple.Item1 = frameCount;
				valueTuple.Item2 = (double)tickTime;
				this.TickFrameTimeMap[text] = valueTuple;
				return;
			}
			else
			{
				long frameCount2 = UKismetSystemLibrary.GetFrameCount();
				this.TickFrameTimeMap[text] = new ValueTuple<long, double, int, bool>(frameCount2, (double)tickTime, 1, true);
			}
		}
	}

	// Token: 0x060031E2 RID: 12770 RVA: 0x0001FB48 File Offset: 0x0001DD48
	[return: Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, string> ConsumeComponentTickTime(int entityId)
	{
		Dictionary<string, double[]> dictionary;
		if (!this.EntityComponentTickDataMap.TryGetValue(entityId, out dictionary))
		{
			return null;
		}
		if (this.TempComponentOutMap == null)
		{
			this.TempComponentOutMap = new Dictionary<string, string>();
		}
		this.TempComponentOutMap.Clear();
		double num = 0.0;
		foreach (string key in dictionary.Keys)
		{
			double[] array = dictionary[key];
			double num2 = (array[0] == 0.0) ? 0.0 : (array[1] / array[0]);
			num += array[1];
			this.TempComponentOutMap[key] = num2.ToString("F3");
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Temp;
		ELogAuthor author = ELogAuthor.ZFJ;
		string message = "ConsumeComponentTickTimeMax";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mm", num);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		dictionary.Clear();
		return this.TempComponentOutMap;
	}

	// Token: 0x060031E3 RID: 12771 RVA: 0x0001FC58 File Offset: 0x0001DE58
	public void CollectEffectTickPerformanceInfo(string key, bool isTickCount, double startTime, double endTime, EMeasureMode measureMode, long bornFrame, int? particleCount = null, int? emitterCount = null)
	{
		long? startFrameCount = this.StartFrameCount;
		if ((bornFrame < startFrameCount.GetValueOrDefault() & startFrameCount != null) || this.MeasureModeStringMap == null)
		{
			return;
		}
		if (this.EffectTickPerformanceMap == null)
		{
			this.EffectTickPerformanceMap = new Dictionary<string, EffectPerformanceRecords>();
		}
		int length = key.IndexOf('.');
		string text = key.Substring(0, length);
		EffectPerformanceRecords effectPerformanceRecords;
		this.EffectTickPerformanceMap.TryGetValue(text, out effectPerformanceRecords);
		float num = (float)(endTime - startTime);
		EffectPerformanceStatistics effectPerformanceStatistics = new EffectPerformanceStatistics();
		effectPerformanceStatistics.Frame = new long?(UKismetSystemLibrary.GetFrameCount());
		effectPerformanceStatistics.StartTime = startTime;
		effectPerformanceStatistics.EndTime = endTime;
		effectPerformanceStatistics.ParticleCount = particleCount.GetValueOrDefault();
		effectPerformanceStatistics.EmitterCount = emitterCount.GetValueOrDefault();
		effectPerformanceStatistics.Type = this.MeasureModeStringMap[(int)measureMode];
		if (effectPerformanceRecords == null)
		{
			EffectPerformanceRecords effectPerformanceRecords2 = new EffectPerformanceRecords();
			effectPerformanceRecords2.TickCount = 1;
			effectPerformanceRecords2.Duration = num;
			effectPerformanceRecords2.Records.Add(effectPerformanceStatistics);
			this.EffectTickPerformanceMap[text] = effectPerformanceRecords2;
		}
		else
		{
			effectPerformanceRecords.TickCount += ((isTickCount > false) ? 1 : 0);
			effectPerformanceRecords.Duration += num;
			effectPerformanceRecords.Records.Add(effectPerformanceStatistics);
		}
		if (this.InStatisticsMode)
		{
			string str = this.MeasureModeStringMap[(int)measureMode];
			this.AddStatistics("EffectHandle." + str + "." + text, measureMode, (double)num, null);
		}
	}

	// Token: 0x060031E4 RID: 12772 RVA: 0x0001FDC0 File Offset: 0x0001DFC0
	[return: Nullable(new byte[]
	{
		2,
		1,
		1,
		0,
		1,
		1
	})]
	public Dictionary<string, List<ValueTuple<string, string>>> ConsumeEffectTickTime()
	{
		if (this.EffectTickPerformanceMap == null)
		{
			return null;
		}
		if (this.TempEffectOutMap == null)
		{
			this.TempEffectOutMap = new Dictionary<string, List<ValueTuple<string, string>>>();
		}
		this.TempEffectOutMap.Clear();
		foreach (string key in this.EffectTickPerformanceMap.Keys)
		{
			EffectPerformanceRecords effectPerformanceRecords = this.EffectTickPerformanceMap[key];
			float num = (effectPerformanceRecords.TickCount == 0) ? 0f : (effectPerformanceRecords.Duration / (float)effectPerformanceRecords.TickCount);
			List<ValueTuple<string, string>> list = new List<ValueTuple<string, string>>();
			list.Add(new ValueTuple<string, string>("Score", num.ToString("F3")));
			list.Add(new ValueTuple<string, string>("TickCount", effectPerformanceRecords.TickCount.ToString()));
			list.Add(new ValueTuple<string, string>("Duration", effectPerformanceRecords.Duration.ToString("F3")));
			int num2 = 0;
			foreach (EffectPerformanceStatistics effectPerformanceStatistics in effectPerformanceRecords.Records)
			{
				List<ValueTuple<string, string>> list2 = list;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Frame_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				list2.Add(new ValueTuple<string, string>(defaultInterpolatedStringHandler.ToStringAndClear(), effectPerformanceStatistics.Frame.Value.ToString()));
				List<ValueTuple<string, string>> list3 = list;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
				defaultInterpolatedStringHandler.AppendLiteral("StartTime_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				list3.Add(new ValueTuple<string, string>(defaultInterpolatedStringHandler.ToStringAndClear(), effectPerformanceStatistics.StartTime.ToString("F3")));
				List<ValueTuple<string, string>> list4 = list;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
				defaultInterpolatedStringHandler.AppendLiteral("EndTime_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				list4.Add(new ValueTuple<string, string>(defaultInterpolatedStringHandler.ToStringAndClear(), effectPerformanceStatistics.EndTime.ToString("F3")));
				List<ValueTuple<string, string>> list5 = list;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
				defaultInterpolatedStringHandler.AppendLiteral("ParticleCount_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				list5.Add(new ValueTuple<string, string>(defaultInterpolatedStringHandler.ToStringAndClear(), effectPerformanceStatistics.ParticleCount.ToString()));
				List<ValueTuple<string, string>> list6 = list;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
				defaultInterpolatedStringHandler.AppendLiteral("EmitterCount_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				list6.Add(new ValueTuple<string, string>(defaultInterpolatedStringHandler.ToStringAndClear(), effectPerformanceStatistics.EmitterCount.ToString()));
				List<ValueTuple<string, string>> list7 = list;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Type_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				list7.Add(new ValueTuple<string, string>(defaultInterpolatedStringHandler.ToStringAndClear(), effectPerformanceStatistics.Type));
				num2++;
			}
			this.TempEffectOutMap[key] = list;
		}
		this.EffectTickPerformanceMap.Clear();
		return this.TempEffectOutMap;
	}

	// Token: 0x060031E5 RID: 12773 RVA: 0x000200D0 File Offset: 0x0001E2D0
	public void SetStatisticsMode(bool isOpen, int targetEntity, string sectionName = "")
	{
		this.InStatisticsMode = isOpen;
		if (isOpen)
		{
			this.CurSectionName = new FName?(new FName(sectionName));
			this.StartFrameCount = new long?(UKismetSystemLibrary.GetFrameCount());
			this.FrameCount = this.StartFrameCount;
			this.TargetEntity = targetEntity;
			this.MeasureModeStringMap = new Dictionary<int, string>();
			this.MeasureModeStringMap[0] = "Create";
			this.MeasureModeStringMap[1] = "Tick";
			this.MeasureModeStringMap[2] = "Other";
			return;
		}
		if (this.TickFrameTimeMap != null)
		{
			foreach (string text in this.TickFrameTimeMap.Keys)
			{
				ValueTuple<long, double, int, bool> valueTuple = this.TickFrameTimeMap[text];
				string str = this.MeasureModeStringMap[valueTuple.Item3];
				this.AddStatistics(valueTuple.Item4 ? (text ?? "") : (text + "." + str), (EMeasureMode)valueTuple.Item3, valueTuple.Item2, new long?(valueTuple.Item1));
			}
			this.TickFrameTimeMap.Clear();
			this.TickFrameTimeMap = null;
		}
		this.MeasureModeStringMap = null;
		this.CurSectionName = null;
		this.TargetEntity = -1;
	}

	// Token: 0x060031E6 RID: 12774 RVA: 0x00020234 File Offset: 0x0001E434
	private void AddStatistics(string tag, EMeasureMode measureMode, double time, long? frame = null)
	{
		if (this.CurSectionName == null)
		{
			return;
		}
		long frameCount = UKismetSystemLibrary.GetFrameCount();
		long num = frameCount;
		long? frameCount2 = this.FrameCount;
		if (!(num == frameCount2.GetValueOrDefault() & frameCount2 != null))
		{
			this.FrameCount = new long?(frameCount);
		}
		UPerformanceStatisticsLibrary.AddStatistics(this.CurSectionName.Value, (int)((frame != null) ? frame.Value : frameCount), tag, (int)measureMode, (float)time, "");
	}

	// Token: 0x040004CF RID: 1231
	public bool IsInAnyEntitySkillTickTest;

	// Token: 0x040004D0 RID: 1232
	public bool IsOpenCatchWorldEntity;

	// Token: 0x040004D1 RID: 1233
	private bool IsEntityTickPerformanceTestInternal;

	// Token: 0x040004D2 RID: 1234
	private bool IsPlayerTickPerformanceTestInternal;

	// Token: 0x040004D3 RID: 1235
	private bool IsEntityGpuPerformanceTestInternal;

	// Token: 0x040004D4 RID: 1236
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, double[]> TickPerformanceMap;

	// Token: 0x040004D5 RID: 1237
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<int, Dictionary<string, double[]>> EntityComponentTickDataMap;

	// Token: 0x040004D6 RID: 1238
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, EffectPerformanceRecords> EffectTickPerformanceMap;

	// Token: 0x040004D7 RID: 1239
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		0,
		1,
		1
	})]
	private Dictionary<string, List<ValueTuple<string, string>>> TempEffectOutMap;

	// Token: 0x040004D8 RID: 1240
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, string> TempComponentOutMap;

	// Token: 0x040004D9 RID: 1241
	private bool InStatisticsMode;

	// Token: 0x040004DA RID: 1242
	private FName? CurSectionName;

	// Token: 0x040004DB RID: 1243
	private int TargetEntity = -1;

	// Token: 0x040004DC RID: 1244
	private long? FrameCount;

	// Token: 0x040004DD RID: 1245
	[Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	private Dictionary<string, ValueTuple<long, double, int, bool>> TickFrameTimeMap;

	// Token: 0x040004DE RID: 1246
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> MeasureModeStringMap;

	// Token: 0x040004DF RID: 1247
	private long? StartFrameCount;
}
