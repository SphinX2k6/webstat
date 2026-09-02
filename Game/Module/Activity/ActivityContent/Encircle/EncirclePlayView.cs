using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006876 RID: 26742
	[NullableContext(1)]
	[Nullable(0)]
	public class EncirclePlayView : UiViewBase
	{
		// Token: 0x06042A4F RID: 272975 RVA: 0x0111AB2F File Offset: 0x01118D2F
		public EncirclePlayView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042A50 RID: 272976 RVA: 0x0111AB44 File Offset: 0x01118D44
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(USpineSkeletonAnimationComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickedBtnReset))
			};
		}

		// Token: 0x06042A51 RID: 272977 RVA: 0x0111AC5C File Offset: 0x01118E5C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<Dictionary<int, IHexData>>(EEventName.EncircleReset, new Action<Dictionary<int, IHexData>>(this.OnEncircleReset));
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042A52 RID: 272978 RVA: 0x0111AC96 File Offset: 0x01118E96
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EncircleReset, new Action<Dictionary<int, IHexData>>(this.OnEncircleReset));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042A53 RID: 272979 RVA: 0x0111ACD0 File Offset: 0x01118ED0
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(3));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedCloseButton));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelpBtn));
			this.Param = (this.OpenParam as IEncircleArgs);
			this.InitMap();
			this.InitTween();
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.CanNotClick = false;
		}

		// Token: 0x06042A54 RID: 272980 RVA: 0x0111AD54 File Offset: 0x01118F54
		protected override void OnBeforeDestroy()
		{
			this.ChildItems.Clear();
			if (this.EncirclePlayTweenEndCbWrapper1 != null)
			{
				ULGUIPlayTweenComponent monster1PlayTweenComp = this.Monster1PlayTweenComp;
				if (monster1PlayTweenComp != null)
				{
					ULGUIPlayTween playTween = monster1PlayTweenComp.GetPlayTween();
					if (playTween != null)
					{
						playTween.UnregisterOnComplete(this.EncirclePlayTweenEndCbWrapper1);
					}
				}
				this.EncirclePlayTweenEndCbWrapper1 = null;
			}
			if (this.EncirclePlayTweenEndCbWrapper2 != null)
			{
				ULGUIPlayTweenComponent monster1PlayTweenComp2 = this.Monster1PlayTweenComp;
				if (monster1PlayTweenComp2 != null)
				{
					ULGUIPlayTween playTween2 = monster1PlayTweenComp2.GetPlayTween();
					if (playTween2 != null)
					{
						playTween2.UnregisterOnComplete(this.EncirclePlayTweenEndCbWrapper2);
					}
				}
				this.EncirclePlayTweenEndCbWrapper2 = null;
			}
			if (this.OnTweenEnd != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.OnTweenEnd);
			}
			USpineSkeletonAnimationComponent spine = base.GetSpine(2);
			if (spine != null)
			{
				spine.ClearTracks();
			}
			USpineSkeletonAnimationComponent spine2 = base.GetSpine(2);
			if (spine2 != null)
			{
				spine2.AnimationComplete.Clear();
			}
			USpineSkeletonAnimationComponent spine3 = base.GetSpine(9);
			if (spine3 != null)
			{
				spine3.ClearTracks();
			}
			USpineSkeletonAnimationComponent spine4 = base.GetSpine(9);
			if (spine4 != null)
			{
				spine4.AnimationComplete.Clear();
			}
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
			this.CanNotClick = false;
		}

		// Token: 0x06042A55 RID: 272981 RVA: 0x0111AE60 File Offset: 0x01119060
		private void InitTween()
		{
			this.Monster1PlayTweenComp = (base.GetItem(1).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			this.Monster2PlayTweenComp = (base.GetItem(8).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
		}

		// Token: 0x06042A56 RID: 272982 RVA: 0x0111AEBC File Offset: 0x011190BC
		private void InitMap()
		{
			UUIItem item = base.GetItem(7);
			UUIItem item2 = base.GetItem(0);
			using (Dictionary<int, IHexData>.ValueCollection.Enumerator enumerator = this.Param.Hexes.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IHexData hexData = enumerator.Current;
					ValueTuple<int, int> planePos = Singleton<EncircleUtils>.Instance.HexPosToPlanePos(hexData.HexPos);
					UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item, item2);
					uuiitem.SetActive(true, false);
					ValueTuple<float, float> valueTuple = this.CalcItemOffset(planePos);
					uuiitem.SetAnchorOffsetX(valueTuple.Item1);
					uuiitem.SetAnchorOffsetY(valueTuple.Item2);
					EncirclePlayMapItemView newMapItemClass = new EncirclePlayMapItemView();
					this.CreateMapItemTemplate(uuiitem, newMapItemClass).ContinueWith(delegate()
					{
						newMapItemClass.SetPos(planePos.Item1, planePos.Item2);
						int num = Singleton<EncircleUtils>.Instance.PlanePosToKey(planePos.Item1, planePos.Item2);
						this.ChildItems[num] = newMapItemClass;
						newMapItemClass.ChangeNorMap(hexData.MapId, new int?(num));
						if (hexData.Type == EncircleHexType.Monster)
						{
							this.SetMonsterPos(hexData.MapId, newMapItemClass, true, 1, false, false);
						}
					});
				}
			}
			this.SetCurrentStepText(0);
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			int currentChallengeId = Singleton<EncirclePlayLevelController>.Instance.GetCurrentChallengeId();
			this.SetBestRecordStepTxt(encircleData.GetChallengeRecord(currentChallengeId));
		}

		// Token: 0x06042A57 RID: 272983 RVA: 0x0111AFF8 File Offset: 0x011191F8
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"OffsetX",
			"OffsetY"
		})]
		private ValueTuple<float, float> CalcItemOffset([TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})] ValueTuple<int, int> planePos)
		{
			int num = (int)Math.Floor((double)this.Param.Height / 2.0);
			int num2 = (int)Math.Floor((double)this.Param.Width / 2.0);
			UUIItem item = base.GetItem(7);
			float width = item.GetWidth();
			float height = item.GetHeight();
			float num3 = height * ((this.Param.Height % 2 == 0) ? 0.5f : 0f);
			return new ValueTuple<float, float>(width * ((this.Param.Width % 2 == 0) ? 0.5f : 0f) + (float)(planePos.Item1 - num2) * width * 1.1f + (((planePos.Item2 + 1) % 2 == 1) ? (width * 0.55f) : 0f), -num3 + (float)(-(float)planePos.Item2 + num) * height * 0.84f);
		}

		// Token: 0x06042A58 RID: 272984 RVA: 0x0111B0D8 File Offset: 0x011192D8
		private void ResetMap(Dictionary<int, IHexData> hexes)
		{
			this.SetCurrentStepText(0);
			foreach (IHexData hexData in hexes.Values)
			{
				ValueTuple<int, int> valueTuple = Singleton<EncircleUtils>.Instance.HexPosToPlanePos(hexData.HexPos);
				EncirclePlayMapItemView encirclePlayMapItemView;
				this.ChildItems.TryGetValue(Singleton<EncircleUtils>.Instance.PlanePosToKey(valueTuple.Item1, valueTuple.Item2), out encirclePlayMapItemView);
				if (encirclePlayMapItemView != null)
				{
					encirclePlayMapItemView.ChangeNorMap(hexData.MapId, new int?(Singleton<EncircleUtils>.Instance.HexPosToKey(hexData.HexPos)));
					if (hexData.Type == EncircleHexType.Monster)
					{
						this.SetMonsterPos(hexData.MapId, encirclePlayMapItemView, true, 1, false, false);
					}
				}
			}
		}

		// Token: 0x06042A59 RID: 272985 RVA: 0x0111B1A4 File Offset: 0x011193A4
		private UniTask CreateMapItemTemplate(UUIItem item, EncirclePlayMapItemView itemView)
		{
			EncirclePlayView.<CreateMapItemTemplate>d__25 <CreateMapItemTemplate>d__;
			<CreateMapItemTemplate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMapItemTemplate>d__.item = item;
			<CreateMapItemTemplate>d__.itemView = itemView;
			<CreateMapItemTemplate>d__.<>1__state = -1;
			<CreateMapItemTemplate>d__.<>t__builder.Start<EncirclePlayView.<CreateMapItemTemplate>d__25>(ref <CreateMapItemTemplate>d__);
			return <CreateMapItemTemplate>d__.<>t__builder.Task;
		}

		// Token: 0x06042A5A RID: 272986 RVA: 0x0111B1F0 File Offset: 0x011193F0
		private void SetMonsterPos(int mapItemId, EncirclePlayMapItemView currentMapItemView, bool init = false, int towardDirection = 1, bool goSleep = false, bool goOutSide = false)
		{
			UUIItem item;
			ULGUIPlayTweenComponent monsterTween;
			USpineSkeletonAnimationComponent spine;
			int monsterIndex;
			if (mapItemId == 2)
			{
				item = base.GetItem(1);
				monsterTween = this.Monster1PlayTweenComp;
				spine = base.GetSpine(2);
				monsterIndex = 1;
			}
			else
			{
				if (mapItemId != 3)
				{
					return;
				}
				item = base.GetItem(8);
				monsterTween = this.Monster2PlayTweenComp;
				spine = base.GetSpine(9);
				monsterIndex = 2;
			}
			item.SetUIActive(true);
			if (towardDirection != 0 && item != null)
			{
				item.SetUIItemScale(new FVector((float)towardDirection, 1f, 1f));
			}
			UUIItem item2 = base.GetItem(0);
			float? num = ((item2 != null) ? new float?(item2.GetAnchorOffsetX()) : null) + ((currentMapItemView != null) ? new float?(currentMapItemView.GetRootItem().GetAnchorOffsetX()) : null);
			float? num2 = ((item2 != null) ? new float?(item2.GetAnchorOffsetY()) : null) + ((currentMapItemView != null) ? new float?(currentMapItemView.GetRootItem().GetAnchorOffsetY()) : null);
			if (init)
			{
				this.ResetSpineStatus(spine);
				this.StopTween(item);
				if (item != null)
				{
					item.SetAnchorOffsetX(num.GetValueOrDefault());
				}
				if (item != null)
				{
					item.SetAnchorOffsetY(num2.GetValueOrDefault());
				}
				if (spine != null)
				{
					spine.SetAnimation(0, ESpineAnimation.Idle.ToEnumString(), true);
					return;
				}
			}
			else
			{
				this.PlayTween(item, monsterTween, spine, num.GetValueOrDefault(), num2.GetValueOrDefault(), goSleep, goOutSide, monsterIndex);
			}
		}

		// Token: 0x06042A5B RID: 272987 RVA: 0x0111B3B4 File Offset: 0x011195B4
		private void PlayTween(UUIItem monsterItem, ULGUIPlayTweenComponent monsterTween, USpineSkeletonAnimationComponent monsterSpine, float offsetX, float offsetY, bool goSleep, bool goOutSide, int monsterIndex)
		{
			float anchorOffsetX = monsterItem.GetAnchorOffsetX();
			float anchorOffsetY = monsterItem.GetAnchorOffsetY();
			ULGUIPlayTween_Vector2 tween = monsterTween.GetPlayTween() as ULGUIPlayTween_Vector2;
			tween.from = Vector2D.Create((double)anchorOffsetX, (double)anchorOffsetY).ToUeVector2D(false);
			tween.to = Vector2D.Create((double)offsetX, (double)offsetY).ToUeVector2D(false);
			double x = monsterItem.D_K2_GetComponentScale().X;
			string sleepAnimName = "";
			string sleepStartAnimName = "";
			string animationName = "";
			if (x > 0.0)
			{
				sleepAnimName = ESpineAnimation.Sleep.ToEnumString();
				sleepStartAnimName = ESpineAnimation.SleepStart.ToEnumString();
				animationName = ESpineAnimation.WakeUp.ToEnumString();
			}
			else if (x < 0.0)
			{
				sleepAnimName = ESpineAnimation.Sleep2.ToEnumString();
				sleepStartAnimName = ESpineAnimation.SleepStart2.ToEnumString();
				animationName = ESpineAnimation.WakeUp2.ToEnumString();
			}
			if (anchorOffsetX == offsetX && anchorOffsetY == offsetY)
			{
				UTrackEntry current = monsterSpine.GetCurrent(0);
				if (!(((current != null) ? current.getAnimationName() : null) == sleepAnimName))
				{
					UTrackEntry current2 = monsterSpine.GetCurrent(0);
					if (!(((current2 != null) ? current2.getAnimationName() : null) == sleepStartAnimName))
					{
						monsterSpine.SetAnimation(0, sleepAnimName, true);
						goto IL_1C6;
					}
				}
				monsterSpine.SetAnimation(0, animationName, false);
				monsterSpine.AnimationComplete.Add(delegate(UTrackEntry entry)
				{
					monsterSpine.SetAnimation(0, ESpineAnimation.Idle.ToEnumString(), true);
				});
				IL_1C6:
				Singleton<EncirclePlayLevelController>.Instance.TryPushMoveToNextState();
				return;
			}
			Action<UTrackEntry> <>9__2;
			Action<UTrackEntry> <>9__3;
			this.OnTweenEnd = delegate()
			{
				if (goOutSide)
				{
					tween.from = Vector2D.Create((double)offsetX, (double)offsetY).ToUeVector2D(false);
					tween.to = Vector2D.Create((double)(offsetX * 1.3f), (double)(offsetY * 1.3f)).ToUeVector2D(false);
					this.ResetSpineStatus(monsterSpine);
					monsterSpine.SetAnimation(0, ESpineAnimation.WalkAway.ToEnumString(), false);
					if (this.EncirclePlayTweenEndCbWrapper1 != null)
					{
						tween.UnregisterOnComplete(this.EncirclePlayTweenEndCbWrapper1);
					}
					if (this.EncirclePlayTweenEndCbWrapper2 != null)
					{
						tween.UnregisterOnComplete(this.EncirclePlayTweenEndCbWrapper2);
					}
					monsterTween.Stop();
					monsterTween.Play();
					FSpineAnimationCompleteDelegate animationComplete = monsterSpine.AnimationComplete;
					Action<UTrackEntry> callback;
					if ((callback = <>9__2) == null)
					{
						callback = (<>9__2 = delegate(UTrackEntry entry)
						{
							this.PushNextState();
							this.CanNotClick = false;
						});
					}
					animationComplete.Add(callback);
					return;
				}
				if (goSleep)
				{
					monsterSpine.SetAnimation(0, sleepStartAnimName, false);
					FSpineAnimationCompleteDelegate animationComplete2 = monsterSpine.AnimationComplete;
					Action<UTrackEntry> callback2;
					if ((callback2 = <>9__3) == null)
					{
						callback2 = (<>9__3 = delegate(UTrackEntry entry)
						{
							monsterSpine.SetAnimation(0, sleepAnimName, true);
						});
					}
					animationComplete2.Add(callback2);
				}
				else
				{
					monsterSpine.SetAnimation(0, ESpineAnimation.Idle.ToEnumString(), true);
				}
				this.PushNextState();
			};
			if (monsterIndex == 1)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.OnTweenEnd);
				if (this.EncirclePlayTweenEndCbWrapper1 != null)
				{
					tween.UnregisterOnComplete(this.EncirclePlayTweenEndCbWrapper1);
				}
				FLGUIPlayTweenCompleteDynamicDelegate flguiplayTweenCompleteDynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(this.OnTweenEnd);
				this.EncirclePlayTweenEndCbWrapper1 = tween.RegisterOnComplete(flguiplayTweenCompleteDynamicDelegate);
			}
			else
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.OnTweenEnd);
				if (this.EncirclePlayTweenEndCbWrapper2 != null)
				{
					tween.UnregisterOnComplete(this.EncirclePlayTweenEndCbWrapper2);
				}
				FLGUIPlayTweenCompleteDynamicDelegate flguiplayTweenCompleteDynamicDelegate2 = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(this.OnTweenEnd);
				this.EncirclePlayTweenEndCbWrapper2 = tween.RegisterOnComplete(flguiplayTweenCompleteDynamicDelegate2);
			}
			if (goOutSide)
			{
				this.CanNotClick = true;
			}
			monsterTween.Stop();
			monsterTween.Play();
			monsterSpine.SetAnimation(0, ESpineAnimation.Walk.ToEnumString(), false);
		}

		// Token: 0x06042A5C RID: 272988 RVA: 0x0111B678 File Offset: 0x01119878
		private void StopTween(UUIItem monsterItem)
		{
			TArray<UActorComponent> tarray = monsterItem.GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				(tarray.Get(i) as ULGUIPlayTweenComponent).Stop();
			}
		}

		// Token: 0x06042A5D RID: 272989 RVA: 0x0111B6C0 File Offset: 0x011198C0
		public void ShowSuccessNiagara()
		{
			foreach (EncirclePlayMapItemView encirclePlayMapItemView in this.ChildItems.Values)
			{
				if (encirclePlayMapItemView != null)
				{
					encirclePlayMapItemView.ShowSuccess();
				}
			}
		}

		// Token: 0x06042A5E RID: 272990 RVA: 0x0111B71C File Offset: 0x0111991C
		public void SetMonsterDead(int monsterId)
		{
			USpineSkeletonAnimationComponent uspineSkeletonAnimationComponent = null;
			if (monsterId == 2)
			{
				uspineSkeletonAnimationComponent = base.GetSpine(2);
			}
			else if (monsterId == 3)
			{
				uspineSkeletonAnimationComponent = base.GetSpine(9);
			}
			this.ResetSpineStatus(uspineSkeletonAnimationComponent);
			if (uspineSkeletonAnimationComponent != null)
			{
				uspineSkeletonAnimationComponent.SetAnimation(0, ESpineAnimation.Die.ToEnumString(), false);
			}
		}

		// Token: 0x06042A5F RID: 272991 RVA: 0x0111B75F File Offset: 0x0111995F
		private void PushNextState()
		{
			Singleton<EncirclePlayLevelController>.Instance.TryPushMoveToNextState();
		}

		// Token: 0x06042A60 RID: 272992 RVA: 0x0111B76C File Offset: 0x0111996C
		private void OnEncircleReset(Dictionary<int, IHexData> hexes)
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.StopCurrentSequence(false, true);
			}
			this.ViewSequencePlayer.PlayLevelSequenceByName("Refresh", false, null, false);
			this.ResetMap(hexes);
		}

		// Token: 0x06042A61 RID: 272993 RVA: 0x0111B7B0 File Offset: 0x011199B0
		public void SetAllMonsterDead(List<int> monsterIds)
		{
			USpineSkeletonAnimationComponent monsterSpine = null;
			foreach (int num in monsterIds)
			{
				if (num == 2)
				{
					monsterSpine = base.GetSpine(2);
				}
				else if (num == 3)
				{
					monsterSpine = base.GetSpine(9);
				}
				this.ResetSpineStatus(monsterSpine);
				USpineSkeletonAnimationComponent monsterSpine4 = monsterSpine;
				if (monsterSpine4 != null)
				{
					monsterSpine4.SetAnimation(0, ESpineAnimation.Die.ToEnumString(), false);
				}
				this.ShowSuccessNiagara();
			}
			this.CanNotClick = true;
			Action<UTrackEntry> executeWin = null;
			executeWin = delegate(UTrackEntry trackEntry)
			{
				USpineSkeletonAnimationComponent monsterSpine3 = monsterSpine;
				if (monsterSpine3 != null)
				{
					monsterSpine3.AnimationComplete.Remove(executeWin);
				}
				Singleton<EncirclePlayLevelController>.Instance.ExecuteWin();
				this.CanNotClick = false;
			};
			USpineSkeletonAnimationComponent monsterSpine2 = monsterSpine;
			if (monsterSpine2 == null)
			{
				return;
			}
			monsterSpine2.AnimationComplete.Add(executeWin);
		}

		// Token: 0x06042A62 RID: 272994 RVA: 0x0111B898 File Offset: 0x01119A98
		public void ChangeEncircleMap(int mapItemId, IHexPos currentPos, [Nullable(2)] IHexPos oldPos)
		{
			EncircleHexType? mapItemType = ConfigBase<ActivityEncircleConfig>.Instance.GetMapItemType(mapItemId);
			int num = Singleton<EncircleUtils>.Instance.HexPosToKey(currentPos);
			EncircleHexType? encircleHexType = mapItemType;
			EncircleHexType encircleHexType2 = EncircleHexType.Monster;
			if (encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null)
			{
				if (oldPos != null)
				{
					EncirclePlayMapItemView encirclePlayMapItemView;
					this.ChildItems.TryGetValue(Singleton<EncircleUtils>.Instance.HexPosToKey(oldPos), out encirclePlayMapItemView);
					if (encirclePlayMapItemView != null)
					{
						encirclePlayMapItemView.ChangeNorMap(0, null);
					}
				}
				EncirclePlayMapItemView encirclePlayMapItemView2;
				this.ChildItems.TryGetValue(num, out encirclePlayMapItemView2);
				EncircleHexType? type = encirclePlayMapItemView2.GetType2();
				bool goSleep = false;
				if (type != null)
				{
					encircleHexType = type;
					encircleHexType2 = EncircleHexType.Trap;
					if (encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null)
					{
						goSleep = true;
					}
				}
				bool goOutSide = false;
				if (Singleton<EncirclePlayLevelController>.Instance.CheckIsBoundary(currentPos))
				{
					goOutSide = true;
				}
				if (encirclePlayMapItemView2 != null)
				{
					encirclePlayMapItemView2.ChangeNorMap(mapItemId, new int?(num));
				}
				this.SetMonsterPos(mapItemId, encirclePlayMapItemView2, false, this.GetTowardDirection(oldPos, currentPos), goSleep, goOutSide);
				return;
			}
			EncirclePlayMapItemView encirclePlayMapItemView3;
			this.ChildItems.TryGetValue(num, out encirclePlayMapItemView3);
			if (encirclePlayMapItemView3 != null)
			{
				encirclePlayMapItemView3.ChangeNorMap(mapItemId, new int?(num));
			}
		}

		// Token: 0x06042A63 RID: 272995 RVA: 0x0111B9A1 File Offset: 0x01119BA1
		private int GetTowardDirection([Nullable(2)] IHexPos oldPos, IHexPos currentPos)
		{
			if (oldPos == null)
			{
				return 1;
			}
			if (oldPos == currentPos)
			{
				return 0;
			}
			if (currentPos.PosX - oldPos.PosX < 0)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x06042A64 RID: 272996 RVA: 0x0111B9C4 File Offset: 0x01119BC4
		public void ShowItemMoveEffect(int posKey, bool value)
		{
			EncirclePlayMapItemView encirclePlayMapItemView;
			this.ChildItems.TryGetValue(posKey, out encirclePlayMapItemView);
			if (encirclePlayMapItemView != null)
			{
				encirclePlayMapItemView.ShowMonsterMoveEffect(value);
			}
		}

		// Token: 0x06042A65 RID: 272997 RVA: 0x0111B9EC File Offset: 0x01119BEC
		public void RefreshStepText()
		{
			if (this.DifficultyStep > 0)
			{
				base.GetText(5).SetText("<color=#fed966>" + this.DifficultyStep.ToString() + "</color>+" + this.CurrentStep.ToString(), true);
				return;
			}
			base.GetText(5).SetText(this.CurrentStep.ToString(), true);
		}

		// Token: 0x06042A66 RID: 272998 RVA: 0x0111BA4D File Offset: 0x01119C4D
		public void SetCurrentStepText(int count)
		{
			this.CurrentStep = count;
			this.RefreshStepText();
		}

		// Token: 0x06042A67 RID: 272999 RVA: 0x0111BA5C File Offset: 0x01119C5C
		public void SetDifficultyStepTxt(int count)
		{
			this.DifficultyStep = count;
			this.RefreshStepText();
		}

		// Token: 0x06042A68 RID: 273000 RVA: 0x0111BA6C File Offset: 0x01119C6C
		public void SetBestRecordStepTxt(int count)
		{
			string newText = count.ToString();
			if (count == 0)
			{
				newText = "--";
			}
			base.GetText(6).SetText(newText, true);
		}

		// Token: 0x06042A69 RID: 273001 RVA: 0x0111BA98 File Offset: 0x01119C98
		public void ResetSpineStatus(USpineSkeletonAnimationComponent monsterSpine)
		{
			monsterSpine.SetToSetupPose();
			monsterSpine.ClearTracks();
			monsterSpine.AnimationComplete.Clear();
		}

		// Token: 0x06042A6A RID: 273002 RVA: 0x0111BAB4 File Offset: 0x01119CB4
		private void OnClickedBtnReset()
		{
			if (this.CanNotClick)
			{
				return;
			}
			Action value = delegate()
			{
			};
			Action value2 = delegate()
			{
				Singleton<EncirclePlayLevelController>.Instance.ResetEncircle();
			};
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.EncircleResetConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, value);
			confirmBoxDataNew.FunctionMap.Add(2, value2);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06042A6B RID: 273003 RVA: 0x0111BB3C File Offset: 0x01119D3C
		private void OnClickedCloseButton()
		{
			if (this.CanNotClick)
			{
				return;
			}
			Action value = delegate()
			{
			};
			Action value2 = delegate()
			{
				Singleton<EncirclePlayLevelController>.Instance.CloseEncircle();
			};
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.EncircleExitConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, value);
			confirmBoxDataNew.FunctionMap.Add(2, value2);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06042A6C RID: 273004 RVA: 0x0111BBC3 File Offset: 0x01119DC3
		private void OnClickHelpBtn()
		{
			if (this.CanNotClick)
			{
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(504);
		}

		// Token: 0x06042A6D RID: 273005 RVA: 0x0111BBDD File Offset: 0x01119DDD
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (closeActivities.Contains(ControllerBase<ActivityEncircleController>.Instance.ActivityId))
			{
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			}
		}

		// Token: 0x0402517E RID: 151934
		private const int MONSTER1_ITEM_ID = 2;

		// Token: 0x0402517F RID: 151935
		private const int MONSTER2_ITEM_ID = 3;

		// Token: 0x04025180 RID: 151936
		private const int HELP_ID = 504;

		// Token: 0x04025181 RID: 151937
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04025182 RID: 151938
		[Nullable(2)]
		private IEncircleArgs Param;

		// Token: 0x04025183 RID: 151939
		private readonly Dictionary<int, EncirclePlayMapItemView> ChildItems = new Dictionary<int, EncirclePlayMapItemView>();

		// Token: 0x04025184 RID: 151940
		[Nullable(2)]
		private ULGUIPlayTweenComponent Monster1PlayTweenComp;

		// Token: 0x04025185 RID: 151941
		[Nullable(2)]
		private ULGUIPlayTweenComponent Monster2PlayTweenComp;

		// Token: 0x04025186 RID: 151942
		[Nullable(2)]
		private FLGUIDelegateHandleWrapper EncirclePlayTweenEndCbWrapper1;

		// Token: 0x04025187 RID: 151943
		[Nullable(2)]
		private FLGUIDelegateHandleWrapper EncirclePlayTweenEndCbWrapper2;

		// Token: 0x04025188 RID: 151944
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;

		// Token: 0x04025189 RID: 151945
		[Nullable(2)]
		private Action OnTweenEnd;

		// Token: 0x0402518A RID: 151946
		private int CurrentStep;

		// Token: 0x0402518B RID: 151947
		private int DifficultyStep;

		// Token: 0x0402518C RID: 151948
		private bool CanNotClick;
	}
}
