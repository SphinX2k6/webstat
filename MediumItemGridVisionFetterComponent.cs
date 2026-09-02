using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020019EE RID: 6638
public class MediumItemGridVisionFetterComponent : MediumItemGridComponent
{
	// Token: 0x0600BE23 RID: 48675 RVA: 0x00325963 File Offset: 0x00323B63
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRogue";
	}

	// Token: 0x0600BE24 RID: 48676 RVA: 0x0032596C File Offset: 0x00323B6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BE25 RID: 48677 RVA: 0x003259D8 File Offset: 0x00323BD8
	protected override UniTask OnBeforeStartAsync()
	{
		MediumItemGridVisionFetterComponent.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MediumItemGridVisionFetterComponent.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BE26 RID: 48678 RVA: 0x00325A1B File Offset: 0x00323C1B
	protected override void OnActivate()
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600BE27 RID: 48679 RVA: 0x00325A30 File Offset: 0x00323C30
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (!(data is int))
		{
			return;
		}
		int groupId = (int)data;
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(groupId);
		this.SetActive(true);
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem == null)
		{
			return;
		}
		visionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
	}

	// Token: 0x04005972 RID: 22898
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02007CDC RID: 31964
	private class EComponent
	{
		// Token: 0x0402A99A RID: 174490
		public const int ElementItem = 0;

		// Token: 0x0402A99B RID: 174491
		public const int ElementNumText = 1;
	}
}
