using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E94 RID: 7828
public class MonsterHandBookDynamicItem : UiPanelBase, IDynamicScrollBaseItem<MonsterHandBookDynamicData>
{
	// Token: 0x0600E77E RID: 59262 RVA: 0x003E8504 File Offset: 0x003E6704
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		MonsterHandBookDynamicItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<MonsterHandBookDynamicItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E77F RID: 59263 RVA: 0x003E854F File Offset: 0x003E674F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E780 RID: 59264 RVA: 0x003E8588 File Offset: 0x003E6788
	[NullableContext(1)]
	public FVector2D GetItemSize(MonsterHandBookDynamicData data)
	{
		if (!string.IsNullOrEmpty(data.TitleId))
		{
			UUIItem item = base.GetItem(0);
			return new FVector2D(item.GetWidth(), item.GetHeight());
		}
		UUIItem item2 = base.GetItem(1);
		return new FVector2D(item2.GetWidth(), item2.GetHeight());
	}

	// Token: 0x0600E781 RID: 59265 RVA: 0x003E85D5 File Offset: 0x003E67D5
	public void ClearItem()
	{
	}

	// Token: 0x020081D8 RID: 33240
	private class EMonsterDynamicItemDefine
	{
		// Token: 0x0402C0D9 RID: 180441
		public const int TitleItem = 0;

		// Token: 0x0402C0DA RID: 180442
		public const int LayoutItem = 1;
	}
}
