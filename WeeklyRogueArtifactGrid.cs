using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D2A RID: 11562
public class WeeklyRogueArtifactGrid : GridProxyAbstract<int>
{
	// Token: 0x06017568 RID: 95592 RVA: 0x00678798 File Offset: 0x00676998
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x06017569 RID: 95593 RVA: 0x00678818 File Offset: 0x00676A18
	private void OnToggleClick(EToggleState state)
	{
		bool arg = base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked;
		Action<int, bool> onSelectedChange = this.OnSelectedChange;
		if (onSelectedChange == null)
		{
			return;
		}
		onSelectedChange(this.TokenId, arg);
	}

	// Token: 0x0601756A RID: 95594 RVA: 0x0067884C File Offset: 0x00676A4C
	public override void Refresh(int tokenId, bool isSelected, int gridIndex)
	{
		this.TokenId = tokenId;
		if (tokenId == 0)
		{
			return;
		}
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(tokenId);
		if (rogueWeeklyBuffPool == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(rogueWeeklyBuffPool.Value.BuffIcon, base.GetTexture(1), null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueWeeklyBuffPool.Value.BuffName, Array.Empty<object>());
	}

	// Token: 0x0601756B RID: 95595 RVA: 0x006788BC File Offset: 0x00676ABC
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
	}

	// Token: 0x0601756C RID: 95596 RVA: 0x006788CF File Offset: 0x00676ACF
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x0601756D RID: 95597 RVA: 0x006788E2 File Offset: 0x00676AE2
	[NullableContext(1)]
	public override object GetKey(int data, int displayIndex)
	{
		return this.TokenId;
	}

	// Token: 0x0400B341 RID: 45889
	[Nullable(2)]
	public Action<int, bool> OnSelectedChange;

	// Token: 0x0400B342 RID: 45890
	protected int TokenId;

	// Token: 0x02008FED RID: 36845
	private enum EComponents
	{
		// Token: 0x040304B4 RID: 197812
		ToggleSelf,
		// Token: 0x040304B5 RID: 197813
		TexIcon,
		// Token: 0x040304B6 RID: 197814
		TxtName
	}
}
