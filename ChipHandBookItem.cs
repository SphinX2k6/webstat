using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E39 RID: 7737
[NullableContext(1)]
[Nullable(0)]
public class ChipHandBookItem : UiPanelBase, IDynamicScrollItem<HandBookChipDynamicData>
{
	// Token: 0x0600E508 RID: 58632 RVA: 0x003DD90C File Offset: 0x003DBB0C
	public UniTask Init(UUIItem actor)
	{
		ChipHandBookItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ChipHandBookItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E509 RID: 58633 RVA: 0x003DD958 File Offset: 0x003DBB58
	private UniTask InitChildItem()
	{
		ChipHandBookItem.<InitChildItem>d__5 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<ChipHandBookItem.<InitChildItem>d__5>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600E50A RID: 58634 RVA: 0x003DD99C File Offset: 0x003DBB9C
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(HandBookChipDynamicData data)
	{
		int? handBookChipConfigId = data.HandBookChipConfigId;
		if (handBookChipConfigId != null && handBookChipConfigId.GetValueOrDefault() != 0)
		{
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(0).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600E50B RID: 58635 RVA: 0x003DD9E5 File Offset: 0x003DBBE5
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600E50C RID: 58636 RVA: 0x003DD9EE File Offset: 0x003DBBEE
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E50D RID: 58637 RVA: 0x003DDA28 File Offset: 0x003DBC28
	public void Update(HandBookChipDynamicData data, int gridIndex)
	{
		HandBookChipDesItem handBookChipDesItem = this.HandBookChipDesItem;
		if (handBookChipDesItem != null)
		{
			handBookChipDesItem.SetUiActive(false);
		}
		HandBookChipToggleItem handBookChipToggleItem = this.HandBookChipToggleItem;
		if (handBookChipToggleItem != null)
		{
			handBookChipToggleItem.SetUiActive(false);
		}
		int? handBookChipConfigId = data.HandBookChipConfigId;
		if (handBookChipConfigId == null || handBookChipConfigId.GetValueOrDefault() == 0)
		{
			if (data.HandBookCommonItemData != null)
			{
				HandBookChipToggleItem handBookChipToggleItem2 = this.HandBookChipToggleItem;
				if (handBookChipToggleItem2 != null)
				{
					handBookChipToggleItem2.SetUiActive(true);
				}
				HandBookChipToggleItem handBookChipToggleItem3 = this.HandBookChipToggleItem;
				if (handBookChipToggleItem3 == null)
				{
					return;
				}
				handBookChipToggleItem3.Refresh(data.HandBookCommonItemData, data.IsShowContent);
			}
			return;
		}
		HandBookChipDesItem handBookChipDesItem2 = this.HandBookChipDesItem;
		if (handBookChipDesItem2 != null)
		{
			handBookChipDesItem2.SetUiActive(true);
		}
		HandBookChipDesItem handBookChipDesItem3 = this.HandBookChipDesItem;
		if (handBookChipDesItem3 == null)
		{
			return;
		}
		handBookChipDesItem3.Refresh(data.HandBookChipConfigId.Value, data.IsShowContent);
	}

	// Token: 0x0600E50E RID: 58638 RVA: 0x003DDADC File Offset: 0x003DBCDC
	public void RefreshNewState()
	{
		HandBookChipToggleItem handBookChipToggleItem = this.HandBookChipToggleItem;
		if (handBookChipToggleItem != null)
		{
			handBookChipToggleItem.RefreshNewState();
		}
		HandBookChipDesItem handBookChipDesItem = this.HandBookChipDesItem;
		if (handBookChipDesItem == null)
		{
			return;
		}
		handBookChipDesItem.RefreshNewState();
	}

	// Token: 0x0600E50F RID: 58639 RVA: 0x003DDAFF File Offset: 0x003DBCFF
	public void BindChildToggleCallback(TChildChipToggleFunction toggleFunction)
	{
		this.OnChildToggleCallback = toggleFunction;
	}

	// Token: 0x0600E510 RID: 58640 RVA: 0x003DDB08 File Offset: 0x003DBD08
	public void BindToggleCallback(TChipToggleFunction toggleFunction)
	{
		this.OnToggleCallback = toggleFunction;
	}

	// Token: 0x04006E17 RID: 28183
	[Nullable(2)]
	private HandBookChipToggleItem HandBookChipToggleItem;

	// Token: 0x04006E18 RID: 28184
	[Nullable(2)]
	private HandBookChipDesItem HandBookChipDesItem;

	// Token: 0x04006E19 RID: 28185
	[Nullable(2)]
	private TChipToggleFunction OnToggleCallback;

	// Token: 0x04006E1A RID: 28186
	[Nullable(2)]
	private TChildChipToggleFunction OnChildToggleCallback;
}
