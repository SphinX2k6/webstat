using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA8 RID: 23464
	[NullableContext(2)]
	[Nullable(0)]
	public class InteractionSpotView : UiPanelBase
	{
		// Token: 0x0603B5C1 RID: 243137 RVA: 0x00F09180 File Offset: 0x00F07380
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B5C2 RID: 243138 RVA: 0x00F0922C File Offset: 0x00F0742C
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(true);
			}
			this.RootActorRotation = new FRotator?(this.RootActor.K2_GetActorRotation());
			this.NormalSpotItem = base.GetItem(0);
			this.QuestSpotItem = base.GetItem(1);
			this.SpotProgressItem = base.GetItem(2);
			this.SpotProgressSprite = base.GetSprite(3);
			this.NormalSpotItem.SetUIActive(true);
			this.QuestSpotItem.SetUIActive(false);
			this.SpotProgressItem.SetUIActive(false);
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
			if (Singleton<Info>.Instance.IsMobileInputModel())
			{
				this.IsSelect = true;
			}
		}

		// Token: 0x0603B5C3 RID: 243139 RVA: 0x00F092F5 File Offset: 0x00F074F5
		protected override void OnBeforeShow()
		{
			this.TickEnabled = true;
			this.OnAddEventListener();
		}

		// Token: 0x0603B5C4 RID: 243140 RVA: 0x00F09304 File Offset: 0x00F07504
		protected override void OnBeforeHide()
		{
			this.TickEnabled = false;
			this.OnRemoveEventListener();
		}

		// Token: 0x0603B5C5 RID: 243141 RVA: 0x00F09313 File Offset: 0x00F07513
		protected override void OnAfterShow()
		{
			this.UpdateInteractionSpotPerform();
		}

		// Token: 0x0603B5C6 RID: 243142 RVA: 0x00F0931B File Offset: 0x00F0751B
		protected void OnAddEventListener()
		{
			if (this.OwnerEntity != null && this.OwnerEntity.Valid)
			{
				Singleton<EventSystem>.Instance.AddWithTarget<float>(this.OwnerEntity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange));
			}
		}

		// Token: 0x0603B5C7 RID: 243143 RVA: 0x00F09354 File Offset: 0x00F07554
		protected void OnRemoveEventListener()
		{
			if (this.OwnerEntity != null && this.OwnerEntity.Valid)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.OwnerEntity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange));
			}
		}

		// Token: 0x0603B5C8 RID: 243144 RVA: 0x00F09390 File Offset: 0x00F07590
		public void DestroySelf(Action callback)
		{
			this.TickEnabled = false;
			this.InDestroyAnim = true;
			this.DestroyCallback = callback;
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, false);
			}
			if (this.SeqPlayer == null)
			{
				base.Destroy(this.DestroyCallback);
				return;
			}
			if (this.LastShowInner.GetValueOrDefault())
			{
				this.DestroyAnimName = "SetOut";
				this.SeqPlayer.PlayLevelSequenceByName("SetOut", false, null, false);
				return;
			}
			this.DestroyAnimName = "NorOut";
			this.SeqPlayer.PlayLevelSequenceByName("NorOut", false, null, false);
		}

		// Token: 0x0603B5C9 RID: 243145 RVA: 0x00F09434 File Offset: 0x00F07634
		public void Update()
		{
			if (this.OwnerActor == null || !this.TickEnabled || this.InDestroyAnim)
			{
				return;
			}
			APlayerController characterController = Global.CharacterController;
			FTransformDouble ftransformDouble = this.OwnerActor.D_GetTransform();
			FVectorDouble fvectorDouble = this.Offset.ToUeVector(false);
			FVectorDouble fvectorDouble2 = ftransformDouble.TransformPositionNoScale(fvectorDouble);
			FVector fvector = fvectorDouble2;
			FVector2D fvector2D = new FVector2D();
			fvectorDouble = fvector;
			if (!UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref fvector2D, false))
			{
				this.RootItem.SetUIActive(false);
				return;
			}
			this.RootItem.SetUIActive(true);
			this.ScreenPosition.Set((double)fvector2D.X, (double)fvector2D.Y);
			if (this.LastScreenPosition.Equals(this.ScreenPosition, 1.0))
			{
				return;
			}
			this.LastScreenPosition.DeepCopy(this.ScreenPosition);
			Vector2D vector2D = Vector2D.Create((double)fvector2D.X, (double)fvector2D.Y);
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			vector2D.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(Vector2D.Create(1.0, -1.0)).AdditionEqual(InteractionSpotView.center);
			this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
		}

		// Token: 0x0603B5CA RID: 243146 RVA: 0x00F09576 File Offset: 0x00F07776
		public void SetOwnerEntity(Entity entity)
		{
			this.OwnerEntity = entity;
		}

		// Token: 0x0603B5CB RID: 243147 RVA: 0x00F0957F File Offset: 0x00F0777F
		public void SetOwnerActor(AActor ownerActor)
		{
			this.OwnerActor = ownerActor;
		}

		// Token: 0x0603B5CC RID: 243148 RVA: 0x00F09588 File Offset: 0x00F07788
		public void SetIsSelect(bool isSelect)
		{
			if (this.InDestroyAnim)
			{
				return;
			}
			this.IsSelect = isSelect;
			this.UpdateInteractionSpotPerform();
		}

		// Token: 0x0603B5CD RID: 243149 RVA: 0x00F095A0 File Offset: 0x00F077A0
		public void SetIsInEntityInteractRange(bool isInEntityInteractRange)
		{
			if (this.InDestroyAnim)
			{
				return;
			}
			this.IsInEntityInteractRange = isInEntityInteractRange;
			this.UpdateInteractionSpotPerform();
		}

		// Token: 0x0603B5CE RID: 243150 RVA: 0x00F095B8 File Offset: 0x00F077B8
		public void SetIsTracking(bool isTracking)
		{
			if (this.InDestroyAnim)
			{
				return;
			}
			this.IsTracking = isTracking;
			this.UpdateInteractionSpotPerform();
		}

		// Token: 0x0603B5CF RID: 243151 RVA: 0x00F095D0 File Offset: 0x00F077D0
		public void SetIsObstruct(bool isObstruct)
		{
			if (this.InDestroyAnim)
			{
				return;
			}
			this.IsObstruct = isObstruct;
			this.UpdateInteractionSpotPerform();
		}

		// Token: 0x0603B5D0 RID: 243152 RVA: 0x00F095E8 File Offset: 0x00F077E8
		[NullableContext(1)]
		public void SetOffset(Vector offset)
		{
			this.Offset.DeepCopy(offset);
		}

		// Token: 0x0603B5D1 RID: 243153 RVA: 0x00F095F6 File Offset: 0x00F077F6
		public void SetSuppressLongPressProgress(bool suppress)
		{
			if (this.InDestroyAnim)
			{
				return;
			}
			this.SuppressLongPressProgress = suppress;
			if (suppress)
			{
				UUIItem spotProgressItem = this.SpotProgressItem;
				if (spotProgressItem == null)
				{
					return;
				}
				spotProgressItem.SetUIActive(false);
			}
		}

		// Token: 0x0603B5D2 RID: 243154 RVA: 0x00F0961C File Offset: 0x00F0781C
		private void OnInteractionLongPressProgressChange(float progress)
		{
			if (this.SuppressLongPressProgress)
			{
				this.SpotProgressItem.SetUIActive(false);
				return;
			}
			if (progress > 0f)
			{
				this.SpotProgressSprite.SetFillAmount(progress);
				this.SpotProgressItem.SetUIActive(true);
				return;
			}
			this.SpotProgressItem.SetUIActive(false);
		}

		// Token: 0x0603B5D3 RID: 243155 RVA: 0x00F0966C File Offset: 0x00F0786C
		private void UpdateInteractionSpotPerform()
		{
			if (this.InDestroyAnim)
			{
				return;
			}
			bool flag = this.IsSelect && this.IsInEntityInteractRange;
			if (this.IsTracking)
			{
				this.NormalSpotItem.SetUIActive(false);
				this.QuestSpotItem.SetUIActive(true);
			}
			else
			{
				this.NormalSpotItem.SetUIActive(true);
				this.QuestSpotItem.SetUIActive(false);
			}
			bool? lastShowInner = this.LastShowInner;
			bool flag2 = flag;
			if (!(lastShowInner.GetValueOrDefault() == flag2 & lastShowInner != null))
			{
				this.OnShowInnerChange(flag);
				this.LastShowInner = new bool?(flag);
			}
			this.NormalSpotItem.SetAlpha(this.IsObstruct ? 0.3f : 1f);
			this.QuestSpotItem.SetAlpha(this.IsObstruct ? 0.3f : 1f);
			this.SpotProgressSprite.SetAlpha(this.IsObstruct ? 0.3f : 1f);
		}

		// Token: 0x0603B5D4 RID: 243156 RVA: 0x00F0975C File Offset: 0x00F0795C
		private void OnShowInnerChange(bool showInner)
		{
			if (this.InDestroyAnim)
			{
				return;
			}
			this.NeedAnimTransition = false;
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, false);
			}
			if (this.LastShowInner == null)
			{
				if (!showInner)
				{
					LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
					if (seqPlayer2 != null)
					{
						seqPlayer2.PlayLevelSequenceByName("Start", false, null, false);
					}
					this.NeedAnimTransition = this.IsTracking;
					return;
				}
				LevelSequencePlayer seqPlayer3 = this.SeqPlayer;
				if (seqPlayer3 == null)
				{
					return;
				}
				seqPlayer3.PlayLevelSequenceByName("Select", false, null, false);
				return;
			}
			else
			{
				bool? lastShowInner = this.LastShowInner;
				bool flag = false;
				if (!(lastShowInner.GetValueOrDefault() == flag & lastShowInner != null))
				{
					if (this.LastShowInner.GetValueOrDefault())
					{
						this.NeedAnimTransition = this.IsTracking;
						LevelSequencePlayer seqPlayer4 = this.SeqPlayer;
						if (seqPlayer4 == null)
						{
							return;
						}
						seqPlayer4.PlayLevelSequenceByName("UnSelect", false, null, false);
					}
					return;
				}
				LevelSequencePlayer seqPlayer5 = this.SeqPlayer;
				if (seqPlayer5 == null)
				{
					return;
				}
				seqPlayer5.PlayLevelSequenceByName("Select", false, null, false);
				return;
			}
		}

		// Token: 0x0603B5D5 RID: 243157 RVA: 0x00F09864 File Offset: 0x00F07A64
		[NullableContext(1)]
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (this.InDestroyAnim && this.DestroyAnimName == sequenceName)
			{
				Action destroyCallback = this.DestroyCallback;
				this.DestroyCallback = null;
				base.Destroy(destroyCallback);
				return;
			}
			if (this.InDestroyAnim)
			{
				return;
			}
			if (!this.NeedAnimTransition)
			{
				return;
			}
			this.NeedAnimTransition = false;
			if (!(sequenceName == "NorOut"))
			{
				if (sequenceName == "Start" || sequenceName == "UnSelect")
				{
					LevelSequencePlayer seqPlayer = this.SeqPlayer;
					if (seqPlayer == null)
					{
						return;
					}
					seqPlayer.PlayLevelSequenceByName("Loop", false, null, false);
				}
				return;
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 == null)
			{
				return;
			}
			seqPlayer2.PlayLevelSequenceByName("Select", false, null, false);
		}

		// Token: 0x04021737 RID: 137015
		private const float CENTER_Y = 62.5f;

		// Token: 0x04021738 RID: 137016
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Vector2D center = Vector2D.Create(0.0, 62.5);

		// Token: 0x04021739 RID: 137017
		protected FRotator? RootActorRotation;

		// Token: 0x0402173A RID: 137018
		private UUIItem NormalSpotItem;

		// Token: 0x0402173B RID: 137019
		private UUIItem QuestSpotItem;

		// Token: 0x0402173C RID: 137020
		private UUIItem SpotProgressItem;

		// Token: 0x0402173D RID: 137021
		private UUISprite SpotProgressSprite;

		// Token: 0x0402173E RID: 137022
		private bool IsSelect;

		// Token: 0x0402173F RID: 137023
		private bool IsInEntityInteractRange;

		// Token: 0x04021740 RID: 137024
		private bool IsTracking;

		// Token: 0x04021741 RID: 137025
		private bool IsObstruct;

		// Token: 0x04021742 RID: 137026
		private bool SuppressLongPressProgress;

		// Token: 0x04021743 RID: 137027
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x04021744 RID: 137028
		private bool? LastShowInner;

		// Token: 0x04021745 RID: 137029
		private bool NeedAnimTransition;

		// Token: 0x04021746 RID: 137030
		private bool InDestroyAnim;

		// Token: 0x04021747 RID: 137031
		private string DestroyAnimName;

		// Token: 0x04021748 RID: 137032
		private Action DestroyCallback;

		// Token: 0x04021749 RID: 137033
		private Entity OwnerEntity;

		// Token: 0x0402174A RID: 137034
		private AActor OwnerActor;

		// Token: 0x0402174B RID: 137035
		[Nullable(1)]
		private readonly Vector Offset = Vector.Create();

		// Token: 0x0402174C RID: 137036
		[Nullable(1)]
		protected readonly Vector2D ScreenPosition = Vector2D.Create();

		// Token: 0x0402174D RID: 137037
		[Nullable(1)]
		private readonly Vector2D LastScreenPosition = Vector2D.Create();

		// Token: 0x0402174E RID: 137038
		private bool TickEnabled;

		// Token: 0x0200BBE0 RID: 48096
		[NullableContext(0)]
		private class ESpotViewDefine
		{
			// Token: 0x04039F78 RID: 237432
			public const int NormalSpot = 0;

			// Token: 0x04039F79 RID: 237433
			public const int QuestSpot = 1;

			// Token: 0x04039F7A RID: 237434
			public const int SpotProgressItem = 2;

			// Token: 0x04039F7B RID: 237435
			public const int SpotProgressSprite = 3;
		}
	}
}
