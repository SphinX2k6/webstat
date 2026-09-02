using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001809 RID: 6153
[NullableContext(1)]
[Nullable(0)]
public class VisionRecoveryResultView : UiViewBase
{
	// Token: 0x0600AEEC RID: 44780 RVA: 0x002E9792 File Offset: 0x002E7992
	public VisionRecoveryResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AEED RID: 44781 RVA: 0x002E97A8 File Offset: 0x002E79A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x0600AEEE RID: 44782 RVA: 0x002E9868 File Offset: 0x002E7A68
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRecoveryResultView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRecoveryResultView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AEEF RID: 44783 RVA: 0x002E98AC File Offset: 0x002E7AAC
	private void RefreshRecoverySlotPanel(IReadOnlyList<PhantomItem> costPhantoms)
	{
		List<PhantomItemData> phantomItemDataListByPhantomItem = ModelBase<InventoryModel>.Instance.GetPhantomItemDataListByPhantomItem(costPhantoms.ToList<PhantomItem>());
		this.RecoverySlotPanel.RefreshUi(phantomItemDataListByPhantomItem);
	}

	// Token: 0x0600AEF0 RID: 44784 RVA: 0x002E98D8 File Offset: 0x002E7AD8
	private void RefreshMainReward(IReadOnlyList<AddCountItemInfo> items)
	{
		List<PhantomItemData> phantomItemDataListByAddCountItemInfo = ModelBase<InventoryModel>.Instance.GetPhantomItemDataListByAddCountItemInfo(items.ToList<AddCountItemInfo>());
		if (phantomItemDataListByAddCountItemInfo.Count <= 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.BB, "VisionRecoveryResultView 主奖励为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.MainRewardVision.RefreshUi(phantomItemDataListByAddCountItemInfo[0]);
	}

	// Token: 0x0600AEF1 RID: 44785 RVA: 0x002E9934 File Offset: 0x002E7B34
	private UniTask RefreshSubReward(IReadOnlyList<AddCountItemInfo> items)
	{
		VisionRecoveryResultView.<RefreshSubReward>d__9 <RefreshSubReward>d__;
		<RefreshSubReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSubReward>d__.<>4__this = this;
		<RefreshSubReward>d__.items = items;
		<RefreshSubReward>d__.<>1__state = -1;
		<RefreshSubReward>d__.<>t__builder.Start<VisionRecoveryResultView.<RefreshSubReward>d__9>(ref <RefreshSubReward>d__);
		return <RefreshSubReward>d__.<>t__builder.Task;
	}

	// Token: 0x0600AEF2 RID: 44786 RVA: 0x002E9980 File Offset: 0x002E7B80
	private void BindStartAnimationCallBack(IReadOnlyList<AddCountItemInfo> items)
	{
		if (items.Count <= 0)
		{
			return;
		}
		this.UiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
		{
			ControllerBase<UiNavigationNewController>.Instance.RepeatCursorMove();
			switch (items.Count)
			{
			case 1:
				this.UiViewSequence.PlaySequence("RewardA", false, null);
				return;
			case 2:
				this.UiViewSequence.PlaySequence("RewardB", false, null);
				return;
			case 3:
				this.UiViewSequence.PlaySequence("RewardC", false, null);
				return;
			case 4:
				this.UiViewSequence.PlaySequence("RewardD", false, null);
				return;
			default:
				this.UiViewSequence.PlaySequence("RewardD", false, null);
				return;
			}
		}, false);
	}

	// Token: 0x0600AEF3 RID: 44787 RVA: 0x002E99CD File Offset: 0x002E7BCD
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600AEF4 RID: 44788 RVA: 0x002E99D6 File Offset: 0x002E7BD6
	[NullableContext(2)]
	private void OnClickRewardCallback(bool isAddVision, PhantomItemData data)
	{
		if (data == null)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(data.GetUniqueId(), data.GetConfigId(), true, null);
	}

	// Token: 0x040052FE RID: 21246
	[Nullable(2)]
	private VisionRecoverySlotPanel RecoverySlotPanel;

	// Token: 0x040052FF RID: 21247
	[Nullable(2)]
	private VisionRecoverySlotItem MainRewardVision;

	// Token: 0x04005300 RID: 21248
	private readonly List<VisionRecoverySlotItem> SubRewardVisionList = new List<VisionRecoverySlotItem>();

	// Token: 0x02007B7F RID: 31615
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A360 RID: 172896
		RecoverySlotPanel,
		// Token: 0x0402A361 RID: 172897
		RecoveryMainReward,
		// Token: 0x0402A362 RID: 172898
		RecoverySubRewardRoot,
		// Token: 0x0402A363 RID: 172899
		RecoverySubRewardItemRoot,
		// Token: 0x0402A364 RID: 172900
		RecoverySubRewardItem,
		// Token: 0x0402A365 RID: 172901
		MaskBtn
	}
}
