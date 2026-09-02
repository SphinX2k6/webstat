using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E90 RID: 7824
[NullableContext(1)]
[Nullable(0)]
public class HandBootNounDynamicItem : UiPanelBase, IDynamicScrollBaseItem<HandBookNounDynamicData>
{
	// Token: 0x0600E754 RID: 59220 RVA: 0x003E7A7C File Offset: 0x003E5C7C
	public UniTask Init(UUIItem actor)
	{
		HandBootNounDynamicItem.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HandBootNounDynamicItem.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E755 RID: 59221 RVA: 0x003E7AC7 File Offset: 0x003E5CC7
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E756 RID: 59222 RVA: 0x003E7B00 File Offset: 0x003E5D00
	public FVector2D GetItemSize(HandBookNounDynamicData data)
	{
		if (data.HandBookNounConfigId != null)
		{
			int? handBookNounConfigId = data.HandBookNounConfigId;
			int num = 0;
			if (!(handBookNounConfigId.GetValueOrDefault() == num & handBookNounConfigId != null))
			{
				UUIItem item = base.GetItem(1);
				return new FVector2D(item.GetWidth(), item.GetHeight());
			}
		}
		UUIItem item2 = base.GetItem(0);
		return new FVector2D(item2.GetWidth(), item2.GetHeight());
	}

	// Token: 0x0600E757 RID: 59223 RVA: 0x003E7B6A File Offset: 0x003E5D6A
	public void ClearItem()
	{
	}
}
