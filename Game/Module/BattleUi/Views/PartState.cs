using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200608C RID: 24716
	[NullableContext(1)]
	[Nullable(0)]
	public class PartState : BattleVisibleChildView
	{
		// Token: 0x0603E5B6 RID: 255414 RVA: 0x00FECC94 File Offset: 0x00FEAE94
		public PartState(Entity entity, CharacterPart part)
		{
			PartState.<>c__DisplayClass18_0 CS$<>8__locals1 = new PartState.<>c__DisplayClass18_0();
			CS$<>8__locals1.entity = entity;
			CS$<>8__locals1.part = part;
			base..ctor();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("UiItem_PartState_Prefab");
			UniTask.Create(delegate()
			{
				PartState.<>c__DisplayClass18_0.<<-ctor>b__0>d <<-ctor>b__0>d;
				<<-ctor>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<-ctor>b__0>d.<>4__this = CS$<>8__locals1;
				<<-ctor>b__0>d.<>1__state = -1;
				<<-ctor>b__0>d.<>t__builder.Start<PartState.<>c__DisplayClass18_0.<<-ctor>b__0>d>(ref <<-ctor>b__0>d);
				return <<-ctor>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0603E5B7 RID: 255415 RVA: 0x00FECD00 File Offset: 0x00FEAF00
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E5B8 RID: 255416 RVA: 0x00FECD8A File Offset: 0x00FEAF8A
		protected override void OnStart()
		{
			this.HpParentWidth = base.GetSprite(2).GetParentAsUIItem().GetWidth();
		}

		// Token: 0x0603E5B9 RID: 255417 RVA: 0x00FECDA3 File Offset: 0x00FEAFA3
		protected override void OnBeforeDestroy()
		{
			this.ResetPartState();
		}

		// Token: 0x0603E5BA RID: 255418 RVA: 0x00FECDAC File Offset: 0x00FEAFAC
		public void InitializePartState(Entity entity, CharacterPart part)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null || !rootItem.IsValid())
			{
				return;
			}
			this.Entity = entity;
			this.Part = part;
			this.PlayerController = Global.CharacterController;
			this.SocketName = part.PartSocketName;
			TsBaseCharacter actor = this.Entity.GetComponent<CharacterActorComponent>().Actor;
			this.SkeletalMesh = actor.Mesh;
			base.InitChildType(EBattleUiChild.PartState);
			this.RefreshValid();
			if (!this.IsPartValid)
			{
				this.HideBattleVisibleChildView();
				return;
			}
			this.RefreshHpBar(false);
			this.RefreshPosition();
			this.ShowBattleVisibleChildView(false);
			if (part.HitPartStateVisibleDuration > 0f)
			{
				base.SetVisible(3, false);
			}
			this.AddEvents();
		}

		// Token: 0x0603E5BB RID: 255419 RVA: 0x00FECE60 File Offset: 0x00FEB060
		private void RefreshValid()
		{
			if (this.Entity == null)
			{
				this.IsPartValid = false;
				Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.CFT, "怪物部位血条非法：不存在Entity", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.SkeletalMesh == null)
			{
				this.IsPartValid = false;
				Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.CFT, "怪物部位血条非法：不存在SkeletalMesh", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!this.SkeletalMesh.DoesSocketExist(this.SocketName.Value))
			{
				this.IsPartValid = false;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "怪物部位血条非法：不存在SocketName";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(string.Empty, this.SocketName.Value);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.IsPartValid = true;
		}

		// Token: 0x0603E5BC RID: 255420 RVA: 0x00FECF24 File Offset: 0x00FEB124
		public void ResetPartState()
		{
			if (this.IsPartValid)
			{
				this.RemoveEvents();
				this.StopBarLerpAnimation();
			}
			this.Entity = null;
			this.Part = null;
			this.PlayerController = null;
			this.SkeletalMesh = null;
			this.CurrentBarPercent = null;
			this.IsPartValid = false;
		}

		// Token: 0x0603E5BD RID: 255421 RVA: 0x00FECF74 File Offset: 0x00FEB174
		private void AddEvents()
		{
			if (!Singleton<EventSystem>.Instance.HasWithTarget<float, CharacterPart>(this.Entity, EEventName.CharPartDamage, new Action<float, CharacterPart>(this.OnCharacterApplyDamage)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<float, CharacterPart>(this.Entity, EEventName.CharPartDamage, new Action<float, CharacterPart>(this.OnCharacterApplyDamage));
			}
		}

		// Token: 0x0603E5BE RID: 255422 RVA: 0x00FECFC0 File Offset: 0x00FEB1C0
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<float, CharacterPart>(this.Entity, EEventName.CharPartDamage, new Action<float, CharacterPart>(this.OnCharacterApplyDamage));
		}

		// Token: 0x0603E5BF RID: 255423 RVA: 0x00FECFE4 File Offset: 0x00FEB1E4
		private void OnCharacterApplyDamage(float damage, CharacterPart part)
		{
			float life = this.Part.Life;
			base.SetVisible(2, life > 0f);
			this.RefreshHpBar(true);
			this.HandleHitTimerOnDamage(part, damage);
		}

		// Token: 0x0603E5C0 RID: 255424 RVA: 0x00FED01C File Offset: 0x00FEB21C
		private void HandleHitTimerOnDamage(CharacterPart part, float damage)
		{
			if (part.Index != this.Part.Index)
			{
				return;
			}
			if (damage <= 0f)
			{
				return;
			}
			float hitPartStateVisibleDuration = this.Part.HitPartStateVisibleDuration;
			if (hitPartStateVisibleDuration > 0f)
			{
				this.HitTimerRemaining = hitPartStateVisibleDuration * 1000f;
				base.SetVisible(3, true);
			}
		}

		// Token: 0x0603E5C1 RID: 255425 RVA: 0x00FED070 File Offset: 0x00FEB270
		private void RefreshHpBar(bool bPlayBarAnimation = false)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			float life = this.Part.Life;
			float lifeMax = this.Part.LifeMax;
			float num = life / lifeMax;
			sprite.SetFillAmount(life / lifeMax);
			if (bPlayBarAnimation)
			{
				double value = this.CurrentBarPercent.GetValueOrDefault();
				if (this.CurrentBarPercent == null)
				{
					value = (double)num;
					this.CurrentBarPercent = new double?(value);
				}
				this.PlayBarAnimation((double)num);
				return;
			}
			this.StopBarLerpAnimation();
			this.CurrentBarPercent = new double?((double)num);
		}

		// Token: 0x0603E5C2 RID: 255426 RVA: 0x00FED0F8 File Offset: 0x00FEB2F8
		private void PlayBarAnimation(double hpPercent)
		{
			double value = this.CurrentBarPercent.Value;
			bool flag = this.HpMachine.IsOriginState();
			if (hpPercent >= value)
			{
				if (flag)
				{
					this.CurrentBarPercent = new double?(hpPercent);
				}
				return;
			}
			this.HpMachine.GetHit((float)hpPercent, (float)value);
			this.TargetBarPercent = hpPercent;
			this.SourceBarPercent = value;
			this.CurrentBarPercent = new double?(hpPercent);
			this.AnimTime = 0f;
			if (flag && !this.HpMachine.IsOriginState())
			{
				this.OnBeginBarAnimation(value);
			}
		}

		// Token: 0x0603E5C3 RID: 255427 RVA: 0x00FED17E File Offset: 0x00FEB37E
		private void OnBeginBarAnimation(double hpPercent)
		{
			this.SetBarBufferPercent(hpPercent);
		}

		// Token: 0x0603E5C4 RID: 255428 RVA: 0x00FED188 File Offset: 0x00FEB388
		private void StopBarLerpAnimation()
		{
			this.TargetBarPercent = 0.0;
			this.SourceBarPercent = 0.0;
			this.AnimTime = -1f;
			this.HpMachine.Reset();
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x0603E5C5 RID: 255429 RVA: 0x00FED1D8 File Offset: 0x00FEB3D8
		private void RefreshBarBuffPercent(double? percent = null)
		{
			if (percent != null && Math.Abs(this.BufferPercent - percent.Value) < 0.009999999776482582)
			{
				return;
			}
			if (percent == null)
			{
				this.OnLerpBarBufferPercent(this.CurrentBarPercent.Value);
			}
			else
			{
				this.OnLerpBarBufferPercent(percent.Value);
			}
			this.BufferPercent = percent.GetValueOrDefault();
		}

		// Token: 0x0603E5C6 RID: 255430 RVA: 0x00FED243 File Offset: 0x00FEB443
		private void OnLerpBarBufferPercent(double percent)
		{
			this.SetBarBufferPercent(percent);
		}

		// Token: 0x0603E5C7 RID: 255431 RVA: 0x00FED24C File Offset: 0x00FEB44C
		private void SetBarBufferPercent(double percent)
		{
			UUISprite sprite = base.GetSprite(1);
			sprite.SetFillAmount((float)percent);
			if (!sprite.IsUIActiveSelf())
			{
				sprite.SetUIActive(true);
			}
			UUISprite sprite2 = base.GetSprite(2);
			sprite2.SetStretchLeft((float)((double)this.HpParentWidth * this.CurrentBarPercent - (double)2).Value);
			sprite2.SetStretchRight((float)((double)this.HpParentWidth * (1.0 - percent) - 2.0));
		}

		// Token: 0x0603E5C8 RID: 255432 RVA: 0x00FED30C File Offset: 0x00FEB50C
		public void RefreshPosition()
		{
			if (!this.IsPartValid)
			{
				return;
			}
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			if (uiRootItem == null)
			{
				return;
			}
			FVectorDouble fvectorDouble = this.SkeletalMesh.D_GetSocketLocation(this.SocketName.Value);
			if (!UGameplayStatics.D_ProjectWorldToScreen(this.PlayerController, fvectorDouble, ref this.PositionRef, false))
			{
				base.SetVisible(1, false);
				return;
			}
			FVector2D anchorOffset = uiRootItem.GetCanvasScaler().ConvertPositionFromViewportToLGUICanvas(this.PositionRef);
			this.RootItem.SetAnchorOffset(anchorOffset);
			base.SetVisible(1, true);
		}

		// Token: 0x0603E5C9 RID: 255433 RVA: 0x00FED390 File Offset: 0x00FEB590
		public void Tick(float delta)
		{
			if (!this.IsPartValid)
			{
				return;
			}
			this.RefreshPosition();
			this.LerpBarPercent(delta);
			if (this.HitTimerRemaining > 0f)
			{
				this.HitTimerRemaining -= delta;
				if (this.HitTimerRemaining <= 0f)
				{
					this.HitTimerRemaining = 0f;
					base.SetVisible(3, false);
				}
			}
		}

		// Token: 0x0603E5CA RID: 255434 RVA: 0x00FED3F0 File Offset: 0x00FEB5F0
		private void LerpBarPercent(float delta)
		{
			if (this.AnimTime == -1f)
			{
				return;
			}
			float num = this.HpMachine.UpdatePercent(delta);
			if (num < 0f)
			{
				this.StopBarLerpAnimation();
			}
			else
			{
				this.RefreshBarBuffPercent(new double?((double)num));
			}
			if (this.TargetBarPercent >= this.SourceBarPercent)
			{
				return;
			}
			this.AnimTime += delta;
		}

		// Token: 0x04022F2D RID: 143149
		private const float PERCENT_TOLERATION = 0.01f;

		// Token: 0x04022F2E RID: 143150
		[Nullable(2)]
		private Entity Entity;

		// Token: 0x04022F2F RID: 143151
		[Nullable(2)]
		private CharacterPart Part;

		// Token: 0x04022F30 RID: 143152
		[Nullable(2)]
		private APlayerController PlayerController;

		// Token: 0x04022F31 RID: 143153
		private FName? SocketName;

		// Token: 0x04022F32 RID: 143154
		private FVector2D PositionRef;

		// Token: 0x04022F33 RID: 143155
		[Nullable(2)]
		private USkeletalMeshComponent SkeletalMesh;

		// Token: 0x04022F34 RID: 143156
		private bool IsPartValid;

		// Token: 0x04022F35 RID: 143157
		private float HitTimerRemaining;

		// Token: 0x04022F36 RID: 143158
		private double? CurrentBarPercent;

		// Token: 0x04022F37 RID: 143159
		private double TargetBarPercent;

		// Token: 0x04022F38 RID: 143160
		private double SourceBarPercent;

		// Token: 0x04022F39 RID: 143161
		private float AnimTime = -1f;

		// Token: 0x04022F3A RID: 143162
		private double BufferPercent;

		// Token: 0x04022F3B RID: 143163
		private readonly HpBufferStateMachine HpMachine = new HpBufferStateMachine();

		// Token: 0x04022F3C RID: 143164
		private float HpParentWidth;

		// Token: 0x0200C178 RID: 49528
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B939 RID: 244025
			HpBarSprite,
			// Token: 0x0403B93A RID: 244026
			BarBufferSprite,
			// Token: 0x0403B93B RID: 244027
			HpLight
		}

		// Token: 0x0200C179 RID: 49529
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403B93D RID: 244029
			Default,
			// Token: 0x0403B93E RID: 244030
			Outside,
			// Token: 0x0403B93F RID: 244031
			Hp,
			// Token: 0x0403B940 RID: 244032
			HitTimer
		}
	}
}
