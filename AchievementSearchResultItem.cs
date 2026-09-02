using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FEE RID: 4078
[NullableContext(2)]
[Nullable(0)]
public class AchievementSearchResultItem : UiPanelBase, IDynamicScrollItem<AchievementSearchData>
{
	// Token: 0x06006953 RID: 26963 RVA: 0x001B7248 File Offset: 0x001B5448
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		AchievementSearchResultItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementSearchResultItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06006954 RID: 26964 RVA: 0x001B7294 File Offset: 0x001B5494
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006955 RID: 26965 RVA: 0x001B7300 File Offset: 0x001B5500
	protected override UniTask OnBeforeStartAsync()
	{
		AchievementSearchResultItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AchievementSearchResultItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006956 RID: 26966 RVA: 0x001B7343 File Offset: 0x001B5543
	[NullableContext(1)]
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(AchievementSearchData data)
	{
		if (data.AchievementSearchGroupData != null)
		{
			return (AUIBaseActor)base.GetItem(0).GetOwner();
		}
		if (data.AchievementData != null)
		{
			return (AUIBaseActor)base.GetItem(1).GetOwner();
		}
		return null;
	}

	// Token: 0x06006957 RID: 26967 RVA: 0x001B737C File Offset: 0x001B557C
	[NullableContext(1)]
	public void Update(AchievementSearchData data, int index)
	{
		this.Data = data;
		this.DescItem.SetActive(false);
		this.ContentItem.SetActive(false);
		if (data.AchievementSearchGroupData != null)
		{
			this.DescItem.SetActive(true);
			this.DescItem.Update(data);
			return;
		}
		if (data.AchievementData != null)
		{
			this.ContentItem.SetActive(true);
			this.ContentItem.RefreshUi(data.AchievementData);
		}
	}

	// Token: 0x06006958 RID: 26968 RVA: 0x001B73EE File Offset: 0x001B55EE
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x06006959 RID: 26969 RVA: 0x001B73F7 File Offset: 0x001B55F7
	protected override void OnBeforeDestroy()
	{
		if (this.DescItem != null)
		{
			this.DescItem.ClearItem();
		}
		if (this.ContentItem != null)
		{
			this.ContentItem.ClearItem();
		}
		if (this.VectorValue != null)
		{
			this.VectorValue = null;
		}
	}

	// Token: 0x0400320B RID: 12811
	protected AchievementSearchData Data;

	// Token: 0x0400320C RID: 12812
	private AchievementSearchDescItem DescItem;

	// Token: 0x0400320D RID: 12813
	private AchievementDataItem ContentItem;

	// Token: 0x0400320E RID: 12814
	private Vector2D VectorValue;
}
