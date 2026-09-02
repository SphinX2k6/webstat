using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200155F RID: 5471
public class ActivityRegressTaskDynamicItem : UiPanelBase, IDynamicScrollBaseItem<ActivityRegressTaskDynamicData>
{
	// Token: 0x0600997C RID: 39292 RVA: 0x002829D4 File Offset: 0x00280BD4
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		ActivityRegressTaskDynamicItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ActivityRegressTaskDynamicItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600997D RID: 39293 RVA: 0x00282A1F File Offset: 0x00280C1F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600997E RID: 39294 RVA: 0x00282A58 File Offset: 0x00280C58
	[NullableContext(1)]
	public FVector2D GetItemSize(ActivityRegressTaskDynamicData data)
	{
		if (data.ItemType == ERegressTaskDynamicItemType.Item)
		{
			UUIItem item = base.GetItem(0);
			return new FVector2D(item.GetWidth(), item.GetHeight());
		}
		UUIItem item2 = base.GetItem(1);
		return new FVector2D(item2.GetWidth(), item2.GetHeight());
	}

	// Token: 0x0600997F RID: 39295 RVA: 0x00282AA1 File Offset: 0x00280CA1
	public void ClearItem()
	{
	}

	// Token: 0x0200791E RID: 31006
	private class EComponents
	{
		// Token: 0x040299E6 RID: 170470
		public const int StripBtn = 0;

		// Token: 0x040299E7 RID: 170471
		public const int TitlePnl = 1;
	}
}
