using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200195F RID: 6495
[NullableContext(1)]
[Nullable(0)]
public class InputMultiKeyItem : UiPanelBase
{
	// Token: 0x0600BA3D RID: 47677 RVA: 0x003196B2 File Offset: 0x003178B2
	[NullableContext(2)]
	public InputMultiKeyItem(bool bListenPlatformChanged = true, bool bListenKeyChanged = true, string uniqueId = null)
	{
	}

	// Token: 0x0600BA3E RID: 47678 RVA: 0x003196D0 File Offset: 0x003178D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BA3F RID: 47679 RVA: 0x0031975C File Offset: 0x0031795C
	protected override UniTask OnBeforeStartAsync()
	{
		InputMultiKeyItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InputMultiKeyItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BA40 RID: 47680 RVA: 0x0031979F File Offset: 0x0031799F
	protected override void OnStart()
	{
		this.InputKeyDisplayData = new InputKeyDisplayData();
	}

	// Token: 0x0600BA41 RID: 47681 RVA: 0x003197AC File Offset: 0x003179AC
	protected override void OnBeforeDestroy()
	{
		InputKeyDisplayData inputKeyDisplayData = this.InputKeyDisplayData;
		if (inputKeyDisplayData != null)
		{
			inputKeyDisplayData.Reset();
		}
		this.OneInputKeyItem = null;
		this.TwoInputKeyItem = null;
	}

	// Token: 0x0600BA42 RID: 47682 RVA: 0x003197D0 File Offset: 0x003179D0
	protected override void OnBeforeShow()
	{
		if (this.<bListenPlatformChanged>P)
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
		if (this.<bListenKeyChanged>P)
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnAxisKeyChanged, new Action<string>(this.OnAxisKeyChanged));
		}
		if (this.ActionOrAxisKeyItem != null)
		{
			this.RefreshByActionOrAxisInternal(this.ActionOrAxisKeyItem);
		}
	}

	// Token: 0x0600BA43 RID: 47683 RVA: 0x00319858 File Offset: 0x00317A58
	protected override void OnAfterHide()
	{
		if (this.<bListenPlatformChanged>P)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
		if (this.<bListenKeyChanged>P)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAxisKeyChanged, new Action<string>(this.OnAxisKeyChanged));
		}
	}

	// Token: 0x0600BA44 RID: 47684 RVA: 0x003198C9 File Offset: 0x00317AC9
	private void InputControllerChange(EInputControllerType eInputControllerType, EInputControllerType inputControllerType)
	{
		if (this.ActionOrAxisKeyItem == null)
		{
			return;
		}
		this.RefreshByActionOrAxisInternal(this.ActionOrAxisKeyItem);
	}

	// Token: 0x0600BA45 RID: 47685 RVA: 0x003198E0 File Offset: 0x00317AE0
	private void OnActionKeyChanged(string actionName)
	{
		if (this.ActionOrAxisKeyItem == null)
		{
			return;
		}
		if (this.ActionOrAxisKeyItem.ActionOrAxisName != actionName)
		{
			return;
		}
		this.RefreshByActionOrAxisInternal(this.ActionOrAxisKeyItem);
	}

	// Token: 0x0600BA46 RID: 47686 RVA: 0x0031990B File Offset: 0x00317B0B
	private void OnAxisKeyChanged(string axisName)
	{
		if (this.ActionOrAxisKeyItem == null)
		{
			return;
		}
		if (this.ActionOrAxisKeyItem.ActionOrAxisName != axisName)
		{
			return;
		}
		this.RefreshByActionOrAxisInternal(this.ActionOrAxisKeyItem);
	}

	// Token: 0x0600BA47 RID: 47687 RVA: 0x00319936 File Offset: 0x00317B36
	public void RefreshByKeyList(InputKeyItemData singleInputKeyItemData, [Nullable(2)] InputKeyItemData doubleInputKeyItem = null)
	{
		this.RefreshByKeyListInternal(singleInputKeyItemData, doubleInputKeyItem, null);
		this.ActionOrAxisKeyItem = null;
	}

	// Token: 0x0600BA48 RID: 47688 RVA: 0x00319948 File Offset: 0x00317B48
	[NullableContext(2)]
	private void RefreshByKeyListInternal([Nullable(1)] InputKeyItemData singleInputKeyItemData, InputKeyItemData doubleInputKeyItem = null, string linkString = null)
	{
		if (singleInputKeyItemData != null)
		{
			InputKeyItem oneInputKeyItem = this.OneInputKeyItem;
			if (oneInputKeyItem != null)
			{
				oneInputKeyItem.Refresh(singleInputKeyItemData);
			}
			InputKeyItem oneInputKeyItem2 = this.OneInputKeyItem;
			if (oneInputKeyItem2 != null)
			{
				oneInputKeyItem2.SetActive(true);
			}
			this.KeyLength = 1;
		}
		UUIText text = base.GetText(0);
		if (doubleInputKeyItem != null)
		{
			InputKeyItem twoInputKeyItem = this.TwoInputKeyItem;
			if (twoInputKeyItem != null)
			{
				twoInputKeyItem.Refresh(doubleInputKeyItem);
			}
			InputKeyItem twoInputKeyItem2 = this.TwoInputKeyItem;
			if (twoInputKeyItem2 != null)
			{
				twoInputKeyItem2.SetActive(true);
			}
			text.SetText(linkString ?? "+", true);
			text.SetUIActive(true);
			this.KeyLength = 2;
			return;
		}
		text.SetUIActive(false);
		InputKeyItem twoInputKeyItem3 = this.TwoInputKeyItem;
		if (twoInputKeyItem3 == null)
		{
			return;
		}
		twoInputKeyItem3.SetActive(false);
	}

	// Token: 0x0600BA49 RID: 47689 RVA: 0x003199EE File Offset: 0x00317BEE
	public void RefreshByKey(InputKeyItemData inputKeyItemData)
	{
		this.RefreshByKeyInternal(inputKeyItemData);
		this.ActionOrAxisKeyItem = null;
	}

	// Token: 0x0600BA4A RID: 47690 RVA: 0x003199FE File Offset: 0x00317BFE
	private void RefreshByKeyInternal(InputKeyItemData inputKeyItemData)
	{
		InputKeyItem oneInputKeyItem = this.OneInputKeyItem;
		if (oneInputKeyItem != null)
		{
			oneInputKeyItem.Refresh(inputKeyItemData);
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		InputKeyItem twoInputKeyItem = this.TwoInputKeyItem;
		if (twoInputKeyItem != null)
		{
			twoInputKeyItem.SetActive(false);
		}
		this.KeyLength = 1;
	}

	// Token: 0x0600BA4B RID: 47691 RVA: 0x00319A3E File Offset: 0x00317C3E
	public void RefreshByActionOrAxis(InputActionOrAxisKeyItem actionOrAxisKeyItem, bool hideMainKey = false)
	{
		this.ActionOrAxisKeyItem = actionOrAxisKeyItem;
		this.HideMainKey = hideMainKey;
		this.RefreshByActionOrAxisInternal(actionOrAxisKeyItem);
	}

	// Token: 0x0600BA4C RID: 47692 RVA: 0x00319A58 File Offset: 0x00317C58
	private void RefreshByActionOrAxisInternal(InputActionOrAxisKeyItem actionOrAxisKeyItem)
	{
		if (this.InputKeyDisplayData == null)
		{
			return;
		}
		string actionOrAxisName = actionOrAxisKeyItem.ActionOrAxisName;
		this.InputKeyDisplayData.Reset();
		bool flag = Singleton<InputSettingsManager>.Instance.GetActionKeyDisplayData(this.InputKeyDisplayData, actionOrAxisName);
		if (!flag)
		{
			flag = Singleton<InputSettingsManager>.Instance.GetAxisKeyDisplayData(this.InputKeyDisplayData, actionOrAxisName);
		}
		if (!flag)
		{
			InputKeyItem oneInputKeyItem = this.OneInputKeyItem;
			if (oneInputKeyItem != null)
			{
				oneInputKeyItem.SetActive(false);
			}
			InputKeyItem twoInputKeyItem = this.TwoInputKeyItem;
			if (twoInputKeyItem != null)
			{
				twoInputKeyItem.SetActive(false);
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			this.KeyLength = 0;
			return;
		}
		int valueOrDefault = actionOrAxisKeyItem.Index.GetValueOrDefault();
		string[] displayKeyNameList = this.InputKeyDisplayData.GetDisplayKeyNameList(valueOrDefault);
		if (displayKeyNameList == null || displayKeyNameList.Length == 0 || (this.HideMainKey && displayKeyNameList.Length == 1))
		{
			InputKeyItem oneInputKeyItem2 = this.OneInputKeyItem;
			if (oneInputKeyItem2 != null)
			{
				oneInputKeyItem2.SetActive(false);
			}
			InputKeyItem twoInputKeyItem2 = this.TwoInputKeyItem;
			if (twoInputKeyItem2 != null)
			{
				twoInputKeyItem2.SetActive(false);
			}
			UUIText text2 = base.GetText(0);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
			this.KeyLength = 0;
			return;
		}
		if (displayKeyNameList.Length == 1)
		{
			this.KeyLength = 1;
			InputKeyItemData singleInputKeyItemData = new InputKeyItemData
			{
				KeyName = displayKeyNameList[0],
				IsLongPressDisable = actionOrAxisKeyItem.IsLongPressDisable,
				LongPressTime = actionOrAxisKeyItem.LongPressTime,
				DelayPressTime = actionOrAxisKeyItem.DelayPressTime,
				IsLongPressProcessVisible = actionOrAxisKeyItem.IsLongPressProcessVisible,
				IsShowLongPressWhenPress = actionOrAxisKeyItem.IsShowLongPressWhenPress,
				IsShowLongPressWhenRelease = actionOrAxisKeyItem.IsShowLongPressWhenRelease,
				IsTextArrowVisible = actionOrAxisKeyItem.IsTextArrowVisible,
				IsUpArrowVisible = actionOrAxisKeyItem.IsUpArrowVisible,
				IsDownArrowVisible = actionOrAxisKeyItem.IsDownArrowVisible,
				IsShowTextArrowWhenPress = actionOrAxisKeyItem.IsShowTextArrowWhenPress,
				IsShowTextArrowWhenRelease = actionOrAxisKeyItem.IsShowTextArrowWhenRelease,
				DescriptionId = actionOrAxisKeyItem.DescriptionId
			};
			this.RefreshByKeyListInternal(singleInputKeyItemData, null, null);
			return;
		}
		if (displayKeyNameList.Length == 2)
		{
			this.KeyLength = 2;
			InputKeyItemData singleInputKeyItemData2 = new InputKeyItemData
			{
				KeyName = displayKeyNameList[0]
			};
			InputKeyItemData inputKeyItemData = new InputKeyItemData
			{
				KeyName = displayKeyNameList[1],
				LongPressTime = actionOrAxisKeyItem.LongPressTime,
				IsLongPressProcessVisible = actionOrAxisKeyItem.IsLongPressProcessVisible,
				IsShowLongPressWhenPress = actionOrAxisKeyItem.IsShowLongPressWhenPress,
				IsShowLongPressWhenRelease = actionOrAxisKeyItem.IsShowLongPressWhenRelease,
				IsTextArrowVisible = actionOrAxisKeyItem.IsTextArrowVisible,
				IsUpArrowVisible = actionOrAxisKeyItem.IsUpArrowVisible,
				IsDownArrowVisible = actionOrAxisKeyItem.IsDownArrowVisible,
				IsShowTextArrowWhenPress = actionOrAxisKeyItem.IsShowTextArrowWhenPress,
				IsShowTextArrowWhenRelease = actionOrAxisKeyItem.IsShowTextArrowWhenRelease,
				DescriptionId = actionOrAxisKeyItem.DescriptionId
			};
			if (this.HideMainKey)
			{
				this.RefreshByKeyListInternal(inputKeyItemData, null, null);
				return;
			}
			this.RefreshByKeyListInternal(singleInputKeyItemData2, inputKeyItemData, actionOrAxisKeyItem.LinkString);
		}
	}

	// Token: 0x0600BA4D RID: 47693 RVA: 0x00319CDC File Offset: 0x00317EDC
	public void SetEnable(bool bEnable, bool bForce = false)
	{
		if (this.IsEnable == bEnable && !bForce)
		{
			return;
		}
		if (bEnable)
		{
			this.RootItem.SetAlpha(1f);
		}
		else
		{
			this.RootItem.SetAlpha(0.2f);
		}
		this.IsEnable = bEnable;
	}

	// Token: 0x0600BA4E RID: 47694 RVA: 0x00319D17 File Offset: 0x00317F17
	public void SetLongPressDisable(bool bDisable)
	{
		if (this.ActionOrAxisKeyItem != null)
		{
			this.ActionOrAxisKeyItem.IsLongPressDisable = new bool?(bDisable);
		}
		InputKeyItem oneInputKeyItem = this.OneInputKeyItem;
		if (oneInputKeyItem != null)
		{
			oneInputKeyItem.SetLongPressDisable(bDisable);
		}
		InputKeyItem twoInputKeyItem = this.TwoInputKeyItem;
		if (twoInputKeyItem == null)
		{
			return;
		}
		twoInputKeyItem.SetLongPressDisable(bDisable);
	}

	// Token: 0x0600BA4F RID: 47695 RVA: 0x00319D55 File Offset: 0x00317F55
	public void SetLongPressTime(float time)
	{
		InputKeyItem oneInputKeyItem = this.OneInputKeyItem;
		if (oneInputKeyItem != null)
		{
			oneInputKeyItem.SetLongPressTime(time);
		}
		InputKeyItem twoInputKeyItem = this.TwoInputKeyItem;
		if (twoInputKeyItem != null)
		{
			twoInputKeyItem.SetLongPressTime(time);
		}
		if (this.ActionOrAxisKeyItem != null)
		{
			this.ActionOrAxisKeyItem.LongPressTime = new float?(time);
		}
	}

	// Token: 0x0600BA50 RID: 47696 RVA: 0x00319D94 File Offset: 0x00317F94
	public void ResetLongPress()
	{
		InputKeyItem oneInputKeyItem = this.OneInputKeyItem;
		if (oneInputKeyItem != null)
		{
			oneInputKeyItem.ResetLongPress();
		}
		InputKeyItem twoInputKeyItem = this.TwoInputKeyItem;
		if (twoInputKeyItem == null)
		{
			return;
		}
		twoInputKeyItem.ResetLongPress();
	}

	// Token: 0x0600BA51 RID: 47697 RVA: 0x00319DB8 File Offset: 0x00317FB8
	public void SetDisableBySingleKeyList(IReadOnlyList<string> keyNameList)
	{
		if (this.KeyLength != 1)
		{
			this.SetEnable(true, false);
			return;
		}
		InputKeyItem oneInputKeyItem = this.OneInputKeyItem;
		string value = (oneInputKeyItem != null) ? oneInputKeyItem.GetKeyName() : null;
		if (string.IsNullOrEmpty(value))
		{
			this.SetEnable(true, false);
			return;
		}
		this.SetEnable(!keyNameList.Contains(value), false);
	}

	// Token: 0x0600BA52 RID: 47698 RVA: 0x00319E0C File Offset: 0x0031800C
	public int GetKeyLength()
	{
		return this.KeyLength;
	}

	// Token: 0x0400581F RID: 22559
	[CompilerGenerated]
	private bool <bListenPlatformChanged>P = bListenPlatformChanged;

	// Token: 0x04005820 RID: 22560
	[CompilerGenerated]
	private bool <bListenKeyChanged>P = bListenKeyChanged;

	// Token: 0x04005821 RID: 22561
	[Nullable(2)]
	[CompilerGenerated]
	private string <uniqueId>P = uniqueId;

	// Token: 0x04005822 RID: 22562
	[Nullable(2)]
	private InputKeyItem OneInputKeyItem;

	// Token: 0x04005823 RID: 22563
	[Nullable(2)]
	private InputKeyItem TwoInputKeyItem;

	// Token: 0x04005824 RID: 22564
	[Nullable(2)]
	private InputKeyDisplayData InputKeyDisplayData;

	// Token: 0x04005825 RID: 22565
	[Nullable(2)]
	private InputActionOrAxisKeyItem ActionOrAxisKeyItem;

	// Token: 0x04005826 RID: 22566
	private bool HideMainKey;

	// Token: 0x04005827 RID: 22567
	private bool IsEnable;

	// Token: 0x04005828 RID: 22568
	private int KeyLength;

	// Token: 0x02007C7B RID: 31867
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A82B RID: 174123
		public const int AddText = 0;

		// Token: 0x0402A82C RID: 174124
		public const int KeyItem1 = 1;

		// Token: 0x0402A82D RID: 174125
		public const int KeyItem2 = 2;
	}
}
