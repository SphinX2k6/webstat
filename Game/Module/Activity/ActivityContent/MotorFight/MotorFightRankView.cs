using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066F1 RID: 26353
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorFightRankView : UiViewBase
	{
		// Token: 0x06041C81 RID: 269441 RVA: 0x010DFF18 File Offset: 0x010DE118
		[NullableContext(1)]
		public MotorFightRankView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C82 RID: 269442 RVA: 0x010DFF24 File Offset: 0x010DE124
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C83 RID: 269443 RVA: 0x010DFFD0 File Offset: 0x010DE1D0
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightRankView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightRankView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C84 RID: 269444 RVA: 0x010E0013 File Offset: 0x010DE213
		[NullableContext(1)]
		private MotorFightRankItem CreateItem()
		{
			return new MotorFightRankItem();
		}

		// Token: 0x06041C85 RID: 269445 RVA: 0x010E001A File Offset: 0x010DE21A
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024B2A RID: 150314
		private MotorFightActivityData MotorFightActivityData;

		// Token: 0x04024B2B RID: 150315
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B2C RID: 150316
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<MotorFightRankItem, MotorFightRankData> RankScrollView;

		// Token: 0x04024B2D RID: 150317
		private MotorFightRankItem MyRankItem;

		// Token: 0x0200C737 RID: 50999
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D551 RID: 251217
			public const int ItemCaption = 0;

			// Token: 0x0403D552 RID: 251218
			public const int LoopViewRank = 1;

			// Token: 0x0403D553 RID: 251219
			public const int ItemRank = 2;

			// Token: 0x0403D554 RID: 251220
			public const int ItemMyRank = 3;
		}
	}
}
