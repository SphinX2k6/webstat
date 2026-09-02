using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001333 RID: 4915
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FightPhotoLevelItem : GridProxyAbstract<FightPhotoLevelData>
{
	// Token: 0x06008631 RID: 34353 RVA: 0x00235BD8 File Offset: 0x00233DD8
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		int num = 1;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list;
	}

	// Token: 0x06008632 RID: 34354 RVA: 0x00235C9B File Offset: 0x00233E9B
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CheckCanClick));
	}

	// Token: 0x06008633 RID: 34355 RVA: 0x00235CC0 File Offset: 0x00233EC0
	public override void Refresh(FightPhotoLevelData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		string textStringId = this.Data.IsDifficulty ? "FightPhotoDifficulty" : "FightPhotoEasy";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, Array.Empty<object>());
		base.GetItem(1).SetUIActive(!this.Data.IsUnLock);
		base.GetItem(2).SetUIActive(this.Data.IsFinished);
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.Data.HasRedDot);
	}

	// Token: 0x06008634 RID: 34356 RVA: 0x00235D52 File Offset: 0x00233F52
	private void OnToggleClick(EToggleState toggleState)
	{
		Action<FightPhotoLevelData> onToggleCallBack = this.OnToggleCallBack;
		if (onToggleCallBack == null)
		{
			return;
		}
		onToggleCallBack(this.Data);
	}

	// Token: 0x06008635 RID: 34357 RVA: 0x00235D6A File Offset: 0x00233F6A
	private bool CheckCanClick()
	{
		return this.CheckToggleCanClick == null || this.CheckToggleCanClick();
	}

	// Token: 0x06008636 RID: 34358 RVA: 0x00235D81 File Offset: 0x00233F81
	public override object GetKey(FightPhotoLevelData data, int displayIndex)
	{
		return data;
	}

	// Token: 0x06008637 RID: 34359 RVA: 0x00235D84 File Offset: 0x00233F84
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		if (this.Data.HasRedDot)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.Data.ReadRedDot();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshFightPhotoLevelRedDot);
			FightPhotoActivityData activityData = ControllerBase<FightPhotoController>.Instance.GetActivityData();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
		}
	}

	// Token: 0x06008638 RID: 34360 RVA: 0x00235DFE File Offset: 0x00233FFE
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04003F76 RID: 16246
	[Nullable(2)]
	private FightPhotoLevelData Data;

	// Token: 0x04003F77 RID: 16247
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<FightPhotoLevelData> OnToggleCallBack;

	// Token: 0x04003F78 RID: 16248
	[Nullable(2)]
	public Func<bool> CheckToggleCanClick;

	// Token: 0x020076D6 RID: 30422
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028EF0 RID: 167664
		ToggleRoot,
		// Token: 0x04028EF1 RID: 167665
		ItemLock,
		// Token: 0x04028EF2 RID: 167666
		ItemFinished,
		// Token: 0x04028EF3 RID: 167667
		TextName,
		// Token: 0x04028EF4 RID: 167668
		ItemRedDot
	}
}
