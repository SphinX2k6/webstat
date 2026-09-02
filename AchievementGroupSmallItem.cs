using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FE3 RID: 4067
[NullableContext(1)]
[Nullable(0)]
public class AchievementGroupSmallItem : UiPanelBase, IDynamicScrollItem<AchievementGroupData>
{
	// Token: 0x060068D4 RID: 26836 RVA: 0x001B4FE8 File Offset: 0x001B31E8
	public UniTask Init(UUIItem actor)
	{
		AchievementGroupSmallItem.<Init>d__2 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementGroupSmallItem.<Init>d__2>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060068D5 RID: 26837 RVA: 0x001B5033 File Offset: 0x001B3233
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x060068D6 RID: 26838 RVA: 0x001B503C File Offset: 0x001B323C
	public AUIBaseActor GetUsingItem(AchievementGroupData data)
	{
		return (AUIBaseActor)base.GetRootItem().GetOwner();
	}

	// Token: 0x060068D7 RID: 26839 RVA: 0x001B504E File Offset: 0x001B324E
	public void Update(AchievementGroupData data, int index)
	{
		this.AchievementGroupData = data;
		this.RefreshDesc(data);
		this.RefreshRedPointState(data);
		this.RefreshToggleState();
		this.RefreshProgress();
	}

	// Token: 0x060068D8 RID: 26840 RVA: 0x001B5074 File Offset: 0x001B3274
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060068D9 RID: 26841 RVA: 0x001B519E File Offset: 0x001B339E
	protected override void OnStart()
	{
		this.AddEventListener();
	}

	// Token: 0x060068DA RID: 26842 RVA: 0x001B51A8 File Offset: 0x001B33A8
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAchievementGroupChange, new Action(this.OnAchievementGroupChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementGroupDataNotify, new Action<int>(this.OnAchievementGroupDataNotify));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x060068DB RID: 26843 RVA: 0x001B520C File Offset: 0x001B340C
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementGroupChange, new Action(this.OnAchievementGroupChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementGroupDataNotify, new Action<int>(this.OnAchievementGroupDataNotify));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x060068DC RID: 26844 RVA: 0x001B5270 File Offset: 0x001B3470
	private void OnAchievementDataWithIdNotify(int dataId)
	{
		int groupId = ModelBase<AchievementModel>.Instance.GetAchievementData(dataId).GetGroupId();
		AchievementGroupData achievementGroupData = this.AchievementGroupData;
		int? num = (achievementGroupData != null) ? new int?(achievementGroupData.GetId()) : null;
		if (groupId == num.GetValueOrDefault() & num != null)
		{
			this.RefreshProgress();
			this.RefreshRedPointState(this.AchievementGroupData);
		}
	}

	// Token: 0x060068DD RID: 26845 RVA: 0x001B52D2 File Offset: 0x001B34D2
	private void OnAchievementGroupDataNotify(int groupId)
	{
		AchievementGroupData achievementGroupData = this.AchievementGroupData;
		if (achievementGroupData != null && achievementGroupData.GetId() == groupId)
		{
			this.RefreshProgress();
			this.RefreshRedPointState(this.AchievementGroupData);
		}
	}

	// Token: 0x060068DE RID: 26846 RVA: 0x001B52FD File Offset: 0x001B34FD
	private void OnAchievementGroupChange()
	{
		this.RefreshToggleState();
	}

	// Token: 0x060068DF RID: 26847 RVA: 0x001B5305 File Offset: 0x001B3505
	private void OnClickToggle(EToggleState state)
	{
		ModelBase<AchievementModel>.Instance.CurrentSelectGroup = this.AchievementGroupData;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAchievementGroupChange);
	}

	// Token: 0x060068E0 RID: 26848 RVA: 0x001B5328 File Offset: 0x001B3528
	private void RefreshToggleState()
	{
		if (this.AchievementGroupData == null)
		{
			return;
		}
		if (base.GetRootItem() == null)
		{
			return;
		}
		EToggleState etoggleState = (ModelBase<AchievementModel>.Instance.CurrentSelectGroup == this.AchievementGroupData) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (base.GetExtendToggle(1).ToggleState != etoggleState)
		{
			base.GetExtendToggle(1).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x060068E1 RID: 26849 RVA: 0x001B5380 File Offset: 0x001B3580
	private void RefreshProgress()
	{
		string achievementGroupProgress = this.AchievementGroupData.GetAchievementGroupProgress();
		base.GetText(3).SetText(achievementGroupProgress, true);
	}

	// Token: 0x060068E2 RID: 26850 RVA: 0x001B53A8 File Offset: 0x001B35A8
	private void RefreshDesc(AchievementGroupData data)
	{
		base.GetText(0).SetText(data.GetTitle(), true);
		UUITexture texture = base.GetTexture(2);
		base.SetTextureByPath(data.GetSmallIcon(), texture, null, null);
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.GetRewards().Count > 0);
	}

	// Token: 0x060068E3 RID: 26851 RVA: 0x001B5406 File Offset: 0x001B3606
	private void RefreshRedPointState(AchievementGroupData data)
	{
		base.GetItem(4).SetUIActive(data.SmallItemRedPoint());
	}

	// Token: 0x060068E4 RID: 26852 RVA: 0x001B541A File Offset: 0x001B361A
	protected override void OnBeforeDestroy()
	{
		if (this.AchievementGroupData != null)
		{
			this.AchievementGroupData = null;
		}
		if (this.ItemSizeVector != null)
		{
			this.ItemSizeVector = null;
		}
		this.RemoveEventListener();
	}

	// Token: 0x040031E3 RID: 12771
	[Nullable(2)]
	private AchievementGroupData AchievementGroupData;

	// Token: 0x040031E4 RID: 12772
	[Nullable(2)]
	private Vector2D ItemSizeVector;
}
