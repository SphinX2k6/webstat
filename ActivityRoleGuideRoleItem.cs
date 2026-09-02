using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001577 RID: 5495
public class ActivityRoleGuideRoleItem : UiPanelBase
{
	// Token: 0x06009A3F RID: 39487 RVA: 0x002864FC File Offset: 0x002846FC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009A40 RID: 39488 RVA: 0x00286544 File Offset: 0x00284744
	protected override void OnBeforeShow()
	{
		USpineSkeletonAnimationComponent spine = base.GetSpine(0);
		if (spine == null)
		{
			return;
		}
		spine.SetAnimation(0, "idle", true);
	}

	// Token: 0x02007939 RID: 31033
	private class EComponents
	{
		// Token: 0x04029A67 RID: 170599
		public const int SpineActor = 0;
	}
}
