using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002AB4 RID: 10932
public class SubPackageDownLoadMobileClearTitleItem : UiPanelBase
{
	// Token: 0x06015DFE RID: 89598 RVA: 0x00612AAC File Offset: 0x00610CAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickHelpBtn))
		};
	}

	// Token: 0x06015DFF RID: 89599 RVA: 0x00612B14 File Offset: 0x00610D14
	public void RefreshItem(int type)
	{
		this.TitleType = type;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "SubPackageClearTipsTitle_" + SubPackageDefineClearTypeToTipsNumber.clearTypeToTipsNumber[(ESubPackageDownLoadPackageType)this.TitleType].ToString(), Array.Empty<object>());
	}

	// Token: 0x06015E00 RID: 89600 RVA: 0x00612B60 File Offset: 0x00610D60
	private void OnClickHelpBtn()
	{
		if (this.OnClickHelpBtnCallBack != null)
		{
			this.OnClickHelpBtnCallBack(this.TitleType, base.GetButton(1).RootUIComp.Get());
		}
	}

	// Token: 0x0400A7EE RID: 42990
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIItem> OnClickHelpBtnCallBack;

	// Token: 0x0400A7EF RID: 42991
	private int TitleType;

	// Token: 0x02008E22 RID: 36386
	private class ESubPackageDownLoadMobileClearTitleItem
	{
		// Token: 0x0402FD0C RID: 195852
		public const int Text = 0;

		// Token: 0x0402FD0D RID: 195853
		public const int HelpBtn = 1;
	}
}
