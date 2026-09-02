using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D7A RID: 19834
	public class MultiHotKeyType : HotKeyTypeBase
	{
		// Token: 0x060335FD RID: 210429 RVA: 0x00CD9B38 File Offset: 0x00CD7D38
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060335FE RID: 210430 RVA: 0x00CD9BA4 File Offset: 0x00CD7DA4
		protected override UniTask OnBeforeStartAsync()
		{
			MultiHotKeyType.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultiHotKeyType.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060335FF RID: 210431 RVA: 0x00CD9BE8 File Offset: 0x00CD7DE8
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			0,
			2
		})]
		private ILayoutItem<UniTask<HotKeyComponent>> OnInitItem(object hotKeyMapId, UUIItem uiItem, int index)
		{
			AActor owner = uiItem.GetOwner();
			if (owner == null)
			{
				return null;
			}
			UniTask<HotKeyComponent> value = HotKeyItemFactory.CreateHotKeyComponent(owner, (int)hotKeyMapId, this);
			return new LayoutItem<UniTask<HotKeyComponent>>
			{
				Key = hotKeyMapId,
				Value = value
			};
		}

		// Token: 0x06033600 RID: 210432 RVA: 0x00CD9C24 File Offset: 0x00CD7E24
		protected override void OnClear()
		{
			foreach (HotKeyComponent hotKeyComponent in this.HotKeyComponentList)
			{
				if (hotKeyComponent != null)
				{
					hotKeyComponent.Clear();
				}
			}
		}

		// Token: 0x06033601 RID: 210433 RVA: 0x00CD9C7C File Offset: 0x00CD7E7C
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		public override List<HotKeyComponent> GetHotKeyComponents()
		{
			return this.HotKeyComponentList;
		}

		// Token: 0x06033602 RID: 210434 RVA: 0x00CD9C84 File Offset: 0x00CD7E84
		public override void KeyItemNotifySetActive(bool value)
		{
			bool active = false;
			foreach (HotKeyComponent hotKeyComponent in this.HotKeyComponentList)
			{
				if (hotKeyComponent != null && hotKeyComponent.IsHotKeyActive())
				{
					active = true;
					break;
				}
			}
			this.SetActive(active);
		}

		// Token: 0x0401DC7E RID: 121982
		[Nullable(new byte[]
		{
			1,
			0,
			2
		})]
		protected GenericLayoutNew<UniTask<HotKeyComponent>> Layout;

		// Token: 0x0401DC7F RID: 121983
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private List<HotKeyComponent> HotKeyComponentList = new List<HotKeyComponent>();

		// Token: 0x0200AD5C RID: 44380
		private class EMultiHotKeyType
		{
			// Token: 0x04035DB1 RID: 220593
			public const int HotKey = 0;

			// Token: 0x04035DB2 RID: 220594
			public const int Layout = 1;
		}
	}
}
