using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DAC RID: 23980
	public class DreamLinkRoleSelectPanel : UiPanelBase
	{
		// Token: 0x0603C624 RID: 247332 RVA: 0x00F53AF8 File Offset: 0x00F51CF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C625 RID: 247333 RVA: 0x00F53B84 File Offset: 0x00F51D84
		private void RefreshHandle()
		{
			foreach (DreamLinkRoleItem dreamLinkRoleItem in this.RoleItemList)
			{
				dreamLinkRoleItem.Refresh();
			}
		}

		// Token: 0x0603C626 RID: 247334 RVA: 0x00F53BD4 File Offset: 0x00F51DD4
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkRoleSelectPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkRoleSelectPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C627 RID: 247335 RVA: 0x00F53C18 File Offset: 0x00F51E18
		public void RefreshInstId(int instId)
		{
			foreach (DreamLinkRoleItem dreamLinkRoleItem in this.RoleItemList)
			{
				dreamLinkRoleItem.RefreshInstId(instId);
			}
		}

		// Token: 0x04021F42 RID: 139074
		[Nullable(1)]
		public List<DreamLinkRoleItem> RoleItemList = new List<DreamLinkRoleItem>();

		// Token: 0x0200BDF2 RID: 48626
		private class EPanelDefine
		{
			// Token: 0x0403A7AD RID: 239533
			public const int RoleItem1 = 0;

			// Token: 0x0403A7AE RID: 239534
			public const int RoleItem2 = 1;

			// Token: 0x0403A7AF RID: 239535
			public const int RoleItem3 = 2;
		}
	}
}
