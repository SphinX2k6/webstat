using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F01 RID: 28417
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DollDescriptionItem : SyncGridProxyAbstract<IDollDescriptionItemData>
	{
		// Token: 0x06044DA1 RID: 282017 RVA: 0x011EA484 File Offset: 0x011E8684
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044DA2 RID: 282018 RVA: 0x011EA50E File Offset: 0x011E870E
		protected override void OnStart()
		{
			this.DollIconItem = new DollDescriptionIconItemPanel();
			this.DollIconItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
		}

		// Token: 0x06044DA3 RID: 282019 RVA: 0x011EA534 File Offset: 0x011E8734
		public override void Refresh(IDollDescriptionItemData data)
		{
			DollDescriptionIconItemPanel dollIconItem = this.DollIconItem;
			if (dollIconItem != null)
			{
				dollIconItem.SetIconTexture(data.IconPath);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TextTitle, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.TextContent, Array.Empty<object>());
		}

		// Token: 0x040265BE RID: 157118
		[Nullable(2)]
		private DollDescriptionIconItemPanel DollIconItem;
	}
}
