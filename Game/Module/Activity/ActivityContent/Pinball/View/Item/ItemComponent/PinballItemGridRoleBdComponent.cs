using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x0200661C RID: 26140
	public class PinballItemGridRoleBdComponent : PinballItemGridComponentBase
	{
		// Token: 0x06041523 RID: 267555 RVA: 0x010C10F8 File Offset: 0x010BF2F8
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

		// Token: 0x06041524 RID: 267556 RVA: 0x010C1140 File Offset: 0x010BF340
		protected override UniTask OnBeforeStartAsync()
		{
			PinballItemGridRoleBdComponent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballItemGridRoleBdComponent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041525 RID: 267557 RVA: 0x010C1183 File Offset: 0x010BF383
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseType";
		}

		// Token: 0x06041526 RID: 267558 RVA: 0x010C118C File Offset: 0x010BF38C
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
			BdComponent roleBdComponent = this.RoleBdComponent;
			if (roleBdComponent == null)
			{
				return;
			}
			roleBdComponent.RefreshItem(num);
		}

		// Token: 0x040248BA RID: 149690
		[Nullable(2)]
		private BdComponent RoleBdComponent;

		// Token: 0x0200C647 RID: 50759
		private enum EComponent
		{
			// Token: 0x0403D094 RID: 250004
			BdItem
		}
	}
}
