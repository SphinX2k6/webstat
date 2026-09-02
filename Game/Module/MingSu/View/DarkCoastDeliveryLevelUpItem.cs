using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x0200573D RID: 22333
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DarkCoastDeliveryLevelUpItem : GridProxyAbstract<DarkCoastDeliveryLevelData>
	{
		// Token: 0x06038D80 RID: 232832 RVA: 0x00E660C4 File Offset: 0x00E642C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture))
			};
		}

		// Token: 0x06038D81 RID: 232833 RVA: 0x00E660E8 File Offset: 0x00E642E8
		[NullableContext(1)]
		public override void Refresh(DarkCoastDeliveryLevelData data, bool isSelected, int gridIndex)
		{
			string visionTexture = data.Config.VisionTexture;
			base.SetTextureShowUntilLoaded(visionTexture, base.GetTexture(0), null);
		}

		// Token: 0x0200B7E9 RID: 47081
		private static class EComponent
		{
			// Token: 0x04038E17 RID: 232983
			public const int VisionTexture = 0;
		}
	}
}
