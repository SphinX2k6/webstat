using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.DreamLink;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.AdvanceNotice
{
	// Token: 0x020069EA RID: 27114
	public class AdvanceNoticeRoleItemView : AdvanceNoticeItemView
	{
		// Token: 0x0604331F RID: 275231 RVA: 0x01144710 File Offset: 0x01142910
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043320 RID: 275232 RVA: 0x0114479A File Offset: 0x0114299A
		protected override void OnStart()
		{
			base.OnStart();
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			base.GetSpine(2).SetAnimation(0, EDreamLinkSpineDefine.Idle.ToString(), true);
		}

		// Token: 0x0200C964 RID: 51556
		private enum EComponent
		{
			// Token: 0x0403DF00 RID: 253696
			DescItem,
			// Token: 0x0403DF01 RID: 253697
			ThemeTextTexture,
			// Token: 0x0403DF02 RID: 253698
			SpineActor
		}
	}
}
