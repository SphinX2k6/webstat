using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005169 RID: 20841
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomSelectItem : GridProxyAbstract<IPhantomSelectItemContextData>
	{
		// Token: 0x06035A11 RID: 219665 RVA: 0x00D7875F File Offset: 0x00D7695F
		public PhantomSelectItem(bool isRaycastTarget = true)
		{
			this.IsRaycastTarget = isRaycastTarget;
		}

		// Token: 0x06035A12 RID: 219666 RVA: 0x00D78780 File Offset: 0x00D76980
		public override void Refresh(IPhantomSelectItemContextData data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x06035A13 RID: 219667 RVA: 0x00D7878C File Offset: 0x00D7698C
		public void Update(IPhantomSelectItemContextData data)
		{
			RogueGainEntry rogueGainEntry = data.RogueGainEntry;
			if (rogueGainEntry.RoguelikeGainDataType.GetValueOrDefault() != RoguelikeGainDataType.Phantom)
			{
				return;
			}
			this.RogueGainEntry = rogueGainEntry;
			this.RoguelikeInfo = data.RoguelikeInfo;
			this.RefreshPanel();
		}

		// Token: 0x06035A14 RID: 219668 RVA: 0x00D787C8 File Offset: 0x00D769C8
		public void SetToggleStateChangeCallback(Action<int> callback)
		{
			this.ToggleStateChangeCallback = callback;
		}

		// Token: 0x06035A15 RID: 219669 RVA: 0x00D787D1 File Offset: 0x00D769D1
		public void SetToggleUnDetermined()
		{
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
		}

		// Token: 0x06035A16 RID: 219670 RVA: 0x00D787E4 File Offset: 0x00D769E4
		public void SetToggleStateForce(bool bSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(5);
			if (bSelected)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06035A17 RID: 219671 RVA: 0x00D78814 File Offset: 0x00D76A14
		public void SetToggleRaycastTarget(bool isRaycastTarget)
		{
			base.GetExtendToggle(5).RootUIComp.Get().SetBubbleUpToParent(isRaycastTarget);
			base.GetExtendToggle(5).SetSelfInteractive(isRaycastTarget);
		}

		// Token: 0x06035A18 RID: 219672 RVA: 0x00D78848 File Offset: 0x00D76A48
		public bool IsSelect()
		{
			return base.GetExtendToggle(5).GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x06035A19 RID: 219673 RVA: 0x00D78859 File Offset: 0x00D76A59
		[NullableContext(2)]
		public UUIItem GetSubItem()
		{
			return base.GetGuideUiItem("0");
		}

		// Token: 0x06035A1A RID: 219674 RVA: 0x00D78868 File Offset: 0x00D76A68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.SelfBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A1B RID: 219675 RVA: 0x00D78A18 File Offset: 0x00D76C18
		private void SelfBtn(EToggleState state)
		{
			Action<int> toggleStateChangeCallback = this.ToggleStateChangeCallback;
			if (toggleStateChangeCallback == null)
			{
				return;
			}
			toggleStateChangeCallback(this.RogueGainEntry.ConfigId);
		}

		// Token: 0x06035A1C RID: 219676 RVA: 0x00D78A38 File Offset: 0x00D76C38
		protected override void OnStart()
		{
			this.PhantomAttrLayout = new GenericLayout<PhantomAttrItem, IPhantomAttrItemData>(base.GetVerticalLayout(3), new Func<PhantomAttrItem>(this.CreatePhantomAttrItem), null, false, true);
			this.SetToggleRaycastTarget(this.IsRaycastTarget);
			base.GetExtendToggle(5).CanExecuteChange.Bind(new Func<bool>(this.CanToggleStateChangeInternal));
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06035A1D RID: 219677 RVA: 0x00D78AA0 File Offset: 0x00D76CA0
		private PhantomAttrItem CreatePhantomAttrItem()
		{
			return new PhantomAttrItem();
		}

		// Token: 0x06035A1E RID: 219678 RVA: 0x00D78AA8 File Offset: 0x00D76CA8
		private bool CanToggleStateChangeInternal()
		{
			if (this.CanToggleStateChange != null)
			{
				EToggleState toggleState = base.GetExtendToggle(5).GetToggleState();
				return this.CanToggleStateChange(toggleState == EToggleState.ETT_Checked);
			}
			return true;
		}

		// Token: 0x06035A1F RID: 219679 RVA: 0x00D78ADB File Offset: 0x00D76CDB
		protected override void OnBeforeDestroy()
		{
			this.ToggleStateChangeCallback = null;
			base.GetExtendToggle(5).CanExecuteChange.Unbind();
		}

		// Token: 0x06035A20 RID: 219680 RVA: 0x00D78AF5 File Offset: 0x00D76CF5
		public void RefreshPanel()
		{
			if (this.RogueGainEntry == null)
			{
				return;
			}
			this.RefreshPhantom();
			this.RefreshAffixEntryList();
		}

		// Token: 0x06035A21 RID: 219681 RVA: 0x00D78B0C File Offset: 0x00D76D0C
		private void RefreshPhantom()
		{
			RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(this.RogueGainEntry.ConfigId);
			if (roguePhantomConfig == null)
			{
				return;
			}
			base.GetText(1).ShowTextNew(roguePhantomConfig.Value.PokemonName);
			base.SetTextureByPath(roguePhantomConfig.Value.PokemonIcon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), roguePhantomConfig.Value.PokemonSkillDesc, Array.Empty<object>());
			base.GetText(2).SetUIActive(ModelBase<RoguelikeModel>.Instance.GetDescModel() == EDescModel.DETAIL);
			RogueQualityConfig? rogueQualityConfigByQualityId = ConfigBase<RoguelikeConfig>.Instance.GetRogueQualityConfigByQualityId(roguePhantomConfig.Value.Quality);
			if (rogueQualityConfigByQualityId != null)
			{
				base.SetTextureByPath(rogueQualityConfigByQualityId.Value.PhantomBgA, base.GetTexture(6), null, null);
				base.SetTextureByPath(rogueQualityConfigByQualityId.Value.PhantomBgB, base.GetTexture(7), null, null);
			}
		}

		// Token: 0x06035A22 RID: 219682 RVA: 0x00D78C2C File Offset: 0x00D76E2C
		private void RefreshAffixEntryList()
		{
			UiAsyncTask task = new UiAsyncTask("PhantomSelectItem.RefreshAffixEntryList", delegate()
			{
				PhantomSelectItem.<<RefreshAffixEntryList>b__26_0>d <<RefreshAffixEntryList>b__26_0>d;
				<<RefreshAffixEntryList>b__26_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshAffixEntryList>b__26_0>d.<>4__this = this;
				<<RefreshAffixEntryList>b__26_0>d.<>1__state = -1;
				<<RefreshAffixEntryList>b__26_0>d.<>t__builder.Start<PhantomSelectItem.<<RefreshAffixEntryList>b__26_0>d>(ref <<RefreshAffixEntryList>b__26_0>d);
				return <<RefreshAffixEntryList>b__26_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06035A23 RID: 219683 RVA: 0x00D78C5C File Offset: 0x00D76E5C
		private List<IPhantomAttrItemData> GetPhantomAttrItemDataList()
		{
			RoguelikeInfo roguelikeInfo = this.RoguelikeInfo;
			List<IPhantomAttrItemData> list = new List<IPhantomAttrItemData>();
			foreach (AffixEntry affixEntry in (this.RogueGainEntry.AffixEntryList ?? new List<AffixEntry>()))
			{
				PhantomAttrItemData item = new PhantomAttrItemData
				{
					AffixEntry = affixEntry,
					RoguelikeInfo = roguelikeInfo
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06035A24 RID: 219684 RVA: 0x00D78CE4 File Offset: 0x00D76EE4
		public void SetUnlockAttrSet(HashSet<long> set)
		{
			this.NewUnlockAttrSet = set;
		}

		// Token: 0x06035A25 RID: 219685 RVA: 0x00D78CF0 File Offset: 0x00D76EF0
		public void PlaySequenceByName(string sequenceName)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName(sequenceName, false, null);
		}

		// Token: 0x0401ECC0 RID: 126144
		public RogueGainEntry RogueGainEntry;

		// Token: 0x0401ECC1 RID: 126145
		public GenericLayout<PhantomAttrItem, IPhantomAttrItemData> PhantomAttrLayout;

		// Token: 0x0401ECC2 RID: 126146
		public bool IsRaycastTarget = true;

		// Token: 0x0401ECC3 RID: 126147
		public HashSet<long> NewUnlockAttrSet = new HashSet<long>();

		// Token: 0x0401ECC4 RID: 126148
		public Func<bool, bool> CanToggleStateChange;

		// Token: 0x0401ECC5 RID: 126149
		private RoguelikeInfo RoguelikeInfo;

		// Token: 0x0401ECC6 RID: 126150
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401ECC7 RID: 126151
		private Action<int> ToggleStateChangeCallback;

		// Token: 0x0200B114 RID: 45332
		[NullableContext(0)]
		private class EPhantomSelectItemCom
		{
			// Token: 0x04036ED4 RID: 224980
			public const int HeadTexture = 0;

			// Token: 0x04036ED5 RID: 224981
			public const int NameText = 1;

			// Token: 0x04036ED6 RID: 224982
			public const int DescText = 2;

			// Token: 0x04036ED7 RID: 224983
			public const int AttrListLayout = 3;

			// Token: 0x04036ED8 RID: 224984
			public const int AttrItem = 4;

			// Token: 0x04036ED9 RID: 224985
			public const int SelfToggle = 5;

			// Token: 0x04036EDA RID: 224986
			public const int QualityBg = 6;

			// Token: 0x04036EDB RID: 224987
			public const int QualityHeadBg = 7;

			// Token: 0x04036EDC RID: 224988
			public const int AttrViewport = 8;

			// Token: 0x04036EDD RID: 224989
			public const int AttrContent = 9;
		}
	}
}
