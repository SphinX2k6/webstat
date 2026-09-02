using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Map
{
	// Token: 0x02004FDF RID: 20447
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SheriffMapSubTabItem : GridProxyAbstract<ISheriffSubTabItemData>
	{
		// Token: 0x06034BA1 RID: 215969 RVA: 0x00D39BAC File Offset: 0x00D37DAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034BA2 RID: 215970 RVA: 0x00D39CB5 File Offset: 0x00D37EB5
		private void OnClickItem()
		{
			if (this.Data == null)
			{
				return;
			}
			Action<ISheriffSubTabItemData> clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack(this.Data);
		}

		// Token: 0x06034BA3 RID: 215971 RVA: 0x00D39CD8 File Offset: 0x00D37ED8
		[NullableContext(1)]
		public override void Refresh(ISheriffSubTabItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(data.TabTxt, true);
			}
			base.TrySetSpriteByPath(data.TabIcon, base.GetSprite(1), false, null, null);
			base.GetItem(3).SetUIActive(!data.IsFinished);
			base.GetItem(4).SetUIActive(data.IsFinished);
		}

		// Token: 0x0401E61F RID: 124447
		[Nullable(2)]
		private ISheriffSubTabItemData Data;

		// Token: 0x0401E620 RID: 124448
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ISheriffSubTabItemData> ClickCallBack;

		// Token: 0x0200AFBA RID: 44986
		private static class EComponent
		{
			// Token: 0x0403686E RID: 223342
			public const int Button = 0;

			// Token: 0x0403686F RID: 223343
			public const int Icon = 1;

			// Token: 0x04036870 RID: 223344
			public const int Text = 2;

			// Token: 0x04036871 RID: 223345
			public const int Arrow = 3;

			// Token: 0x04036872 RID: 223346
			public const int Finished = 4;
		}
	}
}
