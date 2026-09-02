using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200132D RID: 4909
public class FightPhotoFocusView : UiViewBase
{
	// Token: 0x060085E5 RID: 34277 RVA: 0x002344C7 File Offset: 0x002326C7
	[NullableContext(1)]
	public FightPhotoFocusView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060085E6 RID: 34278 RVA: 0x002344D0 File Offset: 0x002326D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x060085E7 RID: 34279 RVA: 0x002344F3 File Offset: 0x002326F3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnNeedShowFightPhotoFocus, new Action<bool>(this.OnNeedShowFightPhotoFocus));
	}

	// Token: 0x060085E8 RID: 34280 RVA: 0x00234511 File Offset: 0x00232711
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnNeedShowFightPhotoFocus, new Action<bool>(this.OnNeedShowFightPhotoFocus));
	}

	// Token: 0x060085E9 RID: 34281 RVA: 0x0023452F File Offset: 0x0023272F
	protected override void OnBeforeShow()
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x060085EA RID: 34282 RVA: 0x00234543 File Offset: 0x00232743
	private void OnNeedShowFightPhotoFocus(bool needShow)
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(needShow);
	}

	// Token: 0x020076CF RID: 30415
	private enum EComponents
	{
		// Token: 0x04028EB5 RID: 167605
		ItemFocusFrame
	}
}
