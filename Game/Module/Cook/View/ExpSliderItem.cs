using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E28 RID: 24104
	public class ExpSliderItem : UiPanelBase
	{
		// Token: 0x0603CA81 RID: 248449 RVA: 0x00F679BA File Offset: 0x00F65BBA
		[NullableContext(1)]
		public ExpSliderItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CA82 RID: 248450 RVA: 0x00F679D0 File Offset: 0x00F65BD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CA83 RID: 248451 RVA: 0x00F67A5C File Offset: 0x00F65C5C
		public void Update()
		{
			ICookerInfoData cookerInfo = ModelBase<CookModel>.Instance.GetCookerInfo();
			int sumExpByLevel = ModelBase<CookModel>.Instance.GetSumExpByLevel(ModelBase<CookModel>.Instance.GetCookerInfo().CookingLevel);
			double num = Singleton<MathUtils>.Instance.GetFloatPointFloor((double)cookerInfo.TotalProficiencys / (double)sumExpByLevel, 3);
			num = ((num > 1.0) ? 1.0 : num);
			base.GetSprite(0).SetFillAmount((float)num);
			base.GetText(1).SetText(cookerInfo.AddExp.ToString(), true);
			base.GetText(2).SetText(cookerInfo.AddExp.ToString(), true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "CookProgressText", new <>z__ReadOnlyArray<object>(new object[]
			{
				cookerInfo.TotalProficiencys,
				sumExpByLevel
			}));
		}
	}
}
