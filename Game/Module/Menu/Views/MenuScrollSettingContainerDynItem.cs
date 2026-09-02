using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x0200576F RID: 22383
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuScrollSettingContainerDynItem : UiPanelBase, IDynamicScrollBaseItem<MenuScrollItemData>
	{
		// Token: 0x06038F60 RID: 233312 RVA: 0x00E6E9C0 File Offset: 0x00E6CBC0
		public UniTask Init(UUIItem actor)
		{
			MenuScrollSettingContainerDynItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MenuScrollSettingContainerDynItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038F61 RID: 233313 RVA: 0x00E6EA0C File Offset: 0x00E6CC0C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06038F62 RID: 233314 RVA: 0x00E6EAA8 File Offset: 0x00E6CCA8
		public FVector2D GetItemSize(MenuScrollItemData itemData)
		{
			if (this.VectorValue == null)
			{
				this.VectorValue = Vector2D.Create();
			}
			UUIItem currentTypeUiItem = this.GetCurrentTypeUiItem(itemData);
			if (currentTypeUiItem != null)
			{
				this.VectorValue.Set((double)currentTypeUiItem.GetWidth(), (double)currentTypeUiItem.GetHeight());
			}
			else
			{
				this.VectorValue.Set(0.0, 0.0);
			}
			return this.VectorValue.ToUeVector2D(false);
		}

		// Token: 0x06038F63 RID: 233315 RVA: 0x00E6EB18 File Offset: 0x00E6CD18
		[return: Nullable(2)]
		private UUIItem GetCurrentTypeUiItem(MenuScrollItemData itemData)
		{
			if (itemData.Type == EMenuScrollItemType.TitleItem)
			{
				return base.GetItem(1);
			}
			switch (itemData.Data.SetType)
			{
			case ESetType.SLIDER:
				return base.GetItem(4);
			case ESetType.OPTIONS:
				return base.GetItem(3);
			case ESetType.KEYMAP:
				return base.GetItem(2);
			case ESetType.BUTTON:
				return base.GetItem(2);
			case ESetType.DROPDOWN:
				return base.GetItem(5);
			default:
				return null;
			}
		}

		// Token: 0x06038F64 RID: 233316 RVA: 0x00E6EB88 File Offset: 0x00E6CD88
		public void ClearItem()
		{
		}

		// Token: 0x040206E9 RID: 132841
		[Nullable(2)]
		private Vector2D VectorValue;
	}
}
