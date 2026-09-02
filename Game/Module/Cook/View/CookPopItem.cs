using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E1E RID: 24094
	[NullableContext(1)]
	[Nullable(0)]
	public class CookPopItem : UiPanelBase
	{
		// Token: 0x0603C9F0 RID: 248304 RVA: 0x00F65092 File Offset: 0x00F63292
		public CookPopItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C9F1 RID: 248305 RVA: 0x00F650A8 File Offset: 0x00F632A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(delegate()
			{
				this.OnClick();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C9F2 RID: 248306 RVA: 0x00F65192 File Offset: 0x00F63392
		public void Update(ICookPopItem data)
		{
			this.ItemData = data;
			this.SetIcon();
			this.SetQuality();
			this.SetCount();
		}

		// Token: 0x0603C9F3 RID: 248307 RVA: 0x00F651B0 File Offset: 0x00F633B0
		private void SetIcon()
		{
			base.SetItemIcon(base.GetTexture(4), this.ItemData.ItemId, null, null);
		}

		// Token: 0x0603C9F4 RID: 248308 RVA: 0x00F651E0 File Offset: 0x00F633E0
		private void SetQuality()
		{
			base.SetItemQualityIcon(base.GetSprite(5), this.ItemData.ItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		}

		// Token: 0x0603C9F5 RID: 248309 RVA: 0x00F65210 File Offset: 0x00F63410
		private void SetCount()
		{
			base.GetText(8).SetText(this.ItemData.ItemNum.ToString(), true);
		}

		// Token: 0x0603C9F6 RID: 248310 RVA: 0x00F6523D File Offset: 0x00F6343D
		private void OnClick()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemData.ItemId, true, null);
		}

		// Token: 0x040220FE RID: 139518
		[Nullable(2)]
		private ICookPopItem ItemData;
	}
}
