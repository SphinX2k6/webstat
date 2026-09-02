using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D3D RID: 11581
public class WeeklyRogueTagItem : GridProxyAbstract<int>
{
	// Token: 0x060175D4 RID: 95700 RVA: 0x0067A83D File Offset: 0x00678A3D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x060175D5 RID: 95701 RVA: 0x0067A878 File Offset: 0x00678A78
	public override void Refresh(int tagId, bool isSelected, int gridIndex)
	{
		RogueWeekTag? rogueWeekTagConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeekTagConfig(tagId);
		if (rogueWeekTagConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueWeekTagConfig.Value.Name, Array.Empty<object>());
		base.GetSprite(0).SetColor(FColor.FromHex(rogueWeekTagConfig.Value.Color));
	}

	// Token: 0x02009000 RID: 36864
	private enum EComponents
	{
		// Token: 0x0403050D RID: 197901
		SpriteBg,
		// Token: 0x0403050E RID: 197902
		TxtTag
	}
}
