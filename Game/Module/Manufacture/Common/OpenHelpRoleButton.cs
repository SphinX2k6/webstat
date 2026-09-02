using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059EF RID: 23023
	public class OpenHelpRoleButton : UiPanelBase
	{
		// Token: 0x0603A54E RID: 238926 RVA: 0x00ECA1E4 File Offset: 0x00EC83E4
		[NullableContext(1)]
		public OpenHelpRoleButton(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A54F RID: 238927 RVA: 0x00ECA1FC File Offset: 0x00EC83FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OpenHelpRole));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A550 RID: 238928 RVA: 0x00ECA2C4 File Offset: 0x00EC84C4
		public void RefreshIcon()
		{
			int? currentRoleId = Singleton<CommonManager>.Instance.GetCurrentRoleId();
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(currentRoleId.Value, true);
			base.SetRoleIcon(roleDataById.GetRoleConfig().RoleHeadIcon, base.GetTexture(1), currentRoleId.Value, null, null);
		}

		// Token: 0x0603A551 RID: 238929 RVA: 0x00ECA31C File Offset: 0x00EC851C
		public void RefreshRedDot(int itemId)
		{
			int? currentRoleId = Singleton<CommonManager>.Instance.GetCurrentRoleId();
			base.GetItem(2).SetUIActive(Singleton<CommonManager>.Instance.CheckIsBuffEx(currentRoleId.Value, itemId));
		}

		// Token: 0x0603A552 RID: 238930 RVA: 0x00ECA352 File Offset: 0x00EC8552
		[NullableContext(1)]
		public void BindOnCallback(Action onCallback)
		{
			this.OnCallback = onCallback;
		}

		// Token: 0x0603A553 RID: 238931 RVA: 0x00ECA35B File Offset: 0x00EC855B
		private void OpenHelpRole()
		{
			if (this.OnCallback != null)
			{
				this.OnCallback();
			}
		}

		// Token: 0x040210A4 RID: 135332
		[Nullable(2)]
		private Action OnCallback;

		// Token: 0x0200B9BD RID: 47549
		private class EOpenHelpRoleDefine
		{
			// Token: 0x0403964F RID: 235087
			public const int OpenButton = 0;

			// Token: 0x04039650 RID: 235088
			public const int RoleIconTexture = 1;

			// Token: 0x04039651 RID: 235089
			public const int RedDotItem = 2;
		}
	}
}
