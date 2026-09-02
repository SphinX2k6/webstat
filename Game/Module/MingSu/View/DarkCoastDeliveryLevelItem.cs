using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x0200573C RID: 22332
	[NullableContext(1)]
	[Nullable(0)]
	public class DarkCoastDeliveryLevelItem : UiPanelBase
	{
		// Token: 0x06038D74 RID: 232820 RVA: 0x00E65D9A File Offset: 0x00E63F9A
		public DarkCoastDeliveryLevelItem(DarkCoastDeliveryLevelData data)
		{
			this.LevelData = data;
		}

		// Token: 0x06038D75 RID: 232821 RVA: 0x00E65DB0 File Offset: 0x00E63FB0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickToggleCallback))
			};
		}

		// Token: 0x06038D76 RID: 232822 RVA: 0x00E65E70 File Offset: 0x00E64070
		protected override void OnBeforeCreateImplement()
		{
			this.UiLevelSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiLevelSequence);
			base.GetExtendToggle(4).CanExecuteChange.Bind(() => base.GetExtendToggle(4).GetToggleState() == EToggleState.ETT_UnChecked);
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06038D77 RID: 232823 RVA: 0x00E65EBF File Offset: 0x00E640BF
		protected override void OnStart()
		{
			this.RefreshUi();
		}

		// Token: 0x06038D78 RID: 232824 RVA: 0x00E65EC7 File Offset: 0x00E640C7
		protected override void OnBeforeShow()
		{
			if (this.IsFirstShow)
			{
				this.PlaySequence(true);
				this.IsFirstShow = false;
			}
		}

		// Token: 0x06038D79 RID: 232825 RVA: 0x00E65EE0 File Offset: 0x00E640E0
		public void RefreshUi()
		{
			DarkCoastDelivery config = this.LevelData.Config;
			MingSuDefine.EDarkCoastDeliveryLevelDataState darkCoastDeliveryGuardState = this.LevelData.GetDarkCoastDeliveryGuardState();
			base.SetTextureShowUntilLoaded(config.Icon, base.GetTexture(0), null);
			this.SetSpriteByPath(config.LevelIcon, base.GetSprite(1), false, null, null);
			this.SetSpriteByPath(config.LevelSelectIcon, base.GetSprite(2), false, null, null);
			base.GetItem(3).SetUIActive(darkCoastDeliveryGuardState == MingSuDefine.EDarkCoastDeliveryLevelDataState.Passed);
		}

		// Token: 0x06038D7A RID: 232826 RVA: 0x00E65F68 File Offset: 0x00E64168
		public void PlaySequence(bool skipToLastFrame)
		{
			switch (this.LevelData.GetDarkCoastDeliveryGuardState())
			{
			case MingSuDefine.EDarkCoastDeliveryLevelDataState.Lock:
				this.UiLevelSequence.PlaySequence("Lock", false, null);
				break;
			case MingSuDefine.EDarkCoastDeliveryLevelDataState.UnLock:
				this.UiLevelSequence.PlaySequence("Unlock", false, null);
				break;
			case MingSuDefine.EDarkCoastDeliveryLevelDataState.Passed:
				this.UiLevelSequence.PlaySequence("Receive", false, null);
				break;
			case MingSuDefine.EDarkCoastDeliveryLevelDataState.Received:
				this.UiLevelSequence.PlaySequence("Done", false, null);
				break;
			}
			if (skipToLastFrame)
			{
				this.UiLevelSequence.StopPrevSequence(false, true);
			}
		}

		// Token: 0x06038D7B RID: 232827 RVA: 0x00E6601C File Offset: 0x00E6421C
		public void SetSelect(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(4).SetToggleStateForce(state2, false, false, false);
		}

		// Token: 0x06038D7C RID: 232828 RVA: 0x00E66044 File Offset: 0x00E64244
		public void JumpUnCheckedToCheckedAnim()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			FToggleAnimationPlayInfo ftoggleAnimationPlayInfo = extendToggle.StateSwitchAnimations.Get(EToggleStateSwitch.UnCheckedToChecked);
			if (ftoggleAnimationPlayInfo == null)
			{
				return;
			}
			FSoftObjectPath levelSequence = ftoggleAnimationPlayInfo.Animation.LevelSequence;
			(extendToggle.GetOwner() as AUIBaseActor).SequenceJumpToEnd(levelSequence);
		}

		// Token: 0x06038D7D RID: 232829 RVA: 0x00E6608E File Offset: 0x00E6428E
		private void OnClickToggleCallback(EToggleState state)
		{
			if (this.ClickToggleCallBack != null)
			{
				this.ClickToggleCallBack(this.LevelData, this);
			}
		}

		// Token: 0x06038D7E RID: 232830 RVA: 0x00E660AA File Offset: 0x00E642AA
		public void SetClickToggleCallback(Action<DarkCoastDeliveryLevelData, DarkCoastDeliveryLevelItem> callback)
		{
			this.ClickToggleCallBack = callback;
		}

		// Token: 0x040205F6 RID: 132598
		public readonly DarkCoastDeliveryLevelData LevelData;

		// Token: 0x040205F7 RID: 132599
		[Nullable(2)]
		public UiBehaviorLevelSequence UiLevelSequence;

		// Token: 0x040205F8 RID: 132600
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<DarkCoastDeliveryLevelData, DarkCoastDeliveryLevelItem> ClickToggleCallBack;

		// Token: 0x040205F9 RID: 132601
		private bool IsFirstShow = true;

		// Token: 0x0200B7E8 RID: 47080
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04038E11 RID: 232977
			public const int MonsterTexture = 0;

			// Token: 0x04038E12 RID: 232978
			public const int LevelIcon = 1;

			// Token: 0x04038E13 RID: 232979
			public const int LevelSelectIcon = 2;

			// Token: 0x04038E14 RID: 232980
			public const int RedDotItem = 3;

			// Token: 0x04038E15 RID: 232981
			public const int Toggle = 4;

			// Token: 0x04038E16 RID: 232982
			public const int ArrowItem = 5;
		}
	}
}
