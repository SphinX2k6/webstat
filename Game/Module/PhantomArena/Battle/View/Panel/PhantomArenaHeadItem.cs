using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055BE RID: 21950
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaHeadItem : UiPanelBase
	{
		// Token: 0x06037E49 RID: 228937 RVA: 0x00E295C8 File Offset: 0x00E277C8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite))
			};
		}

		// Token: 0x06037E4A RID: 228938 RVA: 0x00E29650 File Offset: 0x00E27850
		protected UniTask InitAddHpItem()
		{
			PhantomArenaHeadItem.<InitAddHpItem>d__8 <InitAddHpItem>d__;
			<InitAddHpItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAddHpItem>d__.<>4__this = this;
			<InitAddHpItem>d__.<>1__state = -1;
			<InitAddHpItem>d__.<>t__builder.Start<PhantomArenaHeadItem.<InitAddHpItem>d__8>(ref <InitAddHpItem>d__);
			return <InitAddHpItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E4B RID: 228939 RVA: 0x00E29693 File Offset: 0x00E27893
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnDamageAccumulateEnd), false);
			this.RefreshDamageBar(0f);
		}

		// Token: 0x06037E4C RID: 228940 RVA: 0x00E296CC File Offset: 0x00E278CC
		private UniTask InitDialogItem()
		{
			PhantomArenaHeadItem.<InitDialogItem>d__10 <InitDialogItem>d__;
			<InitDialogItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDialogItem>d__.<>4__this = this;
			<InitDialogItem>d__.<>1__state = -1;
			<InitDialogItem>d__.<>t__builder.Start<PhantomArenaHeadItem.<InitDialogItem>d__10>(ref <InitDialogItem>d__);
			return <InitDialogItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E4D RID: 228941 RVA: 0x00E29710 File Offset: 0x00E27910
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaHeadItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaHeadItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037E4E RID: 228942 RVA: 0x00E29753 File Offset: 0x00E27953
		public void SetBarActive(bool isOwn)
		{
			base.GetSprite(1).SetUIActive(isOwn);
			base.GetSprite(2).SetUIActive(!isOwn);
		}

		// Token: 0x06037E4F RID: 228943 RVA: 0x00E29772 File Offset: 0x00E27972
		public void RefreshLifeBar(float fillAmount)
		{
			base.GetSprite(2).SetFillAmount(fillAmount);
			base.GetSprite(1).SetFillAmount(fillAmount);
		}

		// Token: 0x06037E50 RID: 228944 RVA: 0x00E2978E File Offset: 0x00E2798E
		public void RefreshDamageBar(float fillAmount)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(fillAmount);
		}

		// Token: 0x06037E51 RID: 228945 RVA: 0x00E297A4 File Offset: 0x00E279A4
		public void RefreshRoleIcon(string headIcon)
		{
			base.SetTextureByPath(headIcon, base.GetTexture(0), null, null);
		}

		// Token: 0x06037E52 RID: 228946 RVA: 0x00E297C9 File Offset: 0x00E279C9
		public UUIItem GetAttachItem()
		{
			return base.GetItem(3);
		}

		// Token: 0x06037E53 RID: 228947 RVA: 0x00E297D4 File Offset: 0x00E279D4
		public void PlayAccumulateDamage()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName(EPhantomBattleHeadAnim.DamageAccumulate.ToString(), false, null, false);
		}

		// Token: 0x06037E54 RID: 228948 RVA: 0x00E2980C File Offset: 0x00E27A0C
		public UniTask PlayAddHpEffect(int addCount)
		{
			PhantomArenaHeadItem.<PlayAddHpEffect>d__18 <PlayAddHpEffect>d__;
			<PlayAddHpEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAddHpEffect>d__.<>4__this = this;
			<PlayAddHpEffect>d__.addCount = addCount;
			<PlayAddHpEffect>d__.<>1__state = -1;
			<PlayAddHpEffect>d__.<>t__builder.Start<PhantomArenaHeadItem.<PlayAddHpEffect>d__18>(ref <PlayAddHpEffect>d__);
			return <PlayAddHpEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037E55 RID: 228949 RVA: 0x00E29858 File Offset: 0x00E27A58
		public UniTask PlayReduceHpEffect(int reduceCount)
		{
			PhantomArenaHeadItem.<PlayReduceHpEffect>d__19 <PlayReduceHpEffect>d__;
			<PlayReduceHpEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayReduceHpEffect>d__.<>4__this = this;
			<PlayReduceHpEffect>d__.reduceCount = reduceCount;
			<PlayReduceHpEffect>d__.<>1__state = -1;
			<PlayReduceHpEffect>d__.<>t__builder.Start<PhantomArenaHeadItem.<PlayReduceHpEffect>d__19>(ref <PlayReduceHpEffect>d__);
			return <PlayReduceHpEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037E56 RID: 228950 RVA: 0x00E298A3 File Offset: 0x00E27AA3
		private void OnDamageAccumulateEnd(string name)
		{
			if (name != EPhantomBattleHeadAnim.DamageAccumulate.ToString())
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaBattleDamageAccumulateEnd);
		}

		// Token: 0x0401FFC3 RID: 131011
		public PhantomArenaDialogItem DialogItem;

		// Token: 0x0401FFC4 RID: 131012
		public bool IsOwn;

		// Token: 0x0401FFC5 RID: 131013
		public bool NeedAddHpEffect;

		// Token: 0x0401FFC6 RID: 131014
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0401FFC7 RID: 131015
		protected HpItem AddHpItem;

		// Token: 0x0401FFC8 RID: 131016
		protected HpItem ReduceHpItem;

		// Token: 0x0200B585 RID: 46469
		[NullableContext(0)]
		private class ERoleHead
		{
			// Token: 0x040382BD RID: 230077
			public const int RoleIcon = 0;

			// Token: 0x040382BE RID: 230078
			public const int OwnBar = 1;

			// Token: 0x040382BF RID: 230079
			public const int OpponentBar = 2;

			// Token: 0x040382C0 RID: 230080
			public const int AttachItem = 3;

			// Token: 0x040382C1 RID: 230081
			public const int DamageBar = 4;
		}
	}
}
