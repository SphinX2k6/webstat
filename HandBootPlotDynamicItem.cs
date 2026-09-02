using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E91 RID: 7825
[NullableContext(1)]
[Nullable(0)]
public class HandBootPlotDynamicItem : UiPanelBase, IDynamicScrollBaseItem<HandBookPlotDynamicData>
{
	// Token: 0x0600E75A RID: 59226 RVA: 0x003E7B80 File Offset: 0x003E5D80
	public UniTask Init(UUIItem actor)
	{
		HandBootPlotDynamicItem.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HandBootPlotDynamicItem.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E75B RID: 59227 RVA: 0x003E7BCC File Offset: 0x003E5DCC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600E75C RID: 59228 RVA: 0x003E7C3C File Offset: 0x003E5E3C
	public FVector2D GetItemSize(HandBookPlotDynamicData data)
	{
		if (!string.IsNullOrEmpty(data.NodeText))
		{
			UUIItem item = base.GetItem(2);
			return new FVector2D(item.GetWidth(), item.GetHeight());
		}
		if (data.TalkOption != null)
		{
			UUIItem item2 = base.GetItem(1);
			return new FVector2D(item2.GetWidth(), item2.GetHeight());
		}
		if (data.OptionTalker.GetValueOrDefault())
		{
			UUIItem item3 = base.GetItem(3);
			return new FVector2D(item3.GetWidth(), item3.GetHeight());
		}
		UUIItem item4 = base.GetItem(0);
		return new FVector2D(item4.GetWidth(), item4.GetHeight());
	}

	// Token: 0x0600E75D RID: 59229 RVA: 0x003E7CD2 File Offset: 0x003E5ED2
	public void ClearItem()
	{
	}
}
