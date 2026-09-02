using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001778 RID: 6008
internal class AdviceSelectBtnContentItem : UiPanelBase
{
	// Token: 0x0600A92D RID: 43309 RVA: 0x002D1537 File Offset: 0x002CF737
	[NullableContext(1)]
	public AdviceSelectBtnContentItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A92E RID: 43310 RVA: 0x002D154C File Offset: 0x002CF74C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnChangeBtn)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickDeleteButton))
		};
	}

	// Token: 0x0600A92F RID: 43311 RVA: 0x002D15F8 File Offset: 0x002CF7F8
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectAdviceExpression, new Action(this.OnSelectExpression));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectAdviceWord, new Action(this.RefreshWordText));
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeAdviceWord, new Action(this.RefreshWordConjunctionText));
	}

	// Token: 0x0600A930 RID: 43312 RVA: 0x002D165C File Offset: 0x002CF85C
	private void RefreshWordText()
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.GetIndex() == EAdviceSelectItemEnum.SelectWord1 || this.Data.GetIndex() == EAdviceSelectItemEnum.SelectWord2)
		{
			int key = (this.Data.GetIndex() > EAdviceSelectItemEnum.SelectWord1) ? 1 : 0;
			int num;
			ModelBase<AdviceModel>.Instance.CurrentWordMap.TryGetValue(key, out num);
			if (num > 0)
			{
				string adviceWordText = ConfigBase<AdviceConfig>.Instance.GetAdviceWordText(num);
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetText(adviceWordText ?? "", true);
				}
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.useChangeColor = true;
					return;
				}
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "AdviceFunc_1", Array.Empty<object>());
				UUIText text3 = base.GetText(1);
				if (text3 != null)
				{
					text3.useChangeColor = false;
				}
			}
		}
	}

	// Token: 0x0600A931 RID: 43313 RVA: 0x002D1724 File Offset: 0x002CF924
	private void RefreshWordConjunctionText()
	{
		if (this.Data == null || this.Data.GetIndex() != EAdviceSelectItemEnum.Conjunction)
		{
			return;
		}
		int currentConjunctionId = ModelBase<AdviceModel>.Instance.CurrentConjunctionId;
		if (currentConjunctionId > 0)
		{
			string adviceConjunctionText = ConfigBase<AdviceConfig>.Instance.GetAdviceConjunctionText(currentConjunctionId);
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(adviceConjunctionText ?? "", true);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.useChangeColor = true;
				return;
			}
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "AdviceFunc_1", Array.Empty<object>());
			UUIText text3 = base.GetText(1);
			if (text3 != null)
			{
				text3.useChangeColor = false;
			}
		}
	}

	// Token: 0x0600A932 RID: 43314 RVA: 0x002D17C0 File Offset: 0x002CF9C0
	private void OnSelectExpression()
	{
		this.RefreshExpressionSelectState();
		this.RefreshDeleteButton();
	}

	// Token: 0x0600A933 RID: 43315 RVA: 0x002D17D0 File Offset: 0x002CF9D0
	private void RefreshExpressionSelectState()
	{
		int currentExpressionId = ModelBase<AdviceModel>.Instance.CurrentExpressionId;
		AdviceSelectItemData data = this.Data;
		if (data == null || data.GetIndex() != EAdviceSelectItemEnum.AddExpression)
		{
			return;
		}
		if (currentExpressionId != 0)
		{
			ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(currentExpressionId);
			if (expressionConfig != null)
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.ShowTextNew(expressionConfig.Value.Name);
				}
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.useChangeColor = true;
					return;
				}
			}
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "AdviceFunc_2", Array.Empty<object>());
			UUIText text3 = base.GetText(1);
			if (text3 != null)
			{
				text3.useChangeColor = false;
			}
		}
	}

	// Token: 0x0600A934 RID: 43316 RVA: 0x002D187F File Offset: 0x002CFA7F
	private void OnClickDeleteButton()
	{
		ModelBase<AdviceModel>.Instance.CurrentExpressionId = 0;
		this.RefreshDeleteButton();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectAdviceExpression);
	}

	// Token: 0x0600A935 RID: 43317 RVA: 0x002D18A2 File Offset: 0x002CFAA2
	private void OnChangeBtn()
	{
		if (this.Data != null)
		{
			ModelBase<AdviceModel>.Instance.PreSelectAdviceItemId = (int)this.Data.GetIndex();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceSelectItem);
	}

	// Token: 0x0600A936 RID: 43318 RVA: 0x002D18D1 File Offset: 0x002CFAD1
	[NullableContext(1)]
	public void RefreshView(AdviceSelectItemData data)
	{
		this.Data = data;
		this.RefreshShowText();
		this.RefreshViewByType();
		this.RefreshSprite();
		this.RefreshWordText();
		this.RefreshWordConjunctionText();
		this.RefreshDeleteButton();
	}

	// Token: 0x0600A937 RID: 43319 RVA: 0x002D1900 File Offset: 0x002CFB00
	private void RefreshDeleteButton()
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.GetIndex() == EAdviceSelectItemEnum.AddExpression)
		{
			int currentExpressionId = ModelBase<AdviceModel>.Instance.CurrentExpressionId;
			base.GetButton(3).RootUIComp.Get().SetUIActive(currentExpressionId != 0);
			return;
		}
		base.GetButton(3).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600A938 RID: 43320 RVA: 0x002D1967 File Offset: 0x002CFB67
	private void RefreshViewByType()
	{
		AdviceSelectItemData data = this.Data;
		if (data != null && data.GetIndex() == EAdviceSelectItemEnum.AddExpression)
		{
			this.RefreshExpressionSelectState();
		}
	}

	// Token: 0x0600A939 RID: 43321 RVA: 0x002D1988 File Offset: 0x002CFB88
	private void RefreshShowText()
	{
		if (this.Data == null)
		{
			return;
		}
		EAdviceSelectItemEnum index = this.Data.GetIndex();
		string textTableId = "";
		if (index == EAdviceSelectItemEnum.SelectWord1)
		{
			textTableId = "AdviceFunc_1";
		}
		else if (index == EAdviceSelectItemEnum.Conjunction)
		{
			textTableId = "AdviceFunc_1";
		}
		else if (index == EAdviceSelectItemEnum.SelectWord2)
		{
			textTableId = "AdviceFunc_1";
		}
		else if (index == EAdviceSelectItemEnum.ChangeWordBtn)
		{
			textTableId = "AdviceFunc_3";
		}
		else if (index == EAdviceSelectItemEnum.AddExpression)
		{
			textTableId = "AdviceFunc_2";
		}
		else if (index == EAdviceSelectItemEnum.AddOrDecreaseBtn)
		{
			textTableId = ((ModelBase<AdviceModel>.Instance.CurrentLineModel == ELineMode.SingleLine) ? "AdviceFunc_4" : "AdviceFunc_5");
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textTableId, Array.Empty<object>());
	}

	// Token: 0x0600A93A RID: 43322 RVA: 0x002D1A20 File Offset: 0x002CFC20
	private void RefreshSprite()
	{
		if (this.Data == null)
		{
			return;
		}
		EAdviceSelectItemEnum index = this.Data.GetIndex();
		string path = "";
		if (index == EAdviceSelectItemEnum.SelectWord1)
		{
			path = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnOne.SP_AdviceBtnOne";
		}
		else if (index == EAdviceSelectItemEnum.Conjunction)
		{
			path = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnTwo.SP_AdviceBtnTwo";
		}
		else if (index == EAdviceSelectItemEnum.SelectWord2)
		{
			path = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnThree.SP_AdviceBtnThree";
		}
		else if (index == EAdviceSelectItemEnum.ChangeWordBtn)
		{
			path = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnHuan.SP_AdviceBtnHuan";
		}
		else if (index == EAdviceSelectItemEnum.AddExpression)
		{
			path = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnbiaoqing.SP_AdviceBtnbiaoqing";
		}
		else if (index == EAdviceSelectItemEnum.AddOrDecreaseBtn)
		{
			path = ((ModelBase<AdviceModel>.Instance.CurrentLineModel == ELineMode.SingleLine) ? "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnJia.SP_AdviceBtnJia" : "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnJian.SP_AdviceBtnJian");
		}
		this.SetSpriteByPath(path, base.GetSprite(2), false, null, null);
	}

	// Token: 0x0600A93B RID: 43323 RVA: 0x002D1ABC File Offset: 0x002CFCBC
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectAdviceExpression, new Action(this.OnSelectExpression));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectAdviceWord, new Action(this.RefreshWordText));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeAdviceWord, new Action(this.RefreshWordConjunctionText));
	}

	// Token: 0x04004FC7 RID: 20423
	[Nullable(2)]
	private AdviceSelectItemData Data;

	// Token: 0x02007ADB RID: 31451
	private static class EAdviceSelectBtnContentItemEnum
	{
		// Token: 0x0402A125 RID: 172325
		public const int Button = 0;

		// Token: 0x0402A126 RID: 172326
		public const int Text = 1;

		// Token: 0x0402A127 RID: 172327
		public const int Icon = 2;

		// Token: 0x0402A128 RID: 172328
		public const int DeleteButton = 3;
	}
}
