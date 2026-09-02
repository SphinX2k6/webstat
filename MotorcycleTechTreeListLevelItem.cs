using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002299 RID: 8857
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTechTreeListLevelItem : GridProxyAbstract<IMotorTechLevelPoint>
{
	// Token: 0x06010BE4 RID: 68580 RVA: 0x0049671C File Offset: 0x0049491C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06010BE5 RID: 68581 RVA: 0x0049678C File Offset: 0x0049498C
	[NullableContext(1)]
	public override void Refresh(IMotorTechLevelPoint data, bool isSelected, int gridIndex)
	{
		int targetLevel = data.TargetLevel;
		int curLevel = data.CurLevel;
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(2);
		UUIText text = base.GetText(0);
		UUIText text2 = base.GetText(1);
		UUIItem uuiitem = item;
		bool bUseChangeColor = gridIndex % 2 != 0;
		FColor? fcolor = new FColor?(item.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		bool flag = curLevel > targetLevel;
		bool flag2 = curLevel == targetLevel;
		bool flag3 = curLevel < targetLevel;
		string hexStr = "";
		if (flag)
		{
			hexStr = "ece5d8";
		}
		else if (flag2)
		{
			hexStr = "fff7b4";
		}
		else if (flag3)
		{
			hexStr = "adadad";
		}
		text.SetColor(FColor.FromHex(hexStr));
		item2.SetUIActive(flag2);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(data.Title, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MotorBike_CurrentTechTree_TechLevelInfo", new <>z__ReadOnlyArray<object>(new object[]
		{
			targetLevel,
			localTextNew
		}));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.Desc, Array.Empty<object>());
	}

	// Token: 0x0200856C RID: 34156
	private class EMotorTechLevelItemComponent
	{
		// Token: 0x0402D263 RID: 184931
		public const int TxtLevelTitle = 0;

		// Token: 0x0402D264 RID: 184932
		public const int TxtDesc = 1;

		// Token: 0x0402D265 RID: 184933
		public const int CurLevelItem = 2;

		// Token: 0x0402D266 RID: 184934
		public const int BgItem = 3;
	}
}
