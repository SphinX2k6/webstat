using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.SubPanel
{
	// Token: 0x02005835 RID: 22581
	public class PhantomArenaMapNpcUi : UiPanelBase
	{
		// Token: 0x06039673 RID: 235123 RVA: 0x00E92DD0 File Offset: 0x00E90FD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039674 RID: 235124 RVA: 0x00E92EBD File Offset: 0x00E910BD
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new UiSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequence));
		}

		// Token: 0x06039675 RID: 235125 RVA: 0x00E92EE8 File Offset: 0x00E910E8
		[NullableContext(1)]
		private void OnEndSequence(string sequenceName)
		{
			if (sequenceName == "Start" && this.IsNeedUnlockEffect)
			{
				UiSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequence("Unlock", false, null);
				}
				this.IsNeedUnlockEffect = false;
			}
		}

		// Token: 0x06039676 RID: 235126 RVA: 0x00E92F34 File Offset: 0x00E91134
		protected override void OnAfterShow()
		{
			UiSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequence("Start", false, null);
		}

		// Token: 0x06039677 RID: 235127 RVA: 0x00E92F60 File Offset: 0x00E91160
		public void SetData(int markId)
		{
			if (this.MarkId == markId)
			{
				return;
			}
			this.MarkId = markId;
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleChallenge? phantomBattleChallenge = (instance != null) ? instance.GetPhantomBattleChallengeByMarkId(markId) : null;
			if (phantomBattleChallenge == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "PhantomArenaMapNpcUi找不到对应的挑战数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PhantomArenaModel instance3 = ModelBase<PhantomArenaModel>.Instance;
			EChallengeState? echallengeState = (instance3 != null) ? new EChallengeState?(instance3.GetPermanentChallengeStateById(phantomBattleChallenge.Value.Id)) : null;
			UUITexture texture = base.GetTexture(6);
			if (texture != null)
			{
				texture.SetUIActive(echallengeState.GetValueOrDefault() == EChallengeState.Finish);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(echallengeState.GetValueOrDefault() == EChallengeState.Finish);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				EChallengeState? echallengeState2 = echallengeState;
				EChallengeState echallengeState3 = EChallengeState.Lock;
				item2.SetUIActive(echallengeState2.GetValueOrDefault() == echallengeState3 & echallengeState2 != null);
			}
			PhantomArenaModel instance4 = ModelBase<PhantomArenaModel>.Instance;
			bool? flag;
			if (instance4 == null)
			{
				flag = null;
			}
			else
			{
				PhantomBattleChallengeInfo permanentChallengeData = instance4.GetPermanentChallengeData(phantomBattleChallenge.Value.Id);
				flag = ((permanentChallengeData != null) ? new bool?(permanentChallengeData.IsUncover) : null);
			}
			bool? flag2 = flag;
			string path = flag2.GetValueOrDefault(true) ? phantomBattleChallenge.Value.NpcMapHead : ConfigBase<UiResourceConfig>.Instance.GetResourcePath("MysteryNpcHead");
			base.TrySetTextureByPath(path, base.GetTexture(2), null, null);
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(phantomBattleChallenge.Value.NpcNumber, true);
			}
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			HashSet<int> hashSet = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetCurrentUnlockChallengeIds() : null;
			if (hashSet != null && hashSet.Contains(phantomBattleChallenge.Value.Id))
			{
				this.IsNeedUnlockEffect = true;
				hashSet.Remove(phantomBattleChallenge.Value.Id);
			}
		}

		// Token: 0x06039678 RID: 235128 RVA: 0x00E93164 File Offset: 0x00E91364
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x04020A37 RID: 133687
		[Nullable(2)]
		private UiSequencePlayer LevelSequencePlayer;

		// Token: 0x04020A38 RID: 133688
		private bool IsNeedUnlockEffect;

		// Token: 0x04020A39 RID: 133689
		private int MarkId;

		// Token: 0x0200B8A8 RID: 47272
		public static class EComponents
		{
			// Token: 0x04039174 RID: 233844
			public const int SelfItem = 0;

			// Token: 0x04039175 RID: 233845
			public const int TextNum = 1;

			// Token: 0x04039176 RID: 233846
			public const int TexNpc = 2;

			// Token: 0x04039177 RID: 233847
			public const int PnlLock = 3;

			// Token: 0x04039178 RID: 233848
			public const int PnlDone = 4;

			// Token: 0x04039179 RID: 233849
			public const int TexBg = 5;

			// Token: 0x0403917A RID: 233850
			public const int TexDoneBg = 6;
		}
	}
}
