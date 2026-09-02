using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x0200659D RID: 26013
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballRankRoleHeadItem : GridProxyAbstract<PinballRankRoleHeadData>
	{
		// Token: 0x06040FF6 RID: 266230 RVA: 0x010AD998 File Offset: 0x010ABB98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040FF7 RID: 266231 RVA: 0x010ADA04 File Offset: 0x010ABC04
		[NullableContext(1)]
		public override void Refresh(PinballRankRoleHeadData data, bool isSelected, int gridIndex)
		{
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(data.RoleId);
			if (pinballRoleConfigById != null)
			{
				base.SetTextureByPath(pinballRoleConfigById.Value.MiddleIcon, base.GetTexture(0), null, null);
			}
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Level);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0200C593 RID: 50579
		private enum EComponents
		{
			// Token: 0x0403CCED RID: 249069
			TexRoleIcon,
			// Token: 0x0403CCEE RID: 249070
			TxtLv
		}
	}
}
