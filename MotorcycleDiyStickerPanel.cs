using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002307 RID: 8967
public class MotorcycleDiyStickerPanel : UiPanelBase
{
	// Token: 0x06011074 RID: 69748 RVA: 0x004ACB84 File Offset: 0x004AAD84
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnEnterClick))
		};
	}

	// Token: 0x06011075 RID: 69749 RVA: 0x004ACC59 File Offset: 0x004AAE59
	protected override void OnStart()
	{
		this.PartBoxItemLayout = new GenericLayout<MotorcycleDiyOutlookBoxItem, MotorcycleDiyOutlookBoxItemData>(base.GetHorizontalLayout(3), new Func<MotorcycleDiyOutlookBoxItem>(this.CreatePartBoxItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
		this.SetEditable(true);
	}

	// Token: 0x06011076 RID: 69750 RVA: 0x004ACC93 File Offset: 0x004AAE93
	[NullableContext(1)]
	private MotorcycleDiyOutlookBoxItem CreatePartBoxItem()
	{
		return new MotorcycleDiyOutlookBoxItem();
	}

	// Token: 0x06011077 RID: 69751 RVA: 0x004ACC9C File Offset: 0x004AAE9C
	[NullableContext(1)]
	public void Refresh(List<int> stickerIdList)
	{
		List<MotorcycleDiyOutlookBoxItemData> data = stickerIdList.Select((int id, int index) => new MotorcycleDiyOutlookBoxItemData(EOutlookType.Sticker, id, index)).ToList<MotorcycleDiyOutlookBoxItemData>();
		this.PartBoxItemLayout.RefreshByData(data, null, false);
		base.GetItem(5).SetUIActive(ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewStickerByAnyPartVisible());
	}

	// Token: 0x06011078 RID: 69752 RVA: 0x004ACCF8 File Offset: 0x004AAEF8
	public void SetEditable(bool isEditable)
	{
		base.GetItem(6).SetUIActive(!isEditable);
		base.GetItem(2).SetUIActive(isEditable);
	}

	// Token: 0x06011079 RID: 69753 RVA: 0x004ACD18 File Offset: 0x004AAF18
	private void OnBtnEnterClick()
	{
		ModelBase<MotorcycleDiyModel>.Instance.ResetSelectedItemInfo();
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			OpenTabView = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyStickerTabView),
			PartTabIndex = new int?(1),
			IsNeedResetMotor = new bool?(true)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyRootView, param, null);
	}

	// Token: 0x04008605 RID: 34309
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleDiyOutlookBoxItem, MotorcycleDiyOutlookBoxItemData> PartBoxItemLayout;

	// Token: 0x0200860A RID: 34314
	private class EMotorStickerDecorateComponent
	{
		// Token: 0x0402D576 RID: 185718
		public const int BtnEnter = 0;

		// Token: 0x0402D577 RID: 185719
		public const int TxtTitle = 1;

		// Token: 0x0402D578 RID: 185720
		public const int MotorPartItemScroll = 2;

		// Token: 0x0402D579 RID: 185721
		public const int Content = 3;

		// Token: 0x0402D57A RID: 185722
		public const int MotorPartItem = 4;

		// Token: 0x0402D57B RID: 185723
		public const int NewItem = 5;

		// Token: 0x0402D57C RID: 185724
		public const int LockItem = 6;
	}
}
