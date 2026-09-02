using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020021DC RID: 8668
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class LogReportModel : ModelBase<LogReportModel>
{
	// Token: 0x06010583 RID: 66947 RVA: 0x00477308 File Offset: 0x00475508
	protected override bool OnInit()
	{
		this.TimerAssemblyLogDataMap.Add("1012", new ExploreToolAssemblyLogData("1001"));
		this.TimerAssemblyLogDataMap.Add("1013", new ExploreToolAssemblyLogData("1003"));
		this.TimerAssemblyLogDataMap.Add("1014", new ExploreToolAssemblyLogData("1004"));
		this.TimerAssemblyLogDataMap.Add("1025", new ExploreToolAssemblyLogData("1013"));
		return true;
	}

	// Token: 0x1700142D RID: 5165
	// (get) Token: 0x06010584 RID: 66948 RVA: 0x0047737E File Offset: 0x0047557E
	public double HangUpTime
	{
		get
		{
			return this.HangUpTimeInternal;
		}
	}

	// Token: 0x06010585 RID: 66949 RVA: 0x00477388 File Offset: 0x00475588
	public void RecordOperateTime(bool isCheck = false, string key = "", double value = 0.0)
	{
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (this.LastOperateTime == 0.0)
		{
			this.LastOperateTime = serverTimeStamp;
		}
		if (isCheck && !string.IsNullOrEmpty(key))
		{
			double num;
			if (this.HangUpRecord.TryGetValue(key, out num) && num == value)
			{
				return;
			}
			this.HangUpRecord[key] = value;
		}
		double num2 = (serverTimeStamp - this.LastOperateTime) * Singleton<TimeUtil>.Instance.Millisecond;
		if (num2 > 30.0)
		{
			this.HangUpTimeInternal += num2;
			HangUpTimeLogData hangUpTimeLogData = new HangUpTimeLogData();
			hangUpTimeLogData.f_hang_up_time = num2.ToString();
			ControllerBase<LogReportController>.Instance.LogReport(hangUpTimeLogData);
		}
		this.LastOperateTime = serverTimeStamp;
	}

	// Token: 0x06010586 RID: 66950 RVA: 0x00477438 File Offset: 0x00475638
	public void SetTimerAssemblyLogData(string eventId, AssemblyLogData assemblyLogData)
	{
		this.TimerAssemblyLogDataMap[eventId] = assemblyLogData;
	}

	// Token: 0x06010587 RID: 66951 RVA: 0x00477447 File Offset: 0x00475647
	[return: Nullable(2)]
	public AssemblyLogData GetTimerAssemblyLogData(string eventId)
	{
		return this.TimerAssemblyLogDataMap.GetValueOrDefault(eventId);
	}

	// Token: 0x06010588 RID: 66952 RVA: 0x00477455 File Offset: 0x00475655
	public ICollection<AssemblyLogData> GetAllTimerAssemblyLogData()
	{
		return this.TimerAssemblyLogDataMap.Values;
	}

	// Token: 0x06010589 RID: 66953 RVA: 0x00477464 File Offset: 0x00475664
	public PresetProperties GetPresetProperties()
	{
		PresetProperties presetProperties = new PresetProperties();
		presetProperties.system_language = UKismetInternationalizationLibrary.GetCurrentLanguage();
		presetProperties.os_version = UKuroStaticLibrary.GetOSVersion();
		presetProperties.device_id = UThinkingAnalytics.GetDeviceId(0);
		FVector2D gameResolution = UKuroRenderingRuntimeBPPluginBPLibrary.GetGameResolution();
		presetProperties.screen_height = gameResolution.Y.ToString();
		presetProperties.screen_width = gameResolution.X.ToString();
		return presetProperties;
	}

	// Token: 0x040080DB RID: 32987
	private const int RECORD_HANG_UP_OFFSET = 30;

	// Token: 0x040080DC RID: 32988
	private double LastOperateTime;

	// Token: 0x040080DD RID: 32989
	private double HangUpTimeInternal;

	// Token: 0x040080DE RID: 32990
	private readonly Dictionary<string, double> HangUpRecord = new Dictionary<string, double>();

	// Token: 0x040080DF RID: 32991
	private readonly Dictionary<string, AssemblyLogData> TimerAssemblyLogDataMap = new Dictionary<string, AssemblyLogData>();
}
