using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC9 RID: 24265
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalView : UiViewBase
	{
		// Token: 0x0603CFB9 RID: 249785 RVA: 0x00F7CB0B File Offset: 0x00F7AD0B
		public CiacconaGalView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603CFBA RID: 249786 RVA: 0x00F7CB14 File Offset: 0x00F7AD14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickMask));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.HideAvg));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CFBB RID: 249787 RVA: 0x00F7CC82 File Offset: 0x00F7AE82
		protected override void OnBeforeShow()
		{
			this.WarmUpIcon();
			base.GetTexture(3).SetUIActive(false);
		}

		// Token: 0x0603CFBC RID: 249788 RVA: 0x00F7CC98 File Offset: 0x00F7AE98
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CFBD RID: 249789 RVA: 0x00F7CCDC File Offset: 0x00F7AEDC
		protected override void OnStart()
		{
			ControllerBase<CiacconaGalController>.Instance.AddOnStepDataUpdate(new Action<int>(this.OnDataUpdate));
			ControllerBase<CiacconaGalController>.Instance.GalPlayer.AddOnStateChange(new Action<ECiacconaGalPlayerState>(this.OnGalPlayerStateChange));
			ControllerBase<CiacconaGalController>.Instance.SetGalViewReady(true);
			int curHandlingChapterId = ControllerBase<CiacconaGalController>.Instance.GalPlayer.CurHandlingChapterId;
			CiacconaGalChapterData chapterDataById = ModelBase<CiacconaGalModel>.Instance.GetChapterDataById(curHandlingChapterId);
			if (!string.IsNullOrEmpty(chapterDataById.MusicEvent))
			{
				this.MusicHandle = Singleton<AudioSystem>.Instance.PostEvent(chapterDataById.MusicEvent);
			}
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603CFBE RID: 249790 RVA: 0x00F7CD78 File Offset: 0x00F7AF78
		protected override void OnBeforeDestroy()
		{
			ControllerBase<CiacconaGalController>.Instance.SetGalViewReady(false);
			ControllerBase<CiacconaGalController>.Instance.GalPlayer.RemoveOnStateChange(new Action<ECiacconaGalPlayerState>(this.OnGalPlayerStateChange));
			ControllerBase<CiacconaGalController>.Instance.RemoveOnStepDataUpdate(new Action<int>(this.OnDataUpdate));
			if (this.AudioHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.AudioHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(500)
				}));
			}
			if (this.MusicHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.MusicHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(500)
				}));
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnCiacconaAvgInspirationChoiceShow, false);
		}

		// Token: 0x0603CFBF RID: 249791 RVA: 0x00F7CE44 File Offset: 0x00F7B044
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaAvgReChoose, new Action<CiacconaGalStepData, CiacconaGalChoiceData>(this.OnCiacconaAvgReChoose));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaReChooseConfirm, new Action<CiacconaGalStepData, CiacconaGalChoiceData>(this.OnCiacconaAvgReChooseConfirm));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaReChooseCancel, new Action(this.OnCiacconaAvgReChooseCancel));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603CFC0 RID: 249792 RVA: 0x00F7CEC4 File Offset: 0x00F7B0C4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaAvgReChoose, new Action<CiacconaGalStepData, CiacconaGalChoiceData>(this.OnCiacconaAvgReChoose));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaReChooseConfirm, new Action<CiacconaGalStepData, CiacconaGalChoiceData>(this.OnCiacconaAvgReChooseConfirm));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaReChooseCancel, new Action(this.OnCiacconaAvgReChooseCancel));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603CFC1 RID: 249793 RVA: 0x00F7CF44 File Offset: 0x00F7B144
		private void PlayImageChangeAnim(string imagePath)
		{
			this.NextImagePath = imagePath;
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Next", false, null, false);
		}

		// Token: 0x0603CFC2 RID: 249794 RVA: 0x00F7CF78 File Offset: 0x00F7B178
		private UniTask UpdateImageAsync(string path)
		{
			CiacconaGalView.<UpdateImageAsync>d__23 <UpdateImageAsync>d__;
			<UpdateImageAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateImageAsync>d__.<>4__this = this;
			<UpdateImageAsync>d__.path = path;
			<UpdateImageAsync>d__.<>1__state = -1;
			<UpdateImageAsync>d__.<>t__builder.Start<CiacconaGalView.<UpdateImageAsync>d__23>(ref <UpdateImageAsync>d__);
			return <UpdateImageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CFC3 RID: 249795 RVA: 0x00F7CFC4 File Offset: 0x00F7B1C4
		private void WarmUpIcon()
		{
			Singleton<ResourceSystem>.Instance.Load<UTexture>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningIcon01"), this.MemoryTag);
			Singleton<ResourceSystem>.Instance.Load<UTexture>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningIcon02"), this.MemoryTag);
			Singleton<ResourceSystem>.Instance.Load<UTexture>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningIcon03"), this.MemoryTag);
			Singleton<ResourceSystem>.Instance.Load<UTexture>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningIcon04"), this.MemoryTag);
			Singleton<ResourceSystem>.Instance.Load<UTexture>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningIcon05"), this.MemoryTag);
		}

		// Token: 0x0603CFC4 RID: 249796 RVA: 0x00F7D074 File Offset: 0x00F7B274
		private void ShowAvg()
		{
			this.IsViewHide = false;
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Show", false, null, false);
			}
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetUiActive(true);
			}
			CiacconaGalStepPlayerNormalPanel galPanelNormal = this.GalPanelNormal;
			if (galPanelNormal != null)
			{
				galPanelNormal.SetActive(!this.IsReChoosing);
			}
			if (!this.IsReChoosing)
			{
				CiacconaGalStepPlayerNormalPanel galPanelNormal2 = this.GalPanelNormal;
				if (galPanelNormal2 != null)
				{
					galPanelNormal2.PlayStart();
				}
			}
			CiacconaGalStepPlayerReChoosePanel galPanelReChoose = this.GalPanelReChoose;
			if (galPanelReChoose != null)
			{
				galPanelReChoose.SetActive(this.IsReChoosing);
			}
			if (this.IsReChoosing)
			{
				CiacconaGalStepPlayerReChoosePanel galPanelReChoose2 = this.GalPanelReChoose;
				if (galPanelReChoose2 != null)
				{
					galPanelReChoose2.PlayStart();
				}
			}
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
			this.OnGalPlayerStateChange(this.CurState);
		}

		// Token: 0x0603CFC5 RID: 249797 RVA: 0x00F7D144 File Offset: 0x00F7B344
		private void OnDataUpdate(int stepId)
		{
			this.GalPanelNormal.Refresh();
			if (this.CurStepId != stepId)
			{
				this.CurStepId = stepId;
				CiacconaGalStepData stepDataById = ModelBase<CiacconaGalModel>.Instance.GetStepDataById(stepId);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_com_click_small");
				if (!string.IsNullOrEmpty(stepDataById.ImagePath))
				{
					this.PlayImageChangeAnim(stepDataById.ImagePath);
				}
				if (string.IsNullOrEmpty(this.CurImagePath))
				{
					CiacconaGalStepData[] curStepDataList = ModelBase<CiacconaGalModel>.Instance.GetCurStepDataList();
					for (int i = curStepDataList.Length - 1; i >= 0; i--)
					{
						CiacconaGalStepData ciacconaGalStepData = curStepDataList[i];
						if (!string.IsNullOrEmpty(ciacconaGalStepData.ImagePath))
						{
							this.UpdateImageAsync(ciacconaGalStepData.ImagePath).Forget();
							break;
						}
					}
				}
				if (!string.IsNullOrEmpty(stepDataById.AudioEvent))
				{
					if (this.AudioHandle != 0)
					{
						Singleton<AudioSystem>.Instance.ExecuteAction(this.AudioHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
						{
							TransitionDuration = new int?(500)
						}));
					}
					this.AudioHandle = Singleton<AudioSystem>.Instance.PostEvent(stepDataById.AudioEvent);
				}
				if (!string.IsNullOrEmpty(stepDataById.MusicState))
				{
					string musicState = stepDataById.MusicState;
					Singleton<AudioSystem>.Instance.SetState("caccona_gal_music", musicState, true);
				}
				if (stepDataById.SubEndingId != 0)
				{
					CiacconaGalSubEndingData subEndingDataById = ModelBase<CiacconaGalModel>.Instance.GetSubEndingDataById(stepDataById.SubEndingId);
					if ((!subEndingDataById.IsFinished || subEndingDataById.IsFaked) && subEndingDataById.ShouldExitOnFirstFinish)
					{
						this.UiViewSequence.HideSequenceName = "Close02";
						this.UiViewSequence.CloseSequenceName = "Close02";
					}
				}
			}
		}

		// Token: 0x0603CFC6 RID: 249798 RVA: 0x00F7D2C8 File Offset: 0x00F7B4C8
		private void OnGalPlayerStateChange(ECiacconaGalPlayerState state)
		{
			this.CurState = state;
			base.GetItem(4).SetUIActive((state == ECiacconaGalPlayerState.Playing || state == ECiacconaGalPlayerState.Skipping) && !this.IsViewHide);
			base.GetItem(5).SetUIActive(state == ECiacconaGalPlayerState.Pausing && !this.IsViewHide);
		}

		// Token: 0x0603CFC7 RID: 249799 RVA: 0x00F7D318 File Offset: 0x00F7B518
		private void OnClickMask()
		{
			if (this.IsViewHide)
			{
				this.ShowAvg();
				return;
			}
			ControllerBase<CiacconaGalController>.Instance.GalPlayer.OnClick(null);
		}

		// Token: 0x0603CFC8 RID: 249800 RVA: 0x00F7D34C File Offset: 0x00F7B54C
		private void OnCiacconaAvgReChoose(CiacconaGalStepData stepData, CiacconaGalChoiceData choiceData)
		{
			if (this.IsViewHide)
			{
				return;
			}
			this.GalPanelNormal.PlayCloseAsync().Forget();
			this.GalPanelReChoose.SetActive(true);
			this.GalPanelReChoose.PlayStart();
			this.GalPanelReChoose.Refresh(stepData, choiceData);
			this.IsReChoosing = true;
		}

		// Token: 0x0603CFC9 RID: 249801 RVA: 0x00F7D3A0 File Offset: 0x00F7B5A0
		private void OnCiacconaAvgReChooseConfirm(CiacconaGalStepData stepData, CiacconaGalChoiceData choiceData)
		{
			if (this.IsViewHide)
			{
				return;
			}
			this.GalPanelNormal.SetActive(true);
			this.GalPanelNormal.PlayStart();
			this.GalPanelReChoose.PlayCloseAsync().Forget();
			stepData.ChosenId = choiceData.Id;
			int toStepId = (choiceData.ToStepId == 0) ? stepData.NextStepId : choiceData.ToStepId;
			ControllerBase<CiacconaGalController>.Instance.GalPlayer.TryContinue(toStepId);
			this.IsReChoosing = false;
		}

		// Token: 0x0603CFCA RID: 249802 RVA: 0x00F7D417 File Offset: 0x00F7B617
		private void OnCiacconaAvgReChooseCancel()
		{
			if (this.IsViewHide)
			{
				return;
			}
			this.GalPanelNormal.SetActive(true);
			this.GalPanelNormal.PlayStart();
			this.GalPanelReChoose.PlayCloseAsync().Forget();
			this.IsReChoosing = false;
		}

		// Token: 0x0603CFCB RID: 249803 RVA: 0x00F7D450 File Offset: 0x00F7B650
		private void HideAvg()
		{
			this.IsViewHide = true;
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Hide", false, null, false);
			}
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetUiActive(false);
			}
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			if (this.IsReChoosing)
			{
				CiacconaGalStepPlayerReChoosePanel galPanelReChoose = this.GalPanelReChoose;
				if (galPanelReChoose == null)
				{
					return;
				}
				galPanelReChoose.PlayCloseAsync().Forget();
				return;
			}
			else
			{
				CiacconaGalStepPlayerNormalPanel galPanelNormal = this.GalPanelNormal;
				if (galPanelNormal == null)
				{
					return;
				}
				galPanelNormal.PlayCloseAsync().Forget();
				return;
			}
		}

		// Token: 0x0603CFCC RID: 249804 RVA: 0x00F7D500 File Offset: 0x00F7B700
		private void OnExit()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CiacconaAvgExit);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				if (ControllerBase<CiacconaGalController>.Instance.GalPlayer.GetCurState() == ECiacconaGalPlayerState.SubEnding)
				{
					ControllerBase<CiacconaGalController>.Instance.ExitAvg().Forget();
					return;
				}
				base.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603CFCD RID: 249805 RVA: 0x00F7D53C File Offset: 0x00F7B73C
		private void OnActivitySequenceEmitEvent(string eventName)
		{
			if (eventName == "Change")
			{
				this.UpdateImageAsync(this.NextImagePath).Forget();
			}
		}

		// Token: 0x0603CFCE RID: 249806 RVA: 0x00F7D55C File Offset: 0x00F7B75C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "ChoicesSelect" || a == "FirstChoice")
			{
				return this.GalPanelNormal.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			if (a == "Inspiration")
			{
				CiacconaTitleInspirationItem ciacconaTitleItem = this.CiacconaTitleItem;
				UUIItem uuiitem = (ciacconaTitleItem != null) ? ciacconaTitleItem.GetRootItem() : null;
				if (uuiitem != null)
				{
					return new UUIItem[]
					{
						uuiitem,
						uuiitem
					};
				}
			}
			return null;
		}

		// Token: 0x0402239E RID: 140190
		private CiacconaGalStepPlayerNormalPanel GalPanelNormal;

		// Token: 0x0402239F RID: 140191
		private CiacconaGalStepPlayerReChoosePanel GalPanelReChoose;

		// Token: 0x040223A0 RID: 140192
		private PopupCaptionItem CaptionItem;

		// Token: 0x040223A1 RID: 140193
		private CiacconaTitleInspirationItem CiacconaTitleItem;

		// Token: 0x040223A2 RID: 140194
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x040223A3 RID: 140195
		private int CurStepId;

		// Token: 0x040223A4 RID: 140196
		private int AudioHandle;

		// Token: 0x040223A5 RID: 140197
		private string CurImagePath;

		// Token: 0x040223A6 RID: 140198
		private int MusicHandle;

		// Token: 0x040223A7 RID: 140199
		private string NextImagePath;

		// Token: 0x040223A8 RID: 140200
		private bool IsViewHide;

		// Token: 0x040223A9 RID: 140201
		private bool IsReChoosing;

		// Token: 0x040223AA RID: 140202
		private ECiacconaGalPlayerState CurState;

		// Token: 0x0200BEC1 RID: 48833
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB63 RID: 240483
			public const int ItemCaption = 0;

			// Token: 0x0403AB64 RID: 240484
			public const int ItemContent = 1;

			// Token: 0x0403AB65 RID: 240485
			public const int BtnMask = 2;

			// Token: 0x0403AB66 RID: 240486
			public const int TextureImage = 3;

			// Token: 0x0403AB67 RID: 240487
			public const int ItemOnGoing = 4;

			// Token: 0x0403AB68 RID: 240488
			public const int ItemContinue = 5;

			// Token: 0x0403AB69 RID: 240489
			public const int BtnHide = 6;
		}
	}
}
