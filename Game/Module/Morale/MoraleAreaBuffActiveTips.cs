using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x020056FB RID: 22267
	public class MoraleAreaBuffActiveTips : UiTickViewBase
	{
		// Token: 0x06038AA4 RID: 232100 RVA: 0x00E593EB File Offset: 0x00E575EB
		[NullableContext(1)]
		public MoraleAreaBuffActiveTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038AA5 RID: 232101 RVA: 0x00E593F4 File Offset: 0x00E575F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038AA6 RID: 232102 RVA: 0x00E5958A File Offset: 0x00E5778A
		private void InitDataParam()
		{
		}

		// Token: 0x06038AA7 RID: 232103 RVA: 0x00E5958C File Offset: 0x00E5778C
		protected override void OnStart()
		{
			this.InitDataParam();
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(4);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
		}

		// Token: 0x06038AA8 RID: 232104 RVA: 0x00E595CC File Offset: 0x00E577CC
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06038AA9 RID: 232105 RVA: 0x00E595D4 File Offset: 0x00E577D4
		public void UpdateData()
		{
			this.TipCountDown = (float)ConfigBase<MoraleConfig>.Instance.GetMoraleBuffShowTime();
			MoraleAreaBuffActiveTipsParams moraleAreaBuffActiveTipsParams = this.OpenParam as MoraleAreaBuffActiveTipsParams;
			base.GetText(1).ShowTextNew(((moraleAreaBuffActiveTipsParams != null) ? moraleAreaBuffActiveTipsParams.TitleKey : null) ?? "not title key");
			base.GetText(2).ShowTextNew(((moraleAreaBuffActiveTipsParams != null) ? moraleAreaBuffActiveTipsParams.DescKey : null) ?? "not desc key");
		}

		// Token: 0x06038AAA RID: 232106 RVA: 0x00E59640 File Offset: 0x00E57840
		protected override void OnTick(float delta)
		{
			if (this.TipCountDown <= 0f)
			{
				return;
			}
			this.TipCountDown -= delta;
			if (this.TipCountDown <= 0f)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x040204F6 RID: 132342
		public float TipCountDown;

		// Token: 0x0200B76D RID: 46957
		private enum EChildType
		{
			// Token: 0x04038BAD RID: 232365
			TextTitle = 1,
			// Token: 0x04038BAE RID: 232366
			TextDes,
			// Token: 0x04038BAF RID: 232367
			PanelHaveTitle,
			// Token: 0x04038BB0 RID: 232368
			PanelNoTitle,
			// Token: 0x04038BB1 RID: 232369
			ItemTagNew,
			// Token: 0x04038BB2 RID: 232370
			SpriteTagBg,
			// Token: 0x04038BB3 RID: 232371
			PanelClockIcon,
			// Token: 0x04038BB4 RID: 232372
			TxtNew,
			// Token: 0x04038BB5 RID: 232373
			ItemCheck,
			// Token: 0x04038BB6 RID: 232374
			ItemInvalid,
			// Token: 0x04038BB7 RID: 232375
			ItemInvalidLine
		}
	}
}
