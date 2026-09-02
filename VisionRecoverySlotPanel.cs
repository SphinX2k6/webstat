using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200180C RID: 6156
public class VisionRecoverySlotPanel : UiPanelBase
{
	// Token: 0x0600AF0F RID: 44815 RVA: 0x002E9F12 File Offset: 0x002E8112
	[NullableContext(2)]
	public VisionRecoverySlotPanel(Action<bool, PhantomItemData> clickCallBack = null, bool showRemoveBtn = true)
	{
		this.ClickSlotCallBack = clickCallBack;
		this.ShowRemoveBtn = showRemoveBtn;
	}

	// Token: 0x0600AF10 RID: 44816 RVA: 0x002E9F40 File Offset: 0x002E8140
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600AF11 RID: 44817 RVA: 0x002E9FC8 File Offset: 0x002E81C8
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRecoverySlotPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRecoverySlotPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF12 RID: 44818 RVA: 0x002EA00C File Offset: 0x002E820C
	private UniTask CreateAndAddSlotItem(VisionRecoverySlotPanel.EComponent slot)
	{
		VisionRecoverySlotPanel.<CreateAndAddSlotItem>d__8 <CreateAndAddSlotItem>d__;
		<CreateAndAddSlotItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAndAddSlotItem>d__.<>4__this = this;
		<CreateAndAddSlotItem>d__.slot = slot;
		<CreateAndAddSlotItem>d__.<>1__state = -1;
		<CreateAndAddSlotItem>d__.<>t__builder.Start<VisionRecoverySlotPanel.<CreateAndAddSlotItem>d__8>(ref <CreateAndAddSlotItem>d__);
		return <CreateAndAddSlotItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF13 RID: 44819 RVA: 0x002EA058 File Offset: 0x002E8258
	[NullableContext(1)]
	public void RefreshUi(List<PhantomItemData> visionDataList)
	{
		for (int i = 0; i < this.VisionDataList.Length; i++)
		{
			PhantomItemData data = this.VisionDataList[i];
			if (i >= visionDataList.Count)
			{
				data = null;
			}
			else
			{
				data = visionDataList[i];
			}
			this.RecoverySlotItemList[i].RefreshUi(data);
		}
	}

	// Token: 0x04005308 RID: 21256
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly PhantomItemData[] VisionDataList = new PhantomItemData[5];

	// Token: 0x04005309 RID: 21257
	[Nullable(1)]
	private VisionRecoverySlotItem[] RecoverySlotItemList = new VisionRecoverySlotItem[5];

	// Token: 0x0400530A RID: 21258
	[Nullable(2)]
	private readonly Action<bool, PhantomItemData> ClickSlotCallBack;

	// Token: 0x0400530B RID: 21259
	private readonly bool ShowRemoveBtn;

	// Token: 0x02007B86 RID: 31622
	private enum EComponent
	{
		// Token: 0x0402A38A RID: 172938
		RecoverySlotItem0,
		// Token: 0x0402A38B RID: 172939
		RecoverySlotItem1,
		// Token: 0x0402A38C RID: 172940
		RecoverySlotItem2,
		// Token: 0x0402A38D RID: 172941
		RecoverySlotItem3,
		// Token: 0x0402A38E RID: 172942
		RecoverySlotItem4
	}
}
