using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200638B RID: 25483
	[NullableContext(1)]
	[Nullable(0)]
	public class AbyssDangoRolePanel : SolarSpeedRolePanelBase
	{
		// Token: 0x0603FFE5 RID: 262117 RVA: 0x01066BAC File Offset: 0x01064DAC
		private UniTask InitDescContent()
		{
			AbyssDangoRolePanel.<InitDescContent>d__4 <InitDescContent>d__;
			<InitDescContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDescContent>d__.<>4__this = this;
			<InitDescContent>d__.<>1__state = -1;
			<InitDescContent>d__.<>t__builder.Start<AbyssDangoRolePanel.<InitDescContent>d__4>(ref <InitDescContent>d__);
			return <InitDescContent>d__.<>t__builder.Task;
		}

		// Token: 0x0603FFE6 RID: 262118 RVA: 0x01066BEF File Offset: 0x01064DEF
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAbyssLikeChange, new Action<int>(this.OnAbyssLikeChange));
		}

		// Token: 0x0603FFE7 RID: 262119 RVA: 0x01066C0D File Offset: 0x01064E0D
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssLikeChange, new Action<int>(this.OnAbyssLikeChange));
		}

		// Token: 0x0603FFE8 RID: 262120 RVA: 0x01066C2C File Offset: 0x01064E2C
		private void OnAbyssLikeChange(int playerId)
		{
			int? currentPlayerId = this.CurrentPlayerId;
			if (currentPlayerId.GetValueOrDefault() == playerId & currentPlayerId != null)
			{
				int playerLikeCount = ModelBase<DangoAbyssModel>.Instance.GetPlayerLikeCount(playerId);
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				bool playerIfLikePlayer = ModelBase<DangoAbyssModel>.Instance.GetPlayerIfLikePlayer(id.Value, playerId);
				this.LikeItem.Refresh(playerLikeCount, playerId, playerIfLikePlayer);
			}
		}

		// Token: 0x0603FFE9 RID: 262121 RVA: 0x01066C90 File Offset: 0x01064E90
		protected override UniTask OnBeforeStartAsync()
		{
			AbyssDangoRolePanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AbyssDangoRolePanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FFEA RID: 262122 RVA: 0x01066CD3 File Offset: 0x01064ED3
		protected override void OnStart()
		{
			this.AddEventListener();
		}

		// Token: 0x0603FFEB RID: 262123 RVA: 0x01066CDB File Offset: 0x01064EDB
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0603FFEC RID: 262124 RVA: 0x01066CE4 File Offset: 0x01064EE4
		private void RefreshAvatarTexture(IAbyssRolePanelData data)
		{
			string path = ConfigBase<UiResourceConfig>.Instance.GetResourceConfig(data.AvatarTexturePath).Value.Path;
			base.SetTextureByPath(path, base.GetTexture(14), null, null);
		}

		// Token: 0x0603FFED RID: 262125 RVA: 0x01066D2C File Offset: 0x01064F2C
		private void RefreshLineTexture(IAbyssRolePanelData data)
		{
			string path = ConfigBase<UiResourceConfig>.Instance.GetResourceConfig(data.LineTexturePath).Value.Path;
			base.SetTextureByPath(path, base.GetTexture(15), null, null);
		}

		// Token: 0x0603FFEE RID: 262126 RVA: 0x01066D74 File Offset: 0x01064F74
		private void RefreshPlayerTitle(IAbyssRolePanelData data)
		{
			if (data.PlayerTitle != null)
			{
				int? playerTitle = data.PlayerTitle;
				int num = 0;
				if (playerTitle.GetValueOrDefault() > num & playerTitle != null)
				{
					base.GetItem(16).SetUIActive(true);
				}
			}
			this.PlayerTitleItem.Refresh(data.PlayerTitle, data.PlayerTitleStarLevel, new int?(data.Sex));
		}

		// Token: 0x0603FFEF RID: 262127 RVA: 0x01066DE0 File Offset: 0x01064FE0
		private void RefreshBgTexture(IAbyssRolePanelData data)
		{
			string path = ConfigBase<UiResourceConfig>.Instance.GetResourceConfig(data.BgTexturePath).Value.Path;
			base.SetTextureByPath(path, base.GetTexture(1), null, null);
		}

		// Token: 0x0603FFF0 RID: 262128 RVA: 0x01066E28 File Offset: 0x01065028
		protected override void OnRefresh(ISolarSpeedRolePanelData baseData)
		{
			IAbyssRolePanelData abyssRolePanelData = (IAbyssRolePanelData)baseData;
			this.CurrentPlayerId = new int?(abyssRolePanelData.PlayerId);
			this.DescContent.Refresh(abyssRolePanelData);
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			bool playerIfLikePlayer = ModelBase<DangoAbyssModel>.Instance.GetPlayerIfLikePlayer(id.Value, abyssRolePanelData.PlayerId);
			this.LikeItem.Refresh(abyssRolePanelData.LikeCount, abyssRolePanelData.PlayerId, playerIfLikePlayer);
			this.LikeItem.RefreshLineState(!abyssRolePanelData.IsSelf);
			this.LikeItem.SetActive(true);
			this.RefreshPlayerTitle(abyssRolePanelData);
			this.RefreshAvatarTexture(abyssRolePanelData);
			this.RefreshLineTexture(abyssRolePanelData);
			this.RefreshBgTexture(abyssRolePanelData);
			base.SetFriendItemState(!abyssRolePanelData.IsSelf);
		}

		// Token: 0x04023EF7 RID: 147191
		private AbyssDangoDescContent DescContent;

		// Token: 0x04023EF8 RID: 147192
		private AbyssDangoLikeItem LikeItem;

		// Token: 0x04023EF9 RID: 147193
		private int? CurrentPlayerId;

		// Token: 0x04023EFA RID: 147194
		[Nullable(2)]
		private PlayerTitleItem PlayerTitleItem;
	}
}
