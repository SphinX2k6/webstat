using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001336 RID: 4918
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoTaskTabItem : GridProxyAbstract<PhotoFightRewardTab>
{
	// Token: 0x06008645 RID: 34373 RVA: 0x00236130 File Offset: 0x00234330
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x06008646 RID: 34374 RVA: 0x002361B0 File Offset: 0x002343B0
	public override void Refresh(PhotoFightRewardTab data, bool isSelected, int gridIndex)
	{
		this.Data = new PhotoFightRewardTab?(data);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabTitle, Array.Empty<object>());
		bool uiactive = this.activityData.IsTaskHasRedDotByTab(data.TabId);
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06008647 RID: 34375 RVA: 0x0023620C File Offset: 0x0023440C
	private void OnToggleClick(EToggleState toggleState)
	{
		this.OnToggleClickCallBack(this.Data.Value.TabId);
	}

	// Token: 0x06008648 RID: 34376 RVA: 0x00236237 File Offset: 0x00234437
	public override object GetKey(PhotoFightRewardTab data, int displayIndex)
	{
		return data.TabId;
	}

	// Token: 0x06008649 RID: 34377 RVA: 0x00236248 File Offset: 0x00234448
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600864A RID: 34378 RVA: 0x0023626E File Offset: 0x0023446E
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x0600864B RID: 34379 RVA: 0x00236277 File Offset: 0x00234477
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x04003F7C RID: 16252
	private PhotoFightRewardTab? Data;

	// Token: 0x04003F7D RID: 16253
	public FightPhotoActivityData activityData;

	// Token: 0x04003F7E RID: 16254
	public Action<int> OnToggleClickCallBack = delegate(int tabId)
	{
	};

	// Token: 0x020076DA RID: 30426
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028F03 RID: 167683
		ToggleRoot,
		// Token: 0x04028F04 RID: 167684
		TextTabName,
		// Token: 0x04028F05 RID: 167685
		ItemRedDot
	}
}
