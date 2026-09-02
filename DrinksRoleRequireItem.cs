using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001026 RID: 4134
[Nullable(new byte[]
{
	0,
	1
})]
public class DrinksRoleRequireItem : GridProxyAbstract<IDrinksRequireInfo>
{
	// Token: 0x06006B87 RID: 27527 RVA: 0x001C2798 File Offset: 0x001C0998
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
	}

	// Token: 0x06006B88 RID: 27528 RVA: 0x001C2820 File Offset: 0x001C0A20
	[NullableContext(1)]
	public override void Refresh(IDrinksRequireInfo data, bool isSelected, int gridIndex)
	{
		UUISprite sprite = base.GetSprite(2);
		if (sprite != null)
		{
			sprite.SetUIActive(data.Completed);
		}
		UUISprite sprite2 = base.GetSprite(4);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(data.Type == EDrinksRequireType.Flavor);
		}
		UUIItem text = base.GetText(3);
		bool completed = data.Completed;
		FColor? fcolor = new FColor?(base.GetText(3).changeColor);
		text.SetChangeColor(completed, fcolor);
		if (data.Type != EDrinksRequireType.Flavor || data.FlavorRangeId == null)
		{
			DrinksRequireList? requireList = ConfigBase<DrinksConfig>.Instance.GetRequireList(data.RequireId);
			string textStringId;
			switch (data.Type)
			{
			case EDrinksRequireType.DrinksBase:
				textStringId = requireList.Value.DrinkNeedKey;
				break;
			case EDrinksRequireType.Batching:
				textStringId = requireList.Value.BatchingNeedKey;
				break;
			case EDrinksRequireType.Ornament:
				textStringId = requireList.Value.OrnamentNeedKey;
				break;
			default:
				textStringId = "";
				break;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, Array.Empty<object>());
			return;
		}
		DrinksFlavorRange? flavorRange = ConfigBase<DrinksConfig>.Instance.GetFlavorRange(data.FlavorRangeId.Value);
		DrinksFlavorType? flavorType = ConfigBase<DrinksConfig>.Instance.GetFlavorType((EDrinksFlavorType)flavorRange.Value.FlavorTypeRef);
		int[] flavorValuesArray = flavorRange.Value.GetFlavorValuesArray();
		int num = flavorValuesArray[0];
		int num2 = flavorValuesArray[1];
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), flavorRange.Value.Desc, new <>z__ReadOnlyArray<object>(new object[]
		{
			flavorType.Value.IconRichTxt,
			num,
			num2
		}));
	}

	// Token: 0x02007407 RID: 29703
	private static class EItem
	{
		// Token: 0x0402820D RID: 164365
		public const int IconLock = 0;

		// Token: 0x0402820E RID: 164366
		public const int PanelCheck = 1;

		// Token: 0x0402820F RID: 164367
		public const int SpriteCheck = 2;

		// Token: 0x04028210 RID: 164368
		public const int Desc = 3;

		// Token: 0x04028211 RID: 164369
		public const int SpriteMain = 4;
	}
}
