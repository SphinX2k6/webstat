using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C1E RID: 11294
[NullableContext(1)]
[Nullable(0)]
public class TutorialDataItem : UiPanelBase, IDynamicScrollItem<TutorialItemData>
{
	// Token: 0x060169B2 RID: 92594 RVA: 0x006460A8 File Offset: 0x006442A8
	public UniTask Init(UUIItem actor)
	{
		TutorialDataItem.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<TutorialDataItem.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060169B3 RID: 92595 RVA: 0x006460F3 File Offset: 0x006442F3
	public void ClearItem()
	{
	}

	// Token: 0x060169B4 RID: 92596 RVA: 0x006460F5 File Offset: 0x006442F5
	public AUIBaseActor GetUsingItem(TutorialItemData data)
	{
		if (data.IsTypeTitle)
		{
			return base.GetItem(0).GetOwner() as AUIBaseActor;
		}
		return base.GetRootItem().GetOwner() as AUIBaseActor;
	}

	// Token: 0x060169B5 RID: 92597 RVA: 0x00646121 File Offset: 0x00644321
	public void Update(TutorialItemData data, int index)
	{
		this.TutorialItemData = data;
		if (data.IsTypeTitle)
		{
			this.RefreshTitleItem();
			return;
		}
		this.RefreshTutorialItem();
	}

	// Token: 0x060169B6 RID: 92598 RVA: 0x0064613F File Offset: 0x0064433F
	public void InitData(TutorialItemData data)
	{
		this.TutorialItemData = data;
	}

	// Token: 0x060169B7 RID: 92599 RVA: 0x00646148 File Offset: 0x00644348
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x060169B8 RID: 92600 RVA: 0x006461F4 File Offset: 0x006443F4
	private void OnToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			this.OnToggleSelected(this.TutorialItemData, extendToggle);
		}
	}

	// Token: 0x060169B9 RID: 92601 RVA: 0x0064621F File Offset: 0x0064441F
	public void SetOnToggleSelected(Action<TutorialItemData, UUIExtendToggle> onToggleSelected)
	{
		this.OnToggleSelected = onToggleSelected;
	}

	// Token: 0x060169BA RID: 92602 RVA: 0x00646228 File Offset: 0x00644428
	private void RefreshTitleItem()
	{
		base.GetItem(0).SetUIActive(true);
		base.GetExtendToggle(2).RootUIComp.Get().SetUIActive(false);
		UUIText text = base.GetText(1);
		if (string.IsNullOrEmpty(this.TutorialItemData.Text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.TutorialItemData.TextId, Array.Empty<object>());
			return;
		}
		text.SetText(this.TutorialItemData.Text, true);
	}

	// Token: 0x060169BB RID: 92603 RVA: 0x006462A4 File Offset: 0x006444A4
	private void RefreshTutorialItem()
	{
		base.GetItem(0).SetUIActive(false);
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		extendToggle.RootUIComp.Get().SetUIActive(true);
		UUIText text = base.GetText(4);
		if (string.IsNullOrEmpty(this.TutorialItemData.Text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.TutorialItemData.TextId, Array.Empty<object>());
		}
		else
		{
			text.SetText(this.TutorialItemData.Text, true);
		}
		this.RefreshRed();
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		if (this.TutorialItemData.Selected.GetValueOrDefault())
		{
			this.OnSelected(true);
		}
	}

	// Token: 0x060169BC RID: 92604 RVA: 0x0064634B File Offset: 0x0064454B
	public void RefreshRed()
	{
		if (!this.TutorialItemData.IsTypeTitle)
		{
			base.GetItem(3).SetUIActive(this.TutorialItemData.SavedData.HasRedDot);
		}
	}

	// Token: 0x060169BD RID: 92605 RVA: 0x00646376 File Offset: 0x00644576
	public void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(2).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		this.OnToggleClick(EToggleState.ETT_Checked);
	}

	// Token: 0x060169BE RID: 92606 RVA: 0x00646390 File Offset: 0x00644590
	protected override void OnBeforeDestroy()
	{
		if (this.TutorialItemData != null)
		{
			this.TutorialItemData = null;
		}
	}

	// Token: 0x0400AE7C RID: 44668
	[Nullable(2)]
	private TutorialItemData TutorialItemData;

	// Token: 0x0400AE7D RID: 44669
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<TutorialItemData, UUIExtendToggle> OnToggleSelected;

	// Token: 0x02008F46 RID: 36678
	[NullableContext(0)]
	public enum EComponents
	{
		// Token: 0x040301DB RID: 197083
		ItemTypeTitle,
		// Token: 0x040301DC RID: 197084
		TxtTypeTitle,
		// Token: 0x040301DD RID: 197085
		UUIItemStripD,
		// Token: 0x040301DE RID: 197086
		PnlRedPoint,
		// Token: 0x040301DF RID: 197087
		TxtList
	}
}
