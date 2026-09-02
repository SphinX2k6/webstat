using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061AD RID: 25005
	public class RoleItem : GridProxyAbstract<int>
	{
		// Token: 0x0603F22F RID: 258607 RVA: 0x0103212C File Offset: 0x0103032C
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

		// Token: 0x0603F230 RID: 258608 RVA: 0x01032174 File Offset: 0x01030374
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(data);
			if (roleConfig == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(roleConfig.Value.RoleHeadIcon, base.GetTexture(0), null);
		}
	}
}
