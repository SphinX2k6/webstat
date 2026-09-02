using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x0200661E RID: 26142
	public class PinballItemGridRoleClassComponent : PinballItemGridComponentBase
	{
		// Token: 0x0604152B RID: 267563 RVA: 0x010C12B0 File Offset: 0x010BF4B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604152C RID: 267564 RVA: 0x010C12F8 File Offset: 0x010BF4F8
		protected override UniTask OnBeforeStartAsync()
		{
			PinballItemGridRoleClassComponent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballItemGridRoleClassComponent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604152D RID: 267565 RVA: 0x010C133B File Offset: 0x010BF53B
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseRoleJob";
		}

		// Token: 0x0604152E RID: 267566 RVA: 0x010C1344 File Offset: 0x010BF544
		[NullableContext(1)]
		protected override void OnRefresh(params object[] args)
		{
			int num = (int)args[0];
			if (num <= 0)
			{
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			ClassComponent roleClassComponent = this.RoleClassComponent;
			if (roleClassComponent == null)
			{
				return;
			}
			roleClassComponent.RefreshItem(num);
		}

		// Token: 0x040248BB RID: 149691
		[Nullable(2)]
		private ClassComponent RoleClassComponent;

		// Token: 0x0200C64A RID: 50762
		private enum EComponent
		{
			// Token: 0x0403D09D RID: 250013
			Item
		}
	}
}
