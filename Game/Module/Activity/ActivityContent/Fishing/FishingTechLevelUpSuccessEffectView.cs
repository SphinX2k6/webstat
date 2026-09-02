using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006830 RID: 26672
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingTechLevelUpSuccessEffectView : UiViewBase
	{
		// Token: 0x060427F4 RID: 272372 RVA: 0x01111577 File Offset: 0x0110F777
		public FishingTechLevelUpSuccessEffectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060427F5 RID: 272373 RVA: 0x01111580 File Offset: 0x0110F780
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060427F6 RID: 272374 RVA: 0x011116CD File Offset: 0x0110F8CD
		protected override void OnBeforeCreate()
		{
			if (this.OpenParam == null)
			{
				return;
			}
			this.Data = (this.OpenParam as LevelUpSuccessEffectData);
			this.SetAudio();
		}

		// Token: 0x060427F7 RID: 272375 RVA: 0x011116F0 File Offset: 0x0110F8F0
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(1);
			this.EffectTextLayout = new GenericScrollViewNew<SuccessDescriptionItem, SingleText>(base.GetScrollViewWithScrollbar(0), new Func<SuccessDescriptionItem>(this.CreateTextItem), item.GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x060427F8 RID: 272376 RVA: 0x01111730 File Offset: 0x0110F930
		protected override void OnBeforeShow()
		{
			this.SetTitle();
			this.SetViewContent();
			this.SetTipsText();
		}

		// Token: 0x060427F9 RID: 272377 RVA: 0x01111744 File Offset: 0x0110F944
		private void SetAudio()
		{
			LevelUpSuccessEffectData data = this.Data;
			string text = (data != null) ? data.AudioId : null;
			if (!StringUtils.IsEmpty(text))
			{
				Audio? audio;
				string audioEvent = (ConfigBase<AudioConfig>.Instance.GetAudioPath(text) != null) ? audio.GetValueOrDefault().Path : null;
				base.SetAudioEvent(audioEvent);
			}
		}

		// Token: 0x060427FA RID: 272378 RVA: 0x0111179C File Offset: 0x0110F99C
		private void OnClickButton()
		{
			LevelUpSuccessEffectData data = this.Data;
			Action action = (data != null) ? data.ClickFunction : null;
			if (action != null)
			{
				action();
			}
			base.CloseMe(null);
		}

		// Token: 0x060427FB RID: 272379 RVA: 0x011117CC File Offset: 0x0110F9CC
		private SuccessDescriptionItem CreateTextItem()
		{
			return new SuccessDescriptionItem();
		}

		// Token: 0x060427FC RID: 272380 RVA: 0x011117D4 File Offset: 0x0110F9D4
		private void SetTipsText()
		{
			LevelUpSuccessEffectData data = this.Data;
			string key = ((data != null) ? data.ClickText : null) ?? "Text_BackToView_Text";
			base.GetText(3).ShowTextNew(key);
		}

		// Token: 0x060427FD RID: 272381 RVA: 0x0111180C File Offset: 0x0110FA0C
		private void SetTitle()
		{
			LevelUpSuccessEffectData data = this.Data;
			string key = ((data != null) ? data.Title : null) ?? "Text_ActivedSucceed_Text";
			base.GetText(2).ShowTextNew(key);
		}

		// Token: 0x060427FE RID: 272382 RVA: 0x01111844 File Offset: 0x0110FA44
		private void SetViewContent()
		{
			if (this.EffectTextLayout != null)
			{
				LevelUpSuccessEffectData data = this.Data;
				List<SingleText> list = (data != null) ? data.TextList : null;
				if (list != null)
				{
					base.GetScrollViewWithScrollbar(0).RootUIComp.Get().SetUIActive(true);
					this.EffectTextLayout.RefreshByData(list, null, false);
					return;
				}
				base.GetScrollViewWithScrollbar(0).RootUIComp.Get().SetUIActive(false);
			}
		}

		// Token: 0x04025037 RID: 151607
		private LevelUpSuccessEffectData Data;

		// Token: 0x04025038 RID: 151608
		private GenericScrollViewNew<SuccessDescriptionItem, SingleText> EffectTextLayout;

		// Token: 0x0200C870 RID: 51312
		[NullableContext(0)]
		private class ERoleSuccessEffectNode
		{
			// Token: 0x0403DB1A RID: 252698
			public const int TextScrollLayout = 0;

			// Token: 0x0403DB1B RID: 252699
			public const int TextItem = 1;

			// Token: 0x0403DB1C RID: 252700
			public const int Title = 2;

			// Token: 0x0403DB1D RID: 252701
			public const int TipsText = 3;

			// Token: 0x0403DB1E RID: 252702
			public const int TipsButton = 4;

			// Token: 0x0403DB1F RID: 252703
			public const int TipsButton2 = 5;
		}
	}
}
