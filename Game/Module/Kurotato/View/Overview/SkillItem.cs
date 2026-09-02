using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A9B RID: 23195
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SkillItem : GridProxyAbstract<string>
	{
		// Token: 0x0603AAFD RID: 240381 RVA: 0x00EDFA84 File Offset: 0x00EDDC84
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

		// Token: 0x0603AAFE RID: 240382 RVA: 0x00EDFACC File Offset: 0x00EDDCCC
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

		// Token: 0x0603AAFF RID: 240383 RVA: 0x00EDFB07 File Offset: 0x00EDDD07
		[NullableContext(1)]
		public override void Refresh(string descText, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText(descText, true);
		}

		// Token: 0x0200BA95 RID: 47765
		private enum ESkillComps
		{
			// Token: 0x040399CD RID: 235981
			TextName
		}
	}
}
