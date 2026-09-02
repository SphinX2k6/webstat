using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnrealEngine;

// Token: 0x020032CB RID: 13003
[NullableContext(2)]
[Nullable(0)]
public class RedDotBase
{
	// Token: 0x17002536 RID: 9526
	// (get) Token: 0x0601B467 RID: 111719 RVA: 0x00830B49 File Offset: 0x0082ED49
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Tree<RedDotBase> Tree
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return ModelBase<RedDotModel>.Instance.GetRedDotTree(this.Name.Value);
		}
	}

	// Token: 0x0601B468 RID: 111720 RVA: 0x00830B60 File Offset: 0x0082ED60
	public void SetRedDotActiveByGm(bool bShow)
	{
		this.SetRedDotActive(bShow);
	}

	// Token: 0x0601B469 RID: 111721 RVA: 0x00830B6C File Offset: 0x0082ED6C
	private void SetSelfAndChildActive(bool value)
	{
		this.IsActive = value;
		if (!value)
		{
			this.RemoveCheckEvent();
			using (Dictionary<int, RedDotData>.ValueCollection.Enumerator enumerator = this.DataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RedDotData redDotData = enumerator.Current;
					redDotData.SetUIItemActive(false);
				}
				goto IL_4F;
			}
		}
		this.AddCheckEvent();
		IL_4F:
		if (this.Tree != null)
		{
			foreach (RedDotBase redDotBase in this.Tree.ChildMap.Keys)
			{
				redDotBase.SetSelfAndChildActive(value);
			}
		}
	}

	// Token: 0x0601B46A RID: 111722 RVA: 0x00830C2C File Offset: 0x0082EE2C
	private bool CheckParentState(bool newState)
	{
		Tree<RedDotBase> tree = this.Tree;
		return ((tree != null) ? tree.Parent : null) == null || (this.Tree.Parent.Element.IsActive || !newState);
	}

	// Token: 0x0601B46B RID: 111723 RVA: 0x00830C64 File Offset: 0x0082EE64
	private void SetRedDotActive(bool value)
	{
		if (value == this.IsActive)
		{
			return;
		}
		if (!this.CheckParentState(value))
		{
			return;
		}
		this.SetSelfAndChildActive(value);
		if (value)
		{
			this.CalculateStateCount();
		}
		Tree<RedDotBase> tree = this.Tree;
		if (((tree != null) ? tree.Parent : null) != null)
		{
			this.Tree.Parent.Element.OnChildActiveChange(this, value);
		}
	}

	// Token: 0x0601B46C RID: 111724 RVA: 0x00830CC0 File Offset: 0x0082EEC0
	public void Init(ERedDotName name)
	{
		this.Name = new ERedDotName?(name);
		this.AddCheckEvent();
		this.AddActiveEvents();
		this.AddDisActiveEvents();
	}

	// Token: 0x0601B46D RID: 111725 RVA: 0x00830CE0 File Offset: 0x0082EEE0
	protected void OnActiveEvent()
	{
		this.SetRedDotActive(true);
	}

	// Token: 0x0601B46E RID: 111726 RVA: 0x00830CE9 File Offset: 0x0082EEE9
	protected void OnDisActiveEvent()
	{
		this.SetRedDotActive(false);
	}

	// Token: 0x0601B46F RID: 111727 RVA: 0x00830CF4 File Offset: 0x0082EEF4
	protected void EventCheck()
	{
		int uId = 0;
		if (!this.IsMultiple())
		{
			this.TryGenerateData(uId);
			this.PushToEventQueue(uId);
			return;
		}
		foreach (int uId2 in this.DataMap.Keys)
		{
			this.PushToEventQueue(uId2);
		}
	}

	// Token: 0x0601B470 RID: 111728 RVA: 0x00830D68 File Offset: 0x0082EF68
	protected void EventCheckWithUid(int uId)
	{
		if (this.IsAllEventParamAsUId())
		{
			this.TryGenerateData(uId);
			this.PushToEventQueue(uId);
			return;
		}
		this.EventCheck();
	}

	// Token: 0x0601B471 RID: 111729 RVA: 0x00830D88 File Offset: 0x0082EF88
	private void PushToEventQueue(int uId = 0)
	{
		Singleton<RedDotSystem>.Instance.PushToEventQueue(new TRedDotCheckEvent(this.CheckSelf), uId, this.Name.Value);
	}

	// Token: 0x0601B472 RID: 111730 RVA: 0x00830DAC File Offset: 0x0082EFAC
	private unsafe void CheckSelf(int uId = 0)
	{
		bool flag = this.OnCheck(uId);
		RedDotData data = this.GetData(uId);
		if (data == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RedDot;
			ELogAuthor author = ELogAuthor.TL;
			string message = "Check失败，红点数据未绑定到事件上！";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", this.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("uId", uId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (data.TryChangeState(flag))
		{
			Action<bool, int> stateChangeCallback = this.StateChangeCallback;
			if (stateChangeCallback != null)
			{
				stateChangeCallback(data.State, uId);
			}
			this.NotifyParentStateChange(flag, uId);
		}
	}

	// Token: 0x0601B473 RID: 111731 RVA: 0x00830E58 File Offset: 0x0082F058
	[NullableContext(1)]
	private void OnChildActiveChange(RedDotBase child, bool newActiveState)
	{
		foreach (KeyValuePair<int, RedDotData> keyValuePair in child.DataMap)
		{
			int key = keyValuePair.Key;
			RedDotData value = keyValuePair.Value;
			RedDotData redDotData;
			if (this.DataMap.TryGetValue(key, out redDotData))
			{
				if (newActiveState)
				{
					redDotData.StateCount += value.StateCount;
				}
				else
				{
					redDotData.StateCount -= value.StateCount;
				}
				redDotData.UpdateRedDotUIActive();
			}
		}
		Tree<RedDotBase> tree = this.Tree;
		if (((tree != null) ? tree.Parent : null) != null)
		{
			this.Tree.Parent.Element.OnChildActiveChange(child, newActiveState);
		}
	}

	// Token: 0x0601B474 RID: 111732 RVA: 0x00830F24 File Offset: 0x0082F124
	private void CalculateStateCount()
	{
		foreach (KeyValuePair<int, RedDotData> keyValuePair in this.DataMap)
		{
			int key = keyValuePair.Key;
			RedDotData value = keyValuePair.Value;
			bool flag = this.OnCheck(key);
			value.StateCount = ((flag > false) ? 1 : 0);
			if (flag)
			{
				value.SetUIItemActive(true);
				this.NotifyParentStateChange(flag, key);
			}
		}
		if (this.Tree != null)
		{
			foreach (RedDotBase redDotBase in this.Tree.ChildMap.Keys)
			{
				redDotBase.CalculateStateCount();
			}
		}
	}

	// Token: 0x0601B475 RID: 111733 RVA: 0x00830FFC File Offset: 0x0082F1FC
	private void NotifyParentStateChange(bool result, int rawUniqueId = 0)
	{
		Tree<RedDotBase> tree = this.Tree;
		RedDotBase redDotBase;
		if (tree == null)
		{
			redDotBase = null;
		}
		else
		{
			Tree<RedDotBase> parent = tree.Parent;
			redDotBase = ((parent != null) ? parent.Element : null);
		}
		RedDotBase redDotBase2 = redDotBase;
		if (redDotBase2 == null)
		{
			return;
		}
		int num;
		if (!redDotBase2.IsMultiple())
		{
			num = 0;
		}
		else
		{
			int parentCheckUid = this.GetParentCheckUid(rawUniqueId);
			num = ((parentCheckUid >= 0) ? parentCheckUid : rawUniqueId);
		}
		redDotBase2.TryGenerateData(num);
		RedDotData data = redDotBase2.GetData(num);
		if (data != null && data.OnChildrenStateChange(result))
		{
			Action<bool, int> stateChangeCallback = redDotBase2.StateChangeCallback;
			if (stateChangeCallback != null)
			{
				stateChangeCallback(data.State, num);
			}
			redDotBase2.NotifyParentStateChange(result, num);
		}
	}

	// Token: 0x0601B476 RID: 111734 RVA: 0x00831088 File Offset: 0x0082F288
	private RedDotData GetData(int uId)
	{
		RedDotData result;
		this.DataMap.TryGetValue(uId, out result);
		return result;
	}

	// Token: 0x0601B477 RID: 111735 RVA: 0x008310A8 File Offset: 0x0082F2A8
	[NullableContext(1)]
	private RedDotData TryGenerateData(int uId = 0)
	{
		RedDotData redDotData;
		if (!this.DataMap.TryGetValue(uId, out redDotData))
		{
			redDotData = new RedDotData();
			this.DataMap[uId] = redDotData;
			this.CheckSelf(uId);
		}
		return redDotData;
	}

	// Token: 0x0601B478 RID: 111736 RVA: 0x008310E0 File Offset: 0x0082F2E0
	public void BindUi(int uId = 0, UUIItem uiItem = null, Action<bool, int> stateChangeCallback = null)
	{
		this.TryGenerateData(uId);
		RedDotData data = this.GetData(uId);
		if (data != null)
		{
			data.SetUiItem(uiItem);
		}
		this.StateChangeCallback = stateChangeCallback;
		this.UpdateState(uId);
	}

	// Token: 0x0601B479 RID: 111737 RVA: 0x0083110B File Offset: 0x0082F30B
	public void UnBindGivenUi(int uId = 0, UUIItem uiItem = null)
	{
		RedDotData data = this.GetData(uId);
		if (data == null)
		{
			return;
		}
		data.DeleteUiItem(uiItem);
	}

	// Token: 0x0601B47A RID: 111738 RVA: 0x00831120 File Offset: 0x0082F320
	public void UnBindUi()
	{
		foreach (RedDotData redDotData in this.DataMap.Values)
		{
			redDotData.ClearUiItem();
		}
		this.StateChangeCallback = null;
	}

	// Token: 0x0601B47B RID: 111739 RVA: 0x0083117C File Offset: 0x0082F37C
	public void UnBindGivenUiAndDeleteData(int uId = 0, UUIItem uiItem = null)
	{
		RedDotData data = this.GetData(uId);
		if (data == null)
		{
			return;
		}
		data.DeleteUiItem(uiItem);
		if (data.GetUiItemSet().Count > 0)
		{
			return;
		}
		Singleton<RedDotSystem>.Instance.PopRedDotEventData(uId, this.Name.Value);
		this.DataMap.Remove(uId);
	}

	// Token: 0x0601B47C RID: 111740 RVA: 0x008311D0 File Offset: 0x0082F3D0
	public void UnBindUiAndClearData()
	{
		this.UnBindUi();
		foreach (int id in this.DataMap.Keys)
		{
			Singleton<RedDotSystem>.Instance.PopRedDotEventData(id, this.Name.Value);
		}
		this.DataMap.Clear();
	}

	// Token: 0x0601B47D RID: 111741 RVA: 0x00831248 File Offset: 0x0082F448
	public void UpdateState(int uId = 0)
	{
		RedDotData data = this.GetData(uId);
		if (data != null)
		{
			data.UpdateRedDotUIActive();
		}
		Action<bool, int> stateChangeCallback = this.StateChangeCallback;
		if (stateChangeCallback == null)
		{
			return;
		}
		stateChangeCallback(data != null && data.State, uId);
	}

	// Token: 0x0601B47E RID: 111742 RVA: 0x00831284 File Offset: 0x0082F484
	public bool IsRedDotActive()
	{
		using (Dictionary<int, RedDotData>.ValueCollection.Enumerator enumerator = this.DataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0601B47F RID: 111743 RVA: 0x008312E4 File Offset: 0x0082F4E4
	public ERedDotName? GetParentName()
	{
		return this.OnGetParentName();
	}

	// Token: 0x0601B480 RID: 111744 RVA: 0x008312EC File Offset: 0x0082F4EC
	protected virtual void AddCheckEvent()
	{
	}

	// Token: 0x0601B481 RID: 111745 RVA: 0x008312EE File Offset: 0x0082F4EE
	protected virtual void RemoveCheckEvent()
	{
	}

	// Token: 0x0601B482 RID: 111746 RVA: 0x008312F0 File Offset: 0x0082F4F0
	protected virtual void AddActiveEvents()
	{
	}

	// Token: 0x0601B483 RID: 111747 RVA: 0x008312F2 File Offset: 0x0082F4F2
	protected virtual void AddDisActiveEvents()
	{
	}

	// Token: 0x0601B484 RID: 111748 RVA: 0x008312F4 File Offset: 0x0082F4F4
	protected virtual bool OnCheck(int uId = 0)
	{
		return false;
	}

	// Token: 0x0601B485 RID: 111749 RVA: 0x008312F7 File Offset: 0x0082F4F7
	protected virtual bool IsMultiple()
	{
		return false;
	}

	// Token: 0x0601B486 RID: 111750 RVA: 0x008312FC File Offset: 0x0082F4FC
	protected virtual ERedDotName? OnGetParentName()
	{
		return null;
	}

	// Token: 0x0601B487 RID: 111751 RVA: 0x00831312 File Offset: 0x0082F512
	protected virtual int GetParentCheckUid(int uId)
	{
		return uId;
	}

	// Token: 0x0601B488 RID: 111752 RVA: 0x00831315 File Offset: 0x0082F515
	protected virtual bool IsAllEventParamAsUId()
	{
		return true;
	}

	// Token: 0x0601B489 RID: 111753 RVA: 0x00831318 File Offset: 0x0082F518
	[NullableContext(1)]
	public string ToRedDotString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		StringBuilder stringBuilder4;
		StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler;
		foreach (KeyValuePair<int, RedDotData> keyValuePair in this.DataMap)
		{
			int key = keyValuePair.Key;
			RedDotData value = keyValuePair.Value;
			stringBuilder3.Clear();
			foreach (UUIItem uuiitem in value.GetUiItemSet())
			{
				stringBuilder4 = stringBuilder3;
				StringBuilder stringBuilder5 = stringBuilder4;
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder4);
				appendInterpolatedStringHandler.AppendFormatted(uuiitem.GetDisplayName());
				appendInterpolatedStringHandler.AppendLiteral(", ");
				stringBuilder5.Append(ref appendInterpolatedStringHandler);
			}
			stringBuilder4 = stringBuilder2;
			StringBuilder stringBuilder6 = stringBuilder4;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(30, 3, stringBuilder4);
			appendInterpolatedStringHandler.AppendLiteral("{uid:");
			appendInterpolatedStringHandler.AppendFormatted<int>(key);
			appendInterpolatedStringHandler.AppendLiteral(", stateCount:");
			appendInterpolatedStringHandler.AppendFormatted<int>(value.StateCount);
			appendInterpolatedStringHandler.AppendLiteral(" uiItem:[");
			appendInterpolatedStringHandler.AppendFormatted(stringBuilder3.ToString());
			appendInterpolatedStringHandler.AppendLiteral("] }");
			stringBuilder6.Append(ref appendInterpolatedStringHandler);
		}
		StringBuilder stringBuilder7 = new StringBuilder();
		if (this.Tree != null)
		{
			foreach (RedDotBase redDotBase in this.Tree.ChildMap.Keys)
			{
				stringBuilder4 = stringBuilder7;
				StringBuilder stringBuilder8 = stringBuilder4;
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder4);
				appendInterpolatedStringHandler.AppendFormatted<ERedDotName?>(redDotBase.Name);
				appendInterpolatedStringHandler.AppendLiteral(", ");
				stringBuilder8.Append(ref appendInterpolatedStringHandler);
			}
		}
		stringBuilder4 = stringBuilder;
		StringBuilder stringBuilder9 = stringBuilder4;
		appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(25, 4, stringBuilder4);
		appendInterpolatedStringHandler.AppendLiteral("[红点:");
		appendInterpolatedStringHandler.AppendFormatted<ERedDotName?>(this.Name);
		appendInterpolatedStringHandler.AppendLiteral(" 父红点:");
		Tree<RedDotBase> tree = this.Tree;
		ERedDotName? value2;
		if (tree == null)
		{
			value2 = null;
		}
		else
		{
			Tree<RedDotBase> parent = tree.Parent;
			value2 = ((parent != null) ? parent.Element.Name : null);
		}
		appendInterpolatedStringHandler.AppendFormatted<ERedDotName?>(value2);
		appendInterpolatedStringHandler.AppendLiteral(" 子红点:");
		appendInterpolatedStringHandler.AppendFormatted(stringBuilder7.ToString());
		appendInterpolatedStringHandler.AppendLiteral("  数据:{ ");
		appendInterpolatedStringHandler.AppendFormatted(stringBuilder2.ToString());
		appendInterpolatedStringHandler.AppendLiteral(" }]\n");
		stringBuilder9.Append(ref appendInterpolatedStringHandler);
		return stringBuilder.ToString();
	}

	// Token: 0x0601B48A RID: 111754 RVA: 0x008315E0 File Offset: 0x0082F7E0
	public unsafe void PrintStateDebugString()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RedDot;
		ELogAuthor author = ELogAuthor.CX;
		string message = "=======子红点状态打印开始=======：";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", this.Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (KeyValuePair<int, RedDotData> keyValuePair in this.DataMap)
		{
			int key = keyValuePair.Key;
			RedDotData value = keyValuePair.Value;
			HashSet<UUIItem> uiItemSet = value.GetUiItemSet();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RedDot;
			ELogAuthor author2 = ELogAuthor.CX;
			string message2 = "红点状态数据：";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Uid", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("State", value.State);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StateCount", value.StateCount);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("UiItemSize", uiItemSet.Count);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			foreach (UUIItem uuiitem in uiItemSet)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.RedDot;
				ELogAuthor author3 = ELogAuthor.CX;
				string message3 = "受控制的UI对象";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("UiItem", uuiitem.GetDisplayName());
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
		}
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module4 = ELogModule.RedDot;
		ELogAuthor author4 = ELogAuthor.CX;
		string message4 = "=======子红点状态打印结束=======：";
		ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Name", this.Name);
		instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
	}

	// Token: 0x0601B48B RID: 111755 RVA: 0x008317D8 File Offset: 0x0082F9D8
	public void UpdateAllRedDotData()
	{
		foreach (int uId in this.DataMap.Keys)
		{
			this.PushToEventQueue(uId);
		}
	}

	// Token: 0x0400DE38 RID: 56888
	public ERedDotName? Name;

	// Token: 0x0400DE39 RID: 56889
	private bool IsActive = true;

	// Token: 0x0400DE3A RID: 56890
	[Nullable(1)]
	private readonly Dictionary<int, RedDotData> DataMap = new Dictionary<int, RedDotData>();

	// Token: 0x0400DE3B RID: 56891
	private Action<bool, int> StateChangeCallback;

	// Token: 0x0400DE3C RID: 56892
	private Stat StatsObject;

	// Token: 0x0400DE3D RID: 56893
	private Action EventCheckAction0;
}
