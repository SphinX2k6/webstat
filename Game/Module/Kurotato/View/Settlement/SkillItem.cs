using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A86 RID: 23174
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class SkillItem : GridProxyAbstract<string>
	{
		// Token: 0x0603AA2B RID: 240171 RVA: 0x00EDADD0 File Offset: 0x00ED8FD0
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

		// Token: 0x0603AA2C RID: 240172 RVA: 0x00EDAE18 File Offset: 0x00ED9018
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

		// Token: 0x0603AA2D RID: 240173 RVA: 0x00EDAE53 File Offset: 0x00ED9053
		[NullableContext(1)]
		public override void Refresh(string data, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText(data, true);
		}

		// Token: 0x0200BA63 RID: 47715
		private class ESkillComps
		{
			// Token: 0x040398CC RID: 235724
			public const int TextDes = 0;
		}
	}
}
