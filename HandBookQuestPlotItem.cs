using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E7C RID: 7804
[NullableContext(1)]
[Nullable(0)]
public class HandBookQuestPlotItem : UiPanelBase, IDynamicScrollItem<HandBookQuestDynamicData>
{
	// Token: 0x0600E6BD RID: 59069 RVA: 0x003E48C0 File Offset: 0x003E2AC0
	public UniTask Init(UUIItem actor)
	{
		HandBookQuestPlotItem.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HandBookQuestPlotItem.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E6BE RID: 59070 RVA: 0x003E490C File Offset: 0x003E2B0C
	private UniTask InitChildItem()
	{
		HandBookQuestPlotItem.<InitChildItem>d__4 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<HandBookQuestPlotItem.<InitChildItem>d__4>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600E6BF RID: 59071 RVA: 0x003E494F File Offset: 0x003E2B4F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E6C0 RID: 59072 RVA: 0x003E4988 File Offset: 0x003E2B88
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(HandBookQuestDynamicData data)
	{
		return base.GetItem(1).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600E6C1 RID: 59073 RVA: 0x003E499B File Offset: 0x003E2B9B
	public void Update(HandBookQuestDynamicData data, int index)
	{
		this.PlotNodeItem.SetUiActive(true);
		this.PlotNodeItem.Update(data.TidText, this.IsSelectNode(data.TidText));
	}

	// Token: 0x0600E6C2 RID: 59074 RVA: 0x003E49C6 File Offset: 0x003E2BC6
	public UUIExtendToggle GetNodeToggle()
	{
		return this.PlotNodeItem.GetNodeToggle();
	}

	// Token: 0x0600E6C3 RID: 59075 RVA: 0x003E49D3 File Offset: 0x003E2BD3
	public void SetToggleState(EToggleState state)
	{
		this.PlotNodeItem.SetToggleState(state);
	}

	// Token: 0x0600E6C4 RID: 59076 RVA: 0x003E49E1 File Offset: 0x003E2BE1
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600E6C5 RID: 59077 RVA: 0x003E49EA File Offset: 0x003E2BEA
	public void BindClickCallback(TSelectedCallback onClickCallback)
	{
		this.OnCallBack = onClickCallback;
	}

	// Token: 0x0600E6C6 RID: 59078 RVA: 0x003E49F3 File Offset: 0x003E2BF3
	private bool IsSelectNode(string tidText)
	{
		return this.IsSelectFunction != null && this.IsSelectFunction(tidText);
	}

	// Token: 0x0600E6C7 RID: 59079 RVA: 0x003E4A0B File Offset: 0x003E2C0B
	public void BindIsSelectFunction(TSelectFunction isSelectFunction)
	{
		this.IsSelectFunction = isSelectFunction;
	}

	// Token: 0x0600E6C8 RID: 59080 RVA: 0x003E4A14 File Offset: 0x003E2C14
	[NullableContext(2)]
	public string GetTidText()
	{
		PlotNodeItem plotNodeItem = this.PlotNodeItem;
		if (plotNodeItem == null)
		{
			return null;
		}
		return plotNodeItem.GetTidText();
	}

	// Token: 0x0600E6C9 RID: 59081 RVA: 0x003E4A27 File Offset: 0x003E2C27
	[NullableContext(2)]
	public UUIExtendToggle GetToggleItem()
	{
		PlotNodeItem plotNodeItem = this.PlotNodeItem;
		if (plotNodeItem == null)
		{
			return null;
		}
		return plotNodeItem.GetNodeToggle();
	}

	// Token: 0x04006F44 RID: 28484
	[Nullable(2)]
	public PlotNodeItem PlotNodeItem;

	// Token: 0x04006F45 RID: 28485
	[Nullable(2)]
	private TSelectedCallback OnCallBack;

	// Token: 0x04006F46 RID: 28486
	[Nullable(2)]
	private TSelectFunction IsSelectFunction;
}
