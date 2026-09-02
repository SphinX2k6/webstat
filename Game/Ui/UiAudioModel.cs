using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A44 RID: 19012
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiAudioModel : Singleton<UiAudioModel>
	{
		// Token: 0x06031AA2 RID: 203426 RVA: 0x00C5FA0B File Offset: 0x00C5DC0B
		[NullableContext(2)]
		public void AddAudioStateData(AudioStateData state)
		{
			this.DataSet.Add(state);
		}

		// Token: 0x06031AA3 RID: 203427 RVA: 0x00C5FA1A File Offset: 0x00C5DC1A
		public bool RemoveAudioStateData(AudioStateData state)
		{
			return this.DataSet.Remove(state);
		}

		// Token: 0x06031AA4 RID: 203428 RVA: 0x00C5FA28 File Offset: 0x00C5DC28
		private float CalculateLevel()
		{
			float num = 0f;
			foreach (AudioStateData audioStateData in this.DataSet)
			{
				if (num < audioStateData.Level)
				{
					num = audioStateData.Level;
				}
			}
			return num;
		}

		// Token: 0x06031AA5 RID: 203429 RVA: 0x00C5FA8C File Offset: 0x00C5DC8C
		private float CalculateAlpha()
		{
			float num = 0f;
			foreach (AudioStateData audioStateData in this.DataSet)
			{
				num = num + audioStateData.Alpha - num * audioStateData.Alpha;
			}
			return num;
		}

		// Token: 0x06031AA6 RID: 203430 RVA: 0x00C5FAF4 File Offset: 0x00C5DCF4
		public unsafe void SetLoopAudioEventShow(int viewId, AActor actor, string eventName)
		{
			if (this.LastLoopAudio.Item1 == 0)
			{
				int item = Singleton<AudioSystem>.Instance.PostEvent(eventName);
				this.LastLoopAudio = new Tuple<int, string, int>(viewId, eventName, item);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "Audio BGM, New View";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewId", viewId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("event", eventName);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (viewId != this.LastLoopAudio.Item1 && eventName != this.LastLoopAudio.Item2)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.LastLoopAudio.Item3, EAudioActionType.Stop, null);
				int item2 = Singleton<AudioSystem>.Instance.PostEvent(eventName);
				this.LastLoopAudio = new Tuple<int, string, int>(viewId, eventName, item2);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Audio;
				ELogAuthor author2 = ELogAuthor.WDX;
				string message2 = "Audio BGM, New BGM";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("viewId", viewId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("event", eventName);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			int item3 = this.LastLoopAudio.Item3;
			this.LastLoopAudio = new Tuple<int, string, int>(viewId, eventName, item3);
			Singleton<AudioSystem>.Instance.ExecuteAction(item3, EAudioActionType.Resume, null);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Audio;
			ELogAuthor author3 = ELogAuthor.WDX;
			string message3 = "Audio BGM, Show Same";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("viewId", viewId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("event", eventName);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
		}

		// Token: 0x06031AA7 RID: 203431 RVA: 0x00C5FCC8 File Offset: 0x00C5DEC8
		public void KeepLoopAudioEventShow(int viewId, AActor actor)
		{
			if (this.LastLoopAudio.Item1 == 0)
			{
				return;
			}
			string item = this.LastLoopAudio.Item2;
			Singleton<UiAudioModel>.Instance.SetLoopAudioEventShow(viewId, actor, item);
		}

		// Token: 0x06031AA8 RID: 203432 RVA: 0x00C5FCFC File Offset: 0x00C5DEFC
		public void KeepLoopAudioEventHide(int viewId, AActor actor)
		{
			if (this.LastLoopAudio.Item1 != viewId)
			{
				return;
			}
			string item = this.LastLoopAudio.Item2;
			Singleton<UiAudioModel>.Instance.SetLoopAudioEventHide(viewId, actor, item);
		}

		// Token: 0x06031AA9 RID: 203433 RVA: 0x00C5FD34 File Offset: 0x00C5DF34
		public void KeepLoopAudioEventDestroy(int viewId, AActor actor)
		{
			if (this.LastLoopAudio.Item1 != viewId)
			{
				return;
			}
			string item = this.LastLoopAudio.Item2;
			Singleton<UiAudioModel>.Instance.SetLoopAudioEventDestroy(viewId, actor, item);
		}

		// Token: 0x06031AAA RID: 203434 RVA: 0x00C5FD6C File Offset: 0x00C5DF6C
		public unsafe void SetLoopAudioEventHide(int viewId, AActor actor, string eventName)
		{
			if (viewId == this.LastLoopAudio.Item1)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.LastLoopAudio.Item3, EAudioActionType.Pause, null);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "Audio BGM, Hide";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewId", viewId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("event", eventName);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06031AAB RID: 203435 RVA: 0x00C5FE00 File Offset: 0x00C5E000
		public unsafe void SetLoopAudioEventDestroy(int viewId, AActor actor, string eventName)
		{
			if (viewId == this.LastLoopAudio.Item1)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.LastLoopAudio.Item3, EAudioActionType.Stop, null);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "Audio BGM, Destroy";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewId", viewId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("event", eventName);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.LastLoopAudio = new Tuple<int, string, int>(0, "", 0);
			}
		}

		// Token: 0x06031AAC RID: 203436 RVA: 0x00C5FEA8 File Offset: 0x00C5E0A8
		public void SetRtpcLevelOpening(float level)
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("RPTC_COVER_LEVEL_OPENING", level, null);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "Audio计算结果";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RPTC_COVER_LEVEL_OPENING", level);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031AAD RID: 203437 RVA: 0x00C5FEFC File Offset: 0x00C5E0FC
		public void SetRtpcLevelClosing(float level)
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("RPTC_COVER_LEVEL_CLOSING", level, null);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "Audio计算结果";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RPTC_COVER_LEVEL_CLOSING", level);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031AAE RID: 203438 RVA: 0x00C5FF50 File Offset: 0x00C5E150
		public unsafe void CalculateRtpcValueAndApply()
		{
			float num = this.CalculateLevel();
			Singleton<AudioSystem>.Instance.SetRtpcValue("RTPC_COVER_LEVEL", num, null);
			float num2 = this.CalculateAlpha();
			Singleton<AudioSystem>.Instance.SetRtpcValue("RTPC_COVER_ALPHA", num, null);
			float num3 = num - this.TempLastLevel;
			this.TempLastLevel = num;
			Singleton<AudioSystem>.Instance.SetRtpcValue("RTPC_COVER_LEVEL_DELTA", num, null);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "Audio计算结果";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RTPC_COVER_LEVEL", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RTPC_COVER_ALPHA", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("RTPC_COVER_LEVEL_DELTA", num3);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x0401CE7B RID: 118395
		public const string RPTC_COVER_LEVEL_CLOSING = "RPTC_COVER_LEVEL_CLOSING";

		// Token: 0x0401CE7C RID: 118396
		public const string RPTC_COVER_LEVEL_OPENING = "RPTC_COVER_LEVEL_OPENING";

		// Token: 0x0401CE7D RID: 118397
		public const string RTPC_COVER_ALPHA = "RTPC_COVER_ALPHA";

		// Token: 0x0401CE7E RID: 118398
		public const string RTPC_COVER_LEVEL = "RTPC_COVER_LEVEL";

		// Token: 0x0401CE7F RID: 118399
		public const string RTPC_COVER_LEVEL_DELTA = "RTPC_COVER_LEVEL_DELTA";

		// Token: 0x0401CE80 RID: 118400
		private readonly HashSet<AudioStateData> DataSet = new HashSet<AudioStateData>();

		// Token: 0x0401CE81 RID: 118401
		private float TempLastLevel;

		// Token: 0x0401CE82 RID: 118402
		public Tuple<int, string, int> LastLoopAudio = new Tuple<int, string, int>(0, "", 0);
	}
}
