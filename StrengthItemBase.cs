using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FC7 RID: 8135
[NullableContext(1)]
[Nullable(0)]
public class StrengthItemBase : UiPanelBase
{
	// Token: 0x0600F58B RID: 62859 RVA: 0x00433CC4 File Offset: 0x00431EC4
	public void Init(UUIItem parentItem, [Nullable(2)] BattleUiRoleData roleData, Action<bool> uiVisibleChanged)
	{
		this.RoleData = roleData;
		this.UiVisibleChanged = uiVisibleChanged;
		this.TargetActive = false;
		this.InitAsync(parentItem).ContinueWith(delegate()
		{
		});
	}

	// Token: 0x0600F58C RID: 62860 RVA: 0x00433D14 File Offset: 0x00431F14
	protected virtual UniTask InitAsync(UUIItem parentItem)
	{
		StrengthItemBase.<InitAsync>d__8 <InitAsync>d__;
		<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAsync>d__.<>4__this = this;
		<InitAsync>d__.parentItem = parentItem;
		<InitAsync>d__.<>1__state = -1;
		<InitAsync>d__.<>t__builder.Start<StrengthItemBase.<InitAsync>d__8>(ref <InitAsync>d__);
		return <InitAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F58D RID: 62861 RVA: 0x00433D5F File Offset: 0x00431F5F
	protected virtual string GetResourceId()
	{
		return "UiItem_Endurance";
	}

	// Token: 0x0600F58E RID: 62862 RVA: 0x00433D66 File Offset: 0x00431F66
	protected override void OnStart()
	{
		this.IsAfterStart = true;
		this.OnAddEvents();
		this.OnAddEntityEvents();
		this.OnRefreshRoleData();
		if (!this.IsEnableStrengthItem)
		{
			this.SetEnableStrengthItem(false, false);
		}
	}

	// Token: 0x0600F58F RID: 62863 RVA: 0x00433D91 File Offset: 0x00431F91
	protected override void OnBeforeShow()
	{
		Action<bool> uiVisibleChanged = this.UiVisibleChanged;
		if (uiVisibleChanged == null)
		{
			return;
		}
		uiVisibleChanged(true);
	}

	// Token: 0x0600F590 RID: 62864 RVA: 0x00433DA4 File Offset: 0x00431FA4
	protected override void OnAfterHide()
	{
		Action<bool> uiVisibleChanged = this.UiVisibleChanged;
		if (uiVisibleChanged == null)
		{
			return;
		}
		uiVisibleChanged(false);
	}

	// Token: 0x0600F591 RID: 62865 RVA: 0x00433DB7 File Offset: 0x00431FB7
	protected override void OnBeforeDestroy()
	{
		this.OnRemoveEvents();
		this.RefreshRoleData(null);
		this.IsAfterStart = false;
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F592 RID: 62866 RVA: 0x00433DD3 File Offset: 0x00431FD3
	public override void SetActive(bool visibility)
	{
		this.TargetActive = visibility;
		base.SetActive(visibility);
	}

	// Token: 0x0600F593 RID: 62867 RVA: 0x00433DE3 File Offset: 0x00431FE3
	[NullableContext(2)]
	public void RefreshRoleData(BattleUiRoleData roleData)
	{
		if (this.RoleData == roleData)
		{
			return;
		}
		this.ClearTagTask();
		this.ClearAllAttributeChangedCallback();
		this.OnRemoveEntityEvents();
		this.RoleData = roleData;
		if (!this.IsAfterStart)
		{
			return;
		}
		this.OnAddEntityEvents();
		this.OnRefreshRoleData();
	}

	// Token: 0x0600F594 RID: 62868 RVA: 0x00433E1D File Offset: 0x0043201D
	public virtual void Tick(float delta)
	{
	}

	// Token: 0x0600F595 RID: 62869 RVA: 0x00433E1F File Offset: 0x0043201F
	public bool GetUiVisible()
	{
		return base.IsShowing || base.IsShow;
	}

	// Token: 0x0600F596 RID: 62870 RVA: 0x00433E31 File Offset: 0x00432031
	protected virtual void OnAddEvents()
	{
	}

	// Token: 0x0600F597 RID: 62871 RVA: 0x00433E33 File Offset: 0x00432033
	protected virtual void OnRemoveEvents()
	{
	}

	// Token: 0x0600F598 RID: 62872 RVA: 0x00433E38 File Offset: 0x00432038
	public unsafe void SetEnableStrengthItem(bool b, bool force = false)
	{
		if (this.IsEnableStrengthItem == b && !force)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HudUnit;
		ELogAuthor author = ELogAuthor.HWR;
		string message = "体力条 SetEnableStrengthItem";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("", base.GetType().Name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("", b);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.IsEnableStrengthItem = b;
		if (!this.IsAfterStart)
		{
			return;
		}
		this.OnEnableStrengthItem(b);
	}

	// Token: 0x0600F599 RID: 62873 RVA: 0x00433ECE File Offset: 0x004320CE
	protected virtual void OnEnableStrengthItem(bool b)
	{
	}

	// Token: 0x0600F59A RID: 62874 RVA: 0x00433ED0 File Offset: 0x004320D0
	protected virtual void OnAddEntityEvents()
	{
	}

	// Token: 0x0600F59B RID: 62875 RVA: 0x00433ED2 File Offset: 0x004320D2
	protected virtual void OnRemoveEntityEvents()
	{
	}

	// Token: 0x0600F59C RID: 62876 RVA: 0x00433ED4 File Offset: 0x004320D4
	protected virtual void OnRefreshRoleData()
	{
	}

	// Token: 0x0600F59D RID: 62877 RVA: 0x00433ED8 File Offset: 0x004320D8
	protected void ListenForTagAddOrRemove(BaseTagComponent tagComponent, int? tagId, Action<int, bool> callback)
	{
		ITagTask tagTask = tagComponent.ListenForTagAddOrRemove(tagId, new BaseTagComponent.TTagSwitchedCallback(callback.Invoke), StrengthItemBase.ListenTagStat);
		if (tagTask != null)
		{
			this.TagTaskList.Add(tagTask);
		}
	}

	// Token: 0x0600F59E RID: 62878 RVA: 0x00433F10 File Offset: 0x00432110
	protected void ClearTagTask()
	{
		foreach (ITagTask tagTask in this.TagTaskList)
		{
			tagTask.EndTask();
		}
		this.TagTaskList.Clear();
	}

	// Token: 0x0600F59F RID: 62879 RVA: 0x00433F6C File Offset: 0x0043216C
	protected void ListenForAttributeChanged(EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
	{
		if (attributeId <= EAttributeType.None)
		{
			return;
		}
		BattleUiRoleData roleData = this.RoleData;
		BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		baseAttributeComponent.AddListener(attributeId, onAttributeChanged, null);
		this.AttributeChangedCallbackMap[attributeId] = onAttributeChanged;
	}

	// Token: 0x0600F5A0 RID: 62880 RVA: 0x00433FAC File Offset: 0x004321AC
	protected void RemoveListenAttributeChanged(EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
	{
		if (attributeId <= EAttributeType.None)
		{
			return;
		}
		BattleUiRoleData roleData = this.RoleData;
		BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		baseAttributeComponent.RemoveListener(attributeId, onAttributeChanged);
		this.AttributeChangedCallbackMap.Remove(attributeId);
	}

	// Token: 0x0600F5A1 RID: 62881 RVA: 0x00433FEC File Offset: 0x004321EC
	private void ClearAllAttributeChangedCallback()
	{
		BattleUiRoleData roleData = this.RoleData;
		BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		foreach (KeyValuePair<EAttributeType, Action<EAttributeType, float, float>> keyValuePair in this.AttributeChangedCallbackMap)
		{
			EAttributeType eattributeType;
			Action<EAttributeType, float, float> action;
			keyValuePair.Deconstruct(out eattributeType, out action);
			EAttributeType attrId = eattributeType;
			Action<EAttributeType, float, float> callback = action;
			baseAttributeComponent.RemoveListener(attrId, callback);
		}
		this.AttributeChangedCallbackMap.Clear();
	}

	// Token: 0x0600F5A2 RID: 62882 RVA: 0x00434078 File Offset: 0x00432278
	protected void InitTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
	}

	// Token: 0x0600F5A3 RID: 62883 RVA: 0x0043408E File Offset: 0x0043228E
	protected void PlayTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.PlayTweenAnim(componentType);
	}

	// Token: 0x0600F5A4 RID: 62884 RVA: 0x0043409C File Offset: 0x0043229C
	protected void StopTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.StopTweenAnim(componentType);
	}

	// Token: 0x040076B3 RID: 30387
	[StaticVariableRuleIgnore]
	private static readonly Stat ListenTagStat = Stat.Create("[StrengthItem]ListenTag", "", "");

	// Token: 0x040076B4 RID: 30388
	protected bool IsAfterStart;

	// Token: 0x040076B5 RID: 30389
	[Nullable(2)]
	protected BattleUiRoleData RoleData;

	// Token: 0x040076B6 RID: 30390
	[Nullable(2)]
	protected Action<bool> UiVisibleChanged;

	// Token: 0x040076B7 RID: 30391
	protected readonly List<ITagTask> TagTaskList = new List<ITagTask>();

	// Token: 0x040076B8 RID: 30392
	protected readonly Dictionary<EAttributeType, Action<EAttributeType, float, float>> AttributeChangedCallbackMap = new Dictionary<EAttributeType, Action<EAttributeType, float, float>>();

	// Token: 0x040076B9 RID: 30393
	protected bool TargetActive;

	// Token: 0x040076BA RID: 30394
	protected bool IsEnableStrengthItem = true;

	// Token: 0x040076BB RID: 30395
	protected BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();
}
