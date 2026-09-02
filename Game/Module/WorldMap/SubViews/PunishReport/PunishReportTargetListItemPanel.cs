using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.PunishReport
{
	// Token: 0x02004B90 RID: 19344
	[NullableContext(1)]
	[Nullable(0)]
	public class PunishReportTargetListItemPanel : UiPanelBase
	{
		// Token: 0x06032861 RID: 206945 RVA: 0x00CA5AC8 File Offset: 0x00CA3CC8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032862 RID: 206946 RVA: 0x00CA5B74 File Offset: 0x00CA3D74
		public void SetDescLocalNewTxt(string txtKey)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, txtKey, Array.Empty<object>());
		}

		// Token: 0x06032863 RID: 206947 RVA: 0x00CA5B9A File Offset: 0x00CA3D9A
		public void SetDescTxt(string txt)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(txt, true);
		}

		// Token: 0x06032864 RID: 206948 RVA: 0x00CA5BAF File Offset: 0x00CA3DAF
		public void SetNumTxt(string txt)
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(txt, true);
		}

		// Token: 0x06032865 RID: 206949 RVA: 0x00CA5BC4 File Offset: 0x00CA3DC4
		public void SetState(EPunishReportTargetListItemPanelState state)
		{
			string text;
			switch (state)
			{
			case EPunishReportTargetListItemPanelState.Lock:
				text = "T_MapDifficultyLock";
				break;
			case EPunishReportTargetListItemPanelState.Empty:
				text = "T_MapDifficultyEmpty";
				break;
			case EPunishReportTargetListItemPanelState.Selected:
				text = "T_MapDifficultyTick";
				break;
			default:
				text = "";
				break;
			}
			string resourceId = text;
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
		}

		// Token: 0x0200AC67 RID: 44135
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x0403599A RID: 219546
			public const int TxtL = 0;

			// Token: 0x0403599B RID: 219547
			public const int TexState = 1;

			// Token: 0x0403599C RID: 219548
			public const int PnlGift = 2;

			// Token: 0x0403599D RID: 219549
			public const int TxtLNum = 3;
		}
	}
}
