using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200643C RID: 25660
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeRoleSelectAssistRoleItem : GridProxyAbstract<RoverlikeRoleSelectAssistRoleItemData>
	{
		// Token: 0x060406C1 RID: 263873 RVA: 0x01083E3C File Offset: 0x0108203C
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

		// Token: 0x060406C2 RID: 263874 RVA: 0x01083E84 File Offset: 0x01082084
		public override void Refresh(RoverlikeRoleSelectAssistRoleItemData data, bool isSelected, int gridIndex)
		{
			RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(data.BlessRoleId);
			UUITexture texture = base.GetTexture(0);
			if (blessRoleConfig != null && !string.IsNullOrEmpty(blessRoleConfig.Value.RoleIcon) && texture != null)
			{
				base.SetTextureByPath(blessRoleConfig.Value.RoleIcon, texture, null, null);
			}
		}

		// Token: 0x060406C3 RID: 263875 RVA: 0x01083EEC File Offset: 0x010820EC
		public override object GetKey(RoverlikeRoleSelectAssistRoleItemData data, int gridIndex)
		{
			return data.BlessRoleId;
		}

		// Token: 0x0200C4B2 RID: 50354
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C8AF RID: 247983
			public const int TexRole = 0;
		}
	}
}
