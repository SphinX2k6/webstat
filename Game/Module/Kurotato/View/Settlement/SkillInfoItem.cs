using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A78 RID: 23160
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class SkillInfoItem : GridProxyAbstract<string>
	{
		// Token: 0x0603A9B9 RID: 240057 RVA: 0x00ED84A0 File Offset: 0x00ED66A0
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

		// Token: 0x0603A9BA RID: 240058 RVA: 0x00ED84E8 File Offset: 0x00ED66E8
		protected override void OnStart()
		{
			TermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(0),
				ViewType = ETermExplanationViewType.Center,
				ReportType = ETermExplanationReportType.Kurotato
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		}

		// Token: 0x0603A9BB RID: 240059 RVA: 0x00ED8523 File Offset: 0x00ED6723
		[NullableContext(1)]
		public override void Refresh(string text, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText(text, true);
		}

		// Token: 0x0200BA3F RID: 47679
		private class ESkillInfoComp
		{
			// Token: 0x04039840 RID: 235584
			public const int TextSkillInfo = 0;
		}
	}
}
