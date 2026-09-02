using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020024E0 RID: 9440
[NullableContext(1)]
[Nullable(0)]
public class CostTabItem : CommonTabItemBase
{
	// Token: 0x06012547 RID: 75079 RVA: 0x00509C8E File Offset: 0x00507E8E
	public CostTabItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x06012548 RID: 75080 RVA: 0x00509C9D File Offset: 0x00507E9D
	public void Init()
	{
		base.SetRootActor(this.SourceItem.GetOwner(), true);
	}

	// Token: 0x06012549 RID: 75081 RVA: 0x00509CB4 File Offset: 0x00507EB4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick))
		};
	}

	// Token: 0x0601254A RID: 75082 RVA: 0x00509D5D File Offset: 0x00507F5D
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0601254B RID: 75083 RVA: 0x00509D76 File Offset: 0x00507F76
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x0601254C RID: 75084 RVA: 0x00509D90 File Offset: 0x00507F90
	protected override void OnUpdateTabIcon(string iconPath)
	{
		this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, null);
	}

	// Token: 0x0601254D RID: 75085 RVA: 0x00509DB6 File Offset: 0x00507FB6
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0601254E RID: 75086 RVA: 0x00509DC9 File Offset: 0x00507FC9
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x04008EF8 RID: 36600
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x020087EE RID: 34798
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DEBF RID: 188095
		Icon,
		// Token: 0x0402DEC0 RID: 188096
		Toggle,
		// Token: 0x0402DEC1 RID: 188097
		RedDot,
		// Token: 0x0402DEC2 RID: 188098
		SpriteIcon,
		// Token: 0x0402DEC3 RID: 188099
		SpriteSubIcon
	}
}
