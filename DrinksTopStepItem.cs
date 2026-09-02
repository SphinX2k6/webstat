using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200102A RID: 4138
public class DrinksTopStepItem : UiPanelBase
{
	// Token: 0x06006B9C RID: 27548 RVA: 0x001C32B4 File Offset: 0x001C14B4
	public DrinksTopStepItem(int step)
	{
		this.Step = step;
		this.StepType = (int)DrinksUtils.GetStepType(this.Step);
	}

	// Token: 0x17000851 RID: 2129
	// (get) Token: 0x06006B9D RID: 27549 RVA: 0x001C32E2 File Offset: 0x001C14E2
	// (set) Token: 0x06006B9E RID: 27550 RVA: 0x001C32EA File Offset: 0x001C14EA
	public int Step { get; set; }

	// Token: 0x06006B9F RID: 27551 RVA: 0x001C32F4 File Offset: 0x001C14F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06006BA0 RID: 27552 RVA: 0x001C3350 File Offset: 0x001C1550
	public void UpdateCurState(EDrinksPlayStep curStep)
	{
		EToggleState state = (curStep == (EDrinksPlayStep)this.Step || (DrinksUtils.GetStepType((int)curStep) == EDrinksRequireType.Batching && this.StepType == 2)) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		this.UpdateStepItem();
	}

	// Token: 0x06006BA1 RID: 27553 RVA: 0x001C33A4 File Offset: 0x001C15A4
	public void UpdateStepItem()
	{
		DrinksResultInfo currentPlayData = ModelBase<DrinksModel>.Instance.GetCurrentPlayData();
		if (this.StepType == 1)
		{
			if (currentPlayData.DrinkBase[this.Step] == 0)
			{
				this.SetEmpty(true);
				return;
			}
			this.SetEmpty(false);
			base.SetTextureByPath(ConfigBase<DrinksConfig>.Instance.GetDrinkBase(currentPlayData.DrinkBase[this.Step]).Value.DrinkIcon, base.GetTexture(2), null, null);
			return;
		}
		else if (this.StepType == 3)
		{
			if (currentPlayData.Ornament == 0)
			{
				this.SetEmpty(true);
				return;
			}
			this.SetEmpty(false);
			base.SetTextureByPath(ConfigBase<DrinksConfig>.Instance.GetOrnament(currentPlayData.Ornament).Value.Icon, base.GetTexture(2), null, null);
			return;
		}
		else
		{
			if (currentPlayData.Batching == null)
			{
				this.SetEmpty(true);
				return;
			}
			int num = this.Step - 2;
			if (currentPlayData.Batching.Count <= num || currentPlayData.Batching[num] == 0)
			{
				this.SetEmpty(true);
				return;
			}
			this.SetEmpty(false);
			base.SetTextureByPath(ConfigBase<DrinksConfig>.Instance.GetBatching(currentPlayData.Batching[num]).Value.Icon, base.GetTexture(2), null, null);
			return;
		}
	}

	// Token: 0x06006BA2 RID: 27554 RVA: 0x001C350B File Offset: 0x001C170B
	protected void SetEmpty(bool isEmpty)
	{
		this.IsEmpty = isEmpty;
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(isEmpty);
		}
		UUITexture texture2 = base.GetTexture(2);
		if (texture2 == null)
		{
			return;
		}
		texture2.SetUIActive(!isEmpty);
	}

	// Token: 0x04003332 RID: 13106
	protected int StepType = 1;

	// Token: 0x04003333 RID: 13107
	protected bool IsEmpty = true;

	// Token: 0x0200740B RID: 29707
	private static class EItem
	{
		// Token: 0x04028225 RID: 164389
		public const int Self = 0;

		// Token: 0x04028226 RID: 164390
		public const int TexEmpty = 1;

		// Token: 0x04028227 RID: 164391
		public const int TexIcon = 2;
	}
}
