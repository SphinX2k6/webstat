using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029DE RID: 10718
public class ShipTowerStageItemBase : UiPanelBase
{
	// Token: 0x060155D3 RID: 87507 RVA: 0x005EB9FC File Offset: 0x005E9BFC
	[NullableContext(1)]
	public UniTask Init(UUIItem item, int data)
	{
		ShipTowerStageItemBase.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.data = data;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerStageItemBase.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060155D4 RID: 87508 RVA: 0x005EBA50 File Offset: 0x005E9C50
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnEnter))
		};
	}

	// Token: 0x060155D5 RID: 87509 RVA: 0x005EBAB8 File Offset: 0x005E9CB8
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerStageItemBase.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerStageItemBase.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060155D6 RID: 87510 RVA: 0x005EBAFB File Offset: 0x005E9CFB
	public void UpdateData()
	{
		this.StageItem.UpdateData();
	}

	// Token: 0x060155D7 RID: 87511 RVA: 0x005EBB08 File Offset: 0x005E9D08
	protected void OnClickBtnEnter()
	{
		ShipTowerStageData stageDataById = ModelBase<ShipTowerModel>.Instance.GetStageDataById(this.ItemDataId);
		if (stageDataById == null)
		{
			return;
		}
		stageDataById.OpenViewStageDesc();
	}

	// Token: 0x060155D8 RID: 87512 RVA: 0x005EBB24 File Offset: 0x005E9D24
	public void SetClickEnable(bool enable)
	{
		UUIButtonComponent button = base.GetButton(1);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(enable);
	}

	// Token: 0x0400A483 RID: 42115
	[Nullable(2)]
	protected ShipTowerStageItem StageItem;

	// Token: 0x0400A484 RID: 42116
	protected int ItemDataId;

	// Token: 0x02008D4D RID: 36173
	private static class EChildTypeBase
	{
		// Token: 0x0402F849 RID: 194633
		public const int ItemBase = 0;

		// Token: 0x0402F84A RID: 194634
		public const int BtnEnter = 1;
	}
}
