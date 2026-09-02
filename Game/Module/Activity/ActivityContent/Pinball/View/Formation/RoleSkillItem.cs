using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006631 RID: 26161
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleSkillItem : GridProxyAbstract<IRoleSkillItemData>
	{
		// Token: 0x06041594 RID: 267668 RVA: 0x010C2BF8 File Offset: 0x010C0DF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041595 RID: 267669 RVA: 0x010C2C84 File Offset: 0x010C0E84
		[NullableContext(1)]
		public override void Refresh(IRoleSkillItemData data, bool isSelected, int gridIndex)
		{
			PinballSkillDisplayConfig? pinballSkillDisplayConfigById = ConfigBase<PinballConfig>.Instance.GetPinballSkillDisplayConfigById(data.ConfigId);
			if (pinballSkillDisplayConfigById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), pinballSkillDisplayConfigById.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), pinballSkillDisplayConfigById.Value.Desc, pinballSkillDisplayConfigById.Value.ValueList());
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0200C657 RID: 50775
		private enum ERoleSkillItem
		{
			// Token: 0x0403D0DF RID: 250079
			TitleText,
			// Token: 0x0403D0E0 RID: 250080
			DesText,
			// Token: 0x0403D0E1 RID: 250081
			LeaderItem
		}
	}
}
