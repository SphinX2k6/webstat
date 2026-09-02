using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200610A RID: 24842
	[NullableContext(1)]
	[Nullable(0)]
	public class StalkAlertMark : EntityHeadIconItem
	{
		// Token: 0x0603EC38 RID: 257080 RVA: 0x01012550 File Offset: 0x01010750
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC39 RID: 257081 RVA: 0x010125DC File Offset: 0x010107DC
		protected override void OnStart()
		{
			this.AlertBarItem = base.GetSprite(0);
			this.AlertIconItem = base.GetSprite(1);
			this.AlertArrowItem = base.GetItem(2);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SetActive(false);
		}

		// Token: 0x0603EC3A RID: 257082 RVA: 0x01012628 File Offset: 0x01010828
		public StalkAlertMark(UUIItem parent, AActor trackActor)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			base.CreateThenShowByResourceIdAsync("UiItem_Alert", parent, false).Forget();
			this.TrackingActor = trackActor;
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
			this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
		}

		// Token: 0x0603EC3B RID: 257083 RVA: 0x01012729 File Offset: 0x01010929
		public override void Update()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (this.RootItem == null)
			{
				return;
			}
			this.PositionUpdate();
			if (!this.RequestStopUpdateAlertValue)
			{
				this.AlertValueUpdate();
			}
			base.Update();
		}

		// Token: 0x0603EC3C RID: 257084 RVA: 0x01012758 File Offset: 0x01010958
		private void PositionUpdate()
		{
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation == null)
			{
				return;
			}
			TsCharacterController characterController = Global.CharacterController;
			CharacterAiComponent aiComp = this.AiComp;
			bool flag;
			if (aiComp == null)
			{
				flag = (null != null);
			}
			else
			{
				CharacterActorComponent charActorComp = aiComp.AiController.CharActorComp;
				flag = (((charActorComp != null) ? charActorComp.SkeletalMesh : null) != null);
			}
			FVectorDouble fvectorDouble;
			if (flag)
			{
				global::Vector trackPositionCache = this.TrackPositionCache;
				fvectorDouble = this.AiComp.AiController.CharActorComp.SkeletalMesh.D_K2_GetComponentLocation();
				trackPositionCache.DeepCopy(fvectorDouble);
				Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.AiComp.AiController.CharActorComp, this.TrackPositionCache, (double)this.AiComp.AiController.CharActorComp.HalfHeight);
			}
			else
			{
				global::Vector trackPositionCache2 = this.TrackPositionCache;
				fvectorDouble = this.TrackingActor.D_K2_GetActorLocation();
				trackPositionCache2.DeepCopy(fvectorDouble);
			}
			APlayerController player = characterController;
			fvectorDouble = this.TrackPositionCache.ToUeVector(false);
			bool flag2 = UGameplayStatics.D_ProjectWorldToScreen(player, fvectorDouble, ref this.ScreenPositionRef, false);
			if (!flag2)
			{
				this.TrackPositionCache.Subtraction(playerLocation, this.OffsetCache);
				Rotator.Create(Global.CharacterCameraManager.GetCameraRotation()).Vector(this.CameraForwardCache);
				fvectorDouble = this.OffsetCache.ToUeVector(false);
				FVector v = fvectorDouble;
				FVectorDouble fvectorDouble2 = this.CameraForwardCache.ToUeVector(false);
				FVector fvector = UKismetMathLibrary.ProjectVectorOnToVector(v, fvectorDouble2);
				FVector fvector2 = fvector * 2f;
				this.ProjectResult.Set((double)fvector2.X, (double)fvector2.Y, (double)fvector2.Z);
				this.OffsetCache.SubtractionEqual(this.ProjectResult);
				playerLocation.Addition(this.OffsetCache, this.TrackPositionCache);
				APlayerController player2 = characterController;
				fvectorDouble = this.TrackPositionCache.ToUeVector(false);
				UGameplayStatics.D_ProjectWorldToScreen(player2, fvectorDouble, ref this.ScreenPositionRef, false);
			}
			FVector2D screenPositionRef = this.ScreenPositionRef;
			int num = 0;
			int num2 = 0;
			characterController.GetViewportSize(ref num, ref num2);
			this.ScreenPosition.Set((double)screenPositionRef.X, (double)screenPositionRef.Y);
			this.ViewportSize.Set((double)(uiRootItem.GetWidth() * 0.5f), (double)(uiRootItem.GetHeight() * 0.5f));
			this.ScreenPosition.MultiplyEqual((double)(uiRootItem.GetWidth() / (float)num)).SubtractionEqual(this.ViewportSize).MultiplyEqual(this.PointTransport);
			bool flag3 = this.ClampToEllipse(this.ScreenPosition, flag2);
			Vector2D vector2D = this.ScreenPosition.AdditionEqual(TrackDefine.center);
			if (flag3)
			{
				double x = global::Vector.Distance(playerLocation, this.TrackPositionCache);
				vector2D.AdditionEqual(new Vector2D(0.0, this.GetOffsetY(x)));
			}
			this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
			UUIItem alertArrowItem = this.AlertArrowItem;
			if (alertArrowItem != null)
			{
				alertArrowItem.SetUIActive(!flag3);
			}
			UUIItem alertArrowItem2 = this.AlertArrowItem;
			if (alertArrowItem2 == null)
			{
				return;
			}
			FRotator frotator = new FRotator(0f, (float)(Math.Atan2(vector2D.Y, vector2D.X) * 180.0 / 3.141592653589793), 0f);
			alertArrowItem2.SetUIRelativeRotation(frotator);
		}

		// Token: 0x0603EC3D RID: 257085 RVA: 0x01012A6C File Offset: 0x01010C6C
		private bool ClampToEllipse(Vector2D vector, bool inFront)
		{
			double x = vector.X;
			double y = vector.Y;
			float limitA = this.LimitA;
			float limitB = this.LimitB;
			if (inFront && x * x / (double)(limitA * limitA) + y * y / (double)(limitB * limitB) <= 1.0)
			{
				return true;
			}
			float num = limitA * limitB / (float)Math.Sqrt((double)(limitB * limitB) * x * x + (double)(limitA * limitA) * y * y);
			vector.MultiplyEqual((double)num);
			return false;
		}

		// Token: 0x0603EC3E RID: 257086 RVA: 0x01012AE0 File Offset: 0x01010CE0
		private void AlertValueUpdate()
		{
			CharacterAiComponent aiComponent = this.AiComponent;
			float num = (aiComponent != null) ? aiComponent.AiController.AiAlert.AlertValue : 0f;
			this.AlertBarItem.SetFillAmount(Math.Clamp(num, 0f, 100f) / 100f);
			if (this.LastAlertValue == 0.0 && num > 0f)
			{
				if (this.AudioPath == null)
				{
					Audio? audio;
					this.AudioPath = ((ConfigBase<AudioConfig>.Instance.GetAudioPath("play_ui_fb_warn") != null) ? audio.GetValueOrDefault().Path : null);
				}
				if (!string.IsNullOrEmpty(this.AudioPath))
				{
					Singleton<AudioController>.Instance.PostEvent(this.AudioPath, null, null, null, null, null, true, "");
				}
			}
			this.LastAlertValue = (double)num;
		}

		// Token: 0x0603EC3F RID: 257087 RVA: 0x01012BC2 File Offset: 0x01010DC2
		private double GetOffsetY(double x)
		{
			return 367.327774667328 / (1.0 + Math.Pow(x / 537.430940553175, 1.11393060779131)) + 7.776280778151;
		}

		// Token: 0x0603EC40 RID: 257088 RVA: 0x01012BFB File Offset: 0x01010DFB
		public void SetAlertIcon(string iconType)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(iconType, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
			{
				if (sprite == null || !sprite.IsValid())
				{
					return;
				}
				UUIItem rootItem = this.RootItem;
				if (rootItem != null && rootItem.IsValid())
				{
					UUISprite alertIconItem = this.AlertIconItem;
					if (alertIconItem != null && alertIconItem.IsValid())
					{
						this.AlertIconItem.SetSprite(sprite, true);
						return;
					}
				}
			}, 100, "js_undefined");
		}

		// Token: 0x0603EC41 RID: 257089 RVA: 0x01012C1C File Offset: 0x01010E1C
		public void StopUpdateAlertValue()
		{
			this.RequestStopUpdateAlertValue = true;
		}

		// Token: 0x0603EC42 RID: 257090 RVA: 0x01012C28 File Offset: 0x01010E28
		public void ActivateAlertEffect()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Show", false, false, null, null, false);
			}
			this.PositionUpdate();
		}

		// Token: 0x0603EC43 RID: 257091 RVA: 0x01012C60 File Offset: 0x01010E60
		public bool CheckShowUiCondition()
		{
			if (this.AiComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.AI, ELogAuthor.CWZ, "警戒NPC不能正常获取AiComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			bool flag = this.TrackingActor.WasRecentlyRenderedOnScreen(0.2f) || this.AiComponent.AiController.AiAlert.CheckInAlertRange() || this.AiComponent.AiController.AiAlert.AlertValue > 0f;
			if (flag && !base.GetActive())
			{
				this.SetActive(true);
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
				}
			}
			if (!flag && base.GetActive())
			{
				this.SetActive(false);
			}
			return flag;
		}

		// Token: 0x17009AD3 RID: 39635
		// (get) Token: 0x0603EC44 RID: 257092 RVA: 0x01012D24 File Offset: 0x01010F24
		[Nullable(2)]
		public CharacterAiComponent AiComponent
		{
			[NullableContext(2)]
			get
			{
				if (this.AiComp == null)
				{
					EntityHandle entityByActor = ActorUtils.GetEntityByActor(this.TrackingActor, true);
					this.AiComp = entityByActor.Entity.GetComponent<CharacterAiComponent>();
				}
				return this.AiComp;
			}
		}

		// Token: 0x04023333 RID: 144179
		private const string ADD_AUDIO_ID = "play_ui_fb_warn";

		// Token: 0x04023334 RID: 144180
		[Nullable(2)]
		private readonly AActor TrackingActor;

		// Token: 0x04023335 RID: 144181
		[Nullable(2)]
		private UUISprite AlertBarItem;

		// Token: 0x04023336 RID: 144182
		[Nullable(2)]
		private UUISprite AlertIconItem;

		// Token: 0x04023337 RID: 144183
		[Nullable(2)]
		private UUIItem AlertArrowItem;

		// Token: 0x04023338 RID: 144184
		private FVector2D ScreenPositionRef = new FVector2D();

		// Token: 0x04023339 RID: 144185
		private readonly Vector2D ScreenPosition = Vector2D.Create();

		// Token: 0x0402333A RID: 144186
		private readonly Vector2D ViewportSize = Vector2D.Create();

		// Token: 0x0402333B RID: 144187
		private readonly Vector2D PointTransport = new Vector2D(1.0, -1.0);

		// Token: 0x0402333C RID: 144188
		private readonly global::Vector TrackPositionCache = global::Vector.Create();

		// Token: 0x0402333D RID: 144189
		private readonly global::Vector OffsetCache = global::Vector.Create();

		// Token: 0x0402333E RID: 144190
		private readonly global::Vector CameraForwardCache = global::Vector.Create();

		// Token: 0x0402333F RID: 144191
		private readonly global::Vector ProjectResult = global::Vector.Create();

		// Token: 0x04023340 RID: 144192
		private bool RequestStopUpdateAlertValue;

		// Token: 0x04023341 RID: 144193
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04023342 RID: 144194
		[Nullable(2)]
		private CharacterAiComponent AiComp;

		// Token: 0x04023343 RID: 144195
		private readonly float LimitA;

		// Token: 0x04023344 RID: 144196
		private readonly float LimitB;

		// Token: 0x04023345 RID: 144197
		private double LastAlertValue;

		// Token: 0x04023346 RID: 144198
		[Nullable(2)]
		private string AudioPath;

		// Token: 0x0200C296 RID: 49814
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403BFDB RID: 245723
			AlertBar,
			// Token: 0x0403BFDC RID: 245724
			AlertIcon,
			// Token: 0x0403BFDD RID: 245725
			AlertArrow
		}
	}
}
