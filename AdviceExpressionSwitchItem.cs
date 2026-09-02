using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001782 RID: 6018
[NullableContext(1)]
[Nullable(0)]
public class AdviceExpressionSwitchItem : CommonTabItemBase
{
	// Token: 0x0600A98D RID: 43405 RVA: 0x002D3598 File Offset: 0x002D1798
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleToggle))
		};
	}

	// Token: 0x0600A98E RID: 43406 RVA: 0x002D35FF File Offset: 0x002D17FF
	protected override void OnStart()
	{
		base.OnStart();
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600A98F RID: 43407 RVA: 0x002D361D File Offset: 0x002D181D
	private void OnExtendToggleToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked && this.SelectedCallBack != null)
		{
			this.SelectedCallBack(this.ExpressionGroupId);
		}
	}

	// Token: 0x0600A990 RID: 43408 RVA: 0x002D363E File Offset: 0x002D183E
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0600A991 RID: 43409 RVA: 0x002D3656 File Offset: 0x002D1856
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		CommonTabData data2 = data.Data;
		base.UpdateTabIcon((data2 != null) ? data2.GetIcon() : null);
	}

	// Token: 0x0600A992 RID: 43410 RVA: 0x002D3670 File Offset: 0x002D1870
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x0600A993 RID: 43411 RVA: 0x002D3672 File Offset: 0x002D1872
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0600A994 RID: 43412 RVA: 0x002D367C File Offset: 0x002D187C
	public void UpdateView(int groupId)
	{
		this.ExpressionGroupId = groupId;
		ChatExpressionGroup? expressionGroupConfig = ConfigBase<ChatConfig>.Instance.GetExpressionGroupConfig(groupId);
		if (expressionGroupConfig != null)
		{
			string groupTexturePath = expressionGroupConfig.Value.GroupTexturePath;
			base.SetTextureByPath(groupTexturePath, base.GetTexture(1), null, null);
		}
	}

	// Token: 0x04004FE2 RID: 20450
	private int ExpressionGroupId;

	// Token: 0x02007AE3 RID: 31459
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402A150 RID: 172368
		public const int SwitchToggle = 0;

		// Token: 0x0402A151 RID: 172369
		public const int ExpressionImg = 1;
	}
}
