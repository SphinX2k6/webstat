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

// Token: 0x02002435 RID: 9269
[NullableContext(2)]
[Nullable(0)]
public class PersonalPlayerTitlePreviewComponent : UiPanelBase, IItemTipsUiProxy
{
	// Token: 0x06011ED8 RID: 73432 RVA: 0x004EEB44 File Offset: 0x004ECD44
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x06011ED9 RID: 73433 RVA: 0x004EEC68 File Offset: 0x004ECE68
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalPlayerTitlePreviewComponent.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalPlayerTitlePreviewComponent.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011EDA RID: 73434 RVA: 0x004EECAB File Offset: 0x004ECEAB
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06011EDB RID: 73435 RVA: 0x004EECBE File Offset: 0x004ECEBE
	protected override void OnBeforeShow()
	{
		this.PlayStartSequence();
	}

	// Token: 0x06011EDC RID: 73436 RVA: 0x004EECC8 File Offset: 0x004ECEC8
	private void PlayStartSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x06011EDD RID: 73437 RVA: 0x004EECF8 File Offset: 0x004ECEF8
	public UniTask PlayCloseSequence()
	{
		PersonalPlayerTitlePreviewComponent.<PlayCloseSequence>d__10 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<PersonalPlayerTitlePreviewComponent.<PlayCloseSequence>d__10>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06011EDE RID: 73438 RVA: 0x004EED3C File Offset: 0x004ECF3C
	public void Refresh(int titleId)
	{
		PlayerTitle? playerTitleItemConfig = ConfigBase<InventoryConfig>.Instance.GetPlayerTitleItemConfig(titleId);
		int curCardId = ModelBase<PersonalModel>.Instance.GetCurCardId();
		BackgroundCard? cardItemConfig = ConfigBase<InventoryConfig>.Instance.GetCardItemConfig(curCardId);
		int value = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto).Value;
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(value, true);
		base.GetText(0).ShowTextNew(playerTitleItemConfig.Value.Description);
		if (playerTitleItemConfig.Value.IsShowProgress)
		{
			PersonalPlayerTitleData playerTitleData = ModelBase<PersonalModel>.Instance.GetPlayerTitleData(playerTitleItemConfig.Value.Id);
			int? num = (playerTitleData != null) ? playerTitleData.CurProgress : null;
			PersonalPlayerTitleData playerTitleData2 = ModelBase<PersonalModel>.Instance.GetPlayerTitleData(playerTitleItemConfig.Value.Id);
			int? num2 = (playerTitleData2 != null) ? playerTitleData2.TargetProgress : null;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), playerTitleItemConfig.Value.ItemAccess, new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
		}
		else
		{
			base.GetText(1).ShowTextNew(playerTitleItemConfig.Value.ItemAccess);
		}
		base.GetText(2).ShowTextNew(playerTitleItemConfig.Value.TitleName);
		base.GetText(7).SetText(ModelBase<FunctionModel>.Instance.GetPlayerName(), true);
		base.GetText(9).SetText(ModelBase<FunctionModel>.Instance.GetPlayerName(), true);
		base.SetTextureShowUntilLoaded(cardItemConfig.Value.FunctionViewCardPath, base.GetTexture(3), null);
		base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(4), null);
		base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(5), null);
		base.SetTextureShowUntilLoaded(cardItemConfig.Value.LongCardPath, base.GetTexture(6), null);
		this.RefreshPlayerTitle(playerTitleItemConfig.Value);
	}

	// Token: 0x06011EDF RID: 73439 RVA: 0x004EEF40 File Offset: 0x004ED140
	private void RefreshPlayerTitle(PlayerTitle titleConfig)
	{
		PlayerTitleItem itemTitleInMid = this.ItemTitleInMid;
		if (itemTitleInMid != null)
		{
			itemTitleInMid.Refresh(new int?(titleConfig.Id), new int?(ModelBase<PersonalModel>.Instance.GetPlayerTitleStarLevel(titleConfig.Id)), new int?(ModelBase<PersonalModel>.Instance.GetSex()));
		}
		PlayerTitleItem itemTitleInRight = this.ItemTitleInRight;
		if (itemTitleInRight != null)
		{
			itemTitleInRight.Refresh(new int?(titleConfig.Id), new int?(ModelBase<PersonalModel>.Instance.GetPlayerTitleStarLevel(titleConfig.Id)), new int?(ModelBase<PersonalModel>.Instance.GetSex()));
		}
		PlayerTitleItem itemTitleInList = this.ItemTitleInList;
		if (itemTitleInList == null)
		{
			return;
		}
		itemTitleInList.Refresh(new int?(titleConfig.Id), new int?(ModelBase<PersonalModel>.Instance.GetPlayerTitleStarLevel(titleConfig.Id)), new int?(ModelBase<PersonalModel>.Instance.GetSex()));
	}

	// Token: 0x04008C75 RID: 35957
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04008C76 RID: 35958
	private PlayerTitleItem ItemTitleInMid;

	// Token: 0x04008C77 RID: 35959
	private PlayerTitleItem ItemTitleInRight;

	// Token: 0x04008C78 RID: 35960
	private PlayerTitleItem ItemTitleInList;

	// Token: 0x02008770 RID: 34672
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DCAA RID: 187562
		TxtDesc,
		// Token: 0x0402DCAB RID: 187563
		TxtGetWay,
		// Token: 0x0402DCAC RID: 187564
		TxtTitleName,
		// Token: 0x0402DCAD RID: 187565
		TexCard,
		// Token: 0x0402DCAE RID: 187566
		TexRole,
		// Token: 0x0402DCAF RID: 187567
		TexRoleInList,
		// Token: 0x0402DCB0 RID: 187568
		TexCardInList,
		// Token: 0x0402DCB1 RID: 187569
		TxtPlayerNameInList,
		// Token: 0x0402DCB2 RID: 187570
		ItemTitleInMid,
		// Token: 0x0402DCB3 RID: 187571
		TxtPlayerNameInMid,
		// Token: 0x0402DCB4 RID: 187572
		ItemTitleInRight,
		// Token: 0x0402DCB5 RID: 187573
		ItemTitleInList
	}
}
