using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200271B RID: 10011
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsDangoOrderItem : GridProxyAbstract<DangoIdToDiceNum>
{
	// Token: 0x06013BFA RID: 80890 RVA: 0x0057EF61 File Offset: 0x0057D161
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x06013BFB RID: 80891 RVA: 0x0057EF9C File Offset: 0x0057D19C
	[NullableContext(1)]
	public override void Refresh(DangoIdToDiceNum diceInfo, bool isSelected, int gridIndex)
	{
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(diceInfo.DangoId);
		base.SetTextureShowUntilLoaded(dangoData.Icon, base.GetTexture(0), null);
		DangoConfig instance = ConfigBase<DangoConfig>.Instance;
		Dice? dice = (instance != null) ? instance.GetDiceById(diceInfo.DiceId) : null;
		if (dice != null)
		{
			base.SetTextureShowUntilLoaded(dice.Value.RollDiceBackgroundIcon, base.GetTexture(1), null);
		}
	}

	// Token: 0x02008ABB RID: 35515
	private enum EComponent
	{
		// Token: 0x0402EC70 RID: 191600
		DangoIcon,
		// Token: 0x0402EC71 RID: 191601
		DiceIcon
	}
}
