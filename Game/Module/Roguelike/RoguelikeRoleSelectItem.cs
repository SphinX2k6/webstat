using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005159 RID: 20825
	public class RoguelikeRoleSelectItem : UiPanelBase
	{
		// Token: 0x060359A5 RID: 219557 RVA: 0x00D76D40 File Offset: 0x00D74F40
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRole));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060359A6 RID: 219558 RVA: 0x00D76E49 File Offset: 0x00D75049
		private void OnClickRole()
		{
			Action<int> onClickRoleCallback = this.OnClickRoleCallback;
			if (onClickRoleCallback == null)
			{
				return;
			}
			onClickRoleCallback(this.Index);
		}

		// Token: 0x060359A7 RID: 219559 RVA: 0x00D76E64 File Offset: 0x00D75064
		public void Refresh(int roleId)
		{
			bool flag = roleId == 0;
			base.GetTexture(2).SetUIActive(!flag);
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(3).SetUIActive(flag);
			if (flag)
			{
				return;
			}
			RoleModel instance = ModelBase<RoleModel>.Instance;
			RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(roleId, true) : null;
			if (roleDataBase == null)
			{
				return;
			}
			string roleHeadIconCircle = roleDataBase.GetRoleConfig().RoleHeadIconCircle;
			int roleSkinId = roleDataBase.GetRoleSkinId();
			base.SetRoleSkinIcon(roleHeadIconCircle, base.GetTexture(2), roleSkinId, null, null);
		}

		// Token: 0x060359A8 RID: 219560 RVA: 0x00D76EF1 File Offset: 0x00D750F1
		public void ShowNewUnlockRole(bool isShow)
		{
			base.GetItem(4).SetUIActive(isShow);
		}

		// Token: 0x0401ECA0 RID: 126112
		[Nullable(2)]
		public Action<int> OnClickRoleCallback;

		// Token: 0x0401ECA1 RID: 126113
		public int Index;

		// Token: 0x0200B106 RID: 45318
		private class EComponents
		{
			// Token: 0x04036E97 RID: 224919
			public const int BtnRole = 0;

			// Token: 0x04036E98 RID: 224920
			public const int PanelRole = 1;

			// Token: 0x04036E99 RID: 224921
			public const int TexRole = 2;

			// Token: 0x04036E9A RID: 224922
			public const int PanelEmpty = 3;

			// Token: 0x04036E9B RID: 224923
			public const int PanelNewUnlock = 4;
		}
	}
}
