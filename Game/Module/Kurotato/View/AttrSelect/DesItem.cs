using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AD1 RID: 23249
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class DesItem : SyncGridProxyAbstract<string>
	{
		// Token: 0x0603AC8C RID: 240780 RVA: 0x00EE8520 File Offset: 0x00EE6720
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

		// Token: 0x0603AC8D RID: 240781 RVA: 0x00EE8568 File Offset: 0x00EE6768
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

		// Token: 0x0603AC8E RID: 240782 RVA: 0x00EE85A3 File Offset: 0x00EE67A3
		[NullableContext(1)]
		public override void Refresh(string data)
		{
			base.GetText(0).SetText(data, true);
		}

		// Token: 0x0200BAF7 RID: 47863
		private class EDesItemComp
		{
			// Token: 0x04039B63 RID: 236387
			public const int TextDes = 0;
		}
	}
}
