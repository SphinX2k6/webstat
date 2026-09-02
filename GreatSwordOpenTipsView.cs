using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E17 RID: 7703
public class GreatSwordOpenTipsView : UiViewBase
{
	// Token: 0x0600E36E RID: 58222 RVA: 0x003D3C01 File Offset: 0x003D1E01
	[NullableContext(1)]
	public GreatSwordOpenTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E36F RID: 58223 RVA: 0x003D3C0A File Offset: 0x003D1E0A
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600E370 RID: 58224 RVA: 0x003D3C44 File Offset: 0x003D1E44
	protected override void OnStart()
	{
		IGreatSwordChallenge greatSwordChallenge = this.OpenParam as IGreatSwordChallenge;
		if (greatSwordChallenge == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(greatSwordChallenge.MainText))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), greatSwordChallenge.MainText, Array.Empty<object>());
		}
		if (!string.IsNullOrEmpty(greatSwordChallenge.SubText))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), greatSwordChallenge.SubText, Array.Empty<object>());
		}
	}

	// Token: 0x0600E371 RID: 58225 RVA: 0x003D3CB3 File Offset: 0x003D1EB3
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
