using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002494 RID: 9364
[NullableContext(1)]
[Nullable(0)]
public class PhantomFettersObtainItem : UiPanelBase
{
	// Token: 0x060122B3 RID: 74419 RVA: 0x004FF4B4 File Offset: 0x004FD6B4
	public PhantomFettersObtainItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x060122B4 RID: 74420 RVA: 0x004FF4C3 File Offset: 0x004FD6C3
	public void Init()
	{
		base.CreateThenShowByActor(this.SourceItem.GetOwner(), null);
	}

	// Token: 0x060122B5 RID: 74421 RVA: 0x004FF4D8 File Offset: 0x004FD6D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnTrack))
		};
	}

	// Token: 0x060122B6 RID: 74422 RVA: 0x004FF56C File Offset: 0x004FD76C
	public void Update(IFettersObtainData data)
	{
		this.MonsterId = data.Id;
		if (data.IsGet)
		{
			base.SetTextureByPath(data.Icon, base.GetTexture(0), null, null);
			base.GetText(1).ShowTextNew(data.Name);
		}
		else
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconMonsterHead00_UI");
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			base.GetText(1).SetText("???", true);
		}
		base.GetText(2).SetUIActive(false);
	}

	// Token: 0x060122B7 RID: 74423 RVA: 0x004FF605 File Offset: 0x004FD805
	public void BindOnItemButtonClickedCallback(Action<int> onItemButtonClicked)
	{
		this.OnItemButtonClickedCallback = onItemButtonClicked;
	}

	// Token: 0x060122B8 RID: 74424 RVA: 0x004FF60E File Offset: 0x004FD80E
	private void OnTrack()
	{
		if (this.OnItemButtonClickedCallback != null)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomBattleFettersObtainView, null);
			this.OnItemButtonClickedCallback(this.MonsterId);
		}
	}

	// Token: 0x04008DD8 RID: 36312
	private int MonsterId;

	// Token: 0x04008DD9 RID: 36313
	[Nullable(2)]
	private Action<int> OnItemButtonClickedCallback;

	// Token: 0x04008DDA RID: 36314
	[Nullable(2)]
	private readonly UUIItem SourceItem;
}
