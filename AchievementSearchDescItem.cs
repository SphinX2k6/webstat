using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FEA RID: 4074
[NullableContext(1)]
[Nullable(0)]
public class AchievementSearchDescItem : UiPanelBase
{
	// Token: 0x06006933 RID: 26931 RVA: 0x001B6CE8 File Offset: 0x001B4EE8
	public AchievementSearchDescItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x06006934 RID: 26932 RVA: 0x001B6CF8 File Offset: 0x001B4EF8
	public UniTask Init()
	{
		AchievementSearchDescItem.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementSearchDescItem.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06006935 RID: 26933 RVA: 0x001B6D3C File Offset: 0x001B4F3C
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

	// Token: 0x06006936 RID: 26934 RVA: 0x001B6D84 File Offset: 0x001B4F84
	protected override void OnStart()
	{
	}

	// Token: 0x06006937 RID: 26935 RVA: 0x001B6D86 File Offset: 0x001B4F86
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x06006938 RID: 26936 RVA: 0x001B6D88 File Offset: 0x001B4F88
	public void Update(AchievementSearchData data)
	{
		this.Data = data;
		this.RefreshDesc();
	}

	// Token: 0x06006939 RID: 26937 RVA: 0x001B6D97 File Offset: 0x001B4F97
	private void RefreshDesc()
	{
		if (this.Data != null)
		{
			base.GetText(0).SetText(this.Data.AchievementSearchGroupData.AchievementGroupData.GetTitle(), true);
		}
	}

	// Token: 0x0600693A RID: 26938 RVA: 0x001B6DC4 File Offset: 0x001B4FC4
	public FVector2D GetItemSize(Vector2D vector)
	{
		UUIItem rootItem = base.GetRootItem();
		vector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		return vector.ToUeVector2D(false);
	}

	// Token: 0x0600693B RID: 26939 RVA: 0x001B6DF3 File Offset: 0x001B4FF3
	public AUIBaseActor GetUsingItem()
	{
		return (AUIBaseActor)base.GetRootItem().GetOwner();
	}

	// Token: 0x0600693C RID: 26940 RVA: 0x001B6E05 File Offset: 0x001B5005
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x040031FF RID: 12799
	[Nullable(2)]
	private AchievementSearchData Data;

	// Token: 0x04003200 RID: 12800
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x020073C9 RID: 29641
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040280FE RID: 164094
		Text
	}
}
