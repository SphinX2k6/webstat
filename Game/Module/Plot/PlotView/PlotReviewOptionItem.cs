using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053C7 RID: 21447
	public class PlotReviewOptionItem : UiPanelBase
	{
		// Token: 0x06036B07 RID: 224007 RVA: 0x00DDBC24 File Offset: 0x00DD9E24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036B08 RID: 224008 RVA: 0x00DDBC90 File Offset: 0x00DD9E90
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "PlotReview_2", Array.Empty<object>());
			ITermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(1),
				ViewType = ETermExplanationViewType.Center,
				Group = new ETermExplanationGroup?(ETermExplanationGroup.PlotReview),
				ReportType = ETermExplanationReportType.PlotReview
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		}

		// Token: 0x06036B09 RID: 224009 RVA: 0x00DDBCF1 File Offset: 0x00DD9EF1
		protected override void OnBeforeHide()
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(1));
		}

		// Token: 0x06036B0A RID: 224010 RVA: 0x00DDBD04 File Offset: 0x00DD9F04
		[NullableContext(1)]
		public void Update(PlotReviewOptionItemData data, int index)
		{
			this.Data = data;
			this.Index = index;
			this.Refresh();
		}

		// Token: 0x06036B0B RID: 224011 RVA: 0x00DDBD1C File Offset: 0x00DD9F1C
		public void Refresh()
		{
			ITalkItem talkItem = this.Data.TalkItem;
			if (talkItem == null)
			{
				return;
			}
			List<ITalkOption> options = talkItem.Options;
			if (options == null)
			{
				return;
			}
			int optionIndex = this.Data.OptionIndex;
			if (optionIndex < 0)
			{
				return;
			}
			ITalkOption talkOption = options[optionIndex];
			string text = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkOption.TidTalkOption);
			text = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(text, false);
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x0401F808 RID: 129032
		protected int Index = -1;

		// Token: 0x0401F809 RID: 129033
		[Nullable(2)]
		private PlotReviewOptionItemData Data;

		// Token: 0x0200B33C RID: 45884
		private static class EPlotReviewOptionItemComponent
		{
			// Token: 0x04037864 RID: 227428
			public const int NameText = 0;

			// Token: 0x04037865 RID: 227429
			public const int ContentText = 1;
		}
	}
}
