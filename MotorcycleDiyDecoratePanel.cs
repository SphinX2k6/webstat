using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022FC RID: 8956
public class MotorcycleDiyDecoratePanel : UiPanelBase
{
	// Token: 0x06010F8E RID: 69518 RVA: 0x004A7238 File Offset: 0x004A5438
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

	// Token: 0x06010F8F RID: 69519 RVA: 0x004A730D File Offset: 0x004A550D
	protected override void OnStart()
	{
		this.PartBoxItemLayout = new GenericLayout<MotorcycleDiyOutlookBoxItem, MotorcycleDiyOutlookBoxItemData>(base.GetHorizontalLayout(3), new Func<MotorcycleDiyOutlookBoxItem>(this.CreatePartBoxItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
		this.SetEditable(true);
	}

	// Token: 0x06010F90 RID: 69520 RVA: 0x004A7347 File Offset: 0x004A5547
	[NullableContext(1)]
	private MotorcycleDiyOutlookBoxItem CreatePartBoxItem()
	{
		return new MotorcycleDiyOutlookBoxItem();
	}

	// Token: 0x06010F91 RID: 69521 RVA: 0x004A7350 File Offset: 0x004A5550
	[NullableContext(1)]
	public void Refresh(List<int> decorationIdList)
	{
		List<MotorcycleDiyOutlookBoxItemData> data = decorationIdList.Select((int id, int index) => new MotorcycleDiyOutlookBoxItemData(EOutlookType.Decoration, id, index)).ToList<MotorcycleDiyOutlookBoxItemData>();
		this.PartBoxItemLayout.RefreshByData(data, null, false);
		base.GetItem(5).SetUIActive(ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewDecorationByAnyPartVisible());
	}

	// Token: 0x06010F92 RID: 69522 RVA: 0x004A73AC File Offset: 0x004A55AC
	public void SetEditable(bool isEditable)
	{
		base.GetItem(6).SetUIActive(!isEditable);
		base.GetItem(2).SetUIActive(isEditable);
	}

	// Token: 0x06010F93 RID: 69523 RVA: 0x004A73CC File Offset: 0x004A55CC
	private void OnBtnEnterClick()
	{
		ModelBase<MotorcycleDiyModel>.Instance.ResetSelectedItemInfo();
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			OpenTabView = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyDecorationTabView),
			PartTabIndex = new int?(1),
			IsNeedResetMotor = new bool?(true)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyRootView, param, null);
	}

	// Token: 0x0400859A RID: 34202
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleDiyOutlookBoxItem, MotorcycleDiyOutlookBoxItemData> PartBoxItemLayout;

	// Token: 0x020085E1 RID: 34273
	private class EMotorDecorateComponent
	{
		// Token: 0x0402D4A5 RID: 185509
		public const int BtnEnter = 0;

		// Token: 0x0402D4A6 RID: 185510
		public const int TxtTitle = 1;

		// Token: 0x0402D4A7 RID: 185511
		public const int MotorPartItemScroll = 2;

		// Token: 0x0402D4A8 RID: 185512
		public const int Content = 3;

		// Token: 0x0402D4A9 RID: 185513
		public const int MotorPartItem = 4;

		// Token: 0x0402D4AA RID: 185514
		public const int NewItem = 5;

		// Token: 0x0402D4AB RID: 185515
		public const int LockItem = 6;
	}
}
