using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F1F RID: 7967
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryEquipTabView : UiTabViewBase
{
	// Token: 0x1700122A RID: 4650
	// (get) Token: 0x0600EE5E RID: 61022 RVA: 0x00411A41 File Offset: 0x0040FC41
	public HonamiStoryInteractController DragController { get; } = new HonamiStoryInteractController();

	// Token: 0x0600EE5F RID: 61023 RVA: 0x00411A4C File Offset: 0x0040FC4C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EE60 RID: 61024 RVA: 0x00411AF8 File Offset: 0x0040FCF8
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryEquipTabView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryEquipTabView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE61 RID: 61025 RVA: 0x00411B3B File Offset: 0x0040FD3B
	protected override void OnBeforeShow()
	{
		this.DragController.OnBeforeShow();
	}

	// Token: 0x0600EE62 RID: 61026 RVA: 0x00411B48 File Offset: 0x0040FD48
	private UniTask InitPlayerBackpackPanel()
	{
		HonamiStoryEquipTabView.<InitPlayerBackpackPanel>d__9 <InitPlayerBackpackPanel>d__;
		<InitPlayerBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPlayerBackpackPanel>d__.<>4__this = this;
		<InitPlayerBackpackPanel>d__.<>1__state = -1;
		<InitPlayerBackpackPanel>d__.<>t__builder.Start<HonamiStoryEquipTabView.<InitPlayerBackpackPanel>d__9>(ref <InitPlayerBackpackPanel>d__);
		return <InitPlayerBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE63 RID: 61027 RVA: 0x00411B8C File Offset: 0x0040FD8C
	private UniTask InitBackpackPanel()
	{
		HonamiStoryEquipTabView.<InitBackpackPanel>d__10 <InitBackpackPanel>d__;
		<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBackpackPanel>d__.<>4__this = this;
		<InitBackpackPanel>d__.<>1__state = -1;
		<InitBackpackPanel>d__.<>t__builder.Start<HonamiStoryEquipTabView.<InitBackpackPanel>d__10>(ref <InitBackpackPanel>d__);
		return <InitBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE64 RID: 61028 RVA: 0x00411BD0 File Offset: 0x0040FDD0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "RolePanel" || a == "Equips" || a == "AddBtn" || a == "UpdateBtn")
		{
			HonamiStoryEquipBackpackPanel equipPanel = this.EquipPanel;
			if (equipPanel == null)
			{
				return null;
			}
			return equipPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			if (!(a == "BtnSell") && !(a == "ToggleSelect") && !(a == "BtnReset"))
			{
				return null;
			}
			HonamiStoryBackpackPanel backpackPanel = this.BackpackPanel;
			if (backpackPanel == null)
			{
				return null;
			}
			return backpackPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x04007264 RID: 29284
	private HonamiStoryEquipBackpackPanel EquipPanel;

	// Token: 0x04007265 RID: 29285
	public HonamiStoryBackpackPanel BackpackPanel;

	// Token: 0x02008293 RID: 33427
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C49B RID: 181403
		EquipPanel,
		// Token: 0x0402C49C RID: 181404
		BackpackPanel,
		// Token: 0x0402C49D RID: 181405
		InteractPanel,
		// Token: 0x0402C49E RID: 181406
		AttachPanel
	}
}
