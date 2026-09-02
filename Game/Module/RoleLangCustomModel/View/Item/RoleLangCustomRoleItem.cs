using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View.Item
{
	// Token: 0x020050FD RID: 20733
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleLangCustomRoleItem : GridProxyAbstract<RoleInstance>
	{
		// Token: 0x06035729 RID: 218921 RVA: 0x00D6A4EC File Offset: 0x00D686EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603572A RID: 218922 RVA: 0x00D6A5FA File Offset: 0x00D687FA
		protected override void OnStart()
		{
			base.GetExtendToggle(4).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x0603572B RID: 218923 RVA: 0x00D6A61C File Offset: 0x00D6881C
		public override void Refresh(RoleInstance roleData, bool isSelected, int gridIndex)
		{
			int roleId = roleData.GetRoleId();
			this.RoleData = roleData;
			this.RoleId = roleId;
			int roleSkinId = roleData.GetRoleSkinId();
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
			bool uiactive = false;
			using (List<SceneTeamItem>.Enumerator enumerator = teamItems.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetConfigId == roleId)
					{
						uiactive = true;
						break;
					}
				}
			}
			base.GetItem(6).SetUIActive(uiactive);
			base.SetRoleSkinIcon("", base.GetTexture(0), roleSkinId, null, null);
			base.SetRoleSkinIcon("", base.GetTexture(5), roleSkinId, null, null);
			int id = roleData.GetElementInfo().Value.Id;
			base.SetElementIcon("", base.GetTexture(1), id, null);
			FColor color = FColor.FromHex(ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(id).Value.ElementColor);
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetColor(color);
			}
			int roleLangType = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(roleId);
			RoleVoiceLanguage? roleLangCustomConfigById = ConfigBase<MenuBaseConfig>.Instance.GetRoleLangCustomConfigById(roleLangType);
			base.GetText(2).ShowTextNew(roleLangCustomConfigById.Value.Text);
			FavorRoleInfo? favorRoleInfoConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(roleId);
			if (favorRoleInfoConfig == null)
			{
				return;
			}
			string item = "";
			if (roleLangType == 0)
			{
				item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameCn);
			}
			else if (roleLangType == 1)
			{
				item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameEn);
			}
			else if (roleLangType == 2)
			{
				item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameJp);
			}
			else if (roleLangType == 3)
			{
				item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameKo);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Role_VoiceDIY_CV", new <>z__ReadOnlySingleElementList<object>(item));
			if (this.OnToggleSelectedCheck != null)
			{
				this.SetSelected(this.OnToggleSelectedCheck(roleId), false);
			}
		}

		// Token: 0x0603572C RID: 218924 RVA: 0x00D6A864 File Offset: 0x00D68A64
		public void RefreshByData()
		{
			this.Refresh(this.RoleData, true, 0);
		}

		// Token: 0x0603572D RID: 218925 RVA: 0x00D6A874 File Offset: 0x00D68A74
		public void SetSelected(bool isSelected, bool fireEvent = false)
		{
			base.GetExtendToggle(4).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0603572E RID: 218926 RVA: 0x00D6A88D File Offset: 0x00D68A8D
		private void OnToggleStateChanged(EToggleState state)
		{
			if (this.OnToggleStateChangedCallback != null)
			{
				this.OnToggleStateChangedCallback(this.RoleId);
			}
		}

		// Token: 0x0401EB2B RID: 125739
		protected int RoleId;

		// Token: 0x0401EB2C RID: 125740
		protected RoleInstance RoleData;

		// Token: 0x0401EB2D RID: 125741
		[Nullable(2)]
		public Func<int, bool> OnToggleSelectedCheck;

		// Token: 0x0401EB2E RID: 125742
		[Nullable(2)]
		public Action<int> OnToggleStateChangedCallback;

		// Token: 0x0200B09D RID: 45213
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x04036CEC RID: 224492
			TexRole,
			// Token: 0x04036CED RID: 224493
			TexElementIcon,
			// Token: 0x04036CEE RID: 224494
			TxtLanguage,
			// Token: 0x04036CEF RID: 224495
			TxtCVName,
			// Token: 0x04036CF0 RID: 224496
			Toggle,
			// Token: 0x04036CF1 RID: 224497
			TexRoleShadow,
			// Token: 0x04036CF2 RID: 224498
			PanelInTeam
		}
	}
}
