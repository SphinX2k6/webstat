using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect
{
	// Token: 0x02005AB5 RID: 23221
	public class KurotatoLevelUnlockRolePanel : UiPanelBase
	{
		// Token: 0x0603AB84 RID: 240516 RVA: 0x00EE2C4C File Offset: 0x00EE0E4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnRoleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AB85 RID: 240517 RVA: 0x00EE2D58 File Offset: 0x00EE0F58
		public void Refresh(int roleId)
		{
			this.RoleId = roleId;
			KurotatoRoleData kurotatoRoleData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoRoleData(roleId);
			RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(kurotatoRoleData.RealRoleId).Value;
			base.SetTextureByPath(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(kurotatoRoleData.RealRoleSkinId).Value.RoleHeadIconLarge, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Name, Array.Empty<object>());
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetUIActive(kurotatoRoleData.IsUnLock);
			}
			UUITexture texture = base.GetTexture(4);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(!kurotatoRoleData.IsUnLock);
		}

		// Token: 0x0603AB86 RID: 240518 RVA: 0x00EE2E1E File Offset: 0x00EE101E
		private void OnBtnRoleClick()
		{
			this.OnRoleBtnClick(this.RoleId);
		}

		// Token: 0x04021342 RID: 136002
		private int RoleId;

		// Token: 0x04021343 RID: 136003
		[Nullable(1)]
		public Action<int> OnRoleBtnClick = delegate(int _)
		{
		};

		// Token: 0x0200BABA RID: 47802
		private enum EComponent
		{
			// Token: 0x04039A4C RID: 236108
			BtnRole,
			// Token: 0x04039A4D RID: 236109
			TextureRole,
			// Token: 0x04039A4E RID: 236110
			TextName,
			// Token: 0x04039A4F RID: 236111
			SpriteFinish,
			// Token: 0x04039A50 RID: 236112
			TextureLock
		}
	}
}
