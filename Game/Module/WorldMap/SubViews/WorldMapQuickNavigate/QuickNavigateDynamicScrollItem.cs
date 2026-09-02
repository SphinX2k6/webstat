using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B6C RID: 19308
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickNavigateDynamicScrollItem : UiPanelBase, IDynamicScrollItem<QuickNavigateDynamicData>
	{
		// Token: 0x06032729 RID: 206633 RVA: 0x00C9E98C File Offset: 0x00C9CB8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603272A RID: 206634 RVA: 0x00C9E9F8 File Offset: 0x00C9CBF8
		public UniTask Init(UUIItem actor)
		{
			QuickNavigateDynamicScrollItem.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<QuickNavigateDynamicScrollItem.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603272B RID: 206635 RVA: 0x00C9EA44 File Offset: 0x00C9CC44
		protected override UniTask OnBeforeStartAsync()
		{
			QuickNavigateDynamicScrollItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuickNavigateDynamicScrollItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603272C RID: 206636 RVA: 0x00C9EA87 File Offset: 0x00C9CC87
		[return: Nullable(2)]
		public AUIBaseActor GetUsingItem(QuickNavigateDynamicData data)
		{
			if (data.ItemType == EQuickNavigateItemType.Country)
			{
				return this.GetItemActor(EQuickNavigateDynamicComponent.UiItemTabA);
			}
			if (data.ItemType == EQuickNavigateItemType.State)
			{
				return this.GetItemActor(EQuickNavigateDynamicComponent.UiItemTabB);
			}
			return null;
		}

		// Token: 0x0603272D RID: 206637 RVA: 0x00C9EAAB File Offset: 0x00C9CCAB
		[NullableContext(2)]
		private AUIBaseActor GetItemActor(EQuickNavigateDynamicComponent key)
		{
			UUIItem item = base.GetItem((int)key);
			return ((item != null) ? item.GetOwner() : null) as AUIBaseActor;
		}

		// Token: 0x0603272E RID: 206638 RVA: 0x00C9EAC8 File Offset: 0x00C9CCC8
		public void Update(QuickNavigateDynamicData data, int index)
		{
			bool flag = data.ItemType == EQuickNavigateItemType.Country;
			QuickNavigateItemPanelA quickNavigateItemPanelA = this.QuickNavigateItemPanelA;
			if (quickNavigateItemPanelA != null)
			{
				quickNavigateItemPanelA.SetActive(flag);
			}
			QuickNavigateItemPanelB quickNavigateItemPanelB = this.QuickNavigateItemPanelB;
			if (quickNavigateItemPanelB != null)
			{
				quickNavigateItemPanelB.SetActive(!flag);
			}
			if (flag)
			{
				QuickNavigateItemPanelA quickNavigateItemPanelA2 = this.QuickNavigateItemPanelA;
				if (quickNavigateItemPanelA2 == null)
				{
					return;
				}
				quickNavigateItemPanelA2.RefreshByData(data);
				return;
			}
			else
			{
				QuickNavigateItemPanelB quickNavigateItemPanelB2 = this.QuickNavigateItemPanelB;
				if (quickNavigateItemPanelB2 == null)
				{
					return;
				}
				quickNavigateItemPanelB2.RefreshByData(data);
				return;
			}
		}

		// Token: 0x0603272F RID: 206639 RVA: 0x00C9EB2C File Offset: 0x00C9CD2C
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x0401D6F4 RID: 120564
		[Nullable(2)]
		private QuickNavigateItemPanelA QuickNavigateItemPanelA;

		// Token: 0x0401D6F5 RID: 120565
		[Nullable(2)]
		private QuickNavigateItemPanelB QuickNavigateItemPanelB;
	}
}
