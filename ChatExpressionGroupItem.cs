using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001850 RID: 6224
public class ChatExpressionGroupItem : UiPanelBase
{
	// Token: 0x0600B1FF RID: 45567 RVA: 0x002F7C70 File Offset: 0x002F5E70
	[NullableContext(1)]
	public ChatExpressionGroupItem(AActor rootActor)
	{
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600B200 RID: 45568 RVA: 0x002F7C80 File Offset: 0x002F5E80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickedExpressionGroupExtendToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B201 RID: 45569 RVA: 0x002F7D26 File Offset: 0x002F5F26
	private void OnClickedExpressionGroupExtendToggle(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		Action<int> onClicked = this.OnClicked;
		if (onClicked == null)
		{
			return;
		}
		onClicked(this.ExpressionGroupId);
	}

	// Token: 0x0600B202 RID: 45570 RVA: 0x002F7D44 File Offset: 0x002F5F44
	public void Refresh(ChatExpressionGroup expressionGroupConfig)
	{
		this.ExpressionGroupId = expressionGroupConfig.Id;
		string groupTexturePath = expressionGroupConfig.GroupTexturePath;
		UUITexture expressionGroupTexture = base.GetTexture(0);
		expressionGroupTexture.SetUIActive(false);
		base.SetTextureByPath(groupTexturePath, expressionGroupTexture, null, delegate(bool _)
		{
			expressionGroupTexture.SetUIActive(true);
		});
	}

	// Token: 0x0600B203 RID: 45571 RVA: 0x002F7DA7 File Offset: 0x002F5FA7
	public void SetState(EToggleState state, bool bFireEvent = false)
	{
		base.GetExtendToggle(1).SetToggleState(state, bFireEvent, false, false);
	}

	// Token: 0x0600B204 RID: 45572 RVA: 0x002F7DBA File Offset: 0x002F5FBA
	[NullableContext(1)]
	public void BindOnClicked(Action<int> onClicked)
	{
		this.OnClicked = onClicked;
	}

	// Token: 0x0400545D RID: 21597
	private int ExpressionGroupId;

	// Token: 0x0400545E RID: 21598
	[Nullable(2)]
	private Action<int> OnClicked;

	// Token: 0x02007BED RID: 31725
	private class EChildType
	{
		// Token: 0x0402A58D RID: 173453
		public const int ExpressionGroupTexture = 0;

		// Token: 0x0402A58E RID: 173454
		public const int ExpressionGroupButton = 1;
	}
}
