using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x0200659E RID: 26014
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballRankView : UiViewBase
	{
		// Token: 0x06040FF9 RID: 266233 RVA: 0x010ADA9B File Offset: 0x010ABC9B
		[NullableContext(1)]
		public PinballRankView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040FFA RID: 266234 RVA: 0x010ADAA4 File Offset: 0x010ABCA4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040FFB RID: 266235 RVA: 0x010ADB70 File Offset: 0x010ABD70
		protected override UniTask OnBeforeStartAsync()
		{
			PinballRankView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballRankView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040FFC RID: 266236 RVA: 0x010ADBB3 File Offset: 0x010ABDB3
		[NullableContext(1)]
		private PinballRankItem CreateItem()
		{
			return new PinballRankItem();
		}

		// Token: 0x06040FFD RID: 266237 RVA: 0x010ADBBA File Offset: 0x010ABDBA
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040FFE RID: 266238 RVA: 0x010ADBC3 File Offset: 0x010ABDC3
		private void OnHelpBtnClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(557);
		}

		// Token: 0x04024721 RID: 149281
		private PinballActivityData PinballActivityData;

		// Token: 0x04024722 RID: 149282
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024723 RID: 149283
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<PinballRankItem, PinballRankData> RankScrollView;

		// Token: 0x04024724 RID: 149284
		private PinballRankItem MyRankItem;

		// Token: 0x0200C594 RID: 50580
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CCF0 RID: 249072
			ItemCaption,
			// Token: 0x0403CCF1 RID: 249073
			LoopViewRank,
			// Token: 0x0403CCF2 RID: 249074
			ItemRank,
			// Token: 0x0403CCF3 RID: 249075
			ItemMyRank,
			// Token: 0x0403CCF4 RID: 249076
			Content
		}
	}
}
