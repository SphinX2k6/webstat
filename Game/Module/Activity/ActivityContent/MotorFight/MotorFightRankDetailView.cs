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
	// Token: 0x020066D0 RID: 26320
	public class MotorFightRankDetailView : UiViewBase
	{
		// Token: 0x06041BA9 RID: 269225 RVA: 0x010DAE2C File Offset: 0x010D902C
		[NullableContext(1)]
		public MotorFightRankDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041BAA RID: 269226 RVA: 0x010DAE38 File Offset: 0x010D9038
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041BAB RID: 269227 RVA: 0x010DAFAC File Offset: 0x010D91AC
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightRankDetailView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightRankDetailView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041BAC RID: 269228 RVA: 0x010DAFEF File Offset: 0x010D91EF
		[NullableContext(1)]
		private MotorFightItemSmallGrid CreateItem()
		{
			return new MotorFightItemSmallGrid();
		}

		// Token: 0x06041BAD RID: 269229 RVA: 0x010DAFF6 File Offset: 0x010D91F6
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024AD5 RID: 150229
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024AD6 RID: 150230
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<MotorFightItemSmallGrid, MotorFightItemData> ItemLoopScrollView;

		// Token: 0x0200C6FE RID: 50942
		private class EComponent
		{
			// Token: 0x0403D435 RID: 250933
			public const int ItemCaption = 0;

			// Token: 0x0403D436 RID: 250934
			public const int TextTitle = 1;

			// Token: 0x0403D437 RID: 250935
			public const int TextureRole = 2;

			// Token: 0x0403D438 RID: 250936
			public const int TextPlayerName = 3;

			// Token: 0x0403D439 RID: 250937
			public const int TextScore = 4;

			// Token: 0x0403D43A RID: 250938
			public const int TextWaveNum = 5;

			// Token: 0x0403D43B RID: 250939
			public const int TextKillNum = 6;

			// Token: 0x0403D43C RID: 250940
			public const int TextBuffGateNum = 7;

			// Token: 0x0403D43D RID: 250941
			public const int LoopScrollViewItem = 8;

			// Token: 0x0403D43E RID: 250942
			public const int ItemBase = 9;

			// Token: 0x0403D43F RID: 250943
			public const int ItemEmptyPanel = 10;
		}
	}
}
