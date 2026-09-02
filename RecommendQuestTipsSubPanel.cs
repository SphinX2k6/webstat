using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001314 RID: 4884
[NullableContext(1)]
[Nullable(0)]
public class RecommendQuestTipsSubPanel : UiPanelBase
{
	// Token: 0x060084E7 RID: 34023 RVA: 0x002306B4 File Offset: 0x0022E8B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickTipsBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060084E8 RID: 34024 RVA: 0x0023075A File Offset: 0x0022E95A
	public void SetTipsTxtByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x060084E9 RID: 34025 RVA: 0x0023076F File Offset: 0x0022E96F
	public void SetTipsTxt(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x060084EA RID: 34026 RVA: 0x0023077F File Offset: 0x0022E97F
	public void BindClickBtnTipsCallBack(TRecommendQuestTipsBtnCallBack callBack)
	{
		this.QuestTipsBtnCallBack = callBack;
	}

	// Token: 0x060084EB RID: 34027 RVA: 0x00230788 File Offset: 0x0022E988
	private void OnClickTipsBtn()
	{
		TRecommendQuestTipsBtnCallBack questTipsBtnCallBack = this.QuestTipsBtnCallBack;
		if (questTipsBtnCallBack == null)
		{
			return;
		}
		questTipsBtnCallBack();
	}

	// Token: 0x060084EC RID: 34028 RVA: 0x0023079C File Offset: 0x0022E99C
	public void SetBtnActive(bool active)
	{
		UUIButtonComponent button = base.GetButton(1);
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem = button.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(active);
	}

	// Token: 0x04003F07 RID: 16135
	[Nullable(2)]
	private TRecommendQuestTipsBtnCallBack QuestTipsBtnCallBack;

	// Token: 0x020076BA RID: 30394
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028E68 RID: 167528
		TxtTips,
		// Token: 0x04028E69 RID: 167529
		BtnTips
	}
}
