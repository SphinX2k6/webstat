using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E06 RID: 7686
public class PunishReportView : UiViewBase
{
	// Token: 0x0600E2F8 RID: 58104 RVA: 0x003D2347 File Offset: 0x003D0547
	[NullableContext(1)]
	public PunishReportView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E2F9 RID: 58105 RVA: 0x003D2350 File Offset: 0x003D0550
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E2FA RID: 58106 RVA: 0x003D23BC File Offset: 0x003D05BC
	protected override void OnStart()
	{
		this.UiViewSequence.AddSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd), false);
		IPunishReport punishReport = this.OpenParam as IPunishReport;
		if (punishReport == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(punishReport.MainText))
		{
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(punishReport.MainText);
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(configTextByKey, true);
			}
		}
		if (!string.IsNullOrEmpty(punishReport.SubText))
		{
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(punishReport.SubText);
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(configTextByKey2, true);
		}
	}

	// Token: 0x0600E2FB RID: 58107 RVA: 0x003D245F File Offset: 0x003D065F
	[NullableContext(1)]
	private void OnStartSequenceEnd(string _)
	{
		this.UiViewSequence.RemoveSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd));
		base.CloseMe(null);
	}

	// Token: 0x02008173 RID: 33139
	private static class EViewComponent
	{
		// Token: 0x0402BF87 RID: 180103
		public const int TitleText = 0;

		// Token: 0x0402BF88 RID: 180104
		public const int DescribeText = 1;
	}
}
