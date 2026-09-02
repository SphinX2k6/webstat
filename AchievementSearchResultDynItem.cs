using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FEC RID: 4076
[NullableContext(1)]
[Nullable(0)]
public class AchievementSearchResultDynItem : UiPanelBase, IDynamicScrollBaseItem<AchievementSearchData>
{
	// Token: 0x0600694C RID: 26956 RVA: 0x001B70DC File Offset: 0x001B52DC
	public UniTask Init(UUIItem actor)
	{
		AchievementSearchResultDynItem.<Init>d__2 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementSearchResultDynItem.<Init>d__2>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600694D RID: 26957 RVA: 0x001B7128 File Offset: 0x001B5328
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

	// Token: 0x0600694E RID: 26958 RVA: 0x001B7194 File Offset: 0x001B5394
	protected override void OnStart()
	{
		this.DescVec = Vector2D.Create();
		UUIItem item = base.GetItem(0);
		this.DescVec.Set((double)item.GetWidth(), (double)item.GetHeight());
		this.ItemVec = Vector2D.Create();
		item = base.GetItem(1);
		this.ItemVec.Set((double)item.GetWidth(), (double)item.GetHeight());
	}

	// Token: 0x0600694F RID: 26959 RVA: 0x001B71F9 File Offset: 0x001B53F9
	public FVector2D GetItemSize(AchievementSearchData data)
	{
		if (data.AchievementSearchGroupData != null)
		{
			return this.DescVec.ToUeVector2D(false);
		}
		if (data.AchievementData != null)
		{
			return this.ItemVec.ToUeVector2D(false);
		}
		return new Vector2D().ToUeVector2D(false);
	}

	// Token: 0x06006950 RID: 26960 RVA: 0x001B7230 File Offset: 0x001B5430
	public void ClearItem()
	{
	}

	// Token: 0x04003206 RID: 12806
	[Nullable(2)]
	private Vector2D DescVec;

	// Token: 0x04003207 RID: 12807
	[Nullable(2)]
	private Vector2D ItemVec;
}
