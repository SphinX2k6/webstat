using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.JoinTeam.View
{
	// Token: 0x02005B00 RID: 23296
	[NullableContext(1)]
	[Nullable(0)]
	public class JoinTeamView : UiViewBase
	{
		// Token: 0x0603AE7B RID: 241275 RVA: 0x00EF0112 File Offset: 0x00EEE312
		public JoinTeamView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603AE7C RID: 241276 RVA: 0x00EF011C File Offset: 0x00EEE31C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUINiagara)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickedDetailButton)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnClickedCloseButton))
			};
		}

		// Token: 0x0603AE7D RID: 241277 RVA: 0x00EF0220 File Offset: 0x00EEE420
		private void OnClickedDetailButton()
		{
			RoleModel instance = ModelBase<RoleModel>.Instance;
			int value = ModelBase<JoinTeamModel>.Instance.GetRoleDescriptionId().Value;
			int value2 = ConfigBase<JoinTeamConfig>.Instance.GetRoleConfigId(value).Value;
			RoleDataBase roleDataById = instance.GetRoleDataById(value2, true);
			ControllerBase<JoinTeamController>.Instance.CloseJoinTeamView();
			if (roleDataById != null)
			{
				ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, roleDataById.GetRoleId(), null, null, null);
			}
		}

		// Token: 0x0603AE7E RID: 241278 RVA: 0x00EF028B File Offset: 0x00EEE48B
		private void OnClickedCloseButton()
		{
			ControllerBase<JoinTeamController>.Instance.CloseJoinTeamView();
		}

		// Token: 0x0603AE7F RID: 241279 RVA: 0x00EF0298 File Offset: 0x00EEE498
		protected override void OnStart()
		{
			object openParam = this.OpenParam;
			bool flag;
			bool flag2;
			if (openParam is bool)
			{
				flag = (bool)openParam;
				flag2 = true;
			}
			else
			{
				flag2 = false;
			}
			this.IsTrial = (flag2 && flag);
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(4);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(!this.IsTrial);
				}
			}
			this.RefreshJoinTeamView();
			this.AddEvents();
		}

		// Token: 0x0603AE80 RID: 241280 RVA: 0x00EF0314 File Offset: 0x00EEE514
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvents();
			if (this.MiniElement != null)
			{
				this.MiniElement.Destroy(null);
				this.MiniElement = null;
			}
		}

		// Token: 0x0603AE81 RID: 241281 RVA: 0x00EF0337 File Offset: 0x00EEE537
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshJoinTeamRole, new Action(this.OnRefreshJoinTeamRole));
		}

		// Token: 0x0603AE82 RID: 241282 RVA: 0x00EF0355 File Offset: 0x00EEE555
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshJoinTeamRole, new Action(this.OnRefreshJoinTeamRole));
		}

		// Token: 0x0603AE83 RID: 241283 RVA: 0x00EF0373 File Offset: 0x00EEE573
		private void OnRefreshJoinTeamRole()
		{
			this.RefreshJoinTeamView();
		}

		// Token: 0x0603AE84 RID: 241284 RVA: 0x00EF037C File Offset: 0x00EEE57C
		private void RefreshJoinTeamView()
		{
			int? roleDescriptionId = ModelBase<JoinTeamModel>.Instance.GetRoleDescriptionId();
			if (roleDescriptionId == null)
			{
				return;
			}
			JoinTeamConfig instance = ConfigBase<JoinTeamConfig>.Instance;
			string roleNameId = instance.GetRoleNameId(roleDescriptionId.Value);
			string roleTexturePath = instance.GetRoleTexturePath(roleDescriptionId.Value);
			int value = instance.GetRoleElementId(roleDescriptionId.Value).Value;
			string roleDescriptionId2 = instance.GetRoleDescriptionId(roleDescriptionId.Value);
			this.InitializeMiniElement(value);
			this.SetRoleTexture(roleTexturePath);
			this.SetRoleName(roleNameId);
			this.SetRoleDescription(roleDescriptionId2);
			base.GetUiNiagara(2).ActivateSystem(true);
			this.SetTrial();
		}

		// Token: 0x0603AE85 RID: 241285 RVA: 0x00EF0414 File Offset: 0x00EEE614
		private void InitializeMiniElement(int elementId)
		{
			AActor owner = base.GetItem(5).GetOwner();
			this.MiniElement = new MiniElementItem(elementId, null, owner);
		}

		// Token: 0x0603AE86 RID: 241286 RVA: 0x00EF043C File Offset: 0x00EEE63C
		private void SetRoleName(string roleNameId)
		{
			base.GetText(0).ShowTextNew(roleNameId);
		}

		// Token: 0x0603AE87 RID: 241287 RVA: 0x00EF044C File Offset: 0x00EEE64C
		private void SetRoleTexture(string roleTexturePath)
		{
			base.SetTextureByPath(roleTexturePath, base.GetTexture(1), null, delegate(bool success)
			{
				if (success)
				{
					UUITexture texture = base.GetTexture(1);
					if (texture == null)
					{
						return;
					}
					texture.SetUIActive(true);
				}
			});
		}

		// Token: 0x0603AE88 RID: 241288 RVA: 0x00EF047C File Offset: 0x00EEE67C
		private void SetRoleDescription(string descriptionId)
		{
			base.GetText(3).ShowTextNew(descriptionId);
		}

		// Token: 0x0603AE89 RID: 241289 RVA: 0x00EF048B File Offset: 0x00EEE68B
		private void SetTrial()
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.IsTrial);
		}

		// Token: 0x04021441 RID: 136257
		[Nullable(2)]
		private MiniElementItem MiniElement;

		// Token: 0x04021442 RID: 136258
		private bool IsTrial;

		// Token: 0x0200BB20 RID: 47904
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039C0F RID: 236559
			public const int RoleName = 0;

			// Token: 0x04039C10 RID: 236560
			public const int RoleTexture = 1;

			// Token: 0x04039C11 RID: 236561
			public const int RoleEffect = 2;

			// Token: 0x04039C12 RID: 236562
			public const int RoleDescriptionText = 3;

			// Token: 0x04039C13 RID: 236563
			public const int DetailButton = 4;

			// Token: 0x04039C14 RID: 236564
			public const int MiniElementItem = 5;

			// Token: 0x04039C15 RID: 236565
			public const int CloseButton = 6;

			// Token: 0x04039C16 RID: 236566
			public const int TrialPanel = 7;
		}
	}
}
