using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200220E RID: 8718
[NullableContext(1)]
[Nullable(0)]
public class LordGymThirdBossSelectView : LordGymLordEntranceSelectView
{
	// Token: 0x1700145A RID: 5210
	// (get) Token: 0x06010751 RID: 67409 RVA: 0x0047E983 File Offset: 0x0047CB83
	protected override string ShopTextId
	{
		get
		{
			return "BossChanllengeShop";
		}
	}

	// Token: 0x1700145B RID: 5211
	// (get) Token: 0x06010752 RID: 67410 RVA: 0x0047E98A File Offset: 0x0047CB8A
	protected override string ConfirmTextId
	{
		get
		{
			return "BossChanllengeStart";
		}
	}

	// Token: 0x1700145C RID: 5212
	// (get) Token: 0x06010753 RID: 67411 RVA: 0x0047E991 File Offset: 0x0047CB91
	protected override int ShopTabIndex
	{
		get
		{
			return 4;
		}
	}

	// Token: 0x06010754 RID: 67412 RVA: 0x0047E994 File Offset: 0x0047CB94
	public LordGymThirdBossSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010755 RID: 67413 RVA: 0x0047E9A8 File Offset: 0x0047CBA8
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUISprite)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout)));
	}

	// Token: 0x06010756 RID: 67414 RVA: 0x0047EA0C File Offset: 0x0047CC0C
	protected override void OpenSelectView()
	{
		ModelBase<LordGymModel>.Instance.EntranceEntityId = this.SelectedEntranceId;
		LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
		{
			LordEntranceSetId = this.EntranceSetId,
			LordEntranceId = this.SelectedEntranceId,
			IsPlaySpecialSequence = false
		};
		ALevelSequenceActor lordGymThirdBossSequenceActor = ModelBase<LordGymModel>.Instance.GetLordGymThirdBossSequenceActor();
		if (lordGymThirdBossSequenceActor != null)
		{
			ULevelSequencePlayer sequencePlayer = lordGymThirdBossSequenceActor.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Play();
			}
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymThirdDifficultySelectView, param, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.LordGymThirdBossSelectView, null);
		});
	}

	// Token: 0x06010757 RID: 67415 RVA: 0x0047EA9C File Offset: 0x0047CC9C
	protected override void OnStart()
	{
		if (this.LordEntranceList != null && this.LordEntranceList.Count > 7)
		{
			base.GetVerticalLayout(8).SetAlign(ELGUILayoutAlignmentType.UpperLeft);
			base.GetVerticalLayout(8).SetHeightFitToChildren(true);
		}
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetHomeBtnShowState(true);
		}
		PopupCaptionItem captionItem2 = this.CaptionItem;
		if (captionItem2 != null)
		{
			captionItem2.SetCloseCallBack(new Action(this.OnClickClose));
		}
		this.AddHomeBtnExitDungeonCallback();
		LordGymLordEntranceSelectViewParam lordGymLordEntranceSelectViewParam = this.OpenParam as LordGymLordEntranceSelectViewParam;
		if (lordGymLordEntranceSelectViewParam != null && lordGymLordEntranceSelectViewParam.IsPlaySpecialSequence.GetValueOrDefault())
		{
			this.UiViewSequence.StartSequenceName = "StartZ";
			return;
		}
		this.UiViewSequence.StartSequenceName = "Start01";
	}

	// Token: 0x06010758 RID: 67416 RVA: 0x0047EB4D File Offset: 0x0047CD4D
	public override string GetBlackScreenTypeOnOpenViewLoadScene()
	{
		LordGymLordEntranceSelectViewParam lordGymLordEntranceSelectViewParam = this.OpenParam as LordGymLordEntranceSelectViewParam;
		if (lordGymLordEntranceSelectViewParam != null && lordGymLordEntranceSelectViewParam.NeedBlackScreenAnim)
		{
			return "Start";
		}
		return "None";
	}

	// Token: 0x06010759 RID: 67417 RVA: 0x0047EB73 File Offset: 0x0047CD73
	protected override void InitSelect()
	{
	}

	// Token: 0x0601075A RID: 67418 RVA: 0x0047EB78 File Offset: 0x0047CD78
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymThirdBossSelectView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymThirdBossSelectView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601075B RID: 67419 RVA: 0x0047EBBC File Offset: 0x0047CDBC
	private UniTask PreloadSceneEffect(string effectPath)
	{
		LordGymThirdBossSelectView.<PreloadSceneEffect>d__17 <PreloadSceneEffect>d__;
		<PreloadSceneEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadSceneEffect>d__.<>4__this = this;
		<PreloadSceneEffect>d__.effectPath = effectPath;
		<PreloadSceneEffect>d__.<>1__state = -1;
		<PreloadSceneEffect>d__.<>t__builder.Start<LordGymThirdBossSelectView.<PreloadSceneEffect>d__17>(ref <PreloadSceneEffect>d__);
		return <PreloadSceneEffect>d__.<>t__builder.Task;
	}

	// Token: 0x0601075C RID: 67420 RVA: 0x0047EC08 File Offset: 0x0047CE08
	protected UniTask InitSelectAsync()
	{
		LordGymThirdBossSelectView.<InitSelectAsync>d__18 <InitSelectAsync>d__;
		<InitSelectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSelectAsync>d__.<>4__this = this;
		<InitSelectAsync>d__.<>1__state = -1;
		<InitSelectAsync>d__.<>t__builder.Start<LordGymThirdBossSelectView.<InitSelectAsync>d__18>(ref <InitSelectAsync>d__);
		return <InitSelectAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601075D RID: 67421 RVA: 0x0047EC4B File Offset: 0x0047CE4B
	protected override LordGymLordEntranceItem CreateItem()
	{
		return new LordGymThirdBossItem
		{
			OnToggleClick = new Action<int>(base.OnLordEntranceToggleClick),
			CanExecuteChangeCallBack = new Func<int, bool>(base.CanLordEntranceToggleChange)
		};
	}

	// Token: 0x0601075E RID: 67422 RVA: 0x0047EC76 File Offset: 0x0047CE76
	protected override void ReBuildLordEntranceList()
	{
		if (this.LordEntranceList != null && this.LordEntranceList.Count < 2)
		{
			this.LordEntranceList.Add(0);
		}
	}

	// Token: 0x0601075F RID: 67423 RVA: 0x0047EC9C File Offset: 0x0047CE9C
	protected override void OnHandleLoadScene()
	{
		if (!Singleton<UiSceneManager>.Instance.HasLordSkeletalHandle())
		{
			Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
			ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
			ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceId(this.SelectedEntranceId, true, true);
		}
		else
		{
			ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
		}
		LordGymLordEntranceSelectViewParam lordGymLordEntranceSelectViewParam = this.OpenParam as LordGymLordEntranceSelectViewParam;
		if (lordGymLordEntranceSelectViewParam != null && lordGymLordEntranceSelectViewParam.IsPlaySpecialSequence.GetValueOrDefault() && !this.HasPlayEffect)
		{
			LordGymEntrance? config = ConfigLordGymEntranceById.GetConfig(this.SelectedEntranceId, true);
			if (config != null && !string.IsNullOrEmpty(config.Value.LordUISceneEffect))
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(this.CacheTransform);
				this.SceneEffectHandle = instance.SpawnEffect(world, ftransformDouble, config.Value.LordUISceneEffect, "LordGymSceneEffect", null, EEffectType.UiScene3D, null, null, null, false, false);
			}
		}
		ControllerBase<LordGymController>.Instance.PlayLordModelMaterialAnimationByEntranceId(this.SelectedEntranceId, null, null, this.HasPlayEffect, !this.HasPlayEffect);
		this.HasPlayEffect = true;
	}

	// Token: 0x06010760 RID: 67424 RVA: 0x0047EDA0 File Offset: 0x0047CFA0
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		LordGymThirdBossSelectView.<OnHandlePostLoadSceneAsync>d__22 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<LordGymThirdBossSelectView.<OnHandlePostLoadSceneAsync>d__22>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010761 RID: 67425 RVA: 0x0047EDE4 File Offset: 0x0047CFE4
	protected override UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
	{
		LordGymThirdBossSelectView.<OnHandlePreReleaseSceneAsync>d__23 <OnHandlePreReleaseSceneAsync>d__;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
		<OnHandlePreReleaseSceneAsync>d__.<>1__state = -1;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder.Start<LordGymThirdBossSelectView.<OnHandlePreReleaseSceneAsync>d__23>(ref <OnHandlePreReleaseSceneAsync>d__);
		return <OnHandlePreReleaseSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010762 RID: 67426 RVA: 0x0047EE28 File Offset: 0x0047D028
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.DestroyLordSkeletalHandle();
		if (Singleton<EffectSystem>.Instance.IsValid(this.SceneEffectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.SceneEffectHandle, "[LordGymThirdBossSelectView.OnBeforeDestroy]", true, null);
			this.SceneEffectHandle = 0;
		}
	}

	// Token: 0x06010763 RID: 67427 RVA: 0x0047EE78 File Offset: 0x0047D078
	public override void SelectLordEntranceByIndex(int index)
	{
		int num = this.LordEntranceList[index];
		if (num == 0)
		{
			return;
		}
		GenericScrollViewNew<LordGymLordEntranceItem, int> lordEntranceScrollView = this.LordEntranceScrollView;
		if (lordEntranceScrollView != null)
		{
			GenericLayout<LordGymLordEntranceItem, int> genericLayout = lordEntranceScrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(index, false);
			}
		}
		this.SelectedEntranceId = num;
		ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceId(this.SelectedEntranceId, true, true);
		string text = (index + 1).ToString();
		this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity30/LordGym/SP_BossNum0{0}.SP_BossNum0{1}", new string[]
		{
			text,
			text
		}), base.GetSprite(7), true, null, null);
		base.PlaySequence("Switch", null, false);
	}

	// Token: 0x06010764 RID: 67428 RVA: 0x0047EF18 File Offset: 0x0047D118
	protected UniTask SelectLordEntranceByIndexAsync(int index)
	{
		LordGymThirdBossSelectView.<SelectLordEntranceByIndexAsync>d__26 <SelectLordEntranceByIndexAsync>d__;
		<SelectLordEntranceByIndexAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SelectLordEntranceByIndexAsync>d__.<>4__this = this;
		<SelectLordEntranceByIndexAsync>d__.index = index;
		<SelectLordEntranceByIndexAsync>d__.<>1__state = -1;
		<SelectLordEntranceByIndexAsync>d__.<>t__builder.Start<LordGymThirdBossSelectView.<SelectLordEntranceByIndexAsync>d__26>(ref <SelectLordEntranceByIndexAsync>d__);
		return <SelectLordEntranceByIndexAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010765 RID: 67429 RVA: 0x0047EF64 File Offset: 0x0047D164
	protected override void OnBeforeDestroy()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.SceneEffectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.SceneEffectHandle, "[LordGymThirdBossSelectView.OnBeforeDestroy]", true, null);
			this.SceneEffectHandle = 0;
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.RestoreDungeonEntranceEntity();
	}

	// Token: 0x06010766 RID: 67430 RVA: 0x0047EFB4 File Offset: 0x0047D1B4
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymThirdBossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__28_0>d <<AddHomeBtnExitDungeonCallback>b__28_0>d;
			<<AddHomeBtnExitDungeonCallback>b__28_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__28_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__28_0>d.<>t__builder.Start<LordGymThirdBossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__28_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__28_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__28_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x06010767 RID: 67431 RVA: 0x0047EFE8 File Offset: 0x0047D1E8
	private void OnClickClose()
	{
		if (ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.LordGymExitInstanceConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool _)
				{
					base.CloseMe(null);
				});
			};
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x04008188 RID: 33160
	private bool HasPlayEffect;

	// Token: 0x04008189 RID: 33161
	private readonly FTransformDouble CacheTransform = new FTransformDouble();

	// Token: 0x0400818A RID: 33162
	private int SceneEffectHandle;

	// Token: 0x020084E5 RID: 34021
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402D03C RID: 184380
		public const int ShopHotDot = 6;

		// Token: 0x0402D03D RID: 184381
		public const int BossNumSprite = 7;

		// Token: 0x0402D03E RID: 184382
		public const int Content = 8;
	}
}
