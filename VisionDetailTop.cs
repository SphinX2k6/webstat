using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024F6 RID: 9462
[NullableContext(2)]
[Nullable(0)]
public class VisionDetailTop : UiPanelBase
{
	// Token: 0x0601260B RID: 75275 RVA: 0x0050DA5B File Offset: 0x0050BC5B
	[NullableContext(1)]
	public VisionDetailTop(UUIItem actor)
	{
		this.SourceItem = actor;
	}

	// Token: 0x0601260C RID: 75276 RVA: 0x0050DA6C File Offset: 0x0050BC6C
	public UniTask Init()
	{
		VisionDetailTop.<Init>d__5 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<VisionDetailTop.<Init>d__5>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0601260D RID: 75277 RVA: 0x0050DAB0 File Offset: 0x0050BCB0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickLockToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickDeprecateToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601260E RID: 75278 RVA: 0x0050DC1E File Offset: 0x0050BE1E
	protected void OnClickLockToggle(EToggleState toggleState)
	{
		ControllerBase<InventoryController>.Instance.ItemLockRequest(this.CurrentData.GetUniqueId(), !this.CurrentData.GetIsLock());
	}

	// Token: 0x0601260F RID: 75279 RVA: 0x0050DC43 File Offset: 0x0050BE43
	protected void OnClickDeprecateToggle(EToggleState toggleState)
	{
		ControllerBase<InventoryController>.Instance.ItemDeprecateRequest(this.CurrentData.GetUniqueId(), !this.CurrentData.GetIsDeprecated());
	}

	// Token: 0x06012610 RID: 75280 RVA: 0x0050DC68 File Offset: 0x0050BE68
	protected override UniTask OnBeforeStartAsync()
	{
		VisionDetailTop.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionDetailTop.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012611 RID: 75281 RVA: 0x0050DCAB File Offset: 0x0050BEAB
	protected override void OnStart()
	{
		this.VisionNameText = new VisionNameText(base.GetText(0));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshToggle));
	}

	// Token: 0x06012612 RID: 75282 RVA: 0x0050DCDC File Offset: 0x0050BEDC
	private void RefreshToggle(int incId)
	{
		PhantomBattleData currentData = this.CurrentData;
		if (currentData == null || currentData.GetUniqueId() != incId)
		{
			return;
		}
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(incId);
		if (attributeItemData == null)
		{
			return;
		}
		EToggleState state = attributeItemData.GetIsLock() ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		base.GetExtendToggle(1).SetToggleState(state, false, false, false);
		EToggleState state2 = attributeItemData.GetIsDeprecated() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(6).SetToggleState(state2, false, false, false);
	}

	// Token: 0x06012613 RID: 75283 RVA: 0x0050DD50 File Offset: 0x0050BF50
	[NullableContext(1)]
	public void Update(PhantomBattleData data)
	{
		this.CurrentData = data;
		this.VisionNameText.Update(data);
		base.GetText(4).SetText(data.GetCost().ToString(), true);
		base.GetText(2).SetText(StringUtils.Format("+{0}", new string[]
		{
			data.GetPhantomLevel().ToString()
		}), true);
		base.GetText(2).SetUIActive(true);
		PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(data.GetUniqueId());
		this.RefreshToggle(phantomItemData.GetUniqueId());
		PhantomFetterGroup fetterGroupConfig = data.GetFetterGroupConfig();
		this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupConfig));
	}

	// Token: 0x06012614 RID: 75284 RVA: 0x0050DDFB File Offset: 0x0050BFFB
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshToggle));
	}

	// Token: 0x04008F5A RID: 36698
	private PhantomBattleData CurrentData;

	// Token: 0x04008F5B RID: 36699
	private VisionNameText VisionNameText;

	// Token: 0x04008F5C RID: 36700
	private readonly UUIItem SourceItem;

	// Token: 0x04008F5D RID: 36701
	private VisionFetterSuitItem VisionFetterSuitItem;
}
