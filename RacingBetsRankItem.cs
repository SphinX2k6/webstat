using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002729 RID: 10025
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsRankItem : GridProxyAbstract<IRacingBetsRankData>
{
	// Token: 0x06013C59 RID: 80985 RVA: 0x005801D0 File Offset: 0x0057E3D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
		};
	}

	// Token: 0x06013C5A RID: 80986 RVA: 0x00580282 File Offset: 0x0057E482
	public override void Refresh(IRacingBetsRankData data, bool isSelected, int gridIndex)
	{
		this.PlayerData = data;
		this.UpdateItem();
	}

	// Token: 0x06013C5B RID: 80987 RVA: 0x00580294 File Offset: 0x0057E494
	private void UpdateItem()
	{
		if (this.PlayerData == null)
		{
			return;
		}
		IRacingBetsRankData playerData = this.PlayerData;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(playerData.Name, true);
		}
		UUIText text2 = base.GetText(0);
		if (text2 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(playerData.RankNum);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUIText text3 = base.GetText(4);
		if (text3 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(playerData.HitNum);
			text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUIText text4 = base.GetText(5);
		if (text4 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(playerData.CashNum);
			text4.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUITexture texture = base.GetTexture(1);
		int playerHeadPhoto = playerData.PlayerHeadPhoto;
		PersonalModel instance = ModelBase<PersonalModel>.Instance;
		PlayerHeadData playerHeadData = (instance != null) ? instance.GetPlayerHeadData(playerHeadPhoto, true) : null;
		if (playerHeadData == null || texture == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), texture, null);
		int num = 3;
		string hexStr = (playerData.RankNum <= num) ? RacingBetsRankItem.ColorValueList[playerData.RankNum] : RacingBetsRankItem.ColorValueList[0];
		UUISprite sprite = base.GetSprite(3);
		if (sprite == null)
		{
			return;
		}
		sprite.SetColor(FColor.FromHex(hexStr));
	}

	// Token: 0x040099F0 RID: 39408
	[Nullable(2)]
	private IRacingBetsRankData PlayerData;

	// Token: 0x040099F1 RID: 39409
	[StaticVariableRuleIgnore]
	protected static readonly string[] ColorValueList = new string[]
	{
		"1d4970ff",
		"e4733eff",
		"b444c8ff",
		"0084ffff"
	};

	// Token: 0x02008ACE RID: 35534
	[NullableContext(0)]
	private enum EItemComponents
	{
		// Token: 0x0402ECBD RID: 191677
		RankText,
		// Token: 0x0402ECBE RID: 191678
		HeadPhoto,
		// Token: 0x0402ECBF RID: 191679
		NameText,
		// Token: 0x0402ECC0 RID: 191680
		BgSprite,
		// Token: 0x0402ECC1 RID: 191681
		ObjectText,
		// Token: 0x0402ECC2 RID: 191682
		RankScoreText,
		// Token: 0x0402ECC3 RID: 191683
		PlayerItemButton
	}
}
