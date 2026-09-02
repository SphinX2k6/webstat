using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020019FE RID: 6654
public class PlayerHeadItem : UiPanelBase
{
	// Token: 0x0600BE6D RID: 48749 RVA: 0x00326636 File Offset: 0x00324836
	[NullableContext(1)]
	public PlayerHeadItem(AActor rootActor)
	{
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600BE6E RID: 48750 RVA: 0x00326648 File Offset: 0x00324848
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BE6F RID: 48751 RVA: 0x00326690 File Offset: 0x00324890
	public void RefreshByPlayerId(int playerId, bool useCard = false)
	{
		this.RefreshPlayerTexture(playerId, useCard);
	}

	// Token: 0x0600BE70 RID: 48752 RVA: 0x0032669C File Offset: 0x0032489C
	private void RefreshPlayerTexture(int playerId, bool useCard = false)
	{
		PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
		UUITexture texture = base.GetTexture(0);
		int? id = instance.GetId();
		if (id.GetValueOrDefault() == playerId & id != null)
		{
			if (useCard)
			{
				int headIconId = ModelBase<PlayerInfoModel>.Instance.GetHeadIconId();
				this.RefreshByRoleIdUseCard(headIconId);
				return;
			}
			string playerHeadIconBig = ModelBase<PlayerInfoModel>.Instance.GetPlayerHeadIconBig();
			if (!StringUtils.IsEmpty(playerHeadIconBig))
			{
				base.SetTextureByPath(playerHeadIconBig, texture, null, null);
			}
			return;
		}
		else
		{
			FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(playerId);
			if (friendById == null)
			{
				return;
			}
			int playerHeadPhoto = friendById.PlayerHeadPhoto;
			if (useCard)
			{
				this.RefreshByRoleIdUseCard(playerHeadPhoto);
				return;
			}
			this.RefreshByHeadPhotoId(playerHeadPhoto);
			return;
		}
	}

	// Token: 0x0600BE71 RID: 48753 RVA: 0x0032673F File Offset: 0x0032493F
	public void RefreshByHeadPhotoId(int headPhotoId)
	{
		this.RefreshByRoleId(headPhotoId);
	}

	// Token: 0x0600BE72 RID: 48754 RVA: 0x00326748 File Offset: 0x00324948
	public void RefreshByRoleId(int headPhotoId)
	{
		UUITexture roleTexture = base.GetTexture(0);
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(headPhotoId, false);
		if (playerHeadData != null)
		{
			roleTexture.SetUIActive(false);
			base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), roleTexture, delegate(bool _)
			{
				roleTexture.SetUIActive(true);
			});
			return;
		}
		if (headPhotoId > 0)
		{
			string roleHeadIcon = ConfigBase<RoleConfig>.Instance.GetRoleHeadIcon(headPhotoId, false);
			base.SetRoleIcon(roleHeadIcon, roleTexture, headPhotoId, null, null);
		}
	}

	// Token: 0x0600BE73 RID: 48755 RVA: 0x003267CC File Offset: 0x003249CC
	public void RefreshByRoleIdUseCard(int headPhotoId)
	{
		UUITexture roleTexture = base.GetTexture(0);
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(headPhotoId, false);
		if (playerHeadData != null)
		{
			roleTexture.SetUIActive(false);
			base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), roleTexture, delegate(bool _)
			{
				roleTexture.SetUIActive(true);
			});
			return;
		}
		string card = ConfigBase<RoleConfig>.Instance.GetRoleConfig(headPhotoId).Value.Card;
		base.SetRoleIcon(card, roleTexture, headPhotoId, null, null);
	}

	// Token: 0x0600BE74 RID: 48756 RVA: 0x0032685D File Offset: 0x00324A5D
	public void SetIsGray(bool isGray)
	{
		base.GetTexture(0).SetIsGray(isGray);
	}

	// Token: 0x02007CE6 RID: 31974
	private class EChildType
	{
		// Token: 0x0402A9BD RID: 174525
		public const int RoleTexture = 0;
	}
}
