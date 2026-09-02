using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001781 RID: 6017
public class AdviceExpressionItem : GridProxyAbstract<ChatExpression>
{
	// Token: 0x0600A984 RID: 43396 RVA: 0x002D33B0 File Offset: 0x002D15B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedExpressionButton))
		};
	}

	// Token: 0x0600A985 RID: 43397 RVA: 0x002D3443 File Offset: 0x002D1643
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceExpression, new Action(this.OnClickedExpression));
	}

	// Token: 0x0600A986 RID: 43398 RVA: 0x002D3461 File Offset: 0x002D1661
	private void OnClickedExpression()
	{
		this.RefreshSelectState();
		this.RefreshToggleView();
	}

	// Token: 0x0600A987 RID: 43399 RVA: 0x002D346F File Offset: 0x002D166F
	private void OnClickedExpressionButton(EToggleState state)
	{
		ModelBase<AdviceModel>.Instance.PreSelectExpressionId = this.ExpressionId;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceExpression);
	}

	// Token: 0x0600A988 RID: 43400 RVA: 0x002D3494 File Offset: 0x002D1694
	public override void Refresh(ChatExpression expressionConfig, bool isSelected, int gridIndex)
	{
		this.ExpressionId = expressionConfig.Id;
		string expressionTexturePath = expressionConfig.ExpressionTexturePath;
		base.SetTextureByPath(expressionTexturePath, base.GetTexture(2), null, null);
		string name = expressionConfig.Name;
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(name);
		}
		this.RefreshSelectState();
		this.RefreshToggleView();
	}

	// Token: 0x0600A989 RID: 43401 RVA: 0x002D34F8 File Offset: 0x002D16F8
	private void RefreshToggleView()
	{
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		EToggleState etoggleState = (ModelBase<AdviceModel>.Instance.PreSelectExpressionId == this.ExpressionId) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (toggleState != etoggleState)
		{
			base.GetExtendToggle(0).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x0600A98A RID: 43402 RVA: 0x002D3540 File Offset: 0x002D1740
	private void RefreshSelectState()
	{
		int currentExpressionId = ModelBase<AdviceModel>.Instance.CurrentExpressionId;
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(currentExpressionId == this.ExpressionId);
	}

	// Token: 0x0600A98B RID: 43403 RVA: 0x002D3572 File Offset: 0x002D1772
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceExpression, new Action(this.OnClickedExpression));
	}

	// Token: 0x04004FE1 RID: 20449
	private int ExpressionId;

	// Token: 0x02007AE2 RID: 31458
	private static class EChildType
	{
		// Token: 0x0402A14C RID: 172364
		public const int ExpressionToggle = 0;

		// Token: 0x0402A14D RID: 172365
		public const int ExpressionNameText = 1;

		// Token: 0x0402A14E RID: 172366
		public const int ExpressionTexture = 2;

		// Token: 0x0402A14F RID: 172367
		public const int SelectItem = 3;
	}
}
