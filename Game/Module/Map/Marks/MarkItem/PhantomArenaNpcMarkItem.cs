using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.PhantomArena;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005851 RID: 22609
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaNpcMarkItem : ConfigMarkItem
	{
		// Token: 0x060397FD RID: 235517 RVA: 0x00E97311 File Offset: 0x00E95511
		public PhantomArenaNpcMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x060397FE RID: 235518 RVA: 0x00E97327 File Offset: 0x00E95527
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.UpdateGamePlayState();
		}

		// Token: 0x060397FF RID: 235519 RVA: 0x00E97338 File Offset: 0x00E95538
		private void UpdateGamePlayState()
		{
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleChallenge? phantomBattleChallenge = (instance != null) ? instance.GetPhantomBattleChallengeByMarkId(this.MarkId) : null;
			if (phantomBattleChallenge == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "PhantomArenaNpcMarkItem找不到对应的挑战数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", this.MarkId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PhantomArenaModel instance3 = ModelBase<PhantomArenaModel>.Instance;
			EChallengeState? echallengeState = (instance3 != null) ? new EChallengeState?(instance3.GetPermanentChallengeStateById(phantomBattleChallenge.Value.Id)) : null;
			base.MarkItemEntity.GamePlay.GamePlayState = ((echallengeState.GetValueOrDefault() == EChallengeState.Finish) ? EMarkGamePlayState.Finish : EMarkGamePlayState.Processing);
		}

		// Token: 0x06039800 RID: 235520 RVA: 0x00E973F1 File Offset: 0x00E955F1
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.PhantomArenaNpcMarkItemView;
		}

		// Token: 0x06039801 RID: 235521 RVA: 0x00E973F5 File Offset: 0x00E955F5
		[PreserveBaseOverrides]
		protected new virtual PhantomArenaNpcMarkItemView CreateView()
		{
			return new PhantomArenaNpcMarkItemView(this);
		}

		// Token: 0x06039802 RID: 235522 RVA: 0x00E97400 File Offset: 0x00E95600
		public override string GetTitleText()
		{
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleChallenge? phantomBattleChallenge = (instance != null) ? instance.GetPhantomBattleChallengeByMarkId(this.MarkId) : null;
			if (phantomBattleChallenge == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取挑战信息失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", this.MarkId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return "";
			}
			PhantomBattleChallengeInfo permanentChallengeData = ModelBase<PhantomArenaModel>.Instance.GetPermanentChallengeData(phantomBattleChallenge.Value.Id);
			bool flag = permanentChallengeData == null || permanentChallengeData.IsUncover;
			return ConfigBase<MapConfig>.Instance.GetLocalText(flag ? this.MarkConfig.Value.MarkTitle : EPhantomArenaTextId.TextMysteryNpcName.ToString());
		}

		// Token: 0x06039803 RID: 235523 RVA: 0x00E974CC File Offset: 0x00E956CC
		public override bool CheckCanShowView()
		{
			if (this.CachedIsWorldMapShowMark == null)
			{
				PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
				PhantomBattleChallenge? phantomBattleChallenge = (instance != null) ? instance.GetPhantomBattleChallengeByMarkId(this.MarkId) : null;
				if (phantomBattleChallenge == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PhantomArena;
					ELogAuthor author = ELogAuthor.CB;
					string message = "PhantomArenaNpcMarkItem找不到对应的挑战数据";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", this.MarkId);
					instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				this.CachedIsWorldMapShowMark = new bool?(phantomBattleChallenge.Value.IsWorldMapShowMark);
			}
			MapModel instance3 = ModelBase<MapModel>.Instance;
			return (instance3 != null && instance3.IsExtraUiMarkType(base.MapType, this.MarkType)) || (this.CachedIsWorldMapShowMark.Value && base.CheckCanShowView());
		}

		// Token: 0x04020A74 RID: 133748
		[Nullable(2)]
		public PhantomArenaNpcMarkItemView InnerView;

		// Token: 0x04020A75 RID: 133749
		private bool? CachedIsWorldMapShowMark;
	}
}
