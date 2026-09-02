using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect
{
	// Token: 0x02005AAA RID: 23210
	public class KurotatoLevelHistoryRolePanel : UiPanelBase
	{
		// Token: 0x0603AB49 RID: 240457 RVA: 0x00EE138C File Offset: 0x00EDF58C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB4A RID: 240458 RVA: 0x00EE1438 File Offset: 0x00EDF638
		public void Refresh(int roleId)
		{
			bool flag = roleId == 0;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (flag)
			{
				return;
			}
			KurotatoRoleData kurotatoRoleData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoRoleData(roleId);
			RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(kurotatoRoleData.RealRoleId).Value;
			base.SetTextureByPath(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(kurotatoRoleData.RealRoleSkinId).Value.FormationRoleCard, base.GetTexture(2), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.Name, Array.Empty<object>());
		}

		// Token: 0x0200BAAD RID: 47789
		private enum EComponent
		{
			// Token: 0x04039A24 RID: 236068
			ItemEmpty,
			// Token: 0x04039A25 RID: 236069
			ItemRolePanel,
			// Token: 0x04039A26 RID: 236070
			TextureRole,
			// Token: 0x04039A27 RID: 236071
			TextName
		}
	}
}
