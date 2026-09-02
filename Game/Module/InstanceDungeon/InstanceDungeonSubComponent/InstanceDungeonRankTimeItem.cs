using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonComponentModel;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BEE RID: 23534
	public class InstanceDungeonRankTimeItem : UiPanelBase
	{
		// Token: 0x0603B91E RID: 243998 RVA: 0x00F19C2C File Offset: 0x00F17E2C
		protected unsafe override void OnRegisterComponent()
		{
			RankTimeItemModelBase rankTimeItemModelBase = this.OpenParam as RankTimeItemModelBase;
			if (rankTimeItemModelBase == null)
			{
				throw new ArgumentNullException("OpenParam");
			}
			this.ItemModel = rankTimeItemModelBase;
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ItemModel.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B91F RID: 243999 RVA: 0x00F19CF8 File Offset: 0x00F17EF8
		public void Refresh()
		{
			TableTextArgNew content = this.ItemModel.GetContent();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), content.TextKey, content.Params);
			base.GetButton(0).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x0402188F RID: 137359
		[Nullable(1)]
		public RankTimeItemModelBase ItemModel;

		// Token: 0x0200BC66 RID: 48230
		private enum EComponentDefine
		{
			// Token: 0x0403A17F RID: 237951
			Button,
			// Token: 0x0403A180 RID: 237952
			Content
		}
	}
}
