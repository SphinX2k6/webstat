using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055B2 RID: 21938
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardBattleLoadingView : LoadingViewBase
	{
		// Token: 0x06037DB2 RID: 228786 RVA: 0x00E27044 File Offset: 0x00E25244
		public PhantomArenaCardBattleLoadingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037DB3 RID: 228787 RVA: 0x00E27050 File Offset: 0x00E25250
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUITexture))
			};
		}

		// Token: 0x06037DB4 RID: 228788 RVA: 0x00E27174 File Offset: 0x00E25374
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaCardBattleLoadingView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaCardBattleLoadingView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037DB5 RID: 228789 RVA: 0x00E271B7 File Offset: 0x00E253B7
		protected override void OnStart()
		{
			base.OnStart();
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnAnimEnd), false);
			this.InitPlayerInfo();
			this.InitNpcInfo();
		}

		// Token: 0x06037DB6 RID: 228790 RVA: 0x00E271F4 File Offset: 0x00E253F4
		protected override void UpdateProgressRate(float rate)
		{
		}

		// Token: 0x06037DB7 RID: 228791 RVA: 0x00E271F6 File Offset: 0x00E253F6
		protected override void UpdateProgressValue(float value)
		{
			this.SetTextProgressValue(0, value, "");
			if (value == 100f)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.StopSequenceByKey("Loop", false, false);
			}
		}

		// Token: 0x06037DB8 RID: 228792 RVA: 0x00E27224 File Offset: 0x00E25424
		protected override void OnLevelSequencePlayerBandStateChange(bool state)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06037DB9 RID: 228793 RVA: 0x00E27254 File Offset: 0x00E25454
		private UniTask InitBg()
		{
			PhantomArenaCardBattleLoadingView.<InitBg>d__9 <InitBg>d__;
			<InitBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBg>d__.<>4__this = this;
			<InitBg>d__.<>1__state = -1;
			<InitBg>d__.<>t__builder.Start<PhantomArenaCardBattleLoadingView.<InitBg>d__9>(ref <InitBg>d__);
			return <InitBg>d__.<>t__builder.Task;
		}

		// Token: 0x06037DBA RID: 228794 RVA: 0x00E27298 File Offset: 0x00E25498
		private void InitPlayerInfo()
		{
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			int challengeId = ModelBase<PhantomArenaBattleModel>.Instance.ChallengeId;
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).ActivityId;
			int masterLevel = ModelBase<PhantomArenaModel>.Instance.GetMasterLevel(activityId);
			int masterTitleId = ModelBase<PhantomArenaModel>.Instance.GetMasterTitleId(activityId);
			PhantomBattleMasterTitle phantomBattleMasterTitleById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterTitleById(masterTitleId);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(phantomBattleMasterTitleById.Name, phantomBattleMasterTitleById.Name);
			PhantomBattleEnterCtx loadingConfig = ModelBase<PhantomArenaBattleModel>.Instance.LoadingConfig;
			if (loadingConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.WHJ, "Cant get Phantom fighter Config", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int cardRoleId = loadingConfig.CardRoleId;
			PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(cardRoleId);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(playerName ?? "", true);
			}
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(masterLevel);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(multiTextByKey);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.SetTextureByPath(phantomBattleCardRole.RoleHeadTexture, base.GetTexture(1), null, null);
		}

		// Token: 0x06037DBB RID: 228795 RVA: 0x00E273E4 File Offset: 0x00E255E4
		private void InitNpcInfo()
		{
			PhantomBattleEnterCtx loadingConfig = ModelBase<PhantomArenaBattleModel>.Instance.LoadingConfig;
			if (loadingConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.WHJ, "Cant get Phantom fighter Config", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int challengeId = loadingConfig.ChallengeId;
			PhantomBattleChallenge phantomBattleChallengeConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeConfig(challengeId);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(phantomBattleChallengeConfig.NpcName, phantomBattleChallengeConfig.NpcName);
			string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(phantomBattleChallengeConfig.NpcTitle, phantomBattleChallengeConfig.NpcTitle);
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetText(multiTextByKey, true);
			}
			UUIText text2 = base.GetText(6);
			if (text2 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(phantomBattleChallengeConfig.NpcLevel);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(multiTextByKey2);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.SetTextureByPath(phantomBattleChallengeConfig.NpcHead, base.GetTexture(4), null, null);
		}

		// Token: 0x06037DBC RID: 228796 RVA: 0x00E274EC File Offset: 0x00E256EC
		private void OnAnimEnd(string name)
		{
			if (name == "Start")
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
		}

		// Token: 0x0401FF92 RID: 130962
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B56A RID: 46442
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403824D RID: 229965
			public const int Progress = 0;

			// Token: 0x0403824E RID: 229966
			public const int TexRoleLeft = 1;

			// Token: 0x0403824F RID: 229967
			public const int TxtRoleNameLeft = 2;

			// Token: 0x04038250 RID: 229968
			public const int TxtRoleLevelLeft = 3;

			// Token: 0x04038251 RID: 229969
			public const int TexRoleRight = 4;

			// Token: 0x04038252 RID: 229970
			public const int TxtRoleNameRight = 5;

			// Token: 0x04038253 RID: 229971
			public const int TxtRoleLevelRight = 6;

			// Token: 0x04038254 RID: 229972
			public const int TextureBg = 7;

			// Token: 0x04038255 RID: 229973
			public const int TextureTriangleBg = 8;

			// Token: 0x04038256 RID: 229974
			public const int TextureLeftHand = 9;

			// Token: 0x04038257 RID: 229975
			public const int TextureRightHand = 10;

			// Token: 0x04038258 RID: 229976
			public const int TextureHandShadow = 11;
		}
	}
}
