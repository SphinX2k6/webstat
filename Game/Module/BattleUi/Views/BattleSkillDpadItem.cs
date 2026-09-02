using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC8 RID: 24520
	public class BattleSkillDpadItem : UiPanelBase
	{
		// Token: 0x0603DA84 RID: 252548 RVA: 0x00FB5828 File Offset: 0x00FB3A28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DA85 RID: 252549 RVA: 0x00FB58F4 File Offset: 0x00FB3AF4
		protected override void OnStart()
		{
			this.ItemList.Add(base.GetItem(1));
			this.ItemList.Add(base.GetItem(2));
			this.ItemList.Add(base.GetItem(3));
			this.ItemList.Add(base.GetItem(4));
			for (int i = 0; i < 4; i++)
			{
				this.EnableList.Add(true);
			}
		}

		// Token: 0x0603DA86 RID: 252550 RVA: 0x00FB5961 File Offset: 0x00FB3B61
		public void SetVisible(bool bVisible)
		{
			if (bVisible)
			{
				if (!base.IsShowOrShowing)
				{
					base.Show(null);
					return;
				}
			}
			else if (base.IsShowOrShowing)
			{
				base.Hide(null);
			}
		}

		// Token: 0x0603DA87 RID: 252551 RVA: 0x00FB5985 File Offset: 0x00FB3B85
		public void SetArrowVisible(int index, bool visible)
		{
			this.ItemList[index].SetUIActive(visible);
		}

		// Token: 0x0603DA88 RID: 252552 RVA: 0x00FB5999 File Offset: 0x00FB3B99
		public void SetBgVisible(bool visible)
		{
			base.GetItem(0).SetUIActive(visible);
		}

		// Token: 0x0603DA89 RID: 252553 RVA: 0x00FB59A8 File Offset: 0x00FB3BA8
		public void SetArrowEnable(int index, bool bEnable, bool bForce = false)
		{
			if (this.EnableList[index] == bEnable && !bForce)
			{
				return;
			}
			if (bEnable)
			{
				this.ItemList[index].SetAlpha(1f);
			}
			else
			{
				this.ItemList[index].SetAlpha(0.2f);
			}
			this.EnableList[index] = bEnable;
		}

		// Token: 0x040229BA RID: 141754
		[Nullable(1)]
		private readonly List<UUIItem> ItemList = new List<UUIItem>();

		// Token: 0x040229BB RID: 141755
		[Nullable(1)]
		private readonly List<bool> EnableList = new List<bool>();

		// Token: 0x0200C036 RID: 49206
		private enum EChildType
		{
			// Token: 0x0403B2B8 RID: 242360
			BgItem,
			// Token: 0x0403B2B9 RID: 242361
			UpItem,
			// Token: 0x0403B2BA RID: 242362
			LeftItem,
			// Token: 0x0403B2BB RID: 242363
			DownItem,
			// Token: 0x0403B2BC RID: 242364
			RightItem
		}
	}
}
