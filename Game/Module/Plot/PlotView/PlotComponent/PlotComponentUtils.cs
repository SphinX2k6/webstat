using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053EE RID: 21486
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotComponentUtils
	{
		// Token: 0x06036D8C RID: 224652 RVA: 0x00DE7E40 File Offset: 0x00DE6040
		public static float GetTalkWaitTime(ITalkItem talkItem)
		{
			float? waitTime = talkItem.WaitTime;
			if (waitTime == null)
			{
				waitTime = new float?(ModelBase<PlotModel>.Instance.PlotGlobalConfig.JumpWaitTime);
			}
			float? num = waitTime;
			double? num2 = (num != null) ? new double?((double)num.GetValueOrDefault()) : null;
			double minWaitingTime = ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime;
			if (num2.GetValueOrDefault() < minWaitingTime & num2 != null)
			{
				waitTime = new float?((float)ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime);
			}
			waitTime = new float?((float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)waitTime.Value));
			return waitTime.Value;
		}

		// Token: 0x06036D8D RID: 224653 RVA: 0x00DE7EF4 File Offset: 0x00DE60F4
		public static bool GetContentTextNeedRefresh(ITalkItem talkItem)
		{
			return ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelD;
		}

		// Token: 0x06036D8E RID: 224654 RVA: 0x00DE7F10 File Offset: 0x00DE6110
		public static float GetTextWriterAnimSpeed(bool bIsInteraction)
		{
			float result;
			if (bIsInteraction)
			{
				result = ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedInteraction;
			}
			else if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				result = ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelC;
			}
			else
			{
				result = ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelD;
			}
			return result;
		}

		// Token: 0x06036D8F RID: 224655 RVA: 0x00DE7F74 File Offset: 0x00DE6174
		public static float GetTextScrollDelayCharNum()
		{
			return (float)ConfigCommonParamById.GetIntConfig("PlotAutoScrollDelayCharNum").Value;
		}

		// Token: 0x06036D90 RID: 224656 RVA: 0x00DE7F94 File Offset: 0x00DE6194
		public static float GetTextWriterAnimDuration(ITalkItem talkItem, UUIText textComponent, float speed)
		{
			ICaptionParam captionParams = talkItem.CaptionParams;
			if (captionParams != null && captionParams.StartTime == null)
			{
				return captionParams.TotalTime.GetValueOrDefault();
			}
			return (float)textComponent.GetDisplayCharLength() / speed;
		}

		// Token: 0x06036D91 RID: 224657 RVA: 0x00DE7FD4 File Offset: 0x00DE61D4
		public static float GetAutoPlayEndWaitTime(bool bIsInteraction)
		{
			float num = 1f;
			if (bIsInteraction)
			{
				num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeInteraction;
			}
			else if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeLevelC;
			}
			if ((double)num < ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime)
			{
				num = (float)ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime;
			}
			return num * 1000f;
		}
	}
}
