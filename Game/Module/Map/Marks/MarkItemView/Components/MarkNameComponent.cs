using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A8 RID: 22696
	public class MarkNameComponent : MarkPanelBase
	{
		// Token: 0x06039AAF RID: 236207 RVA: 0x00E9F5D8 File Offset: 0x00E9D7D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039AB0 RID: 236208 RVA: 0x00E9F620 File Offset: 0x00E9D820
		protected override void OnBeforeShow()
		{
			this.UpdateName();
		}

		// Token: 0x06039AB1 RID: 236209 RVA: 0x00E9F628 File Offset: 0x00E9D828
		[NullableContext(1)]
		public void SetNameParam(IMarkItemParam param)
		{
			this.Params = param;
			if (base.IsShowOrShowing)
			{
				this.UpdateName();
			}
		}

		// Token: 0x06039AB2 RID: 236210 RVA: 0x00E9F640 File Offset: 0x00E9D840
		private void UpdateName()
		{
			if (this.Params == null)
			{
				return;
			}
			UUIText text = base.GetText(0);
			if (!ObjectUtils.IsValid(text))
			{
				return;
			}
			if (this.Params.FontSize != null)
			{
				text.SetFontSize((float)this.Params.FontSize.Value);
			}
			if (this.Params.AnchorOffset != null)
			{
				text.SetAnchorOffset(this.Params.AnchorOffset.Value);
			}
			if (this.Params.OutlineSize != null)
			{
				text.outlineSize = (int)this.Params.OutlineSize.Value;
			}
			if (this.Params.OutlineColor != null)
			{
				text.SetFontOutlineColor(this.Params.OutlineColor.Value);
			}
			text.SetText(this.Params.Txt, true);
		}

		// Token: 0x04020AF6 RID: 133878
		[Nullable(2)]
		private IMarkItemParam Params;

		// Token: 0x0200B8D9 RID: 47321
		public static class EChildComponents
		{
			// Token: 0x04039232 RID: 234034
			public const int NameText = 0;
		}
	}
}
