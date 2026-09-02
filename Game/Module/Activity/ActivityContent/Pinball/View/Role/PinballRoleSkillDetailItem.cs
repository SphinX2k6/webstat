using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065DC RID: 26076
	public class PinballRoleSkillDetailItem : GridProxyAbstract<PinballSkillDisplayConfig>
	{
		// Token: 0x0604124C RID: 266828 RVA: 0x010B62C0 File Offset: 0x010B44C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604124D RID: 266829 RVA: 0x010B6329 File Offset: 0x010B4529
		public override void Refresh(PinballSkillDisplayConfig data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Desc, data.ValueList());
		}

		// Token: 0x0200C5E1 RID: 50657
		private enum EComponent
		{
			// Token: 0x0403CE80 RID: 249472
			NameText,
			// Token: 0x0403CE81 RID: 249473
			DescriptionText
		}
	}
}
