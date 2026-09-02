using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A9D RID: 23197
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SkillInfoItem : GridProxyAbstract<string>
	{
		// Token: 0x0603AB08 RID: 240392 RVA: 0x00EDFF6C File Offset: 0x00EDE16C
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

		// Token: 0x0603AB09 RID: 240393 RVA: 0x00EDFFB4 File Offset: 0x00EDE1B4
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

		// Token: 0x0603AB0A RID: 240394 RVA: 0x00EDFFEF File Offset: 0x00EDE1EF
		[NullableContext(1)]
		public override void Refresh(string text, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText(text, true);
		}

		// Token: 0x0200BA9B RID: 47771
		private enum ESkillInfoComp
		{
			// Token: 0x040399E5 RID: 236005
			TextSkillInfo
		}
	}
}
