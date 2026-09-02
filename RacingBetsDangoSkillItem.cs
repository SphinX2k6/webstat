using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200271E RID: 10014
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsDangoSkillItem : GridProxyAbstract<RacingBetsDungeonDangoInfo>
{
	// Token: 0x06013C11 RID: 80913 RVA: 0x0057F5A0 File Offset: 0x0057D7A0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06013C12 RID: 80914 RVA: 0x0057F5FC File Offset: 0x0057D7FC
	[NullableContext(1)]
	public override void Refresh(RacingBetsDungeonDangoInfo data, bool isSelected, int gridIndex)
	{
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(data.DangoId);
		base.SetTextureShowUntilLoaded(dangoData.Icon, base.GetTexture(0), null);
		DangoSkill? skillConfig = dangoData.GetSkillConfig();
		if (skillConfig != null)
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(skillConfig.Value.Name);
			}
			UUIText text2 = base.GetText(2);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew(skillConfig.Value.Desc);
		}
	}

	// Token: 0x02008AC5 RID: 35525
	private class EComponent
	{
		// Token: 0x0402EC9C RID: 191644
		public const int DangoIcon = 0;

		// Token: 0x0402EC9D RID: 191645
		public const int SkillName = 1;

		// Token: 0x0402EC9E RID: 191646
		public const int SkillDesc = 2;
	}
}
