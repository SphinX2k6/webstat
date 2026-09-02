using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B41 RID: 11073
public class SurvivorsCardTipsView : UiViewBase
{
	// Token: 0x06016157 RID: 90455 RVA: 0x00620A4D File Offset: 0x0061EC4D
	[NullableContext(1)]
	public SurvivorsCardTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016158 RID: 90456 RVA: 0x00620A58 File Offset: 0x0061EC58
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x06016159 RID: 90457 RVA: 0x00620ABF File Offset: 0x0061ECBF
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601615A RID: 90458 RVA: 0x00620AC8 File Offset: 0x0061ECC8
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsCardTipsView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsCardTipsView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601615B RID: 90459 RVA: 0x00620B0C File Offset: 0x0061ED0C
	protected override void OnStart()
	{
		object openParam = this.OpenParam;
		if (openParam != null)
		{
			SurvivorsRogueItemCard survivorsRogueItemCard = openParam as SurvivorsRogueItemCard;
			if (survivorsRogueItemCard != null)
			{
				SurvivorsRogueCardBase cardItem = this.CardItem;
				if (cardItem == null)
				{
					return;
				}
				cardItem.Apply(survivorsRogueItemCard);
				return;
			}
			else
			{
				SurvivorsRogueCharacterCard survivorsRogueCharacterCard = openParam as SurvivorsRogueCharacterCard;
				if (survivorsRogueCharacterCard != null)
				{
					SurvivorsRogueCardBase cardItem2 = this.CardItem;
					if (cardItem2 == null)
					{
						return;
					}
					cardItem2.Apply(survivorsRogueCharacterCard);
					return;
				}
				else
				{
					SurvivorsRogueWeaponCard survivorsRogueWeaponCard = openParam as SurvivorsRogueWeaponCard;
					if (survivorsRogueWeaponCard != null)
					{
						SurvivorsRogueCardBase cardItem3 = this.CardItem;
						if (cardItem3 == null)
						{
							return;
						}
						cardItem3.Apply(survivorsRogueWeaponCard);
					}
				}
			}
		}
	}

	// Token: 0x0400AA16 RID: 43542
	[Nullable(2)]
	private SurvivorsRogueCardBase CardItem;
}
