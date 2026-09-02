using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F12 RID: 20242
	public class PreviewMinoItem : UiPanelBase
	{
		// Token: 0x06034507 RID: 214279 RVA: 0x00D17218 File Offset: 0x00D15418
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034508 RID: 214280 RVA: 0x00D17260 File Offset: 0x00D15460
		protected override void OnStart()
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetWidth(this.RootItem.GetWidth());
			}
			UUISprite sprite2 = base.GetSprite(0);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetHeight(this.RootItem.GetHeight());
		}

		// Token: 0x06034509 RID: 214281 RVA: 0x00D1729C File Offset: 0x00D1549C
		[NullableContext(1)]
		public UniTask StartShow(SlidingBlocksDefine.ETetrominoBorad tetrominoType, string styleName, double x, double y)
		{
			PreviewMinoItem.<StartShow>d__5 <StartShow>d__;
			<StartShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartShow>d__.<>4__this = this;
			<StartShow>d__.tetrominoType = tetrominoType;
			<StartShow>d__.styleName = styleName;
			<StartShow>d__.x = x;
			<StartShow>d__.y = y;
			<StartShow>d__.<>1__state = -1;
			<StartShow>d__.<>t__builder.Start<PreviewMinoItem.<StartShow>d__5>(ref <StartShow>d__);
			return <StartShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603450A RID: 214282 RVA: 0x00D17300 File Offset: 0x00D15500
		public UniTask EndShow()
		{
			PreviewMinoItem.<EndShow>d__6 <EndShow>d__;
			<EndShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndShow>d__.<>4__this = this;
			<EndShow>d__.<>1__state = -1;
			<EndShow>d__.<>t__builder.Start<PreviewMinoItem.<EndShow>d__6>(ref <EndShow>d__);
			return <EndShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603450B RID: 214283 RVA: 0x00D17344 File Offset: 0x00D15544
		[NullableContext(1)]
		private PreviewMinoItem.CoordOffset GetCoordOffset(SlidingBlocksDefine.ETetrominoBorad boardType)
		{
			PreviewMinoItem.CoordOffset coordOffset = new PreviewMinoItem.CoordOffset
			{
				X = 0.0,
				Y = 0.0
			};
			switch (boardType)
			{
			case SlidingBlocksDefine.ETetrominoBorad.二乘二:
				coordOffset.X = 1.5;
				coordOffset.Y = 1.5;
				break;
			case SlidingBlocksDefine.ETetrominoBorad.三乘三:
				coordOffset.X = 1.0;
				coordOffset.Y = 1.0;
				break;
			case SlidingBlocksDefine.ETetrominoBorad.四乘四:
				coordOffset.X = 0.5;
				coordOffset.Y = 0.5;
				break;
			}
			return coordOffset;
		}

		// Token: 0x0401E2D9 RID: 123609
		public bool IsUse;

		// Token: 0x0200AF44 RID: 44868
		[RequiredMember]
		private class CoordOffset
		{
			// Token: 0x1700A958 RID: 43352
			// (get) Token: 0x0604C230 RID: 311856 RVA: 0x014CDAB6 File Offset: 0x014CBCB6
			// (set) Token: 0x0604C231 RID: 311857 RVA: 0x014CDABE File Offset: 0x014CBCBE
			[RequiredMember]
			public double X { get; set; }

			// Token: 0x1700A959 RID: 43353
			// (get) Token: 0x0604C232 RID: 311858 RVA: 0x014CDAC7 File Offset: 0x014CBCC7
			// (set) Token: 0x0604C233 RID: 311859 RVA: 0x014CDACF File Offset: 0x014CBCCF
			[RequiredMember]
			public double Y { get; set; }

			// Token: 0x0604C234 RID: 311860 RVA: 0x014CDAD8 File Offset: 0x014CBCD8
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public CoordOffset()
			{
			}
		}

		// Token: 0x0200AF45 RID: 44869
		private enum EViewComponent
		{
			// Token: 0x0403663A RID: 222778
			Sprite
		}
	}
}
