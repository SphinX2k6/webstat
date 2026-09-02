using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D73 RID: 23923
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeRoleMediumGridItem : GridProxyAbstract<RoleDataBase>
	{
		// Token: 0x0603C42C RID: 246828 RVA: 0x00F49E7D File Offset: 0x00F4807D
		public void SetCanSelectRole(Func<int, EToggleState, bool> callback)
		{
			this.CanSelectRole = callback;
		}

		// Token: 0x0603C42D RID: 246829 RVA: 0x00F49E86 File Offset: 0x00F48086
		public void SetOnSelectRole(Action<int, EToggleState> callback)
		{
			this.OnSelectRole = callback;
		}

		// Token: 0x0603C42E RID: 246830 RVA: 0x00F49E90 File Offset: 0x00F48090
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeRoleMediumGridItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeRoleMediumGridItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C42F RID: 246831 RVA: 0x00F49ED3 File Offset: 0x00F480D3
		public override void Refresh(RoleDataBase data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshView(data);
		}

		// Token: 0x0603C430 RID: 246832 RVA: 0x00F49EE4 File Offset: 0x00F480E4
		private void RefreshView(RoleDataBase data)
		{
			int dataId = data.GetDataId();
			RoleInfo roleConfig = data.GetRoleConfig();
			int roleSkinId = data.GetRoleSkinId();
			int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId);
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				ItemConfigId = new int?(dataId),
				SkinId = roleSkinId,
				Index = new int?((roleIndex > 0) ? roleIndex : 0),
				ElementId = new int?(roleConfig.ElementId),
				Data = data,
				IsTrialRoleVisible = new bool?(data.IsTrialRole()),
				BottomTextId = "Text_LevelShow_Text",
				BottomTextParameter = new object[]
				{
					data.GetLevelData().GetLevel()
				}
			};
			this.MediumItemGrid.Apply<CharacterMediumItemGrid>(parameters);
			bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
			this.MediumItemGrid.SetSelected(bSelected, true);
		}

		// Token: 0x0603C431 RID: 246833 RVA: 0x00F49FCC File Offset: 0x00F481CC
		[NullableContext(2)]
		private bool OnCanExecuteChangeEvent(object data, bool isForceSelected, EToggleState state)
		{
			Func<int, EToggleState, bool> canSelectRole = this.CanSelectRole;
			return canSelectRole == null || canSelectRole((data as RoleDataBase).GetDataId(), state);
		}

		// Token: 0x0603C432 RID: 246834 RVA: 0x00F49FEB File Offset: 0x00F481EB
		private void OnClickEvent(MediumItemGridExtendCallback callback)
		{
			Action<int, EToggleState> onSelectRole = this.OnSelectRole;
			if (onSelectRole == null)
			{
				return;
			}
			onSelectRole(this.Data.GetDataId(), callback.State);
		}

		// Token: 0x04021E0B RID: 138763
		[Nullable(2)]
		private RoleDataBase Data;

		// Token: 0x04021E0C RID: 138764
		[Nullable(2)]
		private MediumItemGrid MediumItemGrid;

		// Token: 0x04021E0D RID: 138765
		[Nullable(2)]
		private Func<int, EToggleState, bool> CanSelectRole;

		// Token: 0x04021E0E RID: 138766
		[Nullable(2)]
		private Action<int, EToggleState> OnSelectRole;
	}
}
