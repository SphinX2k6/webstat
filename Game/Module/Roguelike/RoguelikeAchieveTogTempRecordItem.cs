using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005131 RID: 20785
	public class RoguelikeAchieveTogTempRecordItem : UiPanelBase
	{
		// Token: 0x06035826 RID: 219174 RVA: 0x00D6F038 File Offset: 0x00D6D238
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleItemClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035827 RID: 219175 RVA: 0x00D6F141 File Offset: 0x00D6D341
		protected override void OnStart()
		{
			base.SetUiActive(false);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			this.SetRoleAvatarActive(false);
			this.SetToggleState(false, false);
		}

		// Token: 0x06035828 RID: 219176 RVA: 0x00D6F16C File Offset: 0x00D6D36C
		protected override void OnBeforeDestroy()
		{
			this.OnToggleStateChanged = null;
		}

		// Token: 0x06035829 RID: 219177 RVA: 0x00D6F175 File Offset: 0x00D6D375
		[NullableContext(2)]
		public void Refresh(RogueArchiveInfoData archiveInfoData, bool isSaved)
		{
			if (archiveInfoData == null)
			{
				base.SetUiActive(false);
				this.SetToggleState(false, false);
				return;
			}
			base.SetUiActive(true);
			this.RefreshStateIcon(isSaved);
			this.RefreshRoleAvatar(archiveInfoData);
		}

		// Token: 0x0603582A RID: 219178 RVA: 0x00D6F19F File Offset: 0x00D6D39F
		[NullableContext(1)]
		public void BindOnToggleStateChanged(TTempRecordToggleStateChanged callback)
		{
			this.OnToggleStateChanged = callback;
		}

		// Token: 0x0603582B RID: 219179 RVA: 0x00D6F1A8 File Offset: 0x00D6D3A8
		public void SetToggleState(bool isSelected, bool fireEvent)
		{
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(state, fireEvent, false, false);
		}

		// Token: 0x0603582C RID: 219180 RVA: 0x00D6F1D2 File Offset: 0x00D6D3D2
		private void OnToggleItemClick(EToggleState state)
		{
			TTempRecordToggleStateChanged onToggleStateChanged = this.OnToggleStateChanged;
			if (onToggleStateChanged == null)
			{
				return;
			}
			onToggleStateChanged(state);
		}

		// Token: 0x0603582D RID: 219181 RVA: 0x00D6F1E8 File Offset: 0x00D6D3E8
		private void RefreshStateIcon(bool isSaved)
		{
			string path = isSaved ? RoguelikeAchieveDefine.RoguelikeAchieveUnSavedStateIconPath : RoguelikeAchieveDefine.RoguelikeAchieveSavedStateIconPath;
			this.SetSpriteByPath(path, base.GetSprite(1), false, null, null);
		}

		// Token: 0x0603582E RID: 219182 RVA: 0x00D6F220 File Offset: 0x00D6D420
		[NullableContext(1)]
		private void RefreshRoleAvatar(RogueArchiveInfoData archiveInfoData)
		{
			RoguelikeInfo roguelikeInfo = archiveInfoData.RoguelikeInfo;
			int num = (roguelikeInfo != null) ? roguelikeInfo.RoleEntry.ConfigId : 0;
			if (num <= 0)
			{
				this.SetRoleAvatarActive(false);
				return;
			}
			RoleDataBase roguelikeRoleData = ModelBase<RoguelikeModel>.Instance.GetRoguelikeRoleData(num);
			RoleInfo? roleInfo = (roguelikeRoleData != null) ? new RoleInfo?(roguelikeRoleData.GetRoleConfig()) : null;
			string text = (roleInfo != null) ? roleInfo.GetValueOrDefault().RoleHeadIconCircle : null;
			if (roguelikeRoleData == null || roleInfo == null || string.IsNullOrEmpty(text))
			{
				this.SetRoleAvatarActive(false);
				return;
			}
			int roleSkinId = roguelikeRoleData.GetRoleSkinId();
			this.SetRoleAvatarActive(true);
			base.SetRoleSkinIcon(text, base.GetTexture(4), roleSkinId, null, null);
		}

		// Token: 0x0603582F RID: 219183 RVA: 0x00D6F2DB File Offset: 0x00D6D4DB
		private void SetRoleAvatarActive(bool isActive)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(isActive);
			}
			UUITexture texture = base.GetTexture(4);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(isActive);
		}

		// Token: 0x0401EC09 RID: 125961
		[Nullable(2)]
		private TTempRecordToggleStateChanged OnToggleStateChanged;

		// Token: 0x0200B0CF RID: 45263
		private class EComponents
		{
			// Token: 0x04036D95 RID: 224661
			public const int ToggleItem = 0;

			// Token: 0x04036D96 RID: 224662
			public const int SprStateIcon = 1;

			// Token: 0x04036D97 RID: 224663
			public const int TxtRoleName = 2;

			// Token: 0x04036D98 RID: 224664
			public const int RoleAvatarItem = 3;

			// Token: 0x04036D99 RID: 224665
			public const int TexRole = 4;
		}
	}
}
