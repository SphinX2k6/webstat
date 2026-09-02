using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DAB RID: 23979
	[NullableContext(2)]
	[Nullable(0)]
	public class DreamLinkRewardViewLimit : UiTickViewBase
	{
		// Token: 0x0603C60F RID: 247311 RVA: 0x00F534D5 File Offset: 0x00F516D5
		[NullableContext(1)]
		public DreamLinkRewardViewLimit(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603C610 RID: 247312 RVA: 0x00F534F0 File Offset: 0x00F516F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C611 RID: 247313 RVA: 0x00F535BC File Offset: 0x00F517BC
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkRewardViewLimit.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkRewardViewLimit.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C612 RID: 247314 RVA: 0x00F53600 File Offset: 0x00F51800
		protected override void OnStart()
		{
			this.RemainTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			int previewWeaponId = this.ActivityDataBase.GetPreviewWeaponId();
			WeaponTrialData weaponTrialData = new WeaponTrialData();
			weaponTrialData.SetTrialId(previewWeaponId, true);
			this.WeaponItem.Refresh(weaponTrialData.GetItemId(), false);
			this.WeaponItem.SetLookButtonVisible(true);
			this.WeaponItem.BindWeaponPreviewFunction(new int[]
			{
				previewWeaponId
			}, 0);
		}

		// Token: 0x0603C613 RID: 247315 RVA: 0x00F5366C File Offset: 0x00F5186C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.DreamLinkLimitRewardRefresh, new Action(this.RefreshCurrentView));
		}

		// Token: 0x0603C614 RID: 247316 RVA: 0x00F5368A File Offset: 0x00F5188A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.DreamLinkLimitRewardRefresh, new Action(this.RefreshCurrentView));
		}

		// Token: 0x0603C615 RID: 247317 RVA: 0x00F536A8 File Offset: 0x00F518A8
		protected override void OnTick(float delta)
		{
			this.OnRefreshTime();
			DreamLinkWeaponModelHandle weaponHandle = this.WeaponHandle;
			if (weaponHandle == null)
			{
				return;
			}
			weaponHandle.Tick(delta);
		}

		// Token: 0x0603C616 RID: 247318 RVA: 0x00F536C4 File Offset: 0x00F518C4
		protected override void OnHandleLoadScene()
		{
			this.OriginCameraActor = ModelBase<CameraModel>.Instance.MainModel.CurrentCameraActor;
			this.SceneCameraActor = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("DoorCamera").Value, ECollectActorType.UI);
			ControllerBase<CameraController>.Instance.SetViewTarget(this.SceneCameraActor, "DreamLinkRewardViewLimit.OpenAndStartSequence", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
			AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("Weapon1").Value, ECollectActorType.UI);
			AActor actorWithTag2 = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("Weapon2").Value, ECollectActorType.UI);
			AActor[] array = new AActor[]
			{
				actorWithTag,
				actorWithTag2
			};
			for (int i = 0; i < array.Length; i++)
			{
				USkeletalMeshComponent uskeletalMeshComponent = array[i].GetComponentByClass(USkeletalMeshComponent.StaticClass()) as USkeletalMeshComponent;
				uskeletalMeshComponent.SetTickableWhenPaused(true);
				uskeletalMeshComponent.SetForcedLOD(1);
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("Sequence_DreamLinkRewardStart");
			this.PlaySceneLevelSequence(resourcePath, new Action(this.PlayAutoRotate));
		}

		// Token: 0x0603C617 RID: 247319 RVA: 0x00F537E0 File Offset: 0x00F519E0
		protected override void OnBeforeDestroy()
		{
			ControllerBase<CameraController>.Instance.SetViewTarget(this.OriginCameraActor, "DreamLinkRewardViewLimit.OnBeforeDestroy", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
			this.OriginCameraActor = null;
			this.SceneCameraActor = null;
			ALevelSequenceActor sequenceActor = this.SequenceActor;
			if (sequenceActor != null && sequenceActor.IsValid())
			{
				ALevelSequenceActor sequenceActor2 = this.SequenceActor;
				if (sequenceActor2 != null)
				{
					sequenceActor2.K2_DestroyActor();
				}
				this.SequenceActor = null;
			}
			ULevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsValid())
			{
				ULevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 != null)
				{
					sequencePlayer2.Stop();
				}
				this.SequencePlayer = null;
			}
			DreamLinkWeaponModelHandle weaponHandle = this.WeaponHandle;
			if (weaponHandle != null)
			{
				weaponHandle.StopRotate();
			}
			DreamLinkWeaponModelHandle weaponHandle2 = this.WeaponHandle;
			if (weaponHandle2 == null)
			{
				return;
			}
			weaponHandle2.Destroy();
		}

		// Token: 0x0603C618 RID: 247320 RVA: 0x00F538AD File Offset: 0x00F51AAD
		private void RefreshCurrentView()
		{
			this.RefreshTabViewRedDot(this.CurrentTabIndex);
			this.RefreshLayout(this.CurrentTabIndex).Forget();
			this.SpecialRewardItem.Refresh();
		}

		// Token: 0x0603C619 RID: 247321 RVA: 0x00F538D7 File Offset: 0x00F51AD7
		[NullableContext(1)]
		private CommonTabItemData[] GetTabItemData()
		{
			return this.TabComponent.CreateTabItemDataByLength(this.ActivityDataBase.GetLimitTimeRewardTypeLength()).ToArray();
		}

		// Token: 0x0603C61A RID: 247322 RVA: 0x00F538F4 File Offset: 0x00F51AF4
		[NullableContext(1)]
		private CommonTabItem ProxyCreateTabItem([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x0603C61B RID: 247323 RVA: 0x00F538FC File Offset: 0x00F51AFC
		private void RefreshTabViewRedDot(int index)
		{
			int tabId = index + 1;
			this.TabComponent.GetTabItemByIndex(index).SetRedDotState(this.ActivityDataBase.CheckHasLimitTimeTabReward(tabId));
		}

		// Token: 0x0603C61C RID: 247324 RVA: 0x00F5392A File Offset: 0x00F51B2A
		private void OnTypeButtonClicked(int index)
		{
			this.RefreshLayout(index).Forget();
		}

		// Token: 0x0603C61D RID: 247325 RVA: 0x00F53938 File Offset: 0x00F51B38
		[NullableContext(1)]
		private CommonTabData GetCommonData(int index)
		{
			string text;
			string icon;
			this.ActivityDataBase.GetTypeInfoByTabId(index + 1).Deconstruct(out text, out icon);
			string textId = text;
			return new CommonTabData(icon, new CommonTabTitleData(textId, Array.Empty<object>()), null);
		}

		// Token: 0x0603C61E RID: 247326 RVA: 0x00F53970 File Offset: 0x00F51B70
		[NullableContext(1)]
		private DreamLinkRewardLimitTimeItem CreateTaskItem()
		{
			return new DreamLinkRewardLimitTimeItem();
		}

		// Token: 0x0603C61F RID: 247327 RVA: 0x00F53978 File Offset: 0x00F51B78
		private UniTask RefreshLayout(int index)
		{
			DreamLinkRewardViewLimit.<RefreshLayout>d__30 <RefreshLayout>d__;
			<RefreshLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshLayout>d__.<>4__this = this;
			<RefreshLayout>d__.index = index;
			<RefreshLayout>d__.<>1__state = -1;
			<RefreshLayout>d__.<>t__builder.Start<DreamLinkRewardViewLimit.<RefreshLayout>d__30>(ref <RefreshLayout>d__);
			return <RefreshLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603C620 RID: 247328 RVA: 0x00F539C4 File Offset: 0x00F51BC4
		private void OnRefreshTime()
		{
			if (!this.LimitTimeRewardOn)
			{
				return;
			}
			long limitTimeEndTime = this.ActivityDataBase.GetLimitTimeEndTime();
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if ((double)limitTimeEndTime - serverTime < 0.0)
			{
				this.LimitTimeRewardOn = false;
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(limitTimeEndTime, this.RemainTimeText);
			base.GetText(2).SetText(remainTimeText, true);
		}

		// Token: 0x0603C621 RID: 247329 RVA: 0x00F53A34 File Offset: 0x00F51C34
		[NullableContext(1)]
		protected void PlaySceneLevelSequence(string levelSequencePath, [Nullable(2)] Action startCallback = null)
		{
			if (this.SequencePlayer != null)
			{
				this.SequencePlayer.Stop();
				this.SequencePlayer = null;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(levelSequencePath, delegate([Nullable(2)] ULevelSequence levelSequence, string _)
			{
				if (!ObjectUtils.IsValid(levelSequence))
				{
					return;
				}
				ALevelSequenceActor alevelSequenceActor = Singleton<ActorSystem>.Instance.Spawn(ALevelSequenceActor.StaticClass(), new FTransformDouble(), null) as ALevelSequenceActor;
				alevelSequenceActor.SetSequence(levelSequence);
				alevelSequenceActor.PlaybackSettings = new FMovieSceneSequencePlaybackSettings
				{
					bRestoreState = false,
					bPauseAtEnd = true
				};
				alevelSequenceActor.SetTickableWhenPaused(true);
				UKuroSequenceRuntimeFunctionLibrary.SetSequenceInUiScene(levelSequence, true);
				this.SequenceActor = alevelSequenceActor;
				this.SequencePlayer = alevelSequenceActor.SequencePlayer;
				this.SequenceActor.bOverrideInstanceData = true;
				UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
				FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(ControllerBase<RenderModuleController>.Instance.GetKuroCurrentUiSceneTransform().Value);
				udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin;
				this.SequencePlayer.PlayTo(new FMovieSceneSequencePlaybackParams(this.SequencePlayer.GetEndTime().Time, 0f, "A", EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play));
				Action startCallback2 = startCallback;
				if (startCallback2 == null)
				{
					return;
				}
				startCallback2();
			}, 100, this.MemoryTag);
		}

		// Token: 0x0603C622 RID: 247330 RVA: 0x00F53A90 File Offset: 0x00F51C90
		private void PlayAutoRotate()
		{
			AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("WeaponRoot").Value, ECollectActorType.UI);
			this.WeaponHandle = new DreamLinkWeaponModelHandle(actorWithTag);
			int value = ConfigCommonParamById.GetIntConfig("DreamLinkModelRotateTime").Value;
			this.WeaponHandle.SetRotateParam((float)value, ERotateAxis.Yaw, true);
			this.WeaponHandle.StartRotate();
		}

		// Token: 0x04021F35 RID: 139061
		private DreamLinkData ActivityDataBase;

		// Token: 0x04021F36 RID: 139062
		private bool LimitTimeRewardOn = true;

		// Token: 0x04021F37 RID: 139063
		[Nullable(1)]
		private string RemainTimeText = "";

		// Token: 0x04021F38 RID: 139064
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x04021F39 RID: 139065
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<DreamLinkRewardLimitTimeItem, DreamLinkRewardData> TaskLayout;

		// Token: 0x04021F3A RID: 139066
		private int CurrentTabIndex;

		// Token: 0x04021F3B RID: 139067
		private DreamLinkRewardSpecialItem SpecialRewardItem;

		// Token: 0x04021F3C RID: 139068
		private ActivityWeaponDescribeComponent WeaponItem;

		// Token: 0x04021F3D RID: 139069
		private ULevelSequencePlayer SequencePlayer;

		// Token: 0x04021F3E RID: 139070
		private ALevelSequenceActor SequenceActor;

		// Token: 0x04021F3F RID: 139071
		private AActor OriginCameraActor;

		// Token: 0x04021F40 RID: 139072
		private AActor SceneCameraActor;

		// Token: 0x04021F41 RID: 139073
		private DreamLinkWeaponModelHandle WeaponHandle;

		// Token: 0x0200BDEE RID: 48622
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A79D RID: 239517
			public const int CommonTabComponent = 0;

			// Token: 0x0403A79E RID: 239518
			public const int Layout = 1;

			// Token: 0x0403A79F RID: 239519
			public const int TxtTime = 2;

			// Token: 0x0403A7A0 RID: 239520
			public const int PanelSpecial = 3;

			// Token: 0x0403A7A1 RID: 239521
			public const int WeaponAttributeItem = 4;
		}
	}
}
