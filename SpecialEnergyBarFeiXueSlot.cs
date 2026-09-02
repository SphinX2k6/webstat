using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;

// Token: 0x020017AB RID: 6059
public class SpecialEnergyBarFeiXueSlot : SpecialEnergyBarSlot
{
	// Token: 0x0600AB0B RID: 43787 RVA: 0x002DB4D4 File Offset: 0x002D96D4
	protected override void OnStart()
	{
		base.OnStart();
		this.RefreshFullState(this.GetKeyEnable(), true);
		foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
		{
			specialEnergyBarSlotItem.SetFullEffectPercent(1f);
		}
	}

	// Token: 0x0600AB0C RID: 43788 RVA: 0x002DB53C File Offset: 0x002D973C
	protected override void RefreshBarPercent(bool isStart = false)
	{
		base.RefreshBarPercent(isStart);
		this.RefreshFullState(this.GetKeyEnable(), false);
	}

	// Token: 0x0600AB0D RID: 43789 RVA: 0x002DB552 File Offset: 0x002D9752
	private void RefreshFullState(bool isFull, bool isStart = false)
	{
		if (this.IsFull == isFull && !isStart)
		{
			return;
		}
		this.IsFull = isFull;
		if (this.FullStateChangedCallback != null)
		{
			this.FullStateChangedCallback(isFull);
		}
	}

	// Token: 0x04005167 RID: 20839
	private bool IsFull;

	// Token: 0x04005168 RID: 20840
	[Nullable(2)]
	public Action<bool> FullStateChangedCallback;
}
