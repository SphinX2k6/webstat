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
	// Token: 0x02004D7D RID: 19837
	public class MultipleHotKeyItem : HotKeyItem
	{
		// Token: 0x0603360A RID: 210442 RVA: 0x00CD9DEC File Offset: 0x00CD7FEC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603360B RID: 210443 RVA: 0x00CD9E58 File Offset: 0x00CD8058
		protected override UniTask OnBeforeStartAsync()
		{
			MultipleHotKeyItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultipleHotKeyItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603360C RID: 210444 RVA: 0x00CD9E9C File Offset: 0x00CD809C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			1,
			0,
			2
		})]
		private ILayoutItem<UniTask<HotKeyTypeBase>> OnInitItem(object hotKeyTypeId, UUIItem uiItem, int index)
		{
			UniTask<HotKeyTypeBase> value = HotKeyTypeCreator.CreateHotKeyType(uiItem.GetOwner(), ((int?)hotKeyTypeId).Value, true);
			return new LayoutItem<UniTask<HotKeyTypeBase>>
			{
				Key = hotKeyTypeId,
				Value = value
			};
		}

		// Token: 0x0603360D RID: 210445 RVA: 0x00CD9ED8 File Offset: 0x00CD80D8
		protected override void OnClear()
		{
			foreach (HotKeyTypeBase hotKeyTypeBase in this.HotKeyTypeList)
			{
				hotKeyTypeBase.Clear();
			}
		}

		// Token: 0x0603360E RID: 210446 RVA: 0x00CD9F28 File Offset: 0x00CD8128
		private UniTask RefreshHotKey()
		{
			MultipleHotKeyItem.<RefreshHotKey>d__8 <RefreshHotKey>d__;
			<RefreshHotKey>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshHotKey>d__.<>4__this = this;
			<RefreshHotKey>d__.<>1__state = -1;
			<RefreshHotKey>d__.<>t__builder.Start<MultipleHotKeyItem.<RefreshHotKey>d__8>(ref <RefreshHotKey>d__);
			return <RefreshHotKey>d__.<>t__builder.Task;
		}

		// Token: 0x0603360F RID: 210447 RVA: 0x00CD9F6C File Offset: 0x00CD816C
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		public override List<HotKeyComponent> GetHotKeyComponentArray()
		{
			List<HotKeyTypeBase> hotKeyTypeList = this.HotKeyTypeList;
			List<HotKeyComponent> list = new List<HotKeyComponent>();
			foreach (HotKeyTypeBase hotKeyTypeBase in hotKeyTypeList)
			{
				list.AddRange(hotKeyTypeBase.GetHotKeyComponents());
			}
			return list;
		}

		// Token: 0x0401DC83 RID: 121987
		[Nullable(new byte[]
		{
			2,
			0,
			2
		})]
		private GenericLayoutNew<UniTask<HotKeyTypeBase>> Layout;

		// Token: 0x0401DC84 RID: 121988
		private int HotKeyViewIndex;

		// Token: 0x0401DC85 RID: 121989
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private List<HotKeyTypeBase> HotKeyTypeList = new List<HotKeyTypeBase>();

		// Token: 0x0200AD5F RID: 44383
		private class EKeyCommonCom
		{
			// Token: 0x04035DBB RID: 220603
			public const int Layout = 0;

			// Token: 0x04035DBC RID: 220604
			public const int SingleHotKeyItem = 1;
		}
	}
}
