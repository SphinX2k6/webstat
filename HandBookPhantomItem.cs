using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E71 RID: 7793
[NullableContext(1)]
[Nullable(0)]
public class HandBookPhantomItem : UiPanelBase
{
	// Token: 0x0600E679 RID: 59001 RVA: 0x003E34EB File Offset: 0x003E16EB
	public void Initialize(HandBookCommonItemData handBookCommonItemData, [Nullable(2)] UUIItem item)
	{
		this.HandBookCommonItemData = handBookCommonItemData;
		if (item != null)
		{
			base.CreateThenShowByActor(item.GetOwner(), null);
		}
	}

	// Token: 0x0600E67A RID: 59002 RVA: 0x003E3504 File Offset: 0x003E1704
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600E67B RID: 59003 RVA: 0x003E3574 File Offset: 0x003E1774
	protected override void OnStart()
	{
		this.HandBookCommonItem = new HandBookCommonItem();
		this.HandBookCommonItem.Initialize(base.GetItem(0).GetOwner());
		PhantomItem phantomItem = (PhantomItem)this.HandBookCommonItemData.Config;
		HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, phantomItem.MonsterId);
		bool flag = handBookInfo == null;
		bool isNew = handBookInfo != null && !handBookInfo.IsRead;
		handBookCommonItemData.Icon = phantomItem.Icon;
		handBookCommonItemData.IsLock = flag;
		handBookCommonItemData.IsNew = isNew;
		this.HandBookCommonItem.Refresh(handBookCommonItemData, false, 0);
		this.HandBookCommonItem.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnToggleClicked));
		this.HandBookCommonItem.SetNewFlagVisible(new bool?(false));
		UUIText text = base.GetText(1);
		base.GetText(3).SetUIActive(false);
		if (flag)
		{
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("Unknown");
			text.ShowTextNew(textContentIdById);
			return;
		}
		text.ShowTextNew(phantomItem.MonsterName);
	}

	// Token: 0x0600E67C RID: 59004 RVA: 0x003E3677 File Offset: 0x003E1877
	public void BindToggleCallback(THandBookPhantomItemToggleFunction toggleFunction)
	{
		this.OnToggleCallback = toggleFunction;
	}

	// Token: 0x0600E67D RID: 59005 RVA: 0x003E3680 File Offset: 0x003E1880
	private void OnToggleClicked(MediumItemGridExtendCallback callbackParameter)
	{
		if (this.OnToggleCallback != null)
		{
			this.OnToggleCallback(this.HandBookCommonItemData, 0);
		}
	}

	// Token: 0x0600E67E RID: 59006 RVA: 0x003E369C File Offset: 0x003E189C
	public void SetToggleStateForce(EToggleState state, bool bFire = false)
	{
		this.HandBookCommonItem.SetSelected(state == EToggleState.ETT_Checked, false);
	}

	// Token: 0x0600E67F RID: 59007 RVA: 0x003E36AE File Offset: 0x003E18AE
	public void OnSelected(bool fireEvent)
	{
		this.HandBookCommonItem.OnSelected(fireEvent);
	}

	// Token: 0x0600E680 RID: 59008 RVA: 0x003E36BC File Offset: 0x003E18BC
	protected override void OnBeforeDestroy()
	{
		this.HandBookCommonItem = null;
		this.HandBookCommonItemData = null;
		this.OnToggleCallback = null;
	}

	// Token: 0x04006F1F RID: 28447
	[Nullable(2)]
	private HandBookCommonItem HandBookCommonItem;

	// Token: 0x04006F20 RID: 28448
	[Nullable(2)]
	private HandBookCommonItemData HandBookCommonItemData;

	// Token: 0x04006F21 RID: 28449
	[Nullable(2)]
	private THandBookPhantomItemToggleFunction OnToggleCallback;

	// Token: 0x020081BD RID: 33213
	[NullableContext(0)]
	private class EHandBookPhantomItemDefine
	{
		// Token: 0x0402C06F RID: 180335
		public const int HandBookCommonItem = 0;

		// Token: 0x0402C070 RID: 180336
		public const int NameText = 1;

		// Token: 0x0402C071 RID: 180337
		public const int HaveText = 2;

		// Token: 0x0402C072 RID: 180338
		public const int PlaceText = 3;
	}
}
