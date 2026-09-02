using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002B0C RID: 11020
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsTabMainTabItem : CommonTabItemBase
{
	// Token: 0x06016053 RID: 90195 RVA: 0x0061C19C File Offset: 0x0061A39C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick))
		};
	}

	// Token: 0x06016054 RID: 90196 RVA: 0x0061C271 File Offset: 0x0061A471
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06016055 RID: 90197 RVA: 0x0061C28C File Offset: 0x0061A48C
	public void RefreshTabState(ETabState state)
	{
		this.CachedState = state;
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(state == ETabState.Lock);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(state == ETabState.Normal);
		}
		UUIItem item3 = base.GetItem(0);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(state == ETabState.None);
	}

	// Token: 0x06016056 RID: 90198 RVA: 0x0061C2E1 File Offset: 0x0061A4E1
	public void RefreshLevel(int level)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "SurvivorsCombat_Lv", new <>z__ReadOnlySingleElementList<object>(level));
	}

	// Token: 0x06016057 RID: 90199 RVA: 0x0061C304 File Offset: 0x0061A504
	public void RefreshUnlockWave(int unlockWave)
	{
		this.CachedUnlockWave = unlockWave;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "SurvivorsWeaponAttribute_WaveUnlockButton", new <>z__ReadOnlySingleElementList<object>(unlockWave));
	}

	// Token: 0x06016058 RID: 90200 RVA: 0x0061C32E File Offset: 0x0061A52E
	public void SetTextById(string textId)
	{
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(textId);
	}

	// Token: 0x06016059 RID: 90201 RVA: 0x0061C344 File Offset: 0x0061A544
	public void RefreshInfo(string iconPath, int level)
	{
		this.RefreshLevel(level);
		base.SetTextureByPath(iconPath, base.GetTexture(2), null, null);
	}

	// Token: 0x0601605A RID: 90202 RVA: 0x0061C370 File Offset: 0x0061A570
	private void ToggleClick(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		switch (this.CachedState)
		{
		case ETabState.None:
			base.SetForceSwitch(EToggleState.ETT_UnChecked, false);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsCombat_WeaponNoUsed", Array.Empty<object>());
			return;
		case ETabState.Lock:
			base.SetForceSwitch(EToggleState.ETT_UnChecked, false);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsWeaponAttribute_WaveUnlockTips", new object[]
			{
				this.CachedUnlockWave
			});
			return;
		case ETabState.Normal:
		{
			Action<int> selectedCallBack = this.SelectedCallBack;
			if (selectedCallBack == null)
			{
				return;
			}
			selectedCallBack(base.GridIndex);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0601605B RID: 90203 RVA: 0x0061C3FD File Offset: 0x0061A5FD
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x0601605C RID: 90204 RVA: 0x0061C3FF File Offset: 0x0061A5FF
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0601605D RID: 90205 RVA: 0x0061C412 File Offset: 0x0061A612
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x0400A926 RID: 43302
	private ETabState CachedState;

	// Token: 0x0400A927 RID: 43303
	private int CachedUnlockWave = -1;
}
