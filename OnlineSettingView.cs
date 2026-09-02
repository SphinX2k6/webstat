using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200234D RID: 9037
public class OnlineSettingView : UiViewBase
{
	// Token: 0x06011432 RID: 70706 RVA: 0x004BEDDA File Offset: 0x004BCFDA
	[NullableContext(1)]
	public OnlineSettingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011433 RID: 70707 RVA: 0x004BEDE4 File Offset: 0x004BCFE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickSettingConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011434 RID: 70708 RVA: 0x004BEEAB File Offset: 0x004BD0AB
	protected override void OnBeforeShow()
	{
		this.EditSetting = ModelBase<OnlineModel>.Instance.CurrentPermissionsSetting;
		this.InitSettingToggle();
	}

	// Token: 0x06011435 RID: 70709 RVA: 0x004BEEC3 File Offset: 0x004BD0C3
	protected override void OnBeforeDestroy()
	{
		if (this.SettingButtonType != null)
		{
			this.SettingButtonType.Clear();
		}
		this.SettingButtonType = null;
	}

	// Token: 0x06011436 RID: 70710 RVA: 0x004BEEE0 File Offset: 0x004BD0E0
	private void InitSettingToggle()
	{
		this.SettingButtonType = new Dictionary<int, OnlineHallSettingButton>();
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(0);
		this.CreateSettingButton(item.GetOwner(), 0);
		for (int i = 1; i < 4; i++)
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item, item2);
			this.CreateSettingButton(uuiitem.GetOwner(), i);
		}
		this.EditSetting = ModelBase<OnlineModel>.Instance.CurrentPermissionsSetting;
		foreach (KeyValuePair<int, OnlineHallSettingButton> keyValuePair in this.SettingButtonType)
		{
			if (keyValuePair.Key == (int)this.EditSetting)
			{
				keyValuePair.Value.SetSelected(true);
			}
			else
			{
				keyValuePair.Value.SetSelected(false);
			}
		}
	}

	// Token: 0x06011437 RID: 70711 RVA: 0x004BEFB8 File Offset: 0x004BD1B8
	[NullableContext(1)]
	private void CreateSettingButton(AActor uiContainerActor, int type)
	{
		OnlineHallSettingButton onlineHallSettingButton = new OnlineHallSettingButton(uiContainerActor, (WorldEnterPermission)type);
		onlineHallSettingButton.BindOnSettingButtonClickedCallback(new Action<WorldEnterPermission>(this.OnClickSettingBtn));
		onlineHallSettingButton.BindCanToggleExecuteChange(new Func<WorldEnterPermission, bool>(this.CanToggleChange));
		this.SettingButtonType.Add(type, onlineHallSettingButton);
	}

	// Token: 0x06011438 RID: 70712 RVA: 0x004BEFFE File Offset: 0x004BD1FE
	private bool CanToggleChange(WorldEnterPermission type)
	{
		return this.EditSetting != type;
	}

	// Token: 0x06011439 RID: 70713 RVA: 0x004BF00C File Offset: 0x004BD20C
	private void OnClickSettingConfirmBtn()
	{
		ControllerBase<OnlineController>.Instance.WorldEnterPermissionsRequest(this.EditSetting);
		base.CloseMe(null);
	}

	// Token: 0x0601143A RID: 70714 RVA: 0x004BF028 File Offset: 0x004BD228
	private void OnClickSettingBtn(WorldEnterPermission type)
	{
		this.EditSetting = type;
		foreach (KeyValuePair<int, OnlineHallSettingButton> keyValuePair in this.SettingButtonType)
		{
			if (keyValuePair.Key == (int)this.EditSetting)
			{
				keyValuePair.Value.SetSelected(true);
			}
			else
			{
				keyValuePair.Value.SetSelected(false);
			}
		}
	}

	// Token: 0x04008799 RID: 34713
	private const int SETTING_COUNT_ID = 4;

	// Token: 0x0400879A RID: 34714
	private WorldEnterPermission EditSetting;

	// Token: 0x0400879B RID: 34715
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, OnlineHallSettingButton> SettingButtonType;

	// Token: 0x02008667 RID: 34407
	private enum EOnlineSettingView
	{
		// Token: 0x0402D76A RID: 186218
		SettingToggleGroup,
		// Token: 0x0402D76B RID: 186219
		SettingToggle,
		// Token: 0x0402D76C RID: 186220
		SettingConfirm
	}
}
