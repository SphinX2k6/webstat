using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA9 RID: 23465
	[NullableContext(1)]
	[Nullable(0)]
	public class InteractionTipsView : UiPanelBase
	{
		// Token: 0x0603B5D8 RID: 243160 RVA: 0x00F09968 File Offset: 0x00F07B68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B5D9 RID: 243161 RVA: 0x00F099D4 File Offset: 0x00F07BD4
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(false);
			}
			this.TweenAnimPlayer.InitTweenAnim(0, base.GetItem(0), false);
			this.TweenAnimPlayer.InitTweenAnim(1, base.GetItem(1), false);
			this.AddTick();
		}

		// Token: 0x0603B5DA RID: 243162 RVA: 0x00F09A21 File Offset: 0x00F07C21
		protected override void OnBeforeShow()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Resume(this.TickId);
			}
			this.TweenAnimPlayer.StopTweenAnim(1);
			this.TweenAnimPlayer.PlayTweenAnim(0);
		}

		// Token: 0x0603B5DB RID: 243163 RVA: 0x00F09A58 File Offset: 0x00F07C58
		protected override UniTask OnBeforeHideAsync()
		{
			InteractionTipsView.<OnBeforeHideAsync>d__11 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<InteractionTipsView.<OnBeforeHideAsync>d__11>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B5DC RID: 243164 RVA: 0x00F09A9B File Offset: 0x00F07C9B
		protected override void OnAfterHide()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
		}

		// Token: 0x0603B5DD RID: 243165 RVA: 0x00F09AB7 File Offset: 0x00F07CB7
		protected override void OnBeforeDestroy()
		{
			this.RemoveTick();
		}

		// Token: 0x0603B5DE RID: 243166 RVA: 0x00F09ABF File Offset: 0x00F07CBF
		public void SetEnable(bool b)
		{
			this.IsEnable = b;
			this.Update();
		}

		// Token: 0x0603B5DF RID: 243167 RVA: 0x00F09ACE File Offset: 0x00F07CCE
		private void AddTick()
		{
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "InteractionTipsView", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x0603B5E0 RID: 243168 RVA: 0x00F09AFA File Offset: 0x00F07CFA
		private void RemoveTick()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
		}

		// Token: 0x0603B5E1 RID: 243169 RVA: 0x00F09B1D File Offset: 0x00F07D1D
		private void OnTick(float delta)
		{
			this.Update();
		}

		// Token: 0x0603B5E2 RID: 243170 RVA: 0x00F09B28 File Offset: 0x00F07D28
		private void Update()
		{
			if (this.OwnerActor == null || !this.IsEnable)
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetUIActive(false);
				return;
			}
			else if (this.OwnerEntity == null || !SceneItemCaptureController.IsVisible(this.OwnerEntity))
			{
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 == null)
				{
					return;
				}
				rootItem2.SetUIActive(false);
				return;
			}
			else
			{
				APlayerController playerController = Global.PlayerController;
				FTransformDouble ftransformDouble = this.OwnerActor.D_GetTransform();
				FVectorDouble fvectorDouble = this.Offset.ToUeVector(false);
				FVectorDouble fvectorDouble2 = ftransformDouble.TransformPositionNoScale(fvectorDouble);
				FVector2D fvector2D = new FVector2D();
				if (!UGameplayStatics.D_ProjectWorldToScreen(playerController, fvectorDouble2, ref fvector2D, false))
				{
					if (this.RootItem.IsUIActiveSelf())
					{
						this.RootItem.SetUIActive(false);
					}
					return;
				}
				if (!this.RootItem.IsUIActiveSelf())
				{
					this.RootItem.SetUIActive(true);
					this.TweenAnimPlayer.StopTweenAnim(1);
					this.TweenAnimPlayer.PlayTweenAnim(0);
				}
				Vector2D screenPosition = this.ScreenPosition;
				screenPosition.Set((double)fvector2D.X, (double)fvector2D.Y);
				if (this.LastScreenPosition.Equals(screenPosition, 0.10000000149011612))
				{
					return;
				}
				this.LastScreenPosition.DeepCopy(screenPosition);
				screenPosition.MultiplyEqual((double)ModelBase<BattleUiModel>.Instance.ScreenPositionScale).AdditionEqual(ModelBase<BattleUiModel>.Instance.ScreenPositionOffset).MultiplyEqual(Vector2D.Create(1.0, -1.0));
				this.RootItem.SetAnchorOffset(screenPosition.ToUeVector2D(false));
				return;
			}
		}

		// Token: 0x0603B5E3 RID: 243171 RVA: 0x00F09C93 File Offset: 0x00F07E93
		[NullableContext(2)]
		public void SetOwnerEntity(Entity entity)
		{
			this.OwnerEntity = entity;
			AActor ownerActor;
			if (entity == null)
			{
				ownerActor = null;
			}
			else
			{
				BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
				ownerActor = ((component != null) ? component.Owner : null);
			}
			this.OwnerActor = ownerActor;
		}

		// Token: 0x0603B5E4 RID: 243172 RVA: 0x00F09CBA File Offset: 0x00F07EBA
		public void SetOffset(Vector offset)
		{
			this.Offset.DeepCopy(offset);
		}

		// Token: 0x0603B5E5 RID: 243173 RVA: 0x00F09CC8 File Offset: 0x00F07EC8
		public void DestroySelf(Action callback = null)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(false);
			}
			base.Destroy(callback);
		}

		// Token: 0x0402174F RID: 137039
		[Nullable(2)]
		private AActor OwnerActor;

		// Token: 0x04021750 RID: 137040
		[Nullable(2)]
		private Entity OwnerEntity;

		// Token: 0x04021751 RID: 137041
		private readonly BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x04021752 RID: 137042
		private readonly Vector Offset = Vector.Create();

		// Token: 0x04021753 RID: 137043
		protected readonly Vector2D ScreenPosition = Vector2D.Create();

		// Token: 0x04021754 RID: 137044
		private readonly Vector2D LastScreenPosition = Vector2D.Create();

		// Token: 0x04021755 RID: 137045
		private bool IsEnable;

		// Token: 0x04021756 RID: 137046
		private int TickId = -1;

		// Token: 0x0200BBE1 RID: 48097
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039F7C RID: 237436
			public const int AniIn = 0;

			// Token: 0x04039F7D RID: 237437
			public const int AniOut = 1;
		}
	}
}
