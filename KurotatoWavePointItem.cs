using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D19 RID: 7449
public class KurotatoWavePointItem : UiPanelBase
{
	// Token: 0x0600DAEB RID: 56043 RVA: 0x003AC8A6 File Offset: 0x003AAAA6
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600DAEC RID: 56044 RVA: 0x003AC8C9 File Offset: 0x003AAAC9
	public void SetLightVisible(bool visible)
	{
		base.GetSprite(0).SetUIActive(visible);
	}

	// Token: 0x02008090 RID: 32912
	private static class EComponentDefine
	{
		// Token: 0x0402BBA0 RID: 179104
		public const int SpriteLight = 0;
	}
}
