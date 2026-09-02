using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012DD RID: 4829
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyBuffActiveShowPanel : UiPanelBase
{
	// Token: 0x060082E1 RID: 33505 RVA: 0x0022A464 File Offset: 0x00228664
	public UniTask Init(UUIItem item, DangoMonopolyGridData gridData)
	{
		DangoMonopolyBuffActiveShowPanel.<Init>d__2 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.gridData = gridData;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoMonopolyBuffActiveShowPanel.<Init>d__2>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060082E2 RID: 33506 RVA: 0x0022A4B7 File Offset: 0x002286B7
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x060082E3 RID: 33507 RVA: 0x0022A4BC File Offset: 0x002286BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x060082E4 RID: 33508 RVA: 0x0022A518 File Offset: 0x00228718
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyBuffActiveShowPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyBuffActiveShowPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060082E5 RID: 33509 RVA: 0x0022A55B File Offset: 0x0022875B
	protected override void OnStart()
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x060082E6 RID: 33510 RVA: 0x0022A56F File Offset: 0x0022876F
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x060082E7 RID: 33511 RVA: 0x0022A578 File Offset: 0x00228778
	public void UpdateData()
	{
		DangoData dangoData = this.GridData.GetDangoData();
		string text = ((dangoData != null) ? dangoData.NameKey : null) ?? "DangoName";
		string text2 = ConfigMultiTextLang.GetLocalTextNew(text, null) ?? text;
		string text3 = ConfigMultiTextLang.GetLocalTextNew("DangoMonopoly_title_15", null);
		if (text3 != null)
		{
			text3 = StringUtils.Format(text3, new string[]
			{
				text2
			});
		}
		UUIText text4 = base.GetText(0);
		if (text4 != null)
		{
			text4.SetText(text3 ?? "", true);
		}
		UUISprite sprite = base.GetSprite(2);
		this.SetSpriteByPath(this.GetSpriteTitlePath(true), sprite, true, null, null);
	}

	// Token: 0x060082E8 RID: 33512 RVA: 0x0022A614 File Offset: 0x00228814
	public string GetSpriteTitlePath(bool isGet = true)
	{
		string resourceId = isGet ? "SP_TuanziGetTxt" : "SP_TuanziUnlockTxt";
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		return ((instance != null) ? instance.GetResourcePath(resourceId) : null) ?? "";
	}

	// Token: 0x04003E16 RID: 15894
	public DangoMonopolyGridData GridData;

	// Token: 0x02007660 RID: 30304
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028CB2 RID: 167090
		TxtTitle,
		// Token: 0x04028CB3 RID: 167091
		TxtDesc,
		// Token: 0x04028CB4 RID: 167092
		SpriteTitle
	}
}
