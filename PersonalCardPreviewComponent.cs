using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002424 RID: 9252
public class PersonalCardPreviewComponent : UiPanelBase, IItemTipsUiProxy
{
	// Token: 0x06011E56 RID: 73302 RVA: 0x004EC0E4 File Offset: 0x004EA2E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
	}

	// Token: 0x06011E57 RID: 73303 RVA: 0x004EC1C2 File Offset: 0x004EA3C2
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06011E58 RID: 73304 RVA: 0x004EC1D5 File Offset: 0x004EA3D5
	protected override void OnBeforeShow()
	{
		this.PlayStartSequence();
	}

	// Token: 0x06011E59 RID: 73305 RVA: 0x004EC1E0 File Offset: 0x004EA3E0
	private void PlayStartSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x06011E5A RID: 73306 RVA: 0x004EC210 File Offset: 0x004EA410
	public UniTask PlayCloseSequence()
	{
		PersonalCardPreviewComponent.<PlayCloseSequence>d__7 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<PersonalCardPreviewComponent.<PlayCloseSequence>d__7>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06011E5B RID: 73307 RVA: 0x004EC254 File Offset: 0x004EA454
	[NullableContext(1)]
	public void Refresh(ItemTipsData data)
	{
		this.CurrentData = (data as TipsCardData);
		BackgroundCard? cardItemConfig = ConfigBase<InventoryConfig>.Instance.GetCardItemConfig(this.CurrentData.ConfigId);
		if (cardItemConfig == null)
		{
			return;
		}
		base.GetText(3).ShowTextNew(cardItemConfig.Value.Title);
		base.GetText(1).ShowTextNew(cardItemConfig.Value.AttributesDescription);
		base.GetText(2).ShowTextNew(cardItemConfig.Value.Tips);
		base.SetTextureShowUntilLoaded(cardItemConfig.Value.CardPath, base.GetTexture(0), null);
		base.SetTextureShowUntilLoaded(cardItemConfig.Value.FunctionViewCardPath, base.GetTexture(4), null);
		base.SetTextureShowUntilLoaded(cardItemConfig.Value.LongCardPath, base.GetTexture(7), null);
		int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		if (numberPropById == null)
		{
			return;
		}
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(numberPropById.Value, true);
		if (playerHeadData == null)
		{
			return;
		}
		UUITexture roleHeadTexture = base.GetTexture(5);
		roleHeadTexture.SetUIActive(false);
		base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), roleHeadTexture, delegate(bool _)
		{
			roleHeadTexture.SetUIActive(true);
		});
		UUITexture roleFriendHeadTexture = base.GetTexture(6);
		roleFriendHeadTexture.SetUIActive(false);
		base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), roleFriendHeadTexture, delegate(bool _)
		{
			roleFriendHeadTexture.SetUIActive(true);
		});
		base.GetText(8).SetText(ModelBase<FunctionModel>.Instance.GetPlayerName(), true);
	}

	// Token: 0x06011E5C RID: 73308 RVA: 0x004EC3F3 File Offset: 0x004EA5F3
	public override void SetActive(bool visibility)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(visibility);
	}

	// Token: 0x04008C18 RID: 35864
	[Nullable(2)]
	private TipsCardData CurrentData;

	// Token: 0x04008C19 RID: 35865
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0200875E RID: 34654
	private enum EComponent
	{
		// Token: 0x0402DC59 RID: 187481
		CardTexture,
		// Token: 0x0402DC5A RID: 187482
		CardDescText,
		// Token: 0x0402DC5B RID: 187483
		CardTipsText,
		// Token: 0x0402DC5C RID: 187484
		CardName,
		// Token: 0x0402DC5D RID: 187485
		RoleHeadCardTexture,
		// Token: 0x0402DC5E RID: 187486
		RoleHeadTexture,
		// Token: 0x0402DC5F RID: 187487
		RoleFriendHeadTexture,
		// Token: 0x0402DC60 RID: 187488
		LongCardTexture,
		// Token: 0x0402DC61 RID: 187489
		PlayerNameText
	}
}
