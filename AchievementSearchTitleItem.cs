using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FEF RID: 4079
[NullableContext(1)]
[Nullable(0)]
public class AchievementSearchTitleItem : UiPanelBase
{
	// Token: 0x0600695C RID: 26972 RVA: 0x001B7441 File Offset: 0x001B5641
	public AchievementSearchTitleItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x0600695D RID: 26973 RVA: 0x001B7450 File Offset: 0x001B5650
	public UniTask Init()
	{
		AchievementSearchTitleItem.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementSearchTitleItem.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600695E RID: 26974 RVA: 0x001B7494 File Offset: 0x001B5694
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600695F RID: 26975 RVA: 0x001B74DC File Offset: 0x001B56DC
	protected override void OnStart()
	{
	}

	// Token: 0x06006960 RID: 26976 RVA: 0x001B74DE File Offset: 0x001B56DE
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x06006961 RID: 26977 RVA: 0x001B74E0 File Offset: 0x001B56E0
	public void Update(AchievementSearchData data)
	{
		this.Data = data;
		this.RefreshTitle();
	}

	// Token: 0x06006962 RID: 26978 RVA: 0x001B74EF File Offset: 0x001B56EF
	private void RefreshTitle()
	{
		if (this.Data != null)
		{
			base.GetText(0).SetText(this.Data.AchievementCategoryData.GetTitle(), true);
		}
	}

	// Token: 0x06006963 RID: 26979 RVA: 0x001B7518 File Offset: 0x001B5718
	public FVector2D GetItemSize(Vector2D vector)
	{
		UUIItem rootItem = base.GetRootItem();
		vector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		return vector.ToUeVector2D(false);
	}

	// Token: 0x06006964 RID: 26980 RVA: 0x001B7547 File Offset: 0x001B5747
	public AUIBaseActor GetUsingItem()
	{
		return (AUIBaseActor)base.GetRootItem().GetOwner();
	}

	// Token: 0x06006965 RID: 26981 RVA: 0x001B7559 File Offset: 0x001B5759
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0400320F RID: 12815
	[Nullable(2)]
	private AchievementSearchData Data;

	// Token: 0x04003210 RID: 12816
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x020073D1 RID: 29649
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402811D RID: 164125
		Text
	}
}
