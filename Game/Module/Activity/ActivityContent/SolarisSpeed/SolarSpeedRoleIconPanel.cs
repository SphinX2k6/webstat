using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006399 RID: 25497
	public class SolarSpeedRoleIconPanel : UiPanelBase
	{
		// Token: 0x06040050 RID: 262224 RVA: 0x01068BE3 File Offset: 0x01066DE3
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture))
			};
		}

		// Token: 0x06040051 RID: 262225 RVA: 0x01068C08 File Offset: 0x01066E08
		[NullableContext(1)]
		public void Refresh(ISolarSpeedRoleIconPanelData data)
		{
			base.SetTextureByPath(data.IconPath, base.GetTexture(0), null, null);
		}

		// Token: 0x0200C3F7 RID: 50167
		private enum ERoleIconComponent
		{
			// Token: 0x0403C5BE RID: 247230
			IconTexture
		}
	}
}
