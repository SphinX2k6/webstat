using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.RoleUi;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.RoleSelect
{
	// Token: 0x02005A87 RID: 23175
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoRoleGridItem : LoopScrollMediumItemGrid<int>
	{
		// Token: 0x0603AA2F RID: 240175 RVA: 0x00EDAE6B File Offset: 0x00ED906B
		protected override void OnStart()
		{
			this.GetItemGridExtendToggle().bLockStateOnSelect = true;
		}

		// Token: 0x0603AA30 RID: 240176 RVA: 0x00EDAE7C File Offset: 0x00ED907C
		protected override void OnRefresh(int data, bool isSelected, int gridIndex)
		{
			this.RoleId = data;
			KurotatoRoleData kurotatoRoleData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoRoleData(data);
			int realRoleId = kurotatoRoleData.RealRoleId;
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(realRoleId);
			this.IsDisableInternal = (!kurotatoRoleData.IsUnLock || (this.LimitRoleList.Count > 0 && !this.LimitRoleList.Contains(data)));
			bool flag = this.IsHandBookContext ? kurotatoRoleData.HasHandBookRedDot : kurotatoRoleData.HasRoleSelectRedDot;
			bool flag2 = !this.IsDisableInternal && kurotatoRoleData.NeedPlayUnlockAnim;
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				Data = roleConfig,
				ItemConfigId = new int?(realRoleId),
				SkinId = kurotatoRoleData.RealRoleSkinId,
				BottomTextId = kurotatoRoleData.Name,
				IsShowLock = new bool?(!kurotatoRoleData.IsUnLock),
				IsDisable = new bool?(this.IsDisableInternal),
				IsRecommendVisible = new bool?(this.RecommendRoleList.Contains(realRoleId)),
				IsShowArchive = new bool?(this.IsEndlessLevel && kurotatoRoleData.HasArchived),
				IsNewVisible = new bool?(!this.IsDisableInternal && flag)
			};
			base.SetUseFixedAsync(true);
			base.Apply<CharacterMediumItemGrid>(parameters);
			if (flag2)
			{
				base.SetIsProhibit(new bool?(true));
				MediumItemGridProhibitComponent itemGridComponent = base.GetItemGridComponent<MediumItemGridProhibitComponent>(typeof(MediumItemGridProhibitComponent));
				if (itemGridComponent != null)
				{
					itemGridComponent.PlayUnlockAnim().Forget();
				}
				kurotatoRoleData.MarkUnlockAnimPlayed();
				return;
			}
			base.SetIsProhibit(new bool?(false));
		}

		// Token: 0x0603AA31 RID: 240177 RVA: 0x00EDB002 File Offset: 0x00ED9202
		public void SetToggleClickCallback(Action<int> callback)
		{
			this.ToggleClickCallback = callback;
		}

		// Token: 0x0603AA32 RID: 240178 RVA: 0x00EDB00B File Offset: 0x00ED920B
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> toggleClickCallback = this.ToggleClickCallback;
				if (toggleClickCallback == null)
				{
					return;
				}
				toggleClickCallback(this.RoleId);
			}
		}

		// Token: 0x0603AA33 RID: 240179 RVA: 0x00EDB027 File Offset: 0x00ED9227
		protected override void OnExtendToggleClicked()
		{
			this.ReadRedDot();
			if (this.IsSelected)
			{
				return;
			}
			Action<int> toggleClickCallback = this.ToggleClickCallback;
			if (toggleClickCallback == null)
			{
				return;
			}
			toggleClickCallback(this.RoleId);
		}

		// Token: 0x0603AA34 RID: 240180 RVA: 0x00EDB04E File Offset: 0x00ED924E
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, true);
			this.ReadRedDot();
		}

		// Token: 0x0603AA35 RID: 240181 RVA: 0x00EDB05E File Offset: 0x00ED925E
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, true);
		}

		// Token: 0x0603AA36 RID: 240182 RVA: 0x00EDB068 File Offset: 0x00ED9268
		private void ReadRedDot()
		{
			if (this.IsDisableInternal)
			{
				return;
			}
			KurotatoRoleData kurotatoRoleData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoRoleData(this.RoleId);
			if (this.IsHandBookContext && kurotatoRoleData.HasHandBookRedDot)
			{
				kurotatoRoleData.ReadHandBookRedDot(true);
				base.SetNewVisible(new bool?(false));
				return;
			}
			if (!this.IsHandBookContext && kurotatoRoleData.HasRoleSelectRedDot)
			{
				kurotatoRoleData.ReadRoleSelectRedDot();
				base.SetNewVisible(new bool?(false));
			}
		}

		// Token: 0x040212A6 RID: 135846
		private int RoleId;

		// Token: 0x040212A7 RID: 135847
		public List<int> LimitRoleList = new List<int>();

		// Token: 0x040212A8 RID: 135848
		public List<int> RecommendRoleList = new List<int>();

		// Token: 0x040212A9 RID: 135849
		public bool IsEndlessLevel;

		// Token: 0x040212AA RID: 135850
		public bool IsHandBookContext;

		// Token: 0x040212AB RID: 135851
		private bool IsDisableInternal;

		// Token: 0x040212AC RID: 135852
		[Nullable(2)]
		private Action<int> ToggleClickCallback;
	}
}
