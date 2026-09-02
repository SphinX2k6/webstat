using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x02006639 RID: 26169
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballBattleLevelInfoTargetItem : GridProxyAbstract<PinballBattleLevelInfoTargetData>
	{
		// Token: 0x060415D4 RID: 267732 RVA: 0x010C3C78 File Offset: 0x010C1E78
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060415D5 RID: 267733 RVA: 0x010C3D44 File Offset: 0x010C1F44
		[NullableContext(1)]
		public override void Refresh(PinballBattleLevelInfoTargetData data, bool isSelected, int gridIndex)
		{
			if (data.IsSpecial)
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(0);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUISprite sprite = base.GetSprite(3);
				if (sprite != null)
				{
					sprite.SetUIActive(data.IsFinish);
				}
			}
			else
			{
				UUIItem item3 = base.GetItem(0);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(2);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
				UUISprite sprite2 = base.GetSprite(1);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(data.IsFinish);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.Desc, new <>z__ReadOnlySingleElementList<object>(data.Value));
		}

		// Token: 0x0200C65D RID: 50781
		private enum ETargetItemComponent
		{
			// Token: 0x0403D10A RID: 250122
			PnlPointNormal,
			// Token: 0x0403D10B RID: 250123
			SprNormalTargetFinish,
			// Token: 0x0403D10C RID: 250124
			PnlPointSpecial,
			// Token: 0x0403D10D RID: 250125
			SprSpecialTargetFinish,
			// Token: 0x0403D10E RID: 250126
			TextTargetDesc
		}
	}
}
