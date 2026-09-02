using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EA0 RID: 7840
[NullableContext(1)]
[Nullable(0)]
public class NounHandBookItem : UiPanelBase, IDynamicScrollItem<HandBookNounDynamicData>
{
	// Token: 0x0600E7C1 RID: 59329 RVA: 0x003E9C20 File Offset: 0x003E7E20
	public UniTask Init(UUIItem actor)
	{
		NounHandBookItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<NounHandBookItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E7C2 RID: 59330 RVA: 0x003E9C6C File Offset: 0x003E7E6C
	private UniTask InitChildItem()
	{
		NounHandBookItem.<InitChildItem>d__5 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<NounHandBookItem.<InitChildItem>d__5>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600E7C3 RID: 59331 RVA: 0x003E9CB0 File Offset: 0x003E7EB0
	public AUIBaseActor GetUsingItem(HandBookNounDynamicData data)
	{
		if (data.HandBookNounConfigId != null)
		{
			int? handBookNounConfigId = data.HandBookNounConfigId;
			int num = 0;
			if (!(handBookNounConfigId.GetValueOrDefault() == num & handBookNounConfigId != null))
			{
				return base.GetItem(1).GetOwner() as AUIBaseActor;
			}
		}
		return base.GetItem(0).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600E7C4 RID: 59332 RVA: 0x003E9D0A File Offset: 0x003E7F0A
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600E7C5 RID: 59333 RVA: 0x003E9D13 File Offset: 0x003E7F13
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E7C6 RID: 59334 RVA: 0x003E9D4C File Offset: 0x003E7F4C
	public void Update(HandBookNounDynamicData data, int gridIndex)
	{
		if (this.HandBookNounDesItem != null)
		{
			this.HandBookNounDesItem.SetUiActive(false);
		}
		if (this.HandBookNounToggleItem != null)
		{
			this.HandBookNounToggleItem.SetUiActive(false);
		}
		if (this.RootItem != null)
		{
			this.RootItem.SetAlpha(1f);
		}
		if (data.HandBookNounConfigId != null)
		{
			int? handBookNounConfigId = data.HandBookNounConfigId;
			int num = 0;
			if (!(handBookNounConfigId.GetValueOrDefault() == num & handBookNounConfigId != null))
			{
				if (this.HandBookNounDesItem != null)
				{
					this.HandBookNounDesItem.SetUiActive(true);
					this.HandBookNounDesItem.Refresh(data.HandBookNounConfigId.Value, data.IsShowContent);
					return;
				}
				return;
			}
		}
		if (data.HandBookCommonItemData != null && this.HandBookNounToggleItem != null)
		{
			this.HandBookNounToggleItem.SetUiActive(true);
			this.HandBookNounToggleItem.Refresh(data.HandBookCommonItemData, data.IsShowContent);
		}
	}

	// Token: 0x0600E7C7 RID: 59335 RVA: 0x003E9E27 File Offset: 0x003E8027
	public void RefreshNewState()
	{
		if (this.HandBookNounToggleItem != null)
		{
			this.HandBookNounToggleItem.RefreshNewState();
		}
		if (this.HandBookNounDesItem != null)
		{
			this.HandBookNounDesItem.RefreshNewState();
		}
	}

	// Token: 0x0600E7C8 RID: 59336 RVA: 0x003E9E4F File Offset: 0x003E804F
	public void BindChildToggleCallback(TChildNounToggleFunction toggleFunction)
	{
		this.OnChildToggleCallback = toggleFunction;
		if (this.HandBookNounDesItem != null)
		{
			this.HandBookNounDesItem.BindChildToggleCallback(toggleFunction);
		}
	}

	// Token: 0x0600E7C9 RID: 59337 RVA: 0x003E9E6C File Offset: 0x003E806C
	public void BindToggleCallback(TNounToggleFunction toggleFunction)
	{
		this.OnToggleCallback = toggleFunction;
		if (this.HandBookNounToggleItem != null)
		{
			this.HandBookNounToggleItem.BindToggleCallback(toggleFunction);
		}
	}

	// Token: 0x04006FB6 RID: 28598
	[Nullable(2)]
	private HandBookNounToggleItem HandBookNounToggleItem;

	// Token: 0x04006FB7 RID: 28599
	[Nullable(2)]
	private HandBookNounDesItem HandBookNounDesItem;

	// Token: 0x04006FB8 RID: 28600
	[Nullable(2)]
	private TNounToggleFunction OnToggleCallback;

	// Token: 0x04006FB9 RID: 28601
	[Nullable(2)]
	private TChildNounToggleFunction OnChildToggleCallback;
}
