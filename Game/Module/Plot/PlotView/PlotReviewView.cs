using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053C8 RID: 21448
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotReviewView : UiViewBase
	{
		// Token: 0x06036B0D RID: 224013 RVA: 0x00DDBDA1 File Offset: 0x00DD9FA1
		[NullableContext(1)]
		public PlotReviewView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036B0E RID: 224014 RVA: 0x00DDBDB4 File Offset: 0x00DD9FB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036B0F RID: 224015 RVA: 0x00DDBE40 File Offset: 0x00DDA040
		protected override UniTask OnBeforeStartAsync()
		{
			PlotReviewView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PlotReviewView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036B10 RID: 224016 RVA: 0x00DDBE83 File Offset: 0x00DDA083
		private void ScrollToBottom(float _)
		{
			if (this.HasScrollToBottom)
			{
				return;
			}
			this.HasScrollToBottom = true;
			base.GetUIDynScrollViewComponent(1).SetScrollProgress(1f);
		}

		// Token: 0x06036B11 RID: 224017 RVA: 0x00DDBEA6 File Offset: 0x00DDA0A6
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06036B12 RID: 224018 RVA: 0x00DDBEAF File Offset: 0x00DDA0AF
		[NullableContext(1)]
		private PlotReviewDynamicScrollItem CreatePlotReviewItem(PlotReviewItemData data, UUIItem uiItem, int index)
		{
			PlotReviewDynamicScrollItem plotReviewDynamicScrollItem = new PlotReviewDynamicScrollItem();
			plotReviewDynamicScrollItem.SetTalkItemToggleClickCallBack(new Action<int>(this.OnTalkItemToggleClick));
			plotReviewDynamicScrollItem.SetTalkItemCanToggleChangeCallBack(new Func<int, bool>(this.CanTalkItemToggleChange));
			return plotReviewDynamicScrollItem;
		}

		// Token: 0x06036B13 RID: 224019 RVA: 0x00DDBEDA File Offset: 0x00DDA0DA
		private void OnTalkItemToggleClick(int index)
		{
			this.PlayPlotAudioByIndex(index);
		}

		// Token: 0x06036B14 RID: 224020 RVA: 0x00DDBEE3 File Offset: 0x00DDA0E3
		private bool CanTalkItemToggleChange(int index)
		{
			return this.CheckCanPlayPlotAudio(index);
		}

		// Token: 0x06036B15 RID: 224021 RVA: 0x00DDBEEC File Offset: 0x00DDA0EC
		private bool CheckCanPlayPlotAudio(int index)
		{
			if (this.Data == null)
			{
				return false;
			}
			int count = this.Data.PlotReviewItemDataList.Count;
			if (index < 0 || index >= count)
			{
				return false;
			}
			PlotReviewItemData plotReviewItemData = this.Data.PlotReviewItemDataList[index];
			if (plotReviewItemData.Type == EPlotReviewItemType.Option)
			{
				return false;
			}
			ITalkItem talkItem = ((PlotReviewTalkItemData)plotReviewItemData.Data).TalkItem;
			string text = talkItem.PlayVoice.GetValueOrDefault() ? talkItem.TidTalk : null;
			return !string.IsNullOrEmpty(text) && ConfigPlotAudioById.GetConfig(text, true) != null;
		}

		// Token: 0x06036B16 RID: 224022 RVA: 0x00DDBF88 File Offset: 0x00DDA188
		private void PlayPlotAudioByIndex(int index)
		{
			if (!this.CheckCanPlayPlotAudio(index))
			{
				return;
			}
			PlotAudio value = ConfigPlotAudioById.GetConfig(((PlotReviewTalkItemData)this.Data.PlotReviewItemDataList[index].Data).TalkItem.TidTalk, true).Value;
			if (this.CurrentPlayAudioIndex == index)
			{
				this.ClearCurPlayAudio();
				return;
			}
			if (this.CurrentPlayAudioIndex >= 0)
			{
				this.ClearCurPlayAudio();
			}
			string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(value);
			this.CurrentPlayAudioIndex = index;
			this.UpdateTalkItemPlayingState(index, true);
			this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent("play_vo_plot_review_log", null, new PostEventArgs?(new PostEventArgs
			{
				ExternalSourceName = "external_plot_review_log_voice",
				ExternalSourceMediaName = externalSourcesMediaName,
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.EndOfEvent && index == this.CurrentPlayAudioIndex)
					{
						this.OnAudioEnd();
					}
				}
			}));
		}

		// Token: 0x06036B17 RID: 224023 RVA: 0x00DDC094 File Offset: 0x00DDA294
		public void ClearCurPlayAudio()
		{
			if (this.PlotPlayEventResult == 0)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.OnAudioEnd();
		}

		// Token: 0x06036B18 RID: 224024 RVA: 0x00DDC0DC File Offset: 0x00DDA2DC
		private void OnAudioEnd()
		{
			if (this.CurrentPlayAudioIndex >= 0)
			{
				this.UpdateTalkItemPlayingState(this.CurrentPlayAudioIndex, false);
			}
			this.PlotPlayEventResult = 0;
			this.CurrentPlayAudioIndex = -1;
		}

		// Token: 0x06036B19 RID: 224025 RVA: 0x00DDC102 File Offset: 0x00DDA302
		public bool IsPlayingAudio()
		{
			return this.PlotPlayEventResult != 0;
		}

		// Token: 0x06036B1A RID: 224026 RVA: 0x00DDC110 File Offset: 0x00DDA310
		private void UpdateTalkItemPlayingState(int index, bool isPlaying)
		{
			((PlotReviewTalkItemData)this.Data.PlotReviewItemDataList[index].Data).IsPlaying = isPlaying;
			DynamicScrollView<PlotReviewDynamicScrollItem, PlotReviewDynamicScrollBaseItem, PlotReviewItemData> plotReviewDynamicScrollView = this.PlotReviewDynamicScrollView;
			PlotReviewDynamicScrollItem plotReviewDynamicScrollItem = (plotReviewDynamicScrollView != null) ? plotReviewDynamicScrollView.GetScrollItemFromIndex(index) : null;
			if (plotReviewDynamicScrollItem != null)
			{
				EToggleState talkItemToggleState = isPlaying ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				plotReviewDynamicScrollItem.SetTalkItemToggleState(talkItemToggleState);
			}
		}

		// Token: 0x06036B1B RID: 224027 RVA: 0x00DDC164 File Offset: 0x00DDA364
		protected override void OnBeforeHide()
		{
			this.ClearCurPlayAudio();
		}

		// Token: 0x0401F80A RID: 129034
		private PlotReviewViewData Data;

		// Token: 0x0401F80B RID: 129035
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401F80C RID: 129036
		private PlotReviewDynamicScrollBaseItem PlotReviewDynamicScrollBaseItem;

		// Token: 0x0401F80D RID: 129037
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		protected DynamicScrollView<PlotReviewDynamicScrollItem, PlotReviewDynamicScrollBaseItem, PlotReviewItemData> PlotReviewDynamicScrollView;

		// Token: 0x0401F80E RID: 129038
		private int CurrentPlayAudioIndex = -1;

		// Token: 0x0401F80F RID: 129039
		private int PlotPlayEventResult;

		// Token: 0x0401F810 RID: 129040
		private bool HasScrollToBottom;

		// Token: 0x0200B33D RID: 45885
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04037866 RID: 227430
			public const int CaptionItem = 0;

			// Token: 0x04037867 RID: 227431
			public const int PlotReviewDynamicScrollView = 1;

			// Token: 0x04037868 RID: 227432
			public const int PlotReviewItem = 2;
		}
	}
}
