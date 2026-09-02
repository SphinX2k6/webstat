using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D2A RID: 7466
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleArrowBattleProgressItem : UiPanelBase
{
	// Token: 0x0600DBD7 RID: 56279 RVA: 0x003B1414 File Offset: 0x003AF614
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture))
		};
	}

	// Token: 0x0600DBD8 RID: 56280 RVA: 0x003B149C File Offset: 0x003AF69C
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleArrowBattleProgressItem.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleArrowBattleProgressItem.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBD9 RID: 56281 RVA: 0x003B14DF File Offset: 0x003AF6DF
	protected override void OnBeforeDestroy()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x0600DBDA RID: 56282 RVA: 0x003B14E8 File Offset: 0x003AF6E8
	protected override void OnBeforeShow()
	{
		this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		this.RefreshBossIcon();
		this.StartShowHeadItem();
	}

	// Token: 0x0600DBDB RID: 56283 RVA: 0x003B151E File Offset: 0x003AF71E
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorArrowSubLevelNotify, new Action<int, bool>(this.Refresh));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorArrowBossStateChange, new Action<int, EBossState>(this.RefreshBattleState));
	}

	// Token: 0x0600DBDC RID: 56284 RVA: 0x003B1558 File Offset: 0x003AF758
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorArrowSubLevelNotify, new Action<int, bool>(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorArrowBossStateChange, new Action<int, EBossState>(this.RefreshBattleState));
	}

	// Token: 0x0600DBDD RID: 56285 RVA: 0x003B1594 File Offset: 0x003AF794
	public void InitPlayerHead()
	{
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(playerId);
		int? num;
		if (teamPlayerData == null)
		{
			num = null;
		}
		else
		{
			SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
			if (currentGroup == null)
			{
				num = null;
			}
			else
			{
				SceneTeamRole currentRole = currentGroup.GetCurrentRole();
				num = ((currentRole != null) ? new int?(currentRole.RoleId) : null);
			}
		}
		int? num2 = num;
		if (num2 == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.CommonGameMainView, ELogAuthor.TZQ, "[摩托战斗]获取不到当前角色id", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num2.Value);
		if (roleConfig == null)
		{
			return;
		}
		string roleHeadIconCircle = roleConfig.Value.RoleHeadIconCircle;
		base.SetTextureShowUntilLoaded(roleHeadIconCircle, base.GetTexture(4), null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), roleConfig.Value.Name, Array.Empty<object>());
	}

	// Token: 0x0600DBDE RID: 56286 RVA: 0x003B1688 File Offset: 0x003AF888
	public UniTask InitBossHeadItem()
	{
		MotorcycleArrowBattleProgressItem.<InitBossHeadItem>d__26 <InitBossHeadItem>d__;
		<InitBossHeadItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBossHeadItem>d__.<>1__state = -1;
		<InitBossHeadItem>d__.<>t__builder.Start<MotorcycleArrowBattleProgressItem.<InitBossHeadItem>d__26>(ref <InitBossHeadItem>d__);
		return <InitBossHeadItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBDF RID: 56287 RVA: 0x003B16C4 File Offset: 0x003AF8C4
	private UniTask CreateBossItem(float curOffsetY)
	{
		MotorcycleArrowBattleProgressItem.<CreateBossItem>d__27 <CreateBossItem>d__;
		<CreateBossItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateBossItem>d__.<>4__this = this;
		<CreateBossItem>d__.curOffsetY = curOffsetY;
		<CreateBossItem>d__.<>1__state = -1;
		<CreateBossItem>d__.<>t__builder.Start<MotorcycleArrowBattleProgressItem.<CreateBossItem>d__27>(ref <CreateBossItem>d__);
		return <CreateBossItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBE0 RID: 56288 RVA: 0x003B1710 File Offset: 0x003AF910
	public void Refresh(int subLevelIndex, bool isInBossBattle)
	{
		int num = subLevelIndex / 5 * 5;
		if (this.IsForeverLevel && this.CurStartSubLevelIndex != num)
		{
			this.CurStartSubLevelIndex = num;
			this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
			this.RefreshBossIcon();
		}
		int num2 = subLevelIndex - this.CurStartSubLevelIndex;
		for (int i = 0; i < this.HeadItemList.Count; i++)
		{
			MotorcycleBossHeadItem motorcycleBossHeadItem = this.HeadItemList[i];
			if (i < num2)
			{
				motorcycleBossHeadItem.SetBossState(EBossState.Finish, false);
			}
			else if (i == num2)
			{
				motorcycleBossHeadItem.SetBossState(isInBossBattle ? EBossState.Battle : EBossState.WaitStart, false);
			}
			else
			{
				motorcycleBossHeadItem.SetBossState(EBossState.WaitStart, false);
			}
		}
	}

	// Token: 0x0600DBE1 RID: 56289 RVA: 0x003B17B8 File Offset: 0x003AF9B8
	public void RefreshBattleState(int subLevelIndex, EBossState bossState)
	{
		MotorcycleBossHeadItem motorcycleBossHeadItem = this.HeadItemList[subLevelIndex];
		if (motorcycleBossHeadItem == null)
		{
			return;
		}
		motorcycleBossHeadItem.SetBossState(bossState, false);
	}

	// Token: 0x0600DBE2 RID: 56290 RVA: 0x003B17D2 File Offset: 0x003AF9D2
	public void OnTick(float delta)
	{
		this.UpdatePlayerHeadPos();
		if (this.NextShowHeadTime > 0f && this.NextShowHeadTime <= (float)Singleton<Time>.Instance.Now)
		{
			this.ShowNextHeadItem();
		}
	}

	// Token: 0x0600DBE3 RID: 56291 RVA: 0x003B1800 File Offset: 0x003AFA00
	public void UpdatePlayerHeadPos()
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		if (motorcycleArrowSubModel == null)
		{
			return;
		}
		int num = motorcycleArrowSubModel.SubLevelIndex - this.CurStartSubLevelIndex;
		float num2 = 0f;
		if (motorcycleArrowSubModel.EndDistance > 0)
		{
			UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			float? num3;
			if (kscWorld == null)
			{
				num3 = null;
			}
			else
			{
				UKSC_SceneMovement sceneMovement = kscWorld.SceneMovement;
				num3 = ((sceneMovement != null) ? new float?(sceneMovement.MoveDistance) : null);
			}
			float? num4 = num3;
			float valueOrDefault = num4.GetValueOrDefault();
			num2 = Singleton<MathUtils>.Instance.Clamp(valueOrDefault / (float)motorcycleArrowSubModel.EndDistance, 0f, 1f);
		}
		float anchorOffsetY = (float)(-(float)this.BarLength) / 2f + ((float)num + num2) * (float)this.SubBarLength + this.PlayerHeadPosOffset;
		UUIItem playerHead = this.PlayerHead;
		if (playerHead != null)
		{
			playerHead.SetAnchorOffsetY(anchorOffsetY);
		}
		if (this.SubBarCount > 0)
		{
			float fillAmount = ((float)num + num2) / (float)this.SubBarCount;
			UUISprite distancePressBar = this.DistancePressBar;
			if (distancePressBar == null)
			{
				return;
			}
			distancePressBar.SetFillAmount(fillAmount);
		}
	}

	// Token: 0x0600DBE4 RID: 56292 RVA: 0x003B1900 File Offset: 0x003AFB00
	private void StartShowHeadItem()
	{
		if (this.HeadItemList.Count > 1)
		{
			this.ShowHeadItemInterval = 500f / (float)(this.HeadItemList.Count - 1);
			this.NextShowHeadTime = (float)Singleton<Time>.Instance.Now + this.ShowHeadItemInterval;
		}
		else
		{
			this.ShowHeadItemInterval = 0f;
			this.NextShowHeadTime = 0f;
		}
		this.ShowHeadItemIndex = this.HeadItemList.Count;
		this.ShowNextHeadItem();
	}

	// Token: 0x0600DBE5 RID: 56293 RVA: 0x003B197C File Offset: 0x003AFB7C
	private void ShowNextHeadItem()
	{
		this.ShowHeadItemIndex--;
		if (this.ShowHeadItemIndex >= this.HeadItemList.Count || this.ShowHeadItemIndex < 0)
		{
			this.NextShowHeadTime = -1f;
			return;
		}
		this.NextShowHeadTime = (float)Singleton<Time>.Instance.Now + this.ShowHeadItemInterval;
		this.HeadItemList[this.ShowHeadItemIndex].ShowAsync().Forget<bool>();
	}

	// Token: 0x0600DBE6 RID: 56294 RVA: 0x003B19F4 File Offset: 0x003AFBF4
	private void RefreshBossIcon()
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		if (motorcycleArrowSubModel == null)
		{
			return;
		}
		List<string> bossIconPathList = motorcycleArrowSubModel.BossIconPathList;
		for (int i = 0; i < this.HeadItemList.Count; i++)
		{
			MotorcycleBossHeadItem motorcycleBossHeadItem = this.HeadItemList[i];
			int index = i + this.CurStartSubLevelIndex;
			motorcycleBossHeadItem.SetBossIconPath(bossIconPathList[index]);
		}
	}

	// Token: 0x04006913 RID: 26899
	private const int PROGRESS_DURATION = 500;

	// Token: 0x04006914 RID: 26900
	private const int FOREVER_LEVEL_PERCOUNT = 5;

	// Token: 0x04006915 RID: 26901
	protected UUISprite DistancePressBar;

	// Token: 0x04006916 RID: 26902
	protected UUIItem HeadList;

	// Token: 0x04006917 RID: 26903
	protected UUIItem HeadItem;

	// Token: 0x04006918 RID: 26904
	protected UUIItem PlayerHead;

	// Token: 0x04006919 RID: 26905
	protected UUITexture PlayerTextureHead;

	// Token: 0x0400691A RID: 26906
	protected int BarLength;

	// Token: 0x0400691B RID: 26907
	protected int SubBarLength;

	// Token: 0x0400691C RID: 26908
	[Nullable(1)]
	protected List<MotorcycleBossHeadItem> HeadItemList = new List<MotorcycleBossHeadItem>();

	// Token: 0x0400691D RID: 26909
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400691E RID: 26910
	private int ShowHeadItemIndex = -1;

	// Token: 0x0400691F RID: 26911
	private float NextShowHeadTime;

	// Token: 0x04006920 RID: 26912
	private float ShowHeadItemInterval;

	// Token: 0x04006921 RID: 26913
	private bool IsForeverLevel;

	// Token: 0x04006922 RID: 26914
	private int CurStartSubLevelIndex;

	// Token: 0x04006923 RID: 26915
	private int SubBarCount;

	// Token: 0x04006924 RID: 26916
	private float PlayerHeadPosOffset;

	// Token: 0x020080B5 RID: 32949
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BC5F RID: 179295
		public const int DistancePressBar = 0;

		// Token: 0x0402BC60 RID: 179296
		public const int HeadList = 1;

		// Token: 0x0402BC61 RID: 179297
		public const int HeadItem = 2;

		// Token: 0x0402BC62 RID: 179298
		public const int PlayerHead = 3;

		// Token: 0x0402BC63 RID: 179299
		public const int PlayerTextureHead = 4;
	}
}
