using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200536B RID: 21355
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotGlobalConfig
	{
		// Token: 0x0603673E RID: 223038 RVA: 0x00DBC714 File Offset: 0x00DBA914
		public void Init()
		{
			if (this.IsInit)
			{
				return;
			}
			this.EndWaitTimeLevelC = this.GetFloatValue("LevelC.EndWaitTime");
			this.EndWaitTimeLevelD = this.GetFloatValue("LevelD.EndWaitTime");
			this.EndWaitTimeInteraction = this.GetFloatValue("Interaction.EndWaitTime");
			this.EndWaitTimeCenterText = this.GetFloatValue("CenterText.EndWaitTime");
			this.TextAnimSpeedSeq = this.GetFloatValue("Seq.CharPerSec") / (float)Singleton<TimeUtil>.Instance.Minute;
			this.TextAnimSpeedLevelC = this.GetFloatValue("LevelC.CharPerSec") / (float)Singleton<TimeUtil>.Instance.Minute;
			this.TextAnimSpeedLevelD = this.GetFloatValue("LevelD.CharPerSec") / (float)Singleton<TimeUtil>.Instance.Minute;
			this.TextAnimSpeedInteraction = this.GetFloatValue("Interaction.CharPerSec") / (float)Singleton<TimeUtil>.Instance.Minute;
			this.TextAnimSpeedCenterText = this.GetFloatValue("CenterText.CharPerSec");
			this.JumpWaitTime = this.GetFloatValue("Talk.JumpWaitTime");
			this.GuardTime = this.GetFloatValue("Talk.GuardTime");
			this.AudioDelay = this.GetFloatValue("Talk.AudioDelay");
			this.AudioTransitionDuration = this.GetFloatValue("Talk.AudioTransitionDuration");
			this.CenterTextFontSizeSmall = this.GetFloatValue("CenterText.FontSizeSmall");
			this.CenterTextFontSizeMiddle = this.GetFloatValue("CenterText.FontSizeMiddle");
			this.CenterTextFontSizeBig = this.GetFloatValue("CenterText.FontSizeBig");
			this.TemplateCameraShakePath = (this.GetGlobalConfigFromCsvText("PlotTemplate.CameraShake") ?? "");
			this.PlotGoBattleMaterialPath = (this.GetGlobalConfigFromCsvText("Plot.GoBattleMaterialPath") ?? "");
			this.InitPlotTemplateLookAtDelay();
			this.InitPlotTemplateCameraExitRotation();
			this.CallShowAudioEvent = (this.GetGlobalConfigFromCsvText("PhoneCall.CallShowAudioEvent") ?? "");
			this.CallHideAudioEvent = (this.GetGlobalConfigFromCsvText("PhoneCall.CallHideAudioEvent") ?? "");
			this.SequenceEndLeastTime = this.GetFloatValue("Sequence.SequenceEndLeastTime");
			this.TipsDuration = this.GetFloatValue("Plot.TipsDuration");
			this.SkipPressingTime = this.GetFloatValue("Plot.SkipPressingTime");
			this.DoubleClickInterval = this.GetFloatValue("Plot.DoubleClickInterval");
			this.ClickBufferTime = this.GetFloatValue("Plot.ClickBufferTime");
			this.DisableFlow = (this.GetFloatValue("Plot.DisableFlow") >= 1f);
			this.WaitCalmTime = this.GetFloatValue("Plot.WaitCalmTime") * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.DragDist = this.GetFloatValue("Plot.DragDist");
			this.AudioEndWaitTimePrompt = this.GetFloatValue("Plot.AudioEndWaitTimePrompt");
			this.DefaultDurationPrompt = this.GetFloatValue("Plot.DefaultDurationPrompt");
			this.ProtectOptionTime = this.GetFloatValue("Plot.ProtectOptionTime") * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.AudioEndDelay = this.GetFloatValue("Plot.AudioEndDelay");
			this.BubbleAudioEndDelay = this.GetFloatValue("Plot.BubbleAudioEndDelay");
			this.TransitionPopupTime = this.GetFloatValue("Plot.TransitionPopupTime");
			this.EntitySequenceScreenEffectPath = (this.GetGlobalConfigFromCsvText("Plot.EntitySequenceScreenEffectPath") ?? "");
			this.EntitySequencePostEffectPath = (this.GetGlobalConfigFromCsvText("Plot.EntitySequencePostEffectPath") ?? "");
			this.EntitySequenceAudioEvent = (this.GetGlobalConfigFromCsvText("Plot.EntitySequenceSkipAudio") ?? "play_ui_mainline_kuaijing");
			float floatValue = this.GetFloatValue("Plot.EntitySequenceSkipRate");
			this.EntitySequenceAccelerateRate = ((floatValue <= 0f) ? 30f : floatValue);
			this.AutoSelectOptionCharPerSec = this.GetFloatValue("Plot.AutoSelectOptionCharPerSec");
			this.IsInit = true;
		}

		// Token: 0x0603673F RID: 223039 RVA: 0x00DBCA78 File Offset: 0x00DBAC78
		private unsafe void InitPlotTemplateLookAtDelay()
		{
			string globalConfigFromCsvText = this.GetGlobalConfigFromCsvText("PlotTemplate.LookAtDelay");
			if (StringUtils.IsEmpty(globalConfigFromCsvText))
			{
				return;
			}
			string[] array = globalConfigFromCsvText.Split(',', StringSplitOptions.None);
			if (array.Length == 2)
			{
				int num = 2;
				List<float> list = new List<float>(num);
				CollectionsMarshal.SetCount<float>(list, num);
				Span<float> span = CollectionsMarshal.AsSpan<float>(list);
				int num2 = 0;
				*span[num2] = float.Parse(array[0]) * 1000f;
				num2++;
				*span[num2] = float.Parse(array[1]) * 1000f;
				this.PlotTemplateLookAtDelay = list;
			}
		}

		// Token: 0x06036740 RID: 223040 RVA: 0x00DBCB00 File Offset: 0x00DBAD00
		private void InitPlotTemplateCameraExitRotation()
		{
			string globalConfigFromCsvText = this.GetGlobalConfigFromCsvText("PlotTemplate.CameraExitRotation");
			if (StringUtils.IsEmpty(globalConfigFromCsvText))
			{
				return;
			}
			string[] array = globalConfigFromCsvText.Split(',', StringSplitOptions.None);
			if (array.Length == 3)
			{
				this.PlotTemplateCameraExitRotation = Rotator.Create(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			}
		}

		// Token: 0x06036741 RID: 223041 RVA: 0x00DBCB58 File Offset: 0x00DBAD58
		[return: Nullable(2)]
		private string GetGlobalConfigFromCsvText(string name)
		{
			GlobalConfigFromCsv? config = ConfigGlobalConfigFromCsvByName.GetConfig(name, true);
			if (config != null)
			{
				return config.Value.Value;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "已经使用的全局配置字段不能乱删！！！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("被删掉的全局配置字段", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06036742 RID: 223042 RVA: 0x00DBCBB0 File Offset: 0x00DBADB0
		private float GetFloatValue(string key)
		{
			string globalConfigFromCsvText = this.GetGlobalConfigFromCsvText(key);
			if (globalConfigFromCsvText != null)
			{
				return float.Parse(globalConfigFromCsvText);
			}
			return 0f;
		}

		// Token: 0x0401F529 RID: 128297
		public float EndWaitTimeLevelC;

		// Token: 0x0401F52A RID: 128298
		public float EndWaitTimeLevelD;

		// Token: 0x0401F52B RID: 128299
		public float EndWaitTimeInteraction;

		// Token: 0x0401F52C RID: 128300
		public float EndWaitTimeCenterText;

		// Token: 0x0401F52D RID: 128301
		public float TextAnimSpeedSeq;

		// Token: 0x0401F52E RID: 128302
		public float TextAnimSpeedLevelC;

		// Token: 0x0401F52F RID: 128303
		public float TextAnimSpeedLevelD;

		// Token: 0x0401F530 RID: 128304
		public float TextAnimSpeedInteraction;

		// Token: 0x0401F531 RID: 128305
		public float TextAnimSpeedCenterText;

		// Token: 0x0401F532 RID: 128306
		public float JumpWaitTime;

		// Token: 0x0401F533 RID: 128307
		public float GuardTime;

		// Token: 0x0401F534 RID: 128308
		public float AudioDelay;

		// Token: 0x0401F535 RID: 128309
		public float AudioTransitionDuration;

		// Token: 0x0401F536 RID: 128310
		public float CenterTextFontSizeSmall;

		// Token: 0x0401F537 RID: 128311
		public float CenterTextFontSizeMiddle;

		// Token: 0x0401F538 RID: 128312
		public float CenterTextFontSizeBig;

		// Token: 0x0401F539 RID: 128313
		public string TemplateCameraShakePath = "";

		// Token: 0x0401F53A RID: 128314
		public string PlotGoBattleMaterialPath = "";

		// Token: 0x0401F53B RID: 128315
		public Rotator PlotTemplateCameraExitRotation = new Rotator();

		// Token: 0x0401F53C RID: 128316
		public List<float> PlotTemplateLookAtDelay = new List<float>
		{
			300f,
			1000f
		};

		// Token: 0x0401F53D RID: 128317
		public string CallShowAudioEvent = "";

		// Token: 0x0401F53E RID: 128318
		public string CallHideAudioEvent = "";

		// Token: 0x0401F53F RID: 128319
		public float SequenceEndLeastTime;

		// Token: 0x0401F540 RID: 128320
		public float DoubleClickInterval;

		// Token: 0x0401F541 RID: 128321
		public float TipsDuration;

		// Token: 0x0401F542 RID: 128322
		public float SkipPressingTime;

		// Token: 0x0401F543 RID: 128323
		public float ClickBufferTime;

		// Token: 0x0401F544 RID: 128324
		public bool DisableFlow;

		// Token: 0x0401F545 RID: 128325
		public float WaitCalmTime = 4000f;

		// Token: 0x0401F546 RID: 128326
		public float DragDist = 100f;

		// Token: 0x0401F547 RID: 128327
		public float SkipTipsOpenTime = 3f;

		// Token: 0x0401F548 RID: 128328
		public float AudioEndWaitTimePrompt;

		// Token: 0x0401F549 RID: 128329
		public float DefaultDurationPrompt;

		// Token: 0x0401F54A RID: 128330
		public float ProtectOptionTime;

		// Token: 0x0401F54B RID: 128331
		public float AudioEndDelay;

		// Token: 0x0401F54C RID: 128332
		public float BubbleAudioEndDelay;

		// Token: 0x0401F54D RID: 128333
		public float TransitionPopupTime;

		// Token: 0x0401F54E RID: 128334
		public string EntitySequenceScreenEffectPath = "";

		// Token: 0x0401F54F RID: 128335
		public string EntitySequencePostEffectPath = "";

		// Token: 0x0401F550 RID: 128336
		public string EntitySequenceAudioEvent = "";

		// Token: 0x0401F551 RID: 128337
		public float EntitySequenceAccelerateRate;

		// Token: 0x0401F552 RID: 128338
		public float AutoSelectOptionCharPerSec;

		// Token: 0x0401F553 RID: 128339
		private bool IsInit;
	}
}
