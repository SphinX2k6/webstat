using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200271F RID: 10015
public class RacingBetsDangoTerrainItem : GridProxyAbstract<int>
{
	// Token: 0x06013C14 RID: 80916 RVA: 0x0057F688 File Offset: 0x0057D888
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06013C15 RID: 80917 RVA: 0x0057F6E4 File Offset: 0x0057D8E4
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		RacingBetsOrgan? organConfig = ConfigBase<RacingBetsConfig>.Instance.GetOrganConfig(data);
		if (organConfig == null)
		{
			return;
		}
		base.GetText(1).ShowTextNew(organConfig.Value.Name);
		base.GetText(2).ShowTextNew(organConfig.Value.Description);
		base.SetTextureShowUntilLoaded(organConfig.Value.IconPath, base.GetTexture(0), null);
	}

	// Token: 0x02008AC6 RID: 35526
	private class EComponent
	{
		// Token: 0x0402EC9F RID: 191647
		public const int TerrainIcon = 0;

		// Token: 0x0402ECA0 RID: 191648
		public const int TerrainName = 1;

		// Token: 0x0402ECA1 RID: 191649
		public const int TerrainDesc = 2;
	}
}
