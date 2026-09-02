using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA4 RID: 23460
	public class InteractionGuide : UiPanelBase
	{
		// Token: 0x0603B568 RID: 243048 RVA: 0x00F07570 File Offset: 0x00F05770
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B569 RID: 243049 RVA: 0x00F075D9 File Offset: 0x00F057D9
		protected override void OnStart()
		{
			this.SetActive(false);
		}

		// Token: 0x0603B56A RID: 243050 RVA: 0x00F075E2 File Offset: 0x00F057E2
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603B56B RID: 243051 RVA: 0x00F075E4 File Offset: 0x00F057E4
		[NullableContext(1)]
		public void Refresh(string textId)
		{
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalText(text, textId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.ReplaceWildCard(text);
			this.SetActive(true);
		}

		// Token: 0x0603B56C RID: 243052 RVA: 0x00F0761C File Offset: 0x00F0581C
		public void RefreshTextWidth()
		{
			UUIText text = base.GetText(1);
			if (text == null || !text.IsValid())
			{
				return;
			}
			if (text.GetWidth() > 760f)
			{
				text.SetWidth(760f);
				text.SetOverflowType(UITextOverflowType.VerticalOverflow);
			}
		}

		// Token: 0x04021710 RID: 136976
		private const int INTERACT_GUIDE_MAX_TEXT_WIDTH = 760;

		// Token: 0x0200BBD5 RID: 48085
		internal class EChildType
		{
			// Token: 0x04039F4A RID: 237386
			public const int GuideItem = 0;

			// Token: 0x04039F4B RID: 237387
			public const int GuideText = 1;
		}
	}
}
