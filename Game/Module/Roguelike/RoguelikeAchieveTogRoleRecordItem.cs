using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200512F RID: 20783
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeAchieveTogRoleRecordItem : GridProxyAbstract<RoguelikeAchieveSlotData>
	{
		// Token: 0x06035815 RID: 219157 RVA: 0x00D6ECF0 File Offset: 0x00D6CEF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleItemClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035816 RID: 219158 RVA: 0x00D6EDD8 File Offset: 0x00D6CFD8
		public override void Refresh(RoguelikeAchieveSlotData data, bool isSelected, int gridIndex)
		{
			this.SlotData = data;
			this.RefreshSlotIndex(data);
			this.RefreshRoleAvatar(data);
			this.SetToggleState(isSelected, false);
		}

		// Token: 0x06035817 RID: 219159 RVA: 0x00D6EDF7 File Offset: 0x00D6CFF7
		protected override void OnStart()
		{
			this.SetRoleAvatarActive(false);
			this.SetToggleState(false, false);
		}

		// Token: 0x06035818 RID: 219160 RVA: 0x00D6EE08 File Offset: 0x00D6D008
		protected override void OnBeforeDestroy()
		{
			this.SlotData = null;
			this.OnToggleStateChanged = null;
		}

		// Token: 0x06035819 RID: 219161 RVA: 0x00D6EE18 File Offset: 0x00D6D018
		public void BindOnToggleStateChanged(Action<RoguelikeAchieveSlotData, int, EToggleState> callback)
		{
			this.OnToggleStateChanged = callback;
		}

		// Token: 0x0603581A RID: 219162 RVA: 0x00D6EE21 File Offset: 0x00D6D021
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true, fireEvent);
		}

		// Token: 0x0603581B RID: 219163 RVA: 0x00D6EE2B File Offset: 0x00D6D02B
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false, fireEvent);
		}

		// Token: 0x0603581C RID: 219164 RVA: 0x00D6EE35 File Offset: 0x00D6D035
		private void OnToggleItemClick(EToggleState state)
		{
			if (this.SlotData == null)
			{
				return;
			}
			Action<RoguelikeAchieveSlotData, int, EToggleState> onToggleStateChanged = this.OnToggleStateChanged;
			if (onToggleStateChanged == null)
			{
				return;
			}
			onToggleStateChanged(this.SlotData, base.GridIndex, state);
		}

		// Token: 0x0603581D RID: 219165 RVA: 0x00D6EE60 File Offset: 0x00D6D060
		private void RefreshSlotIndex(RoguelikeAchieveSlotData data)
		{
			RogueArchiveInfoData archiveInfoData = data.ArchiveInfoData;
			int? num = (archiveInfoData != null) ? new int?(archiveInfoData.ShowIndex) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() <= num3 & num2 != null))
				{
					UUIText text = base.GetText(1);
					if (text == null)
					{
						return;
					}
					text.SetText(num.Value.ToString().PadLeft(2, '0'), true);
					return;
				}
			}
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText("", true);
		}

		// Token: 0x0603581E RID: 219166 RVA: 0x00D6EEF4 File Offset: 0x00D6D0F4
		private void RefreshRoleAvatar(RoguelikeAchieveSlotData data)
		{
			RogueArchiveInfoData archiveInfoData = data.ArchiveInfoData;
			int? num;
			if (archiveInfoData == null)
			{
				num = null;
			}
			else
			{
				RoguelikeInfo roguelikeInfo = archiveInfoData.RoguelikeInfo;
				num = ((roguelikeInfo != null) ? new int?(roguelikeInfo.RoleEntry.ConfigId) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			if (valueOrDefault <= 0)
			{
				this.SetRoleAvatarActive(false);
				return;
			}
			RoleDataBase roguelikeRoleData = ModelBase<RoguelikeModel>.Instance.GetRoguelikeRoleData(valueOrDefault);
			RoleInfo? roleInfo = (roguelikeRoleData != null) ? new RoleInfo?(roguelikeRoleData.GetRoleConfig()) : null;
			string text = (roleInfo != null) ? roleInfo.GetValueOrDefault().RoleHeadIconCircle : null;
			if (roguelikeRoleData == null || roleInfo == null || string.IsNullOrEmpty(text))
			{
				this.SetRoleAvatarActive(false);
				return;
			}
			int roleSkinId = roguelikeRoleData.GetRoleSkinId();
			this.SetRoleAvatarActive(true);
			base.SetRoleSkinIcon(text, base.GetTexture(3), roleSkinId, null, null);
		}

		// Token: 0x0603581F RID: 219167 RVA: 0x00D6EFDC File Offset: 0x00D6D1DC
		private void SetToggleState(bool isSelected, bool fireEvent)
		{
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(state, fireEvent, false, false);
		}

		// Token: 0x06035820 RID: 219168 RVA: 0x00D6F006 File Offset: 0x00D6D206
		private void SetRoleAvatarActive(bool isActive)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(isActive);
			}
			UUITexture texture = base.GetTexture(3);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(isActive);
		}

		// Token: 0x0401EC07 RID: 125959
		[Nullable(2)]
		private RoguelikeAchieveSlotData SlotData;

		// Token: 0x0401EC08 RID: 125960
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<RoguelikeAchieveSlotData, int, EToggleState> OnToggleStateChanged;

		// Token: 0x0200B0CE RID: 45262
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036D91 RID: 224657
			public const int ToggleItem = 0;

			// Token: 0x04036D92 RID: 224658
			public const int TxtNum = 1;

			// Token: 0x04036D93 RID: 224659
			public const int RoleAvatarItem = 2;

			// Token: 0x04036D94 RID: 224660
			public const int TexRole = 3;
		}
	}
}
