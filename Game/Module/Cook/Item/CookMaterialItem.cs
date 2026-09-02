using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.Item
{
	// Token: 0x02005E30 RID: 24112
	public class CookMaterialItem : UiPanelBase
	{
		// Token: 0x0603CAE3 RID: 248547 RVA: 0x00F69A86 File Offset: 0x00F67C86
		[NullableContext(1)]
		public void BindOnClickedCallback(Action<ISingleItemInfo, int> onClicked)
		{
			this.OnClickedCallback = null;
			this.OnClickedCallback = onClicked;
		}

		// Token: 0x0603CAE4 RID: 248548 RVA: 0x00F69A98 File Offset: 0x00F67C98
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

		// Token: 0x0603CAE5 RID: 248549 RVA: 0x00F69AE0 File Offset: 0x00F67CE0
		protected override void OnStart()
		{
			this.ContentItem = new CookMaterialItemContent();
			this.ContentItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
			this.ContentItem.ClickDelegate = null;
			this.ContentItem.ClickDelegate = new Action(this.OnClick);
		}

		// Token: 0x0603CAE6 RID: 248550 RVA: 0x00F69B33 File Offset: 0x00F67D33
		[NullableContext(1)]
		public void Update(ISingleItemInfo data, int index)
		{
			this.CookItemData = data;
			this.ContentItem.Update(data);
			this.Index = index;
		}

		// Token: 0x0603CAE7 RID: 248551 RVA: 0x00F69B4F File Offset: 0x00F67D4F
		private void OnClick()
		{
			Action<ISingleItemInfo, int> onClickedCallback = this.OnClickedCallback;
			if (onClickedCallback == null)
			{
				return;
			}
			onClickedCallback(this.CookItemData, this.Index);
		}

		// Token: 0x0603CAE8 RID: 248552 RVA: 0x00F69B6D File Offset: 0x00F67D6D
		public void UpdateSelectedState(int index)
		{
			if (index == this.Index)
			{
				this.ContentItem.SetSelect();
				return;
			}
			this.ContentItem.SetDelect();
		}

		// Token: 0x0603CAE9 RID: 248553 RVA: 0x00F69B8F File Offset: 0x00F67D8F
		public void RefreshNeed(int num = 1)
		{
			this.ContentItem.RefreshNeed(num);
		}

		// Token: 0x0603CAEA RID: 248554 RVA: 0x00F69B9D File Offset: 0x00F67D9D
		protected override void OnBeforeDestroy()
		{
			this.ContentItem.Destroy(null);
		}

		// Token: 0x04022144 RID: 139588
		[Nullable(2)]
		private CookMaterialItemContent ContentItem;

		// Token: 0x04022145 RID: 139589
		private int Index;

		// Token: 0x04022146 RID: 139590
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ISingleItemInfo, int> OnClickedCallback;

		// Token: 0x04022147 RID: 139591
		[Nullable(2)]
		private ISingleItemInfo CookItemData;

		// Token: 0x0200BE67 RID: 48743
		private enum ECookMaterialItemWrapComponents
		{
			// Token: 0x0403AA09 RID: 240137
			ContentItem
		}
	}
}
