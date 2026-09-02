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
	// Token: 0x0200512E RID: 20782
	public class RoguelikeAchieveTeamRoleItem : UiPanelBase
	{
		// Token: 0x06035810 RID: 219152 RVA: 0x00D6EB70 File Offset: 0x00D6CD70
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035811 RID: 219153 RVA: 0x00D6EBFA File Offset: 0x00D6CDFA
		protected override void OnStart()
		{
			this.SetEmptyState(true);
		}

		// Token: 0x06035812 RID: 219154 RVA: 0x00D6EC04 File Offset: 0x00D6CE04
		[NullableContext(2)]
		public void Refresh(RogueArchiveInfoData archiveInfoData, int roleIndex)
		{
			if (roleIndex < 0)
			{
				this.SetEmptyState(true);
				return;
			}
			int num = (archiveInfoData != null) ? archiveInfoData.RoleIds.ElementAtOrDefault(roleIndex) : 0;
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

		// Token: 0x06035813 RID: 219155 RVA: 0x00D6ECC6 File Offset: 0x00D6CEC6
		private void SetEmptyState(bool isEmpty)
		{
			base.GetItem(1).SetUIActive(isEmpty);
			base.GetTexture(2).SetUIActive(!isEmpty);
		}

		// Token: 0x0200B0CD RID: 45261
		private class ERoguelikeAchieveTeamRoleItemComponents
		{
			// Token: 0x04036D8E RID: 224654
			public const int BtnItem = 0;

			// Token: 0x04036D8F RID: 224655
			public const int PnlEmpty = 1;

			// Token: 0x04036D90 RID: 224656
			public const int TexRoleAvatar = 2;
		}
	}
}
