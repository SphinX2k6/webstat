using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EC9 RID: 20169
	internal class TowerDefenseInBattlePanel : BattleChildView
	{
		// Token: 0x060341A0 RID: 213408 RVA: 0x00D05274 File Offset: 0x00D03474
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060341A1 RID: 213409 RVA: 0x00D05364 File Offset: 0x00D03564
		protected override void OnStart()
		{
			this.SeqPlayer = new UiSequencePlayer(this.RootItem);
			this.ContentLayout = new GenericLayout<TowerDefenseInBattleInfoItem, ITowerDefensePhantomSkillItemInBattleData>(base.GetVerticalLayout(4), new Func<TowerDefenseInBattleInfoItem>(ControllerBase<TowerDefenseController>.Instance.BuildPhantomSkillInBattleItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060341A2 RID: 213410 RVA: 0x00D053B7 File Offset: 0x00D035B7
		protected override void OnAfterShow()
		{
			UiSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.LiteStop();
			}
			UiSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 == null)
			{
				return;
			}
			seqPlayer2.LitePlayAsync("Start", false, false);
		}

		// Token: 0x060341A3 RID: 213411 RVA: 0x00D053E4 File Offset: 0x00D035E4
		protected override UniTask OnBeforeHideAsync()
		{
			TowerDefenseInBattlePanel.<OnBeforeHideAsync>d__6 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<TowerDefenseInBattlePanel.<OnBeforeHideAsync>d__6>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060341A4 RID: 213412 RVA: 0x00D05427 File Offset: 0x00D03627
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.LiteExit();
			}
			this.SeqPlayer = null;
		}

		// Token: 0x060341A5 RID: 213413 RVA: 0x00D05444 File Offset: 0x00D03644
		[NullableContext(1)]
		public UniTask GetOrCreateAsync(UUIItem parent, string resourceId)
		{
			TowerDefenseInBattlePanel.<GetOrCreateAsync>d__8 <GetOrCreateAsync>d__;
			<GetOrCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GetOrCreateAsync>d__.<>4__this = this;
			<GetOrCreateAsync>d__.parent = parent;
			<GetOrCreateAsync>d__.resourceId = resourceId;
			<GetOrCreateAsync>d__.<>1__state = -1;
			<GetOrCreateAsync>d__.<>t__builder.Start<TowerDefenseInBattlePanel.<GetOrCreateAsync>d__8>(ref <GetOrCreateAsync>d__);
			return <GetOrCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060341A6 RID: 213414 RVA: 0x00D05498 File Offset: 0x00D03698
		public void Refresh()
		{
			int currentPhantomItemIdInBattle = ControllerBase<TowerDefenseController>.Instance.GetCurrentPhantomItemIdInBattle();
			base.SetItemIcon(base.GetTexture(0), currentPhantomItemIdInBattle, null, null);
			string currentPhantomQualitySpritePathInBattle = ControllerBase<TowerDefenseController>.Instance.GetCurrentPhantomQualitySpritePathInBattle();
			base.TrySetSpriteByPath((currentPhantomQualitySpritePathInBattle == "") ? null : currentPhantomQualitySpritePathInBattle, base.GetSprite(1), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), ControllerBase<TowerDefenseController>.Instance.BuildCurrentPhantomNameTextIdInBattle(), Array.Empty<object>());
			UUIText text = base.GetText(3);
			bool flag = ControllerBase<TowerDefenseController>.Instance.CheckInBossRushInstance();
			text.SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, ControllerBase<TowerDefenseController>.Instance.GetNextLevelUnlockDescriptionInBattle() ?? "", Array.Empty<object>());
			}
			List<ITowerDefensePhantomSkillItemInBattleData> source = ControllerBase<TowerDefenseController>.Instance.BuildPhantomSkillInBattleLayoutData();
			GenericLayout<TowerDefenseInBattleInfoItem, ITowerDefensePhantomSkillItemInBattleData> contentLayout = this.ContentLayout;
			if (contentLayout == null)
			{
				return;
			}
			contentLayout.RefreshByData(source.ToList<ITowerDefensePhantomSkillItemInBattleData>(), null, false);
		}

		// Token: 0x0401E178 RID: 123256
		private bool Created;

		// Token: 0x0401E179 RID: 123257
		[Nullable(2)]
		private UiSequencePlayer SeqPlayer;

		// Token: 0x0401E17A RID: 123258
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<TowerDefenseInBattleInfoItem, ITowerDefensePhantomSkillItemInBattleData> ContentLayout;

		// Token: 0x0200AE68 RID: 44648
		private class EPanelComponent
		{
			// Token: 0x0403624E RID: 221774
			public const int IconTex = 0;

			// Token: 0x0403624F RID: 221775
			public const int QualitySprite = 1;

			// Token: 0x04036250 RID: 221776
			public const int NameTxt = 2;

			// Token: 0x04036251 RID: 221777
			public const int DescTxt = 3;

			// Token: 0x04036252 RID: 221778
			public const int InfoLayout = 4;

			// Token: 0x04036253 RID: 221779
			public const int InfoItem = 5;
		}
	}
}
