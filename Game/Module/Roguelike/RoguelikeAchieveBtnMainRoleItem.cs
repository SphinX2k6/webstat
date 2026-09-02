using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005122 RID: 20770
	public class RoguelikeAchieveBtnMainRoleItem : UiPanelBase
	{
		// Token: 0x060357CC RID: 219084 RVA: 0x00D6DCA4 File Offset: 0x00D6BEA4
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060357CD RID: 219085 RVA: 0x00D6DD2E File Offset: 0x00D6BF2E
		protected override void OnStart()
		{
			this.SetEmptyState(true);
		}

		// Token: 0x060357CE RID: 219086 RVA: 0x00D6DD38 File Offset: 0x00D6BF38
		[NullableContext(2)]
		public void Refresh(RogueArchiveInfoData archiveInfoData)
		{
			int num = (archiveInfoData != null) ? archiveInfoData.RoleIds.ElementAtOrDefault(0) : 0;
			if (num <= 0)
			{
				this.SetEmptyState(true);
				return;
			}
			RoleDataBase roguelikeRoleData = ModelBase<RoguelikeModel>.Instance.GetRoguelikeRoleData(num);
			RoleInfo? roleInfo = (roguelikeRoleData != null) ? new RoleInfo?(roguelikeRoleData.GetRoleConfig()) : null;
			string text = (roleInfo != null) ? roleInfo.GetValueOrDefault().RoleHeadIconCircle : null;
			if (roguelikeRoleData == null || roleInfo == null || string.IsNullOrEmpty(text))
			{
				this.SetEmptyState(true);
				return;
			}
			int roleSkinId = roguelikeRoleData.GetRoleSkinId();
			base.SetRoleSkinIcon(text, base.GetTexture(2), roleSkinId, null, null);
			this.SetEmptyState(false);
		}

		// Token: 0x060357CF RID: 219087 RVA: 0x00D6DDEE File Offset: 0x00D6BFEE
		private void SetEmptyState(bool isEmpty)
		{
			base.GetItem(1).SetUIActive(isEmpty);
			base.GetTexture(2).SetUIActive(!isEmpty);
		}

		// Token: 0x0200B0C5 RID: 45253
		private class EComponents
		{
			// Token: 0x04036D75 RID: 224629
			public const int BtnMainRole = 0;

			// Token: 0x04036D76 RID: 224630
			public const int PnlEmpty = 1;

			// Token: 0x04036D77 RID: 224631
			public const int TexMainRoleAvatar = 2;
		}
	}
}
