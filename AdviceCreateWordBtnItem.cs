using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200177F RID: 6015
public class AdviceCreateWordBtnItem : UiPanelBase
{
	// Token: 0x0600A971 RID: 43377 RVA: 0x002D2DBF File Offset: 0x002D0FBF
	[NullableContext(1)]
	public AdviceCreateWordBtnItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A972 RID: 43378 RVA: 0x002D2DD4 File Offset: 0x002D0FD4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn))
		};
	}

	// Token: 0x0600A973 RID: 43379 RVA: 0x002D2E3B File Offset: 0x002D103B
	public void SetType(EActiveCreateWordType type)
	{
		this.Type = type;
	}

	// Token: 0x0600A974 RID: 43380 RVA: 0x002D2E44 File Offset: 0x002D1044
	public void SetIndex(int index)
	{
		this.Index = index;
	}

	// Token: 0x0600A975 RID: 43381 RVA: 0x002D2E4D File Offset: 0x002D104D
	private void OnClickBtn()
	{
		if (this.Type == EActiveCreateWordType.NormalWord)
		{
			this.InitSortWordViewParam();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceSortWordView, null, null);
			return;
		}
		this.InitWordViewParam();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceWordView, null, null);
	}

	// Token: 0x0600A976 RID: 43382 RVA: 0x002D2E88 File Offset: 0x002D1088
	private void InitSortWordViewParam()
	{
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		int num;
		if (instance.CurrentWordMap.TryGetValue(this.Index, out num) && num > 0)
		{
			instance.CurrentSelectSortTypeId = ConfigBase<AdviceConfig>.Instance.GetAdviceWordType(num).GetValueOrDefault();
			instance.CurrentSelectSortWordId = num;
		}
		else
		{
			IReadOnlyList<AdviceWordType> adviceWordTypeConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceWordTypeConfigs();
			int currentSelectSortTypeId = (adviceWordTypeConfigs != null && adviceWordTypeConfigs.Count > 0) ? adviceWordTypeConfigs[0].Id : 0;
			instance.CurrentSelectSortTypeId = currentSelectSortTypeId;
			instance.CurrentSelectSortWordId = -1;
		}
		instance.CurrentSelectWordIndex = this.Index;
	}

	// Token: 0x0600A977 RID: 43383 RVA: 0x002D2F1D File Offset: 0x002D111D
	private void InitWordViewParam()
	{
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		instance.CurrentChangeWordType = EChangeWordType.Conjunction;
		instance.CurrentSelectWordId = instance.CurrentConjunctionId;
	}

	// Token: 0x0600A978 RID: 43384 RVA: 0x002D2F36 File Offset: 0x002D1136
	public void RefreshView()
	{
		this.RefreshWord();
	}

	// Token: 0x0600A979 RID: 43385 RVA: 0x002D2F40 File Offset: 0x002D1140
	private void RefreshWord()
	{
		if (this.Type == EActiveCreateWordType.NormalWord)
		{
			int num;
			ModelBase<AdviceModel>.Instance.CurrentWordMap.TryGetValue(this.Index, out num);
			if (num <= 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ChangeWord", Array.Empty<object>());
				return;
			}
			string adviceWordText = ConfigBase<AdviceConfig>.Instance.GetAdviceWordText(num);
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(adviceWordText ?? "", true);
			return;
		}
		else
		{
			int currentConjunctionId = ModelBase<AdviceModel>.Instance.CurrentConjunctionId;
			if (currentConjunctionId <= 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ChangeWord", Array.Empty<object>());
				return;
			}
			string adviceConjunctionText = ConfigBase<AdviceConfig>.Instance.GetAdviceConjunctionText(currentConjunctionId);
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(adviceConjunctionText ?? "", true);
			return;
		}
	}

	// Token: 0x04004FDB RID: 20443
	private EActiveCreateWordType Type;

	// Token: 0x04004FDC RID: 20444
	private int Index;

	// Token: 0x02007AE0 RID: 31456
	private static class EComponents
	{
		// Token: 0x0402A147 RID: 172359
		public const int WordBtn = 0;

		// Token: 0x0402A148 RID: 172360
		public const int WordText = 1;
	}
}
