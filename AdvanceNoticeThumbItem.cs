using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200119C RID: 4508
[Nullable(new byte[]
{
	0,
	1
})]
public class AdvanceNoticeThumbItem : GridProxyAbstract<AdvanceNoticeThumbItemData>
{
	// Token: 0x0600769B RID: 30363 RVA: 0x001F0B58 File Offset: 0x001EED58
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemToggleClickInternal))
		};
	}

	// Token: 0x0600769C RID: 30364 RVA: 0x001F0C17 File Offset: 0x001EEE17
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanItemToggleChangeInternal));
	}

	// Token: 0x0600769D RID: 30365 RVA: 0x001F0C38 File Offset: 0x001EEE38
	[NullableContext(1)]
	public override void Refresh(AdvanceNoticeThumbItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.SetTextureByPath(data.BgTexturePath, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.NameTextId, Array.Empty<object>());
		base.GetItem(3).SetUIActive(data.ShowLine);
		this.RefreshToggleState(data.IsSelected);
	}

	// Token: 0x0600769E RID: 30366 RVA: 0x001F0CA3 File Offset: 0x001EEEA3
	private void OnItemToggleClickInternal(EToggleState _)
	{
		if (this.Data == null)
		{
			return;
		}
		Action<AdvanceNoticeThumbItemData, int> onItemToggleClickDelegate = this.OnItemToggleClickDelegate;
		if (onItemToggleClickDelegate == null)
		{
			return;
		}
		onItemToggleClickDelegate(this.Data, base.GridIndex);
	}

	// Token: 0x0600769F RID: 30367 RVA: 0x001F0CCA File Offset: 0x001EEECA
	public void RefreshToggleState(bool isSelected)
	{
		base.GetSprite(4).SetUIActive(isSelected);
		base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060076A0 RID: 30368 RVA: 0x001F0CF0 File Offset: 0x001EEEF0
	private bool CanItemToggleChangeInternal()
	{
		if (this.Data == null)
		{
			return false;
		}
		Func<AdvanceNoticeThumbItemData, int, bool> canItemToggleChangeDelegate = this.CanItemToggleChangeDelegate;
		return canItemToggleChangeDelegate == null || canItemToggleChangeDelegate(this.Data, base.GridIndex);
	}

	// Token: 0x04003958 RID: 14680
	[Nullable(2)]
	private AdvanceNoticeThumbItemData Data;

	// Token: 0x04003959 RID: 14681
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<AdvanceNoticeThumbItemData, int> OnItemToggleClickDelegate;

	// Token: 0x0400395A RID: 14682
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<AdvanceNoticeThumbItemData, int, bool> CanItemToggleChangeDelegate;

	// Token: 0x020074F9 RID: 29945
	private class EComponent
	{
		// Token: 0x0402862B RID: 165419
		public const int ItemToggle = 0;

		// Token: 0x0402862C RID: 165420
		public const int ItemTexture = 1;

		// Token: 0x0402862D RID: 165421
		public const int NameText = 2;

		// Token: 0x0402862E RID: 165422
		public const int LineItem = 3;

		// Token: 0x0402862F RID: 165423
		public const int SpriteArrow = 4;

		// Token: 0x04028630 RID: 165424
		public const int SpriteSele = 5;
	}
}
