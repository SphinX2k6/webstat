using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.UiNavigation;

// Token: 0x02002CCC RID: 11468
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class UiNavigationModel : ModelBase<UiNavigationModel>
{
	// Token: 0x06017196 RID: 94614 RVA: 0x0066696C File Offset: 0x00664B6C
	public void InputControllerModeChange()
	{
		foreach (HashSet<HotKeyComponent> hashSet in this.ActionNameHotKeyComponentMap.Values)
		{
			foreach (HotKeyComponent hotKeyComponent in hashSet)
			{
				hotKeyComponent.RefreshMode();
			}
		}
		foreach (HashSet<HotKeyComponent> hashSet2 in this.AxisNameHotKeyComponentMap.Values)
		{
			foreach (HotKeyComponent hotKeyComponent2 in hashSet2)
			{
				hotKeyComponent2.RefreshMode();
			}
		}
		foreach (TsUiNavigationPlatformChangeListener tsUiNavigationPlatformChangeListener in this.PlatformListenerSet)
		{
			tsUiNavigationPlatformChangeListener.ChangeAlpha();
		}
	}

	// Token: 0x06017197 RID: 94615 RVA: 0x00666AAC File Offset: 0x00664CAC
	public unsafe void CustomShieldHotKeyComponent(HashSet<int> excludeHotKeyIndexSet, bool bActive)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "业务触发自定义屏蔽热键组件";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("excludeHotKeyIndexSet", excludeHotKeyIndexSet);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bActive", bActive);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		foreach (HashSet<HotKeyComponent> hashSet in this.ActionNameHotKeyComponentMap.Values)
		{
			foreach (HotKeyComponent hotKeyComponent in hashSet)
			{
				if (!excludeHotKeyIndexSet.Contains(hotKeyComponent.GetHotKeyMapIndex()))
				{
					hotKeyComponent.OnlySetVisibleMode(HotKeyViewDefine.ELogicMode.CustomShield, bActive);
				}
			}
		}
		foreach (HashSet<HotKeyComponent> hashSet2 in this.AxisNameHotKeyComponentMap.Values)
		{
			foreach (HotKeyComponent hotKeyComponent2 in hashSet2)
			{
				if (!excludeHotKeyIndexSet.Contains(hotKeyComponent2.GetHotKeyMapIndex()))
				{
					hotKeyComponent2.OnlySetVisibleMode(HotKeyViewDefine.ELogicMode.CustomShield, bActive);
				}
			}
		}
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
	}

	// Token: 0x06017198 RID: 94616 RVA: 0x00666C44 File Offset: 0x00664E44
	protected override bool OnClear()
	{
		this.ClearCursor();
		UiNavigationGlobalData.ClearBlockListener();
		return true;
	}

	// Token: 0x06017199 RID: 94617 RVA: 0x00666C52 File Offset: 0x00664E52
	[NullableContext(2)]
	public void SetCursorFollowItem(TsUiNavigationBehaviorListener listener)
	{
		this.Cursor.SetFollowItem(listener);
	}

	// Token: 0x0601719A RID: 94618 RVA: 0x00666C60 File Offset: 0x00664E60
	public void SetIsUseMouse(bool value)
	{
		this.Cursor.SetIsUseMouse(value);
	}

	// Token: 0x0601719B RID: 94619 RVA: 0x00666C6E File Offset: 0x00664E6E
	public void MarkMoveInstantly()
	{
		this.Cursor.IsMoveInstantly = true;
	}

	// Token: 0x0601719C RID: 94620 RVA: 0x00666C7C File Offset: 0x00664E7C
	public void SetCursorActiveDelayTime(float time)
	{
		this.Cursor.SetCursorActiveDelayTime(time);
	}

	// Token: 0x0601719D RID: 94621 RVA: 0x00666C8A File Offset: 0x00664E8A
	public void TrySetCursorActive(bool value)
	{
		this.Cursor.TrySetUseItemUiActive(value);
	}

	// Token: 0x0601719E RID: 94622 RVA: 0x00666C98 File Offset: 0x00664E98
	public void RefreshCursorActive()
	{
		this.Cursor.RefreshCursorActive();
	}

	// Token: 0x0601719F RID: 94623 RVA: 0x00666CA5 File Offset: 0x00664EA5
	public void RepeatMove()
	{
		this.Cursor.RepeatMove();
	}

	// Token: 0x060171A0 RID: 94624 RVA: 0x00666CB4 File Offset: 0x00664EB4
	public void ClearCursor()
	{
		Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "清理光标", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.Cursor.Clear();
	}

	// Token: 0x060171A1 RID: 94625 RVA: 0x00666CEB File Offset: 0x00664EEB
	protected override bool OnLeaveLevel()
	{
		this.ClearCursor();
		return true;
	}

	// Token: 0x060171A2 RID: 94626 RVA: 0x00666CF4 File Offset: 0x00664EF4
	public void Tick(float delta)
	{
		this.Cursor.Tick(delta);
	}

	// Token: 0x060171A3 RID: 94627 RVA: 0x00666D02 File Offset: 0x00664F02
	public void AddActionHotKeyComponent(string actionName, HashSet<HotKeyComponent> hotKeyComponentSet)
	{
		this.ActionNameHotKeyComponentMap[actionName] = hotKeyComponentSet;
	}

	// Token: 0x060171A4 RID: 94628 RVA: 0x00666D11 File Offset: 0x00664F11
	public HashSet<HotKeyComponent> GetActionHotKeyComponentSet(string actionName)
	{
		return this.ActionNameHotKeyComponentMap[actionName];
	}

	// Token: 0x060171A5 RID: 94629 RVA: 0x00666D20 File Offset: 0x00664F20
	public HashSet<HotKeyComponent> GetOrAddActionHotKeyComponentSet(string actionName)
	{
		HashSet<HotKeyComponent> hashSet;
		if (!this.ActionNameHotKeyComponentMap.TryGetValue(actionName, out hashSet))
		{
			hashSet = new HashSet<HotKeyComponent>();
			this.AddActionHotKeyComponent(actionName, hashSet);
		}
		return hashSet;
	}

	// Token: 0x060171A6 RID: 94630 RVA: 0x00666D4C File Offset: 0x00664F4C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] CheckActionNameInKeySet(string actionName, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] ValueTuple<IReadOnlyList<string>, bool> inKeyNameData)
	{
		HashSet<string> hashSet = new HashSet<string>(inKeyNameData.Item1);
		ValueTuple<IReadOnlyList<string>, bool>? platformKeyNameDataByActionName = this.GetPlatformKeyNameDataByActionName(actionName);
		if (platformKeyNameDataByActionName == null)
		{
			return null;
		}
		bool item = inKeyNameData.Item2;
		bool item2 = platformKeyNameDataByActionName.Value.Item2;
		if (item == item2)
		{
			if (item)
			{
				HashSet<string> hashSet2 = new HashSet<string>();
				foreach (string item3 in platformKeyNameDataByActionName.Value.Item1)
				{
					if (hashSet.Contains(item3))
					{
						hashSet2.Add(item3);
					}
				}
				if (hashSet2.Count == hashSet.Count)
				{
					return hashSet2.ToArray<string>();
				}
			}
			else
			{
				foreach (string text in platformKeyNameDataByActionName.Value.Item1)
				{
					if (hashSet.Contains(text))
					{
						return new string[]
						{
							text
						};
					}
				}
			}
		}
		return null;
	}

	// Token: 0x060171A7 RID: 94631 RVA: 0x00666E6C File Offset: 0x0066506C
	[return: Nullable(2)]
	private string CheckAxisNameInKeySet(string axisName, HashSet<string> keyNameSet)
	{
		IReadOnlyList<string> platformKeyNameListByAxisName = this.GetPlatformKeyNameListByAxisName(axisName);
		if (platformKeyNameListByAxisName == null)
		{
			return null;
		}
		foreach (string text in platformKeyNameListByAxisName)
		{
			if (keyNameSet.Contains(text))
			{
				return text;
			}
		}
		return null;
	}

	// Token: 0x060171A8 RID: 94632 RVA: 0x00666ECC File Offset: 0x006650CC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<IReadOnlyList<string>, bool>? GetPlatformKeyNameDataByActionName(string actionName)
	{
		InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
		if (combinationActionBindingByActionName != null)
		{
			List<string> list = new List<string>();
			combinationActionBindingByActionName.GetCurrentPlatformKeyNameList(list);
			if (list.Count > 0)
			{
				return new ValueTuple<IReadOnlyList<string>, bool>?(new ValueTuple<IReadOnlyList<string>, bool>(list, true));
			}
		}
		InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionName);
		if (actionBinding != null)
		{
			IReadOnlyList<string> currentPlatformKeyNameList = actionBinding.GetCurrentPlatformKeyNameList();
			if (currentPlatformKeyNameList.Count > 0)
			{
				return new ValueTuple<IReadOnlyList<string>, bool>?(new ValueTuple<IReadOnlyList<string>, bool>(currentPlatformKeyNameList, false));
			}
		}
		return null;
	}

	// Token: 0x060171A9 RID: 94633 RVA: 0x00666F44 File Offset: 0x00665144
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<string> GetPlatformKeyNameListByAxisName(string axisName)
	{
		InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
		if (axisBinding != null)
		{
			IReadOnlyList<string> currentPlatformKeyNameList = axisBinding.GetCurrentPlatformKeyNameList();
			if (currentPlatformKeyNameList.Count > 0)
			{
				return currentPlatformKeyNameList;
			}
		}
		return null;
	}

	// Token: 0x060171AA RID: 94634 RVA: 0x00666F74 File Offset: 0x00665174
	public IReadOnlyList<string> GetGamepadKeyNameListByActionName(string actionName)
	{
		InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
		if (combinationActionBindingByActionName != null)
		{
			List<string> list = new List<string>();
			combinationActionBindingByActionName.GetCurrentGamepadKeyNameList(list);
			if (list.Count > 0)
			{
				return list;
			}
		}
		InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionName);
		if (actionBinding != null)
		{
			IReadOnlyList<string> currentGamepadKeyNameList = actionBinding.GetCurrentGamepadKeyNameList();
			if (currentGamepadKeyNameList.Count > 0)
			{
				return currentGamepadKeyNameList;
			}
		}
		return Array.Empty<string>();
	}

	// Token: 0x060171AB RID: 94635 RVA: 0x00666FD0 File Offset: 0x006651D0
	public bool CheckActionNameListInNavigation(string refActionName)
	{
		ValueTuple<IReadOnlyList<string>, bool>? platformKeyNameDataByActionName = this.GetPlatformKeyNameDataByActionName(refActionName);
		if (platformKeyNameDataByActionName == null)
		{
			return false;
		}
		foreach (KeyValuePair<string, HashSet<HotKeyComponent>> keyValuePair in this.ActionNameHotKeyComponentMap)
		{
			string text;
			HashSet<HotKeyComponent> hashSet;
			keyValuePair.Deconstruct(out text, out hashSet);
			string text2 = text;
			HashSet<HotKeyComponent> hashSet2 = hashSet;
			if (!(refActionName == text2) && this.CheckActionNameInKeySet(text2, platformKeyNameDataByActionName.Value) != null)
			{
				foreach (HotKeyComponent hotKeyComponent in hashSet2)
				{
					if (hotKeyComponent.IsHotKeyActive() && hotKeyComponent.IsOccupancyFightInput())
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x060171AC RID: 94636 RVA: 0x006670B0 File Offset: 0x006652B0
	public bool CheckAxisNameListInNavigation(string refAxisName)
	{
		IReadOnlyList<string> platformKeyNameListByAxisName = this.GetPlatformKeyNameListByAxisName(refAxisName);
		if (platformKeyNameListByAxisName == null)
		{
			return false;
		}
		HashSet<string> keyNameSet = new HashSet<string>(platformKeyNameListByAxisName);
		foreach (KeyValuePair<string, HashSet<HotKeyComponent>> keyValuePair in this.AxisNameHotKeyComponentMap)
		{
			string text;
			HashSet<HotKeyComponent> hashSet;
			keyValuePair.Deconstruct(out text, out hashSet);
			string text2 = text;
			HashSet<HotKeyComponent> hashSet2 = hashSet;
			if (!(refAxisName == text2) && this.CheckAxisNameInKeySet(text2, keyNameSet) != null)
			{
				foreach (HotKeyComponent hotKeyComponent in hashSet2)
				{
					if (hotKeyComponent.IsHotKeyActive() && hotKeyComponent.GetHotKeyFunctionType() != "ShowOnly")
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x060171AD RID: 94637 RVA: 0x00667198 File Offset: 0x00665398
	public void AddAxisHotKeyComponent(string axisName, HashSet<HotKeyComponent> hotKeyComponentSet)
	{
		this.AxisNameHotKeyComponentMap[axisName] = hotKeyComponentSet;
	}

	// Token: 0x060171AE RID: 94638 RVA: 0x006671A7 File Offset: 0x006653A7
	public HashSet<HotKeyComponent> GetAxisHotKeyComponentSet(string axisName)
	{
		return this.AxisNameHotKeyComponentMap[axisName];
	}

	// Token: 0x060171AF RID: 94639 RVA: 0x006671B8 File Offset: 0x006653B8
	public HashSet<HotKeyComponent> GetOrAddAxisHotKeyComponentsSet(string axisName)
	{
		HashSet<HotKeyComponent> hashSet;
		if (!this.AxisNameHotKeyComponentMap.TryGetValue(axisName, out hashSet))
		{
			hashSet = new HashSet<HotKeyComponent>();
			this.AddAxisHotKeyComponent(axisName, hashSet);
		}
		return hashSet;
	}

	// Token: 0x060171B0 RID: 94640 RVA: 0x006671E4 File Offset: 0x006653E4
	public void AddPlatformListener(TsUiNavigationPlatformChangeListener listener)
	{
		this.PlatformListenerSet.Add(listener);
	}

	// Token: 0x060171B1 RID: 94641 RVA: 0x006671F3 File Offset: 0x006653F3
	public void RemovePlatformListener(TsUiNavigationPlatformChangeListener listener)
	{
		this.PlatformListenerSet.Remove(listener);
	}

	// Token: 0x17001E6B RID: 7787
	// (get) Token: 0x060171B2 RID: 94642 RVA: 0x00667202 File Offset: 0x00665402
	[Nullable(2)]
	public TsUiNavigationBehaviorListener GuideFocusListener
	{
		[NullableContext(2)]
		get
		{
			return this.GuideFocusListenerInternal;
		}
	}

	// Token: 0x060171B3 RID: 94643 RVA: 0x0066720A File Offset: 0x0066540A
	public void SetGuideFocusListener(TsUiNavigationBehaviorListener listener)
	{
		this.GuideFocusListenerInternal = listener;
	}

	// Token: 0x060171B4 RID: 94644 RVA: 0x00667213 File Offset: 0x00665413
	public void ResetGuideFocusListener()
	{
		this.GuideFocusListenerInternal = null;
	}

	// Token: 0x0400B1C8 RID: 45512
	private readonly Cursor Cursor = new Cursor();

	// Token: 0x0400B1C9 RID: 45513
	public bool IsOpenLog;

	// Token: 0x0400B1CA RID: 45514
	private readonly Dictionary<string, HashSet<HotKeyComponent>> ActionNameHotKeyComponentMap = new Dictionary<string, HashSet<HotKeyComponent>>();

	// Token: 0x0400B1CB RID: 45515
	private readonly Dictionary<string, HashSet<HotKeyComponent>> AxisNameHotKeyComponentMap = new Dictionary<string, HashSet<HotKeyComponent>>();

	// Token: 0x0400B1CC RID: 45516
	private readonly HashSet<TsUiNavigationPlatformChangeListener> PlatformListenerSet = new HashSet<TsUiNavigationPlatformChangeListener>();

	// Token: 0x0400B1CD RID: 45517
	[Nullable(2)]
	private TsUiNavigationBehaviorListener GuideFocusListenerInternal;
}
