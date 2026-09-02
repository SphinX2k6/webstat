using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Friend
{
	// Token: 0x02005D23 RID: 23843
	internal class TeamItem : UiPanelBase
	{
		// Token: 0x0603C224 RID: 246308 RVA: 0x00F4059D File Offset: 0x00F3E79D
		[NullableContext(1)]
		public TeamItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C225 RID: 246309 RVA: 0x00F405B4 File Offset: 0x00F3E7B4
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

		// Token: 0x0603C226 RID: 246310 RVA: 0x00F40640 File Offset: 0x00F3E840
		[NullableContext(1)]
		public void RefreshView(FriendData data)
		{
			base.GetItem(1).SetUIActive(false);
			base.GetItem(2).SetUIActive(false);
			if (data.TeamMemberCount >= 2)
			{
				base.GetItem(1).SetUIActive(true);
			}
			if (data.TeamMemberCount >= 3)
			{
				base.GetItem(2).SetUIActive(true);
			}
		}

		// Token: 0x0200BD95 RID: 48533
		private class ETeamItemComponents
		{
			// Token: 0x0403A647 RID: 239175
			public const int TeamItem = 0;

			// Token: 0x0403A648 RID: 239176
			public const int TeamSecondItem = 1;

			// Token: 0x0403A649 RID: 239177
			public const int TeamThirdItem = 2;
		}
	}
}
