using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020024D3 RID: 9427
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomGridItem : SyncGridProxyAbstract<PhantomInteractEditGridViewModel>
{
	// Token: 0x060124CE RID: 74958 RVA: 0x00508244 File Offset: 0x00506444
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle))
		};
	}

	// Token: 0x060124CF RID: 74959 RVA: 0x00508268 File Offset: 0x00506468
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		UUIItem uuiitem = (extendToggle != null) ? extendToggle.GetRootComponent() : null;
		this.GridItem = new PhantomInteractGridMediumItemGrid();
		this.GridItem.CreateThenShowByActor(uuiitem.GetOwner(), null);
		this.GridItem.SetOnClickCallBack(delegate(IPhantomInteractGridViewModel data, int gridIndex)
		{
			this.OnClickCb(data, gridIndex);
		});
	}

	// Token: 0x060124D0 RID: 74960 RVA: 0x005082C0 File Offset: 0x005064C0
	public override void Refresh(PhantomInteractEditGridViewModel data)
	{
		if (data == null)
		{
			return;
		}
		if (data.IsSelected && ModelBase<PhantomInteractModel>.Instance.CheckPhantomInteractUnlockRedDot(data.MonsterId))
		{
			ModelBase<PhantomInteractModel>.Instance.SetPhantomInteractUnlockRedDot(data.MonsterId, false);
		}
		this.GridItem.Refresh(data, false, base.GridIndex);
		this.SetToggleState(data.IsSelected);
	}

	// Token: 0x060124D1 RID: 74961 RVA: 0x0050831C File Offset: 0x0050651C
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, false, true);
	}

	// Token: 0x04008EC3 RID: 36547
	[Nullable(2)]
	private PhantomInteractGridMediumItemGrid GridItem;

	// Token: 0x04008EC4 RID: 36548
	public Action<IPhantomInteractGridViewModel, int> OnClickCb;
}
