using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053C6 RID: 21446
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotReviewTalkItem : UiPanelBase
	{
		// Token: 0x06036AFB RID: 223995 RVA: 0x00DDB83C File Offset: 0x00DD9A3C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnToggleClickInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06036AFC RID: 223996 RVA: 0x00DDB924 File Offset: 0x00DD9B24
		protected override void OnStart()
		{
			base.GetExtendToggle(3).CanExecuteChange.Bind(new Func<bool>(this.CanToggleChangeInternal));
		}

		// Token: 0x06036AFD RID: 223997 RVA: 0x00DDB943 File Offset: 0x00DD9B43
		protected override void OnBeforeDestroy()
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(1));
		}

		// Token: 0x06036AFE RID: 223998 RVA: 0x00DDB956 File Offset: 0x00DD9B56
		private void OnToggleClickInternal(EToggleState toggleState)
		{
			Action<int> onToggleClick = this.OnToggleClick;
			if (onToggleClick == null)
			{
				return;
			}
			onToggleClick(this.Index);
		}

		// Token: 0x06036AFF RID: 223999 RVA: 0x00DDB96E File Offset: 0x00DD9B6E
		private bool CanToggleChangeInternal()
		{
			return this.CanToggleChange == null || this.CanToggleChange(this.Index);
		}

		// Token: 0x06036B00 RID: 224000 RVA: 0x00DDB98C File Offset: 0x00DD9B8C
		[NullableContext(1)]
		public void Update(PlotReviewTalkItemData data, int index)
		{
			UUIText text = base.GetText(1);
			if (ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text))
			{
				ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(text);
			}
			ITermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = text,
				ViewType = ETermExplanationViewType.Center,
				Group = new ETermExplanationGroup?(ETermExplanationGroup.PlotReview),
				Priority = new int?(index),
				ReportType = ETermExplanationReportType.PlotReview
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
			this.Data = data;
			this.Index = index;
			this.Refresh();
		}

		// Token: 0x06036B01 RID: 224001 RVA: 0x00DDBA0C File Offset: 0x00DD9C0C
		public void Refresh()
		{
			this.RefreshName();
			this.RefreshContent();
			this.RefreshAudio();
		}

		// Token: 0x06036B02 RID: 224002 RVA: 0x00DDBA20 File Offset: 0x00DD9C20
		public void RefreshName()
		{
			PlotReviewTalkItemData data = this.Data;
			ITalkItemDialog talkItemDialog = ((data != null) ? data.TalkItem : null) as ITalkItemDialog;
			string text;
			if (talkItemDialog != null)
			{
				ETalkItemType? type = talkItemDialog.Type;
				ETalkItemType etalkItemType = ETalkItemType.Talk;
				if (type.GetValueOrDefault() == etalkItemType & type != null)
				{
					ITalkItemStyle style = talkItemDialog.Style;
					if (style != null && style.Type == ETalkItemStyle.InnerVoice)
					{
						text = ConfigMultiTextLang.GetLocalTextNew("PlotReview_3", null);
						goto IL_F8;
					}
				}
			}
			Speaker? config = ConfigSpeakerById.GetConfig(((talkItemDialog != null) ? talkItemDialog.WhoId : null).GetValueOrDefault(), true);
			string text2 = (config != null) ? Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(config.Value.Id)) : null;
			string text3 = (config != null) ? Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerTitle, new int?(config.Value.Id)) : null;
			text = (string.IsNullOrEmpty(text2) ? text3 : text2);
			IL_F8:
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "PlotReview_1", new <>z__ReadOnlySingleElementList<object>(text ?? ""));
		}

		// Token: 0x06036B03 RID: 224003 RVA: 0x00DDBB4C File Offset: 0x00DD9D4C
		public void RefreshContent()
		{
			string tidTalk = this.Data.TalkItem.TidTalk;
			if (string.IsNullOrEmpty(tidTalk))
			{
				return;
			}
			string text = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(tidTalk);
			text = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(text, false);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x06036B04 RID: 224004 RVA: 0x00DDBBA8 File Offset: 0x00DD9DA8
		public void RefreshAudio()
		{
			ITalkItem talkItem = this.Data.TalkItem;
			this.CanPlayVoice = talkItem.PlayVoice.GetValueOrDefault();
			base.GetSprite(2).SetUIActive(this.CanPlayVoice);
			EToggleState toggleState = this.Data.IsPlaying ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			this.SetToggleState(toggleState);
		}

		// Token: 0x06036B05 RID: 224005 RVA: 0x00DDBC00 File Offset: 0x00DD9E00
		public void SetToggleState(EToggleState state)
		{
			base.GetExtendToggle(3).SetToggleState(state, false, false, false);
		}

		// Token: 0x0401F803 RID: 129027
		protected int Index = -1;

		// Token: 0x0401F804 RID: 129028
		private PlotReviewTalkItemData Data;

		// Token: 0x0401F805 RID: 129029
		public Action<int> OnToggleClick;

		// Token: 0x0401F806 RID: 129030
		public Func<int, bool> CanToggleChange;

		// Token: 0x0401F807 RID: 129031
		private bool CanPlayVoice;
	}
}
