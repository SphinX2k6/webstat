using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FEA RID: 24554
	[NullableContext(2)]
	[Nullable(0)]
	public class BossBuffNumItem : BattleVisibleChildView
	{
		// Token: 0x0603DCA7 RID: 253095 RVA: 0x00FBF460 File Offset: 0x00FBD660
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DCA8 RID: 253096 RVA: 0x00FBF4A8 File Offset: 0x00FBD6A8
		protected override void OnStart()
		{
			base.InitChildType(EBattleUiChild.RoleState);
			this.NumText = base.GetText(0);
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603DCA9 RID: 253097 RVA: 0x00FBF4D0 File Offset: 0x00FBD6D0
		protected override void OnBeforeDestroy()
		{
			this.Buff = null;
			this.PresenceCue = null;
			this.StackCue = null;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			base.OnBeforeDestroy();
		}

		// Token: 0x0603DCAA RID: 253098 RVA: 0x00FBF510 File Offset: 0x00FBD710
		public override void Reset()
		{
			this.Buff = null;
			this.CurrentNum = 0;
			this.CurrentStatusPanel = EStatusPanel.None;
			this.Mode = EBossBuffNumMode.StackMode;
			this.BuffFinder = null;
			this.PresenceCue = null;
			this.StackCue = null;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			base.Reset();
		}

		// Token: 0x0603DCAB RID: 253099 RVA: 0x00FBF576 File Offset: 0x00FBD776
		public void SetBuffFinder([Nullable(new byte[]
		{
			1,
			2
		})] Func<int, int, IActiveBuff> finder)
		{
			this.BuffFinder = finder;
		}

		// Token: 0x0603DCAC RID: 253100 RVA: 0x00FBF57F File Offset: 0x00FBD77F
		public void OnCueChanged(int handleId, int entityId, EBossBuffNumMode mode, bool isAdd)
		{
			if (isAdd)
			{
				this.AddCue(handleId, entityId, mode);
			}
			else
			{
				this.RemoveCue(handleId, mode);
			}
			this.RefreshDisplay();
		}

		// Token: 0x0603DCAD RID: 253101 RVA: 0x00FBF59E File Offset: 0x00FBD79E
		public void Tick(float delta)
		{
			if (this.Buff == null)
			{
				this.TryResolvePendingBuff();
				return;
			}
			if (this.Mode == EBossBuffNumMode.PresenceMode)
			{
				return;
			}
			this.RefreshStackCount();
		}

		// Token: 0x0603DCAE RID: 253102 RVA: 0x00FBF5C0 File Offset: 0x00FBD7C0
		private void AddCue(int handleId, int entityId, EBossBuffNumMode mode)
		{
			if (mode == EBossBuffNumMode.PresenceMode)
			{
				if (this.PresenceCue != null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.GHY;
					string message = "BossBuffNumItem.AddCue: PresenceMode 重复添加!";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "existingHandleId";
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.PresenceCue.Value.HandleId);
					ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item2 = "newHandleId";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
					ptr2 = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				this.PresenceCue = new BossBuffNumItem.CueInfo?(new BossBuffNumItem.CueInfo(entityId, handleId));
				return;
			}
			else
			{
				if (this.PresenceCue == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.GHY;
					string message2 = "BossBuffNumItem.AddCue: 添加 StackMode 前必须先有 PresenceMode 实例!";
					string item3 = "handleId";
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item3, defaultInterpolatedStringHandler.ToStringAndClear());
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				if (this.StackCue != null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Battle;
					ELogAuthor author3 = ELogAuthor.GHY;
					string message3 = "BossBuffNumItem.AddCue: StackMode 重复添加!";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
					string item4 = "existingHandleId";
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.StackCue.Value.HandleId);
					ptr3 = new ValueTuple<string, object>(item4, defaultInterpolatedStringHandler.ToStringAndClear());
					ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item5 = "newHandleId";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
					ptr4 = new ValueTuple<string, object>(item5, defaultInterpolatedStringHandler.ToStringAndClear());
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					return;
				}
				this.StackCue = new BossBuffNumItem.CueInfo?(new BossBuffNumItem.CueInfo(entityId, handleId));
				return;
			}
		}

		// Token: 0x0603DCAF RID: 253103 RVA: 0x00FBF788 File Offset: 0x00FBD988
		private void RemoveCue(int handleId, EBossBuffNumMode mode)
		{
			if (mode == EBossBuffNumMode.PresenceMode)
			{
				if (this.PresenceCue == null || this.PresenceCue.Value.HandleId != handleId)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.GHY;
					string message = "BossBuffNumItem.RemoveCue: PresenceMode handleId 不匹配";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "expected";
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int?>((this.PresenceCue != null) ? new int?(this.PresenceCue.GetValueOrDefault().HandleId) : null);
					ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item2 = "actual";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
					ptr2 = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				if (this.StackCue != null)
				{
					this.StackCue = null;
				}
				this.PresenceCue = null;
				return;
			}
			else
			{
				if (this.StackCue == null || this.StackCue.Value.HandleId != handleId)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.GHY;
					string message2 = "BossBuffNumItem.RemoveCue: StackMode handleId 不匹配";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
					string item3 = "expected";
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int?>((this.StackCue != null) ? new int?(this.StackCue.GetValueOrDefault().HandleId) : null);
					ptr3 = new ValueTuple<string, object>(item3, defaultInterpolatedStringHandler.ToStringAndClear());
					ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item4 = "actual";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
					ptr4 = new ValueTuple<string, object>(item4, defaultInterpolatedStringHandler.ToStringAndClear());
					instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					return;
				}
				this.StackCue = null;
				return;
			}
		}

		// Token: 0x0603DCB0 RID: 253104 RVA: 0x00FBF968 File Offset: 0x00FBDB68
		private void RefreshDisplay()
		{
			BossBuffNumItem.CueInfo? stackCue = this.StackCue;
			BossBuffNumItem.CueInfo? cueInfo = (stackCue != null) ? stackCue : this.PresenceCue;
			if (cueInfo == null)
			{
				this.Deactivate();
				return;
			}
			BossBuffNumItem.CueInfo value = cueInfo.Value;
			EBossBuffNumMode mode = (this.StackCue != null) ? EBossBuffNumMode.StackMode : EBossBuffNumMode.PresenceMode;
			Func<int, int, IActiveBuff> buffFinder = this.BuffFinder;
			IActiveBuff activeBuff = (buffFinder != null) ? buffFinder(value.EntityId, value.HandleId) : null;
			this.Mode = mode;
			this.Buff = activeBuff;
			if (activeBuff != null)
			{
				this.ApplyBuffDisplay(activeBuff);
				return;
			}
			this.ShowBattleVisibleChildView(false);
			this.PlaySequence("Start");
		}

		// Token: 0x0603DCB1 RID: 253105 RVA: 0x00FBFA08 File Offset: 0x00FBDC08
		private void TryResolvePendingBuff()
		{
			BossBuffNumItem.CueInfo? stackCue = this.StackCue;
			BossBuffNumItem.CueInfo? cueInfo = (stackCue != null) ? stackCue : this.PresenceCue;
			if (cueInfo == null || this.BuffFinder == null)
			{
				return;
			}
			BossBuffNumItem.CueInfo value = cueInfo.Value;
			IActiveBuff activeBuff = this.BuffFinder(value.EntityId, value.HandleId);
			if (activeBuff != null)
			{
				this.Mode = ((this.StackCue != null) ? EBossBuffNumMode.StackMode : EBossBuffNumMode.PresenceMode);
				this.Buff = activeBuff;
				this.ApplyBuffDisplay(activeBuff);
			}
		}

		// Token: 0x0603DCB2 RID: 253106 RVA: 0x00FBFA8C File Offset: 0x00FBDC8C
		[NullableContext(1)]
		private void ApplyBuffDisplay(IActiveBuff buff)
		{
			bool flag = this.CurrentStatusPanel == EStatusPanel.None;
			int num = (this.Mode == EBossBuffNumMode.PresenceMode) ? 0 : buff.StackCount;
			if (flag)
			{
				this.SetNumText(num);
				this.CurrentNum = num;
				this.CurrentStatusPanel = EStatusPanel.Inactive;
				this.ShowBattleVisibleChildView(false);
				this.PlaySequence("Start");
				if (num > 0)
				{
					this.ApplyNumChange(0, num);
				}
				return;
			}
			this.ApplyNumChange(this.CurrentNum, num);
			this.ShowBattleVisibleChildView(false);
		}

		// Token: 0x0603DCB3 RID: 253107 RVA: 0x00FBFAFF File Offset: 0x00FBDCFF
		private void Deactivate()
		{
			this.Buff = null;
			if (this.CurrentStatusPanel != EStatusPanel.None)
			{
				this.PlaySequence("Close");
			}
			this.CurrentNum = 0;
			this.CurrentStatusPanel = EStatusPanel.None;
			this.HideBattleVisibleChildView();
		}

		// Token: 0x0603DCB4 RID: 253108 RVA: 0x00FBFB30 File Offset: 0x00FBDD30
		private void SetNumText(int num)
		{
			if (this.NumText != null)
			{
				this.NumText.SetText((num <= 0) ? "0" : num.ToString(), true);
			}
		}

		// Token: 0x0603DCB5 RID: 253109 RVA: 0x00FBFB58 File Offset: 0x00FBDD58
		private void RefreshStackCount()
		{
			if (this.Buff == null)
			{
				return;
			}
			int stackCount = this.Buff.StackCount;
			if (stackCount != this.CurrentNum)
			{
				this.ApplyNumChange(this.CurrentNum, stackCount);
			}
		}

		// Token: 0x0603DCB6 RID: 253110 RVA: 0x00FBFB90 File Offset: 0x00FBDD90
		private void ApplyNumChange(int oldNum, int newNum)
		{
			this.SetNumText(newNum);
			this.CurrentNum = newNum;
			if (newNum > oldNum && oldNum >= 0)
			{
				this.PlaySequence("LvUp");
			}
			IActiveBuff buff = this.Buff;
			int? num;
			if (buff == null)
			{
				num = null;
			}
			else
			{
				BuffDefinition config = buff.Config;
				num = ((config != null) ? new int?(config.StackLimitCount) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault(1);
			EStatusPanel estatusPanel = BossBuffNumItem.CalculateStatusPanel(oldNum, valueOrDefault);
			EStatusPanel estatusPanel2 = BossBuffNumItem.CalculateStatusPanel(newNum, valueOrDefault);
			if (estatusPanel != estatusPanel2)
			{
				this.PlayStatusTransition(estatusPanel, estatusPanel2);
			}
		}

		// Token: 0x0603DCB7 RID: 253111 RVA: 0x00FBFC18 File Offset: 0x00FBDE18
		private void PlayStatusTransition(EStatusPanel from, EStatusPanel to)
		{
			string statusTransitionSequence = BossBuffNumItem.GetStatusTransitionSequence(from, to);
			if (statusTransitionSequence == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.GHY;
				string message = "BossBuffNumItem.PlayStatusTransition: 非法状态转换!";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "from";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<EStatusPanel>(from);
				ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item2 = "to";
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<EStatusPanel>(to);
				ptr2 = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (this.LastStatusSequence != null)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.StopSequenceByKey(this.LastStatusSequence, false, true);
				}
			}
			this.CurrentStatusPanel = to;
			this.LastStatusSequence = statusTransitionSequence;
			this.PlaySequence(statusTransitionSequence);
		}

		// Token: 0x0603DCB8 RID: 253112 RVA: 0x00FBFCEB File Offset: 0x00FBDEEB
		private static string GetStatusTransitionSequence(EStatusPanel from, EStatusPanel to)
		{
			if (from == EStatusPanel.Inactive && to == EStatusPanel.Active)
			{
				return "Status1to2";
			}
			if (from == EStatusPanel.Active && to == EStatusPanel.Max)
			{
				return "Status2to3";
			}
			if (from == EStatusPanel.Max && to == EStatusPanel.Inactive)
			{
				return "Status3to1";
			}
			return null;
		}

		// Token: 0x0603DCB9 RID: 253113 RVA: 0x00FBFD16 File Offset: 0x00FBDF16
		private static EStatusPanel CalculateStatusPanel(int num, int maxStack)
		{
			if (num >= maxStack && maxStack > 0)
			{
				return EStatusPanel.Max;
			}
			if (num >= 1)
			{
				return EStatusPanel.Active;
			}
			return EStatusPanel.Inactive;
		}

		// Token: 0x0603DCBA RID: 253114 RVA: 0x00FBFD2C File Offset: 0x00FBDF2C
		[NullableContext(1)]
		private void PlaySequence(string sequenceName)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x04022A8D RID: 141965
		private UUIText NumText;

		// Token: 0x04022A8E RID: 141966
		private IActiveBuff Buff;

		// Token: 0x04022A8F RID: 141967
		private int CurrentNum;

		// Token: 0x04022A90 RID: 141968
		private EStatusPanel CurrentStatusPanel = EStatusPanel.None;

		// Token: 0x04022A91 RID: 141969
		private EBossBuffNumMode Mode;

		// Token: 0x04022A92 RID: 141970
		private Func<int, int, IActiveBuff> BuffFinder;

		// Token: 0x04022A93 RID: 141971
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x04022A94 RID: 141972
		private string LastStatusSequence;

		// Token: 0x04022A95 RID: 141973
		private BossBuffNumItem.CueInfo? PresenceCue;

		// Token: 0x04022A96 RID: 141974
		private BossBuffNumItem.CueInfo? StackCue;

		// Token: 0x0200C06F RID: 49263
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B398 RID: 242584
			NumText
		}

		// Token: 0x0200C070 RID: 49264
		[NullableContext(0)]
		private readonly struct CueInfo
		{
			// Token: 0x0604E3B5 RID: 320437 RVA: 0x015A6CCA File Offset: 0x015A4ECA
			public CueInfo(int entityId, int handleId)
			{
				this.EntityId = entityId;
				this.HandleId = handleId;
			}

			// Token: 0x0403B399 RID: 242585
			public readonly int EntityId;

			// Token: 0x0403B39A RID: 242586
			public readonly int HandleId;
		}
	}
}
