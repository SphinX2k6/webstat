using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001560 RID: 5472
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressTaskDynamicScrollItem : UiPanelBase, IDynamicScrollItem<ActivityRegressTaskDynamicData>
{
	// Token: 0x06009981 RID: 39297 RVA: 0x00282AAC File Offset: 0x00280CAC
	public UniTask Init(UUIItem actor)
	{
		ActivityRegressTaskDynamicScrollItem.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ActivityRegressTaskDynamicScrollItem.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06009982 RID: 39298 RVA: 0x00282AF7 File Offset: 0x00280CF7
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06009983 RID: 39299 RVA: 0x00282B30 File Offset: 0x00280D30
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressTaskDynamicScrollItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressTaskDynamicScrollItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009984 RID: 39300 RVA: 0x00282B73 File Offset: 0x00280D73
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(ActivityRegressTaskDynamicData data)
	{
		if (data.ItemType == ERegressTaskDynamicItemType.Title)
		{
			return this.GetItemActor(1);
		}
		if (data.ItemType == ERegressTaskDynamicItemType.Item)
		{
			return this.GetItemActor(0);
		}
		return null;
	}

	// Token: 0x06009985 RID: 39301 RVA: 0x00282B97 File Offset: 0x00280D97
	private AUIBaseActor GetItemActor(int key)
	{
		return (AUIBaseActor)base.GetItem(key).GetOwner();
	}

	// Token: 0x06009986 RID: 39302 RVA: 0x00282BAC File Offset: 0x00280DAC
	public void Update(ActivityRegressTaskDynamicData data, int index)
	{
		bool flag = data.ItemType == ERegressTaskDynamicItemType.Title;
		this.TitleItem.SetUiActive(flag);
		this.ScrollItem.SetUiActive(!flag);
		if (flag)
		{
			this.TitleItem.RefreshByData(data);
			return;
		}
		if (!flag)
		{
			this.ScrollItem.GetRootItem().SetAnchorOffsetY(0f);
			this.ScrollItem.RefreshByData(data);
		}
	}

	// Token: 0x06009987 RID: 39303 RVA: 0x00282C12 File Offset: 0x00280E12
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x040046E5 RID: 18149
	[Nullable(2)]
	private ActivityRegressTaskScrollItemPanel ScrollItem;

	// Token: 0x040046E6 RID: 18150
	[Nullable(2)]
	private ActivityRegressTaskTitlePanel TitleItem;

	// Token: 0x02007920 RID: 31008
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040299ED RID: 170477
		public const int ScrollItem = 0;

		// Token: 0x040299EE RID: 170478
		public const int TitlePanel = 1;
	}
}
