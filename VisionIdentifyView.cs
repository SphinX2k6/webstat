using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002521 RID: 9505
[NullableContext(1)]
[Nullable(0)]
public class VisionIdentifyView : UiTabViewBase
{
	// Token: 0x06012778 RID: 75640 RVA: 0x00515604 File Offset: 0x00513804
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickLockToggle)),
			new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClickDeprecateToggle))
		};
	}

	// Token: 0x06012779 RID: 75641 RVA: 0x005156DC File Offset: 0x005138DC
	protected override UniTask OnBeforeStartAsync()
	{
		VisionIdentifyView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionIdentifyView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601277A RID: 75642 RVA: 0x00515720 File Offset: 0x00513920
	protected override void OnStart()
	{
		this.VisionIdentifyCostItem = new VisionIdentifyCostItem(base.GetItem(1));
		this.VisionIdentifyCostItem.Init();
		this.VisionIdentifyCostItem.SetOnChangeValueCallBack(new Action(this.OnChangeSelectNumber));
		this.VisionNameText = new VisionNameText(base.GetText(3));
	}

	// Token: 0x0601277B RID: 75643 RVA: 0x00515773 File Offset: 0x00513973
	private void OnChangeSelectNumber()
	{
		this.RefreshAttributePreview();
	}

	// Token: 0x0601277C RID: 75644 RVA: 0x0051577B File Offset: 0x0051397B
	protected override void OnBeforeShow()
	{
		this.AddEvent();
		this.CurrentVisionUniqueId = (int)(this.ExtraParams ?? 0);
		this.CacheCurrentSlotState();
		this.RefreshView();
	}

	// Token: 0x0601277D RID: 75645 RVA: 0x005157AC File Offset: 0x005139AC
	private void AddEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionIdentify, new Action(this.OnVisionIdentify));
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<Aki.Protocol.PhantomPropInfo>>(EEventName.OnVisionIdentifyDoAnimation, new Action<int, IReadOnlyList<Aki.Protocol.PhantomPropInfo>>(this.OnVisionIdentifyDoAnimation));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		this.EventRegistState = true;
	}

	// Token: 0x0601277E RID: 75646 RVA: 0x00515830 File Offset: 0x00513A30
	private void RemoveEvent()
	{
		if (this.EventRegistState)
		{
			this.EventRegistState = false;
			Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionIdentify, new Action(this.OnVisionIdentify));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionIdentifyDoAnimation, new Action<int, IReadOnlyList<Aki.Protocol.PhantomPropInfo>>(this.OnVisionIdentifyDoAnimation));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}
	}

	// Token: 0x0601277F RID: 75647 RVA: 0x005158BC File Offset: 0x00513ABC
	private void RefreshView()
	{
		this.RefreshMainAttribute();
		this.RefreshCostItem();
		this.RefreshName();
		this.RefreshToggleState();
	}

	// Token: 0x06012780 RID: 75648 RVA: 0x005158D8 File Offset: 0x00513AD8
	private void RefreshName()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		this.VisionNameText.Update(phantomItemDataByUniqueId);
	}

	// Token: 0x06012781 RID: 75649 RVA: 0x00515906 File Offset: 0x00513B06
	private void OnVisionIdentifyDoAnimation(int uniqueId, IReadOnlyList<Aki.Protocol.PhantomPropInfo> data)
	{
		this.PlayGridAnimation(uniqueId, data.ToList<Aki.Protocol.PhantomPropInfo>()).Forget();
	}

	// Token: 0x06012782 RID: 75650 RVA: 0x0051591C File Offset: 0x00513B1C
	private UniTask PlayGridAnimation(int uniqueId, List<Aki.Protocol.PhantomPropInfo> data)
	{
		VisionIdentifyView.<PlayGridAnimation>d__19 <PlayGridAnimation>d__;
		<PlayGridAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayGridAnimation>d__.<>4__this = this;
		<PlayGridAnimation>d__.uniqueId = uniqueId;
		<PlayGridAnimation>d__.data = data;
		<PlayGridAnimation>d__.<>1__state = -1;
		<PlayGridAnimation>d__.<>t__builder.Start<VisionIdentifyView.<PlayGridAnimation>d__19>(ref <PlayGridAnimation>d__);
		return <PlayGridAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x06012783 RID: 75651 RVA: 0x00515970 File Offset: 0x00513B70
	private void OnlyRefreshNewAttribute()
	{
		if (this.CurrentNeedAnimationIndex.Count > 0)
		{
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
			if (phantomItemDataByUniqueId == null)
			{
				return;
			}
			int currentCanIdentifyCount = phantomItemDataByUniqueId.GetCurrentCanIdentifyCount();
			List<VisionSubPropData> subPropIdentifyPreviewData = phantomItemDataByUniqueId.GetSubPropIdentifyPreviewData(phantomItemDataByUniqueId.GetPhantomLevel(), (currentCanIdentifyCount == 0) ? 0 : this.VisionIdentifyCostItem.CurrentConsumeSelectNum());
			if (subPropIdentifyPreviewData.Count > 0)
			{
				VisionSubPropData[] array = new VisionSubPropData[subPropIdentifyPreviewData.Count];
				for (int i = 0; i < subPropIdentifyPreviewData.Count; i++)
				{
					array[i] = subPropIdentifyPreviewData[i];
				}
				this.LevelUpIdentifyComponent.Update(array, true);
			}
		}
	}

	// Token: 0x06012784 RID: 75652 RVA: 0x00515A0A File Offset: 0x00513C0A
	private void OnVisionIdentify()
	{
		this.CacheCurrentSlotState();
	}

	// Token: 0x06012785 RID: 75653 RVA: 0x00515A14 File Offset: 0x00513C14
	private void CacheCurrentSlotState()
	{
		this.CurrentNeedAnimationIndex = new List<int>();
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		int currentCanIdentifyCount = phantomItemDataByUniqueId.GetCurrentCanIdentifyCount();
		List<VisionSubPropData> subPropIdentifyPreviewData = phantomItemDataByUniqueId.GetSubPropIdentifyPreviewData(phantomItemDataByUniqueId.GetPhantomLevel(), (currentCanIdentifyCount == 0) ? 0 : this.VisionIdentifyCostItem.CurrentConsumeSelectNum());
		int count = subPropIdentifyPreviewData.Count;
		if (count > 0)
		{
			for (int i = 0; i < count; i++)
			{
				int? num = null;
				int value;
				this.CurrentCacheSubPropSlotData.TryGetValue(i, out value);
				num = new int?(value);
				if (num.GetValueOrDefault() == 5 || num.GetValueOrDefault() == 1)
				{
					int? num2 = num;
					int slotState = (int)subPropIdentifyPreviewData[i].SlotState;
					if (!(num2.GetValueOrDefault() == slotState & num2 != null) && subPropIdentifyPreviewData[i].SlotState == EVisionSlotState.UnlockAndHaveProp)
					{
						this.CurrentNeedAnimationIndex.Add(i);
					}
				}
			}
		}
		for (int j = 0; j < count; j++)
		{
			int slotState2 = (int)subPropIdentifyPreviewData[j].SlotState;
			this.CurrentCacheSubPropSlotData[j] = slotState2;
		}
	}

	// Token: 0x06012786 RID: 75654 RVA: 0x00515B34 File Offset: 0x00513D34
	private void OnItemFuncValueChange(int uniqueId)
	{
		if (uniqueId != this.CurrentVisionUniqueId)
		{
			return;
		}
		this.RefreshToggleState();
	}

	// Token: 0x06012787 RID: 75655 RVA: 0x00515B46 File Offset: 0x00513D46
	private void OnCommonItemCountAnyChange(int i, int i1)
	{
		this.RefreshView();
	}

	// Token: 0x06012788 RID: 75656 RVA: 0x00515B50 File Offset: 0x00513D50
	private void RefreshCostItem()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		this.VisionIdentifyCostItem.Update(phantomItemDataByUniqueId);
	}

	// Token: 0x06012789 RID: 75657 RVA: 0x00515B80 File Offset: 0x00513D80
	private void RefreshMainAttribute()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		List<AttrListScrollData> levelUpPreviewData = phantomItemDataByUniqueId.GetLevelUpPreviewData(phantomItemDataByUniqueId.GetPhantomLevel());
		this.VisionMainAttributeComponent.Update(levelUpPreviewData.ToArray());
	}

	// Token: 0x0601278A RID: 75658 RVA: 0x00515BC0 File Offset: 0x00513DC0
	private void RefreshAttributePreview()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentVisionUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		int currentCanIdentifyCount = phantomItemDataByUniqueId.GetCurrentCanIdentifyCount();
		List<VisionSubPropData> subPropIdentifyPreviewData = phantomItemDataByUniqueId.GetSubPropIdentifyPreviewData(phantomItemDataByUniqueId.GetPhantomLevel(), (currentCanIdentifyCount == 0) ? 0 : this.VisionIdentifyCostItem.CurrentConsumeSelectNum());
		bool flag = subPropIdentifyPreviewData.Count > 0;
		if (flag)
		{
			VisionSubPropData[] array = new VisionSubPropData[subPropIdentifyPreviewData.Count];
			for (int i = 0; i < subPropIdentifyPreviewData.Count; i++)
			{
				array[i] = subPropIdentifyPreviewData[i];
			}
			this.LevelUpIdentifyComponent.Update(array, false);
		}
		this.LevelUpIdentifyComponent.SetActive(flag);
	}

	// Token: 0x0601278B RID: 75659 RVA: 0x00515C60 File Offset: 0x00513E60
	private void RefreshToggleState()
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.CurrentVisionUniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		EToggleState state = attributeItemData.GetIsLock() ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		base.GetExtendToggle(4).SetToggleState(state, false, false, false);
		EToggleState state2 = attributeItemData.GetIsDeprecated() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(5).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0601278C RID: 75660 RVA: 0x00515CBE File Offset: 0x00513EBE
	protected override void OnBeforeHide()
	{
		this.RemoveEvent();
		Singleton<UiLayer>.Instance.SetShowMaskLayer("PhantomLevelUp", false);
	}

	// Token: 0x0601278D RID: 75661 RVA: 0x00515CD6 File Offset: 0x00513ED6
	protected override void OnBeforeDestroy()
	{
		this.RemoveEvent();
		this.LevelUpIdentifyComponent.Destroy(null);
		this.VisionMainAttributeComponent.Destroy(null);
		this.VisionIdentifyCostItem.Destroy(null);
	}

	// Token: 0x0601278E RID: 75662 RVA: 0x00515D04 File Offset: 0x00513F04
	protected void OnClickLockToggle(EToggleState toggleState)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.CurrentVisionUniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		ControllerBase<InventoryController>.Instance.ItemLockRequest(this.CurrentVisionUniqueId, !attributeItemData.GetIsLock());
	}

	// Token: 0x0601278F RID: 75663 RVA: 0x00515D40 File Offset: 0x00513F40
	protected void OnClickDeprecateToggle(EToggleState toggleState)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.CurrentVisionUniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		ControllerBase<InventoryController>.Instance.ItemDeprecateRequest(this.CurrentVisionUniqueId, !attributeItemData.GetIsDeprecated());
	}

	// Token: 0x0400901B RID: 36891
	[Nullable(2)]
	private LevelUpIdentifyComponent LevelUpIdentifyComponent;

	// Token: 0x0400901C RID: 36892
	[Nullable(2)]
	private VisionMainAttributeComponent VisionMainAttributeComponent;

	// Token: 0x0400901D RID: 36893
	private int CurrentVisionUniqueId;

	// Token: 0x0400901E RID: 36894
	[Nullable(2)]
	private VisionIdentifyCostItem VisionIdentifyCostItem;

	// Token: 0x0400901F RID: 36895
	private bool EventRegistState;

	// Token: 0x04009020 RID: 36896
	[Nullable(2)]
	private VisionNameText VisionNameText;

	// Token: 0x04009021 RID: 36897
	private readonly Dictionary<int, int> CurrentCacheSubPropSlotData = new Dictionary<int, int>();

	// Token: 0x04009022 RID: 36898
	private List<int> CurrentNeedAnimationIndex = new List<int>();

	// Token: 0x0200883E RID: 34878
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E047 RID: 188487
		AttributeItem,
		// Token: 0x0402E048 RID: 188488
		CostItem,
		// Token: 0x0402E049 RID: 188489
		IdentifyItem,
		// Token: 0x0402E04A RID: 188490
		VisionName,
		// Token: 0x0402E04B RID: 188491
		LockToggle,
		// Token: 0x0402E04C RID: 188492
		DeprecateToggle
	}
}
