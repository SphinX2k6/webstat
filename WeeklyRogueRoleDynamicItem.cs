using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D34 RID: 11572
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRogueRoleDynamicItem : UiPanelBase, IDynamicScrollBaseItem<IWeeklyRogueRoleGroupInfo>
{
	// Token: 0x060175AC RID: 95660 RVA: 0x00679BA0 File Offset: 0x00677DA0
	public UniTask Init(UUIItem actor)
	{
		WeeklyRogueRoleDynamicItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<WeeklyRogueRoleDynamicItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060175AD RID: 95661 RVA: 0x00679BEC File Offset: 0x00677DEC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x060175AE RID: 95662 RVA: 0x00679CA0 File Offset: 0x00677EA0
	public FVector2D GetItemSize(IWeeklyRogueRoleGroupInfo data)
	{
		if (this.ItemSizeVector == null)
		{
			this.ItemSizeVector = Vector2D.Create();
		}
		if (data.IsTitleType)
		{
			UUIItem item = base.GetItem(2);
			this.ItemSizeVector.Set((double)item.GetWidth(), (double)item.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}
		TWeakObjectPtr<UUIItem> rootUIComp = base.GetGridLayout(0).RootUIComp;
		this.ItemSizeVector.Set((double)rootUIComp.Get().GetWidth(), (double)rootUIComp.Get().GetHeight());
		return this.ItemSizeVector.ToUeVector2D(false);
	}

	// Token: 0x060175AF RID: 95663 RVA: 0x00679D34 File Offset: 0x00677F34
	public void ClearItem()
	{
	}

	// Token: 0x0400B360 RID: 45920
	[Nullable(2)]
	private Vector2D ItemSizeVector;
}
