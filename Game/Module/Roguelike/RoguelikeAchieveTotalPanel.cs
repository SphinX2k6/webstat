using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005133 RID: 20787
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeAchieveTotalPanel : UiPanelBase
	{
		// Token: 0x0603583C RID: 219196 RVA: 0x00D6F6A4 File Offset: 0x00D6D8A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnDetailClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603583D RID: 219197 RVA: 0x00D6F898 File Offset: 0x00D6DA98
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeAchieveTotalPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeAchieveTotalPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603583E RID: 219198 RVA: 0x00D6F8DC File Offset: 0x00D6DADC
		protected override void OnStart()
		{
			this.ElementLayout = new GenericLayout<ElementItem, ElementInfo>(base.GetHorizontalLayout(1), new Func<ElementItem>(this.CreateElementItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
			this.PhantomAffixStateItemLayout = new GenericLayout<RoguelikePhantomAffixStateItem, IRoguelikePhantomAffixStateItemData>(base.GetHorizontalLayout(8), new Func<RoguelikePhantomAffixStateItem>(this.CreatePhantomAffixStateItem), base.GetItem(9).GetOwner() as AUIBaseActor, false, true);
			base.SetUiActive(false);
			this.SetPhantomContentState(false);
			base.GetTexture(7).SetUIActive(false);
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(false);
		}

		// Token: 0x0603583F RID: 219199 RVA: 0x00D6F979 File Offset: 0x00D6DB79
		protected override void OnBeforeDestroy()
		{
			this.CurrentArchiveInfoData = null;
			this.ElementLayout = null;
			this.MainRolePanel = null;
			this.TeamRolePanel1 = null;
			this.TeamRolePanel2 = null;
			this.PhantomAffixStateItemLayout = null;
			this.Vm = null;
		}

		// Token: 0x06035840 RID: 219200 RVA: 0x00D6F9AC File Offset: 0x00D6DBAC
		public void SetViewModel(RoguelikeAchieveViewModel vm)
		{
			this.Vm = vm;
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(this.CurrentArchiveInfoData != null);
		}

		// Token: 0x06035841 RID: 219201 RVA: 0x00D6F9D0 File Offset: 0x00D6DBD0
		[NullableContext(2)]
		public void Refresh(RogueArchiveInfoData archiveInfoData)
		{
			this.CurrentArchiveInfoData = archiveInfoData;
			if (archiveInfoData == null || !archiveInfoData.HasData)
			{
				base.SetUiActive(false);
				return;
			}
			RoguelikeInfo roguelikeInfo = archiveInfoData.RoguelikeInfo;
			base.SetUiActive(true);
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(this.Vm != null);
			}
			RoguelikeAchieveBtnMainRoleItem mainRolePanel = this.MainRolePanel;
			if (mainRolePanel != null)
			{
				mainRolePanel.Refresh(archiveInfoData);
			}
			RoguelikeAchieveTeamRoleItem teamRolePanel = this.TeamRolePanel1;
			if (teamRolePanel != null)
			{
				teamRolePanel.Refresh(archiveInfoData, 1);
			}
			RoguelikeAchieveTeamRoleItem teamRolePanel2 = this.TeamRolePanel2;
			if (teamRolePanel2 != null)
			{
				teamRolePanel2.Refresh(archiveInfoData, 2);
			}
			this.RefreshElementLayout(roguelikeInfo);
			this.RefreshPhantomSection(roguelikeInfo);
		}

		// Token: 0x06035842 RID: 219202 RVA: 0x00D6FA6C File Offset: 0x00D6DC6C
		private void OnBtnDetailClick()
		{
			RogueArchiveInfoData currentArchiveInfoData = this.CurrentArchiveInfoData;
			if (((currentArchiveInfoData != null) ? currentArchiveInfoData.RoguelikeInfo : null) == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(this.CurrentArchiveInfoData.RoguelikeInfo, false, false, ERogueInfoViewPage.Overview);
		}

		// Token: 0x06035843 RID: 219203 RVA: 0x00D6FA9B File Offset: 0x00D6DC9B
		private ElementItem CreateElementItem()
		{
			return new ElementItem();
		}

		// Token: 0x06035844 RID: 219204 RVA: 0x00D6FAA2 File Offset: 0x00D6DCA2
		private RoguelikePhantomAffixStateItem CreatePhantomAffixStateItem()
		{
			return new RoguelikePhantomAffixStateItem();
		}

		// Token: 0x06035845 RID: 219205 RVA: 0x00D6FAAC File Offset: 0x00D6DCAC
		private void RefreshElementLayout(RoguelikeInfo roguelikeInfo)
		{
			List<ElementInfo> list = new List<ElementInfo>();
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			RogueParam? rogueParam;
			foreach (int num in ((instance != null) ? ((instance.GetParamConfigBySeasonId(null) != null) ? rogueParam.GetValueOrDefault().ElementList() : null) : null) ?? Array.Empty<int>())
			{
				list.Add(new ElementInfo(num, roguelikeInfo.ElementDict.GetValueOrDefault(num, 0), null));
			}
			GenericLayout<ElementItem, ElementInfo> elementLayout = this.ElementLayout;
			if (elementLayout == null)
			{
				return;
			}
			elementLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06035846 RID: 219206 RVA: 0x00D6FB4C File Offset: 0x00D6DD4C
		private void RefreshPhantomAffixStateItemLayout(RoguelikeInfo roguelikeInfo, List<AffixEntry> affixEntryList)
		{
			List<IRoguelikePhantomAffixStateItemData> list = new List<IRoguelikePhantomAffixStateItemData>();
			foreach (AffixEntry affixEntry in affixEntryList)
			{
				list.Add(new RoguelikePhantomAffixStateItemData
				{
					AffixEntry = affixEntry,
					IsUnlock = roguelikeInfo.GetIsUnlock(affixEntry)
				});
			}
			GenericLayout<RoguelikePhantomAffixStateItem, IRoguelikePhantomAffixStateItemData> phantomAffixStateItemLayout = this.PhantomAffixStateItemLayout;
			if (phantomAffixStateItemLayout == null)
			{
				return;
			}
			phantomAffixStateItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06035847 RID: 219207 RVA: 0x00D6FBCC File Offset: 0x00D6DDCC
		private void RefreshPhantomSection(RoguelikeInfo roguelikeInfo)
		{
			RogueGainEntry phantomEntry = roguelikeInfo.PhantomEntry;
			if (phantomEntry != null && phantomEntry.ConfigId != 0)
			{
				this.SetPhantomContentState(true);
				this.RefreshPhantomAvatar(phantomEntry.ConfigId);
				this.RefreshPhantomAffixStateItemLayout(roguelikeInfo, phantomEntry.AffixEntryList ?? new List<AffixEntry>());
				return;
			}
			this.SetPhantomContentState(false);
			base.GetTexture(7).SetUIActive(false);
			GenericLayout<RoguelikePhantomAffixStateItem, IRoguelikePhantomAffixStateItemData> phantomAffixStateItemLayout = this.PhantomAffixStateItemLayout;
			if (phantomAffixStateItemLayout == null)
			{
				return;
			}
			phantomAffixStateItemLayout.RefreshByData(new List<IRoguelikePhantomAffixStateItemData>(), null, false);
		}

		// Token: 0x06035848 RID: 219208 RVA: 0x00D6FC40 File Offset: 0x00D6DE40
		private void RefreshPhantomAvatar(int phantomConfigId)
		{
			UUITexture texture = base.GetTexture(7);
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RoguePokemon? roguePokemon = (instance != null) ? instance.GetRoguePhantomConfig(phantomConfigId) : null;
			string text = (roguePokemon != null) ? roguePokemon.GetValueOrDefault().PokemonIcon : null;
			if (roguePokemon == null || string.IsNullOrEmpty(text))
			{
				texture.SetUIActive(false);
				return;
			}
			texture.SetUIActive(true);
			base.SetTextureByPath(text, texture, null, null);
		}

		// Token: 0x06035849 RID: 219209 RVA: 0x00D6FCC0 File Offset: 0x00D6DEC0
		private void SetPhantomContentState(bool hasPhantom)
		{
			base.GetItem(10).SetUIActive(hasPhantom);
			base.GetItem(11).SetUIActive(!hasPhantom);
		}

		// Token: 0x0401EC0D RID: 125965
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<ElementItem, ElementInfo> ElementLayout;

		// Token: 0x0401EC0E RID: 125966
		[Nullable(2)]
		private RoguelikeAchieveBtnMainRoleItem MainRolePanel;

		// Token: 0x0401EC0F RID: 125967
		[Nullable(2)]
		private RoguelikeAchieveTeamRoleItem TeamRolePanel1;

		// Token: 0x0401EC10 RID: 125968
		[Nullable(2)]
		private RoguelikeAchieveTeamRoleItem TeamRolePanel2;

		// Token: 0x0401EC11 RID: 125969
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikePhantomAffixStateItem, IRoguelikePhantomAffixStateItemData> PhantomAffixStateItemLayout;

		// Token: 0x0401EC12 RID: 125970
		[Nullable(2)]
		private RogueArchiveInfoData CurrentArchiveInfoData;

		// Token: 0x0401EC13 RID: 125971
		[Nullable(2)]
		private RoguelikeAchieveViewModel Vm;

		// Token: 0x0200B0D1 RID: 45265
		[NullableContext(0)]
		private class ERoguelikeAchieveTotalPanelComponents
		{
			// Token: 0x04036DA0 RID: 224672
			public const int TotalPanel = 0;

			// Token: 0x04036DA1 RID: 224673
			public const int ElementLayout = 1;

			// Token: 0x04036DA2 RID: 224674
			public const int ElementItem = 2;

			// Token: 0x04036DA3 RID: 224675
			public const int BtnDetail = 3;

			// Token: 0x04036DA4 RID: 224676
			public const int MainRoleItem = 4;

			// Token: 0x04036DA5 RID: 224677
			public const int TeamRoleAItem = 5;

			// Token: 0x04036DA6 RID: 224678
			public const int TeamRoleBItem = 6;

			// Token: 0x04036DA7 RID: 224679
			public const int TexVisionAvatar = 7;

			// Token: 0x04036DA8 RID: 224680
			public const int PhantomAffixStateLayout = 8;

			// Token: 0x04036DA9 RID: 224681
			public const int PhantomAffixStateItem = 9;

			// Token: 0x04036DAA RID: 224682
			public const int PnlContent = 10;

			// Token: 0x04036DAB RID: 224683
			public const int PnlEmpty = 11;
		}
	}
}
