using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063DD RID: 25565
	public class RoverlikeBlessingRepresentativeItem : UiPanelBase
	{
		// Token: 0x0604032C RID: 262956 RVA: 0x0107426C File Offset: 0x0107246C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604032D RID: 262957 RVA: 0x010742B4 File Offset: 0x010724B4
		public void Refresh(int roleId)
		{
			RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(roleId);
			if (blessRoleConfig == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(blessRoleConfig.Value.IconPath, base.GetTexture(0), null);
		}

		// Token: 0x0200C444 RID: 50244
		private class EComponents
		{
			// Token: 0x0403C6AF RID: 247471
			public const int TextureIcon = 0;
		}
	}
}
