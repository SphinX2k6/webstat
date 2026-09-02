using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200118A RID: 4490
public class AdvanceNoticeGridItem : UiPanelBase
{
	// Token: 0x0600762C RID: 30252 RVA: 0x001EE6F2 File Offset: 0x001EC8F2
	public AdvanceNoticeGridItem(int advertisingPageInfoId)
	{
		this.AdvertisingPageInfoId = advertisingPageInfoId;
	}

	// Token: 0x0600762D RID: 30253 RVA: 0x001EE704 File Offset: 0x001EC904
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnItemButtonClick))
		};
	}

	// Token: 0x0600762E RID: 30254 RVA: 0x001EE797 File Offset: 0x001EC997
	protected override void OnStart()
	{
		this.TextureTransitionComp = (base.GetTexture(1).GetOwner().GetComponentByClass(UUITextureTransitionComponent.StaticClass()) as UUITextureTransitionComponent);
	}

	// Token: 0x0600762F RID: 30255 RVA: 0x001EE7BF File Offset: 0x001EC9BF
	public void RefreshByTabId(int tabId)
	{
		this.TabId = tabId;
		this.Refresh();
	}

	// Token: 0x06007630 RID: 30256 RVA: 0x001EE7D0 File Offset: 0x001EC9D0
	public void Refresh()
	{
		AdvertisingTabInfo advertisingTabInfoById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabInfoById(this.TabId);
		base.SetTextureByPath(advertisingTabInfoById.EntryButtonImage, base.GetTexture(1), null, delegate(bool _)
		{
			this.TextureTransitionComp.SetAllStateTexture(base.GetTexture(1).GetTexture());
		});
		this.SetSpriteByPath(advertisingTabInfoById.TabIcon, base.GetSprite(2), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), advertisingTabInfoById.EntryButtonText, Array.Empty<object>());
	}

	// Token: 0x06007631 RID: 30257 RVA: 0x001EE853 File Offset: 0x001ECA53
	private void OnItemButtonClick()
	{
		AdvanceNoticeController instance = ControllerBase<AdvanceNoticeController>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.OpenAdvanceNoticeView(this.AdvertisingPageInfoId, this.TabId);
	}

	// Token: 0x04003939 RID: 14649
	private int TabId;

	// Token: 0x0400393A RID: 14650
	[Nullable(2)]
	private UUITextureTransitionComponent TextureTransitionComp;

	// Token: 0x0400393B RID: 14651
	public readonly int AdvertisingPageInfoId;

	// Token: 0x020074E5 RID: 29925
	private class EComponentDefine
	{
		// Token: 0x040285A9 RID: 165289
		public const int ItemButton = 0;

		// Token: 0x040285AA RID: 165290
		public const int BgTexture = 1;

		// Token: 0x040285AB RID: 165291
		public const int TypeIconSprite = 2;

		// Token: 0x040285AC RID: 165292
		public const int TitleDescText = 3;
	}
}
