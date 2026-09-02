using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D7 RID: 25047
	[NullableContext(2)]
	[Nullable(0)]
	public class CategoryToggleItem : UiPanelBase
	{
		// Token: 0x17009B41 RID: 39745
		// (get) Token: 0x0603F33F RID: 258879 RVA: 0x01039A78 File Offset: 0x01037C78
		// (set) Token: 0x0603F340 RID: 258880 RVA: 0x01039A80 File Offset: 0x01037C80
		public Action<EToggleState> OnToggleClickCallBack { get; set; }

		// Token: 0x0603F341 RID: 258881 RVA: 0x01039A8C File Offset: 0x01037C8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F342 RID: 258882 RVA: 0x01039B53 File Offset: 0x01037D53
		private void ToggleClick(EToggleState state)
		{
			Action<EToggleState> onToggleClickCallBack = this.OnToggleClickCallBack;
			if (onToggleClickCallBack == null)
			{
				return;
			}
			onToggleClickCallBack(state);
		}

		// Token: 0x0603F343 RID: 258883 RVA: 0x01039B68 File Offset: 0x01037D68
		[NullableContext(1)]
		public void SetIcon(string iconPath)
		{
			this.SetSpriteByPath(iconPath, base.GetSprite(1), false, null, null);
		}

		// Token: 0x0603F344 RID: 258884 RVA: 0x01039B8E File Offset: 0x01037D8E
		[NullableContext(1)]
		public UUIExtendToggle GetTabToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x0603F345 RID: 258885 RVA: 0x01039B97 File Offset: 0x01037D97
		public void SetRedDotState(bool bVisible)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(bVisible);
		}

		// Token: 0x0200C317 RID: 49943
		[NullableContext(0)]
		private class EToggleComponents
		{
			// Token: 0x0403C228 RID: 246312
			public const int Toggle = 0;

			// Token: 0x0403C229 RID: 246313
			public const int Icon = 1;

			// Token: 0x0403C22A RID: 246314
			public const int RedDot = 2;
		}
	}
}
