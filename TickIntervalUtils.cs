using System;
using System.Runtime.CompilerServices;

// Token: 0x02000C26 RID: 3110
[NullableContext(1)]
[Nullable(0)]
public static class TickIntervalUtils
{
	// Token: 0x060035BD RID: 13757 RVA: 0x00032B10 File Offset: 0x00030D10
	private static int GetTickInterval(double distance, double radio, TickIntervalConfig config)
	{
		if (distance < (double)config.TickPerFrameThreshold && radio < config.TickPerFrameThresholdRadio)
		{
			return 0;
		}
		double num = 1.0;
		if (distance > (double)config.TickPerFrameThreshold)
		{
			num = 1.0 + (distance - (double)config.TickPerFrameThreshold) / (double)config.TickFramePeriod;
			num *= num;
		}
		double num2 = 1.0;
		if (radio > config.TickPerFrameThresholdRadio)
		{
			num2 = 1.0 + (radio - config.TickPerFrameThresholdRadio) / config.TickFramePeriodRatio;
			num2 *= num2;
		}
		return (int)Math.Min(num * num2, (double)config.MaxInterval);
	}

	// Token: 0x060035BE RID: 13758 RVA: 0x00032BA7 File Offset: 0x00030DA7
	public static double GetCharacterTickInterval(double distance, double radio)
	{
		return (double)TickIntervalUtils.GetTickInterval(distance, radio, TickIntervalUtils.characterConfig);
	}

	// Token: 0x060035BF RID: 13759 RVA: 0x00032BB6 File Offset: 0x00030DB6
	public static double GetCommonNpcTickInterval(double distance, double radio)
	{
		return (double)TickIntervalUtils.GetTickInterval(distance, radio, TickIntervalUtils.commonNpcConfig);
	}

	// Token: 0x060035C0 RID: 13760 RVA: 0x00032BC5 File Offset: 0x00030DC5
	public static int GetSimpleNpcTickInterval(double distance, double radio)
	{
		return TickIntervalUtils.GetTickInterval(distance, radio, TickIntervalUtils.simpleNpcConfig);
	}

	// Token: 0x060035C1 RID: 13761 RVA: 0x00032BD3 File Offset: 0x00030DD3
	public static int GetSceneItemTickInterval(double distance, double radio)
	{
		return TickIntervalUtils.GetTickInterval(distance, radio, TickIntervalUtils.sceneItemConfig);
	}

	// Token: 0x040006A1 RID: 1697
	private const int MAX_INTERVAL = 60;

	// Token: 0x040006A2 RID: 1698
	[StaticVariableRuleIgnore]
	private static readonly TickIntervalConfig characterConfig = new TickIntervalConfig(5000, 5000, 1.3089969158172607, 0.1745329201221466, 60);

	// Token: 0x040006A3 RID: 1699
	[StaticVariableRuleIgnore]
	private static readonly TickIntervalConfig commonNpcConfig = new TickIntervalConfig(5000, 5000, 1.3089969158172607, 0.1745329201221466, 60);

	// Token: 0x040006A4 RID: 1700
	[StaticVariableRuleIgnore]
	private static readonly TickIntervalConfig simpleNpcConfig = new TickIntervalConfig(5000, 3500, 1.3089969158172607, 0.1745329201221466, 60);

	// Token: 0x040006A5 RID: 1701
	[StaticVariableRuleIgnore]
	private static readonly TickIntervalConfig sceneItemConfig = new TickIntervalConfig(1500, 1000, 1.3089969158172607, 0.1745329201221466, 60);
}
