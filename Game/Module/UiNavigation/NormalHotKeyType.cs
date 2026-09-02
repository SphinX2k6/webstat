using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D7B RID: 19835
	public class NormalHotKeyType : HotKeyTypeBase
	{
		// Token: 0x06033604 RID: 210436 RVA: 0x00CD9CFC File Offset: 0x00CD7EFC
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

		// Token: 0x06033605 RID: 210437 RVA: 0x00CD9D44 File Offset: 0x00CD7F44
		protected override UniTask OnBeforeStartAsync()
		{
			NormalHotKeyType.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NormalHotKeyType.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033606 RID: 210438 RVA: 0x00CD9D87 File Offset: 0x00CD7F87
		protected override void OnClear()
		{
			HotKeyComponent hotKeyComponent = this.HotKeyComponent;
			if (hotKeyComponent == null)
			{
				return;
			}
			hotKeyComponent.Clear();
		}

		// Token: 0x06033607 RID: 210439 RVA: 0x00CD9D9C File Offset: 0x00CD7F9C
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		public unsafe override List<HotKeyComponent> GetHotKeyComponents()
		{
			int num = 1;
			List<HotKeyComponent> list = new List<HotKeyComponent>(num);
			CollectionsMarshal.SetCount<HotKeyComponent>(list, num);
			Span<HotKeyComponent> span = CollectionsMarshal.AsSpan<HotKeyComponent>(list);
			int index = 0;
			*span[index] = this.HotKeyComponent;
			return list;
		}

		// Token: 0x06033608 RID: 210440 RVA: 0x00CD9DD0 File Offset: 0x00CD7FD0
		public override void KeyItemNotifySetActive(bool value)
		{
			if (this.IsMultiKeyItem)
			{
				this.SetActive(value);
			}
		}

		// Token: 0x0401DC80 RID: 121984
		[Nullable(2)]
		protected HotKeyComponent HotKeyComponent;
	}
}
