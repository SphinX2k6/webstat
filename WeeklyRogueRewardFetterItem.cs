using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D31 RID: 11569
public class WeeklyRogueRewardFetterItem : GridProxyAbstract<int>
{
	// Token: 0x06017599 RID: 95641 RVA: 0x006795D0 File Offset: 0x006777D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x0601759A RID: 95642 RVA: 0x00679609 File Offset: 0x00677809
	protected override void OnStart()
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(false);
	}

	// Token: 0x0601759B RID: 95643 RVA: 0x00679620 File Offset: 0x00677820
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		string fetterElementPath = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data).FetterElementPath;
		base.SetTextureByPath(fetterElementPath, base.GetTexture(1), null, null);
	}

	// Token: 0x02008FF5 RID: 36853
	private enum EFetter
	{
		// Token: 0x040304DD RID: 197853
		Sprite,
		// Token: 0x040304DE RID: 197854
		Texture
	}
}
