using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FE1 RID: 4065
[NullableContext(1)]
[Nullable(0)]
public class AchievementGroupSmallDynItem : UiPanelBase, IDynamicScrollBaseItem<AchievementGroupData>
{
	// Token: 0x060068CE RID: 26830 RVA: 0x001B4E8C File Offset: 0x001B308C
	public UniTask Init(UUIItem actor)
	{
		AchievementGroupSmallDynItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementGroupSmallDynItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060068CF RID: 26831 RVA: 0x001B4ED8 File Offset: 0x001B30D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060068D0 RID: 26832 RVA: 0x001B4F84 File Offset: 0x001B3184
	public FVector2D GetItemSize(AchievementGroupData data)
	{
		if (this.ItemSizeVector == null)
		{
			this.ItemSizeVector = Vector2D.Create();
		}
		UUIItem rootItem = base.GetRootItem();
		this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		return this.ItemSizeVector.ToUeVector2D(false);
	}

	// Token: 0x060068D1 RID: 26833 RVA: 0x001B4FD0 File Offset: 0x001B31D0
	public void ClearItem()
	{
	}

	// Token: 0x040031DB RID: 12763
	[Nullable(2)]
	private Vector2D ItemSizeVector;
}
