using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhoneMessage.View
{
	// Token: 0x0200545F RID: 21599
	[NullableContext(1)]
	[Nullable(0)]
	public class PhoneMessageButtonHelper
	{
		// Token: 0x06037047 RID: 225351 RVA: 0x00DF6D50 File Offset: 0x00DF4F50
		public PhoneMessageButtonHelper(UUIItem RootItem, AUIBaseActor RootActor, UUIItem RedDotItem, UUISprite SpriteEnterIcon, UUIItem PanelPrefabHead, UUITexture TexIconHead, UUIItem BubbleItem, UUINiagara NiagaraItem, Action<string, UUITexture> SetTextureByPathFunc)
		{
		}

		// Token: 0x06037048 RID: 225352 RVA: 0x00DF6DC0 File Offset: 0x00DF4FC0
		public void Init()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.<RootItem>P);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceFinishEvent), false);
			this.<RootActor>P.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
			this.RedDotInitAlpha = this.<RedDotItem>P.GetAlpha();
			this.RedDotInitScale = new FVector?(this.<RedDotItem>P.GetRelativeTransform().GetScale3D());
			this.EnterIconInitAlpha = this.<SpriteEnterIcon>P.GetAlpha();
			this.EnterIconInitScale = new FVector?(this.<SpriteEnterIcon>P.GetRelativeTransform().GetScale3D());
		}

		// Token: 0x06037049 RID: 225353 RVA: 0x00DF6E70 File Offset: 0x00DF5070
		public void OnShowBattleChildView()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) == "Phone_Icon_Out")
			{
				return;
			}
			if (ModelBase<PhoneMsgModel>.Instance.CurrentShowingMsgIdInSmallHead == 0)
			{
				if (this.CheckModelQueueHaveId())
				{
					this.PopShowHeadIcon();
					return;
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.StopCurrentSequence(false, false);
				}
				this.<PanelPrefabHead>P.SetUIActive(false);
				this.<SpriteEnterIcon>P.SetUIActive(true);
				this.ResetButton();
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 == null)
				{
					return;
				}
				levelSequencePlayer3.ResumeSequence();
				return;
			}
		}

		// Token: 0x0603704A RID: 225354 RVA: 0x00DF6EF9 File Offset: 0x00DF50F9
		public void OnHideBattleChildView()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PauseSequence();
		}

		// Token: 0x0603704B RID: 225355 RVA: 0x00DF6F0B File Offset: 0x00DF510B
		public void Clear()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x0603704C RID: 225356 RVA: 0x00DF6F25 File Offset: 0x00DF5125
		public void CheckAndPlayPhoneSequence()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) != null)
			{
				return;
			}
			if (!this.CheckModelQueueHaveId())
			{
				return;
			}
			this.PlayPhoneSequence("Phone_Icon_Out");
		}

		// Token: 0x0603704D RID: 225357 RVA: 0x00DF6F50 File Offset: 0x00DF5150
		public void PopShowHeadIcon()
		{
			if (!this.CheckModelQueueHaveId())
			{
				return;
			}
			PhoneMsgModel instance = ModelBase<PhoneMsgModel>.Instance;
			List<int> currentToBeNotifiedMsgInSmallHeadQueue = instance.CurrentToBeNotifiedMsgInSmallHeadQueue;
			int num = currentToBeNotifiedMsgInSmallHeadQueue[0];
			currentToBeNotifiedMsgInSmallHeadQueue.RemoveAt(0);
			instance.CurrentShowingMsgIdInSmallHead = num;
			this.SetAndShowHeadIcon(num);
		}

		// Token: 0x0603704E RID: 225358 RVA: 0x00DF6F8C File Offset: 0x00DF518C
		private void SetAndShowHeadIcon(int shortMessageId)
		{
			int whichChat = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(shortMessageId).Value.WhichChat;
			string iconSmall = ModelBase<PhoneMsgModel>.Instance.GetChatPartnerConfigNew(whichChat).Value.IconSmall;
			this.<PanelPrefabHead>P.SetUIActive(true);
			this.<BubbleItem>P.SetUIActive(true);
			this.<SetTextureByPathFunc>P(iconSmall, this.<TexIconHead>P);
			this.PlayPhoneSequence("Phone_Circle_In");
		}

		// Token: 0x0603704F RID: 225359 RVA: 0x00DF7008 File Offset: 0x00DF5208
		public void HideHeadIcon()
		{
			this.PlayPhoneSequence("Phone_Icon_In");
			this.<BubbleItem>P.SetUIActive(false);
			ModelBase<PhoneMsgModel>.Instance.CurrentShowingMsgIdInSmallHead = 0;
		}

		// Token: 0x06037050 RID: 225360 RVA: 0x00DF702C File Offset: 0x00DF522C
		private void SequenceFinishEvent(string sequenceName)
		{
			if (sequenceName == "Phone_Circle_In")
			{
				if (!this.CheckModelQueueHaveId())
				{
					this.HideHeadIcon();
					return;
				}
				this.PopShowHeadIcon();
			}
			if (sequenceName == "Phone_Icon_Out")
			{
				if (!this.CheckModelQueueHaveId())
				{
					this.HideHeadIcon();
					return;
				}
				this.PopShowHeadIcon();
			}
			if (sequenceName == "Phone_Icon_In")
			{
				if (!this.CheckModelQueueHaveId())
				{
					this.ResetButton();
					return;
				}
				this.PlayPhoneSequence("Phone_Icon_Out");
			}
		}

		// Token: 0x06037051 RID: 225361 RVA: 0x00DF70A4 File Offset: 0x00DF52A4
		private void ResetButton()
		{
			this.<SpriteEnterIcon>P.SetUIActive(true);
			this.<PanelPrefabHead>P.SetUIActive(false);
			this.<NiagaraItem>P.SetUIActive(false);
			this.<RedDotItem>P.SetAlpha(this.RedDotInitAlpha);
			if (this.RedDotInitScale != null)
			{
				this.<RedDotItem>P.SetUIItemScale(this.RedDotInitScale.Value);
			}
			this.<SpriteEnterIcon>P.SetAlpha(this.EnterIconInitAlpha);
			if (this.EnterIconInitScale != null)
			{
				this.<SpriteEnterIcon>P.SetUIItemScale(this.EnterIconInitScale.Value);
			}
		}

		// Token: 0x06037052 RID: 225362 RVA: 0x00DF7140 File Offset: 0x00DF5340
		private void PlayPhoneSequence(string sequenceKey)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null && levelSequencePlayer.CheckSeqActorIsUnStopped(sequenceKey))
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.ReplaySequenceByKey(sequenceKey);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 == null)
				{
					return;
				}
				levelSequencePlayer3.PlaySequencePurely(sequenceKey, false, false, null, null, false);
				return;
			}
		}

		// Token: 0x06037053 RID: 225363 RVA: 0x00DF7192 File Offset: 0x00DF5392
		private bool CheckModelQueueHaveId()
		{
			return ModelBase<PhoneMsgModel>.Instance.CurrentToBeNotifiedMsgInSmallHeadQueue.Count > 0;
		}

		// Token: 0x06037054 RID: 225364 RVA: 0x00DF71A6 File Offset: 0x00DF53A6
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (eventName == "Phone_Circle_Switch")
			{
				this.PopShowHeadIcon();
			}
		}

		// Token: 0x0401FA6D RID: 129645
		[CompilerGenerated]
		private UUIItem <RootItem>P = RootItem;

		// Token: 0x0401FA6E RID: 129646
		[CompilerGenerated]
		private AUIBaseActor <RootActor>P = RootActor;

		// Token: 0x0401FA6F RID: 129647
		[CompilerGenerated]
		private UUIItem <RedDotItem>P = RedDotItem;

		// Token: 0x0401FA70 RID: 129648
		[CompilerGenerated]
		private UUISprite <SpriteEnterIcon>P = SpriteEnterIcon;

		// Token: 0x0401FA71 RID: 129649
		[CompilerGenerated]
		private UUIItem <PanelPrefabHead>P = PanelPrefabHead;

		// Token: 0x0401FA72 RID: 129650
		[CompilerGenerated]
		private UUITexture <TexIconHead>P = TexIconHead;

		// Token: 0x0401FA73 RID: 129651
		[CompilerGenerated]
		private UUIItem <BubbleItem>P = BubbleItem;

		// Token: 0x0401FA74 RID: 129652
		[CompilerGenerated]
		private UUINiagara <NiagaraItem>P = NiagaraItem;

		// Token: 0x0401FA75 RID: 129653
		[CompilerGenerated]
		private Action<string, UUITexture> <SetTextureByPathFunc>P = SetTextureByPathFunc;

		// Token: 0x0401FA76 RID: 129654
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401FA77 RID: 129655
		private float RedDotInitAlpha = 1f;

		// Token: 0x0401FA78 RID: 129656
		private float EnterIconInitAlpha = 1f;

		// Token: 0x0401FA79 RID: 129657
		private FVector? RedDotInitScale;

		// Token: 0x0401FA7A RID: 129658
		private FVector? EnterIconInitScale;
	}
}
