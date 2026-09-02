using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AEB RID: 10987
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandFactory
{
	// Token: 0x06015F8D RID: 89997 RVA: 0x006194C8 File Offset: 0x006176C8
	[return: Nullable(2)]
	public static SurvivorsRogueCommandBase Create(SurvivorsOpData data)
	{
		ESurvivorsRogueCommandType? esurvivorsRogueCommandType = null;
		string text = data.DataCase.ToString();
		if (text != null)
		{
			switch (text.Length)
			{
			case 14:
				if (text == "Proto_ShopView")
				{
					esurvivorsRogueCommandType = new ESurvivorsRogueCommandType?(ESurvivorsRogueCommandType.Shop);
				}
				break;
			case 16:
			{
				char c = text[6];
				if (c != 'E')
				{
					if (c == 'R')
					{
						if (text == "Proto_ResultView")
						{
							esurvivorsRogueCommandType = new ESurvivorsRogueCommandType?(ESurvivorsRogueCommandType.ResultSettle);
						}
					}
				}
				else if (text == "Proto_EvolveView")
				{
					esurvivorsRogueCommandType = new ESurvivorsRogueCommandType?(ESurvivorsRogueCommandType.Evolve);
				}
				break;
			}
			case 20:
				if (text == "Proto_TokenAwardView")
				{
					esurvivorsRogueCommandType = new ESurvivorsRogueCommandType?(ESurvivorsRogueCommandType.RewardGot);
				}
				break;
			case 21:
				if (text == "Proto_TokenSelectView")
				{
					esurvivorsRogueCommandType = new ESurvivorsRogueCommandType?(ESurvivorsRogueCommandType.RewardSelect);
				}
				break;
			case 22:
				if (text == "Proto_WeaponSelectView")
				{
					esurvivorsRogueCommandType = new ESurvivorsRogueCommandType?(ESurvivorsRogueCommandType.WeaponSelect);
				}
				break;
			case 24:
				if (text == "Proto_RoleOrWeaponUpView")
				{
					esurvivorsRogueCommandType = new ESurvivorsRogueCommandType?(ESurvivorsRogueCommandType.AdditionRewardGot);
				}
				break;
			}
		}
		if (esurvivorsRogueCommandType == null)
		{
			return null;
		}
		return (SurvivorsRogueCommandBase)Activator.CreateInstance(SurvivorsRogueCommandFactory.TypeCommandClassCtorMap[esurvivorsRogueCommandType.Value], new object[]
		{
			esurvivorsRogueCommandType.Value
		});
	}

	// Token: 0x06015F8F RID: 89999 RVA: 0x0061964C File Offset: 0x0061784C
	// Note: this type is marked as 'beforefieldinit'.
	static SurvivorsRogueCommandFactory()
	{
		Dictionary<ESurvivorsRogueCommandType, Type> dictionary = new Dictionary<ESurvivorsRogueCommandType, Type>();
		dictionary[ESurvivorsRogueCommandType.RewardGot] = typeof(SurvivorsRogueCommandRewardGot);
		dictionary[ESurvivorsRogueCommandType.RewardSelect] = typeof(SurvivorsRogueCommandRewardSelect);
		dictionary[ESurvivorsRogueCommandType.WeaponSelect] = typeof(SurvivorsRogueCommandWeaponSelect);
		dictionary[ESurvivorsRogueCommandType.Shop] = typeof(SurvivorsRogueCommandShop);
		dictionary[ESurvivorsRogueCommandType.Evolve] = typeof(SurvivorsRogueCommandEvolve);
		dictionary[ESurvivorsRogueCommandType.ResultSettle] = typeof(SurvivorsRogueCommandResultSettle);
		dictionary[ESurvivorsRogueCommandType.AdditionRewardGot] = typeof(SurvivorsRogueCommandAdditionRewardGot);
		SurvivorsRogueCommandFactory.TypeCommandClassCtorMap = dictionary;
	}

	// Token: 0x0400A8D1 RID: 43217
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<ESurvivorsRogueCommandType, Type> TypeCommandClassCtorMap;
}
