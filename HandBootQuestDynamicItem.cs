using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E92 RID: 7826
[NullableContext(1)]
[Nullable(0)]
public class HandBootQuestDynamicItem : UiPanelBase, IDynamicScrollBaseItem<HandBookQuestDynamicData>
{
	// Token: 0x0600E760 RID: 59232 RVA: 0x003E7CE8 File Offset: 0x003E5EE8
	public UniTask Init(UUIItem actor)
	{
		HandBootQuestDynamicItem.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HandBootQuestDynamicItem.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E761 RID: 59233 RVA: 0x003E7D33 File Offset: 0x003E5F33
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E762 RID: 59234 RVA: 0x003E7D6C File Offset: 0x003E5F6C
	public FVector2D GetItemSize(HandBookQuestDynamicData data)
	{
		UUIItem item = base.GetItem(1);
		return new FVector2D(item.GetWidth(), item.GetHeight());
	}

	// Token: 0x0600E763 RID: 59235 RVA: 0x003E7D92 File Offset: 0x003E5F92
	public void ClearItem()
	{
	}
}
