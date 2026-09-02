using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200181F RID: 6175
[NullableContext(1)]
[Nullable(0)]
public class VisionRefineResultView : UiViewBase
{
	// Token: 0x0600AFDC RID: 45020 RVA: 0x002EE04B File Offset: 0x002EC24B
	public VisionRefineResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AFDD RID: 45021 RVA: 0x002EE060 File Offset: 0x002EC260
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnGoToPhantomLevelUp)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickMask)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickMask))
		};
	}

	// Token: 0x0600AFDE RID: 45022 RVA: 0x002EE1D8 File Offset: 0x002EC3D8
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineResultView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineResultView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AFDF RID: 45023 RVA: 0x002EE21C File Offset: 0x002EC41C
	protected override void OnAfterShow()
	{
		List<int> list = new List<int>();
		foreach (PhantomItemData phantomItemData in this.ItemDataList)
		{
			int uniqueId = phantomItemData.GetUniqueId();
			AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(uniqueId);
			if (attributeItemData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.WDX, "Proto_PhantomPolishResponse.Proto_UpdateInfo为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else if (attributeItemData.CanLock() && !attributeItemData.GetIsLock())
			{
				list.Add(uniqueId);
			}
		}
		if (list.Count > 0)
		{
			this.TryLockRefineVisions(list).Forget();
		}
	}

	// Token: 0x0600AFE0 RID: 45024 RVA: 0x002EE2D0 File Offset: 0x002EC4D0
	private UniTask TryLockRefineVisions(List<int> uidList)
	{
		VisionRefineResultView.<TryLockRefineVisions>d__8 <TryLockRefineVisions>d__;
		<TryLockRefineVisions>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryLockRefineVisions>d__.<>4__this = this;
		<TryLockRefineVisions>d__.uidList = uidList;
		<TryLockRefineVisions>d__.<>1__state = -1;
		<TryLockRefineVisions>d__.<>t__builder.Start<VisionRefineResultView.<TryLockRefineVisions>d__8>(ref <TryLockRefineVisions>d__);
		return <TryLockRefineVisions>d__.<>t__builder.Task;
	}

	// Token: 0x0600AFE1 RID: 45025 RVA: 0x002EE31B File Offset: 0x002EC51B
	private VisionRecoverySlotGridItem InitVisionRecoverySlotGridItem()
	{
		return new VisionRecoverySlotGridItem(new Action<bool, PhantomItemData>(this.OnClickRewardCallback), false);
	}

	// Token: 0x0600AFE2 RID: 45026 RVA: 0x002EE32F File Offset: 0x002EC52F
	private void OnClickMask()
	{
		base.CloseMe(this.OnCloseCallback);
	}

	// Token: 0x0600AFE3 RID: 45027 RVA: 0x002EE340 File Offset: 0x002EC540
	private void OnGoToPhantomLevelUp()
	{
		if (this.ItemDataList.Count != 1)
		{
			return;
		}
		VisionIntensifyViewPassData visionIntensifyViewPassData = new VisionIntensifyViewPassData();
		visionIntensifyViewPassData.UniqueId = this.ItemDataList[0].GetUniqueId();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionIntensifyView, visionIntensifyViewPassData, null);
		base.CloseMe(delegate(bool success)
		{
			if (this.OnCloseCallback != null)
			{
				this.OnCloseCallback(success);
			}
		});
	}

	// Token: 0x0600AFE4 RID: 45028 RVA: 0x002EE39C File Offset: 0x002EC59C
	[NullableContext(2)]
	private void OnClickRewardCallback(bool isAddVision, PhantomItemData data)
	{
		if (data == null)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(data.GetUniqueId(), data.GetConfigId(), true, null);
	}

	// Token: 0x0600AFE5 RID: 45029 RVA: 0x002EE3BA File Offset: 0x002EC5BA
	private void SetTipsState(bool active)
	{
		base.GetItem(5).SetUIActive(active);
		base.GetButton(1).SetSelfInteractive(!active);
	}

	// Token: 0x0400535C RID: 21340
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRecoverySlotGridItem, PhantomItemData> MainRewardLayout;

	// Token: 0x0400535D RID: 21341
	private readonly List<PhantomItemData> ItemDataList = new List<PhantomItemData>();

	// Token: 0x0400535E RID: 21342
	[Nullable(2)]
	public Action<bool> OnCloseCallback;

	// Token: 0x02007BA1 RID: 31649
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A415 RID: 173077
		ItemVision,
		// Token: 0x0402A416 RID: 173078
		BtnMask,
		// Token: 0x0402A417 RID: 173079
		MainRewardLayout,
		// Token: 0x0402A418 RID: 173080
		ItemTips,
		// Token: 0x0402A419 RID: 173081
		ExtraRewardLayout,
		// Token: 0x0402A41A RID: 173082
		TipItem,
		// Token: 0x0402A41B RID: 173083
		CancelBtn,
		// Token: 0x0402A41C RID: 173084
		ConfirmBtn,
		// Token: 0x0402A41D RID: 173085
		AttrRoot,
		// Token: 0x0402A41E RID: 173086
		AttrTex,
		// Token: 0x0402A41F RID: 173087
		AttrText,
		// Token: 0x0402A420 RID: 173088
		AttrTipText
	}
}
