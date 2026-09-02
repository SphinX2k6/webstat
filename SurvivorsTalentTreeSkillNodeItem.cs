using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B5A RID: 11098
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsTalentTreeSkillNodeItem : UiPanelBase
{
	// Token: 0x17001CCC RID: 7372
	// (get) Token: 0x06016206 RID: 90630 RVA: 0x00624127 File Offset: 0x00622327
	public SurvivorsTalentNode Node
	{
		get
		{
			return this.NodeData;
		}
	}

	// Token: 0x06016207 RID: 90631 RVA: 0x00624130 File Offset: 0x00622330
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06016208 RID: 90632 RVA: 0x00624208 File Offset: 0x00622408
	public UniTask RefreshNodeAsyncByData(SurvivorsTalentNode talentNode)
	{
		SurvivorsTalentTreeSkillNodeItem.<RefreshNodeAsyncByData>d__5 <RefreshNodeAsyncByData>d__;
		<RefreshNodeAsyncByData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsyncByData>d__.<>4__this = this;
		<RefreshNodeAsyncByData>d__.talentNode = talentNode;
		<RefreshNodeAsyncByData>d__.<>1__state = -1;
		<RefreshNodeAsyncByData>d__.<>t__builder.Start<SurvivorsTalentTreeSkillNodeItem.<RefreshNodeAsyncByData>d__5>(ref <RefreshNodeAsyncByData>d__);
		return <RefreshNodeAsyncByData>d__.<>t__builder.Task;
	}

	// Token: 0x06016209 RID: 90633 RVA: 0x00624254 File Offset: 0x00622454
	public UniTask RefreshNodeAsync()
	{
		SurvivorsTalentTreeSkillNodeItem.<RefreshNodeAsync>d__6 <RefreshNodeAsync>d__;
		<RefreshNodeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsync>d__.<>4__this = this;
		<RefreshNodeAsync>d__.<>1__state = -1;
		<RefreshNodeAsync>d__.<>t__builder.Start<SurvivorsTalentTreeSkillNodeItem.<RefreshNodeAsync>d__6>(ref <RefreshNodeAsync>d__);
		return <RefreshNodeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601620A RID: 90634 RVA: 0x00624297 File Offset: 0x00622497
	public void SelectNode()
	{
		this.OnClickToggle(EToggleState.ETT_Checked);
	}

	// Token: 0x0601620B RID: 90635 RVA: 0x006242A0 File Offset: 0x006224A0
	private void OnClickToggle(EToggleState state)
	{
		Action<SurvivorsTalentNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.NodeData, base.GetExtendToggle(6));
	}

	// Token: 0x0400AAD5 RID: 43733
	private SurvivorsTalentNode NodeData;

	// Token: 0x0400AAD6 RID: 43734
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<SurvivorsTalentNode, UUIExtendToggle> OnClickToggleBack;
}
