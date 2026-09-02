using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200119A RID: 4506
[NullableContext(1)]
[Nullable(0)]
public class AdvanceNoticeTabItem : CommonTabItemBase
{
	// Token: 0x0600768B RID: 30347 RVA: 0x001F08DC File Offset: 0x001EEADC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggleSpriteTransition)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick))
		};
	}

	// Token: 0x0600768C RID: 30348 RVA: 0x001F099B File Offset: 0x001EEB9B
	protected override void OnStart()
	{
		base.OnStart();
		this.GetTabToggle().SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x0600768D RID: 30349 RVA: 0x001F09C0 File Offset: 0x001EEBC0
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x0600768E RID: 30350 RVA: 0x001F09D9 File Offset: 0x001EEBD9
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		base.UpdateTabIcon(data.Data.GetIcon());
		this.UpdateTitle(data.Data.GetTabItemTitleData().TextId);
	}

	// Token: 0x0600768F RID: 30351 RVA: 0x001F0A04 File Offset: 0x001EEC04
	protected override void OnUpdateTabIcon(string iconPath)
	{
		this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, new Action<bool>(this.RefreshTransition));
	}

	// Token: 0x06007690 RID: 30352 RVA: 0x001F0A38 File Offset: 0x001EEC38
	protected void RefreshTransition(bool result)
	{
		UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(3);
		if (uiExtendToggleSpriteTransition != null)
		{
			uiExtendToggleSpriteTransition.SetAllStateSprite(base.GetSprite(0).GetSprite());
		}
	}

	// Token: 0x06007691 RID: 30353 RVA: 0x001F0A62 File Offset: 0x001EEC62
	public void UpdateTitle(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textId, Array.Empty<object>());
	}

	// Token: 0x06007692 RID: 30354 RVA: 0x001F0A7B File Offset: 0x001EEC7B
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		this.GetTabToggle().SetToggleState(state, bFire, false, false);
	}

	// Token: 0x06007693 RID: 30355 RVA: 0x001F0A8D File Offset: 0x001EEC8D
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x020074F8 RID: 29944
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028625 RID: 165413
		public const int TabIconSprite = 0;

		// Token: 0x04028626 RID: 165414
		public const int ItemToggle = 1;

		// Token: 0x04028627 RID: 165415
		public const int RedDotItem = 2;

		// Token: 0x04028628 RID: 165416
		public const int TabIconTransition = 3;

		// Token: 0x04028629 RID: 165417
		public const int SubIconSprite = 4;

		// Token: 0x0402862A RID: 165418
		public const int TabNameText = 5;
	}
}
